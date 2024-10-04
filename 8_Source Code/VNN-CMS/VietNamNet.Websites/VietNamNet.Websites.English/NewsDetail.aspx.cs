using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.English
{
    public partial class NewsDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                PanelContentCateName1.CategoryAlias = categoryAlias;
                PanelContentNews1.ArticleId = docId;
                PanelContentNews1.CategoryAlias = categoryAlias;
                
                PanelContentReadOn1.CategoryAlias = categoryAlias;
                PanelContentReadOn1.ArticleId = docId;
                
                PanelContentListFeedback1.ArticleId = docId;
                PanelContentFeedback1.ArticleId = docId;

                PanelAdvertisement1.CategoryAlias = categoryAlias;
                PaneSurvey1.ArticleId = docId;

            }
        }
    }
}