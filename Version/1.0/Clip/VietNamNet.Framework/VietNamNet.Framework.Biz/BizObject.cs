using System;
using System.Xml.Serialization;

namespace VietNamNet.Framework.Biz
{
    [Serializable()]
    public class BizObject
    {
        private string actions;
        private string assembly;
        private string name;
        private string type;

        [XmlAttribute]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlAttribute]
        public string Assembly
        {
            get { return assembly; }
            set { assembly = value; }
        }

        [XmlAttribute]
        public string Actions
        {
            get { return actions; }
            set { actions = value; }
        }
    }
}