using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.DBAccess;
using VietNamNet.AddOn.Advertisement.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Advertisement
{
    public partial class AdvertisementLayoutEdit : BasePage
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

                    AdvertisementLayoutHelper helper = new AdvertisementLayoutHelper(new AdvertisementLayout());
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
                    
                    int copyId = Utilities.ParseInt(Request.Params[Constants.ParameterName.COPY_ID]);
                    if (copyId > 0)
                    {
                        AdvertisementLayoutHelper helper = new AdvertisementLayoutHelper(new AdvertisementLayout());
                        helper.ValueObject.Id = copyId;
                        helper.Load();

                        if (helper.ValueObject == null)
                        {
                            Utilities.ItemDoesntExist();
                        }

                        BindData(helper.ValueObject);
                        //AuditTrail1.Get(helper.ValueObject);
                    }
                    else
                    {
                        Session[GetLayoutCategoriesSessionName()] = null;
                        Session[GetLayoutZoneSessionName()] = null;
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
            moduleAlias = "VietNamNet.AddOn.Advertisement";
            viewAlias = "VietNamNet.AddOn.Advertisement.View";
            addNewAlias = "VietNamNet.AddOn.Advertisement.AddNew";
            updateAlias = "VietNamNet.AddOn.Advertisement.Update";
            deleteAlias = "VietNamNet.AddOn.Advertisement.Delete";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
            lblNameErrorLabel.Visible = false;
        }

        private string GetLayoutZoneSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Zones, docId);
        }

        private string GetLayoutCategoriesSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Categories, docId);
        }

        private void BindData(AdvertisementLayout o)
        {
            txtName.Text = o.Name;
            txtDetail.Text = o.Detail;

            //Session
            Session[GetLayoutCategoriesSessionName()] = o.Categories;
            Session[GetLayoutZoneSessionName()] = o.Zones;

            pnlAdvCategory.BindDataToCategories();
        }

        private bool GetData(AdvertisementLayout o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            //Valid
            bool blnValid = true;
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.LayoutNameCantEmpty));
                ErrorMessage1.Visible = true;
                lblNameErrorLabel.Visible = true;
                blnValid = false;
            }

            if (!blnValid) return false;

            //Get data
            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            //Categorys
            o.Categories = (Session[GetLayoutCategoriesSessionName()] == null)
                          ? AdvertisementLayoutCategoryDAO.GetTemplateTable()
                          : (DataTable)Session[GetLayoutCategoriesSessionName()];

            //Zones
            o.Zones = (Session[GetLayoutZoneSessionName()] == null)
                          ? AdvertisementLayoutZoneDAO.GetTemplateTable()
                          : (DataTable)Session[GetLayoutZoneSessionName()];

            return true;
        }

        private void DoSave()
        {
            AdvertisementLayoutHelper helper = new AdvertisementLayoutHelper(new AdvertisementLayout());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementLayoutDisplay,
                                   helper.ValueObject.Id.ToString(),
                                   true);
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
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementLayoutView);
                    break;
                default:
                    break;
            }
        }
    }
}