using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Layout.Mobile.Common;
using VietNamNet.Layout.Mobile.Common.ValueObject;
using VietNamNet.Layout.Mobile.Presentation;

namespace VietNamNet.Layout.Mobile.UserControls
{
    public partial class PanelNewsDetail : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[VNN4MobileConstants.ViewState.ArticleId]); }
            set { ViewState[VNN4MobileConstants.ViewState.ArticleId] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VNN4MobileHelper helper = new VNN4MobileHelper(new VNN4MobileObject());
                helper.ValueObject.ArticleId = ArticleId;
                rptNewsDetail.DataSource = helper.GetArticle();
                rptNewsDetail.DataBind();
            }
        }
    }
}