using System.Web;
using VietNamNet.Framework.Common;

namespace VietNamNet.Websites.Core
{
    public class SystemIntergration : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string file = HttpUtility.UrlDecode(context.Request.Url.AbsolutePath);

            if (!Nulls.IsNullOrEmpty(file))
            {
                if (Utilities.FileSystem.FileExists(file))
                {
                    //get file
                    file = context.Server.MapPath(file);

                    context.Response.WriteFile(file);
                }
                else //if not exist
                {
                    context.Response.Redirect("~/");
                }
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}