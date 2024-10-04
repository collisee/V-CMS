using System.Xml.Serialization;

namespace VietNamNet.Framework.Common.RSS
{
    [XmlRoot(ElementName = "rss", IsNullable = false)]
    public class RSS
    {
        private Channel channel;
        private string version;

        public RSS(string v, Channel c)
        {
            version = v;
            channel = c;
        }

        public RSS(Channel c)
        {
            version = "2.0";
            channel = c;
        }

        public RSS(string v)
        {
            version = v;
            channel = new Channel();
        }

        public RSS()
        {
            version = "2.0";
            channel = new Channel();
        }

        [XmlAttribute(AttributeName = "version")]
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        [XmlElement(ElementName = "channel", IsNullable = false)]
        public Channel Channel
        {
            get { return channel; }
            set { channel = value; }
        }
    }
}