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
                PanelCateBox1_1.CategoryAlias = categoryAlias;
                PanelCateBox1_2.CategoryAlias = categoryAlias;
                PanelCateBox1.CategoryAlias = categoryAlias;
                PanelCateBox2.CategoryAlias = categoryAlias;
                PanelCateContent1.CategoryAlias = categoryAlias;
                PanelCateCenterPoint1.CategoryAlias = categoryAlias;
                PanelCateHotSlide1.CategoryAlias = categoryAlias;
                PanelCateHotNews1.CategoryAlias = categoryAlias;
                PanelCatePoll1.CategoryAlias = categoryAlias;
                PanelCateTicker1.CategoryAlias = categoryAlias;
                 

                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCateContent1.PageNumber = pageNumber;
                PanelOtherNews1.PageNumber = pageNumber;
                PanelOtherNews1.CategoryAlias = categoryAlias;
                PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}