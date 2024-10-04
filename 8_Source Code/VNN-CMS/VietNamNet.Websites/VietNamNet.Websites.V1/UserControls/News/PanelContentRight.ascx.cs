using System;
using System.Web.UI;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls.News
{
    public partial class PanelContentRight : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
            }
        }
    }
}