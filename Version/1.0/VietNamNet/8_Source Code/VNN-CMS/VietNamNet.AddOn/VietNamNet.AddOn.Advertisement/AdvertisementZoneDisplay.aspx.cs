using System;
using Telerik.Web.UI;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Advertisement
{
    public partial class AdvertisementZoneDisplay : BasePage
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
                    AdvertisementZoneHelper helper = new AdvertisementZoneHelper(new AdvertisementZone());
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
            moduleAlias = "VietNamNet.AddOn.Advertisement";
            viewAlias = "VietNamNet.AddOn.Advertisement.View";
            addNewAlias = "VietNamNet.AddOn.Advertisement.AddNew";
            updateAlias = "VietNamNet.AddOn.Advertisement.Update";
            deleteAlias = "VietNamNet.AddOn.Advertisement.Delete";
        }

        private string GetZoneBlockSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", AdvertisementConstants.Session.AdvertisementData.Blocks, docId);
        }

        private void BindData(AdvertisementZone o)
        {
            lblName.Text = o.Name;
            lblHolderId.Text = o.HolderId;
            lblMode.Text = (o.Mode == 0) ? "Ngẫu nhiên" : "Thứ tự";
            lblDirection.Text = (o.Direction == 0) ? "Chiều dọc" : "Chiều ngang";
            lblWidth.Text = Utilities.DisplayNumberFormat(o.Width);
            lblHeight.Text = Utilities.DisplayNumberFormat(o.Height);
            lblDetail.Text = o.Detail;

            //Session
            Session[GetZoneBlockSessionName()] = o.Blocks;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            string goback = Request.Params[Constants.ParameterName.GOBACK];

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementZoneEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(AdvertisementConstants.FormNames.Advertisements.AdvertisementZoneEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    AdvertisementZoneHelper helper = new AdvertisementZoneHelper(new AdvertisementZone());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(AdvertisementConstants.FormNames.Advertisements.AdvertisementZoneView);
                    break;
                case Constants.CommandNames.Copy:
                    string strCopy =
                        string.Format("{0}?{1}={2}&{3}={4}", AdvertisementConstants.FormNames.Advertisements.AdvertisementZoneEdit,
                                      Constants.ParameterName.COPY_ID, docId,
                                      Constants.ParameterName.GOBACK, goback);
                    Response.Redirect(strCopy);
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