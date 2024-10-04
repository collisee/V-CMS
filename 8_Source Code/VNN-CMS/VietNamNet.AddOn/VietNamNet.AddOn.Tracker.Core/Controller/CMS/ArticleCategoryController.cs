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
namespace VietNamNet.AddOn.Tracker.Core.CMS
{
    /// <summary>
    /// Controller class for ArticleCategory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ArticleCategoryController
    {
        // Preload our schema..
        ArticleCategory thisSchemaLoad = new ArticleCategory();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ArticleCategoryCollection FetchAll()
        {
            ArticleCategoryCollection coll = new ArticleCategoryCollection();
            Query qry = new Query(ArticleCategory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleCategoryCollection FetchByID(object Id)
        {
            ArticleCategoryCollection coll = new ArticleCategoryCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleCategoryCollection FetchByQuery(Query qry)
        {
            ArticleCategoryCollection coll = new ArticleCategoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ArticleCategory.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ArticleCategory.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CategoryId,int PartitionId,int ArticleId,int Ord,int ArticleContentTypeId,string Url,DateTime PublishDate,int PrimaryCategory,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag,int? PartitionNumber)
	    {
		    ArticleCategory item = new ArticleCategory();
		    
            item.CategoryId = CategoryId;
            
            item.PartitionId = PartitionId;
            
            item.ArticleId = ArticleId;
            
            item.Ord = Ord;
            
            item.ArticleContentTypeId = ArticleContentTypeId;
            
            item.Url = Url;
            
            item.PublishDate = PublishDate;
            
            item.PrimaryCategory = PrimaryCategory;
            
            item.CreatedAt = CreatedAt;
            
            item.CreatedBy = CreatedBy;
            
            item.LastModifiedAt = LastModifiedAt;
            
            item.LastModifiedBy = LastModifiedBy;
            
            item.Flag = Flag;
            
            item.PartitionNumber = PartitionNumber;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int CategoryId,int PartitionId,int ArticleId,int Ord,int ArticleContentTypeId,string Url,DateTime PublishDate,int PrimaryCategory,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag,int? PartitionNumber)
	    {
		    ArticleCategory item = new ArticleCategory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.CategoryId = CategoryId;
				
			item.PartitionId = PartitionId;
				
			item.ArticleId = ArticleId;
				
			item.Ord = Ord;
				
			item.ArticleContentTypeId = ArticleContentTypeId;
				
			item.Url = Url;
				
			item.PublishDate = PublishDate;
				
			item.PrimaryCategory = PrimaryCategory;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
			item.PartitionNumber = PartitionNumber;
				
	        item.Save(UserName);
	    }
    }
}
