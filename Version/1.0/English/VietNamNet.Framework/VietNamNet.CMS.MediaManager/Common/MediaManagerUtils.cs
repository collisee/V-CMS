using System;
using System.IO;
using System.Web;
using VietNamNet.Framework.Common;

namespace VietNamNet.CMS.MediaManager.Common
{
    public class MediaManagerUtils
    {
        public static string GetCommonFolder()
        {
            string uploadFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.UpLoadDirectory);
            string commonFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.CommonDirectory);
            string folder = string.Format("~/{0}/{1}/", uploadFolder, commonFolder);
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }
            
            return folder;
        }

        public static string GetUserFolder()
        {
            string uploadFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.UpLoadDirectory);
            string userLoginName = Nulls.IsNullOrEmpty(HttpContext.Current.Session[Constants.Session.USER_LOGINNAME])
                                  ? string.Empty
                                  : HttpUtility.HtmlDecode(HttpContext.Current.Session[Constants.Session.USER_LOGINNAME].ToString());
            string folder = string.Format("~/{0}/{1}/", uploadFolder, userLoginName);
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }
            
            return folder;
        }

        public static string GetUserFolderByDay()
        {
            string uploadFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.UpLoadDirectory);
            string userLoginName = Nulls.IsNullOrEmpty(HttpContext.Current.Session[Constants.Session.USER_LOGINNAME])
                                  ? string.Empty
                                  : HttpUtility.HtmlDecode(HttpContext.Current.Session[Constants.Session.USER_LOGINNAME].ToString());
            string folder =
                string.Format("~/{0}/{1}/{2}/{3}/{4}/", uploadFolder, userLoginName, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"));
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }
            
            return folder;
        }

        public static string GetSystemFolder()
        {
            string uploadFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.UpLoadDirectory);
            string folder = string.Format("~/{0}/", uploadFolder);
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }
            
            return folder;
        }

        public static string[] GetFileTypeSearchPatterns()
        {
            return
                Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.FileTypeAllow).Split(new char[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int GetMaxUploadFile()
        {
            return 1024 * Utilities.ParseInt(Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.MaxUploadFileSize));
        }

        public static int GetMaxUploadFileZip()
        {
            return 1024 * Utilities.ParseInt(Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.MaxUploadFileZipSize));
        }

        public static string GetFileType(string fileName)
        {
            string extension = fileName.Substring(fileName.LastIndexOf(".")).ToLower();
            string imageFileType = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.ImageFileType);
            if (imageFileType.IndexOf(extension) > -1) return MediaManagerConstants.FileType.Image;
            string audioFileType = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.AudioFileType);
            if (audioFileType.IndexOf(extension) > -1) return MediaManagerConstants.FileType.Audio;
            string videoFileType = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.VideoFileType);
            if (videoFileType.IndexOf(extension) > -1) return MediaManagerConstants.FileType.Video;
            string flashFileType = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.FlashFileType);
            if (flashFileType.IndexOf(extension) > -1) return MediaManagerConstants.FileType.Flash;

            return MediaManagerConstants.FileType.Other;
        }

        public static string GetPublicFolder()
        {
            string publicFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicDirectory);
            string folder =
                string.Format("~/{0}/{1}/{2}/{3}/{4}/", publicFolder, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }

            return folder;
        }

        public static string GetPublicImageFolder()
        {
            string publicFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicImageDirectory);
            string folder =
                string.Format("~/{0}/{1}/{2}/{3}/{4}/", publicFolder, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }

            return folder;
        }

        public static string GetPublicAudioFolder()
        {
            string publicFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicAudioDirectory);
            string folder =
                string.Format("~/{0}/{1}/{2}/{3}/{4}/", publicFolder, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }

            return folder;
        }

        public static string GetPublicVideoFolder()
        {
            string publicFolder = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicVideoDirectory);
            string folder =
                string.Format("~/{0}/{1}/{2}/{3}/{4}/", publicFolder, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            //create folder if not exist
            string strPhysicalPath = HttpContext.Current.Request.MapPath(folder);
            if (!Directory.Exists(strPhysicalPath))
            {
                Directory.CreateDirectory(strPhysicalPath);
            }

            return folder;
        }

        public static string GetPublicServerLink()
        {
            string serverLink = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicServerLink);
            if (Nulls.IsNullOrEmpty(serverLink))
            {
                if (HttpContext.Current.Request.Url.Port != 80)
                {
                    serverLink =
                        string.Format("{0}://{1}:{2}/{3}/", HttpContext.Current.Request.Url.Scheme,
                                  HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port,
                                  Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicDirectory));
                }
                else
                {
                    serverLink =
                        string.Format("{0}://{1}/{2}/", HttpContext.Current.Request.Url.Scheme,
                                  HttpContext.Current.Request.Url.Host,
                                  Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicDirectory));
                }
            }
            if (serverLink[serverLink.Length - 1] == '/')
            {
                serverLink = serverLink.Substring(0, serverLink.Length - 1);
            }
            return serverLink;
        }

        public static string GetPublicServerLinkFolder()
        {
            string serverLink = GetPublicServerLink();
            string link =
                string.Format("{0}/{1}/{2}/{3}/{4}/", serverLink, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            return link;
        }

        public static string GetImageServerLink()
        {
            string serverLink = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.ImageServerLink);
            if (Nulls.IsNullOrEmpty(serverLink))
            {
                if (HttpContext.Current.Request.Url.Port != 80)
                {
                    serverLink =
                        string.Format("{0}://{1}:{2}/{3}/", HttpContext.Current.Request.Url.Scheme,
                                      HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port,
                                      Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicImageDirectory));
                }
                else //HttpContext.Current.Request.Url.Port == 80
                {
                    serverLink =
                        string.Format("{0}://{1}/{2}/", HttpContext.Current.Request.Url.Scheme,
                                      HttpContext.Current.Request.Url.Host,
                                      Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicImageDirectory));
                }
            }
            if (serverLink[serverLink.Length - 1] == '/')
            {
                serverLink = serverLink.Substring(0, serverLink.Length - 1);
            }
            return serverLink;
        }

        public static string GetImageServerLinkFolder()
        {
            string serverLink = GetImageServerLink();
            string link =
                string.Format("{0}/{1}/{2}/{3}/{4}/", serverLink, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            return link;
        }

        public static string GetAudioServerLink()
        {
            string serverLink = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.AudioServerLink);
            if (Nulls.IsNullOrEmpty(serverLink))
            {
                if (HttpContext.Current.Request.Url.Port != 80)
                {
                    serverLink =
                        string.Format("{0}://{1}:{2}/{3}/", HttpContext.Current.Request.Url.Scheme,
                                  HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port,
                                  Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicAudioDirectory));
                }
                else
                {
                    serverLink =
                        string.Format("{0}://{1}/{2}/", HttpContext.Current.Request.Url.Scheme,
                                  HttpContext.Current.Request.Url.Host,
                                  Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicAudioDirectory));
                }
            }
            if (serverLink[serverLink.Length - 1] == '/')
            {
                serverLink = serverLink.Substring(0, serverLink.Length - 1);
            }
            return serverLink;
        }

        public static string GetAudioServerLinkFolder()
        {
            string serverLink = GetAudioServerLink();
            string link =
                string.Format("{0}/{1}/{2}/{3}/{4}/", serverLink, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            return link;
        }

        public static string GetVideoServerLink()
        {
            string serverLink = Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.VideoServerLink);
            if (Nulls.IsNullOrEmpty(serverLink))
            {
                if (HttpContext.Current.Request.Url.Port != 80)
                {
                    serverLink =
                        string.Format("{0}://{1}:{2}/{3}/", HttpContext.Current.Request.Url.Scheme,
                                  HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port,
                                  Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicVideoDirectory));
                }
                else
                {
                    serverLink =
                        string.Format("{0}://{1}/{2}/", HttpContext.Current.Request.Url.Scheme,
                                  HttpContext.Current.Request.Url.Host, 
                                  Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.PublicVideoDirectory));
                }
            }
            if (serverLink[serverLink.Length - 1] == '/')
            {
                serverLink = serverLink.Substring(0, serverLink.Length - 1);
            }
            return serverLink;
        }

        public static string GetVideoServerLinkFolder()
        {
            string serverLink = GetVideoServerLink();
            string link =
                string.Format("{0}/{1}/{2}/{3}/{4}/", serverLink, DateTime.Now.Year.ToString("0000"),
                              DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"),
                              DateTime.Now.Hour.ToString("00"));
            return link;
        }
    }
}