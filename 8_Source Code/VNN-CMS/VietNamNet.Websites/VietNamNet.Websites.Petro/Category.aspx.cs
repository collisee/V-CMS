using System;
using System.Web.UI;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.Petro
{
    public partial class Category : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
          {
            int pageNumber = Utilities.ParseInt(Request.Params[PetroConstants.ParameterName.PAGE]);
            string categoryAlias = Request.Params[PetroConstants.ParameterName.CATEGORY_ALIAS];

            PanelCategory1.CategoryAlias = categoryAlias;
            PanelCategory1.PageNumber = pageNumber;
          }
        }
    }
}