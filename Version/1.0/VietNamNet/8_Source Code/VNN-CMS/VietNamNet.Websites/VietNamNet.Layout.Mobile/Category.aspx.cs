using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Layout.Mobile.Common;

namespace VietNamNet.Layout.Mobile
{
    public partial class Category : Page
    {
        public int pageNumber = 1;
        public string categoryAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageNumber = Utilities.ParseInt(Request.Params[VNN4MobileConstants.ParameterName.PAGE]);
                categoryAlias = Request.Params[VNN4MobileConstants.ParameterName.CATEGORY_ALIAS];
                
                int pageSize = Utilities.GetPageSize();
                if (pageNumber <= 0) pageNumber = 1;

                PanelCategory1.CategoryAlias = categoryAlias;
                PanelCategory1.FirstIndexRecord = (pageNumber - 1) * pageSize + 1; ;
                PanelCategory1.LastIndexRecord = pageNumber * pageSize;
            }
        }
    }
}