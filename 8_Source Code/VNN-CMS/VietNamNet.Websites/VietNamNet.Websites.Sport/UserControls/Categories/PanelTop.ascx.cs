using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sport.UserControls.Categories
{
  public partial class PanelTop : UserControl
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
        int categoryId =
          Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
        int partitionId =
          Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

        categoryUrl = dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();

        //Get Category
        helper.ValueObject.PartitionId = partitionId;
        helper.ValueObject.CategoryId = categoryId;
        rptCateTitle.DataSource = dt;
        rptCateTitle.DataBind();

        //Get Article
        WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
        helperArticles.ValueObject.PartitionId = partitionId;
        helperArticles.ValueObject.CategoryId = categoryId;
        helperArticles.ValueObject.FirstIndexRecord = 1;
        helperArticles.ValueObject.LastIndexRecord = 9;
        DataTable dtArticles = helperArticles.GetCategoryArticles();

        if (dtArticles != null && dt.Rows.Count > 0)
        {
          if (dtArticles.Rows.Count > 0) //top 1
          {
            DataTable dtArticles1 = dtArticles.Copy();
            while (dtArticles1.Rows.Count > 1) dtArticles1.Rows.RemoveAt(1);

            rptTop.DataSource = dtArticles1;
            rptTop.DataBind();
          }

          if (dtArticles.Rows.Count > 1) // top 2 - 8
          {
            DataTable dtArticles2 = dtArticles.Copy();
            dtArticles2.Rows.RemoveAt(0); //remove 1

            rptTop3.DataSource = dtArticles2;
            rptTop3.DataBind();
          }
        }
      }
    }
  }
}