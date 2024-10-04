/// <summary>
/// Constants of Petronas.NextG.Framework.DAC
/// </summary>
using VietNamNet.Framework.Module;

namespace  VietNamNet.AddOn.Report.Core.Common
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
		 
		public class Report
		{
			public const string Name = "Report";
			public class FieldName
			{
                public const string UserId = "UserId";
                public const string CatId = "CatId";
                public const string DateFrom = "DateFrom";
                public const string DateTo = "DateTo"; 
			}
		} 

	}
	#endregion

	#region ParameterName
    public class ParameterName : ModuleConstants.ParameterName
	{
        public const string TYPE_ID = "typeid";
        public const string CategoryId = "fundid";
	}
	#endregion

	#region Services
	public class Services
	{ 
		#region ReportManager
		public class ReportManager
		{
			public const string Name = "ReportManager";
			public class Actions  
            {
                public const string ListByArticle = "ListByArticle"; 

                public const string ReportByCat = "Report_ReportByCat";
                public const string ReportByGroup = "Report_ReportByGroup";
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
        public const string ReportTypesDeleted = "ReportTypesDeleted";
        public const string ReportTypesUpdated = "ReportTypesUpdated";
        public const string ReportFundsDeleted = "ReportFundsDeleted";
        public const string ReportFundsUpdated = "ReportFundsUpdated"; 

    }

    #endregion

}
}
