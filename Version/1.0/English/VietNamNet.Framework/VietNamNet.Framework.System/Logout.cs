using System.Web;
using System.Web.SessionState;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.System
{
    public class Logout : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //Log
            SystemLogging.System("Logout!");
            //Clear Session
            context.Session.Clear();
            //Goback to view
            context.Response.Redirect(Constants.FormNames.Root);
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}