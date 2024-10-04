 using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport
{
    public partial class NewsDetail : Page
    {
        public string categoryAlias;
        public int docId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);
                
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    Response.Redirect(WebsitesUtils.GetHomepage());
                }

                PanelContentNews1.ArticleId = docId;
                PanelContentNewsPath1.CategoryAlias = categoryAlias;


                PanelHotNews1.CategoryAlias = categoryAlias;

                PanelOtherNews1.ArticleId = docId;
                PanelOtherNews1.CategoryAlias = categoryAlias;

                PanelNewsFeedback1.ArticleId = docId;
                PanelNewsFeedback1.CategoryAlias = categoryAlias;

                PanelArticleTracking1.ArticleId = docId;
                PanelArticleTracking1.CategoryAlias = categoryAlias;


                PanelGame1.ArticleId = docId;

                PanelContentListFeedback1.ArticleId = docId;
                PanelContentListFeedback2.ArticleId = docId;
            }
        }
    }
}