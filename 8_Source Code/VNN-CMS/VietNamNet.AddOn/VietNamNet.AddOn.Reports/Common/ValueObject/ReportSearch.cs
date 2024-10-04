
using System;

namespace  VietNamNet.AddOn.Report.Core.Common.ValueObject
{
    public class ReportSearch 
	{
		#region Members
        private int _userId;
         private int _groupId;
        private int _categoryId;
		private DateTime _dateFrom;
        private DateTime _dateTo; 

		#endregion

        #region Public Properties

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set { _dateFrom = value; }
        }

        public DateTime DateTo
        {
            get { return _dateTo; }
            set { _dateTo = value; }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        #endregion

    }
}
