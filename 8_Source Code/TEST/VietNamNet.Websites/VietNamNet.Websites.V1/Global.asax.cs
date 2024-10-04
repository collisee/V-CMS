using System;
using System.IO.Compression;
using System.Web;

namespace VietNamNet.Websites.V1
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Global_PostReleaseRequestState(object sender, EventArgs e)
        {
            string contentType = Response.ContentType;

            if (//contentType == "text/html" ||
                contentType == "text/css" || 
                contentType == "application/x-javascript" ||
                contentType == "text/javascript")
            {
                Response.Cache.VaryByHeaders["Accept-Encoding"] = true;

                string acceptEncoding =
                    Request.Headers["Accept-Encoding"];

                if (acceptEncoding != null)
                {
                    if (acceptEncoding.Contains("gzip"))
                    {
                        Response.Filter = new GZipStream(
                            Response.Filter, CompressionMode.Compress);
                        Response.AppendHeader(
                            "Content-Encoding", "gzip");
                    }
                    else if (acceptEncoding.Contains("deflate"))
                    {
                        Response.Filter = new DeflateStream(
                            Response.Filter, CompressionMode.Compress);
                        Response.AppendHeader(
                            "Content-Encoding", "deflate");
                    }
                }
            }
        }
    }
}