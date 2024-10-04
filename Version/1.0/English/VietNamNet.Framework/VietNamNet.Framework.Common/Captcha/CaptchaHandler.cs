using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using VietNamNet.Framework.Common.Cryptography;

namespace VietNamNet.Framework.Common.Captcha
{
    public class CaptchaHandler : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.BufferOutput = false;

            // Get text
            string s = "No Text";
            string enc = string.Empty;
            if (!Nulls.IsNullOrEmpty(context.Request.QueryString["c"]))
            {
                enc = context.Request.QueryString["c"];
            }
            if (!Nulls.IsNullOrEmpty(context.Session["CaptchaText"]))
            {
                enc = context.Session["CaptchaText"].ToString();
            }

            if (!Nulls.IsNullOrEmpty(enc))
            {
                // space was replaced with + to prevent error
                enc = enc.Replace(" ", "+");
                string key = ConfigurationManager.AppSettings["CaptchaKey"];
                string salt = ConfigurationManager.AppSettings["CaptchaSalt"];
                try
                {
                    if (key == null) key = string.Empty;
                    if (salt == null) salt = string.Empty;
                    s = Encryptor.Decrypt(enc, key, Convert.FromBase64String(salt));
                }
                catch
                {
                    s = "No Text";
                }
            }
            // Get dimensions
            int w = Utilities.ParseInt(context.Request.QueryString["w"]);
            int h = Utilities.ParseInt(context.Request.QueryString["h"]);
            if (w <= 0) w = 120;
            if (h <= 0) h = 50;
            // Color
            Color Bc = Color.White;
            if (!Nulls.IsNullOrEmpty(context.Request.QueryString["bc"]))
            {
                try
                {
                    string bc = context.Request.QueryString["bc"].ToString().Insert(0, "#");
                    Bc = ColorTranslator.FromHtml(bc);
                }
                catch
                {
                    Bc = Color.White;
                }
            }
            // Generate image
            CaptchaImage ci = new CaptchaImage(s, Bc, w, h);

            // Return
            ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            // Dispose
            ci.Dispose();
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #endregion
    }
}