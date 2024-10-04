using System;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.V1.UserControls.Categories
{
    public partial class PanelCateLargeBox : System.Web.UI.UserControl
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
                int categoryId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                int partitionId = Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

                //Get Category
                helper.ValueObject.PartitionId = partitionId;
                helper.ValueObject.CategoryId = categoryId;
                rptCateTitle.DataSource = dt;
                rptCateTitle.DataBind();

                //Get Article
                WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
                helperArticles.ValueObject.PartitionId = partitionId;
                helperArticles.ValueObject.CategoryId = categoryId;
                helperArticles.ValueObject.FirstIndexRecord = 1;
                helperArticles.ValueObject.LastIndexRecord = 4;
                DataTable dtArticles = helperArticles.GetCategoryArticles();

                if (dtArticles != null && dt.Rows.Count > 0)
                {
                    if (dtArticles.Rows.Count > 0) //top 1
                    {
                        DataTable dtArticles1 = dtArticles.Copy();
                        while (dtArticles1.Rows.Count > 1) dtArticles1.Rows.RemoveAt(1);

                        rptTop1.DataSource = dtArticles1;
                        rptTop1.DataBind();
                    }

                    if (dtArticles.Rows.Count > 1)
                    {
                        dtArticles.Rows.RemoveAt(0); //remove 1

                        rptTopNext.DataSource = dtArticles;
                        rptTopNext.DataBind();
                    }
                }
            }
        }
    }
}