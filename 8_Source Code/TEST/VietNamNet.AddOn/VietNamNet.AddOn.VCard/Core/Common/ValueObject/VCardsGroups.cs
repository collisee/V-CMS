
using System;

namespace VietNamNet.AddOn.VCard.Core.Common.ValueObject
{
	public class VCardsGroups 
	{
			#region Members
			protected int groupId;
			protected string groupName;
			protected string description;
			protected int owner;
			protected DateTime created_At;
			protected int created_By;
			protected DateTime last_Modified_At;
			protected int last_Modified_By;
			protected string flag;
			#endregion
			#region Public Properties

			/// <summary>
			/// Property relating to database column GroupId(int,not null)
			/// </summary>
			public int GroupId
			{
				get { return groupId; }
				set { groupId = value; }
			}

			/// <summary>
			/// Property relating to database column GroupName(nvarchar(100),null)
			/// </summary>
			public string GroupName
			{
				get { return groupName; }
				set { groupName = value; }
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
			/// Property relating to database column Owner(int,not null)
			/// </summary>
			public int Owner
			{
				get { return owner; }
				set { owner = value; }
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
