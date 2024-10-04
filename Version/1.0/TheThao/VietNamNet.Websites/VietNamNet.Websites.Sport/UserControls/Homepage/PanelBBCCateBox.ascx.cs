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

namespace VietNamNet.Websites.Sport.UserControls.Homepage
{
  public partial class PanelBBCCateBox : UserControl
  {
    public string categoryUrl,categoryUrl1,categoryUrl2,categoryUrl3 = string.Empty;

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

        //Get Article
        WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
        helperArticles.ValueObject.PartitionId = partitionId;
        helperArticles.ValueObject.CategoryId = categoryId;
        helperArticles.ValueObject.FirstIndexRecord = 1;
        helperArticles.ValueObject.LastIndexRecord = 1;
        DataTable dtArticles = helperArticles.GetCategoryArticles();
        rptTop.DataSource = dtArticles;
        rptTop.DataBind();
      }

      //
      WebsitesHelper helper1 = new WebsitesHelper(new WebsitesObject());
      helper1.ValueObject.CategoryAlias = "bbc-tieng-viet-multimedia";
      DataTable dt1 = helper1.GetCategoryByAlias();

      if (dt1 != null && dt1.Rows.Count > 0)
      {
        int categoryId =
            Utilities.ParseInt(dt1.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
        int partitionId =
            Utilities.ParseInt(dt1.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

        categoryUrl1 = dt1.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();

        //Get Article
        WebsitesHelper helperArticles1 = new WebsitesHelper(new WebsitesObject());
        helperArticles1.ValueObject.PartitionId = partitionId;
        helperArticles1.ValueObject.CategoryId = categoryId;
        helperArticles1.ValueObject.FirstIndexRecord = 1;
        helperArticles1.ValueObject.LastIndexRecord = 1;
        DataTable dtArticles1 = helperArticles1.GetCategoryArticles();
        rptTop2.DataSource = dtArticles1;
        rptTop2.DataBind();
      }      
      
      //
      WebsitesHelper helper2 = new WebsitesHelper(new WebsitesObject());
      helper2.ValueObject.CategoryAlias = "bbc-tieng-viet-binh-luan";
      DataTable dt2 = helper2.GetCategoryByAlias();

      if (dt2 != null && dt2.Rows.Count > 0)
      {
        int categoryId =
            Utilities.ParseInt(dt2.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
        int partitionId =
            Utilities.ParseInt(dt2.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

        categoryUrl2 = dt2.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();

        //Get Article
        WebsitesHelper helperArticles2 = new WebsitesHelper(new WebsitesObject());
        helperArticles2.ValueObject.PartitionId = partitionId;
        helperArticles2.ValueObject.CategoryId = categoryId;
        helperArticles2.ValueObject.FirstIndexRecord = 1;
        helperArticles2.ValueObject.LastIndexRecord = 1;
        DataTable dtArticles2 = helperArticles2.GetCategoryArticles();
        rptTop3.DataSource = dtArticles2;
        rptTop3.DataBind();
      }      
      
      //
      WebsitesHelper helper3 = new WebsitesHelper(new WebsitesObject());
      helper3.ValueObject.CategoryAlias = "bbc-tieng-viet-ho-so-premiership";
      DataTable dt3 = helper3.GetCategoryByAlias();

      if (dt3 != null && dt3.Rows.Count > 0)
      {
        int categoryId =
            Utilities.ParseInt(dt3.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
        int partitionId =
            Utilities.ParseInt(dt3.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

        categoryUrl3 = dt3.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();

        //Get Article
        WebsitesHelper helperArticles3 = new WebsitesHelper(new WebsitesObject());
        helperArticles3.ValueObject.PartitionId = partitionId;
        helperArticles3.ValueObject.CategoryId = categoryId;
        helperArticles3.ValueObject.FirstIndexRecord = 1;
        helperArticles3.ValueObject.LastIndexRecord = 1;
        DataTable dtArticles3 = helperArticles3.GetCategoryArticles();
        rptTop4.DataSource = dtArticles3;
        rptTop4.DataBind();
      }
    }
  }
}