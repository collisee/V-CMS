using System;
using System.Web.UI;
using VietNamNet.Layout.Mobile.Common.ValueObject;
using VietNamNet.Layout.Mobile.Presentation;

namespace VietNamNet.Layout.Mobile.UserControls
{
    public partial class PanelTopNews : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get Article
                VNN4MobileHelper helperArticles = new VNN4MobileHelper(new VNN4MobileObject());
                rptCategory.DataSource = helperArticles.GetTopArticle();
                rptCategory.DataBind();
            }
        }
    }
}