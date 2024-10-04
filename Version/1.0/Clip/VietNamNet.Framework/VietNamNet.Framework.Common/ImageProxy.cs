/************************************************************************/
/* File Name  : ImageProxy.cs                                           */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.Framework.Common                          */
/* Product Version : 1.0                                                */
/* Creator : Dao Tuan Anh                                               */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/*                                                                      */
/* File history                                                         */
/* 11/09/2010 File Create                                               */
/* 14/09/2011 Update Url check name                                     */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using VietNamNet.Framework.ImageUtility;

namespace VietNamNet.Framework.Common
{
    public class ImageProxy : IHttpHandler
    {
        #region Implement Method

        public void ProcessRequest(HttpContext context)
        {
            int width = Utilities.ParseInt(context.Request.QueryString[Constants.ParameterName.WIDTH2]);
            int height = Utilities.ParseInt(context.Request.QueryString[Constants.ParameterName.HEIGHT2]);

            string file = HttpUtility.UrlDecode(context.Request.Url.AbsolutePath);
            string extension = file.Substring(file.LastIndexOf("."));

            if (!Nulls.IsNullOrEmpty(file))
            {
                if (Utilities.FileSystem.FileExists(file))
                {
                    //get file
                    file = context.Server.MapPath(file);

                    //Set Content Type
                    context.Response.ContentType = GetImageContentType(extension);
                    //context.Response.Expires = 7 * 24 * 60; //7 days x 24 hours x 60 minutes
                    context.Response.Cookies.Clear(); //clear cookie
                    context.Response.Cache.SetExpires(DateTime.Now.AddDays(7)); //Set Cache
                    //context.Response.Cache.SetETag(file);
                    context.Response.Cache.SetLastModified(File.GetLastWriteTime(file)); // get last modified file

                    //check width & height
                    if (width <= 0 && height <= 0)
                    {
                        if (Utilities.StringCompare(extension, ".png")) //PNG
                        {
                            Image img = ImageUtils.GetImage(file);
                            MemoryStream ms = new MemoryStream();

                            img.Save(ms, GetImageFormat(extension));
                            ms.WriteTo(context.Response.OutputStream);

                            img.Dispose();
                        }
                        else
                        {
                            Image img = ImageUtils.GetImage(file);
                            img.Save(context.Response.OutputStream, GetImageFormat(extension));
                            img.Dispose();
                        }
                    }
                    else
                    {
                        if (width <= 0)
                        {
                            Image img = ImageUtils.GetImage(file);
                            width = (img.Width*height)/img.Height;
                        }
                        if (height <= 0)
                        {
                            Image img = ImageUtils.GetImage(file);
                            height = (img.Height * width) / img.Width;
                        }

                        if (Utilities.StringCompare(extension, ".png")) //PNG
                        {
                            Image img = ImageUtils.GetImage(file);
                            MemoryStream ms = new MemoryStream();

                            ImageUtils.Crop(file, width, height, GetImageFormat(extension), ms);
                            ms.WriteTo(context.Response.OutputStream);

                            img.Dispose();
                        }
                        else
                        {
                            ImageUtils.Crop(file, width, height, GetImageFormat(extension), context.Response.OutputStream);
                            //ImageUtils.Thumbnail(file, width, height, false, GetImageFormat(extension), context.Response.OutputStream);
                        }
                    }
                }
                else //blank.gif
                {
                    file = context.Server.MapPath(Utilities.GetConfigKey(Constants.ConfigKey.ImageBlank));
                    extension = file.Substring(file.LastIndexOf("."));

                    //Set Content Type
                    context.Response.ContentType = GetImageContentType(extension);
                    //context.Response.Expires = 7 * 24 * 60; //7 days x 24 hours x 60 minutes
                    context.Response.Cookies.Clear(); //clear cookie
                    context.Response.Cache.SetExpires(DateTime.Now.AddDays(7)); //Set Cache
                    //context.Response.Cache.SetETag(file);
                    context.Response.Cache.SetLastModified(File.GetLastWriteTime(file)); // get last modified file
                    if (Utilities.StringCompare(extension, ".png")) //PNG
                    {
                        Image img = ImageUtils.GetImage(file);
                        MemoryStream ms = new MemoryStream();

                        img.Save(ms, GetImageFormat(extension));
                        ms.WriteTo(context.Response.OutputStream);

                        img.Dispose();
                    }
                    else
                    {
                        Image img = ImageUtils.GetImage(file);
                        img.Save(context.Response.OutputStream, GetImageFormat(extension));
                        img.Dispose();
                    }
                }
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #endregion

        #region Private Method

        /**
         * Method Name: GetImageFormat
         * Parameters:
         *      string extension
         * Return: ImageFormat of extension
         */
        private ImageFormat GetImageFormat(string extension)
        {
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".png":
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        /**
         * Method Name: GetImageContentType
         * Parameters:
         *      string extension
         * Return: Content Type of extension
         */
        private string GetImageContentType(string extension)
        {
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".gif":
                    return "image/gif";
                case ".png":
                    return "image/png";
                default:
                    return "image/jpeg";
            }
        }

        #endregion
    }
}