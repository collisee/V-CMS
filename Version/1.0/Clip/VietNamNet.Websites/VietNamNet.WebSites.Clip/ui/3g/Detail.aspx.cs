using System;
using System.Data;
using System.Web.UI;
using System.Configuration;
using System.ComponentModel;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Clip.ui._3g
{
    public partial class Detail : Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    categoryAlias = "video-3g-hot";
                }

                //PanelCateTicker1.CategoryAlias = categoryAlias;
                PanelArticlePlaylist1.ArticleId = docId;
                PanelAdvertisement1.CategoryAlias = categoryAlias;

                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.ArticleId = docId;
                DataTable dtArticle = helper.GetArticle();
                if (dtArticle != null && dtArticle.Rows.Count > 0)
                {
                    string title =
                      dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.Name].ToString().Replace("\"",
                                                                                                                   string.Empty);
                    Page.Title = string.Format("VietNamNet - {0} | {1}", title, Utilities.RemoveVietNamChar(title));

                    //Get more article
                    int categoryId = Utilities.ParseInt(dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                    int partitionId = Utilities.ParseInt(dtArticle.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

                    WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.ArticleId = docId;
                    helperArticles.ValueObject.FirstIndexRecord = 1;
                    helperArticles.ValueObject.LastIndexRecord = 15;
                    rptMore.DataSource = helperArticles.GetCategoryArticlesMore();
                    rptMore.DataBind();
                }
            }
        }
    }
}
