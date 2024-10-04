using System;
using System.Reflection;

namespace VietNamNet.Framework.Biz
{
    public sealed class ServiceFacade
    {
        private static BizObject GetBizObject(string serviceName, string action)
        {
            BizObject bizObject = null;
            BizConfiguration bizConfig = BizConfiguration.GetConfig();
            string key = string.Format("{0}:{1}", serviceName, action);
            int indexOfKey = bizConfig.BizObjects.IndexOfKey(key);
            if (indexOfKey != -1)
            {
                bizObject = (BizObject)bizConfig.BizObjects.GetByIndex(indexOfKey);
            }
            else //Default action
            {
                string keyDefault = string.Format("{0}:Default", serviceName);
                int indexOfKeyDefault = bizConfig.BizObjects.IndexOfKey(keyDefault);
                if (indexOfKeyDefault != -1)
                {
                    bizObject = (BizObject)bizConfig.BizObjects.GetByIndex(indexOfKeyDefault);
                }
            }
            return bizObject;
        }

        private static Facade GetFacade(string serviceName, string action)
        {
            BizObject bizObject = (BizObject) GetBizObject(serviceName, action);
            Assembly assembly = Assembly.Load(bizObject.Assembly);
            Facade instance = assembly.CreateInstance(bizObject.Type) as Facade;

            return instance;
        }

        public static Packet Execute(Packet packet)
        {
            Facade instance = GetFacade(packet.ServiceName, packet.Action);
            if (instance == null)
            {
                throw new Exception(
                    string.Format("The service named {0} - action {1} was not configured.", packet.ServiceName,
                                  packet.Action));
            }

            return instance.Execute(packet);
        }
    }
}