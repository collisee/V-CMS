using System;
using System.Web;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Encryption;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.CMS
{
    public partial class Login : Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            if (radCaptchaLogin.IsValid)
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.LoginName = txtLoginName.Text.Trim();
                helper.ValueObject.Password = MD5Encrypt.Encrypt(txtPassword.Text.Trim());
                helper.GetUser();

                if (helper.ValueObject != null)
                {
                    //Clear Session
                    Session.Clear();

                    //Store Session
                    Session[Constants.Session.USER_ID] = helper.ValueObject.Id;
                    //Session[Constants.Session.USER_GROUP] = helper.ValueObject.GroupId;
                    Session[Constants.Session.USER_LOGINNAME] = HttpUtility.HtmlEncode(helper.ValueObject.LoginName);
                    Session[Constants.Session.USER_FULLNAME] = HttpUtility.HtmlEncode(helper.ValueObject.FullName);
                    Session[Constants.Session.USER_EMAIL] = HttpUtility.HtmlEncode(helper.ValueObject.Email);
                    //Session[Constants.Session.USER_LASTLOGIN] = helper.ValueObject.LastLogin;
                    //Session[Constants.Session.SKIN] = helper.ValueObject.Skin;
                    Session[Constants.Session.USER_STATUS] = helper.ValueObject.Status;

                    SystemLogging.System("Login!");
                    helper.UpdateUserLastLogin();
                    Utilities.GoBackToLastUrl(Constants.FormNames.Default);
                }
                else
                {
                    lblError.Text = Utilities.GetConfigKey(Constants.Message.UserLoginFailed);
                }
            }
        }
    }
}