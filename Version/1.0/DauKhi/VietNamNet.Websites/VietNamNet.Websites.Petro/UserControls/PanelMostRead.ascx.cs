using System;
using System.Web.UI;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.UserControls
{
    public partial class PanelMostRead : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Articles
            PetroHelper helperArticles = new PetroHelper(new PetroObject());
            helperArticles.ValueObject.FirstIndexRecord = 1;
            helperArticles.ValueObject.LastIndexRecord = 7;
            rptMostRead.DataSource = helperArticles.GetMostReadArticles();
            rptMostRead.DataBind();
        }
    }
}