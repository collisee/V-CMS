using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;
using VietNamNet.AddOn.VCard.Core.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.VCard
{
    public partial class PopupVCardDetail : BasePage
    {
        #region  "Controls"

        #endregion

        #region "Event Handlers"
        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            //// test only
            //Session[Constants.Session.USER_ID] = 7;
            //Session[Constants.Session.USER_LOGINNAME] = "dnson";
            //Session[Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
            //Session[Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
            //Session[Constants.Session.USER_STATUS] = "Hoạt động";

            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                SetupEnvironment();
            }
        }

        private void Initialize()
        {
        }

        #endregion

        #region "Private Methods"
        private void SetupEnvironment()
        { 

            if (Request.Params["vcardid"] != null)
            {


                VCardsHelper vHelper = new VCardsHelper(new VCards());
                vHelper.ValueObject.ContactId = Utilities.ParseInt(Request.Params["vcardid"]);
                vHelper.Load();

                if (vHelper.ValueObject == null)
                {
                    Utilities.ItemDoesntExist();
                }

                PopularVCard(vHelper.ValueObject);

                //Store view states
                if (vHelper.ValueObject != null) ViewState["vcardid"] = vHelper.ValueObject.ContactId;
            }
            else
            {
                txtVCardId.Text = Utilities.ParseInt(0).ToString();
            }


        } 
         
        private void PopularVCard(VCards obj)
        {
            txtVCardId.Text = obj.ContactId.ToString();

            txtFullname.Text = obj.Fullname;
            txtOrgTitle.Text = obj.OrgTitle;
            txtOrgName.Text = obj.OrgName;
            txtOrgUnit.Text = obj.OrgUnit;
            txtOrgPhone.Text = obj.OrgPhone;
            txtOrgMobile.Text = obj.OrgMobile;
            txtOrgFax.Text = obj.OrgFax;
            txtOrgAdr1.Text = obj.OrgAdr1;
            txtOrgAdr2.Text = obj.OrgAdr2;
            txtOrgEmail1.Text = obj.OrgEmail1;
            txtOrgEmail2.Text = obj.OrgEmail2;
            txtOrgWebsite.Text = obj.OrgWebsite;
            txtSex.Text = obj.Sex == 0 ? "Nam" : "Nữ";
            
            txtBirthday.Text = obj.Bday.ToShortDateString();


            txtHomePhone.Text = obj.HomePhone;
            txtHomeMobile.Text = obj.HomeMobile;
            txtHomeFax.Text = obj.HomeFax;
            txtHomeAdr1.Text = obj.HomeAdr1;
            txtHomeAdr2.Text = obj.HomeAdr2;
            txtHomeEmail1.Text = obj.HomeEmail1;
            txtHomeEmail2.Text = obj.HomeEmail2;
            txtHomepage.Text = obj.Homepage;

            txtNotes.Text = obj.Notes; 
            txtScope.Text = obj.Scope== 0 ? "Cá nhân" : "Công cộng";

        }
        #endregion

        #region "Public Methods"
        #endregion
    }
}
