using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.WebSites.Clip
{
  public partial class Category : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
        PanelCategoryPlaylist1.CategoryAlias = categoryAlias;
        PanelCate3gContent1.CategoryAlias = categoryAlias;
        //PanelClipNoibat1.CategoryAlias = categoryAlias;
        //PanelTamdiem3g1.CategoryAlias = categoryAlias;
        //PanelCateBox1_2.CategoryAlias = categoryAlias;
        PanelAdvertisement1.CategoryAlias = categoryAlias;

        int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
        PanelCate3gContent1.PageNumber = pageNumber;
      }
    }
  }
}