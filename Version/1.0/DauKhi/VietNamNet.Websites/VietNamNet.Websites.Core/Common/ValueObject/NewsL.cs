using System;

namespace VietNamNet.Websites.Core.Common.ValueObject
{
    public class NewsL
    {
        #region Member

        private DateTime _date;
        private int _id;
        private string _img;
        private string _link;
        private string _source;
        private string _lead;
        private string _title;

        #endregion

        #region Public Properties

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string lead
        {
            get { return _lead; }
            set { _lead = value; }
        }

        public string img
        {
            get { return _img; }
            set { _img = value; }
        }

        public string link
        {
            get { return _link; }
            set { _link = value; }
        }

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        #endregion
    }
}