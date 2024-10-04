using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.English.UserControls.News
{
    public partial class PanelContentListFeedback : System.Web.UI.UserControl
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
            //Registe poll js
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("feedback.js"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "feedback.js",
                             "<script src=\"" + Page.ResolveUrl("/Scripts/feedback.js") + "\"></script>");
            }
        }
    }
}