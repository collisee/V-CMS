using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for ConfigurationHelper.
    /// </summary>
    public class ConfigurationHelper
    {
        private Configuration o;

        #region ConfigurationHelper(Configuration o)

        public ConfigurationHelper(Configuration o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Configuration ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.ConfigurationManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Configuration;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Configuration;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Configuration;
        }

        #endregion

        #region GetConfiguration

        public void GetConfiguration()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.ConfigurationManager.Actions.GetConfiguration;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Configuration;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Configuration;
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