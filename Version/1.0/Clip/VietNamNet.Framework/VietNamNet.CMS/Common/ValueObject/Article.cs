using System;
using System.Data;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Common.ValueObject
{
    public class Article : BaseObject
    {
        #region Members

        protected int articleContentTypeId;
        protected int articleTypeId;
        protected string author;
        protected int authorId;
        protected string authorInfo;
        protected string detail;
        protected string history;
        protected string imageLink;
        protected string imageLink1;
        protected string imageLink2;
        protected string imageLink3;
        protected string imageLink4;
        protected string imageLink5;
        protected int isMember;
        protected string lead;
        protected string name;
        protected DateTime publishDate;
        protected string status;
        protected string subTitle1;
        protected string subTitle2;
        protected string subTitle3;
        protected string subTitle4;
        protected string subTitle5;
        protected string subTitle6;
        protected string title;
        protected int totalView;
        protected int versionId;
        protected int showComment;

        protected string url;
        protected int categoryId;
        protected int partitionId;

        private DataTable media;
        private DataTable categories;
        private DataTable versions;
        private DataTable eventItems;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property relating to database column VersionId(int,not null)
        /// </summary>
        public int VersionId
        {
            get { return versionId; }
            set { versionId = value; }
        }

        /// <summary>
        /// Property relating to database column Status(nvarchar(255),not null)
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Property relating to database column ArticleTypeId(int,not null)
        /// </summary>
        public int ArticleTypeId
        {
            get { return articleTypeId; }
            set { articleTypeId = value; }
        }

        /// <summary>
        /// Property relating to database column ArticleContentTypeId(int,not null)
        /// </summary>
        public int ArticleContentTypeId
        {
            get { return articleContentTypeId; }
            set { articleContentTypeId = value; }
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
        /// Property relating to database column Url(nvarchar(255),null)
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }


        /// <summary>
        /// Property relating to database column CategoryId(int,not null)
        /// </summary>
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }


        /// <summary>
        /// Property relating to database column PartitionId(int,not null)
        /// </summary>
        public int PartitionId
        {
            get { return partitionId; }
            set { partitionId = value; }
        }

        /// <summary>
        /// Property relating to database column SubTitle1(nvarchar(255),null)
        /// </summary>
        public string SubTitle1
        {
            get { return subTitle1; }
            set { subTitle1 = value; }
        }

        /// <summary>
        /// Property relating to database column SubTitle2(nvarchar(255),null)
        /// </summary>
        public string SubTitle2
        {
            get { return subTitle2; }
            set { subTitle2 = value; }
        }

        /// <summary>
        /// Property relating to database column SubTitle3(nvarchar(255),null)
        /// </summary>
        public string SubTitle3
        {
            get { return subTitle3; }
            set { subTitle3 = value; }
        }

        /// <summary>
        /// Property relating to database column SubTitle4(nvarchar(255),null)
        /// </summary>
        public string SubTitle4
        {
            get { return subTitle4; }
            set { subTitle4 = value; }
        }

        /// <summary>
        /// Property relating to database column SubTitle5(nvarchar(255),null)
        /// </summary>
        public string SubTitle5
        {
            get { return subTitle5; }
            set { subTitle5 = value; }
        }

        /// <summary>
        /// Property relating to database column SubTitle6(nvarchar(255),null)
        /// </summary>
        public string SubTitle6
        {
            get { return subTitle6; }
            set { subTitle6 = value; }
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
        /// Property relating to database column ImageLink1(nvarchar(255),not null)
        /// </summary>
        public string ImageLink1
        {
            get { return imageLink1; }
            set { imageLink1 = value; }
        }

        /// <summary>
        /// Property relating to database column ImageLink2(nvarchar(255),not null)
        /// </summary>
        public string ImageLink2
        {
            get { return imageLink2; }
            set { imageLink2 = value; }
        }

        /// <summary>
        /// Property relating to database column ImageLink3(nvarchar(255),not null)
        /// </summary>
        public string ImageLink3
        {
            get { return imageLink3; }
            set { imageLink3 = value; }
        }

        /// <summary>
        /// Property relating to database column ImageLink4(nvarchar(255),not null)
        /// </summary>
        public string ImageLink4
        {
            get { return imageLink4; }
            set { imageLink4 = value; }
        }

        /// <summary>
        /// Property relating to database column ImageLink5(nvarchar(255),not null)
        /// </summary>
        public string ImageLink5
        {
            get { return imageLink5; }
            set { imageLink5 = value; }
        }

        /// <summary>
        /// Property relating to database column Lead(ntext,not null)
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

        public int ShowComment
        {
            get { return showComment; }
            set { showComment = value; }
        }

        public int AuthorId
        {
            get { return authorId; }
            set { authorId = value; }
        }

        /// <summary>
        /// Property relating to database column Author(nvarchar(255),null)
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        /// <summary>
        /// Property relating to database column AuthorInfo(nvarchar(4000),null)
        /// </summary>
        public string AuthorInfo
        {
            get { return authorInfo; }
            set { authorInfo = value; }
        }

        /// <summary>
        /// Property relating to database column IsMember(int,not null)
        /// </summary>
        public int IsMember
        {
            get { return isMember; }
            set { isMember = value; }
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
        /// Property relating to database column History(ntext,not null)
        /// </summary>
        public string History
        {
            get { return history; }
            set { history = value; }
        }

        public DataTable Media
        {
            get { return media; }
            set { media = value; }
        }

        public DataTable Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public DataTable Versions
        {
            get { return versions; }
            set { versions = value; }
        }

        public DataTable EventItems
        {
            get { return eventItems; }
            set { eventItems = value; }
        }

        #endregion
    }
}