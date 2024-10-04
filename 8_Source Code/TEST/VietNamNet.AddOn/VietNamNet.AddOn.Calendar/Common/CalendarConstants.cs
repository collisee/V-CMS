using VietNamNet.Framework.Module;

/// <summary>
/// Constants of VietNamNet.AddOn.Calendar
/// </summary>
namespace VietNamNet.AddOn.Calendar.Common
{
    public class CalendarConstants
    {
        #region Entities

        public class Entities : BaseEntities
        {
            #region Appointment

            public class Appointment
            {
                public const string Name = "Appointment";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string AppointmentTypeId = "AppointmentTypeId";
                    public const string EndTime = "EndTime";
                    public const string RecurrenceParentID = "RecurrenceParentID";
                    public const string RecurrenceRule = "RecurrenceRule";
                    public const string StartTime = "StartTime";
                    public const string Subject = "Subject";
                }

                #endregion
            }

            #endregion

            #region AppointmentType

            public class AppointmentType
            {
                public const string Name = "AppointmentType";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region Room

            public class Room
            {
                public const string Name = "Room";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string Detail = "Detail";
                    public const string Name = "Name";
                }

                #endregion
            }

            #endregion

            #region RoomBooking

            public class RoomBooking
            {
                public const string Name = "RoomBooking";

                #region Nested type: FieldName

                public class FieldName : BaseFieldName
                {
                    public const string EndTime = "EndTime";
                    public const string RecurrenceParentID = "RecurrenceParentID";
                    public const string RecurrenceRule = "RecurrenceRule";
                    public const string RoomId = "RoomId";
                    public const string StartTime = "StartTime";
                    public const string Subject = "Subject";
                }

                #endregion
            }

            #endregion
        }

        #endregion

        #region Services

        public class Services : BaseServices
        {
            #region AppointmentManager

            public class AppointmentManager
            {
                public const string Name = "AppointmentManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region AppointmentTypeManager

            public class AppointmentTypeManager
            {
                public const string Name = "AppointmentTypeManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region RoomManager

            public class RoomManager
            {
                public const string Name = "RoomManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion

            #region RoomBookingManager

            public class RoomBookingManager
            {
                public const string Name = "RoomBookingManager";

                #region Nested type: Actions

                public class Actions : CommonActions
                {
                }

                #endregion
            }

            #endregion
        }

        #endregion
    }
}