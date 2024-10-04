using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementZone : BaseObject
    {
        #region Members

        protected string detail;
        protected int direction;
        protected int height;
        protected string holderId;
        protected int mode;
        protected string name;
        protected int width;

        private DataTable blocks;

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
        /// Property relating to database column HolderId(nvarchar(255),not null)
        /// </summary>
        public string HolderId
        {
            get { return holderId; }
            set { holderId = value; }
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
        /// Property relating to database column Direction(int,not null)
        /// </summary>
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
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

        public DataTable Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        #endregion
    }
}