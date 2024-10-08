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
    /// Controller class for Category
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CategoryController
    {
        // Preload our schema..
        Category thisSchemaLoad = new Category();
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
        public CategoryCollection FetchAll()
        {
            CategoryCollection coll = new CategoryCollection();
            Query qry = new Query(Category.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CategoryCollection FetchByID(object Id)
        {
            CategoryCollection coll = new CategoryCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CategoryCollection FetchByQuery(Query qry)
        {
            CategoryCollection coll = new CategoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Category.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Category.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int PartitionId,int? PId,int Ord,string Name,string AliasX,string DisplayName,string Url,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Category item = new Category();
		    
            item.PartitionId = PartitionId;
            
            item.PId = PId;
            
            item.Ord = Ord;
            
            item.Name = Name;
            
            item.AliasX = AliasX;
            
            item.DisplayName = DisplayName;
            
            item.Url = Url;
            
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
	    public void Update(int Id,int PartitionId,int? PId,int Ord,string Name,string AliasX,string DisplayName,string Url,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Category item = new Category();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.PartitionId = PartitionId;
				
			item.PId = PId;
				
			item.Ord = Ord;
				
			item.Name = Name;
				
			item.AliasX = AliasX;
				
			item.DisplayName = DisplayName;
				
			item.Url = Url;
				
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
