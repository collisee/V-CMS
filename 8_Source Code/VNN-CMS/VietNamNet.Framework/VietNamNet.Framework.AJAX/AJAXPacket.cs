using System.Collections.Specialized;

namespace VietNamNet.Framework.AJAX
{
    public class AJAXPacket
    {
        private string action;
        private NameValueCollection parameters;
        private string serviceName;
        private AJAXStatus status;
        private AJAXType type;
        private object value;

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

        public AJAXType Type
        {
            get { return type; }
            set { type = value; }
        }

        public AJAXStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}