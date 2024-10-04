using System;
using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class User : BaseObject
    {
        #region Members

        protected string address;
        protected string avatar;
        protected DateTime birthday;
        protected string email;
        protected string fullName;
        protected DateTime lastLogin;
        protected string loginName;
        protected string mobile;
        protected string password;
        protected string phone;
        protected string sex;
        protected string status;
        protected int groupId;
        protected DataTable memberOf;

        protected string skype;
        protected string skin;
        protected string yahoo;
        protected string facebook;
        protected string detail;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column Status(nvarchar(255),not null)
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Property relating to database column LoginName(nvarchar(255),not null)
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        /// <summary>
        /// Property relating to database column Email(nvarchar(255),not null)
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Property relating to database column Avatar(nvarchar(255),not null)
        /// </summary>
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        /// <summary>
        /// Property relating to database column Birthday(datetime,not null)
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        /// <summary>
        /// Property relating to database column Sex(nvarchar(50),not null)
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// Property relating to database column FullName(nvarchar(255),not null)
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        /// <summary>
        /// Property relating to database column Password(nvarchar(255),not null)
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Property relating to database column Address(nvarchar(255),not null)
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Property relating to database column Phone(nvarchar(255),not null)
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// Property relating to database column Mobile(nvarchar(255),not null)
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        /// <summary>
        /// Property relating to database column LastLogin(datetime, null)
        /// </summary>
        public DateTime LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }

        public DataTable MemberOf
        {
            get { return memberOf; }
            set { memberOf = value; }
        }

        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public string Skype
        {
            get { return skype; }
            set { skype = value; }
        }

        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        public string Yahoo
        {
            get { return yahoo; }
            set { yahoo = value; }
        }

        public string Facebook
        {
            get { return facebook; }
            set { facebook = value; }
        }

        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        #endregion
    }
}