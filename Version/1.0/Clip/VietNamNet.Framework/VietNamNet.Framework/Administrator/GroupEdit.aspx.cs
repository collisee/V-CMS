using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.DBAccess;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.Administrator
{
    public partial class GroupEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0) //update
                {
                    if (!isUpdater)
                    {
                        Utilities.NoRightToAccess();
                    }

                    GroupHelper helper = new GroupHelper(new Group());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindDataToUsers();
                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else // add nbew
                {
                    if (!isAddNewer)
                    {
                        Utilities.NoRightToCreate();
                    }

                    BindDataToUsers();
                    ViewState[SystemConstants.ViewState.SystemData.Members] = null;
                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }

                //Focus
                //txtName.Focus();
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.Administrator";
            viewAlias = "System.Administrator.View";
            addNewAlias = "System.Administrator.AddNew";
            updateAlias = "System.Administrator.Update";
            deleteAlias = "System.Administrator.Delete";
        }

        private void BindDataToUsers()
        {
            UserHelper helper = new UserHelper(new User());
            ViewState[SystemConstants.ViewState.SystemData.NotMembers] = Utilities.EncodeDatatable(helper.ListAll());
        }

        private void BindData(Group o)
        {
            txtName.Text = o.Name;
            txtDetail.Text = o.Detail;

            ViewState[SystemConstants.ViewState.SystemData.Members] = o.Members;
        }

        private void GetData(Group o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            //Members
            o.Members = (ViewState[SystemConstants.ViewState.SystemData.Members] == null)
                            ? GroupMemberDAO.GetTemplateTable()
                            : (DataTable) ViewState[SystemConstants.ViewState.SystemData.Members];
        }

        private void DoSave()
        {
            GroupHelper helper = new GroupHelper(new Group());
            GetData(helper.ValueObject);
            AuditTrail1.Set(helper.ValueObject);
            helper.DoSave();

            //Redirect to Diplay page
            Utilities.Redirect(SystemConstants.FormNames.Administrator.GroupDisplay, helper.ValueObject.Id.ToString(),
                               true);
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave();
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.GroupView);
                    break;
                default:
                    break;
            }
        }

        protected void radGridUsers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridUsers.DataSource = ViewState[SystemConstants.ViewState.SystemData.NotMembers];
        }

        protected void radGridMembers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtMembers = (ViewState[SystemConstants.ViewState.SystemData.Members] != null)
                                      ? (DataTable) ViewState[SystemConstants.ViewState.SystemData.Members]
                                      : GroupMemberDAO.GetTemplateTable();
            radGridMembers.DataSource = dtMembers.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridUsers_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridUsers.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[SystemConstants.ViewState.SystemData.Members])) 
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridMembers.ClientID)
                    {
                        DataTable dtMembers = (ViewState[SystemConstants.ViewState.SystemData.Members] == null)
                                                  ? GroupMemberDAO.GetTemplateTable()
                                                  : (DataTable) ViewState[SystemConstants.ViewState.SystemData.Members];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int userId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string loginName = draggedItem.GetDataKeyValue("LoginName").ToString();
                            string fullName = draggedItem.GetDataKeyValue("FullName").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtMembers.Rows)
                            {
                                if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.UserId]) ==
                                    userId)
                                {
                                    //change Status
                                    if (
                                        Utilities.StringCompare(
                                            row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                            Constants.CommonStatus.DELETE))
                                    {
                                        int id =
                                            Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.Id]);
                                        string status = (id > 0)
                                                            ? Constants.CommonStatus.UPDATE
                                                            : Constants.CommonStatus.NEW;
                                        row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = status;
                                        row[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_At] =
                                            DateTime.Now;
                                        row[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_By] = UserId;
                                    }
                                    //mask existed
                                    blnExist = true;
                                    break;
                                }
                            }

                            if (blnExist) continue;

                            //add memberOf
                            DataRow drNew = dtMembers.NewRow();
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Id] = 0;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.GroupId] = 0;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.UserId] = userId;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.LoginName] = loginName;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.FullName] = fullName;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Created_At] = DateTime.Now;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Created_By] = UserId;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_By] = UserId;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] =
                                Constants.CommonStatus.NEW;
                            dtMembers.Rows.Add(drNew);
                        }

                        ViewState[SystemConstants.ViewState.SystemData.Members] = dtMembers;

                        radGridMembers.Rebind();
                    }
                }
            }
        }

        protected void radGridMembers_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridMembers.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[SystemConstants.ViewState.SystemData.NotMembers]))
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridUsers.ClientID)
                    {
                        DataTable dtMembers = (ViewState[SystemConstants.ViewState.SystemData.Members] == null)
                                                  ? GroupMemberDAO.GetTemplateTable()
                                                  : (DataTable) ViewState[SystemConstants.ViewState.SystemData.Members];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int userId = Utilities.ParseInt(draggedItem.GetDataKeyValue("UserId"));

                            foreach (DataRow row in dtMembers.Rows)
                            {
                                if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.UserId]) ==
                                    userId)
                                {
                                    //remove memberOf
                                    row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] =
                                        Constants.CommonStatus.DELETE;
                                    //break;
                                    break;
                                }
                            }
                        }

                        ViewState[SystemConstants.ViewState.SystemData.Members] = dtMembers;

                        radGridMembers.Rebind();
                    }
                }
            }
        }

        protected void radGridMembers_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtMembers = (ViewState[SystemConstants.ViewState.SystemData.Members] == null)
                                          ? GroupMemberDAO.GetTemplateTable()
                                          : (DataTable)ViewState[SystemConstants.ViewState.SystemData.Members];

                int userId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"]);

                foreach (DataRow row in dtMembers.Rows)
                {
                    if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.UserId]) == userId)
                    {
                        //remove memberOf
                        row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        //break;
                        break;
                    }
                }

                ViewState[SystemConstants.ViewState.SystemData.Members] = dtMembers;

                radGridMembers.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridUsers_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtMembers = (ViewState[SystemConstants.ViewState.SystemData.Members] == null)
                                          ? GroupMemberDAO.GetTemplateTable()
                                          : (DataTable)ViewState[SystemConstants.ViewState.SystemData.Members];

                int userId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string loginName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LoginName"].ToString();
                string fullName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FullName"].ToString();

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtMembers.Rows)
                {
                    if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.UserId]) == userId)
                    {
                        //change Status
                        if (
                            Utilities.StringCompare(row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                                    Constants.CommonStatus.DELETE))
                        {
                            int id = Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.Id]);
                            string status = (id > 0)
                                                ? Constants.CommonStatus.UPDATE
                                                : Constants.CommonStatus.NEW;
                            row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = status;
                            row[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_At] = DateTime.Now;
                            row[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_By] = UserId;
                        }
                        //mask existed
                        blnExist = true;
                        break;
                    }
                }

                if (!blnExist)
                {
                    //add memberOf
                    DataRow drNew = dtMembers.NewRow();
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Id] = 0;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.GroupId] = 0;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.UserId] = userId;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.LoginName] = loginName;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.FullName] = fullName;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Created_At] = DateTime.Now;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Created_By] = UserId;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_By] = UserId;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    dtMembers.Rows.Add(drNew);
                }

                ViewState[SystemConstants.ViewState.SystemData.Members] = dtMembers;

                radGridMembers.Rebind();

                e.Canceled = true;
            }
        }
    }
}