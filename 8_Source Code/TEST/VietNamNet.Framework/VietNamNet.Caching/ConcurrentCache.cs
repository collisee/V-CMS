using System;
using System.IO;
using System.Web.Caching;

namespace Caching
{
    public class ConcurrentCache : OutputCacheProvider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ConcurrentCache()
        {
            Utils.PrepareCacheDirectory();
        }

        #region Overrides
        /// <summary>
        /// Inserts the specified entry into the output cache.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entry"></param>
        /// <param name="utcExpiry"></param>
        /// <returns></returns>
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
			// If the item exists, return the item
			object existingItem = Get(key);
			if (existingItem != null)
				return existingItem;

			// If the item doesnt exist. Add it to the cache
			Set(key, entry, utcExpiry);
			return entry;
        }

        /// <summary>
        /// Returns a reference to the specified entry in the output cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object Get(string key)
        {
            CacheMode cacheMode = Utils.GetCacheMode();
            var cacheItem = Utils.ConcurrentCache.AsParallel().Where(c => c.Key == key && c.Value.UtcExpiry >= DateTime.Now.ToUniversalTime()).FirstOrDefault();
            if (cacheItem.Key == null)
                return null;

            if (cacheMode == CacheMode.Compressed)
                return IO.ReadCompressedFile(key);
            else if (cacheItem.Value.ItemValue != null) // Check the memory first
                return cacheItem.Value.ItemValue;
            else
                return IO.ReadFile(key);
        }

        /// <summary>
        /// Removes the specified entry from the output cache.
        /// </summary>
        /// <param name="key"></param>
        public override void Remove(string key)
        {
            CachItem cacheObject = new CachItem();
            Utils.ConcurrentCache.TryRemove(key, out cacheObject);
            string fileKey = Utils.GetCacheFileName(key);
            if (File.Exists(Utils.CacheLocation + fileKey))
                File.Delete(Utils.CacheLocation + fileKey);
        }

        /// <summary>
        /// Inserts the specified entry into the output cache, overwriting the entry if it is already cached.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entry"></param>
        /// <param name="utcExpiry"></param>
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            CacheMode cacheMode = Utils.GetCacheMode();
            CachItem cacheObject = new CachItem() { UtcExpiry = utcExpiry };

            if (cacheMode == CacheMode.Compressed)
                IO.WriteCompressedFile(key, entry);
            else if (cacheMode == CacheMode.Files)
                IO.WriteFile(key, entry);
            else
                cacheObject.ItemValue = entry;

            Utils.ConcurrentCache.AddOrUpdate(key, cacheObject, (oldKey, oldValue) => cacheObject);
        }

        #endregion
    }
}
