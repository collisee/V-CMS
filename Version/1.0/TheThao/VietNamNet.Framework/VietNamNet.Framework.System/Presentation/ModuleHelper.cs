using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for ModuleHelper.
    /// </summary>
    public class ModuleHelper
    {
        private ValueObject.Module o;

        #region ModuleHelper(System.ValueObject.Module o)

        public ModuleHelper(ValueObject.Module o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public ValueObject.Module ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.ModuleManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ValueObject.Module;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ValueObject.Module;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ValueObject.Module;
        }

        #endregion

        #region GetModuleByAlias

        public void GetModuleByAlias()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.ModuleManager.Actions.GetModuleByAlias;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ValueObject.Module;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ValueObject.Module;
        }

        #endregion

        #region ListAll

        public DataTable ListAll()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}