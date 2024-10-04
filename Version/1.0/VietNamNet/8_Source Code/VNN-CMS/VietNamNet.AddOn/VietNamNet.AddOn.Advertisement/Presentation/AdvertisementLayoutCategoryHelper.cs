using System.Data;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Advertisement.Presentation
{
    /// <summary>
    /// Summary description for AdvertisementLayoutCategoryHelper.
    /// </summary>
    public class AdvertisementLayoutCategoryHelper
    {
        private AdvertisementLayoutCategory o;

        #region AdvertisementLayoutCategoryHelper(AdvertisementLayoutCategory o)

        public AdvertisementLayoutCategoryHelper(AdvertisementLayoutCategory o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AdvertisementLayoutCategory ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = AdvertisementConstants.Services.AdvertisementLayoutCategoryManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayoutCategory;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayoutCategory;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayoutCategory;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayoutCategory;
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