using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls.News
{
    public partial class PanelContentPoll : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
            set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
        }

        [Description("Category Alias")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string CategoryAlias
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.CategoryAlias])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.CategoryAlias].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.CategoryAlias] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void SetupEnvironment()
        {
            //Registe poll js
            if (!Page.ClientScript.IsClientScriptBlockRegistered("poll.js"))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "poll.js",
                                                            "<script src=\"" + Page.ResolveUrl("/js/poll.js") +
                                                            "\"></script>");
            }
        }
    }
}