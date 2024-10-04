using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;
using VietNamNet.AddOn.VCard.Core.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.AddOn.VCard
{
    public partial class ExportVCard : BasePage
    {
        #region "Event Handlers"

        private void Initialize()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message ;
            }
        }

        #endregion

        #region "Private Methods"
        private void SetupEnvironment()
        {
            if (Request.Params["vcardid"].ToString().Equals("MyVCard"))
            {
                UserHelper u = new UserHelper(new VietNamNet.Framework.System.ValueObject.User());
                u.ValueObject.Id = this.UserId;
                u.Load();

                if (u.ValueObject != null)
                {
                    VCards v = new VCards();
                    v.Fullname = u.ValueObject.FullName;
                    v.OrgEmail1 = u.ValueObject.Email; 
                    v.Bday = u.ValueObject.Birthday;
                    v.OrgAdr1 = u.ValueObject.Address;
                    v.OrgPhone = u.ValueObject.Phone;
                    v.OrgMobile = u.ValueObject.Mobile;
                    v.Notes = u.ValueObject.Detail;

                    ExportVcard(v);
                    return;
                }

            }

            if (Request.Params["vcardid"] != null)
            {

                    VCardsHelper vHelper = new VCardsHelper(new VCards());
                    vHelper.ValueObject.ContactId = Utilities.ParseInt(Request.Params["vcardid"]);
                    vHelper.Load();

                    if (vHelper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        ExportVcard(vHelper.ValueObject);
                    }
                    return;
 
            } 
        }

        private void ExportVcard(VCards obj)
        {
            //clear Response.object
            Response.Clear();
            // Response.Charset = "Unicode"; 
            Response.AddHeader("Content-disposition", "attachment; filename=\"" + obj.Fullname + "\".vcf");
            //Response.ContentEncoding = Encoding.UTF8;
            //set the Response mime type for vCard

            Response.ContentType = "text/x-vCard";

            Response.Write(obj.ToString());

            Response.End();
        }
 
        #endregion
    }
}
