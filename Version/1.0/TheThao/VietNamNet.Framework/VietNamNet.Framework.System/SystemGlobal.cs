using System;
using System.Web;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.System
{
    public class SystemGlobal : HttpApplication
    {
        protected void Application_OnStart(object sender, EventArgs e)
        {
            Application[Constants.Session.USERS_ONLINE] = 0;
            Application[Constants.Session.USERS_VISIT] = Utilities.ParseInt(SystemUtils.GetConfiguration(Constants.Session.USERS_VISIT));

            SystemLogging.Log((int)Constants.LogLevel.System, string.Empty, 0, string.Empty, "Application Start!", DateTime.Now, string.Empty);
        }

        protected void Application_OnEnd(object sender, EventArgs e)
        {
            Application.Lock();
            SystemUtils.SetConfiguration(Constants.Session.USERS_VISIT, Application[Constants.Session.USERS_VISIT]);
            Application.UnLock();

            SystemLogging.Log((int)Constants.LogLevel.System, string.Empty, 0, string.Empty, "Application End!", DateTime.Now, string.Empty);
        }

        protected void Session_OnStart()
        {
            Application.Lock();
            Application[Constants.Session.USERS_ONLINE] = (Application[Constants.Session.USERS_ONLINE] == null)
                                                              ? 1
                                                              : (int) Application[Constants.Session.USERS_ONLINE] + 1;
            Application[Constants.Session.USERS_VISIT] = (Application[Constants.Session.USERS_VISIT] == null)
                                                             ? 1
                                                             : (int) Application[Constants.Session.USERS_VISIT] + 1;
            Application.UnLock();
        }

        protected void Session_OnEnd()
        {
            Application.Lock();
            Application[Constants.Session.USERS_ONLINE] = (Application[Constants.Session.USERS_ONLINE] == null)
                                                              ? 0
                                                              : (int) Application[Constants.Session.USERS_ONLINE] - 1;
            Application.UnLock();

            //Log
            //int uid = Utilities.ParseInt(HttpContext.Current.Session[Constants.Session.USER_ID]);
            //if (uid > 0) SystemLogging.System("Logout!", "End Session!!!");
        }
     
    }
}