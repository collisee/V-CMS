using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Logging : BaseObject
    {
        #region Members

        protected string action;
        protected string detail;
        protected string iP;
        private DateTime loggingFromDate;
        private DateTime loggingToDate;
        protected int logLevel;
        private int logUser;
        protected DateTime logTime;
        protected int uId;
        protected string userFullName;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column LogTime(datetime,not null)
        /// </summary>
        public DateTime LogTime
        {
            get { return logTime; }
            set { logTime = value; }
        }

        /// <summary>
        /// Property relating to database column LogLevel(int,not null)
        /// </summary>
        public int LogLevel
        {
            get { return logLevel; }
            set { logLevel = value; }
        }

        /// <summary>
        /// Property relating to database column IP(nvarchar(50),not null)
        /// </summary>
        public string IP
        {
            get { return iP; }
            set { iP = value; }
        }

        /// <summary>
        /// Property relating to database column UId(int,not null)
        /// </summary>
        public int UId
        {
            get { return uId; }
            set { uId = value; }
        }

        /// <summary>
        /// Property relating to database column UserFullName(nvarchar(255),not null)
        /// </summary>
        public string UserFullName
        {
            get { return userFullName; }
            set { userFullName = value; }
        }

        /// <summary>
        /// Property relating to database column Action(nvarchar(255),not null)
        /// </summary>
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(nvarchar(4000),null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public DateTime LoggingFromDate
        {
            get { return loggingFromDate; }
            set { loggingFromDate = value; }
        }

        public DateTime LoggingToDate
        {
            get { return loggingToDate; }
            set { loggingToDate = value; }
        }

        public int LogUser
        {
            get { return logUser; }
            set { logUser = value; }
        }

        #endregion
    }
}