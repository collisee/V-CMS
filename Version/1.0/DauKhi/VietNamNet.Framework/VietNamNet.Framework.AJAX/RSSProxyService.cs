using System;
using System.IO;
using System.Net;
using System.Text;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.RSS;

namespace VietNamNet.Framework.AJAX
{
    public class RSSProxyService : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            string url = packet.Parameters["url"];

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(url);
        }

        private object GetData(string url)
        {
            HttpWebRequest RSS_Request;
            HttpWebResponse RSS_Response;
            try
            {
                RSS_Request = (HttpWebRequest)WebRequest.Create(url);
                RSS_Request.UserAgent =
                    @"Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.4) Gecko/20070515 Firefox/2.0.0.4";
                RSS_Response = (HttpWebResponse)RSS_Request.GetResponse();
                Stream streamResponse = RSS_Response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse);
                StringBuilder sb = new StringBuilder();
                Char[] readBuffer = new Char[256];
                int count = streamReader.Read(readBuffer, 0, 256);
                while (count > 0)
                {
                    String resultData = new String(readBuffer, 0, count);
                    sb.Append(resultData);
                    count = streamReader.Read(readBuffer, 0, 256);
                }
                streamReader.Close();
                streamResponse.Close();

                RSS_Response.Close();

                //Convert to RSS Object
                return Convertor.ToObject(typeof(RSS), sb.ToString());
            }
            catch
            {
                return null;
            }
        }
    }
}