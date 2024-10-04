using System.Xml.Serialization;

namespace VietNamNet.Framework.Common.RSS
{
    [XmlRoot(ElementName = "item", IsNullable = false)]
    public class Item
    {
        private string description;
        private string link;
        private string pubDate;
        private string title;

        [XmlElement(ElementName = "title", IsNullable = true)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [XmlElement(ElementName = "description", IsNullable = true)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [XmlElement(ElementName = "link", IsNullable = true)]
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        [XmlElement(ElementName = "pubDate", IsNullable = true)]
        public string PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }
    }
}