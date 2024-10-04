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
    /// Controller class for MessageDelivery
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MessageDeliveryController
    {
        // Preload our schema..
        MessageDelivery thisSchemaLoad = new MessageDelivery();
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
        public MessageDeliveryCollection FetchAll()
        {
            MessageDeliveryCollection coll = new MessageDeliveryCollection();
            Query qry = new Query(MessageDelivery.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MessageDeliveryCollection FetchByID(object Id)
        {
            MessageDeliveryCollection coll = new MessageDeliveryCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MessageDeliveryCollection FetchByQuery(Query qry)
        {
            MessageDeliveryCollection coll = new MessageDeliveryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (MessageDelivery.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (MessageDelivery.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int MessageId,string Status,int FromUserId,int ToUserId,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    MessageDelivery item = new MessageDelivery();
		    
            item.MessageId = MessageId;
            
            item.Status = Status;
            
            item.FromUserId = FromUserId;
            
            item.ToUserId = ToUserId;
            
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
	    public void Update(int Id,int MessageId,string Status,int FromUserId,int ToUserId,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    MessageDelivery item = new MessageDelivery();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.MessageId = MessageId;
				
			item.Status = Status;
				
			item.FromUserId = FromUserId;
				
			item.ToUserId = ToUserId;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
