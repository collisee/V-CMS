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
using VideoDAL.Objects;

namespace VideoDAL
{
    /// <summary>
    /// Controller class for AdvertisementItem
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AdvertisementItemController
    {
        // Preload our schema..
        AdvertisementItem thisSchemaLoad = new AdvertisementItem();
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
        public AdvertisementItemCollection FetchAll()
        {
            AdvertisementItemCollection coll = new AdvertisementItemCollection();
            Query qry = new Query(AdvertisementItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdvertisementItemCollection FetchByID(object Id)
        {
            AdvertisementItemCollection coll = new AdvertisementItemCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdvertisementItemCollection FetchByQuery(Query qry)
        {
            AdvertisementItemCollection coll = new AdvertisementItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (AdvertisementItem.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (AdvertisementItem.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,int TypeId,string Link,string FileLink1,string FileLink2,string FileJS,string CodeJS,DateTime StartTime,DateTime EndTime,string Detail,int? ExWidth,int? ExHeight,int? ExMode,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    AdvertisementItem item = new AdvertisementItem();
		    
            item.Name = Name;
            
            item.TypeId = TypeId;
            
            item.Link = Link;
            
            item.FileLink1 = FileLink1;
            
            item.FileLink2 = FileLink2;
            
            item.FileJS = FileJS;
            
            item.CodeJS = CodeJS;
            
            item.StartTime = StartTime;
            
            item.EndTime = EndTime;
            
            item.Detail = Detail;
            
            item.ExWidth = ExWidth;
            
            item.ExHeight = ExHeight;
            
            item.ExMode = ExMode;
            
            item.History = History;
            
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
	    public void Update(int Id,string Name,int TypeId,string Link,string FileLink1,string FileLink2,string FileJS,string CodeJS,DateTime StartTime,DateTime EndTime,string Detail,int? ExWidth,int? ExHeight,int? ExMode,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    AdvertisementItem item = new AdvertisementItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Name = Name;
				
			item.TypeId = TypeId;
				
			item.Link = Link;
				
			item.FileLink1 = FileLink1;
				
			item.FileLink2 = FileLink2;
				
			item.FileJS = FileJS;
				
			item.CodeJS = CodeJS;
				
			item.StartTime = StartTime;
				
			item.EndTime = EndTime;
				
			item.Detail = Detail;
				
			item.ExWidth = ExWidth;
				
			item.ExHeight = ExHeight;
				
			item.ExMode = ExMode;
				
			item.History = History;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
