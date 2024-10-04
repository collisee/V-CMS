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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string AdvertisementBlock = @"AdvertisementBlock";
        
		public static string AdvertisementBlockItem = @"AdvertisementBlockItem";
        
		public static string AdvertisementItem = @"AdvertisementItem";
        
		public static string AdvertisementLayout = @"AdvertisementLayout";
        
		public static string AdvertisementLayoutCategory = @"AdvertisementLayoutCategory";
        
		public static string AdvertisementLayoutZone = @"AdvertisementLayoutZone";
        
		public static string AdvertisementType = @"AdvertisementType";
        
		public static string AdvertisementZone = @"AdvertisementZone";
        
		public static string AdvertisementZoneBlock = @"AdvertisementZoneBlock";
        
		public static string Appointment = @"Appointment";
        
		public static string AppointmentType = @"AppointmentType";
        
		public static string Article = @"Article";
        
		public static string ArticleCategory = @"ArticleCategory";
        
		public static string ArticleComment = @"ArticleComment";
        
		public static string ArticleContentType = @"ArticleContentType";
        
		public static string ArticleEvent = @"ArticleEvent";
        
		public static string ArticleEventCategory = @"ArticleEventCategory";
        
		public static string ArticleEventItem = @"ArticleEventItem";
        
		public static string ArticleMedium = @"ArticleMedia";
        
		public static string ArticleType = @"ArticleType";
        
		public static string ArticleVersion = @"ArticleVersion";
        
		public static string Category = @"Category";
        
		public static string CategoryPolicy = @"CategoryPolicy";
        
		public static string Collaborator = @"Collaborator";
        
		public static string Configuration = @"Configuration";
        
		public static string Function = @"Function";
        
		public static string Group = @"Group";
        
		public static string GroupMember = @"GroupMember";
        
		public static string Logging = @"Logging";
        
		public static string Menu = @"Menu";
        
		public static string Message = @"Message";
        
		public static string MessageDelivery = @"MessageDelivery";
        
		public static string ModuleX = @"Module";
        
		public static string Policy = @"Policy";
        
		public static string Room = @"Room";
        
		public static string RoomBooking = @"RoomBooking";
        
		public static string RoyaltyFund = @"RoyaltyFund";
        
		public static string RoyaltyType = @"RoyaltyTypes";
        
		public static string User = @"User";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table AdvertisementBlock{
            get { return DataService.GetSchema("AdvertisementBlock","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementBlockItem{
            get { return DataService.GetSchema("AdvertisementBlockItem","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementItem{
            get { return DataService.GetSchema("AdvertisementItem","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementLayout{
            get { return DataService.GetSchema("AdvertisementLayout","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementLayoutCategory{
            get { return DataService.GetSchema("AdvertisementLayoutCategory","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementLayoutZone{
            get { return DataService.GetSchema("AdvertisementLayoutZone","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementType{
            get { return DataService.GetSchema("AdvertisementType","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementZone{
            get { return DataService.GetSchema("AdvertisementZone","VCMS"); }
		}
        
		public static TableSchema.Table AdvertisementZoneBlock{
            get { return DataService.GetSchema("AdvertisementZoneBlock","VCMS"); }
		}
        
		public static TableSchema.Table Appointment{
            get { return DataService.GetSchema("Appointment","VCMS"); }
		}
        
		public static TableSchema.Table AppointmentType{
            get { return DataService.GetSchema("AppointmentType","VCMS"); }
		}
        
		public static TableSchema.Table Article{
            get { return DataService.GetSchema("Article","VCMS"); }
		}
        
		public static TableSchema.Table ArticleCategory{
            get { return DataService.GetSchema("ArticleCategory","VCMS"); }
		}
        
		public static TableSchema.Table ArticleComment{
            get { return DataService.GetSchema("ArticleComment","VCMS"); }
		}
        
		public static TableSchema.Table ArticleContentType{
            get { return DataService.GetSchema("ArticleContentType","VCMS"); }
		}
        
		public static TableSchema.Table ArticleEvent{
            get { return DataService.GetSchema("ArticleEvent","VCMS"); }
		}
        
		public static TableSchema.Table ArticleEventCategory{
            get { return DataService.GetSchema("ArticleEventCategory","VCMS"); }
		}
        
		public static TableSchema.Table ArticleEventItem{
            get { return DataService.GetSchema("ArticleEventItem","VCMS"); }
		}
        
		public static TableSchema.Table ArticleMedium{
            get { return DataService.GetSchema("ArticleMedia","VCMS"); }
		}
        
		public static TableSchema.Table ArticleType{
            get { return DataService.GetSchema("ArticleType","VCMS"); }
		}
        
		public static TableSchema.Table ArticleVersion{
            get { return DataService.GetSchema("ArticleVersion","VCMS"); }
		}
        
		public static TableSchema.Table Category{
            get { return DataService.GetSchema("Category","VCMS"); }
		}
        
		public static TableSchema.Table CategoryPolicy{
            get { return DataService.GetSchema("CategoryPolicy","VCMS"); }
		}
        
		public static TableSchema.Table Collaborator{
            get { return DataService.GetSchema("Collaborator","VCMS"); }
		}
        
		public static TableSchema.Table Configuration{
            get { return DataService.GetSchema("Configuration","VCMS"); }
		}
        
		public static TableSchema.Table Function{
            get { return DataService.GetSchema("Function","VCMS"); }
		}
        
		public static TableSchema.Table Group{
            get { return DataService.GetSchema("Group","VCMS"); }
		}
        
		public static TableSchema.Table GroupMember{
            get { return DataService.GetSchema("GroupMember","VCMS"); }
		}
        
		public static TableSchema.Table Logging{
            get { return DataService.GetSchema("Logging","VCMS"); }
		}
        
		public static TableSchema.Table Menu{
            get { return DataService.GetSchema("Menu","VCMS"); }
		}
        
		public static TableSchema.Table Message{
            get { return DataService.GetSchema("Message","VCMS"); }
		}
        
		public static TableSchema.Table MessageDelivery{
            get { return DataService.GetSchema("MessageDelivery","VCMS"); }
		}
        
		public static TableSchema.Table ModuleX{
            get { return DataService.GetSchema("Module","VCMS"); }
		}
        
		public static TableSchema.Table Policy{
            get { return DataService.GetSchema("Policy","VCMS"); }
		}
        
		public static TableSchema.Table Room{
            get { return DataService.GetSchema("Room","VCMS"); }
		}
        
		public static TableSchema.Table RoomBooking{
            get { return DataService.GetSchema("RoomBooking","VCMS"); }
		}
        
		public static TableSchema.Table RoyaltyFund{
            get { return DataService.GetSchema("RoyaltyFund","VCMS"); }
		}
        
		public static TableSchema.Table RoyaltyType{
            get { return DataService.GetSchema("RoyaltyTypes","VCMS"); }
		}
        
		public static TableSchema.Table User{
            get { return DataService.GetSchema("User","VCMS"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["VCMS"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository {
            get {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
	
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
            
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
     
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static string VCMS = @"VCMS";
    
}
#endregion