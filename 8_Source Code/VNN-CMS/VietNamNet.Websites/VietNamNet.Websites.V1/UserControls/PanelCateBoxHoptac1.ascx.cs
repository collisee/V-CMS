using System;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Presentation;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.V1.UserControls
{
    public partial class PanelCateBoxHoptac1 : System.Web.UI.UserControl
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

        [Description("Category Link")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryLink
        {
            get
            {
                return
                  Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.CategoryLink])
                    ? string.Empty
                    : ViewState[WebsitesConstants.ViewState.CategoryLink].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.CategoryLink] = value; }
        }

        [Description("Item Link")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string ItemLink
        {
            get
            {
                return
                  Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.ItemLink])
                    ? string.Empty
                    : ViewState[WebsitesConstants.ViewState.ItemLink].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.ItemLink] = value; }
        }

        public string categoryUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
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

                //Get Article
                WebsitesHelper helperArticles = new WebsitesHelper(new WebsitesObject());
                helperArticles.ValueObject.PartitionId = partitionId;
                helperArticles.ValueObject.CategoryId = categoryId;
                helperArticles.ValueObject.FirstIndexRecord = 1;
                helperArticles.ValueObject.LastIndexRecord = 1;
                DataTable dtArticles = helperArticles.GetCategoryArticles();
                rptTop.DataSource = dtArticles;
                rptTop.DataBind();
            }
        }
    }
}