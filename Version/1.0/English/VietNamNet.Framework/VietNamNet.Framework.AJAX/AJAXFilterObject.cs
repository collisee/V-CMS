using System;
using System.Xml.Serialization;

namespace VietNamNet.Framework.AJAX
{
    [Serializable()]
    public class AJAXFilterObject
    {
        private string assembly;
        private string name;
        private string type;

        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlAttribute]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [XmlAttribute]
        public string Assembly
        {
            get { return assembly; }
            set { assembly = value; }
        }
    }
}