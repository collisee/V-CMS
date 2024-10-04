using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Messages.Common.ValueObject
{
    public class Message : BaseObject
    {
        #region Members

        protected string detail;
        protected int msgType;
        protected string name;

        private int receiverId;
        protected string status;
        protected string subject;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column MsgType(int,not null)
        /// </summary>
        public int MsgType
        {
            get { return msgType; }
            set { msgType = value; }
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
        /// Property relating to database column Name(nvarchar(255),not null)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property relating to database column Subject(nvarchar(255),not null)
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(ntext,not null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }


        public int ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        #endregion
    }
}