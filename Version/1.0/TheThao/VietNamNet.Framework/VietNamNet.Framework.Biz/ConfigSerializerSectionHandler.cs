using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace VietNamNet.Framework.Biz
{
    [Serializable()]
    public class ConfigSerializerSectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        public object Create(object parent, object configContext, XmlNode section)
        {
            // Create an instance of XmlSerializer based on the AJAXConfiguration type...
            XmlSerializer cfg = new XmlSerializer(typeof(BizConfiguration));
            // Return the Deserialized object from the Web.config XML
            return cfg.Deserialize(new XmlNodeReader(section));
        }

        #endregion
    }
}