using System;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Sport.UserControls.Homepage
{
  public partial class PanelTrungthuong : System.Web.UI.UserControl
  {
    public string categoryUrl = string.Empty;

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

    [Description("FirstIndexRecord")]
    [Browsable(true)]
    [DefaultSettingValue("1")]
    public int FirstIndexRecord
    {
      get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.FirstIndexRecord]); }
      set { ViewState[WebsitesConstants.ViewState.FirstIndexRecord] = value; }
    }

    [Description("LastIndexRecord")]
    [Browsable(true)]
    [DefaultSettingValue("5")]
    public int LastIndexRecord
    {
      get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.LastIndexRecord]); }
      set { ViewState[WebsitesConstants.ViewState.LastIndexRecord] = value; }
    }

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

        //Get Article
        WebsitesHelper helperArticles2 = new WebsitesHelper(new WebsitesObject());
        helperArticles2.ValueObject.PartitionId = partitionId;
        helperArticles2.ValueObject.CategoryId = categoryId;
        helperArticles2.ValueObject.FirstIndexRecord = 1;
        helperArticles2.ValueObject.LastIndexRecord = 4;
        DataTable dtArticles2 = helperArticles2.GetCategoryArticles();
        rptMostRead.DataSource = dtArticles2;
        rptMostRead.DataBind();
      }
    }
  }
}