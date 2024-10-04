using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;
using VietNamNet.Framework.Common;


namespace VietNamNet.Websites.Petro.UserControls
{
  public partial class PanelTheodongsukien : System.Web.UI.UserControl
  {
    [Description("Category Alias")]
    [Browsable(true)]
    [DefaultSettingValue("")]
    public string CategoryAlias
    {
      get
      {
        return
            Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.CategoryAlias])
                ? string.Empty
                : ViewState[PetroConstants.ViewState.CategoryAlias].ToString();
      }
      set { ViewState[PetroConstants.ViewState.CategoryAlias] = value; }
    }

    [Description("Page")]
    [Browsable(true)]
    [DefaultSettingValue("1")]
    public int PageNumber
    {
      get { return Utilities.ParseInt(ViewState[PetroConstants.ViewState.PageNumber]); }
      set { ViewState[PetroConstants.ViewState.PageNumber] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        PetroHelper helper = new PetroHelper(new PetroObject());
        helper.ValueObject.CategoryAlias = CategoryAlias;
        DataTable dt = helper.GetCategoryByAlias();

        if (dt != null && dt.Rows.Count > 0)
        {
          hplCate.Text =
              dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.CategoryDisplayName].ToString();
          hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

          int categoryId =
              Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.CategoryId]);
          int partitionId =
              Utilities.ParseInt(dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.PartitionId]);

          //Get PageNumber
          int pageSize = Utilities.GetPageSize();
          if (PageNumber <= 0) PageNumber = 1;

          //Get Article
          PetroHelper helperArticles = new PetroHelper(new PetroObject());
          helperArticles.ValueObject.PartitionId = partitionId;
          helperArticles.ValueObject.CategoryId = categoryId;
          helperArticles.ValueObject.FirstIndexRecord = (PageNumber - 1) * pageSize + 1;
          helperArticles.ValueObject.LastIndexRecord = 6;
          DataTable dtArticles = helperArticles.GetCategoryArticles();
          rptCate.DataSource = dtArticles;
          rptCate.DataBind();
        }
      }
    }
  }
}