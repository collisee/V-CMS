using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Layout.Mobile.Common;
using VietNamNet.Layout.Mobile.Common.ValueObject;
using VietNamNet.Layout.Mobile.Presentation;

namespace VietNamNet.Layout.Mobile.UserControls
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
                    Nulls.IsNullOrEmpty(ViewState[VNN4MobileConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[VNN4MobileConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[VNN4MobileConstants.ViewState.CategoryAlias] = value; }
        }

        [Description("FirstIndexRecord")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int FirstIndexRecord
        {
            get { return Utilities.ParseInt(ViewState[VNN4MobileConstants.ViewState.FirstIndexRecord]); }
            set { ViewState[VNN4MobileConstants.ViewState.FirstIndexRecord] = value; }
        }

        [Description("LastIndexRecord")]
        [Browsable(true)]
        [DefaultSettingValue("5")]
        public int LastIndexRecord
        {
            get { return Utilities.ParseInt(ViewState[VNN4MobileConstants.ViewState.LastIndexRecord]); }
            set { ViewState[VNN4MobileConstants.ViewState.LastIndexRecord] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VNN4MobileHelper helper = new VNN4MobileHelper(new VNN4MobileObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.GetCategoryByAlias();
                if (dt != null && dt.Rows.Count == 1)
                {
                    lnkCategory.Text = dt.Rows[0][VNN4MobileConstants.Entity.VNN4MobileObject.FieldName.CategoryDisplayName].ToString();
                    lnkCategory.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

                    int categoryId = Utilities.ParseInt(dt.Rows[0][VNN4MobileConstants.Entity.VNN4MobileObject.FieldName.CategoryId]);
                    int partitionId = Utilities.ParseInt(dt.Rows[0][VNN4MobileConstants.Entity.VNN4MobileObject.FieldName.PartitionId]);

                    //Get Article
                    VNN4MobileHelper helperArticles = new VNN4MobileHelper(new VNN4MobileObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = FirstIndexRecord;
                    helperArticles.ValueObject.LastIndexRecord = LastIndexRecord;
                    rptCategory.DataSource = helperArticles.GetCategoryArticles();
                    rptCategory.DataBind();
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }
}