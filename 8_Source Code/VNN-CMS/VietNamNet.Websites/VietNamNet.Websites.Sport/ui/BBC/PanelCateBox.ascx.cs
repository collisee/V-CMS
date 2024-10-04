using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sport.ui.BBC
{
  public partial class PanelCateBox : UserControl
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
        helperArticles.ValueObject.LastIndexRecord = 8;
        DataTable dtArticles = helperArticles.GetCategoryArticles();

        if (dtArticles != null && dt.Rows.Count > 0)
        {
          if (dtArticles.Rows.Count > 0) //top 3
          {
            DataTable dtArticles1 = dtArticles.Copy();
            while (dtArticles1.Rows.Count > 3) dtArticles1.Rows.RemoveAt(3);

            rptTop3.DataSource = dtArticles1;
            rptTop3.DataBind();
          }

          if (dtArticles.Rows.Count > 4) // top 4 - 8
          {
            DataTable dtArticles3 = dtArticles.Copy();
            dtArticles3.Rows.RemoveAt(0); //remove 1            
            dtArticles3.Rows.RemoveAt(1); //remove 2            
            dtArticles3.Rows.RemoveAt(2); //remove 3            
            while (dtArticles3.Rows.Count > 5) dtArticles3.Rows.RemoveAt(5);

            rptTop5.DataSource = dtArticles3;
            rptTop5.DataBind();
          }
        }
      }
    }
  }
}