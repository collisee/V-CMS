using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;

namespace VietNamNet.AddOn.Union.UserControls.News
{
  public partial class PanelNewsMore : UserControl
  {
    [Description("Category Alias")]
    [Browsable(true)]
    [DefaultSettingValue("")]
    public string CategoryAlias
    {
      get
      {
        return
          Nulls.IsNullOrEmpty(ViewState[UnionConstants.ViewState.CategoryAlias])
            ? string.Empty
            : ViewState[UnionConstants.ViewState.CategoryAlias].ToString();
      }
      set { ViewState[UnionConstants.ViewState.CategoryAlias] = value; }
    }

    [Description("ArticleId")]
    [Browsable(true)]
    [DefaultSettingValue("0")]
    public int ArticleId
    {
      get { return Utilities.ParseInt(ViewState[UnionConstants.ViewState.ArticleId]); }
      set { ViewState[UnionConstants.ViewState.ArticleId] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        UnionHelper helper = new UnionHelper(new UnionObject());
        helper.ValueObject.CategoryAlias = CategoryAlias;
        DataTable dt = helper.GetCategoryByAlias();
        if (dt != null && dt.Rows.Count == 1)
        {
          int categoryId =
            Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryId]);
          int partitionId =
            Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.PartitionId]);

          //Get Article
          UnionHelper helperArticles = new UnionHelper(new UnionObject());
          helperArticles.ValueObject.PartitionId = partitionId;
          helperArticles.ValueObject.CategoryId = categoryId;
          helperArticles.ValueObject.ArticleId = ArticleId;
          helperArticles.ValueObject.FirstIndexRecord = 1;
          helperArticles.ValueObject.LastIndexRecord = 6;
          rptMore.DataSource = helperArticles.GetCategoryArticlesMore();
          rptMore.DataBind();
        }
        else
        {
          Visible = false;
        }
      }
    }
  }
}