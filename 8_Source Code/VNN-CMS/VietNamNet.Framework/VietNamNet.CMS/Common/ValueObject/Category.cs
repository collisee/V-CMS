using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class Category : BaseObject
    {
        #region Members

        protected string alias;
        protected string detail;
        protected string displayName;
        protected string url;
        protected string name;
        protected int ord;
        protected int oldOrd;
        protected int partitionId;
        protected int pId;
        private string parentDisplayName;
        private string parentName;
        private int userId;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column PartitionId(int,not null)
        /// </summary>
        public int PartitionId
        {
            get { return partitionId; }
            set { partitionId = value; }
        }

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
        /// Property relating to database column DisplayName(nvarchar(255),not null)
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// Property relating to database column Url(nvarchar(255),not null)
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
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

        public string ParentDisplayName
        {
            get { return parentDisplayName; }
            set { parentDisplayName = value; }
        }

        public string ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        #endregion
    }
}