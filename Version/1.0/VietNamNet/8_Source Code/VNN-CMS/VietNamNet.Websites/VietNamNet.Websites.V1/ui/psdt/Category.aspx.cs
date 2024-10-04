using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.ui.psdt
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    categoryAlias = "phong-su-dieu-tra";
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
