using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for PolicyHelper.
    /// </summary>
    public class PolicyHelper
    {
        private Policy o;

        #region PolicyHelper(Policy o)

        public PolicyHelper(Policy o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Policy ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.PolicyManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Policy;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Policy;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Policy;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Policy;
        }

        #endregion

        #region ListAll

        public DataTable ListAll()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetPolicy

        public DataTable GetPolicy()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.PolicyManager.Actions.GetPolicy;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetPolicyByGroup

        public DataTable GetPolicyByGroup()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.PolicyManager.Actions.GetPolicyByGroup;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region SavePolicyByGroup

        public void SavePolicyByGroup(DataTable dt)
        {
            Packet p = GetPacket();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt.Copy());
            p.Action = SystemConstants.Services.PolicyManager.Actions.SavePolicyByGroup;
            ServiceFacade.Execute(p);
        }

        #endregion

        #region GetPolicyByModule

        public DataTable GetPolicyByModule()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.PolicyManager.Actions.GetPolicyByModule;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region SavePolicyByModule

        public void SavePolicyByModule(DataTable dt)
        {
            Packet p = GetPacket();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt.Copy());
            p.Action = SystemConstants.Services.PolicyManager.Actions.SavePolicyByModule;
            ServiceFacade.Execute(p);
        }

        #endregion
    }
}