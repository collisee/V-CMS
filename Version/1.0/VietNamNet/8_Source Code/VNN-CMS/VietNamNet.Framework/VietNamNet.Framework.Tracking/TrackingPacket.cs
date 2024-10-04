using System.Collections.Specialized;

namespace VietNamNet.Framework.Tracking
{
    public class TrackingPacket
    {
        private string action;
        private NameValueCollection parameters;
        private string serviceName;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public NameValueCollection Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }
    }
}