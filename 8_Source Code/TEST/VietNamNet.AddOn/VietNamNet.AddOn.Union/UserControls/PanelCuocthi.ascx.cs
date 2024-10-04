using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;

namespace VietNamNet.AddOn.Union.UserControls
{
  public partial class PanelCuocthi : UserControl
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
          helperArticles.ValueObject.FirstIndexRecord = 1;
          helperArticles.ValueObject.LastIndexRecord = 4;
          DataTable dtArticles = helperArticles.GetCategoryArticles();

          if (dtArticles != null && dtArticles.Rows.Count > 0)
          {
            DataTable dtArticleTop = dtArticles.Copy();
            while (dtArticleTop.Rows.Count > 1) dtArticleTop.Rows.RemoveAt(1);
            if (
              Nulls.IsNullOrEmpty(
                dtArticleTop.Rows[0][UnionConstants.Entity.UnionObject.FieldName.ImageLink]))
            {
              rptTopNoImg.DataSource = dtArticleTop;
              rptTopNoImg.DataBind();
              rptTop.Visible = false;
            }
            else
            {
              rptTop.DataSource = dtArticleTop;
              rptTop.DataBind();
              rptTopNoImg.Visible = false;
            }

            DataTable dtArticleMore = dtArticles.Copy();
            dtArticleMore.Rows.RemoveAt(0);
            rptMore.DataSource = dtArticleMore;
            rptMore.DataBind();
          }
        }
      }
    }
  }
}