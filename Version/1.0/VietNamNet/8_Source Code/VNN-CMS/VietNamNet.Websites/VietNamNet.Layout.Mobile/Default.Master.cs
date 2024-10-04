using System;
using System.Web.UI;

namespace VietNamNet.Layout.Mobile
{
    public partial class Default : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserInterface"] = "";
            }
            if (!Request.Browser.IsMobileDevice)
            {
                //Response.Redirect("http://www.vietnamnet.vn/");
            }
        }
    }
}