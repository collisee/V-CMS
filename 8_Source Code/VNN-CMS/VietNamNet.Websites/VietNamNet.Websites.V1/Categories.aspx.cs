using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1
{
    public partial class Categories : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                PanelCateContent1.CategoryAlias = categoryAlias;
                PanelCateCenterPoint1.CategoryAlias = categoryAlias;
                PanelCateHotNews1.CategoryAlias = categoryAlias;
                PanelCateTicker1.CategoryAlias = categoryAlias;
                 
                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCateContent1.PageNumber = pageNumber;
                PanelOtherNews1.PageNumber = pageNumber;
                PanelOtherNews1.CategoryAlias = categoryAlias;
                if (PanelAdvertisement1 != null) PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}