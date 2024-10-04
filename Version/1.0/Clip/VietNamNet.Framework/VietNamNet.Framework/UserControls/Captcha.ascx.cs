using System;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.Captcha;
using VietNamNet.Framework.Common.Cryptography;

namespace VietNamNet.Framework.UserControls
{
    public partial class Captcha : UserControl
    {
        private string color = "#ffffff";
        protected string style;

        public string BackgroundColor
        {
            set { color = value.Trim("#".ToCharArray()); }
            get { return color; }
        }

        public string Style
        {
            set { style = value; }
            get { return style; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCaptcha();
                txtCaptcha.Text = "";

                this.Visible =
                    Utilities.StringCompare(Utilities.GetConfigKey(Constants.ConfigKey.Captcha),
                                            Constants.Security.ON.ToString());
            }
        }

        private void SetCaptcha()
        {
            // Set url
            imgCaptcha.ImageUrl = CaptchaGenerator.Generate();
        }

        public bool OnSuccess()
        {
            if (Utilities.StringCompare(Utilities.GetConfigKey(Constants.ConfigKey.Captcha), Constants.Security.ON.ToString()))
            {
                if (CaptchaGenerator.IsValidText(txtCaptcha.Text))
                {
                    return true;
                }
                else
                {
                    //onFailure Restart
                    txtCaptcha.Text = "";
                    SetCaptcha();
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}