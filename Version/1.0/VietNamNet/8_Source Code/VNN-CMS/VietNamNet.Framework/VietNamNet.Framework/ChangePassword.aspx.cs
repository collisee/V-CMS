using System;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Encryption;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework
{
    public partial class ChangePassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            lblInfoLabel.Text = string.Empty;
            lblErrorLabel.Text = string.Empty;
            lblInfoLabel.Visible = false;
            lblErrorLabel.Visible = false;
            txtOldPwd.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;
            //Pwd
            if (!Nulls.IsNullOrEmpty(txtPwd.Text) && !Nulls.IsNullOrEmpty(txtRepPwd.Text) &&
                !Utilities.StringCompare(txtPwd.Text, txtRepPwd.Text))
            {
                lblErrorLabel.Text = Utilities.GetConfigKey(SystemConstants.Message.PasswordAndRetypeError);
                lblErrorLabel.Visible = true;
            }
            else
            {
                UserHelper helper = new UserHelper(new User());
                helper.ValueObject.Id = UserId;
                helper.Load();

                if (helper.ValueObject != null)
                {
                    string strOldPwd = Nulls.IsNullOrEmpty(txtOldPwd.Text.Trim())
                                           ? string.Empty
                                           : MD5Encrypt.Encrypt(txtOldPwd.Text.Trim());
                    string strNewPwd = Nulls.IsNullOrEmpty(txtPwd.Text.Trim())
                                           ? string.Empty
                                           : MD5Encrypt.Encrypt(txtPwd.Text.Trim());
                    if (Nulls.IsNullOrEmpty(strOldPwd) || Nulls.IsNullOrEmpty(strNewPwd))
                    {
                        lblErrorLabel.Text = Utilities.GetConfigKey(SystemConstants.Message.WrongPassword);
                        lblErrorLabel.Visible = true;
                    }
                    if (Utilities.StringCompare(strOldPwd, helper.ValueObject.Password))
                    {
                        helper.ValueObject.Password = strNewPwd;
                        helper.ValueObject.Last_Modified_At = DateTime.Now;
                        helper.ValueObject.Last_Modified_By = UserId;
                        helper.DoSave();
                        lblInfoLabel.Text = Utilities.GetConfigKey(SystemConstants.Message.ChangePasswordSuccess);
                        lblInfoLabel.Visible = true;

                        //send email
                        SystemEmailFunction.SendChangePassword(helper.ValueObject, txtPwd.Text.Trim());
                    }
                    else
                    {
                        lblErrorLabel.Text = Utilities.GetConfigKey(SystemConstants.Message.WrongPassword);
                        lblErrorLabel.Visible = true;
                    }
                }
            }
        }
    }
}