using System;
using System.Web;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.Framework.UserControls
{
    public partial class Login : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strMsg = Request.Params[Constants.ParameterName.MESSAGE];
                if (Nulls.IsNullOrEmpty(strMsg))
                {
                    lblMsg.Visible = false;
                }
                else
                {
                    lblMsg.Visible = true;
                    string message = Utilities.GetConfigKey(strMsg);
                    lblMsg.Text = Nulls.IsNullOrEmpty(message)
                                      ? HttpUtility.HtmlEncode(strMsg)
                                      : HttpUtility.HtmlEncode(message);
                }
            }
            //else
            //{
            //    lblMsg.Visible = false;
            //}

            txtLoginName.Focus();
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

            if (radCaptchaLogin.IsValid)
            {
                if (Nulls.IsNullOrEmpty(txtLoginName.Text.Trim()) || Nulls.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    lblError.Text = Utilities.GetConfigKey(Constants.Message.UserLoginFailed);
                    return;
                }

                string loginMsg = SystemUtils.UserLogin(txtLoginName.Text, txtPassword.Text);
                if (Nulls.IsNullOrEmpty(loginMsg))
                {
                    Utilities.GoBackToLastUrl(Constants.FormNames.Default);
                }
                else
                {
                    lblError.Text = loginMsg;
                }
            }
        }
    }
}