using System;
using System.Web.UI;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.Sports.Mobile.UserControls
{
    public partial class PanelUerInterface : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbtnUI_Click(object sender, EventArgs e)
        {
            Session["UserInterface"] = "standard";
            string url = string.Format("{0}{1}?ui=standard", Utilities.GetConfigKey("StandardDomain")
                , Request.Url.AbsolutePath);
            Response.Redirect(url);
        }
    }
}