using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace VietNamNet.Framework.AJAX
{
    [Serializable()]
    public class AJAXConfigurationSectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        /// <summary>
        /// Creates an instance of the <see cref="AJAXConfiguration"/> class.
        /// </summary>
        /// <remarks>Uses XML Serialization to deserialize the XML in the Web.config file into an
        /// <see cref="AJAXConfiguration"/> instance.</remarks>
        /// <returns>An instance of the <see cref="AJAXConfiguration"/> class.</returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            // Create an instance of XmlSerializer based on the AJAXConfiguration type...
            XmlSerializer cfg = new XmlSerializer(typeof(AJAXConfiguration));
            // Return the Deserialized object from the Web.config XML
            return cfg.Deserialize(new XmlNodeReader(section));
        }

        #endregion
    }
}