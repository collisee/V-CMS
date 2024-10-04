using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport.ui.BBC
{
    public partial class Category : Page
    {
        public string categoryAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    categoryAlias = "the-thao";
                }
            }
        }
    }
}