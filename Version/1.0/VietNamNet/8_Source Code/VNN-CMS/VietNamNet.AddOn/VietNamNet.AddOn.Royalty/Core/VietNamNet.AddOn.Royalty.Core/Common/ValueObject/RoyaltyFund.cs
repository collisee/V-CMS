
using System;

namespace  VietNamNet.AddOn.Royalty.Core.Common.ValueObject
{
	public class RoyaltyFund 
	{
		#region Members
		protected int fund_Id;
		protected int article_Id;
		protected int text_Fund;
		protected int image_Fund;
		protected int audio_Fund;
		protected int video_Fund;
		protected int other_Fund;
		protected string notes;
		protected int author_Id;
        protected int author_IsMember;
		protected int setter_Id;
		protected int type_Id;
		protected string set_Type;
		protected DateTime pay_Date;
		protected int pay_Status;
		protected DateTime created_At;
		protected int created_By;
		protected DateTime last_Modified_At;
		protected int last_Modified_By;
		protected string flag;
		#endregion
		#region Public Properties

		/// <summary>
		/// Property relating to database column Fund_Id(int,not null)
		/// </summary>
		public int Fund_Id
		{
			get { return fund_Id; }
			set { fund_Id = value; }
		}

		/// <summary>
		/// Property relating to database column Article_Id(int,not null)
		/// </summary>
		public int Article_Id
		{
			get { return article_Id; }
			set { article_Id = value; }
		}

		/// <summary>
		/// Property relating to database column Text_Fund(int,null)
		/// </summary>
		public int Text_Fund
		{
			get { return text_Fund; }
			set { text_Fund = value; }
		}

		/// <summary>
		/// Property relating to database column Image_Fund(int,null)
		/// </summary>
		public int Image_Fund
		{
			get { return image_Fund; }
			set { image_Fund = value; }
		}

		/// <summary>
		/// Property relating to database column Audio_Fund(int,null)
		/// </summary>
		public int Audio_Fund
		{
			get { return audio_Fund; }
			set { audio_Fund = value; }
		}

		/// <summary>
		/// Property relating to database column Video_Fund(int,null)
		/// </summary>
		public int Video_Fund
		{
			get { return video_Fund; }
			set { video_Fund = value; }
		}

		/// <summary>
		/// Property relating to database column Other_Fund(int,null)
		/// </summary>
		public int Other_Fund
		{
			get { return other_Fund; }
			set { other_Fund = value; }
		}

		/// <summary>
		/// Property relating to database column Notes(nvarchar(500),null)
		/// </summary>
		public string Notes
		{
			get { return notes; }
			set { notes = value; }
		}

		/// <summary>
		/// Property relating to database column Author_Id(int,null)
		/// </summary>
		public int Author_Id
		{
			get { return author_Id; }
			set { author_Id = value; }
		}
        /// <summary>
        /// Property relating to database column Author_Id(int,null)
        /// </summary>
        public int Author_IsMember
        {
            get { return author_IsMember; }
            set { author_IsMember = value; }
        }

		/// <summary>
		/// Property relating to database column Setter_Id(int,null)
		/// </summary>
		public int Setter_Id
		{
			get { return setter_Id; }
			set { setter_Id = value; }
		}

		/// <summary>
		/// Property relating to database column Type_Id(int,null)
		/// </summary>
		public int Type_Id
		{
			get { return type_Id; }
			set { type_Id = value; }
		}

		/// <summary>
		/// Property relating to database column Set_Type(nvarchar(500),null)
		/// </summary>
		public string Set_Type
		{
			get { return set_Type; }
			set { set_Type = value; }
		}

		/// <summary>
		/// Property relating to database column Pay_Date(datetime,null)
		/// </summary>
		public DateTime Pay_Date
		{
			get { return pay_Date; }
			set { pay_Date = value; }
		}

		/// <summary>
		/// Property relating to database column Pay_Status(int,not null)
		/// </summary>
		public int Pay_Status
		{
			get { return pay_Status; }
			set { pay_Status = value; }
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
		#endregion
	}
}
