using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.V1.UserControls.Homepage
{
    public partial class PanelCategory : UserControl
    {
        public string categoryUrl = string.Empty;

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

        [Description("Sub Category Name")]
        [Browsable(true)]
        [DefaultSettingValue(null)]
        public string SubCategoryName
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SubCategoryName])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.SubCategoryName].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.SubCategoryName] = value; }
        }

        [Description("Sub Category Link")]
        [Browsable(true)]
        [DefaultSettingValue(null)]
        public string SubCategoryLink
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SubCategoryLink])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.SubCategoryLink].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.SubCategoryLink] = value; }
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
            //set subcate
            string[] strSubCateNames =
                SubCategoryName.Split(new char[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);
            string[] strSubCateLinks =
                SubCategoryLink.Split(new char[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strSubCateNames.Length; i++)
            {
                try
                {
                    HyperLink link = (HyperLink) FindControl("cattitle_sub" + i.ToString());
                    if (link != null)
                    {
                        if (i < strSubCateLinks.Length)
                        {
                            link.Text = strSubCateNames[i];
                            link.NavigateUrl = strSubCateLinks[i];
                            link.Visible = true;
                        }
                    }
                }
                catch
                {
                }
            }

            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.CategoryAlias = CategoryAlias;
            DataTable dt = helper.GetCategoryByAlias();

            if (dt != null && dt.Rows.Count > 0)
            {
                int categoryId =
                    Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                int partitionId =
                    Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);
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
                helperArticles.ValueObject.LastIndexRecord = 6;
                DataTable dtArticles = helperArticles.GetCategoryArticles();

                if (dtArticles != null && dt.Rows.Count > 0)
                {
                    if (dtArticles.Rows.Count > 0) //top 1
                    {
                        DataTable dtArticles1 = dtArticles.Copy();
                        while (dtArticles1.Rows.Count > 1) dtArticles1.Rows.RemoveAt(1);

                        rptTop.DataSource = dtArticles1;
                        rptTop.DataBind();
                    }

                    if (dtArticles.Rows.Count > 1) // top 2
                    {
                        DataTable dtArticles3 = dtArticles.Copy();
                        dtArticles3.Rows.RemoveAt(0); //remove 1
                        while (dtArticles3.Rows.Count > 1) dtArticles3.Rows.RemoveAt(1);

                        rptTop3.DataSource = dtArticles3;
                        rptTop3.DataBind();
                    }

                    if (dtArticles.Rows.Count > 3) // top 3 - 4
                    {
                        DataTable dtArticles4 = dtArticles.Copy();
                        dtArticles4.Rows.RemoveAt(0); //remove 1
                        dtArticles4.Rows.RemoveAt(0); //remove 2
                        while (dtArticles4.Rows.Count > 2) dtArticles4.Rows.RemoveAt(2);

                        rptTop3_1.DataSource = dtArticles4;
                        rptTop3_1.DataBind();
                    }

                    if (dtArticles.Rows.Count > 5) // top 5 - 6
                    {
                        DataTable dtArticles2 = dtArticles.Copy();
                        dtArticles2.Rows.RemoveAt(0); //remove 1
                        dtArticles2.Rows.RemoveAt(0); //remove 2
                        dtArticles2.Rows.RemoveAt(0); //remove 3
                        dtArticles2.Rows.RemoveAt(0); //remove 4
                        while (dtArticles2.Rows.Count > 2) dtArticles2.Rows.RemoveAt(2);

                        rptTop2.DataSource = dtArticles2;
                        rptTop2.DataBind();
                    }
                }
            }
        }
    }
}