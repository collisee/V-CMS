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
  public partial class PanelSearch : UserControl
  {
    [Description("Search Keyword")]
    [Browsable(true)]
    [DefaultSettingValue("")]
    public string SearchKeyword
    {
      get
      {
        return
            Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.SearchKeyword])
                ? string.Empty
                : ViewState[PetroConstants.ViewState.SearchKeyword].ToString();
      }
      set { ViewState[PetroConstants.ViewState.SearchKeyword] = value; }
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
        SearchKeyword = Convert.ToString(Request.QueryString["keyword"]);
        PageNumber = Utilities.ParseInt(Request.Params[PetroConstants.ParameterName.PAGE]);

        //Get PageNumber
        int pageSize = Utilities.GetPageSize();
        if (PageNumber <= 0) PageNumber = 1;

        //hidden link Prev
        if (PageNumber <= 1) hplPrev.Visible = false;
        hplPrev.NavigateUrl = string.Format("/vn/tim-kiem/page/{1}/index.html?keyword={0}", SearchKeyword, PageNumber - 1);
        hplNext.NavigateUrl = string.Format("/vn/tim-kiem/page/{1}/index.html?keyword={0}", SearchKeyword, PageNumber + 1);

        PetroHelper helper = new PetroHelper(new PetroObject());
        helper.ValueObject.Searchkeyword = "%" + SearchKeyword + "%";
        helper.ValueObject.FirstIndexRecord = (PageNumber - 1) * pageSize + 1;
        helper.ValueObject.LastIndexRecord = PageNumber * pageSize - 1;
        DataTable dt = helper.GetSearchArticles();

        if (dt != null && dt.Rows.Count > 0)
        {
          //Get Article
          rptSearchArticles.DataSource = dt;
          rptSearchArticles.DataBind();
        }

        //hidden link Next
        if (dt == null || dt.Rows.Count < pageSize) hplNext.Visible = false;
      }
    }
  }
}