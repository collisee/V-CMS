using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementZoneBlock : BaseObject
    {
        #region Members

        protected int blockId;
        protected int ord;
        protected int zoneId;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column ZoneId(int,not null)
        /// </summary>
        public int ZoneId
        {
            get { return zoneId; }
            set { zoneId = value; }
        }

        /// <summary>
        /// Property relating to database column BlockId(int,not null)
        /// </summary>
        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
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