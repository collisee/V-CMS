using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementLayoutCategory : BaseObject
    {
        #region Members

        protected int categoryId;
        protected int layoutId;

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
        /// Property relating to database column CategoryId(int,not null)
        /// </summary>
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        #endregion
    }
}