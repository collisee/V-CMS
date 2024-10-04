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
    /// Controller class for SurveyResults
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SurveyResultController
    {
        // Preload our schema..
        SurveyResult thisSchemaLoad = new SurveyResult();
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
        public SurveyResultCollection FetchAll()
        {
            SurveyResultCollection coll = new SurveyResultCollection();
            Query qry = new Query(SurveyResult.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyResultCollection FetchByID(object SurveyResultId)
        {
            SurveyResultCollection coll = new SurveyResultCollection().Where("SurveyResultId", SurveyResultId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyResultCollection FetchByQuery(Query qry)
        {
            SurveyResultCollection coll = new SurveyResultCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SurveyResultId)
        {
            return (SurveyResult.Delete(SurveyResultId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SurveyResultId)
        {
            return (SurveyResult.Destroy(SurveyResultId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SurveyOptionId,string Notes,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiOn,bool? IsDeleted,bool? IsActive)
	    {
		    SurveyResult item = new SurveyResult();
		    
            item.SurveyOptionId = SurveyOptionId;
            
            item.Notes = Notes;
            
            item.CreatedBy = CreatedBy;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedBy = ModifiedBy;
            
            item.ModifiOn = ModifiOn;
            
            item.IsDeleted = IsDeleted;
            
            item.IsActive = IsActive;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SurveyResultId,int SurveyOptionId,string Notes,string CreatedBy,DateTime? CreatedOn,string ModifiedBy,DateTime? ModifiOn,bool? IsDeleted,bool? IsActive)
	    {
		    SurveyResult item = new SurveyResult();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SurveyResultId = SurveyResultId;
				
			item.SurveyOptionId = SurveyOptionId;
				
			item.Notes = Notes;
				
			item.CreatedBy = CreatedBy;
				
			item.CreatedOn = CreatedOn;
				
			item.ModifiedBy = ModifiedBy;
				
			item.ModifiOn = ModifiOn;
				
			item.IsDeleted = IsDeleted;
				
			item.IsActive = IsActive;
				
	        item.Save(UserName);
	    }
    }
}
