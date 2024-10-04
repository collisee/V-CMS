using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Xml.Serialization;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.AJAX
{
    [XmlRoot("AJAXConfiguration")]
    public class AJAXConfiguration
    {
        private AJAXServiceCollection serviceCollection;
        private AJAXFilterCollection filterCollection;
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

        [XmlElement("AJAXService")]
        public AJAXServiceCollection AJAXServices
        {
            get { return serviceCollection; }
            set { serviceCollection = value; }
        }

        [XmlElement("AJAXFilter")]
        public AJAXFilterCollection AJAXFilters
        {
            get { return filterCollection; }
            set { filterCollection = value; }
        }

        private static AJAXConfiguration GetAJAX(object[] param)
        {
            return (AJAXConfiguration)ConfigurationManager.GetSection("AJAXConfiguration");
        }

        public static AJAXConfiguration GetConfig()
        {
            CacheManager.SourceDataDelegate getConfig = new CacheManager.SourceDataDelegate(GetAJAX);
            CacheManager cm = new CacheManager();
            object[] arg = new object[] { };

            AJAXConfiguration cfg = (AJAXConfiguration)cm.GetCachedData("AJAXConfig", 90, getConfig, arg);
            return cfg;
        }
    }
}