using System;
using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class ArticleEvent : BaseObject
    {
        #region Members

        protected string detail;
        protected string history;
        protected string imageLink;
        protected string lead;
        protected string name;
        protected DateTime publishDate;
        protected string status;
        protected string title;
        protected int totalView;

        private DataTable items;
        private DataTable categories;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column Status(nvarchar(255),not null)
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Property relating to database column Name(nvarchar(255),not null)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property relating to database column Title(nvarchar(255),null)
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Property relating to database column ImageLink(nvarchar(255),not null)
        /// </summary>
        public string ImageLink
        {
            get { return imageLink; }
            set { imageLink = value; }
        }

        /// <summary>
        /// Property relating to database column Lead(nvarchar(4000),not null)
        /// </summary>
        public string Lead
        {
            get { return lead; }
            set { lead = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(ntext,not null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        /// <summary>
        /// Property relating to database column PublishDate(datetime,not null)
        /// </summary>
        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        /// <summary>
        /// Property relating to database column TotalView(int,not null)
        /// </summary>
        public int TotalView
        {
            get { return totalView; }
            set { totalView = value; }
        }

        /// <summary>
        /// Property relating to database column History(ntext,null)
        /// </summary>
        public string History
        {
            get { return history; }
            set { history = value; }
        }

        public DataTable Items
        {
            get { return items; }
            set { items = value; }
        }

        public DataTable Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        #endregion
    }
}