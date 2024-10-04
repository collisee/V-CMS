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
    /// Controller class for AdvertisementZone
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AdvertisementZoneController
    {
        // Preload our schema..
        AdvertisementZone thisSchemaLoad = new AdvertisementZone();
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
        public AdvertisementZoneCollection FetchAll()
        {
            AdvertisementZoneCollection coll = new AdvertisementZoneCollection();
            Query qry = new Query(AdvertisementZone.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdvertisementZoneCollection FetchByID(object Id)
        {
            AdvertisementZoneCollection coll = new AdvertisementZoneCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdvertisementZoneCollection FetchByQuery(Query qry)
        {
            AdvertisementZoneCollection coll = new AdvertisementZoneCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AdvertisementZone.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AdvertisementZone.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string HolderId,string Detail,int Mode,int Direction,int Width,int Height,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    AdvertisementZone item = new AdvertisementZone();
		    
            item.Name = Name;
            
            item.HolderId = HolderId;
            
            item.Detail = Detail;
            
            item.Mode = Mode;
            
            item.Direction = Direction;
            
            item.Width = Width;
            
            item.Height = Height;
            
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
	    public void Update(int Id,string Name,string HolderId,string Detail,int Mode,int Direction,int Width,int Height,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    AdvertisementZone item = new AdvertisementZone();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Name = Name;
				
			item.HolderId = HolderId;
				
			item.Detail = Detail;
				
			item.Mode = Mode;
				
			item.Direction = Direction;
				
			item.Width = Width;
				
			item.Height = Height;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
