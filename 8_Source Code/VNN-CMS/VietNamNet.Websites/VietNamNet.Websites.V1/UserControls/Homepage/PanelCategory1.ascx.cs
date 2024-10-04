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

namespace VietNamNet.Websites.V1.UserControls.Homepage
{
  public partial class PanelCategory1 : UserControl
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

    [Description("Sub Category Name")]
    [Browsable(true)]
    [DefaultSettingValue(null)]
    public string SubCategoryName
    {
      get
      {
        return
          Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SubCategoryName])
            ? string.Empty
            : ViewState[WebsitesConstants.ViewState.SubCategoryName].ToString();
      }
      set { ViewState[WebsitesConstants.ViewState.SubCategoryName] = value; }
    }

    [Description("Sub Category Link")]
    [Browsable(true)]
    [DefaultSettingValue(null)]
    public string SubCategoryLink
    {
      get
      {
        return
          Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SubCategoryLink])
            ? string.Empty
            : ViewState[WebsitesConstants.ViewState.SubCategoryLink].ToString();
      }
      set { ViewState[WebsitesConstants.ViewState.SubCategoryLink] = value; }
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

    public string categoryUrl = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
      //set subcate
      string[] strSubCateNames = SubCategoryName.Split(new char[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);
      string[] strSubCateLinks = SubCategoryLink.Split(new char[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);

      for (int i = 0; i < strSubCateNames.Length; i++)
      {
        try
        {
          HyperLink link = (HyperLink) FindControl("cattitle_sub" + i.ToString());
          if (link != null)
          {
            if (i < strSubCateLinks.Length)
            {
              link.Text = strSubCateNames[i];
              link.NavigateUrl = strSubCateLinks[i];
              link.Visible = true;
            }
          }
        }
        catch
        {
        }
      }

      WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
      helper.ValueObject.CategoryAlias = CategoryAlias;
      DataTable dt = helper.GetCategoryByAlias();

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

        ////Get Sub Category
        //WebsitesHelper helperSubCate = new WebsitesHelper(new WebsitesObject());
        //helperSubCate.ValueObject.PartitionId = partitionId;
        //helperSubCate.ValueObject.CategoryId = categoryId;
        //helperSubCate.ValueObject.FirstIndexRecord = 1;
        //helperSubCate.ValueObject.LastIndexRecord = 4;
        //helperSubCate.ValueObject.CategoryAlias = CategoryAlias;
        //DataTable dtSubCate = helperSubCate.GetSubCategory();
        //rptSubCate.DataSource = dtSubCate;
        //rptSubCate.DataBind();

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
        helperArticles2.ValueObject.LastIndexRecord = 3;
        DataTable dtArticles2 = helperArticles2.GetCategoryArticles();
        rptTop2.DataSource = dtArticles2;
        rptTop2.DataBind();

        //Get Article
        WebsitesHelper helperArticles3 = new WebsitesHelper(new WebsitesObject());
        helperArticles3.ValueObject.PartitionId = partitionId;
        helperArticles3.ValueObject.CategoryId = categoryId;
        helperArticles3.ValueObject.FirstIndexRecord = 4;
        helperArticles3.ValueObject.LastIndexRecord = 6;
        DataTable dtArticles3 = helperArticles3.GetCategoryArticles();
        rptTop3.DataSource = dtArticles3;
        rptTop3.DataBind();
      }
    }
  }
}