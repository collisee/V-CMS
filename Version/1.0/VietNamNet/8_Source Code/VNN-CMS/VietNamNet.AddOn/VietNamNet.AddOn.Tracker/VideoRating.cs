using System.IO;
using System.Text;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Tracking;

namespace VietNamNet.AddOn.Tracker
{
    public class VideoRating : TrackingService
    {
        public override void Execute(TrackingPacket packet)
        {
            ArticleWriteFile(packet.Parameters[TrackingConstants.ParameterName.ServiceName],
                Utilities.ParseInt(packet.Parameters[Constants.ParameterName.DOC_ID]),
                Utilities.ParseInt(packet.Parameters["p"]),
                HttpContext.Current.Request.UserHostAddress,
                packet.Parameters[TrackingConstants.ParameterName.Domain],
                packet.Parameters[TrackingConstants.ParameterName.User],
                packet.Parameters[TrackingConstants.ParameterName.Visit]);
        }

        private void ArticleWriteFile(string servieName, int articleid, int point, string ip, string domain, string user, string visit)
        {
            string logFolder = TrackingUtils.GetTrackingFolder(servieName);
            string fileName = string.Format("{0}.log", Utilities.KeyGenerator());
            string filePath = string.Format("{0}/{1}", logFolder, fileName);

            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            //Create file
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("VietNamNet.Framework.Tracking.VideoRating");
            sb.AppendLine(HttpContext.Current.Request.QueryString.ToString());
            sb.AppendLine(domain);
            sb.AppendLine(user);
            sb.AppendLine(visit);
            sb.AppendLine(ip);
            sb.AppendLine(articleid.ToString());
            sb.AppendLine(point.ToString());

            TextWriter tw = new StreamWriter(filePath);
            tw.Write(sb.ToString());
            tw.Close();
        }
    }
}