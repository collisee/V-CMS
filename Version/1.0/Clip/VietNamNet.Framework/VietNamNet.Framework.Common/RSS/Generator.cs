using System.Collections.Generic;
using System.Data;

namespace VietNamNet.Framework.Common.RSS
{
    public class Generator
    {
        public static string FromDataTable(DataTable source, Channel c)
        {
            RSS rss = new RSS(c);

            if (source != null && source.Rows.Count > 0)
            {
                foreach (DataRow dr in source.Rows)
                {
                    Item item = MaptoItem(dr);
                    rss.Channel.Items.Add(item);
                }
            }

            return Convertor.ToString(rss);
        }

        public static string FromDataTable(DataTable source, string cTitle, string cLink, string cDesc,
                                           string cCopyright)
        {
            Channel c = new Channel(cTitle, cLink, cDesc, cCopyright);

            return FromDataTable(source, c);
        }

        public static string FromArray(object[] source, Channel c)
        {
            RSS rss = new RSS(c);

            if (source != null && source.Length > 0)
            {
                foreach (object obj in source)
                {
                    Item item = MaptoItem(obj);
                    rss.Channel.Items.Add(item);
                }
            }

            return Convertor.ToString(rss);
        }

        public static string FromArray(object[] source, string cTitle, string cLink, string cDesc,
                                       string cCopyright)
        {
            Channel c = new Channel(cTitle, cLink, cDesc, cCopyright);

            return FromArray(source, c);
        }

        public static string FromList(List<object> source, Channel c)
        {
            RSS rss = new RSS(c);

            if (source != null && source.Count > 0)
            {
                foreach (object obj in source)
                {
                    Item item = MaptoItem(obj);
                    rss.Channel.Items.Add(item);
                }
            }

            return Convertor.ToString(rss);
        }

        public static string FromList(List<object> source, string cTitle, string cLink, string cDesc,
                                      string cCopyright)
        {
            Channel c = new Channel(cTitle, cLink, cDesc, cCopyright);

            return FromList(source, c);
        }

        private static Item MaptoItem(object obj)
        {
            Item itm = new Item();

            if (obj is DataRow)
            {
                DataRow dr = (DataRow) obj;
                itm.Title = dr["Title"].ToString();
                itm.Description = dr["Description"].ToString();
                itm.Link = dr["Link"].ToString();
                itm.PubDate = dr["PubDate"].ToString();
            }
            else
            {
                itm.Title = Utilities.GetProperty(obj, "Title");
                itm.Description = Utilities.GetProperty(obj, "Description");
                itm.Link = Utilities.GetProperty(obj, "Link");
                itm.PubDate = Utilities.GetProperty(obj, "PubDate");
            }
            return itm;
        }
    }
}