using System;
using System.Web;
using System.Web.Caching;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.AJAX
{
    public class AJAXCacheFilter
    {
        public static AJAXPacket GetCache()
        {
            string url = HttpContext.Current.Request.Url.ToString();
            url = Utilities.SetParamForURL(url, "rnd", "0");
            object obj = HttpRuntime.Cache.Get(url);
            if (obj != null)
            {
                AJAXPacket packet = (AJAXPacket)obj;
                return packet;
            }

            return null;
        }

        public static void SetCache(AJAXPacket packet, int cacheInMinutes)
        {
            string url = HttpContext.Current.Request.Url.ToString();
            url = Utilities.SetParamForURL(url, "rnd", "0");
            double expireMinutes = cacheInMinutes;
            if (expireMinutes <= 0) expireMinutes = 10;
            HttpRuntime.Cache.Add(url, packet, null, DateTime.Now.AddMinutes(expireMinutes), Cache.NoSlidingExpiration,
                                  CacheItemPriority.Default, null);
        }

        public static void SetCache(AJAXPacket packet)
        {
            SetCache(packet, Utilities.ParseInt(Utilities.GetConfigKey("TimeCaching")));
        }
    }
}