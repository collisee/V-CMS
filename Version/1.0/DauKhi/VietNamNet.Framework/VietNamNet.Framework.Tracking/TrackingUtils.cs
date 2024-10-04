using System;
using System.Web;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Tracking
{
    public class TrackingUtils
    {
        public static bool CheckServiceName(string serviceName)
        {
            if (Nulls.IsNullOrEmpty(serviceName)) return false;

            string[] services =
                Utilities.GetConfigKey(TrackingConstants.ConfigKey.AllowServices).Split(new char[] { ';', ',' },
                                                                                        StringSplitOptions.
                                                                                            RemoveEmptyEntries);
            foreach (string service in services)
            {
                if (Utilities.StringCompare(service, TrackingConstants.ServiceName.All) || Utilities.StringCompare(service, serviceName))
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetTrackingFolder(string serviceNamer)
        {
            if (Nulls.IsNullOrEmpty(serviceNamer)) return string.Empty;
            DateTime now = DateTime.Now;
            string trackingFolder = Utilities.GetConfigKey(TrackingConstants.ConfigKey.TrackingFolder);
            string folder = string.Format("~/{0}/{1}/{2}/{3}/{4}/{5}", trackingFolder, serviceNamer.ToLower(), now.Year, now.Month, now.Day, now.Hour);
            string physicalFolder = HttpContext.Current.Server.MapPath(folder);
            return physicalFolder;
        }

        public static string GetTrackingFolder()
        {
            return GetTrackingFolder(TrackingConstants.ServiceName.Default);
        }
    }
}