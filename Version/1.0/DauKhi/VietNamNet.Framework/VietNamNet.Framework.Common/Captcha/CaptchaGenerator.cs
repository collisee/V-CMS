using System;
using System.Configuration;
using System.Web;
using VietNamNet.Framework.Common.Cryptography;

namespace VietNamNet.Framework.Common.Captcha
{
    public class CaptchaGenerator
    {
        public static string Generate()
        {
            return Generate(200, 75, "ffffff");
        }

        public static string Generate(int width, int height)
        {
            return Generate(width, height, "ffffff");
        }

        public static string Generate(int width, int height, string bgColor)
        {
            // Set image
            string s = RandomText.Generate();

            // Encrypt
            string key = Utilities.GetConfigKey("CaptchaKey");
            string salt = Utilities.GetConfigKey("CaptchaSalt");

            string ens = Encryptor.Encrypt(s, key, Convert.FromBase64String(salt));

            // Save to session
            HttpContext.Current.Session["CaptchaText"] = ens;

            // Set url
            return string.Format("~/Captcha.ashx?w={0}&h={1}&bc={2}", width, height, bgColor);
        }

        public static bool IsValidText(string text)
        {
            if (!Nulls.IsNullOrEmpty(HttpContext.Current.Session["CaptchaText"]))
            {
                string s = string.Empty;
                string enc = HttpContext.Current.Session["CaptchaText"].ToString();
                // space was replaced with + to prevent error
                enc = enc.Replace(" ", "+");
                string key = ConfigurationManager.AppSettings["CaptchaKey"];
                string salt = ConfigurationManager.AppSettings["CaptchaSalt"];
                try
                {
                    if (key == null) key = string.Empty;
                    if (salt == null) salt = string.Empty;
                    s = Encryptor.Decrypt(enc, key, Convert.FromBase64String(salt));
                    return Utilities.StringCompare(s, text);
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}