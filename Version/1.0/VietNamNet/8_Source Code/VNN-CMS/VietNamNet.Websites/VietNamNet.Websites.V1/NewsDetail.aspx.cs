using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1
{
    public partial class NewsDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                PanelCateTicker1.CategoryAlias = categoryAlias;

                PanelNewsDetail1.ArticleId = docId;

                //PanelNewsFeedback1.ArticleId = docId;
                //PanelNewsFeedback1.CategoryAlias = categoryAlias;

                PanelOtherNews1.ArticleId = docId;
                PanelOtherNews1.CategoryAlias = categoryAlias;

                //WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                //helper.ValueObject.CategoryAlias = categoryAlias;
                //DataTable dt = helper.GetCategoryByAlias();
                //if (dt != null && dt.Rows.Count == 1)
                //{
                //  hplCate.Text =
                //      dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryDisplayName].ToString();
                //  hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);
                //}
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