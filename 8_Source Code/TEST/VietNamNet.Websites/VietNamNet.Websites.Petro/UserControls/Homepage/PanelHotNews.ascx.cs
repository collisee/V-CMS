using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.UserControls.Homepage
{
    public partial class PanelHotNews : UserControl
    {
        [Description("Category Alias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[PetroConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[PetroConstants.ViewState.CategoryAlias] = value; }
        }

        public string commentCounter = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PetroHelper helper = new PetroHelper(new PetroObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.PartitionId]);

                    //Get Article
                    PetroHelper helperArticles = new PetroHelper(new PetroObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = 1;
                    helperArticles.ValueObject.LastIndexRecord = 1;
                    DataTable dtArticles = helperArticles.GetCategoryArticles();
                    if (dtArticles != null && dtArticles.Rows.Count == 1)
                    {
                        rptHotNews.DataSource = dtArticles;
                        rptHotNews.DataBind();

                        int articleId =
                            Utilities.ParseInt(dtArticles.Rows[0][PetroConstants.Entity.PetroObject.FieldName.Id]);

                        PetroHelper helperComment = new PetroHelper(new PetroObject());
                        helperComment.ValueObject.ArticleId = articleId;
                        DataTable dtComment = helperComment.GetArticleComment();
                        if (dtComment != null)
                        {
                            commentCounter = Utilities.DisplayNumberFormat(dtComment.Rows.Count);
                        }
                    }

                    //Get Article1
                    PetroHelper helperArticles1 = new PetroHelper(new PetroObject());
                    helperArticles1.ValueObject.PartitionId = partitionId;
                    helperArticles1.ValueObject.CategoryId = categoryId;
                    helperArticles1.ValueObject.FirstIndexRecord = 2;
                    helperArticles1.ValueObject.LastIndexRecord = 3;
                    DataTable dtArticles1 = helperArticles1.GetCategoryArticles();
                    rptCate1.DataSource = dtArticles1;
                    rptCate1.DataBind();
                }
            }
        }
    }
}