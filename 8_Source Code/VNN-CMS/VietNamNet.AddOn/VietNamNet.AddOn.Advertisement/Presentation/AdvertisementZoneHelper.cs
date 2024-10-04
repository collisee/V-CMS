using System.Data;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Advertisement.Presentation
{
    /// <summary>
    /// Summary description for AdvertisementZoneHelper.
    /// </summary>
    public class AdvertisementZoneHelper
    {
        private AdvertisementZone o;

        #region AdvertisementZoneHelper(AdvertisementZone o)

        public AdvertisementZoneHelper(AdvertisementZone o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AdvertisementZone ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = AdvertisementConstants.Services.AdvertisementZoneManager.Name;
            if (ValueObject.Blocks != null)
            {
                ValueObject.Blocks.TableName = AdvertisementConstants.Entities.AdvertisementZone.Blocks;
                p.RawData.Tables.Add(ValueObject.Blocks.Copy());
            }
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementZone;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementZone;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementZone;
            if (ValueObject != null)
            {
                ValueObject.Blocks = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks];
            }
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementZone;
            if (ValueObject != null)
            {
                ValueObject.Blocks = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks];
            }
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