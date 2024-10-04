using System;

namespace VietNamNet.Framework.Module
{
    public class BaseObject
    {
        protected string flag;
        protected DateTime created_At;
        protected int created_By;
        protected int id;
        protected DateTime last_Modified_At;
        protected int last_Modified_By;
        protected int firstIndexRecord;
        protected int lastIndexRecord;
        protected string keywords;

        /// <summary>
        /// Property relating to database column Id(int,not null)
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Property relating to database column Created_At(datetime,not null)
        /// </summary>
        public DateTime Created_At
        {
            get { return created_At; }
            set { created_At = value; }
        }

        /// <summary>
        /// Property relating to database column Created_By(int,not null)
        /// </summary>
        public int Created_By
        {
            get { return created_By; }
            set { created_By = value; }
        }

        /// <summary>
        /// Property relating to database column Last_Modified_At(datetime,not null)
        /// </summary>
        public DateTime Last_Modified_At
        {
            get { return last_Modified_At; }
            set { last_Modified_At = value; }
        }

        /// <summary>
        /// Property relating to database column Last_Modified_By(int,not null)
        /// </summary>
        public int Last_Modified_By
        {
            get { return last_Modified_By; }
            set { last_Modified_By = value; }
        }

        /// <summary>
        /// Property relating to database column flag(char(1),null)
        /// </summary>
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public int FirstIndexRecord
        {
            get { return firstIndexRecord; }
            set { firstIndexRecord = value; }
        }

        public int LastIndexRecord
        {
            get { return lastIndexRecord; }
            set { lastIndexRecord = value; }
        }

        public string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }
    }
}