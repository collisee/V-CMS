using System;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Union
{
  public partial class Forums : BasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      PageLoad();
      if (!isLogged)
      {
        Response.Redirect("~/");
      }
    }
  }
}
