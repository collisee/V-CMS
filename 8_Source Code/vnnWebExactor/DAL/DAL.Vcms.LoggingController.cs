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
    /// Controller class for Logging
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LoggingController
    {
        // Preload our schema..
        Logging thisSchemaLoad = new Logging();
        private string userName = string.Empty;
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
        public LoggingCollection FetchAll()
        {
            LoggingCollection coll = new LoggingCollection();
            Query qry = new Query(Logging.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LoggingCollection FetchByID(object Id)
        {
            LoggingCollection coll = new LoggingCollection().Where("Id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LoggingCollection FetchByQuery(Query qry)
        {
            LoggingCollection coll = new LoggingCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Logging.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Logging.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime LogTime,int LogLevel,string Ip,int UId,string UserFullName,string Action,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Logging item = new Logging();
		    
            item.LogTime = LogTime;
            
            item.LogLevel = LogLevel;
            
            item.Ip = Ip;
            
            item.UId = UId;
            
            item.UserFullName = UserFullName;
            
            item.Action = Action;
            
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
	    public void Update(int Id,DateTime LogTime,int LogLevel,string Ip,int UId,string UserFullName,string Action,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Logging item = new Logging();
		    
				item.Id = Id;
				
				item.LogTime = LogTime;
				
				item.LogLevel = LogLevel;
				
				item.Ip = Ip;
				
				item.UId = UId;
				
				item.UserFullName = UserFullName;
				
				item.Action = Action;
				
				item.Detail = Detail;
				
				item.CreatedAt = CreatedAt;
				
				item.CreatedBy = CreatedBy;
				
				item.LastModifiedAt = LastModifiedAt;
				
				item.LastModifiedBy = LastModifiedBy;
				
				item.Flag = Flag;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}


