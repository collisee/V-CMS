using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class ArticleEventItem : BaseObject
    {
        #region Members

        protected int articleEventId;
        protected int articleId;
        protected int ord;

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
        /// Property relating to database column ArticleId(int,not null)
        /// </summary>
        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        /// <summary>
        /// Property relating to database column Ord(int,not null)
        /// </summary>
        public int Ord
        {
            get { return ord; }
            set { ord = value; }
        }

        #endregion
    }
}