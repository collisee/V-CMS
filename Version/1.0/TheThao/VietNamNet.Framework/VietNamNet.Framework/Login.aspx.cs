using System;
using VietNamNet.Framework.System;

namespace VietNamNet.Framework
{
    public partial class Login : BasePage
    {
        private const string SecureProtocolPrefix = "https://";
        private const string UnsecureProtocolPrefix = "http://";

        protected void Page_Load(object sender, EventArgs e)
        {
            //string loginLink = Request.Url.AbsoluteUri;
            //if (loginLink.StartsWith(UnsecureProtocolPrefix))
            //{
            //    loginLink = loginLink.Replace(UnsecureProtocolPrefix, SecureProtocolPrefix);
            //    Response.Redirect(loginLink);
            //}
        }
    }
}