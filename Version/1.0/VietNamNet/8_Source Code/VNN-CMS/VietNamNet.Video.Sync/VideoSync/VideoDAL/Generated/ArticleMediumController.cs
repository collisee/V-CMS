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
namespace VideoDAL
{
    /// <summary>
    /// Controller class for ArticleMedia
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ArticleMediumController
    {
        // Preload our schema..
        ArticleMedium thisSchemaLoad = new ArticleMedium();
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
        public ArticleMediumCollection FetchAll()
        {
            ArticleMediumCollection coll = new ArticleMediumCollection();
            Query qry = new Query(ArticleMedium.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleMediumCollection FetchByID(object Id)
        {
            ArticleMediumCollection coll = new ArticleMediumCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleMediumCollection FetchByQuery(Query qry)
        {
            ArticleMediumCollection coll = new ArticleMediumCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ArticleMedium.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ArticleMedium.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ArticleId,string MediaType,int Ord,string FileLink,string Thumbnail,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleMedium item = new ArticleMedium();
		    
            item.ArticleId = ArticleId;
            
            item.MediaType = MediaType;
            
            item.Ord = Ord;
            
            item.FileLink = FileLink;
            
            item.Thumbnail = Thumbnail;
            
            item.Detail = Detail;
            
            item.CreatedAt = CreatedAt;
            
            item.CreatedBy = CreatedBy;
            
            item.LastModifiedAt = LastModifiedAt;
            
            item.LastModifiedBy = LastModifiedBy;
            
            item.Flag = Flag;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,int ArticleId,string MediaType,int Ord,string FileLink,string Thumbnail,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleMedium item = new ArticleMedium();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.ArticleId = ArticleId;
				
			item.MediaType = MediaType;
				
			item.Ord = Ord;
				
			item.FileLink = FileLink;
				
			item.Thumbnail = Thumbnail;
				
			item.Detail = Detail;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
