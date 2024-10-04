using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.English.UserControls.Search
{
    public partial class PanelSearchContent : UserControl
    {
        #region Members

        private string _categoryAlias = "";
        private int _page;
        private string _publishDate = "";
        private string _searchKeyword = "";

        [Description("Search Keyword")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string SearchKeyword
        {
            get
            {
                return _searchKeyword;
            }
            set
            {
                _searchKeyword = value;
            }
        }

        [Description("CategoryAlias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return _categoryAlias;
                //    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.SearchKeyword])
                //        ? string.Empty
                //        : ViewState[PetroConstants.ViewState.SearchKeyword].ToString();
            }
            set
            {
//_searchKeyword = value; 
                _categoryAlias = value;
            }
        }

        [Description("PublishDate")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string PublishDate
        {
            get
            {
                return _publishDate;
                //    Nulls.IsNullOrEmpty(ViewState[PetroConstants.ViewState.SearchKeyword])
                //        ? string.Empty
                //        : ViewState[PetroConstants.ViewState.SearchKeyword].ToString();
            }
            set
            {
//_searchKeyword = value; 
                _publishDate = value;
            }
        }


        [Description("Page")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int PageNumber
        {
            get { return _page; }
            set { _page = value; }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["keyword"] != null && Request.QueryString["keyword"] != "")
                {
                    SearchKeyword = Convert.ToString(Request.QueryString["keyword"]);
                }
                if (Request.QueryString["cat"] != null && Request.QueryString["cat"] != "")
                {
                    CategoryAlias = Convert.ToString(Request.QueryString["cat"]);
                }
                if (Request.QueryString["d"] != null && Request.QueryString["d"] != "" &&
                    Request.QueryString["d"].Length == 8)
                {
                    string d = Convert.ToString(Request.QueryString["d"]);
                    if (d.Length == 8) PublishDate = d;
                }

                SetupEnvironment();

                if (SearchKeyword != "" || CategoryAlias != "" || PublishDate != "")
                {
                    PopularItem();
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetupEnvironment()
        {
            lScript.Text = "";
        }

        private void PopularItem()
        {
            //Get PageNumber
            int pageSize = Utilities.GetPageSize();
            if (PageNumber <= 0) PageNumber = 1;

            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.FirstIndexRecord = (PageNumber - 1)*pageSize + 1;
            helper.ValueObject.LastIndexRecord = PageNumber*pageSize - 1;
            helper.ValueObject.Keywords = SearchKeyword;
            helper.ValueObject.CategoryAlias = CategoryAlias;
            helper.ValueObject.PublishDate = PublishDate;

            DataTable dt = helper.Search();

            //lblMessages.Text= dt.TableName + dt.Rows.Count.ToString();
            if (dt != null && dt.Rows.Count > 0)
            {
                //Get Article
                rptSearchArticles.DataSource = dt;
                rptSearchArticles.DataBind();
                //Paging
                if (PageNumber <= 1) hplPrev.Visible = false;
                hplPrev.NavigateUrl =
                    string.Format("/en/search/index.html?keyword={0}&page={1}", SearchKeyword, PageNumber - 1);
                if (dt.Rows.Count < pageSize) hplNext.Visible = false;
                hplNext.NavigateUrl =
                    string.Format("/en/search/index.html?keyword={0}&page={1}", SearchKeyword, PageNumber + 1);
            }
            else
            {
                hplPrev.Visible = false;
                hplNext.Visible = false;
                rptSearchArticles.Visible = false;
            }
        }

        #endregion
    }
}