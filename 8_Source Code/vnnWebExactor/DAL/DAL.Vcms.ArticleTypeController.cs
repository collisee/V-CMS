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
    /// Controller class for ArticleType
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ArticleTypeController
    {
        // Preload our schema..
        ArticleType thisSchemaLoad = new ArticleType();
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
        public ArticleTypeCollection FetchAll()
        {
            ArticleTypeCollection coll = new ArticleTypeCollection();
            Query qry = new Query(ArticleType.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleTypeCollection FetchByID(object Id)
        {
            ArticleTypeCollection coll = new ArticleTypeCollection().Where("Id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleTypeCollection FetchByQuery(Query qry)
        {
            ArticleTypeCollection coll = new ArticleTypeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ArticleType.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ArticleType.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string Detail,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleType item = new ArticleType();
		    
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
		    ArticleType item = new ArticleType();
		    
				item.Id = Id;
				
				item.Name = Name;
				
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


