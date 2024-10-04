using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport
{
    public partial class Default : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utilities.StringCompare(Request.QueryString["ui"], "standard"))
            {
                Session["UserInterface"] = "standard";
            }

            if (Request.Browser.IsMobileDevice && Nulls.IsNullOrEmpty(Session["UserInterface"]))
            {
                string url = string.Format("{0}{1}", Utilities.GetConfigKey("MobileDomain")
                    , Request.Url.AbsolutePath);
                Response.Redirect(url);
            }

            string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
            if (!Nulls.IsNullOrEmpty(categoryAlias)) PanelAdvertisement1.CategoryAlias = categoryAlias;
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