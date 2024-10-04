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
    /// Controller class for SurveyPublishs
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SurveyPublishController
    {
        // Preload our schema..
        SurveyPublish thisSchemaLoad = new SurveyPublish();
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
        public SurveyPublishCollection FetchAll()
        {
            SurveyPublishCollection coll = new SurveyPublishCollection();
            Query qry = new Query(SurveyPublish.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyPublishCollection FetchByID(object SurveyPublishId)
        {
            SurveyPublishCollection coll = new SurveyPublishCollection().Where("SurveyPublishId", SurveyPublishId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyPublishCollection FetchByQuery(Query qry)
        {
            SurveyPublishCollection coll = new SurveyPublishCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SurveyPublishId)
        {
            return (SurveyPublish.Delete(SurveyPublishId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SurveyPublishId)
        {
            return (SurveyPublish.Destroy(SurveyPublishId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SurveyId,int? ArticleId,int? CategoryId,DateTime StartDate,DateTime ExpireDate,byte Security,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiOn,bool IsDeleted,bool IsActive,byte Status)
	    {
		    SurveyPublish item = new SurveyPublish();
		    
            item.SurveyId = SurveyId;
            
            item.ArticleId = ArticleId;
            
            item.CategoryId = CategoryId;
            
            item.StartDate = StartDate;
            
            item.ExpireDate = ExpireDate;
            
            item.Security = Security;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiOn = ModifiOn;
            
            item.IsDeleted = IsDeleted;
            
            item.IsActive = IsActive;
            
            item.Status = Status;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SurveyPublishId,int SurveyId,int? ArticleId,int? CategoryId,DateTime StartDate,DateTime ExpireDate,byte Security,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiOn,bool IsDeleted,bool IsActive,byte Status)
	    {
		    SurveyPublish item = new SurveyPublish();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SurveyPublishId = SurveyPublishId;
				
			item.SurveyId = SurveyId;
				
			item.ArticleId = ArticleId;
				
			item.CategoryId = CategoryId;
				
			item.StartDate = StartDate;
				
			item.ExpireDate = ExpireDate;
				
			item.Security = Security;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiOn = ModifiOn;
				
			item.IsDeleted = IsDeleted;
				
			item.IsActive = IsActive;
				
			item.Status = Status;
				
	        item.Save(UserName);
	    }
    }
}
