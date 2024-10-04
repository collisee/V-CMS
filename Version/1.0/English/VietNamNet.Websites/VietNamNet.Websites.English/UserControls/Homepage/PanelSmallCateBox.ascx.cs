using System;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.English.UserControls.Homepage
{
  public partial class PanelSmallCateBox : System.Web.UI.UserControl
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
      DataTable dt;

      helper.ValueObject.CategoryAlias = CategoryAlias;
      dt = helper.GetCategoryByAlias();

      if (dt != null && dt.Rows.Count > 0)
      {
        int categoryId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
        int partitionId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

        categoryUrl = dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();

        //Get Category
        helper.ValueObject.PartitionId = partitionId;
        helper.ValueObject.CategoryId = categoryId;
        rptCateTitle.DataSource = dt;
        rptCateTitle.DataBind();
        dt.Clear();

        //Get Article
        helper.ValueObject.FirstIndexRecord = 1;
        helper.ValueObject.LastIndexRecord = 1;
        dt = helper.GetCategoryArticles();
        rptNews.DataSource = dt;
        rptNews.DataBind();
        dt.Clear();

        //Get Article Other
        helper.ValueObject.FirstIndexRecord = 2;
        helper.ValueObject.LastIndexRecord = 4;
        dt = helper.GetCategoryArticles();
        rptNewsOther.DataSource = dt;
        rptNewsOther.DataBind();
        dt.Clear();
      }
    }
  }
}