using VietNamNet.Framework.Module;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class AdvertisementObject : BaseObject
    {
        protected string categoryAlias;
        protected int categoryId;
        protected int layoutId;
        protected int zoneId;
        protected int blockId;
        protected int itemId;

        public string CategoryAlias
        {
            get { return categoryAlias; }
            set { categoryAlias = value; }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public int LayoutId
        {
            get { return layoutId; }
            set { layoutId = value; }
        }

        public int ZoneId
        {
            get { return zoneId; }
            set { zoneId = value; }
        }

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
    }
}