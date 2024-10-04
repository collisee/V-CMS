using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Policy : BaseObject
    {
        #region Members

        protected int groupId;
        protected string moduleAlias;
        protected int moduleId;
        protected int userId;
        protected int val;

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
        /// Property relating to database column ModuleId(int,not null)
        /// </summary>
        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        /// <summary>
        /// Property relating to database column Val(int,not null)
        /// </summary>
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string ModuleAlias
        {
            get { return moduleAlias; }
            set { moduleAlias = value; }
        }

        #endregion
    }
}