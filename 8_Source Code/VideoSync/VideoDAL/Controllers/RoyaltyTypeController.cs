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
    /// Controller class for RoyaltyTypes
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RoyaltyTypeController
    {
        // Preload our schema..
        RoyaltyType thisSchemaLoad = new RoyaltyType();
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
        public RoyaltyTypeCollection FetchAll()
        {
            RoyaltyTypeCollection coll = new RoyaltyTypeCollection();
            Query qry = new Query(RoyaltyType.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RoyaltyTypeCollection FetchByID(object TypeId)
        {
            RoyaltyTypeCollection coll = new RoyaltyTypeCollection().Where("Type_Id", TypeId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RoyaltyTypeCollection FetchByQuery(Query qry)
        {
            RoyaltyTypeCollection coll = new RoyaltyTypeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TypeId)
        {
            return (RoyaltyType.Delete(TypeId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TypeId)
        {
            return (RoyaltyType.Destroy(TypeId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Title,string Description,int? ParentId,decimal? MinVal,decimal? MaxVal,DateTime? CreatedAt,int? CreatedBy,DateTime? LastModifiedAt,int? LastModifiedBy,string Flag)
	    {
		    RoyaltyType item = new RoyaltyType();
		    
            item.Title = Title;
            
            item.Description = Description;
            
            item.ParentId = ParentId;
            
            item.MinVal = MinVal;
            
            item.MaxVal = MaxVal;
            
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
	    public void Update(int TypeId,string Title,string Description,int? ParentId,decimal? MinVal,decimal? MaxVal,DateTime? CreatedAt,int? CreatedBy,DateTime? LastModifiedAt,int? LastModifiedBy,string Flag)
	    {
		    RoyaltyType item = new RoyaltyType();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TypeId = TypeId;
				
			item.Title = Title;
				
			item.Description = Description;
				
			item.ParentId = ParentId;
				
			item.MinVal = MinVal;
				
			item.MaxVal = MaxVal;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
