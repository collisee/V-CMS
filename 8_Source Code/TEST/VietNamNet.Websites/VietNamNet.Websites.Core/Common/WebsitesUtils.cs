using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.Core.Common
{
  public class WebsitesUtils
  {
    public static string BuildLink(string title)
    {
      return Utilities.ConvertToHTMLLink(title);
    }

    public static string GetArticleIcon(int ArticleContentType)
    {
      switch (ArticleContentType)
      {
        case 2:
          return "photob";
        case 3:
          return "videob";
        case 4:
          return "audiob";
        default:
          return "";
      }
    }
  }
}