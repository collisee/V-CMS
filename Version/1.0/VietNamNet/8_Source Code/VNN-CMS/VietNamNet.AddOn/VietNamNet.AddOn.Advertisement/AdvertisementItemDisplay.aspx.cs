using System;
using Telerik.Web.UI;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Advertisement
{
    public partial class AdvertisementItemDisplay : BasePage
    {
        #region Handler Method

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
                    AdvertisementItemHelper helper = new AdvertisementItemHelper(new AdvertisementItem());
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

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            string goback = Request.Params[Constants.ParameterName.GOBACK];

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementItemEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementItemEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    AdvertisementItemHelper helper = new AdvertisementItemHelper(new AdvertisementItem());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementItemView);
                    break;
                case Constants.CommandNames.Copy:
                    string strCopy =
                        string.Format("{0}?{1}={2}&{3}={4}", AdvertisementConstants.FormNames.Advertisements.AdvertisementItemEdit,
                                      Constants.ParameterName.COPY_ID, docId,
                                      Constants.ParameterName.GOBACK, goback);
                    Response.Redirect(strCopy);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementItemView);
                    break;
                default:
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
        }

        private void BindData(AdvertisementItem o)
        {
            lblName.Text = o.Name;
            lnkLink.Text = o.Link;
            lnkLink.NavigateUrl = o.Link;
            lblStartTime.Text = Utilities.FormatDisplayDateTime(o.StartTime);
            lblEndTime.Text = Utilities.FormatDisplayDateTime(o.EndTime);
            lblDetail.Text = o.Detail;

            lblFileLink1.Text = o.FileLink1;
            hidFileLink1.Value = o.FileLink1;
            lblFileLink11.Text = o.FileLink1;
            hidFileLink11.Value = o.FileLink1;
            lblFileLink2.Text = o.FileLink2;
            hidFileLink2.Value = o.FileLink2;
            lblFileJS.Text = o.FileJS;
            lblFileJS1.Text = o.FileJS;
            lblCodeJS.Text = o.CodeJS.Replace("\r\n", "<br />");
            lblExWidth.Text = Utilities.DisplayNumberFormat(o.ExWidth);
            lblExHeight.Text = Utilities.DisplayNumberFormat(o.ExHeight);
            lblExMode.Text = (o.ExMode == 0) ? "Trái dưới" : "Phải dưới";
            lblExMode1.Text = (o.ExMode == 0) ? "Thêm file js trước khi gọi code" : "Thêm code trước khi gọi file js";

            AdvertisementTypeHelper typeHelper = new AdvertisementTypeHelper(new AdvertisementType());
            typeHelper.ValueObject.Id = o.TypeId;
            typeHelper.Load();
            lblAdvertisementType.Text = (typeHelper.ValueObject == null) ? string.Empty : typeHelper.ValueObject.Name;
            string advTypeAlias = (typeHelper.ValueObject == null) ? string.Empty : typeHelper.ValueObject.Alias;

            switch (advTypeAlias)
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
    }
}