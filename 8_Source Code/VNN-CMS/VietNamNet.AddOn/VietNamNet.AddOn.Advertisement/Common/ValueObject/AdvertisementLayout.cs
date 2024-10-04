using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementLayout : BaseObject
    {
        #region Members

        protected string detail;
        protected string name;

        private DataTable categories;
        private DataTable zones;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column Name(nvarchar(255),not null)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(nvarchar(4000),null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public DataTable Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public DataTable Zones
        {
            get { return zones; }
            set { zones = value; }
        }

        #endregion
    }
}