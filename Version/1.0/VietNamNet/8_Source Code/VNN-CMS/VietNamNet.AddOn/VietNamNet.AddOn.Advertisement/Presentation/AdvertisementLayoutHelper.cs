using System.Data;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Advertisement.Presentation
{
    /// <summary>
    /// Summary description for AdvertisementLayoutHelper.
    /// </summary>
    public class AdvertisementLayoutHelper
    {
        private AdvertisementLayout o;

        #region AdvertisementLayoutHelper(AdvertisementLayout o)

        public AdvertisementLayoutHelper(AdvertisementLayout o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AdvertisementLayout ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = AdvertisementConstants.Services.AdvertisementLayoutManager.Name;
            if (ValueObject.Categories != null)
            {
                ValueObject.Categories.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Categories;
                p.RawData.Tables.Add(ValueObject.Categories.Copy());
            }
            if (ValueObject.Zones != null)
            {
                ValueObject.Zones.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Zones;
                p.RawData.Tables.Add(ValueObject.Zones.Copy());
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
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayout;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayout;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayout;
            if (ValueObject != null)
            {
                ValueObject.Zones = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones];
                ValueObject.Categories = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories];
            }
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementLayout;
            if (ValueObject != null)
            {
                ValueObject.Zones = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones];
                ValueObject.Categories = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories];
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