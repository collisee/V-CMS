using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections.ObjectModel;

namespace vnnRssFramework
{
    public class RssReader
    {
        private string url;

        private XmlTextReader rssReader;
        private XmlDocument rssDoc;
        private XmlNode nodeRss;
        private XmlNode nodeChannel;
        private XmlNode nodeItem;

        private string title;
        private string language;
        private string link;
        private string description;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private List<RssEntry> entryList = new List<RssEntry>();


        public ReadOnlyCollection<RssEntry> Entries
        {
            get { return new ReadOnlyCollection<RssEntry>(entryList); }
        }

        public RssReader(string url)
        {
            this.url = url;
            Refresh();
        }

        public void Refresh()
        {
            try
            {
                // Create a new XmlTextReader from the specified URL (RSS feed)
                rssReader = new XmlTextReader(url);
                rssDoc = new XmlDocument();
                // Load the XML content into a XmlDocument
                rssDoc.Load(rssReader);

                // Loop for the <rss> tag
                for (int i = 0; i < rssDoc.ChildNodes.Count; i++)
                {
                    if (rssDoc.ChildNodes[i].Name == "rss")
                    {
                        nodeRss = rssDoc.ChildNodes[i];
                    }
                }

                // Loop for the <channel> tag
                if (nodeRss != null)
                {
                    for (int i = 0; i < nodeRss.ChildNodes.Count; i++)
                    {
                        if (nodeRss.ChildNodes[i].Name == "channel")
                        {
                            nodeChannel = nodeRss.ChildNodes[i];
                        }
                    }
                    if (nodeChannel != null)
                    {
                        title = nodeChannel["title"].InnerText;
                        //language = nodeChannel["language"].InnerText;
                        link = nodeChannel["link"].InnerText;
                        description = nodeChannel["description"].InnerText;

                        // Loop for the <title>, <link>, <description> and all the other tags
                        for (int i = 0; i < nodeChannel.ChildNodes.Count; i++)
                        {
                            if (nodeChannel.ChildNodes[i].Name == "item")
                            {
                                nodeItem = nodeChannel.ChildNodes[i];

                                string entryTitle = nodeItem["title"].InnerText;
                                string entryLink = nodeItem["link"].InnerText;
                                string entryDescription = nodeItem["description"].InnerText;
                                entryList.Add(new RssEntry(entryTitle, entryLink, entryDescription));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}