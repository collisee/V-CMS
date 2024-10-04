using System;
using System.Drawing.Imaging;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.ImageUtility;

namespace VietNamNet.Framework.Common
{
    public class ViewThumbnail : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string filePath = context.Request.QueryString[Constants.ParameterName.FILEPATH];
            string file = Nulls.IsNullOrEmpty(filePath)
                              ? context.Request.QueryString[Constants.ParameterName.FILE]
                              : filePath;
            int width = Utilities.ParseInt(context.Request.QueryString[Constants.ParameterName.WIDTH]);
            int height = Utilities.ParseInt(context.Request.QueryString[Constants.ParameterName.HEIGHT]);

            width = (width <= 0) ? Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.ThumbnailWidth)) : width;
            height = (height <= 0) ? Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.ThumbnailHeight)) : height;

            width = (width <= 0) ? 100 : width;
            height = (height <= 0) ? 56 : height;

            if (!Nulls.IsNullOrEmpty(file))
            {
                if (file.IndexOf("http://") > -1) //remove domain
                {
                    file = file.Replace("http://", string.Empty);
                    int index = file.IndexOf("/");
                    if (index > -1) file = file.Substring(index);
                }

                if (Utilities.FileSystem.FileExists(file))
                {
                    file = context.Server.MapPath(file);
                    context.Response.ContentType = "image/gif";
                    context.Response.Expires = 7*24*60; //7 days x 24 hours x 60 minutes
                    context.Response.Cookies.Clear(); //clear cookie
                    context.Response.Cache.SetExpires(DateTime.Now.AddDays(7));
                    ImageUtils.Thumbnail(file, width, height, false, ImageFormat.Gif, context.Response.OutputStream);
                }
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }

    }
}