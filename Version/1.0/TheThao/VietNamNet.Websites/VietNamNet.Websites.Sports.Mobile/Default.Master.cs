using System;
using System.Web.UI;

namespace VietNamNet.Websites.Sports.Mobile
{
    public partial class Default : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserInterface"] = "";
            }
        }
    }
}