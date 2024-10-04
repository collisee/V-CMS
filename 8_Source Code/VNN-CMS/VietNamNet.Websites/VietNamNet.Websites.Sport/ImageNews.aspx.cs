using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sport
{
    public partial class ImageNews : System.Web.UI.Page
    {
        public string categoryAlias;
        public int docId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);

                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    Response.Redirect(WebsitesUtils.GetHomepage());
                }

                PanelSlideImagePath1.CategoryAlias = categoryAlias;
                PanelSlideImageContent1.ArticleId = docId;
                PanelSlideImageList1.CategoryAlias = categoryAlias;
                PanelSlideImageList1.ArticleId = docId;
            }
        }
    }
}
