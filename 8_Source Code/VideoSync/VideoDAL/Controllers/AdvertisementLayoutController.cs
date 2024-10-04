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
    /// Controller class for AdvertisementLayout
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AdvertisementLayoutController
    {
        // Preload our schema..
        AdvertisementLayout thisSchemaLoad = new AdvertisementLayout();
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
        public AdvertisementLayoutCollection FetchAll()
        {
            AdvertisementLayoutCollection coll = new AdvertisementLayoutCollection();
            Query qry = new Query(AdvertisementLayout.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdvertisementLayoutCollection FetchByID(object Id)
        {
            AdvertisementLayoutCollection coll = new AdvertisementLayoutCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdvertisementLayoutCollection FetchByQuery(Query qry)
        {
            AdvertisementLayoutCollection coll = new AdvertisementLayoutCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AdvertisementLayout.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AdvertisementLayout.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    AdvertisementLayout item = new AdvertisementLayout();
		    
            item.Name = Name;
            
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
	    public void Update(int Id,string Name,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    AdvertisementLayout item = new AdvertisementLayout();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Name = Name;
				
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
