using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementBlock : BaseObject
    {
        #region Members

        protected string detail;
        protected int height;
        protected int mode;
        protected string name;
        protected int timeDelay;
        protected int width;

        private DataTable items;

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

        /// <summary>
        /// Property relating to database column Mode(int,not null)
        /// </summary>
        public int Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        /// <summary>
        /// Property relating to database column TimeDelay(int,not null)
        /// </summary>
        public int TimeDelay
        {
            get { return timeDelay; }
            set { timeDelay = value; }
        }

        /// <summary>
        /// Property relating to database column Width(int,not null)
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Property relating to database column Height(int,not null)
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public DataTable Items
        {
            get { return items; }
            set { items = value; }
        }

        #endregion
    }
}