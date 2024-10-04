using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.ValueObject
{
    public class Function : BaseObject
    {
        #region Members

        protected string alias;
        protected string detail;
        protected int moduleId;
        protected int ord;
        protected int oldOrd;
        protected string name;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column ModuleId(int,not null)
        /// </summary>
        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
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
        /// Property relating to database column Name(nvarchar(255),not null)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property relating to database column Alias(nvarchar(255),not null)
        /// </summary>
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(nvarchar(4000),null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public int OldOrd
        {
            get { return oldOrd; }
            set { oldOrd = value; }
        }

        #endregion
    }
}