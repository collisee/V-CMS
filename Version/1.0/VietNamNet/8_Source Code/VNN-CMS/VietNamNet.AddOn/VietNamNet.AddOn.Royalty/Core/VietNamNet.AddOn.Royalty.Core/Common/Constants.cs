/// <summary>
/// Constants of Petronas.NextG.Framework.DAC
/// </summary>
using VietNamNet.Framework.Module;

namespace  VietNamNet.AddOn.Royalty.Core.Common
{

public class Constants
{
	#region Entities
	public class Entities
	{
		#region CommonEntity
		public class CommonEntity
		{
			public const string Created_At = "Created_At";
			public const string Created_By = "Created_By";
			public const string Last_Modified_At = "Last_Modified_At";
			public const string Last_Modified_By = "Last_Modified_By";
			public const string flag = "flag";
		}
		#endregion
		#region RoyaltyFund
		public class RoyaltyFund
		{
			public const string Name = "RoyaltyFund";
			public class FieldName
			{
				public const string Fund_Id="Fund_Id";
				public const string Article_Id="Article_Id";
				public const string Text_Fund="Text_Fund";
				public const string Image_Fund="Image_Fund";
				public const string Audio_Fund="Audio_Fund";
				public const string Video_Fund="Video_Fund";
				public const string Other_Fund="Other_Fund";
				public const string Notes="Notes";
				public const string Author_Id="Author_Id";
				public const string Setter_Id="Setter_Id";
				public const string Type_Id="Type_Id";
				public const string Set_Type="Set_Type";
				public const string Pay_Date="Pay_Date";
				public const string Pay_Status="Pay_Status";
				public const string Created_At="Created_At";
				public const string Created_By="Created_By";
				public const string Last_Modified_At="Last_Modified_At";
				public const string Last_Modified_By="Last_Modified_By";
				public const string flag="flag";
			}
		}
		#endregion

		#region RoyaltyTypes
		public class RoyaltyTypes
		{
			public const string Name = "RoyaltyTypes";
			public class FieldName
			{
				public const string Type_Id="Type_Id";
				public const string Title="Title";
				public const string Description="Description";
				public const string Parent_Id="Parent_Id";
				public const string MIN_VAL="MIN_VAL";
				public const string MAX_VAL="MAX_VAL";
				public const string Created_At="Created_At";
				public const string Created_By="Created_By";
				public const string Last_Modified_At="Last_Modified_At";
				public const string Last_Modified_By="Last_Modified_By";
				public const string flag="flag";
			}
		}
		#endregion

	}
	#endregion

	#region ParameterName
    public class ParameterName : ModuleConstants.ParameterName
	{
        public const string TYPE_ID = "typeid";
        public const string FUND_ID = "fundid";
	}
	#endregion

	#region Services
	public class Services
	{
		#region CommonActions
		public class CommonActions
		{
			public const string SAVE = "Save";
			public const string DELETE = "Delete";
			public const string LOAD = "Load";
			public const string LOAD_ENCODE = "Load_Encode";
			public const string LISTALL = "ListAll";
           
		}
		#endregion

		#region RoyaltyFundManager
		public class RoyaltyFundManager
		{
			public const string Name = "RoyaltyFundManager";
			public class Actions : CommonActions
            {
                public const string ListByArticle = "ListByArticle";
                public const string Reports21B = "Royalty_Reports21b";
                public const string Reports21A = "Royalty_Reports21a";
                public const string ViewGetAllArticleList = "ViewGetAllArticleList";
			}
		}
		#endregion

		#region RoyaltyTypesManager
		public class RoyaltyTypesManager
		{
			public const string Name = "RoyaltyTypesManager";
			public class Actions : CommonActions
			{
                public const string ListByParent = "ListByParent";
			}
		}
		#endregion

	}
	#endregion

    #region CommandNames
    public class CommandNames  
    {
        public const string UPDATE = "Update";
        public const string DELETE = "Delete";
    }
    #endregion

    #region FormNames
    public class FormNames
	{
		public const string DEFAULT = "Default.aspx";
        public const string TYPE_EDIT = "../TypesManager/TypesEdit.aspx";
        public const string TYPE_LIST = "../TypesManager/TypesList.aspx";

        public const string FUND_LISTBYARTICLE = "../FundsManager/FundByArticle.aspx";
        public const string FUND_EDIT = "../FundsManager/EditFund.aspx";

	}
	#endregion

    #region Message

    public class Message : ModuleConstants.Message
    {
        public const string RoyaltyTypesDeleted = "RoyaltyTypesDeleted";
        public const string RoyaltyTypesUpdated = "RoyaltyTypesUpdated";
        public const string RoyaltyFundsDeleted = "RoyaltyFundsDeleted";
        public const string RoyaltyFundsUpdated = "RoyaltyFundsUpdated"; 

    }

    #endregion

}
}
