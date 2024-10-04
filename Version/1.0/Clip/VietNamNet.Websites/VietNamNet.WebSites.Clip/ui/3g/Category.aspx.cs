using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Clip.ui._3g
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
                    categoryAlias = "video-3g-hot";
                }
                PanelCatePoll1.CategoryAlias = categoryAlias;
                //PanelCateTicker1.CategoryAlias = categoryAlias;

                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCate3gContent1.PageNumber = pageNumber;

                PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}