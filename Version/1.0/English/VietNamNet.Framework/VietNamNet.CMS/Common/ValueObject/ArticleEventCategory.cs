using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class ArticleEventCategory : BaseObject
    {
        #region Members

        protected int articleEventId;
        protected int categoryId;
        protected int ord;
        protected int oldOrd;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column ArticleEventId(int,not null)
        /// </summary>
        public int ArticleEventId
        {
            get { return articleEventId; }
            set { articleEventId = value; }
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
        /// Property relating to database column Ord(int,not null)
        /// </summary>
        public int Ord
        {
            get { return ord; }
            set { ord = value; }
        }

        public int OldOrd
        {
            get { return oldOrd; }
            set { oldOrd = value; }
        }

        #endregion
    }
}