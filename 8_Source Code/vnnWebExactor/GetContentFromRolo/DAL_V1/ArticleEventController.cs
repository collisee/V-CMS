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
namespace DAL
{
    /// <summary>
    /// Controller class for ArticleEvent
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ArticleEventController
    {
        // Preload our schema..
        ArticleEvent thisSchemaLoad = new ArticleEvent();
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
        public ArticleEventCollection FetchAll()
        {
            ArticleEventCollection coll = new ArticleEventCollection();
            Query qry = new Query(ArticleEvent.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleEventCollection FetchByID(object Id)
        {
            ArticleEventCollection coll = new ArticleEventCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleEventCollection FetchByQuery(Query qry)
        {
            ArticleEventCollection coll = new ArticleEventCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ArticleEvent.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ArticleEvent.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Status,string Name,string Title,string ImageLink,string Lead,string Detail,DateTime PublishDate,int TotalView,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleEvent item = new ArticleEvent();
		    
            item.Status = Status;
            
            item.Name = Name;
            
            item.Title = Title;
            
            item.ImageLink = ImageLink;
            
            item.Lead = Lead;
            
            item.Detail = Detail;
            
            item.PublishDate = PublishDate;
            
            item.TotalView = TotalView;
            
            item.History = History;
            
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
	    public void Update(int Id,string Status,string Name,string Title,string ImageLink,string Lead,string Detail,DateTime PublishDate,int TotalView,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleEvent item = new ArticleEvent();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Status = Status;
				
			item.Name = Name;
				
			item.Title = Title;
				
			item.ImageLink = ImageLink;
				
			item.Lead = Lead;
				
			item.Detail = Detail;
				
			item.PublishDate = PublishDate;
				
			item.TotalView = TotalView;
				
			item.History = History;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
