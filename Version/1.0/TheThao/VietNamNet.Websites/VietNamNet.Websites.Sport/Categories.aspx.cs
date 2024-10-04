using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport
{
    public partial class Categories : Page
    {
        public string categoryAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    Response.Redirect(WebsitesUtils.GetHomepage());
                }

                PanelTop1.CategoryAlias = categoryAlias;
                PanelCateContent1.CategoryAlias = categoryAlias;
                //PanelOtherNews1.CategoryAlias = categoryAlias;

                int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                PanelCateContent1.PageNumber = pageNumber;
                //PanelOtherNews1.PageNumber = pageNumber;

                PanelSurvey1.CategoryAlias = categoryAlias;
            }
        }
    }
}