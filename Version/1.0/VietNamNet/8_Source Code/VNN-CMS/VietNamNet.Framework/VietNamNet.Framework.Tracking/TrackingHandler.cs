using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.Tracking
{
    public class TrackingHandler : IHttpHandler
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
            //segments: /, tracking/, execute.svr

            string serviceName = context.Request.QueryString[TrackingConstants.ParameterName.ServiceName];
            string action = context.Request.QueryString[TrackingConstants.ParameterName.Action];

            //check
            if (!TrackingUtils.CheckServiceName(serviceName)) return;

            //packet
            TrackingPacket packet = new TrackingPacket();
            packet.ServiceName = serviceName;
            packet.Action = action;
            packet.Parameters = new NameValueCollection(context.Request.QueryString.Count, context.Request.QueryString);

            //execute
            TrackingServiceProvider.Execute(packet);
        }

        #endregion
    }
}