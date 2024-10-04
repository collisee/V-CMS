using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1
{
    public partial class NewsDetailPrint : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                PanelCateTicker1.CategoryAlias = categoryAlias;

                PanelNewsDetail1.ArticleId = docId;

                //PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}