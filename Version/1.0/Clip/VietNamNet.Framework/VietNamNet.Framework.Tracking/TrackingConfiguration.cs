using System.Configuration;
using System.Xml.Serialization;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Tracking
{
    [XmlRoot("TrackingConfiguration")]
    public class TrackingConfiguration
    {
        private TrackingServiceCollection serviceCollection;
        private string assembly;
        private string type;

        [XmlAttribute(AttributeName = "Assembly", DataType = "string")]
        public string Assembly
        {
            get { return assembly; }
            set { assembly = value; }
        }

        [XmlAttribute("Type")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [XmlElement("TrackingService")]
        public TrackingServiceCollection TrackingServices
        {
            get { return serviceCollection; }
            set { serviceCollection = value; }
        }

        private static TrackingConfiguration GetTracking(object[] param)
        {
            return (TrackingConfiguration)ConfigurationManager.GetSection("TrackingConfiguration");
        }

        public static TrackingConfiguration GetConfig()
        {
            CacheManager.SourceDataDelegate getConfig = new CacheManager.SourceDataDelegate(GetTracking);
            CacheManager cm = new CacheManager();
            object[] arg = new object[] { };

            TrackingConfiguration cfg = (TrackingConfiguration)cm.GetCachedData("TrackingConfig", 90, getConfig, arg);
            return cfg;
        }
    }
}