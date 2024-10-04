using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.ui.xahoi
{
    public partial class Detail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    categoryAlias = "xa-hoi";
                }

                PanelCateTicker1.CategoryAlias = categoryAlias;

                PanelNewsDetail1.ArticleId = docId;

                PanelOtherNews1.ArticleId = docId;
                PanelOtherNews1.CategoryAlias = categoryAlias;

                if (PanelAdvertisement1 != null) PanelAdvertisement1.CategoryAlias = categoryAlias;

                PanelArticleTracking1.ArticleId = docId;
                PanelArticleTracking1.CategoryAlias = categoryAlias;

                PanelContentListFeedback1.ArticleId = docId;
                PanelNewsFeedback1.ArticleId = docId;
                PanelNewsFeedback1.CategoryAlias = categoryAlias;
            }
        }
    }
}