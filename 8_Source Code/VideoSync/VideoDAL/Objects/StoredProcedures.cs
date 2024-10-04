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
namespace VideoDAL{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the GetCategoryByUserId Procedure
        /// </summary>
        public static StoredProcedure GetCategoryByUserId(int? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetCategoryByUserId", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@UserId", UserId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetLogging Procedure
        /// </summary>
        public static StoredProcedure GetLogging(DateTime? LoggingFromDate, DateTime? LoggingToDate, int? LogLevel, int? LogUser)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetLogging", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@LoggingFromDate", LoggingFromDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@LoggingToDate", LoggingToDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@LogLevel", LogLevel, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LogUser", LogUser, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetMenuByUserId Procedure
        /// </summary>
        public static StoredProcedure GetMenuByUserId(int? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetMenuByUserId", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@UserId", UserId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPolicyByUserIdAndCategoryAlias Procedure
        /// </summary>
        public static StoredProcedure GetPolicyByUserIdAndCategoryAlias(int? UserId, string CategoryAlias)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPolicyByUserIdAndCategoryAlias", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@UserId", UserId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CategoryAlias", CategoryAlias, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPolicyByUserIdAndCategoryId Procedure
        /// </summary>
        public static StoredProcedure GetPolicyByUserIdAndCategoryId(int? UserId, int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPolicyByUserIdAndCategoryId", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@UserId", UserId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the GetPolicyByUserIdAndModuleAlias Procedure
        /// </summary>
        public static StoredProcedure GetPolicyByUserIdAndModuleAlias(int? UserId, string ModuleAlias)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetPolicyByUserIdAndModuleAlias", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@UserId", UserId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ModuleAlias", ModuleAlias, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetArticle Procedure
        /// </summary>
        public static StoredProcedure LayoutGetArticle(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetArticle", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetArticleComment Procedure
        /// </summary>
        public static StoredProcedure LayoutGetArticleComment(int? ArticleId, int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetArticleComment", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetArticleMedia Procedure
        /// </summary>
        public static StoredProcedure LayoutGetArticleMedia(int? ArticleId, string MediaType)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetArticleMedia", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@MediaType", MediaType, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetArticleVNNId Procedure
        /// </summary>
        public static StoredProcedure LayoutGetArticleVNNId(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetArticleVNNId", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetCategoryArticleNumber Procedure
        /// </summary>
        public static StoredProcedure LayoutGetCategoryArticleNumber(int? PartitionId, int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetCategoryArticleNumber", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@PartitionId", PartitionId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetCategoryArticles Procedure
        /// </summary>
        public static StoredProcedure LayoutGetCategoryArticles(int? PartitionId, int? CategoryId, int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetCategoryArticles", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@PartitionId", PartitionId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetCategoryArticlesMore Procedure
        /// </summary>
        public static StoredProcedure LayoutGetCategoryArticlesMore(int? PartitionId, int? CategoryId, int? ArticleId, int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetCategoryArticlesMore", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@PartitionId", PartitionId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetCategoryByAlias Procedure
        /// </summary>
        public static StoredProcedure LayoutGetCategoryByAlias(string CategoryAlias)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetCategoryByAlias", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@CategoryAlias", CategoryAlias, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetMostReadArticles Procedure
        /// </summary>
        public static StoredProcedure LayoutGetMostReadArticles(int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetMostReadArticles", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetPrimaryCategory Procedure
        /// </summary>
        public static StoredProcedure LayoutGetPrimaryCategory(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetPrimaryCategory", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetSearchArticles Procedure
        /// </summary>
        public static StoredProcedure LayoutGetSearchArticles(string Searchkeyword, int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetSearchArticles", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@Searchkeyword", Searchkeyword, DbType.String, null, null);
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetSubCategory Procedure
        /// </summary>
        public static StoredProcedure LayoutGetSubCategory(string CategoryAlias)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetSubCategory", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@CategoryAlias", CategoryAlias, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetTopArticles Procedure
        /// </summary>
        public static StoredProcedure LayoutGetTopArticles(int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetTopArticles", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_GetTopMedia Procedure
        /// </summary>
        public static StoredProcedure LayoutGetTopMedia(int? PartitionId, int? CategoryId, int? FirstIndexRecord, int? LastIndexRecord, string MediaType)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_GetTopMedia", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@PartitionId", PartitionId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@MediaType", MediaType, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Layout_SetTotalView Procedure
        /// </summary>
        public static StoredProcedure LayoutSetTotalView(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Layout_SetTotalView", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@ArticleId", ArticleId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the OptimizeArticleCategory Procedure
        /// </summary>
        public static StoredProcedure OptimizeArticleCategory(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeArticleCategory", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the OptimizeArticleEventCategory Procedure
        /// </summary>
        public static StoredProcedure OptimizeArticleEventCategory(int? CategoryId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeArticleEventCategory", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@CategoryId", CategoryId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the OptimizeCategory Procedure
        /// </summary>
        public static StoredProcedure OptimizeCategory()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeCategory", DataService.GetInstance("VCMS"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the OptimizeMenu Procedure
        /// </summary>
        public static StoredProcedure OptimizeMenu()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("OptimizeMenu", DataService.GetInstance("VCMS"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Royalty_FundListByArticle Procedure
        /// </summary>
        public static StoredProcedure RoyaltyFundListByArticle(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Royalty_FundListByArticle", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@Article_Id", ArticleId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the Royalty_ListByArticle Procedure
        /// </summary>
        public static StoredProcedure RoyaltyListByArticle(int? ArticleId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("Royalty_ListByArticle", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@Article_Id", ArticleId, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SearchArticle Procedure
        /// </summary>
        public static StoredProcedure SearchArticle(string KeyWords, string CategoryAlias, string PublishDate, int? FirstIndexRecord, int? LastIndexRecord)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SearchArticle", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@KeyWords", KeyWords, DbType.String, null, null);
        	
            sp.Command.AddParameter("@CategoryAlias", CategoryAlias, DbType.String, null, null);
        	
            sp.Command.AddParameter("@PublishDate", PublishDate, DbType.String, null, null);
        	
            sp.Command.AddParameter("@FirstIndexRecord", FirstIndexRecord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastIndexRecord", LastIndexRecord, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SearchArticleByKeyword Procedure
        /// </summary>
        public static StoredProcedure SearchArticleByKeyword(string KeyWords, int? FirstRow, int? LastRow)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SearchArticleByKeyword", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@KeyWords", KeyWords, DbType.String, null, null);
        	
            sp.Command.AddParameter("@FirstRow", FirstRow, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LastRow", LastRow, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SearchArticleByKeywordCount Procedure
        /// </summary>
        public static StoredProcedure SearchArticleByKeywordCount(string KeyWords)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SearchArticleByKeywordCount", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@KeyWords", KeyWords, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the SystemLogging Procedure
        /// </summary>
        public static StoredProcedure SystemLogging(string Action, string Detail)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("SystemLogging", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@Action", Action, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Detail", Detail, DbType.String, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the UpdateCategoryPIdAndOrder Procedure
        /// </summary>
        public static StoredProcedure UpdateCategoryPIdAndOrder(int? Id, int? PId, int? Ord, DateTime? LastModifiedAt, int? LastModifiedBy)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("UpdateCategoryPIdAndOrder", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@Id", Id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PId", PId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Ord", Ord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Last_Modified_At", LastModifiedAt, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@Last_Modified_By", LastModifiedBy, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the UpdateMenuPIdAndOrder Procedure
        /// </summary>
        public static StoredProcedure UpdateMenuPIdAndOrder(int? Id, int? PId, int? Ord, DateTime? LastModifiedAt, int? LastModifiedBy)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("UpdateMenuPIdAndOrder", DataService.GetInstance("VCMS"), "dbo");
        	
            sp.Command.AddParameter("@Id", Id, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@PId", PId, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Ord", Ord, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Last_Modified_At", LastModifiedAt, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@Last_Modified_By", LastModifiedBy, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
    }
    
}
