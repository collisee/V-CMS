using System.IO;
using System.Text;
using System.Web;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Tracking
{
    public class TrackingServiceDefault : TrackingService
    {
        public override void Execute(TrackingPacket packet)
        {
            string defaultFolder = TrackingUtils.GetTrackingFolder();
            string fileName = string.Format("{0}.log", Utilities.KeyGenerator());
            string filePath = string.Format("{0}/{1}", defaultFolder, fileName);

            if (!Directory.Exists(defaultFolder))
            {
                Directory.CreateDirectory(defaultFolder);
            }

            //Create file
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("VietNamNet.Framework.Tracking");
            sb.AppendLine(packet.ServiceName);
            sb.AppendLine(packet.Action);
            //sb.AppendLine(packet.Parameters.ToString());
            sb.AppendLine(HttpContext.Current.Request.QueryString.ToString());

            TextWriter tw = new StreamWriter(filePath);
            tw.Write(sb.ToString());
            tw.Close();
        }
    }
}