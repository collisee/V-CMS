using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for FunctionHelper.
    /// </summary>
    public class FunctionHelper
    {
        private Function o;

        #region FunctionHelper(Function o)

        public FunctionHelper(Function o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Function ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.FunctionManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Function;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Function;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Function;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Function;
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

        #region GetFunctionByAlias

        public void GetFunctionByAlias()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.FunctionManager.Actions.GetFunctionByAlias;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Function;
        }

        #endregion

        #region GetFunctionByModuleId

        public DataTable GetFunctionByModuleId()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.FunctionManager.Actions.GetFunctionByModuleId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #endregion
    }
}