using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls.News
{
    public partial class PanelContentListFeedback : UserControl
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
                SetupEnvironment();
            }
        }

        private void SetupEnvironment()
        {
            ////Registe poll js
            //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("feedback.js"))
            //{
            //    this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "feedback.js",
            //                 "<script src=\"" + Page.ResolveUrl("/js/feedback.js") + "\"></script>");
            //}
        }
    }
}