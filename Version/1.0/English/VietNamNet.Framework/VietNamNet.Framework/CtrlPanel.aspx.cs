using System;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Encryption;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework
{
    public partial class CtrlPanel : BasePage
    {
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
                int docId = UserId;
                if (docId > 0) //update
                {
                    UserHelper helper = new UserHelper(new User());
                    helper.ValueObject.Id = docId;
                    helper.Load();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else//add new
                {
                    Utilities.NoRightToAccess();
                }

                txtLoginName.Focus();
            }
        }

        private void Initialize()
        {
            moduleAlias = "Personal";
            viewAlias = "Personal.View";
            addNewAlias = "Personal.AddNew";
            updateAlias = "Personal.Update";
            deleteAlias = "Personal.Delete";
            ErrorMessage1.Visible = false;
            ErrorMessage1.ClearMessage();
            lblInfoLabel.Visible = false;
        }

        private void BindData(User o)
        {
            lblStatus.Text = o.Status;
            txtLoginName.Text = o.LoginName;
            txtFullName.Text = o.FullName;
            txtEmail.Text = o.Email;
            radDpkBirthday.SelectedDate = o.Birthday;
            txtAvatar.Text = o.Avatar;
            cmbSex.SelectedValue = o.Sex;
            txtAddress.Text = o.Address;
            txtPhone.Text = o.Phone;
            txtMobile.Text = o.Mobile;
            txtYahoo.Text = o.Yahoo;
            txtSkype.Text = o.Skype;
            txtFacebook.Text = o.Facebook;
            txtDetail.Text = o.Detail;
        }

        private bool GetData(User o)
        {
            int docId = UserId;
            o.Id = docId;

            //Valid user & user email
            bool blnValid = true;
            UserHelper validLoginNameHelper = new UserHelper(new User());
            validLoginNameHelper.ValueObject.LoginName = txtLoginName.Text.Trim();
            validLoginNameHelper.GetUserByLoginName();
            if (validLoginNameHelper.ValueObject != null && validLoginNameHelper.ValueObject.Id != docId)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.LoginNameExisted));
                blnValid = false;
            }

            UserHelper validEmailHelper = new UserHelper(new User());
            validEmailHelper.ValueObject.Email = txtEmail.Text.Trim();
            validEmailHelper.GetUserByEmail();
            if (validEmailHelper.ValueObject != null && validLoginNameHelper.ValueObject.Id != docId)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.EmailExisted));
                blnValid = false;
            }

            //Email
            if (Nulls.IsNullOrEmpty(txtEmail))
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.EmailCantEmpty));
                blnValid = false;
            }
            //Birthday
            if (radDpkBirthday.SelectedDate == null)
            {
                ErrorMessage1.Visible = true;
                ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.DateOfBirthCantEmpty));
                blnValid = false;
            }
            //Password
            if (!Nulls.IsNullOrEmpty(txtPassword.Text.Trim()) || !Nulls.IsNullOrEmpty(txtRetypePassword.Text.Trim()))
            {
                if (!Utilities.StringCompare(txtPassword.Text.Trim(), txtRetypePassword.Text.Trim()))
                {
                    ErrorMessage1.Visible = true;
                    ErrorMessage1.AddMessage(Utilities.GetConfigKey(SystemConstants.Message.PasswordAndRetypeError));
                    blnValid = false;
                }
            }

            if (!blnValid)
            {
                return false;
            }

            //Getdata
            //o.Status = cmbStatus.SelectedValue;
            o.LoginName = txtLoginName.Text.Trim();
            o.FullName = txtFullName.Text.Trim();
            o.Avatar = txtAvatar.Text.Trim();
            o.Email = txtEmail.Text.Trim();
            o.Birthday = (DateTime)radDpkBirthday.SelectedDate;
            o.Sex = cmbSex.SelectedValue;
            o.Address = txtAddress.Text.Trim();
            o.Phone = txtPhone.Text.Trim();
            o.Mobile = txtMobile.Text.Trim();
            o.Yahoo = txtYahoo.Text.Trim();
            o.Skype = txtSkype.Text.Trim();
            o.Facebook = txtFacebook.Text.Trim();
            o.Detail = txtDetail.Text.Trim();
            o.Password = Nulls.IsNullOrEmpty(txtPassword.Text.Trim())
                             ? o.Password
                             : MD5Encrypt.Encrypt(txtPassword.Text.Trim());
            return true;
        }

        private void DoSave()
        {
            UserHelper helper = new UserHelper(new User());
            int docId = UserId;
            if (docId > 0)
            {
                helper.ValueObject.Id = docId;
                helper.Load();
                if (helper.ValueObject == null)
                {
                    Utilities.ItemDoesntExist();
                    return;
                }
            }
            if (GetData(helper.ValueObject))
            {
                AuditTrail1.Set(helper.ValueObject);
                helper.DoSave();

                //send email
                if (!Nulls.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    SystemEmailFunction.SendChangePassword(helper.ValueObject, txtPassword.Text.Trim());
                }

                //show msg
                lblInfoLabel.Visible = true;
            }
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    DoSave();
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(Constants.FormNames.Default);
                    break;
                default:
                    break;
            }
        }
    }
}