using System;
using System.Web.UI;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sport
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(WebsitesUtils.GetHomepage());
        }
    }
}