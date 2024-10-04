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
    public partial class AdvertisementBlockEdit : BasePage
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

                    AdvertisementBlockHelper helper = new AdvertisementBlockHelper(new AdvertisementBlock());
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
                        AdvertisementBlockHelper helper = new AdvertisementBlockHelper(new AdvertisementBlock());
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
                        Session[GetBlockItemSessionName()] = null;
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

        private string GetBlockItemSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Items, docId);
        }

        private void BindData(AdvertisementBlock o)
        {
            txtName.Text = o.Name;
            cmbMode.SelectedValue = o.Mode.ToString();
            txtTimeDelay.Value = o.TimeDelay;
            txtWidth.Value = o.Width;
            txtHeight.Value = o.Height;
            txtDetail.Text = o.Detail;

            //Session
            Session[GetBlockItemSessionName()] = o.Items;
        }

        private bool GetData(AdvertisementBlock o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            //Valid
            bool blnValid = true;
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.BlockNameCantEmpty));
                ErrorMessage1.Visible = true;
                lblNameErrorLabel.Visible = true;
                blnValid = false;
            }

            if (!blnValid) return false;

            //Get data
            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Mode = Utilities.ParseInt(cmbMode.SelectedValue);
            o.TimeDelay = Utilities.ParseInt(txtTimeDelay.Value);
            o.Width = Utilities.ParseInt(txtWidth.Value);
            o.Height = Utilities.ParseInt(txtHeight.Value);
            o.Detail = txtDetail.Text.Trim();

            //Items
            o.Items = (Session[GetBlockItemSessionName()] == null)
                          ? AdvertisementBlockItemDAO.GetTemplateTable()
                          : (DataTable)Session[GetBlockItemSessionName()];

            return true;
        }

        private void DoSave()
        {
            AdvertisementBlockHelper helper = new AdvertisementBlockHelper(new AdvertisementBlock());
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementBlockDisplay,
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
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementBlockView);
                    break;
                default:
                    break;
            }
        }
    }
}