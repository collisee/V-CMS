
using System;

namespace  VietNamNet.AddOn.Royalty.Core.Common.ValueObject
{
    public class RoyaltySearch 
	{
		#region Members
        private int _userId;
        private int _isMember;
		private DateTime _dateFrom;
        private DateTime _dateTo; 

		#endregion

        #region Public Properties

        public int IsMember
        {
            get { return _isMember; }
            set { _isMember = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
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

        #endregion

    }
}
