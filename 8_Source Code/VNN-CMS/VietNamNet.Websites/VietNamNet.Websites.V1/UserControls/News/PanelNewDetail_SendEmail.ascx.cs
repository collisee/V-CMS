using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.V1.UserControls.News
{
    public partial class PanelNewDetail_SendEmail : UserControl
    {
        [Description("SendEmailId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int SendEmailId
        {
            get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.SendMail.SendEmailId]); }
            set { ViewState[WebsitesConstants.ViewState.SendMail.SendEmailId] = value; }
        }

        [Description("Subject")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string Subject
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SendMail.Subject])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.SendMail.Subject].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.SendMail.Subject] = value; }
        }

        [Description("Messages")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string Messages
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SendMail.Messages])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.SendMail.Messages].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.SendMail.Messages] = value; }
        }

        [Description("Url")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string Url
        {
            get
            {
                return
                    Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.SendMail.Url])
                        ? string.Empty
                        : ViewState[WebsitesConstants.ViewState.SendMail.Url].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.SendMail.Url] = value; }
        }
          
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}