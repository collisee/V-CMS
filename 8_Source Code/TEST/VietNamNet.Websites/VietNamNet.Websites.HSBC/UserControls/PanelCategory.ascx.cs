using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Websites.HSBC.Common;
using VietNamNet.Websites.HSBC.Common.ValueObject;
using VietNamNet.Websites.HSBC.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.HSBC.UserControls
{
    public partial class PanelCategory : UserControl
    {
        [Description("Category Alias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[HSBCConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[HSBCConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[HSBCConstants.ViewState.CategoryAlias] = value; }
        }

        [Description("Page")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int PageNumber
        {
            get { return Utilities.ParseInt(ViewState[HSBCConstants.ViewState.PageNumber]); }
            set { ViewState[HSBCConstants.ViewState.PageNumber] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HSBCHelper helper = new HSBCHelper(new HSBCObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    hplCate.Text =
                        dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryDisplayName].ToString();
                    hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.PartitionId]);

                    //Get PageNumber
                    int pageSize = Utilities.GetPageSize();
                    if (PageNumber <= 0) PageNumber = 1;

                    if (PageNumber <= 1) hplPrev.Visible = false;
                    hplPrev.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber - 1);
                    hplNext.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber + 1);

                    //Get Article
                    HSBCHelper helperArticles = new HSBCHelper(new HSBCObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = (PageNumber - 1) * pageSize + 1;
                    helperArticles.ValueObject.LastIndexRecord = PageNumber * pageSize - 3;
                    DataTable dtArticles = helperArticles.GetCategoryArticles();
                    rptCate.DataSource = dtArticles;
                    rptCate.DataBind();

                    //Get Article1
                    HSBCHelper helperArticles1 = new HSBCHelper(new HSBCObject());
                    helperArticles1.ValueObject.PartitionId = partitionId;
                    helperArticles1.ValueObject.CategoryId = categoryId;
                    helperArticles1.ValueObject.FirstIndexRecord = (PageNumber - 1) * pageSize + 4;
                    helperArticles1.ValueObject.LastIndexRecord = PageNumber * pageSize;
                    DataTable dtArticles1 = helperArticles1.GetCategoryArticles();
                    rptCate1.DataSource = dtArticles1;
                    rptCate1.DataBind();

                    //hidden link Next
                    if (dtArticles1 == null || dtArticles1.Rows.Count < 3) hplNext.Visible = false;
                }
            }
        }
    }
}