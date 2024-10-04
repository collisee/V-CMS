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
    /// Controller class for ArticleVersion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ArticleVersionController
    {
        // Preload our schema..
        ArticleVersion thisSchemaLoad = new ArticleVersion();
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
        public ArticleVersionCollection FetchAll()
        {
            ArticleVersionCollection coll = new ArticleVersionCollection();
            Query qry = new Query(ArticleVersion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleVersionCollection FetchByID(object Id)
        {
            ArticleVersionCollection coll = new ArticleVersionCollection().Where("Id", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleVersionCollection FetchByQuery(Query qry)
        {
            ArticleVersionCollection coll = new ArticleVersionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (ArticleVersion.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (ArticleVersion.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ArticleId,int VersionId,string Status,int ArticleTypeId,int ArticleContentTypeId,string Name,string Title,string SubTitle1,string SubTitle2,string SubTitle3,string SubTitle4,string SubTitle5,string SubTitle6,string ImageLink,string ImageLink1,string ImageLink2,string ImageLink3,string ImageLink4,string ImageLink5,string Lead,string Detail,DateTime PublishDate,string Author,string AuthorInfo,int IsMember,int TotalView,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleVersion item = new ArticleVersion();
		    
            item.ArticleId = ArticleId;
            
            item.VersionId = VersionId;
            
            item.Status = Status;
            
            item.ArticleTypeId = ArticleTypeId;
            
            item.ArticleContentTypeId = ArticleContentTypeId;
            
            item.Name = Name;
            
            item.Title = Title;
            
            item.SubTitle1 = SubTitle1;
            
            item.SubTitle2 = SubTitle2;
            
            item.SubTitle3 = SubTitle3;
            
            item.SubTitle4 = SubTitle4;
            
            item.SubTitle5 = SubTitle5;
            
            item.SubTitle6 = SubTitle6;
            
            item.ImageLink = ImageLink;
            
            item.ImageLink1 = ImageLink1;
            
            item.ImageLink2 = ImageLink2;
            
            item.ImageLink3 = ImageLink3;
            
            item.ImageLink4 = ImageLink4;
            
            item.ImageLink5 = ImageLink5;
            
            item.Lead = Lead;
            
            item.Detail = Detail;
            
            item.PublishDate = PublishDate;
            
            item.Author = Author;
            
            item.AuthorInfo = AuthorInfo;
            
            item.IsMember = IsMember;
            
            item.TotalView = TotalView;
            
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
	    public void Update(int Id,int ArticleId,int VersionId,string Status,int ArticleTypeId,int ArticleContentTypeId,string Name,string Title,string SubTitle1,string SubTitle2,string SubTitle3,string SubTitle4,string SubTitle5,string SubTitle6,string ImageLink,string ImageLink1,string ImageLink2,string ImageLink3,string ImageLink4,string ImageLink5,string Lead,string Detail,DateTime PublishDate,string Author,string AuthorInfo,int IsMember,int TotalView,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    ArticleVersion item = new ArticleVersion();
		    
				item.Id = Id;
				
				item.ArticleId = ArticleId;
				
				item.VersionId = VersionId;
				
				item.Status = Status;
				
				item.ArticleTypeId = ArticleTypeId;
				
				item.ArticleContentTypeId = ArticleContentTypeId;
				
				item.Name = Name;
				
				item.Title = Title;
				
				item.SubTitle1 = SubTitle1;
				
				item.SubTitle2 = SubTitle2;
				
				item.SubTitle3 = SubTitle3;
				
				item.SubTitle4 = SubTitle4;
				
				item.SubTitle5 = SubTitle5;
				
				item.SubTitle6 = SubTitle6;
				
				item.ImageLink = ImageLink;
				
				item.ImageLink1 = ImageLink1;
				
				item.ImageLink2 = ImageLink2;
				
				item.ImageLink3 = ImageLink3;
				
				item.ImageLink4 = ImageLink4;
				
				item.ImageLink5 = ImageLink5;
				
				item.Lead = Lead;
				
				item.Detail = Detail;
				
				item.PublishDate = PublishDate;
				
				item.Author = Author;
				
				item.AuthorInfo = AuthorInfo;
				
				item.IsMember = IsMember;
				
				item.TotalView = TotalView;
				
				item.History = History;
				
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


