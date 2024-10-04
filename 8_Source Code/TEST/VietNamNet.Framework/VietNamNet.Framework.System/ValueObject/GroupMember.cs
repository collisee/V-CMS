using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class GroupMember : BaseObject
    {
        #region Members

        protected int groupId;
        protected int userId;
        protected string loginName;
        protected string fullName;
        protected string groupName;
        protected string saveStatus;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column GroupId(int,not null)
        /// </summary>
        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        /// <summary>
        /// Property relating to database column UserId(int,not null)
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string SaveStatus
        {
            get { return saveStatus; }
            set { saveStatus = value; }
        }

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        #endregion
    }
}