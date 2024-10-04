using System;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Encryption;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework
{
    public partial class FindPassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfoLabel.Visible = false;
            lblErrorLabel.Visible = false;
            txtLoginName.Focus();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            UserHelper helper = new UserHelper(new User());
            helper.ValueObject.LoginName = txtLoginName.Text.Trim();
            helper.GetUserByLoginName();

            if (helper.ValueObject != null)
            {
                if (Utilities.StringCompare(helper.ValueObject.Email, txtEmail.Text.Trim()))
                {
                    string newPwd = Utilities.GetRandomPassword();

                    helper.ValueObject.Password = MD5Encrypt.Encrypt(newPwd);
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = 0;
                    helper.DoSave();

                    lblInfoLabel.Visible = true;

                    //send email
                    SystemEmailFunction.SendChangePassword(helper.ValueObject, newPwd);
                }
                else
                {
                    lblErrorLabel.Visible = true;
                }
            }
            else
            {
                lblErrorLabel.Visible = true;
            }
        }
    }
}