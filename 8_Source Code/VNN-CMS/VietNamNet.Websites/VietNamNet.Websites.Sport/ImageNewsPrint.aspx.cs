using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sport
{
    public partial class ImageNewsPrint : System.Web.UI.Page
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

                    PanelSlideImagePrint1.ArticleId = docId;
                    
                    
                }
            }
     }
    
    
}
