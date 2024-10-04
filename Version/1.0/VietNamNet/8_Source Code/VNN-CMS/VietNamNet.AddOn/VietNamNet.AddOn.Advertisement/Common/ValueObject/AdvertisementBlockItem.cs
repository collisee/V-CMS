using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementBlockItem : BaseObject
    {
        #region Members

        protected int blockId;
        protected int itemId;
        protected int ord;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column BlockId(int,not null)
        /// </summary>
        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        /// <summary>
        /// Property relating to database column ItemId(int,not null)
        /// </summary>
        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
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