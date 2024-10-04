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
  public partial class PanelTopNews : System.Web.UI.UserControl
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

        dt.Clear();
        helper.ValueObject.PartitionId = partitionId;
        helper.ValueObject.CategoryId = categoryId;

        //Get Article
        helper.ValueObject.FirstIndexRecord = 1;
        helper.ValueObject.LastIndexRecord = 1;
        dt = helper.GetCategoryArticles();
        rptTopNews.DataSource = dt;
        rptTopNews.DataBind();
        dt.Clear();

        //Get Article Other
        helper.ValueObject.FirstIndexRecord = 2;
        helper.ValueObject.LastIndexRecord = 4;
        dt = helper.GetCategoryArticles();
        rptTopNewsOther.DataSource = dt;
        rptTopNewsOther.DataBind();
        dt.Clear();
      }
    }
  }
}