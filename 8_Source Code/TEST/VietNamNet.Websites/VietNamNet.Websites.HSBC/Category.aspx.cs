using System;
using System.Web.UI;
using VietNamNet.Websites.HSBC.Common;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.HSBC
{
    public partial class Category : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pageNumber = Utilities.ParseInt(Request.Params[HSBCConstants.ParameterName.PAGE]);
                string categoryAlias = Request.Params[HSBCConstants.ParameterName.CATEGORY_ALIAS];

                PanelCategory1.CategoryAlias = categoryAlias;
                PanelCategory1.PageNumber = pageNumber;
            }
        }
    }
}