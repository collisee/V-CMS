using System.Data;
using VietNamNet.AddOn.Calendar.Common;
using VietNamNet.AddOn.Calendar.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.AddOn.Calendar.Presentation
{
    /// <summary>
    /// Summary description for AppointmentTypeHelper.
    /// </summary>
    public class AppointmentTypeHelper
    {
        private AppointmentType o;

        #region AppointmentTypeHelper(AppointmentType o)

        public AppointmentTypeHelper(AppointmentType o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public AppointmentType ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CalendarConstants.Services.AppointmentTypeManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AppointmentType;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AppointmentType;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AppointmentType;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = CalendarConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as AppointmentType;
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