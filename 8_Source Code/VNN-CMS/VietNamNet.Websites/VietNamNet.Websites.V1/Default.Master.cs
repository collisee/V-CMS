using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

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

        protected void Page_Init(object sender, EventArgs e)
        {
            //add StyleSheet
            foreach (string styleSheet in WebsitesUtils.GetStyleSheet().Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                HtmlLink css = new HtmlLink();
                css.Href = styleSheet;
                css.Attributes["rel"] = "stylesheet";
                css.Attributes["type"] = "text/css";
                //Page.Header.Controls.Add(css);
                Page.Header.Controls.AddAt(Page.Header.Controls.Count - 1, css);
            }
            //add Javascript
            foreach (string javascipt in WebsitesUtils.GetJavascript().Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                HtmlGenericControl js = new HtmlGenericControl("script");
                js.Attributes["type"] = "text/javascript";
                js.Attributes["src"] = javascipt;
                //Page.Header.Controls.Add(js);
                Page.Header.Controls.AddAt(Page.Header.Controls.Count - 1, js);
            }
        }
    }
}