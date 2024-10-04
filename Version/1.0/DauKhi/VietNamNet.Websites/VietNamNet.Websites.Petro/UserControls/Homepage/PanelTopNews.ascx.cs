using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.UserControls.Homepage
{
    public partial class PanelTopNews : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get Articles
                PetroHelper helperArticles = new PetroHelper(new PetroObject());
                helperArticles.ValueObject.FirstIndexRecord = 1;
                helperArticles.ValueObject.LastIndexRecord = 3;
                rptTopNews.DataSource = helperArticles.GetTopArticles();
                rptTopNews.DataBind();
            }
        }
    }
}