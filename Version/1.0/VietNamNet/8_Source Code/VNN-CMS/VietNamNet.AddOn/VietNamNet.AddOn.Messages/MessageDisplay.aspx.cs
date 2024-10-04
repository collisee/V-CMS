using System;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.AddOn.Messages.Common.ValueObject;
using VietNamNet.AddOn.Messages.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Messages
{
    public partial class MessageDisplay : BasePage
    {
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

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
                    MessageHelper helper = new MessageHelper(new Message());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    //check security
                    if (!isSystem && helper.ValueObject.Created_By != UserId)
                    {
                        Utilities.NoRightToAccess();
                    }

                    if (Utilities.StringCompare(HttpUtility.HtmlDecode(helper.ValueObject.Status), MessagesConstants.MessageStatus.Sent))
                    {
                        radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = false;
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
            //radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isUpdater;
            radToolBarDefault.Items[2].Visible = radToolBarDefault.Items[2].Enabled = isDeleter;
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Messages";
            viewAlias = "VietNamNet.AddOn.Messages.View";
            addNewAlias = "VietNamNet.AddOn.Messages.AddNew";
            updateAlias = "VietNamNet.AddOn.Messages.Update";
            deleteAlias = "VietNamNet.AddOn.Messages.Delete";
            systemAlias = "VietNamNet.AddOn.Messages.System";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

        private void BindData(Message o)
        {
            lblStatus.Text = o.Status;
            lblName.Text = o.Name;
            lblSubject.Text = o.Subject;
            lblDetail.Text = o.Detail.Replace("\r\n", "<br />");
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(MessagesConstants.FormNames.Messages.MessageEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(MessagesConstants.FormNames.Messages.MessageEdit,
                                           Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

                    MessageHelper helper = new MessageHelper(new Message());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(MessagesConstants.FormNames.Messages.MessageView);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(MessagesConstants.FormNames.Messages.MessageView);
                    break;
                default:
                    break;
            }
        }
    }
}