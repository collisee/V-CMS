using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro
{
    public partial class HotNewsDetail : Page
    {
        public string categoryAlias = string.Empty;
        public int docId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[PetroConstants.ParameterName.CATEGORY_ALIAS];
                docId = Utilities.ParseInt(Request.Params[PetroConstants.ParameterName.DOC_ID]);

                //Article
                if (docId > 0)
                {
                    PetroHelper articleHelper = new PetroHelper(new PetroObject());
                    articleHelper.ValueObject.ArticleId = docId;
                    DataTable dtArticle = articleHelper.GetArticle();
                    if (dtArticle != null && dtArticle.Rows.Count > 0)
                    {
                        rptNewsDetail.DataSource = dtArticle;
                        rptNewsDetail.DataBind();

                        string title = dtArticle.Rows[0][PetroConstants.Entity.PetroObject.FieldName.Name].ToString().Replace("\"", string.Empty);
                        this.Page.Title = string.Format("Daukhi - {0} | {1}", title, Utilities.RemoveVietNamChar(title)); ;

                        int aticleContentType =
                            Utilities.ParseInt(
                                dtArticle.Rows[0][PetroConstants.Entity.PetroObject.FieldName.ArticleContentTypeId]);
                        //VideoPlayer
                        if (aticleContentType == 3)
                        {
                            VideoPlayer1.ArticleId = docId;
                        }
                        else
                        {
                            VideoPlayer1.Visible = false;
                        }

                        //Comment
                        PanelComment1.ArticleId = docId;

                        //Update TotalView
                        PetroHelper updateHelper = new PetroHelper(new PetroObject());
                        updateHelper.ValueObject.ArticleId = docId;
                        updateHelper.SetTotalView();
                    }

                    //Category
                    PetroHelper cateHelper = new PetroHelper(new PetroObject());
                    cateHelper.ValueObject.ArticleId = docId;
                    DataTable dt = cateHelper.GetPrimaryCategory();
                    if (dt != null && dt.Rows.Count == 1)
                    {
                        //Get more article
                        categoryAlias =
                            dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.Alias].ToString();
                        int categoryId =
                            Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.Id]);
                        int partitionId =
                            Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.PartitionId]);

                        hplCate.Text =
                            dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.DisplayName].ToString();
                        hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);

                        PetroHelper helperArticles = new PetroHelper(new PetroObject());
                        helperArticles.ValueObject.PartitionId = partitionId;
                        helperArticles.ValueObject.CategoryId = categoryId;
                        helperArticles.ValueObject.ArticleId = docId;
                        helperArticles.ValueObject.FirstIndexRecord = 1;
                        helperArticles.ValueObject.LastIndexRecord = 6;
                        rptMore.DataSource = helperArticles.GetCategoryArticlesMore();
                        rptMore.DataBind();
                    }
                }
            }
        }
    }
}