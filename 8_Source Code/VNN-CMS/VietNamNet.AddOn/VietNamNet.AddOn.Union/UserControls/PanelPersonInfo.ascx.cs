using System;
using System.Data;
using System.Web.UI;
using VietNamNet.AddOn.Messages.Common.ValueObject;
using VietNamNet.AddOn.Messages.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Union.UserControls
{
    public partial class PanelPersonInfo : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Constants.Session.USER_ID] != null)
                {
                    lblUsersOnline.Text = Session[Constants.Session.USER_FULLNAME].ToString();
                    imgAvatar.ImageUrl = Session[Constants.Session.USER_AVATAR].ToString();
                    PanelLogin.Visible = false;
                    PanelUserInfo.Visible = true;

                    //get New private messages
                    GetNewMessages();
                }
                else
                {
                    PanelLogin.Visible = true;
                    PanelUserInfo.Visible = false;

                    txtLoginName.Focus();
                }
            }
        }

        private void GetNewMessages()
        {
            //get New private messages
            MessageHelper messages = new MessageHelper(new Message());
            messages.ValueObject.ReceiverId = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
            DataTable dtMessages = messages.GetNewPrivateMessages();
            if (dtMessages != null && dtMessages.Rows.Count > 0)
            {
                lblMessagesNumber.Text = Utilities.DisplayNumberFormat(Utilities.ParseInt(dtMessages.Rows[0][0]));
            }
        }

        private void ShowUserInfo()
        {
            lblUsersOnline.Text = Session[Constants.Session.USER_FULLNAME].ToString();
            imgAvatar.ImageUrl = Session[Constants.Session.USER_AVATAR].ToString();
            PanelLogin.Visible = false;
            PanelUserInfo.Visible = true;
        }

        private bool CheckLockUser()
        {
            int login = Utilities.ParseInt(Session["TryLogin"]);
            login += 1;
            if (login > 3)
            {
                lblError.Text = Utilities.GetConfigKey(Constants.Message.UserTryLocked);
            }
            Session["TryLogin"] = login;
            return login <= 3;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            if (!CheckLockUser())
            {
                return;
            }

            string loginMsg = SystemUtils.UserLogin(txtLoginName.Text, txtPassword.Text);
            if (Nulls.IsNullOrEmpty(loginMsg))
            {
                //redriect
                Response.Redirect(Request.Url.AbsolutePath);

                ShowUserInfo();

                //get New private messages
                GetNewMessages();
            }
            else
            {
                lblError.Text = loginMsg;
            }
        }
    }
}