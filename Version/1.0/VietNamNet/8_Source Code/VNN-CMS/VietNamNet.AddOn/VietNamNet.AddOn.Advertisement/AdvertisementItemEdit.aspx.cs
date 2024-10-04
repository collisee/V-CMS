using System;
using Telerik.Web.UI;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Advertisement
{
    public partial class AdvertisementItemEdit : BasePage
    {
        #region Handler Method

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

                    AdvertisementItemHelper helper = new AdvertisementItemHelper(new AdvertisementItem());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindDataToAdvertisementType();
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
                        AdvertisementItemHelper helper = new AdvertisementItemHelper(new AdvertisementItem());
                        helper.ValueObject.Id = copyId;
                        helper.Load();

                        if (helper.ValueObject == null)
                        {
                            Utilities.ItemDoesntExist();
                        }

                        BindDataToAdvertisementType();
                        BindData(helper.ValueObject);
                    }
                    else
                    {
                        BindDataToAdvertisementType();
                        BindData();
                    }

                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }

                //Focus
                txtName.Focus();
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
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementItemView);
                    break;
                default:
                    break;
            }
        }

        protected void cmbAdvertisementType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            switch (cmbAdvertisementType.SelectedValue)
            {
                case "add-code":
                    plhBanner.Visible = false;
                    plhAddcode.Visible = true;
                    plhExpanding.Visible = false;
                    plhIFrame.Visible = false;
                    break;
                case "expanding":
                    plhBanner.Visible = false;
                    plhAddcode.Visible = false;
                    plhExpanding.Visible = true;
                    plhIFrame.Visible = false;
                    break;
                case "iframe":
                    plhBanner.Visible = false;
                    plhAddcode.Visible = false;
                    plhExpanding.Visible = false;
                    plhIFrame.Visible = true;
                    break;
                default: //include image, flash
                    plhBanner.Visible = true;
                    plhAddcode.Visible = false;
                    plhExpanding.Visible = false;
                    plhIFrame.Visible = false;
                    break;
            }
        }

        #endregion

        #region Private Method

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
            lblLinkErrorLabel.Visible = false;
            lblStartTimeErrorLabel.Visible = false;
            lblEndTimeErrorLabel.Visible = false;
        }

        private void BindDataToAdvertisementType()
        {
            AdvertisementTypeHelper helper = new AdvertisementTypeHelper(new AdvertisementType());
            cmbAdvertisementType.DataSource = helper.ListAll();
            cmbAdvertisementType.DataBind();
        }

        private void BindData()
        {
            //default binding
            cmbAdvertisementType.SelectedValue = "flash";
            plhBanner.Visible = true;
            plhAddcode.Visible = false;
            plhExpanding.Visible = false;
            plhIFrame.Visible = false;

            radDpkStartTime.SelectedDate = DateTime.Now;
            radDpkEndTime.SelectedDate = DateTime.Now.AddMonths(3);
        }

        private void BindData(AdvertisementItem o)
        {
            txtName.Text = o.Name;
            txtLink.Text = o.Link;
            radDpkStartTime.SelectedDate = o.StartTime;
            radDpkEndTime.SelectedDate = o.EndTime;
            txtDetail.Text = o.Detail;

            txtFileLink1.Text = o.FileLink1;
            txtFileLink11.Text = o.FileLink1;
            txtFileLink2.Text = o.FileLink2;
            txtFileJS.Text = o.FileJS;
            txtFileJS1.Text = o.FileJS;
            txtCodeJS.Text = o.CodeJS;
            txtExWidth.Value = o.ExWidth;
            txtExHeight.Value = o.ExHeight;
            cmbExMode.SelectedValue = o.ExMode.ToString();
            cmbExMode1.SelectedValue = o.ExMode.ToString();
            
            AdvertisementTypeHelper typeHelper = new AdvertisementTypeHelper(new AdvertisementType());
            typeHelper.ValueObject.Id = o.TypeId;
            typeHelper.Load();
            cmbAdvertisementType.SelectedValue = (typeHelper.ValueObject == null) ? string.Empty : typeHelper.ValueObject.Alias;

            switch (cmbAdvertisementType.SelectedValue)
            {
                case "add-code":
                    plhBanner.Visible = false;
                    plhAddcode.Visible = true;
                    plhExpanding.Visible = false;
                    plhIFrame.Visible = false;
                    break;
                case "expanding":
                    plhBanner.Visible = false;
                    plhAddcode.Visible = false;
                    plhExpanding.Visible = true;
                    plhIFrame.Visible = false;
                    break;
                case "iframe":
                    plhBanner.Visible = false;
                    plhAddcode.Visible = false;
                    plhExpanding.Visible = false;
                    plhIFrame.Visible = true;
                    break;
                default: //include image, flash
                    plhBanner.Visible = true;
                    plhAddcode.Visible = false;
                    plhExpanding.Visible = false;
                    plhIFrame.Visible = false;
                    break;
            }
        }

        private bool GetData(AdvertisementItem o)
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

            #region Valid

            bool blnValid = true;
            //Name
            if (Nulls.IsNullOrEmpty(txtName.Text.Trim()))
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.ItemNameCantEmpty));
                ErrorMessage1.Visible = true;
                lblNameErrorLabel.Visible = true;
                blnValid = false;
            }

            //Link
            if (Nulls.IsNullOrEmpty(txtLink.Text.Trim()))
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.ItemLinkCantEmpty));
                ErrorMessage1.Visible = true;
                lblLinkErrorLabel.Visible = true;
                blnValid = false;
            }

            //StartTime
            if (radDpkStartTime.SelectedDate == null)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.StartTimeCantEmpty));
                ErrorMessage1.Visible = true;
                lblStartTimeErrorLabel.Visible = true;
                blnValid = false;
            }

            //EndTime
            if (radDpkEndTime.SelectedDate == null)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.EndTimeCantEmpty));
                ErrorMessage1.Visible = true;
                lblEndTimeErrorLabel.Visible = true;
                blnValid = false;
            }

            //EndTime < StartTime
            if (radDpkEndTime.SelectedDate != null && radDpkStartTime.SelectedDate != null
                && ((DateTime)radDpkEndTime.SelectedDate).CompareTo(((DateTime)radDpkStartTime.SelectedDate)) < 0)
            {
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(AdvertisementConstants.Message.EndTimeLessThanStartTime));
                ErrorMessage1.Visible = true;
                lblStartTimeErrorLabel.Visible = true;
                lblEndTimeErrorLabel.Visible = true;
                blnValid = false;
            }

            if (!blnValid) return false;

            #endregion

            #region Get data

            o.Id = docId;
            o.Name = txtName.Text.Trim();
            o.Link = txtLink.Text.Trim();
            o.StartTime = (radDpkStartTime.SelectedDate == null)
                              ? DateTime.Now
                              : (DateTime) radDpkStartTime.SelectedDate;
            o.EndTime = (radDpkEndTime.SelectedDate == null)
                            ? DateTime.Now
                            : (DateTime) radDpkEndTime.SelectedDate;
            o.Detail = txtDetail.Text.Trim();

            AdvertisementTypeHelper typeHelper = new AdvertisementTypeHelper(new AdvertisementType());
            typeHelper.ValueObject.Id = 0;
            typeHelper.ValueObject.Alias = cmbAdvertisementType.SelectedValue;
            typeHelper.GetAdvertisementTypeByAlias();
            o.TypeId = (typeHelper.ValueObject == null) ? 0 : typeHelper.ValueObject.Id;

            switch (cmbAdvertisementType.SelectedValue)
            {
                case "add-code":
                    o.FileLink1 = string.Empty;
                    o.FileLink2 = string.Empty;
                    o.FileJS = txtFileJS.Text.Trim();
                    o.CodeJS = txtCodeJS.Text.Trim();
                    o.ExWidth = 0;
                    o.ExHeight = 0;
                    o.ExMode = Utilities.ParseInt(cmbExMode1.SelectedValue);
                    break;
                case "expanding":
                    o.FileLink1 = txtFileLink11.Text.Trim();
                    o.FileLink2 = txtFileLink2.Text.Trim();
                    o.FileJS = string.Empty;
                    o.CodeJS = string.Empty;
                    o.ExWidth = Utilities.ParseInt(txtExWidth.Value);
                    o.ExHeight = Utilities.ParseInt(txtExHeight.Value);
                    o.ExMode = Utilities.ParseInt(cmbExMode.SelectedValue);
                    break;
                case "iframe":
                    o.FileLink1 = string.Empty;
                    o.FileLink2 = string.Empty;
                    o.FileJS = txtFileJS1.Text.Trim();
                    o.ExWidth = 0;
                    o.ExHeight = 0;
                    break;
                default: //include image, flash
                    o.FileLink1 = txtFileLink1.Text.Trim();
                    o.FileLink2 = string.Empty;
                    o.FileJS = string.Empty;
                    o.CodeJS = string.Empty;
                    o.ExWidth = 0;
                    o.ExHeight = 0;
                    o.ExMode = 0;
                    break;
            }

            #endregion

            return true;
        }

        private void DoSave()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            AdvertisementItemHelper helper = new AdvertisementItemHelper(new AdvertisementItem());

            if (docId > 0)
            {
                helper.ValueObject.Id = docId;
                helper.Load();

                if (helper.ValueObject == null)
                {
                    Utilities.ItemDoesntExist();
                }
            }

            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementItemDisplay,
                                   helper.ValueObject.Id.ToString(),
                                   true);
            }
        }

        #endregion
    }
}