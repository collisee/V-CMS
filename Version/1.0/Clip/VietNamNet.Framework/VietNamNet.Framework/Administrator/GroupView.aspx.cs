using System;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class GroupView : BasePageView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                if (radKeyword != null)
                {
                    RadTextBox txtKw = (RadTextBox) radKeyword.FindControl("txtKeyword");
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
                radGridDefault.Columns[radGridDefault.Columns.Count - 2].Visible = SystemUtils.GetPolicyViewRight(UserId); //Policy View
                radGridDefault.Columns[radGridDefault.Columns.Count - 3].Visible = isAddNewer;

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
            ServiceName = SystemConstants.Services.GroupManager.Name;
            ActionName = SystemConstants.Services.GroupManager.Actions.ViewGetAllGroup;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.GroupEdit);
                    break;
                case Constants.CommandNames.Search:
                    string kw = string.Empty;
                    RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                    if (radKeyword != null)
                    {
                        RadTextBox txtKw = (RadTextBox) radKeyword.FindControl("txtKeyword");
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

        protected override void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                Utilities.Redirect(SystemConstants.FormNames.Administrator.GroupDisplay,
                               e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            }
            else if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                GroupHelper helper = new GroupHelper(new Group());
                helper.ValueObject.Id =
                    Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                helper.ValueObject.Last_Modified_At = DateTime.Now;
                helper.ValueObject.Last_Modified_By = UserId;
                helper.Delete();

                //load
                FunctionforPageLoad();
            }
        }
    }
}