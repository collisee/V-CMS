using System.Collections;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System
{
    public class SystemEmailFunction
    {
        public static bool SendNewPassword(User u, string newPassword)
        {
            if (Nulls.IsNullOrEmpty(newPassword)) return false;

            EmailPacket objEmail = new EmailPacket();

            objEmail.Subject = Utilities.GetConfigKey(SystemConstants.Message.EmailSubject.NewPassword);
            objEmail.To = u.Email;
            objEmail.EmailTemplate = HttpContext.Current.Server.MapPath(Constants.EmailTemplates.NewPassword);

            //Build mail
            Hashtable hst = new Hashtable();
            hst.Add("FullName", u.FullName);
            hst.Add("Password", newPassword);

            return objEmail.SendEmail(hst);
        }

        public static bool SendChangePassword(User u, string newPassword)
        {
            if (Nulls.IsNullOrEmpty(newPassword)) return false;

            EmailPacket objEmail = new EmailPacket();

            objEmail.Subject = Utilities.GetConfigKey(SystemConstants.Message.EmailSubject.ChangePassword);
            objEmail.To = u.Email;
            objEmail.EmailTemplate = HttpContext.Current.Server.MapPath(Constants.EmailTemplates.ChangePassword);

            //Mask new password
            if (newPassword.Length >= 3 && newPassword.Length < 5)
            {
                newPassword = newPassword.Substring(0, newPassword.Length - 3) + "***";
            }
            else
            {
                newPassword = newPassword.Substring(0, newPassword.Length - 5) + "*****";
            }

            //Build mail
            Hashtable hst = new Hashtable();
            hst.Add("FullName", u.FullName);
            hst.Add("Password", newPassword);

            return objEmail.SendEmail(hst);
        }
    }
}