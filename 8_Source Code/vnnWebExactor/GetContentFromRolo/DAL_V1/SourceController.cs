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
    /// Controller class for Sources
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SourceController
    {
        // Preload our schema..
        Source thisSchemaLoad = new Source();
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
        public SourceCollection FetchAll()
        {
            SourceCollection coll = new SourceCollection();
            Query qry = new Query(Source.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SourceCollection FetchByID(object Id)
        {
            SourceCollection coll = new SourceCollection().Where("ID", Id).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SourceCollection FetchByQuery(Query qry)
        {
            SourceCollection coll = new SourceCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Source.Delete(Id) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Source.Destroy(Id) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Id,string Href,string StartTags,string EndTags,string TitleStartTags,string TitleEndTags,string DescStartTags,string DescEndTags,string ContentStartTags,string ContentEndTags,string Description,int? CategoryID,string SourceX,bool? NewsFlag,string WholeImagePath,string ImageDirectory,string ServiceName)
	    {
		    Source item = new Source();
		    
            item.Id = Id;
            
            item.Href = Href;
            
            item.StartTags = StartTags;
            
            item.EndTags = EndTags;
            
            item.TitleStartTags = TitleStartTags;
            
            item.TitleEndTags = TitleEndTags;
            
            item.DescStartTags = DescStartTags;
            
            item.DescEndTags = DescEndTags;
            
            item.ContentStartTags = ContentStartTags;
            
            item.ContentEndTags = ContentEndTags;
            
            item.Description = Description;
            
            item.CategoryID = CategoryID;
            
            item.SourceX = SourceX;
            
            item.NewsFlag = NewsFlag;
            
            item.WholeImagePath = WholeImagePath;
            
            item.ImageDirectory = ImageDirectory;
            
            item.ServiceName = ServiceName;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Href,string StartTags,string EndTags,string TitleStartTags,string TitleEndTags,string DescStartTags,string DescEndTags,string ContentStartTags,string ContentEndTags,string Description,int? CategoryID,string SourceX,bool? NewsFlag,string WholeImagePath,string ImageDirectory,string ServiceName)
	    {
		    Source item = new Source();
		    
				item.Id = Id;
				
				item.Href = Href;
				
				item.StartTags = StartTags;
				
				item.EndTags = EndTags;
				
				item.TitleStartTags = TitleStartTags;
				
				item.TitleEndTags = TitleEndTags;
				
				item.DescStartTags = DescStartTags;
				
				item.DescEndTags = DescEndTags;
				
				item.ContentStartTags = ContentStartTags;
				
				item.ContentEndTags = ContentEndTags;
				
				item.Description = Description;
				
				item.CategoryID = CategoryID;
				
				item.SourceX = SourceX;
				
				item.NewsFlag = NewsFlag;
				
				item.WholeImagePath = WholeImagePath;
				
				item.ImageDirectory = ImageDirectory;
				
				item.ServiceName = ServiceName;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}


