using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Layout.Mobile.Common;
using VietNamNet.Layout.Mobile.Common.ValueObject;
using VietNamNet.Layout.Mobile.Presentation;

namespace VietNamNet.Layout.Mobile.V1
{
    public partial class News : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[VNN4MobileConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[VNN4MobileConstants.ParameterName.DOC_ID]);

                VNN4MobileHelper helper = new VNN4MobileHelper(new VNN4MobileObject());
                helper.ValueObject.CategoryAlias = categoryAlias;
                DataTable dt = helper.GetCategoryByAlias();
                if (dt != null && dt.Rows.Count == 1)
                {
                    lnkCategory.Text =
                        dt.Rows[0][VNN4MobileConstants.Entity.VNN4MobileObject.FieldName.CategoryDisplayName].ToString();
                    lnkCategory.NavigateUrl = string.Format("/vn/{0}/index.html", categoryAlias);
                }

                PanelNewsDetail1.ArticleId = docId;

                PanelNewsMore1.CategoryAlias = categoryAlias;
                PanelNewsMore1.ArticleId = docId;
            }
        }
    }
}