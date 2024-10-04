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
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport.UserControls.Categories
{
    public partial class PanelCateName : System.Web.UI.UserControl
    {
        public string strCateName;
        protected void Page_Load(object sender, EventArgs e)
        {
            strCateName = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
        }
    }
}