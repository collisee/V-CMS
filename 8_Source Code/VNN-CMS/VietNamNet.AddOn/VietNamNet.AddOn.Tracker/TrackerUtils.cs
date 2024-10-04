using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Tracking;

namespace VietNamNet.AddOn.Tracker
{
    public class TrackerUtils
    {
        public static string GetNewClientUserId()
        {
            return Utilities.KeyGenerator();
        }

        public static void WriteFile(NameValueCollection parameters)
        {
            string logFolder = TrackingUtils.GetTrackingFolder(parameters[TrackingConstants.ParameterName.ServiceName]);
            string fileName = string.Format("{0}.log", Utilities.KeyGenerator());
            string filePath = string.Format("{0}/{1}", logFolder, fileName);

            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            //Create file
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("VietNamNet.Framework.Tracking");

            foreach (string key in parameters.Keys)
            {
                sb.AppendLine(key);
                sb.AppendLine(parameters[key]);
            }

            TextWriter tw = new StreamWriter(filePath);
            tw.Write(sb.ToString());
            tw.Close();
        }
    }
}