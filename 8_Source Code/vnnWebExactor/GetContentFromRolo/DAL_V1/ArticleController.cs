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
    /// Controller class for Article
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ArticleController
    {
        // Preload our schema..
        Article thisSchemaLoad = new Article();
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
        public ArticleCollection FetchAll()
        {
            ArticleCollection coll = new ArticleCollection();
            Query qry = new Query(Article.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleCollection FetchByID(object Id)
        {
            ArticleCollection coll = new ArticleCollection().Where("Id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ArticleCollection FetchByQuery(Query qry)
        {
            ArticleCollection coll = new ArticleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Article.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Article.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int VersionId,string Status,int ArticleTypeId,int ArticleContentTypeId,string Name,string Title,string Url,int CategoryId,int PartitionId,string SubTitle1,string SubTitle2,string SubTitle3,string SubTitle4,string SubTitle5,string SubTitle6,string ImageLink,string ImageLink1,string ImageLink2,string ImageLink3,string ImageLink4,string ImageLink5,string Lead,string Detail,DateTime PublishDate,string Author,string AuthorInfo,int IsMember,int TotalView,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Article item = new Article();
		    
            item.VersionId = VersionId;
            
            item.Status = Status;
            
            item.ArticleTypeId = ArticleTypeId;
            
            item.ArticleContentTypeId = ArticleContentTypeId;
            
            item.Name = Name;
            
            item.Title = Title;
            
            item.Url = Url;
            
            item.CategoryId = CategoryId;
            
            item.PartitionId = PartitionId;
            
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
	    public void Update(int Id,int VersionId,string Status,int ArticleTypeId,int ArticleContentTypeId,string Name,string Title,string Url,int CategoryId,int PartitionId,string SubTitle1,string SubTitle2,string SubTitle3,string SubTitle4,string SubTitle5,string SubTitle6,string ImageLink,string ImageLink1,string ImageLink2,string ImageLink3,string ImageLink4,string ImageLink5,string Lead,string Detail,DateTime PublishDate,string Author,string AuthorInfo,int IsMember,int TotalView,string History,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    Article item = new Article();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.VersionId = VersionId;
				
			item.Status = Status;
				
			item.ArticleTypeId = ArticleTypeId;
				
			item.ArticleContentTypeId = ArticleContentTypeId;
				
			item.Name = Name;
				
			item.Title = Title;
				
			item.Url = Url;
				
			item.CategoryId = CategoryId;
				
			item.PartitionId = PartitionId;
				
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
    }
}
