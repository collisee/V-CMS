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
namespace VietNamNet.AddOn.Tracker.Core.tracker
{
    /// <summary>
    /// Controller class for Tracking_Articles
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TrackingArticleController
    {
        // Preload our schema..
        TrackingArticle thisSchemaLoad = new TrackingArticle();
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
        public TrackingArticleCollection FetchAll()
        {
            TrackingArticleCollection coll = new TrackingArticleCollection();
            Query qry = new Query(TrackingArticle.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TrackingArticleCollection FetchByID(object Id)
        {
            TrackingArticleCollection coll = new TrackingArticleCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TrackingArticleCollection FetchByQuery(Query qry)
        {
            TrackingArticleCollection coll = new TrackingArticleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (TrackingArticle.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (TrackingArticle.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string IPAddress,int? ArticleId,string CategoryAlias,DateTime? CreatedOn,DateTime? ModifyOn)
	    {
		    TrackingArticle item = new TrackingArticle();
		    
            item.IPAddress = IPAddress;
            
            item.ArticleId = ArticleId;
            
            item.CategoryAlias = CategoryAlias;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifyOn = ModifyOn;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string IPAddress,int? ArticleId,string CategoryAlias,DateTime? CreatedOn,DateTime? ModifyOn)
	    {
		    TrackingArticle item = new TrackingArticle();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.IPAddress = IPAddress;
				
			item.ArticleId = ArticleId;
				
			item.CategoryAlias = CategoryAlias;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifyOn = ModifyOn;
				
	        item.Save(UserName);
	    }
    }
}
