using System.Data;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Advertisement.Presentation
{
    /// <summary>
    /// Summary description for AdvertisementBlockHelper.
    /// </summary>
    public class AdvertisementBlockHelper
    {
        private AdvertisementBlock o;

        #region AdvertisementBlockHelper(AdvertisementBlock o)

        public AdvertisementBlockHelper(AdvertisementBlock o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AdvertisementBlock ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = AdvertisementConstants.Services.AdvertisementBlockManager.Name;
            if (ValueObject.Items != null)
            {
                ValueObject.Items.TableName = AdvertisementConstants.Entities.AdvertisementBlock.Items;
                p.RawData.Tables.Add(ValueObject.Items.Copy());
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
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementBlock;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementBlock;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementBlock;
            if (ValueObject != null)
            {
                ValueObject.Items = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items];
            }
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = AdvertisementConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AdvertisementBlock;
            if (ValueObject != null)
            {
                ValueObject.Items = p.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items];
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