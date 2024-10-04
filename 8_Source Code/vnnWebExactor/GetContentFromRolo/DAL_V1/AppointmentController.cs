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
    /// Controller class for Appointment
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AppointmentController
    {
        // Preload our schema..
        Appointment thisSchemaLoad = new Appointment();
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
        public AppointmentCollection FetchAll()
        {
            AppointmentCollection coll = new AppointmentCollection();
            Query qry = new Query(Appointment.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AppointmentCollection FetchByID(object Id)
        {
            AppointmentCollection coll = new AppointmentCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AppointmentCollection FetchByQuery(Query qry)
        {
            AppointmentCollection coll = new AppointmentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Appointment.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Appointment.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Subject,DateTime StartTime,DateTime EndTime,string RecurrenceRule,int? RecurrenceParentID,int AppointmentTypeId,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Appointment item = new Appointment();
		    
            item.Subject = Subject;
            
            item.StartTime = StartTime;
            
            item.EndTime = EndTime;
            
            item.RecurrenceRule = RecurrenceRule;
            
            item.RecurrenceParentID = RecurrenceParentID;
            
            item.AppointmentTypeId = AppointmentTypeId;
            
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
	    public void Update(int Id,string Subject,DateTime StartTime,DateTime EndTime,string RecurrenceRule,int? RecurrenceParentID,int AppointmentTypeId,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Appointment item = new Appointment();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Subject = Subject;
				
			item.StartTime = StartTime;
				
			item.EndTime = EndTime;
				
			item.RecurrenceRule = RecurrenceRule;
				
			item.RecurrenceParentID = RecurrenceParentID;
				
			item.AppointmentTypeId = AppointmentTypeId;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
