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

namespace VietNamNet.Websites.Clip.UserControls.News
{
  public partial class PanelContentRight : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];

            PanelCatePoll1.CategoryAlias = categoryAlias;
        }
    }
  }
}