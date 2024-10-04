using System;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.AddOn.Union
{
    public partial class UserInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Response.Redirect("~/");
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

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else //add new
                {
                    Utilities.NoRightToAccess();
                }
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Union";
            viewAlias = "VietNamNet.AddOn.Union.View";
            addNewAlias = "VietNamNet.AddOn.Union.AddNew";
            updateAlias = "VietNamNet.AddOn.Union.Update";
            deleteAlias = "VietNamNet.AddOn.Union.Delete";
            lblInfoLabel.Visible = false;
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }

        private void BindData(User o)
        {
            //txtLoginName.Text = o.LoginName;
            txtFullName.Text = o.FullName;
            txtEmail.Text = o.Email;
            txtAvatar.Text = o.Avatar;
            radDpkBirthday.SelectedDate = o.Birthday;
            cmbSex.SelectedValue = o.Sex;
            txtAddress.Text = o.Address;
            txtPhone.Text = o.Phone;
            txtMobile.Text = o.Mobile;
            txtYahoo.Text = o.Yahoo;
            txtSkype.Text = o.Skype;
            txtFacebook.Text = o.Facebook;
        }

        private bool GetData(User o)
        {
            int docId = UserId;
            o.Id = docId;

            //Getdata
            //o.LoginName = txtLoginName.Text.Trim();
            o.FullName = txtFullName.Text.Trim();
            o.Email = txtEmail.Text.Trim();
            o.Avatar = txtAvatar.Text;
            o.Birthday = (DateTime) radDpkBirthday.SelectedDate;
            o.Sex = cmbSex.SelectedValue;
            o.Address = txtAddress.Text.Trim();
            o.Phone = txtPhone.Text.Trim();
            o.Mobile = txtMobile.Text.Trim();
            o.Yahoo = txtYahoo.Text.Trim();
            o.Skype = txtSkype.Text.Trim();
            o.Facebook = txtFacebook.Text.Trim();
            //o.Password = Nulls.IsNullOrEmpty(txtPassword.Text.Trim())
            //                       ? o.Password
            //                       : MD5Encrypt.Encrypt(txtPassword.Text.Trim());
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                helper.DoSave();

                //show msg
                lblInfoLabel.Visible = true;

                //new Avatar
                Session[Constants.Session.USER_AVATAR] = helper.ValueObject.Avatar;
            }
        }
    }
}