using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.ui.xahoi
{
    public partial class Category : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    categoryAlias = "xa-hoi";
                }
                PanelCateContent1.CategoryAlias = categoryAlias;
                PanelCateTicker1.CategoryAlias = categoryAlias;
                PanelOtherNews1.CategoryAlias = categoryAlias;

                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCateContent1.PageNumber = pageNumber;
                PanelOtherNews1.PageNumber = pageNumber;
                PanelOtherNews1.CategoryAlias = categoryAlias;
                if (PanelAdvertisement1 != null) PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}