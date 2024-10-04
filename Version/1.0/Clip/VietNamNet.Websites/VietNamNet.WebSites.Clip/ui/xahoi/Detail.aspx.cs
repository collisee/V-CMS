using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Clip.ui.xahoi
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
                int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);
                if (Nulls.IsNullOrEmpty(categoryAlias))
                {
                    categoryAlias = "xa-hoi";
                }

                PanelCateTicker1.CategoryAlias = categoryAlias;

                PanelNewsDetail1.ArticleId = docId;

                PanelNewsFeedback1.ArticleId = docId;
                PanelNewsFeedback1.CategoryAlias = categoryAlias;

                PanelOtherNews1.ArticleId = docId;
                PanelOtherNews1.CategoryAlias = categoryAlias;

                PanelContentPoll1.ArticleId = docId;
                PanelContentPoll1.CategoryAlias = categoryAlias;

                PanelAdvertisement1.CategoryAlias = categoryAlias;
            }
        }
    }
}
