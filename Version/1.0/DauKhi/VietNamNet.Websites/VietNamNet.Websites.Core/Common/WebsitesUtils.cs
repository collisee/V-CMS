using System.Data;
using System.Net;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.Common
{
    public class WebsitesUtils
    {
        #region Build Link

        public static string BuildLink(string title)
        {
            return Utilities.ConvertToHTMLLink(title);
        }

        public static string BuildLink(object title)
        {
            if (title == null) return string.Empty;
            return Utilities.ConvertToHTMLLink(title.ToString());
        }

        public static string GetArticleIcon(int ArticleContentType)
        {
            switch (ArticleContentType)
            {
                case 2:
                    return " photob";
                case 3:
                    return " videob";
                case 4:
                    return " audiob";
                default:
                    return string.Empty;
            }
        }

        protected static string GetUrlFormat(string url)
        {
            if (Nulls.IsNullOrEmpty(url)) return string.Empty;

            if (url.IndexOf("/") == 0 || url.IndexOf("http") > -1)
            {
                return url;
            }
            else
            {
                return "/vn/" + url + "{0}/{1}.html";
            }
        }

        protected static string GetCategoryUrlFormat(string url)
        {
            if (Nulls.IsNullOrEmpty(url)) return string.Empty;

            if (url.IndexOf("http://") == 0)
            {
                string strSub = url.Substring(7);
                string strUrl = "http://" + strSub.Substring(0, strSub.IndexOf("/"));
                return strUrl;
            }
            else if (url.IndexOf("/") != 0)
            {
                return string.Format("/vn/{0}index.html", url);
            }
            else
            {
                return url.Replace("{0}/{1}", "index");
            }
        }

        public static string BuildCategoryLink(string url, string title, string className)
        {
            if (Nulls.IsNullOrEmpty(url)) return string.Empty;

            string strLink = "<a class=\"{1}\" href=\"{2}\" target=\"{3}\">{0}</a>";

            string strUrl = GetCategoryUrlFormat(url);

            string strTarget = url.IndexOf("http://") == 0 ? "_blank" : "_self";

            return string.Format(strLink, title, className, strUrl, strTarget);
        }

        public static string BuildCategoryLink(object url, object title, object className)
        {
            string strUrl = (url == null) ? string.Empty : url.ToString();
            string strTitle = (title == null) ? string.Empty : title.ToString();
            string strClassName = (className == null) ? string.Empty : className.ToString();
            return BuildCategoryLink(strUrl, strTitle, strClassName);
        }

        public static string BuildTextLink(string url, string id, string title, string className, int type)
        {
            if (Nulls.IsNullOrEmpty(url)) return string.Empty;

            string strLink = "<a class=\"{1}\" href=\"{2}\" target=\"{3}\">{0}</a>";

            string strUrl = string.Format(GetUrlFormat(url), id, BuildLink(title));

            string strTarget = url.IndexOf("http://") == 0 ? "_blank" : "_self";

            string strClassName = className + GetArticleIcon(type);

            return string.Format(strLink, title, strClassName, strUrl, strTarget);
        }

        public static string BuildTextLink(string url, string id, string title, string className)
        {
            return BuildTextLink(url, id, title, className, 1);
        }

        public static string BuildTextLink(object url, object id, object title, object className, int type)
        {
            string strUrl = (url == null) ? string.Empty : url.ToString();
            string strId = (id == null) ? string.Empty : id.ToString();
            string strTitle = (title == null) ? string.Empty : title.ToString();
            string strClassName = (className == null) ? string.Empty : className.ToString();
            return BuildTextLink(strUrl, strId, strTitle, strClassName, type);
        }

        public static string BuildTextLink(object url, object id, object title, object className)
        {
            return BuildTextLink(url, id, title, className, 1);
        }

        public static string BuildImageLink(string url, string id, string title, string className, string alternativeClassName, string imageUrl, string imageClassName, int width, int height)
        {
            if (Nulls.IsNullOrEmpty(url)) return string.Empty;
            if (Nulls.IsNullOrEmpty(imageUrl)) return string.Empty;

            string strLink = "<a class=\"{1}\" href=\"{2}\" target=\"{3}\"><img alt=\"\" title=\"\" src=\"{0}\"{4} /></a>";

            string strImageUrl = string.Format("{0}?w={1}&h={2}", imageUrl, width, height);

            string strClassName = Nulls.IsNullOrEmpty(imageUrl) ? alternativeClassName : className;

            string strUrl = string.Format(GetUrlFormat(url), id, BuildLink(title));

            string strTarget = url.IndexOf("http://") == 0 ? "_blank" : "_self";

            string strImageProperties = (width > 0) ? string.Format(" width=\"{0}\"", width) : string.Empty;
            strImageProperties += (height > 0) ? string.Format(" height=\"{0}\"", height) : string.Empty;
            strImageProperties += !Nulls.IsNullOrEmpty(imageClassName) ? string.Format(" class=\"{0}\"", imageClassName) : string.Empty;

            return string.Format(strLink, strImageUrl, strClassName, strUrl, strTarget, strImageProperties);
        }

        public static string BuildImageLink(string url, string id, string title, string className, string alternativeClassName, string imageUrl, string imageClassName, int width)
        {
            return BuildImageLink(url, id, title, className, alternativeClassName, imageUrl, imageClassName, width, 0);
        }

        public static string BuildImageLink(object url, object id, object title, object className, object alternativeClassName, object imageUrl, object imageClassName, int width, int height)
        {
            string strUrl = (url == null) ? string.Empty : url.ToString();
            string strId = (id == null) ? string.Empty : id.ToString();
            string strTitle = (title == null) ? string.Empty : title.ToString();
            string strClassName = (className == null) ? string.Empty : className.ToString();
            string strAlternativeClassName = (alternativeClassName == null) ? string.Empty : alternativeClassName.ToString();
            string strImageUrl = (imageUrl == null) ? string.Empty : imageUrl.ToString();
            string strImageClassName = (imageClassName == null) ? string.Empty : imageClassName.ToString();
            return BuildImageLink(strUrl, strId, strTitle, strClassName, strAlternativeClassName, strImageUrl, strImageClassName, width, height);
        }

        public static string BuildImageLink(object url, object id, object title, object className, object alternativeClassName, object imageUrl, object imageClassName, int width)
        {
            return BuildImageLink(url, id, title, className, alternativeClassName, imageUrl, imageClassName, width, 0);
        }

        #endregion

        #region Configuration

        public static string GetServerIP()
        {
            IPHostEntry ipHost = Dns.GetHostByName(Dns.GetHostName());

            return (ipHost.AddressList.Length > 0) ? ipHost.AddressList[0].ToString() : string.Empty;
        }

        public static int GetConfigCacheTime()
        {
            int defaultCacheTime = Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.TimeCaching));
            CacheManager.SourceDataDelegate getServerConfig = new CacheManager.SourceDataDelegate(GetServerConfig);
            CacheManager cm = new CacheManager();
            object[] arg = new object[] { WebsitesConstants.ServerConfiguration.ConfigCacheTime };

            string cfg = (string)cm.GetCachedData(WebsitesConstants.ServerConfiguration.Name, defaultCacheTime, getServerConfig, arg);
            int cacheTime = Utilities.ParseInt(cfg);

            return cacheTime <= 0 ? defaultCacheTime : cacheTime;
        }

        private static string GetServerConfig(object[] param)
        {
            if (param.Length <= 0) return string.Empty;
            if (!param[0].GetType().Equals(typeof(string))) return string.Empty;

            string serverConfig = string.Format("{0}_{1}", GetServerIP(), param[0]);

            string serverValue = SystemUtils.GetConfiguration(serverConfig);

            return Nulls.IsNullOrEmpty(serverValue) ? SystemUtils.GetConfiguration(param[0].ToString()) : serverValue;
        }

        public static string GetConfiguration(string configName)
        {
            CacheManager.SourceDataDelegate getServerConfig = new CacheManager.SourceDataDelegate(GetServerConfig);
            CacheManager cm = new CacheManager();
            object[] arg = new object[] { configName };

            string cfg = (string)cm.GetCachedData(WebsitesConstants.ServerConfiguration.Name, GetConfigCacheTime(), getServerConfig, arg);
            return cfg;
        }

        public static string GetHomepage()
        {
            string homepage = GetConfiguration(WebsitesConstants.ServerConfiguration.Homepage);
            return (Nulls.IsNullOrEmpty(homepage)) ? Utilities.GetConfigKey(WebsitesConstants.ConfigKey.Homepage) : homepage;
        }

        public static string GetStyleSheet()
        {
            return GetConfiguration(WebsitesConstants.ServerConfiguration.StyleSheet);
        }

        public static string GetJavascript()
        {
            return GetConfiguration(WebsitesConstants.ServerConfiguration.Javascript);
        }

        #endregion

        #region ArtilesTopRead, ArtilesTopComment

        public static DataTable GetArtilesTopRead()
        {
            int topRead = Utilities.ParseInt(GetConfiguration(WebsitesConstants.ServerConfiguration.TopRead));

            if (topRead == 0) //topRead = 0 -> get Top Read
            {
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.FirstIndexRecord = 1;
                helper.ValueObject.LastIndexRecord = 10;
                return helper.GetArticlesTopRead();
            }
            else //topRead = 1 -> get by Category
            {
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.CategoryAlias = "doc-nhieu-nhat";
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

                    //Get Article
                    WebsitesHelper helperArticles2 = new WebsitesHelper(new WebsitesObject());
                    helperArticles2.ValueObject.PartitionId = partitionId;
                    helperArticles2.ValueObject.CategoryId = categoryId;
                    helperArticles2.ValueObject.FirstIndexRecord = 1;
                    helperArticles2.ValueObject.LastIndexRecord = 10;
                    return helperArticles2.GetCategoryArticles();
                }
            }

            return null;
        }

        public static DataTable GetArtilesTopComment()
        {
            int topComment = Utilities.ParseInt(GetConfiguration(WebsitesConstants.ServerConfiguration.TopComment));

            if (topComment == 0) //topComment = 0 -> get Top Comment
            {
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.FirstIndexRecord = 1;
                helper.ValueObject.LastIndexRecord = 10;
                return helper.GetArticlesTopComment();
            }
            else //topComment = 1 -> get by Category
            {
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.CategoryAlias = "phan-hoi-nhieu-nhat";
                DataTable dt = helper.GetCategoryByAlias();

                if (dt != null && dt.Rows.Count > 0)
                {
                    int categoryId =
                        Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                    int partitionId =
                        Utilities.ParseInt(dt.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

                    //Get Article
                    WebsitesHelper helperArticles2 = new WebsitesHelper(new WebsitesObject());
                    helperArticles2.ValueObject.PartitionId = partitionId;
                    helperArticles2.ValueObject.CategoryId = categoryId;
                    helperArticles2.ValueObject.FirstIndexRecord = 1;
                    helperArticles2.ValueObject.LastIndexRecord = 10;
                    return helperArticles2.GetCategoryArticles();
                }
            }

            return null;
        }

        #endregion
    }
}