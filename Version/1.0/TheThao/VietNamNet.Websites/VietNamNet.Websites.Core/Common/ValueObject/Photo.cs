using System;
using System.Xml.Serialization;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    [Serializable()]
    public class Photo
    {
        #region Private Properties

        protected string fileName;
        protected string link;
        protected string description;

        #endregion

        #region Public Properties

        [XmlElement("filename")]
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        [XmlElement("link")]
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        [XmlElement("description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        #endregion
    }
}
