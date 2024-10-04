using System;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class ArticleMedia : BaseObject
    {
        #region Members

        protected int articleId;
        protected string detail;
        protected string fileLink;
        protected string mediaType;
        protected int ord;
        protected string thumbnail;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column ArticleId(int,not null)
        /// </summary>
        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        /// <summary>
        /// Property relating to database column MediaType(nvarchar(50),not null)
        /// </summary>
        public string MediaType
        {
            get { return mediaType; }
            set { mediaType = value; }
        }

        /// <summary>
        /// Property relating to database column Ord(int,not null)
        /// </summary>
        public int Ord
        {
            get { return ord; }
            set { ord = value; }
        }

        /// <summary>
        /// Property relating to database column FileLink(nvarchar(255),not null)
        /// </summary>
        public string FileLink
        {
            get { return fileLink; }
            set { fileLink = value; }
        }

        /// <summary>
        /// Property relating to database column Thumbnail(nvarchar(255),not null)
        /// </summary>
        public string Thumbnail
        {
            get { return thumbnail; }
            set { thumbnail = value; }
        }

        /// <summary>
        /// Property relating to database column Detail(nvarchar(4000),null)
        /// </summary>
        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        #endregion
    }
}