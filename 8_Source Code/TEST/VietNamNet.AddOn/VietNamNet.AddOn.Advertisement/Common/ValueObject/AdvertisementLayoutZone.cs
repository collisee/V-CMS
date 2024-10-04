using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementLayoutZone : BaseObject
    {
        #region Members

        protected int layoutId;
        protected int zoneId;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column LayoutId(int,not null)
        /// </summary>
        public int LayoutId
        {
            get { return layoutId; }
            set { layoutId = value; }
        }

        /// <summary>
        /// Property relating to database column ZoneId(int,not null)
        /// </summary>
        public int ZoneId
        {
            get { return zoneId; }
            set { zoneId = value; }
        }

        #endregion
    }
}