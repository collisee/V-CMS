using System;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework
{
    public partial class UserInfo : BasePage
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
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0)
                {
                    UserHelper helper = new UserHelper(new User());
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
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }
            }
        }

        private void Initialize()
        {
        }

        private void BindData(User o)
        {
            lblStatus.Text = o.Status;
            lblLoginName.Text = o.LoginName;
            lblFullName.Text = o.FullName;
            lblEmail.Text = o.Email;
            imgAvatar.ImageUrl = o.Avatar;
            lblBirthday.Text = Utilities.FormatDisplayDateOnly(o.Birthday);
            lblSex.Text = o.Sex;
            lblAddress.Text = o.Address;
            lblPhone.Text = o.Phone;
            lblMobile.Text = o.Mobile;
            lblYahoo.Text = o.Yahoo;
            lblSkype.Text = o.Skype;
            lblFacebook.Text = o.Facebook;
            lblDetail.Text = o.Detail;
            radGridMemberOf.DataSource = o.MemberOf;
            radGridMemberOf.DataBind();
        }
    }
}