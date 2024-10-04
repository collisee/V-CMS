using System;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.System
{
    public class SystemLogging
    {
        #region Log

        public static void Log(int logLevel, string ip, int uid, string userName, string action, DateTime timeLog, string detail)
        {
            int level = Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.LogLevel));
            if (level > logLevel) return;

            LoggingHelper logger = new LoggingHelper(new Logging());
            logger.ValueObject.Id = 0;
            logger.ValueObject.LogTime = timeLog;
            logger.ValueObject.LogLevel = logLevel;
            logger.ValueObject.IP = ip;
            logger.ValueObject.UId = uid;
            logger.ValueObject.UserFullName = userName;
            logger.ValueObject.Action = action;
            logger.ValueObject.Detail = detail;
            logger.ValueObject.Created_At = DateTime.Now;
            logger.ValueObject.Created_By = 0;
            logger.ValueObject.Last_Modified_At = DateTime.Now;
            logger.ValueObject.Last_Modified_By = 0;

            logger.DoSave();
        }

        public static void Log(int logLevel, string action, string detail)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            int uid = Utilities.ParseInt(HttpContext.Current.Session[Constants.Session.USER_ID]);
            string userName = Nulls.IsNullOrEmpty(HttpContext.Current.Session[Constants.Session.USER_FULLNAME])
                                  ? string.Empty
                                  : HttpUtility.HtmlDecode(
                                        HttpContext.Current.Session[Constants.Session.USER_FULLNAME].ToString());
            Log(logLevel, ip, uid, userName, action, DateTime.Now, detail);
        }

        public static void Log(int logLevel, string action)
        {
            Log(logLevel, action, null);
        }

        #endregion

        #region Info

        public static void Info(string action)
        {
            Log((int)Constants.LogLevel.Info, action);
        }

        public static void Info(string action, string detail)
        {
            Log((int)Constants.LogLevel.Info, action, detail);
        }

        #endregion

        #region Error

        public static void Error(string action)
        {
            Log((int)Constants.LogLevel.Error, action);
        }

        public static void Error(string action, string detail)
        {
            Log((int)Constants.LogLevel.Error, action, detail);
        }

        #endregion

        #region System

        public static void System(string action)
        {
            Log((int)Constants.LogLevel.System, action);
        }

        public static void System(string action, string detail)
        {
            Log((int)Constants.LogLevel.System, action, detail);
        }

        #endregion
    }
}