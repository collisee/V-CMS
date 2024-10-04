using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class CategoryPolicy : BaseObject
    {
        #region Members

        protected int categoryId;
        protected string categoryAlias;
        protected int groupId;
        protected int val;
        protected int userId;

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
        /// Property relating to database column CategoryId(int,not null)
        /// </summary>
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        /// <summary>
        /// Property relating to database column Val(int,not null)
        /// </summary>
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public string CategoryAlias
        {
            get { return categoryAlias; }
            set { categoryAlias = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        #endregion
    }
}