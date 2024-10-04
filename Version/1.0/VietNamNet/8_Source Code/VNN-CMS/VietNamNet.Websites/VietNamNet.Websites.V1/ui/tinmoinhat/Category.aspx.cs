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
            PanelCateMonongContent1.CategoryAlias = categoryAlias;
            //PanelCateContent1.CategoryAlias = categoryAlias;
            PanelCateTicker1.CategoryAlias = categoryAlias;
            //PanelOtherNews1.CategoryAlias = categoryAlias;

            int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
            PanelCateMonongContent1.PageNumber = pageNumber;
            //PanelCateContent1.PageNumber = pageNumber;
            //PanelOtherNews1.PageNumber = pageNumber;
            if (PanelAdvertisement1 != null) PanelAdvertisement1.CategoryAlias = categoryAlias;
        }
    }
}