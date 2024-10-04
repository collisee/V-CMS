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

namespace VietNamNet.Websites.Sport
{
  public partial class NewsDetailPrint : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
            int docId = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.DOC_ID]);
            
            PanelContentNewsPrint1.ArticleId = docId;
            PanelContentNewsPrint1.CategoryAlias = categoryAlias;


        }
    }
  }
}
