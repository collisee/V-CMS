using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.V1.UserControls.Homepage
{
    public partial class PanelTopNews : UserControl
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

                //Get Article
                WebsitesHelper helperArticlesTop = new WebsitesHelper(new WebsitesObject());
                helperArticlesTop.ValueObject.PartitionId = partitionId;
                helperArticlesTop.ValueObject.CategoryId = categoryId;
                helperArticlesTop.ValueObject.FirstIndexRecord = 1;
                helperArticlesTop.ValueObject.LastIndexRecord = 4;
                DataTable dtArticlesTop = helperArticlesTop.GetCategoryArticles();

                if (dtArticlesTop != null && dtArticlesTop.Rows.Count > 1)
                {
                    DataTable dtArticlesTop1 = dtArticlesTop.Copy();
                    while (dtArticlesTop1 != null && dtArticlesTop1.Rows.Count > 1) dtArticlesTop1.Rows.RemoveAt(1);
                    rptTop.DataSource = dtArticlesTop1;
                    rptTop.DataBind();

                    if (dtArticlesTop.Rows.Count > 0)
                    {
                        dtArticlesTop.Rows.RemoveAt(0);
                        rptTopOther.DataSource = dtArticlesTop;
                        rptTopOther.DataBind();
                    }
                }
            }
        }
    }
}