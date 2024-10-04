using System;
using Telerik.Web.UI;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.AddOn.Advertisement
{
    public partial class AdvertisementTypeEdit : BasePage
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

                    AdvertisementTypeHelper helper = new AdvertisementTypeHelper(new AdvertisementType());
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
                else //add new
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
            moduleAlias = "VietNamNet.AddOn.Advertisement";
            viewAlias = "VietNamNet.AddOn.Advertisement.View";
            addNewAlias = "VietNamNet.AddOn.Advertisement.AddNew";
            updateAlias = "VietNamNet.AddOn.Advertisement.Update";
            deleteAlias = "VietNamNet.AddOn.Advertisement.Delete";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
        }

        private void BindData(AdvertisementType o)
        {
            txtName.Text = o.Name;
            txtAlias.Text = o.Alias;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(AdvertisementType o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            AdvertisementTypeHelper helper = new AdvertisementTypeHelper(new AdvertisementType());
            helper.ValueObject.Id = docId;
            helper.ValueObject.Alias = txtAlias.Text.Trim();
            helper.GetAdvertisementTypeByAlias();

            if (helper.ValueObject != null)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.AliasExisted));
                ErrorMessage1.Visible = true;
                return false;
            }

            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Alias = txtAlias.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            return true;
        }

        private void DoSave()
        {
            AdvertisementTypeHelper helper = new AdvertisementTypeHelper(new AdvertisementType());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementTypeDisplay,
                                   helper.ValueObject.Id.ToString(), true);
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave();
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementTypeView);
                    break;
                default:
                    break;
            }
        }
    }
}