using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using FTPClient;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace VietNamNet.Services.Sports.Crawling
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //Calendar
                string strHtml = GetCalendar();

                if (strHtml.Equals(string.Empty)) return;

                StreamReader sr = new StreamReader("template.htm");
                string strTemplate = sr.ReadToEnd();
                sr.Close();

                TextWriter tw = new StreamWriter("index.htm", false, Encoding.UTF8);
                tw.Write(strTemplate.Replace("@calendar", strHtml));
                tw.Close();

                //Result
                string strHtml1 = GetResults();

                if (strHtml1.Equals(string.Empty)) return;

                StreamReader sr1 = new StreamReader("template.htm");
                string strTemplate1 = sr1.ReadToEnd();
                sr1.Close();

                TextWriter tw1 = new StreamWriter("result.htm", false, Encoding.UTF8);
                tw1.Write(strTemplate1.Replace("@calendar", strHtml1));
                tw1.Close();

                FTP2Server("index.htm");
                FTP2Server("result.htm");
            }
            catch(Exception ex)
            {
                
            }
        }

        private static string GetCalendar()
        {
            StringBuilder sb = new StringBuilder();

            string url = "http://www.bongda.com.vn/dudoan/";
            string strHTML = GetData(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(strHTML);

            //foreach (HtmlNode element in doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[1]/div[1]/div[2]"))
            HtmlNode element = doc.DocumentNode.SelectSingleNode("//*[@id=\"oddMain\"]//div[1]//table[1]");
            if (element != null)
            //foreach (HtmlNode element in doc.DocumentNode.SelectNodes("//div[@class=\"tGroupDetail\"]"))
            {
                //change bg color
                if (element.Attributes.Contains("bgcolor")) element.Attributes["bgcolor"].Value = "#DBDBDB";

                //remove first tr
                element.SelectSingleNode(element.XPath + "//tr[1]").Remove();

                //remove image src
                foreach (HtmlNode image in element.SelectNodes(element.XPath + "//img"))
                {
                    image.Remove();
                }

                //remove table
                foreach (HtmlNode table in element.SelectNodes(element.XPath + "//table"))
                {
                    table.Remove();
                }

                //change sup
                foreach (HtmlNode sup in element.SelectNodes(element.XPath + "//sup"))
                {
                    sup.Remove();
                    //if (sup.Attributes.Contains("style")) sup.Attributes["style"].Remove();
                }

                //change td bgcolor
                foreach (HtmlNode td in element.SelectNodes(element.XPath + "//tr//td"))
                {
                    if (td.Attributes.Contains("bgcolor"))
                    {
                        string bgcolor = td.Attributes["bgcolor"].Value;
                        if (!"#336699".Equals(bgcolor.ToLower())) td.Attributes["bgcolor"].Remove();
                        else
                        {
                            td.Attributes["bgcolor"].Value = "#AAAAAA";
                            td.ParentNode.Attributes.Add("key", "true");
                            td.Attributes.Add("class", "lich-td-title");
                        }
                    }
                }

                string[] colors = new string[] { "#FFFFFF", "#E7ECEF" };
                int index = 0;

                //change td bgcolor
                foreach (HtmlNode tr in element.SelectNodes(element.XPath + "//tr"))
                {
                    if (tr.Attributes.Contains("key"))
                    {
                        index = 0;
                        continue;
                    }

                    foreach (HtmlNode td in tr.SelectNodes(tr.XPath + "//td"))
                    {
                        if (td.Attributes.Contains("bgcolor")) td.Attributes["bgcolor"].Value = colors[index];
                        else td.Attributes.Add("bgcolor", colors[index]);
                    }

                    index = 1 - index;
                }

                //change font color
                foreach (HtmlNode font in element.SelectNodes(element.XPath + "//font"))
                {
                    font.Attributes.RemoveAll();
                }

                sb.Append(element.OuterHtml.Replace("và","-"));
            }

            return sb.ToString();
        }

        private static string GetResults()
        {
            StringBuilder sb = new StringBuilder();

            string url = "http://livescore.com/soccer/soccer/";
            string strHTML = GetData(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(strHTML);

            //HtmlNode element = doc.DocumentNode.SelectSingleNode("//html//body//table//tbody//tr[4]//td//table//tbody//tr//td[5]//table");
            HtmlNode element = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[1]/tr[4]/td[1]/table[1]/tr[1]/td[5]/table[1]");
            if (element != null)
            {
                if (element.Attributes.Contains("width")) element.Attributes["width"].Value = "650px";
                else element.Attributes.Add("width", "650px");

                if (element.Attributes.Contains("bgcolor")) element.Attributes["bgcolor"].Value = "#A0A0A0";
                else element.Attributes.Add("bgcolor", "#AAAAAA");

                //remove tr has bgcolor #111111
                foreach (HtmlNode tr in element.SelectNodes(element.XPath + "//tr"))
                {
                    if (tr.Attributes.Contains("bgcolor") && "#111111".Equals(tr.Attributes["bgcolor"].Value))
                    {
                        tr.Remove();
                    }
                    else if (tr.Attributes.Contains("bgcolor") && "#333333".Equals(tr.Attributes["bgcolor"].Value))
                    {
                        tr.Attributes["bgcolor"].Value = "#E7ECEF";
                    }
                }

                //remove a
                foreach (HtmlNode a in element.SelectNodes(element.XPath + "//a"))
                {
                    a.Attributes["href"].Value = "http://livescore.com" + a.Attributes["href"].Value;
                }

                //change color #952929
                //foreach (HtmlNode td in element.SelectNodes(element.XPath + "//td[3]"))
                //{
                //    td.InnerHtml = string.Format("<font color=\"#952929\"><b>{0}</b></font>", td.InnerHtml);
                //}

                sb.Append(element.OuterHtml);
            }

            return sb.ToString();
        }

        #region Common Method

        private static string GetData(string url)
        {
            StringBuilder sb = new StringBuilder();
            HttpWebRequest RSS_Request;
            HttpWebResponse RSS_Response;

            try
            {
                RSS_Request = (HttpWebRequest)WebRequest.Create(string.Format(url));
                RSS_Request.UserAgent =
                    @"Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.4) Gecko/20070515 Firefox/2.0.0.4";
                RSS_Response = (HttpWebResponse)RSS_Request.GetResponse();
                Stream streamResponse = RSS_Response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse, Encoding.UTF8);
                Char[] readBuffer = new Char[256];
                int count = streamReader.Read(readBuffer, 0, 256);
                while (count > 0)
                {
                    String resultData = new String(readBuffer, 0, count);
                    sb.Append(resultData);
                    count = streamReader.Read(readBuffer, 0, 256);
                }
                //sb.Append(streamReader.ReadToEnd());
                streamReader.Close();
                streamResponse.Close();

                RSS_Response.Close();
            }
            catch
            {
                sb = null;
            }

            return sb != null ? sb.ToString() : string.Empty;
        }

        public static string GetConfigKey(string msgConstantKey)
        {
            string msg;
            try
            {
                msg = ConfigurationManager.AppSettings[msgConstantKey];
            }
            catch
            {
                msg = string.Empty;
            }
            return msg;
        }

        private static void FTP2Server(string fileName)
        {
            try
            {
                string ftpHost = GetConfigKey("FTPHost");
                string ftpPort = GetConfigKey("FTPPort");
                string ftpUser = GetConfigKey("FTPUser");
                string ftpPass = GetConfigKey("FTPPass");
                string ftpFolder = GetConfigKey("FTPFolder");
                string ftpMode = GetConfigKey("FTPMode");
                string ftpTransferType = GetConfigKey("FTPTransferType");

                FTPConnection ftpConn = new FTPConnection();
                ftpConn.Open(ftpHost, Convert.ToInt32(ftpPort), ftpUser, ftpPass,
                             (Convert.ToInt32(ftpMode) == 1) ? FTPMode.Passive : FTPMode.Active);
                ftpConn.SetCurrentDirectory(ftpFolder);
                string filePath = string.Format(@"{0}\{1}", Application.StartupPath, fileName);
                ftpConn.SendFile(filePath,
                                 (Convert.ToInt32(ftpTransferType) == 1)
                                     ? FTPFileTransferType.ASCII
                                     : FTPFileTransferType.Binary);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}