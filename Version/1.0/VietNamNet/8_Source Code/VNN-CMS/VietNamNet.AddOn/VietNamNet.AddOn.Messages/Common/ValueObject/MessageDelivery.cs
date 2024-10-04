using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Messages.Common.ValueObject
{
    public class MessageDelivery : BaseObject
    {
        #region Members

        private string detail;
        protected int fromUserId;
        protected int messageId;
        protected string status;
        private string subject;
        protected int toUserId;
        private string userName;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column MessageId(int,not null)
        /// </summary>
        public int MessageId
        {
            get { return messageId; }
            set { messageId = value; }
        }

        /// <summary>
        /// Property relating to database column Status(nvarchar(255),not null)
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Property relating to database column FromUserId(int,not null)
        /// </summary>
        public int FromUserId
        {
            get { return fromUserId; }
            set { fromUserId = value; }
        }

        /// <summary>
        /// Property relating to database column ToUserId(int,not null)
        /// </summary>
        public int ToUserId
        {
            get { return toUserId; }
            set { toUserId = value; }
        }

        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        #endregion
    }
}