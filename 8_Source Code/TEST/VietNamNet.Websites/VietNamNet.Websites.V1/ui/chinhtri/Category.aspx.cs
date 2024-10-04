using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.ui.chinhtri
{
    public partial class Category : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
            if (Nulls.IsNullOrEmpty(categoryAlias))
            {
                categoryAlias = "chinh-tri";
            }
            PanelCatePoll1.CategoryAlias = categoryAlias;
            PanelCateContent1.CategoryAlias = categoryAlias;
            PanelOtherNews1.CategoryAlias = categoryAlias;
            PanelCateTicker1.CategoryAlias = categoryAlias;

            int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
            PanelCateContent1.PageNumber = pageNumber;
            PanelOtherNews1.PageNumber = pageNumber;
            PanelOtherNews1.CategoryAlias = categoryAlias;
            PanelAdvertisement1.CategoryAlias = categoryAlias;
        }
    }
}