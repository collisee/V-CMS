using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sports.Mobile
{
    public partial class Categories : Page
    {
        #region Member

        public string categoryAlias = string.Empty;
        public int pageNumber = 1;

        #endregion

        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
                categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];

                int pageSize = Utilities.GetPageSize();
                if (pageNumber <= 0) pageNumber = 1;

                PanelCategory1.CategoryAlias = categoryAlias;
                PanelCategory1.FirstIndexRecord = (pageNumber - 1)*pageSize + 1;
                PanelCategory1.LastIndexRecord = pageNumber*pageSize;
            }
        }

        #endregion
    }
}