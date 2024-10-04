using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Caching;

namespace ConcurrentCache
{
    /// <summary>
    /// Disk IO operations
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// Read an object from a file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object ReadFile(string key)
        {
            string fileKey = Utils.GetCacheFileName(key);

            if (!File.Exists(Utils.CacheLocation + fileKey))
                return null;
            object ItemValue = null;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Utils.CacheLocation + fileKey, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ItemValue = formatter.Deserialize(stream);
            }
            return ItemValue;
        }

        /// <summary>
        /// Write an object to a file
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ItemValue"></param>
        public static void WriteFile(string key, object ItemValue)
        {
            string fileKey = Utils.GetCacheFileName(key);
            
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Utils.CacheLocation + fileKey, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, ItemValue);
            }
        }

        /// <summary>
        /// Read a compressed object from a file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object ReadCompressedFile(string key)
        {
            string fileKey = Utils.GetCacheFileName(key);
           
            if (!File.Exists(Utils.CacheLocation + fileKey))
                return null;

            object ItemValue = null;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Utils.CacheLocation + fileKey, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (GZipStream Decompress = new GZipStream(stream,
                        CompressionMode.Decompress))
                {
                    ItemValue = formatter.Deserialize(Decompress);
                }
            }
            return ItemValue;
        }
      
        /// <summary>
        /// Write a compressed object to a file
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ItemValue"></param>
        public static void WriteCompressedFile(string key, object ItemValue)
        {
            string fileKey = Utils.GetCacheFileName(key);
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(Utils.CacheLocation + fileKey, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                using (GZipStream Compress = new GZipStream(stream, CompressionMode.Compress))
                {
                    formatter.Serialize(Compress, ItemValue);
                }
            }
        }
    }
}
