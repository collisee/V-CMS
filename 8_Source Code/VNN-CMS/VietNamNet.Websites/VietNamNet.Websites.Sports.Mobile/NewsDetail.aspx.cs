using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sports.Mobile
{
    public partial class NewsDetail : Page
    {
        public int docId = 0;
        public string categoryAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.CategoryAlias = categoryAlias;
                DataTable dt = helper.GetCategoryByAlias();
                if (dt != null && dt.Rows.Count == 1)
                {
                    lnkCategory.Text =
                        dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryDisplayName].ToString();
                    lnkCategory.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);
                }

                PanelNewsDetail1.ArticleId = docId;

                PanelNewsMore1.CategoryAlias = categoryAlias;
                PanelNewsMore1.ArticleId = docId;
            }
        }
    }
}