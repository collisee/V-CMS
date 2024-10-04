using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace DAL{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the OptimizeCategory Procedure
        /// </summary>
        public static StoredProcedure OptimizeCategory()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeCategory" , DataService.GetInstance("VCMS"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the UpdateCategoryPIdAndOrder Procedure
        /// </summary>
        public static StoredProcedure UpdateCategoryPIdAndOrder(int? Id, int? PId, int? Ord, DateTime? LastModifiedAt, int? LastModifiedBy)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("UpdateCategoryPIdAndOrder" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@Id", Id,DbType.Int32);
        	    
            sp.Command.AddParameter("@PId", PId,DbType.Int32);
        	    
            sp.Command.AddParameter("@Ord", Ord,DbType.Int32);
        	    
            sp.Command.AddParameter("@Last_Modified_At", LastModifiedAt,DbType.DateTime);
        	    
            sp.Command.AddParameter("@Last_Modified_By", LastModifiedBy,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the InsertNew Procedure
        /// </summary>
        public static StoredProcedure InsertNew(string Name, string Title, string ImageLink, string Lead, string Detail, string History, string Href, string Status, int? ArticleType)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("InsertNew" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@Name", Name,DbType.String);
        	    
            sp.Command.AddParameter("@Title", Title,DbType.String);
        	    
            sp.Command.AddParameter("@ImageLink", ImageLink,DbType.String);
        	    
            sp.Command.AddParameter("@Lead", Lead,DbType.String);
        	    
            sp.Command.AddParameter("@Detail", Detail,DbType.String);
        	    
            sp.Command.AddParameter("@History", History,DbType.String);
        	    
            sp.Command.AddParameter("@Href", Href,DbType.String);
        	    
            sp.Command.AddParameter("@Status", Status,DbType.String);
        	    
            sp.Command.AddParameter("@ArticleType", ArticleType,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the InsertArticleCate Procedure
        /// </summary>
        public static StoredProcedure InsertArticleCate(int? CategoryId, int? PartitionId, int? ArticleId, int? Ord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("InsertArticleCate" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            sp.Command.AddParameter("@PartitionId", PartitionId,DbType.Int32);
        	    
            sp.Command.AddParameter("@ArticleId", ArticleId,DbType.Int32);
        	    
            sp.Command.AddParameter("@Ord", Ord,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the SelectCategory Procedure
        /// </summary>
        public static StoredProcedure SelectCategory(int? ID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SelectCategory" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@ID", ID,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetMenuByUserId Procedure
        /// </summary>
        public static StoredProcedure GetMenuByUserId(int? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMenuByUserId" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the OptimizeMenu Procedure
        /// </summary>
        public static StoredProcedure OptimizeMenu()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeMenu" , DataService.GetInstance("VCMS"));
        	
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the UpdateMenuPIdAndOrder Procedure
        /// </summary>
        public static StoredProcedure UpdateMenuPIdAndOrder(int? Id, int? PId, int? Ord, DateTime? LastModifiedAt, int? LastModifiedBy)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("UpdateMenuPIdAndOrder" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@Id", Id,DbType.Int32);
        	    
            sp.Command.AddParameter("@PId", PId,DbType.Int32);
        	    
            sp.Command.AddParameter("@Ord", Ord,DbType.Int32);
        	    
            sp.Command.AddParameter("@Last_Modified_At", LastModifiedAt,DbType.DateTime);
        	    
            sp.Command.AddParameter("@Last_Modified_By", LastModifiedBy,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the SystemLogging Procedure
        /// </summary>
        public static StoredProcedure SystemLogging(string Action, string Detail)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SystemLogging" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@Action", Action,DbType.String);
        	    
            sp.Command.AddParameter("@Detail", Detail,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetLogging Procedure
        /// </summary>
        public static StoredProcedure GetLogging(DateTime? LoggingFromDate, DateTime? LoggingToDate, int? LogLevel, int? LogUser)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetLogging" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@LoggingFromDate", LoggingFromDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@LoggingToDate", LoggingToDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@LogLevel", LogLevel,DbType.Int32);
        	    
            sp.Command.AddParameter("@LogUser", LogUser,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetCategoryByUserId Procedure
        /// </summary>
        public static StoredProcedure GetCategoryByUserId(int? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetCategoryByUserId" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetPolicyByUserIdAndCategoryAlias Procedure
        /// </summary>
        public static StoredProcedure GetPolicyByUserIdAndCategoryAlias(int? UserId, string CategoryAlias)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPolicyByUserIdAndCategoryAlias" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Int32);
        	    
            sp.Command.AddParameter("@CategoryAlias", CategoryAlias,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetPolicyByUserIdAndCategoryId Procedure
        /// </summary>
        public static StoredProcedure GetPolicyByUserIdAndCategoryId(int? UserId, int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPolicyByUserIdAndCategoryId" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Int32);
        	    
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the ViewGetAllArticleByCategory Procedure
        /// </summary>
        public static StoredProcedure ViewGetAllArticleByCategory(string CategoriesId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ViewGetAllArticleByCategory" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@CategoriesId", CategoriesId,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the OptimizeArticleCategory Procedure
        /// </summary>
        public static StoredProcedure OptimizeArticleCategory(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeArticleCategory" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@CategoryId", CategoryId,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetPolicyByUserIdAndModuleAlias Procedure
        /// </summary>
        public static StoredProcedure GetPolicyByUserIdAndModuleAlias(int? UserId, string ModuleAlias)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPolicyByUserIdAndModuleAlias" , DataService.GetInstance("VCMS"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Int32);
        	    
            sp.Command.AddParameter("@ModuleAlias", ModuleAlias,DbType.String);
        	    
            return sp;
        }

        
    }

    
}


