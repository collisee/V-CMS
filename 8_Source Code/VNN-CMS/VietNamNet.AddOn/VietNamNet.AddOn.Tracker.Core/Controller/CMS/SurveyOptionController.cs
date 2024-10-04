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
    /// Controller class for SurveyOptions
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SurveyOptionController
    {
        // Preload our schema..
        SurveyOption thisSchemaLoad = new SurveyOption();
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
        public SurveyOptionCollection FetchAll()
        {
            SurveyOptionCollection coll = new SurveyOptionCollection();
            Query qry = new Query(SurveyOption.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyOptionCollection FetchByID(object SurveyOptionId)
        {
            SurveyOptionCollection coll = new SurveyOptionCollection().Where("SurveyOptionId", SurveyOptionId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyOptionCollection FetchByQuery(Query qry)
        {
            SurveyOptionCollection coll = new SurveyOptionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SurveyOptionId)
        {
            return (SurveyOption.Delete(SurveyOptionId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SurveyOptionId)
        {
            return (SurveyOption.Destroy(SurveyOptionId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SurveyOptionId,int SurveyId,string OptionName,int ViewOrder,string Notes,bool? IsOther,bool? IsCorrect,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiOn,bool IsDeleted,bool IsActive)
	    {
		    SurveyOption item = new SurveyOption();
		    
            item.SurveyOptionId = SurveyOptionId;
            
            item.SurveyId = SurveyId;
            
            item.OptionName = OptionName;
            
            item.ViewOrder = ViewOrder;
            
            item.Notes = Notes;
            
            item.IsOther = IsOther;
            
            item.IsCorrect = IsCorrect;
            
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
	    public void Update(int SurveyOptionId,int SurveyId,string OptionName,int ViewOrder,string Notes,bool? IsOther,bool? IsCorrect,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiOn,bool IsDeleted,bool IsActive)
	    {
		    SurveyOption item = new SurveyOption();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SurveyOptionId = SurveyOptionId;
				
			item.SurveyId = SurveyId;
				
			item.OptionName = OptionName;
				
			item.ViewOrder = ViewOrder;
				
			item.Notes = Notes;
				
			item.IsOther = IsOther;
				
			item.IsCorrect = IsCorrect;
				
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
