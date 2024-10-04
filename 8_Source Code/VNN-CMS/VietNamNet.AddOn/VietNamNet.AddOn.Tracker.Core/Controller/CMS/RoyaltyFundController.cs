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
namespace VietNamNet.AddOn.Tracker.Core.CMS
{
    /// <summary>
    /// Controller class for RoyaltyFund
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class RoyaltyFundController
    {
        // Preload our schema..
        RoyaltyFund thisSchemaLoad = new RoyaltyFund();
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
        public RoyaltyFundCollection FetchAll()
        {
            RoyaltyFundCollection coll = new RoyaltyFundCollection();
            Query qry = new Query(RoyaltyFund.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public RoyaltyFundCollection FetchByID(object FundId)
        {
            RoyaltyFundCollection coll = new RoyaltyFundCollection().Where("Fund_Id", FundId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public RoyaltyFundCollection FetchByQuery(Query qry)
        {
            RoyaltyFundCollection coll = new RoyaltyFundCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object FundId)
        {
            return (RoyaltyFund.Delete(FundId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object FundId)
        {
            return (RoyaltyFund.Destroy(FundId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ArticleId,int? TextFund,int? ImageFund,int? AudioFund,int? VideoFund,int? OtherFund,string Notes,int? AuthorId,int? AuthorIsMember,int? SetterId,int? TypeId,string SetType,DateTime? PayDate,int PayStatus,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    RoyaltyFund item = new RoyaltyFund();
		    
            item.ArticleId = ArticleId;
            
            item.TextFund = TextFund;
            
            item.ImageFund = ImageFund;
            
            item.AudioFund = AudioFund;
            
            item.VideoFund = VideoFund;
            
            item.OtherFund = OtherFund;
            
            item.Notes = Notes;
            
            item.AuthorId = AuthorId;
            
            item.AuthorIsMember = AuthorIsMember;
            
            item.SetterId = SetterId;
            
            item.TypeId = TypeId;
            
            item.SetType = SetType;
            
            item.PayDate = PayDate;
            
            item.PayStatus = PayStatus;
            
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
	    public void Update(int FundId,int ArticleId,int? TextFund,int? ImageFund,int? AudioFund,int? VideoFund,int? OtherFund,string Notes,int? AuthorId,int? AuthorIsMember,int? SetterId,int? TypeId,string SetType,DateTime? PayDate,int PayStatus,DateTime CreatedAt,int CreatedBy,DateTime LastModifiedAt,int LastModifiedBy,string Flag)
	    {
		    RoyaltyFund item = new RoyaltyFund();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.FundId = FundId;
				
			item.ArticleId = ArticleId;
				
			item.TextFund = TextFund;
				
			item.ImageFund = ImageFund;
				
			item.AudioFund = AudioFund;
				
			item.VideoFund = VideoFund;
				
			item.OtherFund = OtherFund;
				
			item.Notes = Notes;
				
			item.AuthorId = AuthorId;
				
			item.AuthorIsMember = AuthorIsMember;
				
			item.SetterId = SetterId;
				
			item.TypeId = TypeId;
				
			item.SetType = SetType;
				
			item.PayDate = PayDate;
				
			item.PayStatus = PayStatus;
				
			item.CreatedAt = CreatedAt;
				
			item.CreatedBy = CreatedBy;
				
			item.LastModifiedAt = LastModifiedAt;
				
			item.LastModifiedBy = LastModifiedBy;
				
			item.Flag = Flag;
				
	        item.Save(UserName);
	    }
    }
}
