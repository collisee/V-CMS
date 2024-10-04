using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.V1.UserControls.News
{
  public partial class PanelOtherNews : UserControl
  {
    [Description("ArticleId")]
    [Browsable(true)]
    [DefaultSettingValue("0")]
    public int ArticleId
    {
      get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
      set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
    }

    [Description("Category Alias")]
    [Browsable(true)]
    [DefaultSettingValue("")]
    public string CategoryAlias
    {
      get
      {
        return
          Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.CategoryAlias])
            ? string.Empty
            : ViewState[WebsitesConstants.ViewState.CategoryAlias].ToString();
      }
      set { ViewState[WebsitesConstants.ViewState.CategoryAlias] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      //Article
      if (ArticleId > 0)
      {
        WebsitesHelper articleHelper = new WebsitesHelper(new WebsitesObject());
        articleHelper.ValueObject.ArticleId = ArticleId;
        DataTable dtArticle = articleHelper.GetArticle();
        if (dtArticle != null && dtArticle.Rows.Count > 0)
        {
          //Category
          WebsitesHelper cateHelper = new WebsitesHelper(new WebsitesObject());
          cateHelper.ValueObject.CategoryAlias = CategoryAlias;
          DataTable dt = cateHelper.GetCategoryByAlias();
          if (dt != null && dt.Rows.Count == 1)
          {
            //Get more article
            int categoryId =
              Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
            int partitionId =
              Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

            WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
            helperArticles.ValueObject.PartitionId = partitionId;
            helperArticles.ValueObject.CategoryId = categoryId;
            helperArticles.ValueObject.ArticleId = ArticleId;
            helperArticles.ValueObject.FirstIndexRecord = 1;
            helperArticles.ValueObject.LastIndexRecord = 15;
            rptMore.DataSource = helperArticles.GetCategoryArticlesMore();
            rptMore.DataBind();
          }
        }
      }
    }
  }
}