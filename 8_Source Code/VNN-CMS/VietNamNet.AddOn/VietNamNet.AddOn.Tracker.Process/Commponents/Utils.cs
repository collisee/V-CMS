/************************************************************************/
/* File Name  : Constants.cs                                            */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai báo Utils của Tracker                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 17/09/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using VietNamNet.AddOn.Tracker.Process.Commponents;

namespace VietNamNet.AddOn.Tracker.Components
{
    public class Utils
    {
        public static string GetInfoFromLog(LogEntry log, string itemName )
        {
            return GetInfoFromLog(log,itemName,"=");
        }
        public static string GetInfoFromLog(LogEntry log, string itemName, string separator)
        {
            string s = "";
            s = log.Message.Substring(log.Message.IndexOf("<" + itemName + separator)).Substring(log.Message.Substring(log.Message.IndexOf("<" + itemName + separator)).IndexOf(":") + 1, log.Message.Substring(log.Message.IndexOf("<" + itemName + separator)).IndexOf(">") - (log.Message.Substring(log.Message.IndexOf("<" + itemName + separator)).IndexOf(":") + 1)); // phân tích Name
            if (s.LastIndexOf(separator)>=0) s = s.Substring(s.LastIndexOf(separator));
            s = s.Replace(separator, "") ;
            return s;
        }
        public static bool IsInfoInLog(LogEntry log, string itemName )
        {
            return log.Message.IndexOf("<" + itemName )>=0;
        }

    }
}
