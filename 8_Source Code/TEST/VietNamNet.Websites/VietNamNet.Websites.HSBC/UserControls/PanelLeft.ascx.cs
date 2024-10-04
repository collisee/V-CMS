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
    public partial class PanelLeft : UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HSBCHelper helper = new HSBCHelper(new HSBCObject());
                helper.ValueObject.CategoryAlias = CategoryAlias;
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][HSBCConstants.Entity.HSBCObject.FieldName.PartitionId]);

                    //Get Article
                    HSBCHelper helperArticles = new HSBCHelper(new HSBCObject());
                    helperArticles.ValueObject.PartitionId = partitionId;
                    helperArticles.ValueObject.CategoryId = categoryId;
                    helperArticles.ValueObject.FirstIndexRecord = 1;
                    helperArticles.ValueObject.LastIndexRecord = 2;
                    rptMore.DataSource = helperArticles.GetCategoryArticles();
                    rptMore.DataBind();
                }
            }
        }
    }
}