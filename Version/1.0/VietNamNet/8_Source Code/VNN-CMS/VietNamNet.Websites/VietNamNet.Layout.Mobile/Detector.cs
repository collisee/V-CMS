using System.Web;
using System.Web.SessionState;
using VietNamNet.Framework.Common;

namespace VietNamNet.Layout.Mobile
{
    public class Detector : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Browser.IsMobileDevice && Nulls.IsNullOrEmpty(context.Session["UserInterface"]))
            {
                string mobileDomain = Utilities.GetConfigKey("MobileDomain");
                string jsx = string.Format("window.location = '{0}'", mobileDomain);
                context.Response.Write(jsx);
                context.Response.Flush();
            }

            context.Response.Write(string.Format("//IsMobileDevice: {0}\r\n", context.Request.Browser.IsMobileDevice));
            context.Response.Write(string.Format("//Browser: {0}\r\n", context.Request.Browser.Browser));
            context.Response.Write(string.Format("//Platform: {0}\r\n", context.Request.Browser.Platform));
            context.Response.Write(string.Format("//ScreenWidth: {0}\r\n", context.Request.Browser.ScreenPixelsWidth));
            context.Response.Write(string.Format("//ScreenHeight: {0}\r\n", context.Request.Browser.ScreenPixelsHeight));
            context.Response.Write(string.Format("//SupportsCss: {0}\r\n", context.Request.Browser.SupportsCss));
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #endregion
    }
}