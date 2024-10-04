using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using AjaxPro;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.AJAX
{
    public class AJAXHandler : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler's implement

        public void ProcessRequest(HttpContext context)
        {
            ExecuteAction(context);
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #endregion

        #region Private Method

        private void ExecuteAction(HttpContext context)
        {
            //Segments: /, ajax/, serviceName/, action/, index.html
            string[] arrSegments = context.Request.Url.Segments;
            string serviceName = arrSegments.Length > 3
                                     ? arrSegments[2].Substring(0, arrSegments[2].Length - 1)
                                     : string.Empty; //Remove "/"
            string action = arrSegments.Length > 4
                                ? arrSegments[3].Substring(0, arrSegments[3].Length - 1)
                                : string.Empty; //Remove "/"
            if (Nulls.IsNullOrEmpty(serviceName))
            {
                context.Response.Write(" ");
                return;
            }

            AJAXPacket packet = new AJAXPacket();
            packet.ServiceName = serviceName;
            packet.Action = action;
            //packet.Parameters = context.Request.QueryString;
            packet.Parameters = new NameValueCollection(context.Request.QueryString.Count, context.Request.QueryString);
            packet.Status = AJAXStatus.Start;

            packet = AJAXServiceProvider.Execute(packet);
            string result;
            switch (packet.Type)
            {
                case AJAXType.XML:
                    result = Convertor.ToString(packet.Value);
                    break;
                case AJAXType.JavaScriptObject:
                    result = JavaScriptSerializer.Serialize(packet.Value);
                    break;
                case AJAXType.HTML:
                default:
                    result = Nulls.IsNullOrEmpty(packet.Value) ? string.Empty : packet.Value.ToString();
                    break;
            }

            context.Response.Write(result);
        }

        #endregion
    }
}