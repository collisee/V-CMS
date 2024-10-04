using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS
{
    public partial class CategoryView : BasePageView
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
                radGridDefault.Columns[radGridDefault.Columns.Count - 4].Visible = isUpdater;

                FunctionforPageLoad();
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Category";
            viewAlias = "VietNamNet.CMS.Category.View";
            addNewAlias = "VietNamNet.CMS.Category.AddNew";
            updateAlias = "VietNamNet.CMS.Category.Update";
            deleteAlias = "VietNamNet.CMS.Category.Delete";
            ServiceName = CMSConstants.Services.CategoryManager.Name;
            ActionName = CMSConstants.Services.CategoryManager.Actions.ViewGetAllCategory;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryEdit);
                    break;
                case Constants.CommandNames.Optimize:
                    //Optimize
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.OptimizeCategory();
                    //Rebind
                    FunctionforPageLoad();
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
                Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryDisplay,
                                   e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            }
            else if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                CategoryHelper helper = new CategoryHelper(new Category());
                helper.ValueObject.Id =
                    Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                helper.ValueObject.Last_Modified_At = DateTime.Now;
                helper.ValueObject.Last_Modified_By = UserId;
                helper.Delete();

                //load
                FunctionforPageLoad();
            }
        }

        protected void btnSave_Click(object sender, CommandEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            try
            {
                ImageButton btnSave = sender as ImageButton;

                GridTableCell myPanel = btnSave.Parent as GridTableCell;

                GridDataItem dataItem = myPanel.Parent as GridDataItem;

                TextBox txtOrd = (TextBox)dataItem.FindControl("txtOrd");

                CategoryHelper helper = new CategoryHelper(new Category());
                helper.ValueObject.Id = Utilities.ParseInt(e.CommandArgument);
                helper.Load();
                if (helper.ValueObject != null)
                {
                    helper.ValueObject.OldOrd = helper.ValueObject.Ord;
                    helper.ValueObject.Ord = Utilities.ParseInt(txtOrd.Text);
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.DoSave();
                }
            }
            catch (Exception ex)
            {
                SystemLogging.Error("CategoryView::SaveOrder::Error", ex.Message);
            }
            finally
            {
                FunctionforPageLoad();
            }
        }
    }
}