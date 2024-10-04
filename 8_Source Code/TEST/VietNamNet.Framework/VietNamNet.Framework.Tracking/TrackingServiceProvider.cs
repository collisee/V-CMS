using System;
using System.Reflection;

namespace VietNamNet.Framework.Tracking
{
    public class TrackingServiceProvider
    {
        private static TrackingServiceObject GetServiceObject(string serviceName, string action)
        {
            TrackingServiceObject serviceObj = null;
            TrackingConfiguration ajaxConfig = TrackingConfiguration.GetConfig();
            string key = string.Format("{0}:{1}", serviceName, action);
            int indexOfKey = ajaxConfig.TrackingServices.IndexOfKey(key);
            if (indexOfKey != -1)
            {
                serviceObj = (TrackingServiceObject)ajaxConfig.TrackingServices.GetByIndex(indexOfKey);
            }
            else //Default action
            {
                string keyDefault = string.Format("{0}:Default", serviceName);
                int indexOfKeyDefault = ajaxConfig.TrackingServices.IndexOfKey(keyDefault);
                if (indexOfKeyDefault != -1)
                {
                    serviceObj = (TrackingServiceObject)ajaxConfig.TrackingServices.GetByIndex(indexOfKeyDefault);
                }
            }
            return serviceObj;
        }

        private static TrackingService GetService(string serviceName, string action)
        {
            TrackingService service;
            try
            {
                TrackingServiceObject serviceObject = (TrackingServiceObject)GetServiceObject(serviceName, action);
                Assembly assembly = Assembly.Load(serviceObject.Assembly);
                service = assembly.CreateInstance(serviceObject.Type) as TrackingService;
            }
            catch (Exception ex)
            {
                //service = null;
                service = new TrackingServiceDefault();
            }
            return service;
        }

        public static void Execute(TrackingPacket packet)
        {
            TrackingService service = GetService(packet.ServiceName, packet.Action);
            if (service != null)
            {
                //Execute
                service.Execute(packet);
            }
        }
    }
}