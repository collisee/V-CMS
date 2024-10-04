using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Websites.HSBC.Common;
using VietNamNet.Websites.HSBC.Common.ValueObject;
using VietNamNet.Websites.HSBC.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.HSBC
{
    public partial class NewsDetail : Page
    {
        public string categoryAlias = string.Empty;
        public int docId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[HSBCConstants.ParameterName.CATEGORY_ALIAS];
                docId = Utilities.ParseInt(Request.Params[HSBCConstants.ParameterName.DOC_ID]);

                //Article
                if (docId > 0)
                {
                    HSBCHelper articleHelper = new HSBCHelper(new HSBCObject());
                    articleHelper.ValueObject.ArticleId = docId;
                    rptNewsDetail.DataSource = articleHelper.GetArticle();
                    rptNewsDetail.DataBind();

                    //Category
                    HSBCHelper cateHelper = new HSBCHelper(new HSBCObject());
                    cateHelper.ValueObject.CategoryAlias = categoryAlias;
                    DataTable dt = cateHelper.GetCategoryByAlias();
                    if (dt != null && dt.Rows.Count == 1)
                    {
                        hplCate.Text =
                            dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryDisplayName].ToString();
                        hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);

                        //Get more article
                        int categoryId =
                            Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryId]);
                        int partitionId =
                            Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.PartitionId]);

                        HSBCHelper helperArticles = new HSBCHelper(new HSBCObject());
                        helperArticles.ValueObject.PartitionId = partitionId;
                        helperArticles.ValueObject.CategoryId = categoryId;
                        helperArticles.ValueObject.ArticleId = docId;
                        helperArticles.ValueObject.FirstIndexRecord = 1;
                        helperArticles.ValueObject.LastIndexRecord = 6;
                        rptMore.DataSource = helperArticles.GetCategoryArticlesMore();
                        rptMore.DataBind();
                    }
                }
                else //tin top
                {
                    HSBCHelper helper = new HSBCHelper(new HSBCObject());
                    helper.ValueObject.CategoryAlias = categoryAlias;
                    DataTable dt = helper.GetCategoryByAlias();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        hplCate.Text =
                            dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryDisplayName].ToString();
                        hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);

                        //Get Article
                        int categoryId =
                            Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryId]);
                        int partitionId =
                            Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.PartitionId]);

                        HSBCHelper articleHelper = new HSBCHelper(new HSBCObject());
                        articleHelper.ValueObject.PartitionId = partitionId;
                        articleHelper.ValueObject.CategoryId = categoryId;
                        articleHelper.ValueObject.FirstIndexRecord = 1;
                        articleHelper.ValueObject.LastIndexRecord = 1;
                        rptNewsDetail.DataSource = articleHelper.GetCategoryArticles();
                        rptNewsDetail.DataBind();
                    }

                    pnlMoreArticle.Visible = false;
                }
            }
        }
    }
}