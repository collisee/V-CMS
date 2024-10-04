using System;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS
{
    public partial class CategoryDisplay : BasePage
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
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0)
                {
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;

                    //check save success
                    if (Utilities.ParseInt(Request.Params[Constants.ParameterName.SAVE_SUCCESS]) == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);
                    }
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }
            }
            else
            {
                lblMessage.Visible = false;
            }

            //show hide AddNew button
            radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
            radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isUpdater;
            radToolBarDefault.Items[2].Visible = radToolBarDefault.Items[2].Enabled = isDeleter;
            radToolBarDefault.Items[3].Visible = radToolBarDefault.Items[3].Enabled = isAddNewer;
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Category";
            viewAlias = "VietNamNet.CMS.Category.View";
            addNewAlias = "VietNamNet.CMS.Category.AddNew";
            updateAlias = "VietNamNet.CMS.Category.Update";
            deleteAlias = "VietNamNet.CMS.Category.Delete";
        }

        private void BindData(Category o)
        {
            lblPartitionId.Text = Utilities.DisplayNumberFormat(o.PartitionId);
            lblParentName.Text = Nulls.IsNullOrEmpty(o.ParentDisplayName) ? "Root" : o.ParentDisplayName;
            lblOrder.Text = Utilities.DisplayNumberFormat(o.Ord);
            lblName.Text = o.Name;
            lblAlias.Text = o.Alias;
            lblDisplayName.Text = o.DisplayName;
            lblUrl.Text = o.Url;
            lblDetail.Text = o.Detail;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            string goback = Request.Params[Constants.ParameterName.GOBACK];

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryEdit,
                                             Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.CategoryView);
                    break;
                case Constants.CommandNames.Copy:
                    string strCopy =
                        string.Format("{0}?{1}={2}&{3}={4}", CMSConstants.FormNames.CMS.CategoryEdit,
                                      Constants.ParameterName.COPY_ID, docId,
                                      Constants.ParameterName.GOBACK, goback);
                    Response.Redirect(strCopy);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.CategoryView);
                    break;
                default:
                    break;
            }
        }
    }
}