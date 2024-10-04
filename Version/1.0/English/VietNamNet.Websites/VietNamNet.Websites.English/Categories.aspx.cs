using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.English
{
    public partial class Categories : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias ="";
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                
                PanelCateReadOn1.CategoryAlias = categoryAlias;
                //PanelInFocus1.CategoryAlias = categoryAlias;
                
                string spe_categoryAlias= categoryAlias+"-top-news";
                PanelCateHotNews1.CategoryAlias = spe_categoryAlias;    

                PanelCateTopNews1.CategoryAlias = categoryAlias;
                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCateContent1.PageNumber = pageNumber;
                PanelCateContent1.CategoryAlias = categoryAlias;
                PanelCateReadOn1.PageNumber = pageNumber;
                

                PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }

        protected void PanelCateTopNews1_Load(object sender, EventArgs e)
        {

        }
    }
}