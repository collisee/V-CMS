using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class ArticleCategory : BaseObject
    {
        #region Members

        protected int articleContentTypeId;
        protected int articleId;
        protected int categoryId;
        protected int ord;
        protected int oldOrd;
        protected int partitionId;
        protected int primaryCategory;
        protected string saveStatus;
        protected string url;
        protected DateTime publishDate;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column CategoryId(int,not null)
        /// </summary>
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        /// <summary>
        /// Property relating to database column PartitionId(int,not null)
        /// </summary>
        public int PartitionId
        {
            get { return partitionId; }
            set { partitionId = value; }
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

        /// <summary>
        /// Property relating to database column ArticleContentTypeId(int,not null)
        /// </summary>
        public int ArticleContentTypeId
        {
            get { return articleContentTypeId; }
            set { articleContentTypeId = value; }
        }

        /// <summary>
        /// Property relating to database column PrimaryCategory(int,not null)
        /// </summary>
        public int PrimaryCategory
        {
            get { return primaryCategory; }
            set { primaryCategory = value; }
        }

        public int OldOrd
        {
            get { return oldOrd; }
            set { oldOrd = value; }
        }

        public string SaveStatus
        {
            get { return saveStatus; }
            set { saveStatus = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        #endregion
    }
}