using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.ui._3g
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

                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCate3gContent1.PageNumber = pageNumber;

                if (PanelAdvertisement1 != null) PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}