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
    public partial class AdvertisementZoneEdit : BasePage
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

                    AdvertisementZoneHelper helper = new AdvertisementZoneHelper(new AdvertisementZone());
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
                        AdvertisementZoneHelper helper = new AdvertisementZoneHelper(new AdvertisementZone());
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
                        Session[GetZoneBlockSessionName()] = null;
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
            lblHolderIdErrorLabel.Visible = false;
        }

        private string GetZoneBlockSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Blocks, docId);
        }

        private void BindData(AdvertisementZone o)
        {
            txtName.Text = o.Name;
            txtHolderId.Text = o.HolderId;
            cmbMode.SelectedValue = o.Mode.ToString();
            cmbDirection.SelectedValue= o.Direction.ToString();
            txtWidth.Value = o.Width;
            txtHeight.Value = o.Height;
            txtDetail.Text = o.Detail;

            //Session
            Session[GetZoneBlockSessionName()] = o.Blocks;
        }

        private bool GetData(AdvertisementZone o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            //Valid
            bool blnValid = true;
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.ZoneNameCantEmpty));
                ErrorMessage1.Visible = true;
                lblNameErrorLabel.Visible = true;
                blnValid = false;
            }

            if (Nulls.IsNullOrEmpty(txtHolderId.Text.Trim()))
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.ZoneHolderIdCantEmpty));
                ErrorMessage1.Visible = true;
                lblHolderIdErrorLabel.Visible = true;
                blnValid = false;
            }

            if (!blnValid) return false;

            //Get data
            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.HolderId = txtHolderId.Text.Trim();
            o.Mode = Utilities.ParseInt(cmbMode.SelectedValue);
            o.Direction = Utilities.ParseInt(cmbDirection.SelectedValue);
            o.Width = Utilities.ParseInt(txtWidth.Value);
            o.Height = Utilities.ParseInt(txtHeight.Value);
            o.Detail = txtDetail.Text.Trim();

            //Blocks
            o.Blocks = (Session[GetZoneBlockSessionName()] == null)
                          ? AdvertisementZoneBlockDAO.GetTemplateTable()
                          : (DataTable)Session[GetZoneBlockSessionName()];

            return true;
        }

        private void DoSave()
        {
            AdvertisementZoneHelper helper = new AdvertisementZoneHelper(new AdvertisementZone());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementZoneDisplay,
                                   helper.ValueObject.Id.ToString(),
                                   true);
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
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementZoneView);
                    break;
                default:
                    break;
            }
        }
    }
}