
using System;

namespace  VietNamNet.AddOn.Royalty.Core.Common.ValueObject
{
	public class RoyaltyTypes 
	{
			#region Members
			protected int type_Id;
			protected string title;
			protected string description;
			protected int parent_Id;
			protected decimal mIN_VAL;
			protected decimal mAX_VAL;
			protected DateTime created_At;
			protected int created_By;
			protected DateTime last_Modified_At;
			protected int last_Modified_By;
			protected string flag;
			#endregion
			#region Public Properties

			/// <summary>
			/// Property relating to database column Type_Id(int,not null)
			/// </summary>
			public int Type_Id
			{
				get { return type_Id; }
				set { type_Id = value; }
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
			/// Property relating to database column Description(nvarchar(500),null)
			/// </summary>
			public string Description
			{
				get { return description; }
				set { description = value; }
			}

			/// <summary>
			/// Property relating to database column Parent_Id(int,null)
			/// </summary>
			public int Parent_Id
			{
				get { return parent_Id; }
				set { parent_Id = value; }
			}

			/// <summary>
			/// Property relating to database column MIN_VAL(numeric(18,0),null)
			/// </summary>
			public decimal MIN_VAL
			{
				get { return mIN_VAL; }
				set { mIN_VAL = value; }
			}

			/// <summary>
			/// Property relating to database column MAX_VAL(numeric(18,0),null)
			/// </summary>
			public decimal MAX_VAL
			{
				get { return mAX_VAL; }
				set { mAX_VAL = value; }
			}

			/// <summary>
			/// Property relating to database column Created_At(datetime,null)
			/// </summary>
			public DateTime Created_At
			{
				get { return created_At; }
				set { created_At = value; }
			}

			/// <summary>
			/// Property relating to database column Created_By(int,null)
			/// </summary>
			public int Created_By
			{
				get { return created_By; }
				set { created_By = value; }
			}

			/// <summary>
			/// Property relating to database column Last_Modified_At(datetime,null)
			/// </summary>
			public DateTime Last_Modified_At
			{
				get { return last_Modified_At; }
				set { last_Modified_At = value; }
			}

			/// <summary>
			/// Property relating to database column Last_Modified_By(int,null)
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
