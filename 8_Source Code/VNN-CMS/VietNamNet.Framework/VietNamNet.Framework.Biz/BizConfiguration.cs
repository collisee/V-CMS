using System.Configuration;
using System.Xml.Serialization;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Biz
{
    [XmlRoot("BizConfiguration")]
    public class BizConfiguration
    {
        private string assembly;
        private BizObjectCollection bizObjects;
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

        [XmlElement("BizObject")]
        public BizObjectCollection BizObjects
        {
            get { return bizObjects; }
            set { bizObjects = value; }
        }

        private static BizConfiguration GetBiz(object[] param)
        {
            return (BizConfiguration) ConfigurationManager.GetSection("BizConfiguration");
        }

        public static BizConfiguration GetConfig()
        {
            CacheManager.SourceDataDelegate getConfig = new CacheManager.SourceDataDelegate(GetBiz);
            CacheManager cm = new CacheManager();
            object[] arg = new object[] {};

            BizConfiguration cfg = (BizConfiguration) cm.GetCachedData("BizConfig", 90, getConfig, arg);
            return cfg;
        }
    }
}