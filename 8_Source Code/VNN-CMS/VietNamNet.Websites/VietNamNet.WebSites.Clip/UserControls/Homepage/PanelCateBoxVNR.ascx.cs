using System;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Clip.UserControls.Homepage
{
  public partial class PanelCateBoxVNR : System.Web.UI.UserControl
  {
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

    public string categoryUrl = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
      WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
      helper.ValueObject.CategoryAlias = CategoryAlias;
      DataTable dt = helper.GetCategoryByAlias();

      if (dt != null && dt.Rows.Count > 0)
      {
        int categoryId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
        int partitionId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);
        categoryUrl = dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();

        ////Get Category
        //helper.ValueObject.PartitionId = partitionId;
        //helper.ValueObject.CategoryId = categoryId;
        //rptCateTitle.DataSource = dt;
        //rptCateTitle.DataBind();

        //Get Article
        WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
        helperArticles.ValueObject.PartitionId = partitionId;
        helperArticles.ValueObject.CategoryId = categoryId;
        helperArticles.ValueObject.FirstIndexRecord = 1;
        helperArticles.ValueObject.LastIndexRecord = 1;
        DataTable dtArticles = helperArticles.GetCategoryArticles();
        rptTop.DataSource = dtArticles;
        rptTop.DataBind();

        //Get Article
        WebsitesHelper helperArticles2 = new WebsitesHelper(new WebsitesObject());
        helperArticles2.ValueObject.PartitionId = partitionId;
        helperArticles2.ValueObject.CategoryId = categoryId;
        helperArticles2.ValueObject.FirstIndexRecord = 2;
        helperArticles2.ValueObject.LastIndexRecord = 5;
        DataTable dtArticles2 = helperArticles2.GetCategoryArticles();
        rptNext.DataSource = dtArticles2;
        rptNext.DataBind();
      }
    }
  }
}