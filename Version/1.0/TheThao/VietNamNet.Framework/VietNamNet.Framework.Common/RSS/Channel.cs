using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VietNamNet.Framework.Common.RSS
{
    [XmlRoot(ElementName = "channel", IsNullable = false)]
    public class Channel
    {
        private string copyright;
        private string description;
        private string generator;
        private List<Item> items;
        private string lastBuildDate;
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

        [XmlElement(ElementName = "copyright", IsNullable = true)]
        public string Copyright
        {
            get { return copyright; }
            set { copyright = value; }
        }

        [XmlElement(ElementName = "generator", IsNullable = true)]
        public string Generator
        {
            get { return generator; }
            set { generator = value; }
        }

        [XmlElement(ElementName = "pubDate", IsNullable = true)]
        public string PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }

        [XmlElement(ElementName = "lastBuildDate", IsNullable = true)]
        public string LastBuildDate
        {
            get { return lastBuildDate; }
            set { lastBuildDate = value; }
        }

        [XmlElement(ElementName = "item", IsNullable = true)]
        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Channel()
        {
            title = string.Empty;
            description = string.Empty;
            link = string.Empty;
            copyright = string.Empty;
            generator = "VietNamNet.Framework.Common.RSS.Generator - version 1.0";
            pubDate = DateTime.Now.ToLongTimeString();
            lastBuildDate = DateTime.Now.ToLongTimeString();
            items = new List<Item>();
        }

        public Channel(string cTitle, string cLink, string cDesc, string cCopyright)
        {
            title = cTitle;
            description = cDesc;
            link = cLink;
            copyright = cCopyright;
            generator = "VietNamNet.Framework.Common.RSS.Generator - version 1.0";
            pubDate = DateTime.Now.ToLongTimeString();
            lastBuildDate = DateTime.Now.ToLongTimeString();
            items = new List<Item>();
        }
    }
}