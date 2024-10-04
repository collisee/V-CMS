using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Encryption;
using VietNamNet.Framework.System.DBAccess;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class UserEdit : BasePage
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

                    UserHelper helper = new UserHelper(new User());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindDataToGroups();
                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else//add new
                {
                    if (!isAddNewer)
                    {
                        Utilities.NoRightToCreate();
                    }

                    BindDataToGroups();
                    ViewState[SystemConstants.ViewState.SystemData.MemberOf] = null;
                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }

                txtLoginName.Focus();
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.Administrator";
            viewAlias = "System.Administrator.View";
            addNewAlias = "System.Administrator.AddNew";
            updateAlias = "System.Administrator.Update";
            deleteAlias = "System.Administrator.Delete";
            ErrorMessage1.Visible = false;
            ErrorMessage1.ClearMessage();
        }

        private void BindDataToGroups()
        {
            GroupHelper helper = new GroupHelper(new Group());
            ViewState[SystemConstants.ViewState.SystemData.NotMemberOf] = Utilities.EncodeDatatable(helper.ListAll());
        }

        private void BindData(User o)
        {
            cmbStatus.SelectedValue = o.Status;
            txtLoginName.Text = o.LoginName;
            txtFullName.Text = o.FullName;
            txtEmail.Text = o.Email;
            txtAvatar.Text = o.Avatar;
            radDpkBirthday.SelectedDate = o.Birthday;
            cmbSex.SelectedValue = o.Sex;
            txtAddress.Text = o.Address;
            txtPhone.Text = o.Phone;
            txtMobile.Text = o.Mobile;
            txtYahoo.Text = o.Yahoo;
            txtSkype.Text = o.Skype;
            txtFacebook.Text = o.Facebook;
            txtDetail.Text = o.Detail;

            //
            ViewState[SystemConstants.ViewState.SystemData.MemberOf] = o.MemberOf;
        }

        private bool GetData(User o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            o.Id = docId;

            //Valid user & user email
            bool blnValid = true;
            UserHelper validLoginNameHelper = new UserHelper(new User());
            validLoginNameHelper.ValueObject.LoginName = txtLoginName.Text.Trim();
            validLoginNameHelper.GetUserByLoginName();
            if (validLoginNameHelper.ValueObject != null && validLoginNameHelper.ValueObject.Id != docId)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.LoginNameExisted));
                blnValid = false;
            }

            UserHelper validEmailHelper = new UserHelper(new User());
            validEmailHelper.ValueObject.Email = txtEmail.Text.Trim();
            validEmailHelper.GetUserByEmail();
            if (validEmailHelper.ValueObject != null && validEmailHelper.ValueObject.Id != docId)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.EmailExisted));
                blnValid = false;
            }

            //Email
            if (Nulls.IsNullOrEmpty(txtEmail))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.EmailCantEmpty));
                blnValid = false;
            }
            //Birthday
            if (radDpkBirthday.SelectedDate == null)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.DateOfBirthCantEmpty));
                blnValid = false;
            }
            //Password
            if (!Nulls.IsNullOrEmpty(txtPassword.Text.Trim()) || !Nulls.IsNullOrEmpty(txtRetypePassword.Text.Trim()))
            {
                if (!Utilities.StringCompare(txtPassword.Text.Trim(), txtRetypePassword.Text.Trim()))
                {
                    ErrorMessage1.Visible = true;
                    ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.PasswordAndRetypeError));
                    blnValid = false;
                }
            }

            if (!blnValid)
            {
                return false;
            }

            //Getdata
            o.Status = cmbStatus.SelectedValue;
            o.LoginName = txtLoginName.Text.Trim();
            o.FullName = txtFullName.Text.Trim();
            o.Email = txtEmail.Text.Trim();
            o.Avatar = txtAvatar.Text.Trim();
            o.Birthday = (DateTime)radDpkBirthday.SelectedDate;
            o.Sex = cmbSex.SelectedValue;
            o.Address = txtAddress.Text.Trim();
            o.Phone = txtPhone.Text.Trim();
            o.Mobile = txtMobile.Text.Trim();
            o.Yahoo = txtYahoo.Text.Trim();
            o.Skype = txtSkype.Text.Trim();
            o.Facebook = txtFacebook.Text.Trim();
            o.Detail = txtDetail.Text.Trim();
            if (docId == 0) o.Skin = "Office2007";
            o.Password = Nulls.IsNullOrEmpty(txtPassword.Text.Trim())
                             ? (docId == 0) ? string.Empty : o.Password
                             : MD5Encrypt.Encrypt(txtPassword.Text.Trim());
            //MemberOf
            o.MemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] == null)
                             ? GroupMemberDAO.GetTemplateTable()
                             : (DataTable) ViewState[SystemConstants.ViewState.SystemData.MemberOf];
            return true;
        }

        private void DoSave()
        {
            UserHelper helper = new UserHelper(new User());
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            if (docId > 0)
            {
                helper.ValueObject.Id = docId;
                helper.Load();
                if (helper.ValueObject == null)
                {
                    Utilities.ItemDoesntExist();
                    return;
                }
            }
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //send email
                if (!Nulls.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    SystemEmailFunction.SendNewPassword(helper.ValueObject, txtPassword.Text.Trim());
                }

                //Redirect to Diplay page
                Utilities.Redirect(SystemConstants.FormNames.Administrator.UserDisplay, helper.ValueObject.Id.ToString(), true);
            }
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
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.UserView);
                    break;
                default:
                    break;
            }
        }

        protected void radGridGroups_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridGroups.DataSource = ViewState[SystemConstants.ViewState.SystemData.NotMemberOf];
        }

        protected void radGridMemberOf_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtMemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] != null)
                                    ? (DataTable)ViewState[SystemConstants.ViewState.SystemData.MemberOf]
                                    : GroupMemberDAO.GetTemplateTable();
            radGridMemberOf.DataSource = dtMemberOf.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridGroups_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridGroups.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[SystemConstants.ViewState.SystemData.MemberOf])) 
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridMemberOf.ClientID)
                    {
                        DataTable dtMemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] == null)
                                                ? GroupMemberDAO.GetTemplateTable()
                                                : (DataTable)ViewState[SystemConstants.ViewState.SystemData.MemberOf];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int groupId = Utilities.ParseInt(draggedItem.GetDataKeyValue("Id"));
                            string groupName = draggedItem.GetDataKeyValue("Name").ToString();

                            //check exist
                            bool blnExist = false;
                            foreach (DataRow row in dtMemberOf.Rows)
                            {
                                if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.GroupId]) == groupId)
                                {
                                    //change Status
                                    if (Utilities.StringCompare(row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus], Constants.CommonStatus.DELETE))
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

                            if (blnExist) continue;
                    
                            //add memberOf
                            DataRow drNew = dtMemberOf.NewRow();
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Id] = 0;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.GroupId] = groupId;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.UserId] = 0;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.GroupName] = groupName;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Created_At] = DateTime.Now;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Created_By] = UserId;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_At] = DateTime.Now;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_By] = UserId;
                            drNew[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                            dtMemberOf.Rows.Add(drNew);
                        }

                        ViewState[SystemConstants.ViewState.SystemData.MemberOf] = dtMemberOf;

                        radGridMemberOf.Rebind();
                    }
                }
            }
        }

        protected void radGridMemberOf_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (Nulls.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == radGridMemberOf.ClientID)
                {
                    //if ((e.DestDataItem == null && checkDataTableEmpty(ViewState[SystemConstants.ViewState.SystemData.NotMemberOf]))
                    if ((e.DestDataItem == null)
                        || e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridGroups.ClientID)
                    {
                        DataTable dtMemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] == null)
                                                ? GroupMemberDAO.GetTemplateTable()
                                                : (DataTable)ViewState[SystemConstants.ViewState.SystemData.MemberOf];

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            int groupId = Utilities.ParseInt(draggedItem.GetDataKeyValue("GroupId"));

                            foreach (DataRow row in dtMemberOf.Rows)
                            {
                                if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.GroupId]) == groupId)
                                {
                                    //remove memberOf
                                    row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                                    //break;
                                    break;
                                }
                            }
                        }

                        ViewState[SystemConstants.ViewState.SystemData.MemberOf] = dtMemberOf;

                        radGridMemberOf.Rebind();
                    }
                }
            }
        }

        protected void radGridGroups_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtMemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] == null)
                                           ? GroupMemberDAO.GetTemplateTable()
                                           : (DataTable) ViewState[SystemConstants.ViewState.SystemData.MemberOf];

                int groupId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                string groupName = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Name"].ToString();

                //check exist
                bool blnExist = false;
                foreach (DataRow row in dtMemberOf.Rows)
                {
                    if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.GroupId]) == groupId)
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
                    DataRow drNew = dtMemberOf.NewRow();
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Id] = 0;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.GroupId] = groupId;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.UserId] = 0;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.GroupName] = groupName;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Created_At] = DateTime.Now;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Created_By] = UserId;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_At] = DateTime.Now;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.Last_Modified_By] = UserId;
                    drNew[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                    dtMemberOf.Rows.Add(drNew);
                }

                ViewState[SystemConstants.ViewState.SystemData.MemberOf] = dtMemberOf;

                radGridMemberOf.Rebind();

                e.Canceled = true;
            }
        }

        protected void radGridMemberOf_ItemCommand(object source, GridCommandEventArgs e)
        {
            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                DataTable dtMemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] == null)
                                        ? GroupMemberDAO.GetTemplateTable()
                                        : (DataTable)ViewState[SystemConstants.ViewState.SystemData.MemberOf];

                int groupId = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupId"]);

                foreach (DataRow row in dtMemberOf.Rows)
                {
                    if (Utilities.ParseInt(row[SystemConstants.Entities.GroupMember.FieldName.GroupId]) == groupId)
                    {
                        //remove memberOf
                        row[SystemConstants.Entities.GroupMember.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        //break;
                        break;
                    }
                }

                ViewState[SystemConstants.ViewState.SystemData.MemberOf] = dtMemberOf;

                radGridMemberOf.Rebind();

                e.Canceled = true;
            }
        }
    }
}