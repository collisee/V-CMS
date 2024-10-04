using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.Common.ValueObject
{
    public class AdvertisementItem : BaseObject
    {
        #region Members

        protected string codeJS;
        protected string detail;
        protected DateTime endTime;
        protected int exHeight;
        protected int exMode;
        protected int exWidth;
        protected string fileJS;
        protected string fileLink1;
        protected string fileLink2;
        protected string history;
        protected string link;
        protected string name;
        protected DateTime startTime;
        protected int typeId;

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
        /// Property relating to database column TypeId(int,not null)
        /// </summary>
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        /// <summary>
        /// Property relating to database column Link(nvarchar(255),not null)
        /// </summary>
        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        /// <summary>
        /// Property relating to database column FileLink1(nvarchar(255),not null)
        /// </summary>
        public string FileLink1
        {
            get { return fileLink1; }
            set { fileLink1 = value; }
        }

        /// <summary>
        /// Property relating to database column FileLink2(nvarchar(255),null)
        /// </summary>
        public string FileLink2
        {
            get { return fileLink2; }
            set { fileLink2 = value; }
        }

        /// <summary>
        /// Property relating to database column FileJS(nvarchar(4000),null)
        /// </summary>
        public string FileJS
        {
            get { return fileJS; }
            set { fileJS = value; }
        }

        /// <summary>
        /// Property relating to database column CodeJS(nvarchar(4000),null)
        /// </summary>
        public string CodeJS
        {
            get { return codeJS; }
            set { codeJS = value; }
        }

        /// <summary>
        /// Property relating to database column StartTime(datetime,not null)
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// Property relating to database column EndTime(datetime,not null)
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
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
        /// Property relating to database column ExWidth(int,null)
        /// </summary>
        public int ExWidth
        {
            get { return exWidth; }
            set { exWidth = value; }
        }

        /// <summary>
        /// Property relating to database column ExHeight(int,null)
        /// </summary>
        public int ExHeight
        {
            get { return exHeight; }
            set { exHeight = value; }
        }

        /// <summary>
        /// Property relating to database column ExMode(int,null)
        /// </summary>
        public int ExMode
        {
            get { return exMode; }
            set { exMode = value; }
        }

        /// <summary>
        /// Property relating to database column History(ntext,null)
        /// </summary>
        public string History
        {
            get { return history; }
            set { history = value; }
        }

        #endregion
    }
}