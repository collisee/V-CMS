using System;
using System.Web.UI;

namespace VietNamNet.Websites.Sport.UserControls
{
  public partial class PanelFooter : UserControl
  {
    public string KeyWords = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      // Search KeyWords
      if (Request.QueryString["keyword"] != null)
      {
        KeyWords = Request.QueryString["keyword"].ToString();
      }
    }
  }
}