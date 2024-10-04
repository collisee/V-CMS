using System;
using HtmlAgilityPack;

namespace VNN_WEBEXTRACTOR
{
    public class Html2Xml
    {
        public void SaveHtml2Xml()
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(@"..\..\mshome.htm");
                doc.OptionOutputAsXml = true;
                doc.Save("mshome.xml");
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveHtml2Xml(String htmlFile, String xmlDirDes)
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(htmlFile);
                doc.OptionOutputAsXml = true;
                doc.Save(xmlDirDes);
            }
            catch (Exception ex)
            {
            }
        }
    }
}