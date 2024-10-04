using System;
using System.Xml.Serialization;

namespace VietNamNet.Framework.AJAX
{
    [Serializable()]
    public class AJAXServiceObject
    {
        private string actions;
        private string afterFilters;
        private string assembly;
        private string beforeFilters;
        private string name;
        private bool noCache;
        private string type;
        private int cacheTime;

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

        [XmlAttribute]
        public bool NoCache
        {
            get { return noCache; }
            set { noCache = value; }
        }

        [XmlAttribute]
        public string Actions
        {
            get { return actions; }
            set { actions = value; }
        }

        [XmlAttribute]
        public string BeforeFilters
        {
            get { return beforeFilters; }
            set { beforeFilters = value; }
        }

        [XmlAttribute]
        public string AfterFilters
        {
            get { return afterFilters; }
            set { afterFilters = value; }
        }

        [XmlAttribute]
        public int CacheTime
        {
            get { return cacheTime; }
            set { cacheTime = value; }
        }
    }
}