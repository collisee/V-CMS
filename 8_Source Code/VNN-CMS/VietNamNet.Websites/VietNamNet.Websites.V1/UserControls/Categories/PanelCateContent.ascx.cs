using System.Data;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;


namespace VietNamNet.Websites.V1.UserControls.Categories
{
    public partial class PanelCateContent : System.Web.UI.UserControl
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

        public string categoryUrl = string.Empty;

        protected void Page_Load(object sender, System.EventArgs e)
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
                hplPrev.NavigateUrl = string.Format("/vn/{0}trang{1}/index.html", categoryUrl, PageNumber - 1);
                hplNext.NavigateUrl = string.Format("/vn/{0}trang{1}/index.html", categoryUrl, PageNumber + 1);

                
                //Get Article
                WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
                helperArticles.ValueObject.PartitionId = partitionId;
                helperArticles.ValueObject.CategoryId = categoryId;
                helperArticles.ValueObject.FirstIndexRecord = ((PageNumber - 1) * pageSize + 1) + 4;
                helperArticles.ValueObject.LastIndexRecord = (PageNumber * pageSize) + 4;
                helperArticles.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dtArticles = helperArticles.GetCategoryArticles();
                rptListContent.DataSource = dtArticles;
                rptListContent.DataBind();
                
                //hidden link Next
                if (dtArticles == null || dtArticles.Rows.Count < pageSize) hplNext.Visible = false;

            }
        }
    }
}