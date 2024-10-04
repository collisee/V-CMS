using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.Administrator
{
    public partial class UserViewByGroup : BasePageView
    {
        protected int groupId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            groupId = Utilities.ParseInt(Request.Params[Constants.ParameterName.GROUP_ID]);

            if (!IsPostBack)
            {
                RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                if (radKeyword != null)
                {
                    RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                    if (txtKw != null)
                    {
                        txtKw.Text = Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.KEYWORD])
                                         ? string.Empty
                                         : Request.Params[Constants.ParameterName.KEYWORD];
                    }
                }

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
                radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isAddNewer;
                //show hide Delete button
                radGridDefault.Columns[radGridDefault.Columns.Count - 1].Visible = isDeleter;
                radGridDefault.Columns[radGridDefault.Columns.Count - 2].Visible = isUpdater;
                radGridDefault.Columns[radGridDefault.Columns.Count - 3].Visible = !isUpdater;

                FunctionforPageLoad();
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.Administrator";
            viewAlias = "System.Administrator.View";
            addNewAlias = "System.Administrator.AddNew";
            updateAlias = "System.Administrator.Update";
            deleteAlias = "System.Administrator.Delete";
            ServiceName = SystemConstants.Services.UserManager.Name;
            ActionName = SystemConstants.Services.UserManager.Actions.ViewGetAllUserByGroup;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.UserEdit);
                    break;
                case Constants.CommandNames.Search:
                    string kw = string.Empty;
                    RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                    if (radKeyword != null)
                    {
                        RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                        if (txtKw != null)
                        {
                            kw = txtKw.Text.Trim();
                        }
                    }
                    string url =
                        Utilities.SetParamForURL(Request.Url.AbsoluteUri, Constants.ParameterName.KEYWORD, kw);
                    Response.Redirect(url);
                    break;
                default:
                    break;
            }
        }

        protected override DataTable BindSearchingTable()
        {
            DataTable dtSearch = new DataTable(Constants.Paging.Direction.SearchingTableName);
            dtSearch.Columns.Add(Constants.Paging.Direction.IsSearch, typeof(bool));
            dtSearch.Columns.Add(Constants.Paging.Direction.KeyWords, typeof(string));
            dtSearch.Columns.Add(Constants.Paging.Direction.GId, typeof(int));
            DataRow drSearch = dtSearch.NewRow();
            drSearch[Constants.Paging.Direction.IsSearch] =
                Convert.ToBoolean(ViewState[Constants.Paging.Direction.IsSearch]);
            drSearch[Constants.Paging.Direction.KeyWords] =
                Convert.ToString(ViewState[Constants.Paging.Direction.KeyWords]);
            drSearch[Constants.Paging.Direction.GId] = groupId;
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }

        protected override void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                Utilities.Redirect(SystemConstants.FormNames.Administrator.UserDisplay,
                               e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            }
            else if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.Id =
                    Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                helper.ValueObject.Last_Modified_At = DateTime.Now;
                helper.ValueObject.Last_Modified_By = UserId;
                helper.Delete();

                //load
                FunctionforPageLoad();
            }
        }

        protected void btnLock_Click(object sender, CommandEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            try
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.Id = Utilities.ParseInt(e.CommandArgument);
                helper.Load();

                if (helper.ValueObject != null)
                {
                    helper.ValueObject.Status = "Khóa";
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;

                    helper.DoSave();
                }
            }
            catch (Exception ex)
            {
                SystemLogging.Error("UserView::Lock::Error", ex.Message);
            }
            finally
            {
                FunctionforPageLoad();
            }
        }

        protected void btnUnLock_Click(object sender, CommandEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            try
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.Id = Utilities.ParseInt(e.CommandArgument);
                helper.Load();

                if (helper.ValueObject != null)
                {
                    helper.ValueObject.Status = "Hoạt động";
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;

                    helper.DoSave();
                }
            }
            catch (Exception ex)
            {
                SystemLogging.Error("UserView::Lock::Error", ex.Message);
            }
            finally
            {
                FunctionforPageLoad();
            }
        }
    }
}