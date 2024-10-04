using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for LoggingHelper.
    /// </summary>
    public class LoggingHelper
    {
        private Logging o;

        #region LoggingHelper(Logging o)

        public LoggingHelper(Logging o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Logging ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.LoggingManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Logging;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Logging;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Logging;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Logging;
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

        #region GetLogging

        public DataTable GetLogging()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.LoggingManager.Actions.GetLogging;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}