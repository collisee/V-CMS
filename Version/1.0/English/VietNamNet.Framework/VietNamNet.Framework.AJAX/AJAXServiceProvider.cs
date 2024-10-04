using System;
using System.Reflection;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.AJAX
{
    public class AJAXServiceProvider
    {
        private static AJAXServiceObject GetServiceObject(string serviceName, string action)
        {
            AJAXServiceObject serviceObj = null;
            AJAXConfiguration ajaxConfig = AJAXConfiguration.GetConfig();
            string key = string.Format("{0}:{1}", serviceName, action);
            int indexOfKey = ajaxConfig.AJAXServices.IndexOfKey(key);
            if (indexOfKey != -1)
            {
                serviceObj = (AJAXServiceObject)ajaxConfig.AJAXServices.GetByIndex(indexOfKey);
            }
            else //Default action
            {
                string keyDefault = string.Format("{0}:Default", serviceName);
                int indexOfKeyDefault = ajaxConfig.AJAXServices.IndexOfKey(keyDefault);
                if (indexOfKeyDefault != -1)
                {
                    serviceObj = (AJAXServiceObject)ajaxConfig.AJAXServices.GetByIndex(indexOfKeyDefault);
                }
            }
            return serviceObj;
        }

        private static AJAXService GetService(string serviceName, string action)
        {
            AJAXService service;
            try
            {
                AJAXServiceObject serviceObject = (AJAXServiceObject)GetServiceObject(serviceName, action);
                Assembly assembly = Assembly.Load(serviceObject.Assembly);
                service = assembly.CreateInstance(serviceObject.Type) as AJAXService;
                if (service != null)
                {
                    service.NoCache = serviceObject.NoCache;
                    service.CacheTime = Utilities.ParseInt(serviceObject.CacheTime);
                    service.BeforeFilters = serviceObject.BeforeFilters;
                    service.AfterFilters = serviceObject.AfterFilters;
                }
            }
            catch (Exception ex)
            {
                service = null;
            }
            return service;
        }

        private static AJAXFilterObject GetFilterObject(string filterName)
        {
            AJAXFilterObject filterObj = null;
            AJAXConfiguration ajaxConfig = AJAXConfiguration.GetConfig();
            int indexOfKey = ajaxConfig.AJAXFilters.IndexOfKey(filterName);
            if (indexOfKey != -1)
            {
                filterObj = (AJAXFilterObject)ajaxConfig.AJAXFilters.GetByIndex(indexOfKey);
            }
            return filterObj;
        }

        private static AJAXFilter GetFilter(string filterName)
        {
            AJAXFilter filter;
            try
            {
                AJAXFilterObject filterObject = (AJAXFilterObject)GetFilterObject(filterName);
                Assembly assembly = Assembly.Load(filterObject.Assembly);
                filter = assembly.CreateInstance(filterObject.Type) as AJAXFilter;
            }
            catch (Exception ex)
            {
                filter = null;
            }
            return filter;
        }

        private static AJAXPacket FilterExecute(AJAXPacket packet, string filterName, ref bool flag)
        {
            AJAXFilter filter = GetFilter(filterName);
            if (filter == null)
            {
                packet.Type = AJAXType.HTML;
                packet.Value = "AJAX Configuration: The filter named " + filterName +
                               " was not configured or configured wrong or not implemented.";
                flag = false;
                return packet;
            }
            return filter.Process(packet, ref flag);
        }

        public static AJAXPacket Execute(AJAXPacket packet)
        {
            AJAXService service = GetService(packet.ServiceName, packet.Action);
            if (service == null)
            {
                packet.Type = AJAXType.HTML;
                packet.Value = "AJAX Configuration: The service named " + packet.ServiceName +
                               " was not configured or configured wrong or not implemented.";
                return packet;
            }

            //Get Cache
            if (!service.NoCache)
            {
                AJAXPacket pCache = AJAXCacheFilter.GetCache();
                if (pCache != null)
                {
                    return pCache;
                }
            }

            //Before Filteres
            bool blnFilter = true;
            if (!Utilities.StringCompare(service.BeforeFilters, "None"))
            {
                foreach (string filterName in service.BeforeFilters.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    packet = FilterExecute(packet, filterName, ref blnFilter);
                    if (!blnFilter) return packet;
                }
            }

            //Execute
            service.Execute(packet);

            //Before Filteres
            blnFilter = true;
            if (!Utilities.StringCompare(service.AfterFilters, "None"))
            {
                foreach (string filterName in service.AfterFilters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    packet = FilterExecute(packet, filterName, ref blnFilter);
                    if (!blnFilter) return packet;
                }
            }

            //Set Cache
            if (!service.NoCache)
            {
                if (service.CacheTime > 0)
                {
                    AJAXCacheFilter.SetCache(packet, service.CacheTime);
                }
                else
                {
                    AJAXCacheFilter.SetCache(packet);
                }
            }

            return packet;
        }
    }
}