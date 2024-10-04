using System;
using System.Web.UI;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.V1
{
    public partial class Default : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice && Nulls.IsNullOrEmpty(Session["UserInterface"]))
            {
                Response.Redirect(Utilities.GetConfigKey("MobileDomain"));
            }
        }
    }
}