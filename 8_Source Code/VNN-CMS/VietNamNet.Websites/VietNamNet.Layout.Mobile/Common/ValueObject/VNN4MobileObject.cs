using VietNamNet.Framework.Module;

namespace VietNamNet.Layout.Mobile.Common.ValueObject
{
    public class VNN4MobileObject : BaseObject
    {
        protected string categoryAlias;
        protected string categoryDisplayName;
        protected string categoryName;
        protected int categoryId;
        protected int articleId;
        protected int partitionId;

        public string CategoryAlias
        {
            get { return categoryAlias; }
            set { categoryAlias = value; }
        }

        public string CategoryDisplayName
        {
            get { return categoryDisplayName; }
            set { categoryDisplayName = value; }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public int PartitionId
        {
            get { return partitionId; }
            set { partitionId = value; }
        }

        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }
    }
}