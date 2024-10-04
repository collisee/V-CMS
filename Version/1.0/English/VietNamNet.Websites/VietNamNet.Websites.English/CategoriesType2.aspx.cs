using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.English
{
  public partial class CategoriesType2 : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];

        //PanelCateLatestNews1.CategoryAlias = categoryAlias;
        //PanelCateTopStory1.CategoryAlias = categoryAlias;
        //PanelCateReadOn1.CategoryAlias = categoryAlias;
        //PanelInFocus1.CategoryAlias = categoryAlias;
        //PanelCateHotNews1.CategoryAlias = categoryAlias;
        //PanelCateTopNews1.CategoryAlias = categoryAlias;


        int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
        //PanelCateContent1.PageNumber = pageNumber;
        //PanelCateContent1.CategoryAlias = categoryAlias;
        //PanelCateReadOn1.PageNumber = pageNumber;

        PanelAdvertisement1.CategoryAlias = categoryAlias;
      }
    }
  }
}