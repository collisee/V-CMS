using System;
using System.Web.UI;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport.UserControls
{
    public partial class PanelMenu : UserControl
    {
        public string categoryAlias = string.Empty;
        public string KeyWords = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Search KeyWords
            if (Request.QueryString["keyword"] != null)
            {
                KeyWords = Request.QueryString["keyword"].ToString();
            }
            categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
        }
    }
}