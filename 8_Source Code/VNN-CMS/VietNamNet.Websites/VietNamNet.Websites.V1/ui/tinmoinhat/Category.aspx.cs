using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.ui.tinmoinhat
{
    public partial class Category : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
            PanelCateMoinhatContent1.CategoryAlias = "xa-hoi";

            int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
            PanelCateMoinhatContent1.PageNumber = pageNumber;
            if (PanelAdvertisement1 != null) PanelAdvertisement1.CategoryAlias = categoryAlias;
        }
    }
}