using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;

namespace VietNamNet.AddOn.Union.UserControls.Hompage
{
  public partial class PanelCategory : UserControl
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
          lnkCategory.Text = dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryDisplayName].ToString();
          lnkCategory.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

          int categoryId = Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryId]);
          int partitionId = Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.PartitionId]);

          //Get Article Number
          UnionHelper helperArticleNumber = new UnionHelper(new UnionObject());
          helperArticleNumber.ValueObject.PartitionId = partitionId;
          helperArticleNumber.ValueObject.CategoryId = categoryId;
          DataTable dtArticleNumber = helperArticleNumber.GetCategoryArticleNumber();

          if (dtArticleNumber != null && dtArticleNumber.Rows.Count == 1)
          {
            string number = Utilities.DisplayNumberFormat(Utilities.ParseInt(dtArticleNumber.Rows[0][0]));
            lnkCategory2.Text = string.Format("{0} Chủ đề", number);
            lnkCategory2.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);
          }
          else
          {
            lnkCategory2.Visible = false;
          }

          //Get Article
          UnionHelper helperArticles= new UnionHelper(new UnionObject());
          helperArticles.ValueObject.PartitionId = partitionId;
          helperArticles.ValueObject.CategoryId = categoryId;
          helperArticles.ValueObject.FirstIndexRecord = 1;
          helperArticles.ValueObject.LastIndexRecord = 4;
          DataTable dtArticles= helperArticles.GetCategoryArticles();

          if (dtArticles != null && dtArticles.Rows.Count > 0)
          {
            DataTable dtArticleTop = dtArticles.Copy();
            while (dtArticleTop.Rows.Count > 1) dtArticleTop.Rows.RemoveAt(1);
            if (Nulls.IsNullOrEmpty(dtArticleTop.Rows[0][UnionConstants.Entity.UnionObject.FieldName.ImageLink]))
            {
              rptTopNoImage.DataSource = dtArticleTop;
              rptTopNoImage.DataBind();
              rptTop.Visible = false;
            }
            else
            {
              rptTop.DataSource = dtArticleTop;
              rptTop.DataBind();
              rptTopNoImage.Visible = false;
            }

            DataTable dtArticleMore = dtArticles.Copy();
            dtArticleMore.Rows.RemoveAt(0);
            rptMore.DataSource = dtArticleMore;
            rptMore.DataBind();
          }
          else
          {
            this.Visible = false;
          }
        }
        else
        {
          this.Visible = false;
        }
      }
    }
  }
}