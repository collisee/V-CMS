using System;
using System.Web.UI;

namespace VietNamNet.AddOn.Union
{
  public partial class NewsMedia : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Control ctrNewsVideo = LoadControl("/UserControls/News/PanelNewsVideo.ascx");
      PlaceHolder1.Controls.Add(ctrNewsVideo);
    }
  }
}
