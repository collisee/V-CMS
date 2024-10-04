using System.Data;
using VietNamNet.AddOn.Calendar.Common;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Calendar.Presentation
{
    /// <summary>
    /// Summary description for RoomBookingHelper.
    /// </summary>
    public class RoomBookingHelper
    {
        private Common.ValueObject.RoomBooking o;

        #region RoomBookingHelper(RoomBooking o)

        public RoomBookingHelper(Common.ValueObject.RoomBooking o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Common.ValueObject.RoomBooking ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CalendarConstants.Services.RoomBookingManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Common.ValueObject.RoomBooking;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Common.ValueObject.RoomBooking;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Common.ValueObject.RoomBooking;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Common.ValueObject.RoomBooking;
        }

        #endregion

        #region ListAll

        public DataTable ListAll()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}