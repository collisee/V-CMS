using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.HSBC.Common
{
  public class HSBCUtils
  {
    public static string BuildLink(string title)
    {
      return Utilities.ConvertToHTMLLink(title);
    }

  }
}