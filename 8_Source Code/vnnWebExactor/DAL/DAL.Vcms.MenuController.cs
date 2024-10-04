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
    /// Controller class for Menu
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class MenuController
    {
        // Preload our schema..
        Menu thisSchemaLoad = new Menu();
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
        public MenuCollection FetchAll()
        {
            MenuCollection coll = new MenuCollection();
            Query qry = new Query(Menu.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public MenuCollection FetchByID(object Id)
        {
            MenuCollection coll = new MenuCollection().Where("Id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public MenuCollection FetchByQuery(Query qry)
        {
            MenuCollection coll = new MenuCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Menu.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Menu.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? PId,int Ord,string Name,string DisplayName,string Link,int ModuleId,int Access,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Menu item = new Menu();
		    
            item.PId = PId;
            
            item.Ord = Ord;
            
            item.Name = Name;
            
            item.DisplayName = DisplayName;
            
            item.Link = Link;
            
            item.ModuleId = ModuleId;
            
            item.Access = Access;
            
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
	    public void Update(int Id,int? PId,int Ord,string Name,string DisplayName,string Link,int ModuleId,int Access,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Menu item = new Menu();
		    
				item.Id = Id;
				
				item.PId = PId;
				
				item.Ord = Ord;
				
				item.Name = Name;
				
				item.DisplayName = DisplayName;
				
				item.Link = Link;
				
				item.ModuleId = ModuleId;
				
				item.Access = Access;
				
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


