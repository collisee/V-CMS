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
    /// Controller class for Surveys
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SurveyController
    {
        // Preload our schema..
        Survey thisSchemaLoad = new Survey();
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
        public SurveyCollection FetchAll()
        {
            SurveyCollection coll = new SurveyCollection();
            Query qry = new Query(Survey.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyCollection FetchByID(object SurveyId)
        {
            SurveyCollection coll = new SurveyCollection().Where("SurveyId", SurveyId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SurveyCollection FetchByQuery(Query qry)
        {
            SurveyCollection coll = new SurveyCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SurveyId)
        {
            return (Survey.Delete(SurveyId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SurveyId)
        {
            return (Survey.Destroy(SurveyId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SurveyId,string Question,string Tags,string OptionType,string Notes,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiOn,bool IsDeleted,bool IsActive,byte? Status)
	    {
		    Survey item = new Survey();
		    
            item.SurveyId = SurveyId;
            
            item.Question = Question;
            
            item.Tags = Tags;
            
            item.OptionType = OptionType;
            
            item.Notes = Notes;
            
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
	    public void Update(int SurveyId,string Question,string Tags,string OptionType,string Notes,string CreatedBy,DateTime CreatedOn,string ModifiedBy,DateTime ModifiOn,bool IsDeleted,bool IsActive,byte? Status)
	    {
		    Survey item = new Survey();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SurveyId = SurveyId;
				
			item.Question = Question;
				
			item.Tags = Tags;
				
			item.OptionType = OptionType;
				
			item.Notes = Notes;
				
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
