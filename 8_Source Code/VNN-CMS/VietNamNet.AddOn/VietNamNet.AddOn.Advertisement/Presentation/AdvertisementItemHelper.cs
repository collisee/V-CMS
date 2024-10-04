using System.Data;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Advertisement.Presentation
{
    /// <summary>
    /// Summary description for AdvertisementItemHelper.
    /// </summary>
    public class AdvertisementItemHelper
    {
        private AdvertisementItem o;

        #region AdvertisementItemHelper(AdvertisementItem o)

        public AdvertisementItemHelper(AdvertisementItem o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AdvertisementItem ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = AdvertisementConstants.Services.AdvertisementItemManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementItem;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementItem;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementItem;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementItem;
        }

        #endregion

        #region ListAll

        public DataTable ListAll()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}