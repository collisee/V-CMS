using VietNamNet.Framework.Module;

namespace VietNamNet.Websites.Petro.Common.ValueObject
{
    public class PetroObject : BaseObject
    {
        protected int articleId;
        protected string categoryAlias;
        protected string categoryDisplayName;
        protected int categoryId;
        protected string categoryName;
        protected string mediaType;
      protected string searchkeyword;
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

        public string MediaType
        {
            get { return mediaType; }
            set { mediaType = value; }
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

      public string Searchkeyword
      {
        get { return searchkeyword; }
        set { searchkeyword = value; }
      }
    }
}