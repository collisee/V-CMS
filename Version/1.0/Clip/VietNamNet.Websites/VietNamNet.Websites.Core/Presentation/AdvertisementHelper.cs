using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;

namespace VietNamNet.Websites.Core.Presentation
{
    public class AdvertisementHelper
    {
        private AdvertisementObject o;

        #region AdvertisementHelper(AdvertisementObject o)

        public AdvertisementHelper(AdvertisementObject o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AdvertisementObject ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = WebsitesConstants.Services.AdvertisementManager.Name;
            return p;
        }

        #endregion

        #region GetLayoutByCategoryId

        public DataTable GetLayoutByCategoryId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.AdvertisementManager.Actions.GetLayoutByCategoryId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetZonesByLayoutId

        public DataTable GetZonesByLayoutId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.AdvertisementManager.Actions.GetZonesByLayoutId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetBlocksByZoneId

        public DataTable GetBlocksByZoneId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.AdvertisementManager.Actions.GetBlocksByZoneId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetItemsByBlockId

        public DataTable GetItemsByBlockId()
        {
            Packet p = GetPacket();
            p.Action = WebsitesConstants.Services.AdvertisementManager.Actions.GetItemsByBlockId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}