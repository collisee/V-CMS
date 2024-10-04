using System;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Captcha;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Sports.Mobile.UserControls
{
    public partial class PanelSendFeedBack : UserControl
    {
        [Description("ArticleId")]
        [Browsable(true)]
        [DefaultSettingValue("0")]
        public int ArticleId
        {
            get { return Utilities.ParseInt(ViewState[WebsitesConstants.ViewState.ArticleId]); }
            set { ViewState[WebsitesConstants.ViewState.ArticleId] = value; }
        }

        [Description("ArticleName")]
        [Browsable(true)]
        [DefaultSettingValue("")]
        public string ArticleName
        {
            get
            {
                return Nulls.IsNullOrEmpty(ViewState[WebsitesConstants.ViewState.ArticleName])
                           ? string.Empty
                           : ViewState[WebsitesConstants.ViewState.ArticleName].ToString();
            }
            set { ViewState[WebsitesConstants.ViewState.ArticleName] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblInfo.Visible = false;

            if (!IsPostBack)
            {
                hidArticleId.Value = ArticleId.ToString();
                hidArticleName.Value = ArticleName;

                if (!Nulls.IsNullOrEmpty(hidArticleName.Value))
                {
                    txtSubject.Text = ArticleName;
                    txtSubject.CssClass = "none";
                }

                genImage();
            }
        }

        private void genImage()
        {
            int width = Utilities.ParseInt(Utilities.GetConfigKey(WebsitesConstants.ConfigKey.ValidImageWidth));
            int height = Utilities.ParseInt(Utilities.GetConfigKey(WebsitesConstants.ConfigKey.ValidImageheight));
            imgValidCode.Width = Unit.Pixel(width);
            imgValidCode.Height = Unit.Pixel(height);
            imgValidCode.ImageUrl = CaptchaGenerator.Generate(width, height);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CaptchaGenerator.IsValidText(txtValidCode.Text))
            {
                EmailPacket email = new EmailPacket();
                email.Subject = hidEmailSubject.Value +
                                (Nulls.IsNullOrEmpty(hidArticleName.Value)
                                    ? HttpUtility.HtmlEncode(txtSubject.Text)
                                    : hidArticleName.Value);
                email.To = hidEmailTo.Value;
                email.Cc = hidEmailCC.Value;
                email.Bcc = hidEmailBCC.Value;
                email.Body = string.Format("Người gửi: {0}<br />" +
                                           "Email: {1}<br />" +
                                           "Nội dung: <br />{2}<br />",
                                           HttpUtility.HtmlEncode(txtName.Text), HttpUtility.HtmlEncode(txtEmail.Text), 
                                           HttpUtility.HtmlEncode(txtContent.Text));
                email.SendEmail();
                lblInfo.Visible = true;

                txtName.Text = "Họ tên";
                txtSubject.Text = "Tiêu đề";
                txtEmail.Text = "Email";
                txtValidCode.Text = "Mã bảo vệ";
                txtContent.Text = "Nội dung";

                if (!Nulls.IsNullOrEmpty(hidArticleName.Value))
                {
                    txtSubject.Text = ArticleName;
                    txtSubject.CssClass = "none";
                }

                genImage();
            }
            else
            {
                lblError.Visible = true;

                genImage();
            }
        }
    }
}