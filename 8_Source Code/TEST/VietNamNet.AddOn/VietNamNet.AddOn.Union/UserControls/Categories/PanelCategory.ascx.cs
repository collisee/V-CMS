using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Union.UserControls.Categories
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
                    Nulls.IsNullOrEmpty(ViewState[UnionConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[UnionConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[UnionConstants.ViewState.CategoryAlias] = value; }
        }

        [Description("Page")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int PageNumber
        {
            get { return Utilities.ParseInt(ViewState[UnionConstants.ViewState.PageNumber]); }
            set { ViewState[UnionConstants.ViewState.PageNumber] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //hplCate.Text = CategoryAlias;

                UnionHelper helper = new UnionHelper(new UnionObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.GetCategoryByAlias();
                if (dt != null && dt.Rows.Count == 1)
                {
                    hplCate.Text =
                        dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryDisplayName].ToString();
                    hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.PartitionId]);

                    //Get Article
                    int pageSize = Utilities.GetPageSize();
                    if (PageNumber <= 0) PageNumber = 1;

                    //hidden link Prev
                    if (PageNumber <= 1) hplPrev.Visible = false;
                    hplPrev.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber - 1);
                    hplNext.NavigateUrl = string.Format("/vn/{0}/page/{1}/index.html", CategoryAlias, PageNumber + 1);
                    
                    int topNews = 8;
                    UnionHelper helperArticles = new UnionHelper(new UnionObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = (PageNumber - 1)*pageSize + 1;
                    helperArticles.ValueObject.LastIndexRecord = PageNumber*pageSize;
                    DataTable dtArticles = helperArticles.GetCategoryArticles();

                    if (dtArticles != null && dtArticles.Rows.Count > 0)
                    {
                        DataTable dtArticleTop = dtArticles.Copy();
                        while (dtArticleTop.Rows.Count > topNews) dtArticleTop.Rows.RemoveAt(topNews);
                        rptTop.DataSource = dtArticleTop;
                        rptTop.DataBind();

                        DataTable dtArticleMore = dtArticles.Copy();
                        for (int i = 0; i < topNews; i++)
                        {
                            if (dtArticleMore.Rows.Count > 0) dtArticleMore.Rows.RemoveAt(0);
                        }
                        rptMore.DataSource = dtArticleMore;
                        rptMore.DataBind();

                        //hidden link Next
                        if (dtArticleMore == null || dtArticleMore.Rows.Count < pageSize - 8) hplNext.Visible = false;
                    }
                    else
                    {
                        Visible = false;
                    }
                }
                else
                {
                    Visible = false;
                }
            }
        }
    }
}