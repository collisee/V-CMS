using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace Caching
{
    /// <summary>
    /// Cache modes
    /// </summary>
    public enum CacheMode
    {
        Memory,
        Files,
        Compressed,
        Auto
    }

    /// <summary>
    /// Utilities Class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// The location of the temporary cache folder
        /// </summary>
        public static readonly string CacheLocation = HostingEnvironment.ApplicationPhysicalPath + "ConcurrentCache\\";
        /// <summary>
        /// The in memory cache object
        /// </summary>
        public static ConcurrentDictionary<string, CachItem> ConcurrentCache = new ConcurrentDictionary<string, CachItem>();
        
        // Cache selection variables
        static readonly int MIN_MEMORY_PERCENT = 40;
        static DateTime LastChecked = DateTime.MinValue;
        public static TimeSpan CheckInterval = new TimeSpan(TimeSpan.TicksPerMinute);
        static CacheMode cacheMode;

        /// <summary>
        /// Prepare the Cache Directory
        /// </summary>
        public static void PrepareCacheDirectory()
        {
            if (!Directory.Exists(Utils.CacheLocation))
                Directory.CreateDirectory(Utils.CacheLocation);
        }

        /// <summary>
        /// Gets the current cache mode
        /// </summary>
        /// <returns></returns>
        public static CacheMode GetCacheMode()
        {
            if ((DateTime.Now - LastChecked) < CheckInterval)
                return cacheMode;

            LastChecked = DateTime.Now;

            Enum.TryParse(ConfigurationManager.AppSettings["CacheMode"], out cacheMode);
            switch (cacheMode)
            {
                case CacheMode.Auto:
                    if (GetFreeMemoryPercent() >= MIN_MEMORY_PERCENT)
                        cacheMode = CacheMode.Files;
                    else
                        cacheMode = CacheMode.Memory;
                    return cacheMode;
                default:
                    return cacheMode;
            }
        }

        /// <summary>
        /// If the cache more is set to Auto, find out the current free memory
        /// </summary>
        /// <returns></returns>
        public static int GetFreeMemoryPercent()
        {
            ComputerInfo ci = new ComputerInfo();
            return Convert.ToInt32(Convert.ToDouble(ci.AvailableVirtualMemory) / Convert.ToDouble(ci.TotalVirtualMemory) * 100);
        }

        /// <summary>
        /// Sets the cache key to a valid file name
        /// </summary>
        /// <param name="fileKey"></param>
        /// <returns></returns>
        public static string GetCacheFileName(string fileKey)
        {
            Array.ForEach(Path.GetInvalidFileNameChars(), (c) => fileKey.Replace(c, '-'));
            return Path.GetFileName(fileKey);
        }
    }

    /// <summary>
    /// Holds the cache key and expiration date
    /// </summary>
    public struct CachItem
    {
        public DateTime UtcExpiry { get; set; }
        public object ItemValue { get; set; }
    }
}
