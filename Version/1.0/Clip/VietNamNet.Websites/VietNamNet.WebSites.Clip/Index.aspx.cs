using System;
using System.Web.UI;

namespace VietNamNet.Websites.Clip
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/vn/index.html");
        }
    }
}