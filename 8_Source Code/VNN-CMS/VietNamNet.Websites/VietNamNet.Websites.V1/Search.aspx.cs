using System;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1
{
  public partial class Search : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
     
        //PanelOtherNews1.CategoryAlias = categoryAlias;

        int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);

        //PanelOtherNews1.PageNumber = pageNumber; 
    }
  }
}
