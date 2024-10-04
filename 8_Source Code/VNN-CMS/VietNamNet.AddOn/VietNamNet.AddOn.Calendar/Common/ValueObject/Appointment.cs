using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Calendar.Common.ValueObject
{
    public class Appointment : BaseObject
    {
        #region Members

        protected int appointmentTypeId;
        protected DateTime endTime;
        protected int recurrenceParentID;
        protected string recurrenceRule;
        protected DateTime startTime;
        protected string subject;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column Subject(nvarchar(4000),not null)
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// Property relating to database column StartTime(datetime,not null)
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// Property relating to database column EndTime(datetime,not null)
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        /// <summary>
        /// Property relating to database column RecurrenceRule(nvarchar(4000),null)
        /// </summary>
        public string RecurrenceRule
        {
            get { return recurrenceRule; }
            set { recurrenceRule = value; }
        }

        /// <summary>
        /// Property relating to database column RecurrenceParentID(int,null)
        /// </summary>
        public int RecurrenceParentID
        {
            get { return recurrenceParentID; }
            set { recurrenceParentID = value; }
        }

        /// <summary>
        /// Property relating to database column AppointmentTypeId(int,not null)
        /// </summary>
        public int AppointmentTypeId
        {
            get { return appointmentTypeId; }
            set { appointmentTypeId = value; }
        }

        #endregion
    }
}