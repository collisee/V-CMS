using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Sports.Mobile.UserControls
{
    public partial class PanelNewsDetail : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
            set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.ArticleId = ArticleId;
                rptNewsDetail.DataSource = helper.GetArticle();
                rptNewsDetail.DataBind();
            }
        }
    }
}