using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.English.UserControls.Category
{
  public partial class PanelCateContent : UserControl
  {
    public string categoryUrl = string.Empty;
    public int cateType = 0;

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

    [Description("Page")]
    [Browsable(true)]
    [DefaultSettingValue("1")]
    public int PageNumber
    {
      get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.PageNumber]); }
      set { ViewState[WebsitesConstants.ViewState.PageNumber] = value; }
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

        //Get PageNumber
        int pageSize = Utilities.GetPageSize();
        if (PageNumber <= 0) PageNumber = 1;

        if (PageNumber <= 1) hplPrev.Visible = false;
        hplPrev.NavigateUrl = string.Format("/en/{0}page{1}/index.html", categoryUrl, PageNumber - 1);
        hplNext.NavigateUrl = string.Format("/en/{0}page{1}/index.html", categoryUrl, PageNumber + 1);
        
        //Get Article
        WebsitesHelper helperArticlesTop = new WebsitesHelper(new WebsitesObject());
        helperArticlesTop.ValueObject.PartitionId = partitionId;
        helperArticlesTop.ValueObject.CategoryId = categoryId;
        helperArticlesTop.ValueObject.FirstIndexRecord = ((PageNumber - 1) * pageSize + 1) + 1;
        helperArticlesTop.ValueObject.LastIndexRecord = (PageNumber * pageSize) + 1;

        //switch(cateType)
        //{
        //  case 1:
        //    helperArticlesTop.ValueObject.FirstIndexRecord = ((PageNumber - 1) * pageSize + 1) + 1;
        //    helperArticlesTop.ValueObject.LastIndexRecord = (PageNumber * pageSize) + 1;
        //    break;
        //  default:
        //    helperArticlesTop.ValueObject.FirstIndexRecord = ((PageNumber - 1) * pageSize + 1) + 1;
        //    helperArticlesTop.ValueObject.LastIndexRecord = (PageNumber * pageSize) + 1;
        //    break;
        //}

        helperArticlesTop.ValueObject.CategoryAlias = CategoryAlias;
        DataTable dtArticlesTop = helperArticlesTop.GetCategoryArticles();
        rptContent.DataSource = dtArticlesTop;
        rptContent.DataBind();

        if (dtArticlesTop == null || dtArticlesTop.Rows.Count < pageSize) hplNext.Visible = false;
      }
    }
  }
}