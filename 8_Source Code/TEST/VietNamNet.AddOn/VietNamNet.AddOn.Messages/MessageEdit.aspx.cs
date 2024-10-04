using System;
using Telerik.Web.UI;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.AddOn.Messages.Common.ValueObject;
using VietNamNet.AddOn.Messages.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.AddOn.Messages
{
    public partial class MessageEdit : BasePage
    {
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;
        
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

                    MessageHelper helper = new MessageHelper(new Message());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    if (Utilities.StringCompare(helper.ValueObject.Status, MessagesConstants.MessageStatus.Sent))
                    {
                        Utilities.Redirect(MessagesConstants.FormNames.Messages.MessageDisplay, helper.ValueObject.Id.ToString());
                    }

                    BindUserData();
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

                    int msgType = Utilities.ParseInt(Request.Params[MessagesConstants.ParameterName.MsgType]);
                    int receiverId = Utilities.ParseInt(Request.Params[MessagesConstants.ParameterName.ReceiverId]);
                    string subject = Request.Params[MessagesConstants.ParameterName.Subject];

                    txtSubject.Text = subject;
                    cmbMsgType.SelectedValue = msgType.ToString();
                    switch (msgType)
                    {
                        case 0:
                            BindUserData();
                            cmbMsgReceiver.Text = string.Empty;
                            cmbMsgReceiver.SelectedValue = string.Empty;
                            cmbMsgReceiver.EmptyMessage = "Chọn người nhận...";
                            cmbMsgReceiver.Visible = true;
                            break;
                        case 1:
                            BindGroupData();
                            cmbMsgReceiver.Text = string.Empty;
                            cmbMsgReceiver.SelectedValue = string.Empty;
                            cmbMsgReceiver.EmptyMessage = "Chọn nhóm nhận...";
                            cmbMsgReceiver.Visible = true;
                            break;
                        case 2:
                            cmbMsgReceiver.Text = string.Empty;
                            cmbMsgReceiver.SelectedValue = string.Empty;
                            cmbMsgReceiver.Visible = false;
                            break;
                        default:
                            break;
                    }

                    if (receiverId > 0) cmbMsgReceiver.SelectedValue = receiverId.ToString();

                    AuditTrail1.Get(null);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = 0;
                }

                //Focus
                txtSubject.Focus();
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Messages";
            viewAlias = "VietNamNet.AddOn.Messages.View";
            addNewAlias = "VietNamNet.AddOn.Messages.AddNew";
            updateAlias = "VietNamNet.AddOn.Messages.Update";
            deleteAlias = "VietNamNet.AddOn.Messages.Delete";
            systemAlias = "VietNamNet.AddOn.Messages.System";
            ErrorMessage1.ClearMessage();
            ErrorMessage1.Visible = false;
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

        private void BindData(Message o)
        {
            txtSubject.Text = o.Subject;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(Message o, string status)
        {
            bool isValid = true;
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            o.Id = docId;
            o.Status = status;
            o.MsgType = Utilities.ParseInt(cmbMsgType.SelectedValue);
            switch(status)
            {
                case MessagesConstants.MessageStatus.Sent:
                    o.Name = string.Format("Gửi cho {0}: {1}", cmbMsgType.Text, cmbMsgReceiver.Text);
                    if (Nulls.IsNullOrEmpty(txtSubject.Text.Trim()))
                    {
                        ErrorMessage1.Visible = true;
                        ErrorMessage1.AddMessage(Utilities.GetConfigKey(MessagesConstants.Message.SubjectCantEmpty));
                        isValid = false;
                    }

                    //check receiver
                    switch (o.MsgType)
                    {
                        case 0: // Personal
                        case 1: // Group
                            o.ReceiverId = Utilities.ParseInt(cmbMsgReceiver.SelectedValue);
                            if (o.ReceiverId == 0)
                            {
                                ErrorMessage1.Visible = true;
                                ErrorMessage1.AddMessage(Utilities.GetConfigKey(MessagesConstants.Message.ReceiverNotSelect));
                                isValid = false;
                            }
                            break;
                        case 2: // All
                        default:
                            o.ReceiverId = 0;
                            break;
                    }
                    break;
                case MessagesConstants.MessageStatus.Draft:
                default:
                    o.ReceiverId = 0;
                    o.Name = "Lưu tạm";
                    break;
            }

            o.Subject = txtSubject.Text.Trim();
            o.Detail = txtDetail.Text.Trim();

            return isValid;
        }

        private void DoSave(string status)
        {
            MessageHelper helper = new MessageHelper(new Message());
            if (GetData(helper.ValueObject, status))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //Redirect to Diplay page
                Utilities.Redirect(MessagesConstants.FormNames.Messages.MessageDisplay, helper.ValueObject.Id.ToString(), true);
                //switch (status)
                //{
                //    case MessagesConstants.MessageStatus.Draft:
                //        Response.Redirect(MessagesConstants.FormNames.Messages.MessageDraft);
                //        break;
                //    case MessagesConstants.MessageStatus.Sent:
                //        Response.Redirect(MessagesConstants.FormNames.Messages.MessageSent);
                //        break;
                //    default:
                //        break;
                //}
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave(MessagesConstants.MessageStatus.Draft);
                    break;
                case MessagesConstants.CommandNames.Send:
                    DoSave(MessagesConstants.MessageStatus.Sent);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(MessagesConstants.FormNames.Messages.MessageView);
                    break;
                default:
                    break;
            }
        }

        private void BindUserData()
        {
            UserHelper helper = new UserHelper(new User());
            cmbMsgReceiver.DataSource = helper.ListAll();
            cmbMsgReceiver.DataTextField = SystemConstants.Entities.User.FieldName.Name;
            cmbMsgReceiver.DataValueField = SystemConstants.Entities.User.FieldName.Id;
            cmbMsgReceiver.DataBind();
        }

        private void BindGroupData()
        {
            GroupHelper helper = new GroupHelper(new Group());
            cmbMsgReceiver.DataSource = helper.ListAll();
            cmbMsgReceiver.DataTextField = SystemConstants.Entities.Group.FieldName.Name;
            cmbMsgReceiver.DataValueField = SystemConstants.Entities.Group.FieldName.Id;
            cmbMsgReceiver.DataBind();
        }

        protected void cmbMsgType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            switch(Utilities.ParseInt(cmbMsgType.SelectedValue))
            {
                case 0:
                    BindUserData();
                    cmbMsgReceiver.Text = string.Empty;
                    cmbMsgReceiver.SelectedValue = string.Empty;
                    cmbMsgReceiver.EmptyMessage = "Chọn người nhận...";
                    cmbMsgReceiver.Visible = true;
                    lblReceiverError.Visible = true;
                    break;
                case 1:
                    BindGroupData();
                    cmbMsgReceiver.Text = string.Empty;
                    cmbMsgReceiver.SelectedValue = string.Empty;
                    cmbMsgReceiver.EmptyMessage = "Chọn nhóm nhận...";
                    cmbMsgReceiver.Visible = true;
                    lblReceiverError.Visible = true;
                    break;
                case 2:
                    cmbMsgReceiver.Text = string.Empty;
                    cmbMsgReceiver.SelectedValue = string.Empty;
                    cmbMsgReceiver.Visible = false;
                    lblReceiverError.Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}