using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Layout.Mobile.Common.ValueObject;
using VietNamNet.Layout.Mobile.Presentation;

namespace VietNamNet.Layout.Mobile.V1.UserControls
{
    public partial class PanelTopNews : UserControl
    {
        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Get Article
                VNN4MobileHelper helperArticles = new VNN4MobileHelper(new VNN4MobileObject());
                DataTable dt = helperArticles.GetTopArticle();

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable dt1 = dt.Copy();
                    while (dt1.Rows.Count > 1) dt1.Rows.RemoveAt(1);
                    rptCategoryImg.DataSource = dt1;
                    rptCategoryImg.DataBind();

                    //remove row 0
                    dt.Rows.RemoveAt(0);
                    rptCategory.DataSource = dt;
                    rptCategory.DataBind();
                }
                else
                {
                    this.Visible = false;
                }
            }
        }

        #endregion
    }
}