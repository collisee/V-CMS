using System;
using System.Web.UI;
using VietNamNet.Framework.Common;

namespace VietNamNet.Layout.Mobile.UserControls
{
    public partial class PanelUerInterface : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbtnUI_Click(object sender, EventArgs e)
        {
            Session["UserInterface"] = "standard";
            Response.Redirect(Utilities.GetConfigKey("StandardDomain"));
        }
    }
}