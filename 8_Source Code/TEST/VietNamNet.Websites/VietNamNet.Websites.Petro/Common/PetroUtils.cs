using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.Petro.Common
{
  public class PetroUtils
  {
    public static string BuildLink(string title)
    {
      return Utilities.ConvertToHTMLLink(title);
    }

  }
}