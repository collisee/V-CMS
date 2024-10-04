using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Menu : BaseObject
    {
        #region Members

        protected int access;
        protected string displayName;
        protected int userId;
        protected string link;
        protected int moduleId;
        protected string name;
        protected int ord;
        protected int oldOrd;
        protected int pId;
        private string moduleName;
        private string parentDisplayName;
        private string parentName;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column PId(int,null)
        /// </summary>
        public int PId
        {
            get { return pId; }
            set { pId = value; }
        }

        /// <summary>
        /// Property relating to database column Ord(int,not null)
        /// </summary>
        public int Ord
        {
            get { return ord; }
            set { ord = value; }
        }

        /// <summary>
        /// Property relating to database column Name(nvarchar(50),not null)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property relating to database column DisplayName(nvarchar(50),not null)
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// Property relating to database column Link(nvarchar(255),null)
        /// </summary>
        public string Link
        {
            get { return link; }
            set { link = value; }
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
        /// Property relating to database column Access(int,not null)
        /// </summary>
        public int Access
        {
            get { return access; }
            set { access = value; }
        }

        public int OldOrd
        {
            get { return oldOrd; }
            set { oldOrd = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }

        public string ParentDisplayName
        {
            get { return parentDisplayName; }
            set { parentDisplayName = value; }
        }

        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        #endregion
    }
}