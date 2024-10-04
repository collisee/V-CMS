using System.Data;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.AddOn.Messages.Common.ValueObject;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Messages.Presentation
{
    /// <summary>
    /// Summary description for MessageHelper.
    /// </summary>
    public class MessageHelper
    {
        private Message o;

        #region MessageHelper(Message o)

        public MessageHelper(Message o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Message ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = MessagesConstants.Services.MessageManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Message;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Message;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Message;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Message;
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

        #region GetNewPrivateMessages

        public DataTable GetNewPrivateMessages()
        {
            Packet p = GetPacket();
            p.Action = MessagesConstants.Services.MessageManager.Actions.GetNewPrivateMessages;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}