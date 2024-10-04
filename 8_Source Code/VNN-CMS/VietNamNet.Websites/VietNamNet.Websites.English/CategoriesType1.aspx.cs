using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.English
{
  public partial class CategoriesType1 : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string categoryAlias = Request.Params[WebsitesConstants.ParameterName.CATEGORY_ALIAS];

        switch (categoryAlias)
        {
          case "special-report" :
            PanelCateTopStory1.Visible = false;
            break;
          case "vietnam-in-photos":
            PanelCateTopStory2.Visible = false;
            break;
          case "what-on":
            PanelCateTopStory3.Visible = false;
            break;
        }

        //PanelCateLatestNews1.CategoryAlias = categoryAlias;
        //PanelCateTopStory1.CategoryAlias = categoryAlias;
        PanelCateReadOn1.CategoryAlias = categoryAlias;
        //PanelInFocus1.CategoryAlias = categoryAlias;
        //PanelCateHotNews1.CategoryAlias = categoryAlias;
        PanelCateTopNews1.CategoryAlias = categoryAlias;

        int pageNumber = Utilities.ParseInt(Request.Params[WebsitesConstants.ParameterName.PAGE]);
        PanelCateContent1.PageNumber = pageNumber;
        PanelCateContent1.CategoryAlias = categoryAlias;
        PanelCateContent1.cateType = 1;
        PanelCateReadOn1.PageNumber = pageNumber;
        PanelCateReadOn1.cateType = 1;

        PanelAdvertisement1.CategoryAlias = categoryAlias;
      }
    }
  }
}