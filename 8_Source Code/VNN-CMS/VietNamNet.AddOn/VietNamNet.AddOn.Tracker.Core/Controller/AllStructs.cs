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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string AdvertisementBlock = @"AdvertisementBlock";
        
		public static readonly string AdvertisementBlockItem = @"AdvertisementBlockItem";
        
		public static readonly string AdvertisementItem = @"AdvertisementItem";
        
		public static readonly string AdvertisementLayout = @"AdvertisementLayout";
        
		public static readonly string AdvertisementLayoutCategory = @"AdvertisementLayoutCategory";
        
		public static readonly string AdvertisementLayoutZone = @"AdvertisementLayoutZone";
        
		public static readonly string AdvertisementType = @"AdvertisementType";
        
		public static readonly string AdvertisementZone = @"AdvertisementZone";
        
		public static readonly string AdvertisementZoneBlock = @"AdvertisementZoneBlock";
        
		public static readonly string Appointment = @"Appointment";
        
		public static readonly string AppointmentType = @"AppointmentType";
        
		public static readonly string Article = @"Article";
        
		public static readonly string ArticleCategory = @"ArticleCategory";
        
		public static readonly string ArticleComment = @"ArticleComment";
        
		public static readonly string ArticleContentType = @"ArticleContentType";
        
		public static readonly string ArticleEvent = @"ArticleEvent";
        
		public static readonly string ArticleEventCategory = @"ArticleEventCategory";
        
		public static readonly string ArticleEventItem = @"ArticleEventItem";
        
		public static readonly string ArticleMedium = @"ArticleMedia";
        
		public static readonly string ArticleType = @"ArticleType";
        
		public static readonly string ArticleVersion = @"ArticleVersion";
        
		public static readonly string Category = @"Category";
        
		public static readonly string CategoryPolicy = @"CategoryPolicy";
        
		public static readonly string Collaborator = @"Collaborator";
        
		public static readonly string Configuration = @"Configuration";
        
		public static readonly string Function = @"Function";
        
		public static readonly string Group = @"Group";
        
		public static readonly string GroupMember = @"GroupMember";
        
		public static readonly string Logging = @"Logging";
        
		public static readonly string Menu = @"Menu";
        
		public static readonly string Message = @"Message";
        
		public static readonly string MessageDelivery = @"MessageDelivery";
        
		public static readonly string ModuleX = @"Module";
        
		public static readonly string Policy = @"Policy";
        
		public static readonly string Room = @"Room";
        
		public static readonly string RoomBooking = @"RoomBooking";
        
		public static readonly string RoyaltyFund = @"RoyaltyFund";
        
		public static readonly string RoyaltyType = @"RoyaltyTypes";
        
		public static readonly string Source = @"Sources";
        
		public static readonly string SurveyOption = @"SurveyOptions";
        
		public static readonly string SurveyPublish = @"SurveyPublishs";
        
		public static readonly string SurveyResult = @"SurveyResults";
        
		public static readonly string Survey = @"Surveys";
        
		public static readonly string User = @"User";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table AdvertisementBlock
		{
            get { return DataService.GetSchema("AdvertisementBlock", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementBlockItem
		{
            get { return DataService.GetSchema("AdvertisementBlockItem", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementItem
		{
            get { return DataService.GetSchema("AdvertisementItem", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementLayout
		{
            get { return DataService.GetSchema("AdvertisementLayout", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementLayoutCategory
		{
            get { return DataService.GetSchema("AdvertisementLayoutCategory", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementLayoutZone
		{
            get { return DataService.GetSchema("AdvertisementLayoutZone", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementType
		{
            get { return DataService.GetSchema("AdvertisementType", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementZone
		{
            get { return DataService.GetSchema("AdvertisementZone", "VNN"); }
		}
        
		public static TableSchema.Table AdvertisementZoneBlock
		{
            get { return DataService.GetSchema("AdvertisementZoneBlock", "VNN"); }
		}
        
		public static TableSchema.Table Appointment
		{
            get { return DataService.GetSchema("Appointment", "VNN"); }
		}
        
		public static TableSchema.Table AppointmentType
		{
            get { return DataService.GetSchema("AppointmentType", "VNN"); }
		}
        
		public static TableSchema.Table Article
		{
            get { return DataService.GetSchema("Article", "VNN"); }
		}
        
		public static TableSchema.Table ArticleCategory
		{
            get { return DataService.GetSchema("ArticleCategory", "VNN"); }
		}
        
		public static TableSchema.Table ArticleComment
		{
            get { return DataService.GetSchema("ArticleComment", "VNN"); }
		}
        
		public static TableSchema.Table ArticleContentType
		{
            get { return DataService.GetSchema("ArticleContentType", "VNN"); }
		}
        
		public static TableSchema.Table ArticleEvent
		{
            get { return DataService.GetSchema("ArticleEvent", "VNN"); }
		}
        
		public static TableSchema.Table ArticleEventCategory
		{
            get { return DataService.GetSchema("ArticleEventCategory", "VNN"); }
		}
        
		public static TableSchema.Table ArticleEventItem
		{
            get { return DataService.GetSchema("ArticleEventItem", "VNN"); }
		}
        
		public static TableSchema.Table ArticleMedium
		{
            get { return DataService.GetSchema("ArticleMedia", "VNN"); }
		}
        
		public static TableSchema.Table ArticleType
		{
            get { return DataService.GetSchema("ArticleType", "VNN"); }
		}
        
		public static TableSchema.Table ArticleVersion
		{
            get { return DataService.GetSchema("ArticleVersion", "VNN"); }
		}
        
		public static TableSchema.Table Category
		{
            get { return DataService.GetSchema("Category", "VNN"); }
		}
        
		public static TableSchema.Table CategoryPolicy
		{
            get { return DataService.GetSchema("CategoryPolicy", "VNN"); }
		}
        
		public static TableSchema.Table Collaborator
		{
            get { return DataService.GetSchema("Collaborator", "VNN"); }
		}
        
		public static TableSchema.Table Configuration
		{
            get { return DataService.GetSchema("Configuration", "VNN"); }
		}
        
		public static TableSchema.Table Function
		{
            get { return DataService.GetSchema("Function", "VNN"); }
		}
        
		public static TableSchema.Table Group
		{
            get { return DataService.GetSchema("Group", "VNN"); }
		}
        
		public static TableSchema.Table GroupMember
		{
            get { return DataService.GetSchema("GroupMember", "VNN"); }
		}
        
		public static TableSchema.Table Logging
		{
            get { return DataService.GetSchema("Logging", "VNN"); }
		}
        
		public static TableSchema.Table Menu
		{
            get { return DataService.GetSchema("Menu", "VNN"); }
		}
        
		public static TableSchema.Table Message
		{
            get { return DataService.GetSchema("Message", "VNN"); }
		}
        
		public static TableSchema.Table MessageDelivery
		{
            get { return DataService.GetSchema("MessageDelivery", "VNN"); }
		}
        
		public static TableSchema.Table ModuleX
		{
            get { return DataService.GetSchema("Module", "VNN"); }
		}
        
		public static TableSchema.Table Policy
		{
            get { return DataService.GetSchema("Policy", "VNN"); }
		}
        
		public static TableSchema.Table Room
		{
            get { return DataService.GetSchema("Room", "VNN"); }
		}
        
		public static TableSchema.Table RoomBooking
		{
            get { return DataService.GetSchema("RoomBooking", "VNN"); }
		}
        
		public static TableSchema.Table RoyaltyFund
		{
            get { return DataService.GetSchema("RoyaltyFund", "VNN"); }
		}
        
		public static TableSchema.Table RoyaltyType
		{
            get { return DataService.GetSchema("RoyaltyTypes", "VNN"); }
		}
        
		public static TableSchema.Table Source
		{
            get { return DataService.GetSchema("Sources", "VNN"); }
		}
        
		public static TableSchema.Table SurveyOption
		{
            get { return DataService.GetSchema("SurveyOptions", "VNN"); }
		}
        
		public static TableSchema.Table SurveyPublish
		{
            get { return DataService.GetSchema("SurveyPublishs", "VNN"); }
		}
        
		public static TableSchema.Table SurveyResult
		{
            get { return DataService.GetSchema("SurveyResults", "VNN"); }
		}
        
		public static TableSchema.Table Survey
		{
            get { return DataService.GetSchema("Surveys", "VNN"); }
		}
        
		public static TableSchema.Table User
		{
            get { return DataService.GetSchema("User", "VNN"); }
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
        public static DataProvider _provider = DataService.Providers["VNN"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
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
namespace VietNamNet.AddOn.Tracker.Core.tracker
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static readonly string TrackingArticle = @"Tracking_Articles";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table TrackingArticle
		{
            get { return DataService.GetSchema("Tracking_Articles", "VNN_Tracker"); }
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
        public static DataProvider _provider = DataService.Providers["VNN_Tracker"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository 
        {
            get 
            {
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
	
	public static readonly string VNN = @"VNN";
    
	public static readonly string VNN_Tracker = @"VNN_Tracker";
    
}
#endregion