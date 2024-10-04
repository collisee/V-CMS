using System;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS
{
    public partial class ArticleContentTypeEdit : BasePage
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

                    ArticleContentTypeHelper helper = new ArticleContentTypeHelper(new ArticleContentType());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

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

                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }

                //Focus
                txtName.Focus();
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Configuration";
            viewAlias = "VietNamNet.CMS.Configuration.View";
            addNewAlias = "VietNamNet.CMS.Configuration.AddNew";
            updateAlias = "VietNamNet.CMS.Configuration.Update";
            deleteAlias = "VietNamNet.CMS.Configuration.Delete";
        }

        private void BindData(ArticleContentType o)
        {
            txtName.Text = o.Name;
            txtDetail.Text = o.Detail;
        }

        private void GetData(ArticleContentType o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Detail = txtDetail.Text.Trim();
        }

        private void DoSave()
        {
            ArticleContentTypeHelper helper = new ArticleContentTypeHelper(new ArticleContentType());
            GetData(helper.ValueObject);
            AuditTrail1.Set(helper.ValueObject);
            helper.DoSave();

            //Redirect to Diplay page
            Utilities.Redirect(CMSConstants.FormNames.CMS.ArticleContentTypeDisplay, helper.ValueObject.Id.ToString(), true);
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
                    Utilities.GoBackToView(CMSConstants.FormNames.CMS.ArticleContentTypeView);
                    break;
                default:
                    break;
            }
        }
    }
}