using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace VietNamNet.Framework.Common
{
    public class CacheManager
    {
        #region Delegates

        public delegate object SourceDataDelegate(object[] parameters);

        #endregion

        /// <summary>
        /// Get cached data if it exists, otherwise callback to get from source.
        /// The cached data uses a key that is composed of the parameter array.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="expireMinutes"></param>
        /// <param name="getSourceData"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object GetCachedData(string category, int expireMinutes, SourceDataDelegate getSourceData,
                                    object[] parameters)
        {
            Cache cache;
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                cache = current.Cache;
            }
            else
            {
                cache = HttpRuntime.Cache;
            }

            string key = BindKey(category, parameters);
            object obj = cache.Get(key);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                obj = getSourceData(parameters);

                if (obj != null)
                {
                    cache.Insert(key, obj, null, DateTime.Now.AddMinutes(expireMinutes), Cache.NoSlidingExpiration);
                }

                return obj;
            }
        }

        private static string BindKey(string category, object[] parameters)
        {
            StringBuilder strBuilder = new StringBuilder(category);

            foreach (object param in parameters)
            {
                if (param.GetType() == typeof (String))
                {
                    strBuilder.Append("_");
                    strBuilder.Append(((string) param).Trim().ToLower());
                }
                else if (param.GetType().IsValueType)
                {
                    strBuilder.Append("_");
                    strBuilder.Append(param);
                }
                else if (param.GetType() == typeof (DateTime))
                {
                    strBuilder.Append("_");
                    strBuilder.Append(param.ToString());
                }
            }
            return strBuilder.ToString();
        }

        public static void ClearCache()
        {
            Cache cache;
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                cache = current.Cache;
            }
            else
            {
                cache = HttpRuntime.Cache;
            }
            ArrayList list = new ArrayList();
            IDictionaryEnumerator enumerator = cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Key.ToString());
            }
            foreach (object obj2 in list)
            {
                cache.Remove(obj2.ToString());
            }
        }

        public static string GetCacheXML(string key)
        {
            object obj = GetCacheObject(key);
            return Convertor.ToString(obj);
        }

        public static object GetCacheObject(string key)
        {
            Cache cache;
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                cache = current.Cache;
            }
            else
            {
                cache = HttpRuntime.Cache;
            }

            return cache.Get(key);
        }

        public static DataTable GetCaches()
        {
            DataTable dt = GetCacheTableTemplate();
            Cache cache;
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                cache = current.Cache;
            }
            else
            {
                cache = HttpRuntime.Cache;
            }

            foreach (DictionaryEntry entry in cache)
            {
                DataRow dr = dt.NewRow();
                dr["Key"] = entry.Key.ToString();
                if (entry.Value != null)
                {
                    dr["ObjectType"] = entry.Value.GetType().FullName;
                    string xml = Convertor.ToString(entry.Value);
                    if (Nulls.IsNullOrEmpty(xml))
                    {
                        dr["Code"] = 0;
                        dr["Length"] = 0;
                        dr["XML"] = string.Empty;
                        dr["Note"] = "Data could not be serialized to Xml.";
                    }
                    else
                    {
                        dr["Code"] = 1;
                        dr["Length"] = xml.Length;
                        dr["XML"] = xml;
                        dr["Note"] = "Double Click to View Data.";
                    }
                }
                else
                {
                    dr["ObjectType"] = "NULL";
                    dr["Code"] = 0;
                    dr["Length"] = 0;
                    dr["XML"] = string.Empty;
                    dr["Note"] = "Data could not be serialized to Xml.";
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static DataTable GetCacheTableTemplate()
        {
            DataTable dt = new DataTable("CacheManager");
            dt.Columns.Add("Key");
            dt.Columns.Add("ObjectType");
            dt.Columns.Add("Code", typeof(int));
            dt.Columns.Add("Length", typeof(int));
            dt.Columns.Add("XML");
            dt.Columns.Add("Note");
            return dt;
        }
    }
}