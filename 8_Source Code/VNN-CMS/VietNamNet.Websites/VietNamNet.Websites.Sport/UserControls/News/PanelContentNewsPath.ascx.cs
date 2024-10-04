using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sport.UserControls.News
{
    public partial class PanelContentNewsPath : System.Web.UI.UserControl
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

        public string categoryUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
            helper.ValueObject.CategoryAlias = CategoryAlias;
            DataTable dt = helper.GetCategoryByAlias();

            rptCateTitle.DataSource = dt;
            rptCateTitle.DataBind();


            if (dt != null && dt.Rows.Count > 0)
            {
                string title =
                    dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryDisplayName].ToString().Replace
                        ("\"", string.Empty);
                Page.Title = string.Format("VietNamNet - {0} | {1}", title, Utilities.RemoveVietNamChar(title));


                categoryUrl = dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryUrl].ToString();
            }
         
        }
    }
}