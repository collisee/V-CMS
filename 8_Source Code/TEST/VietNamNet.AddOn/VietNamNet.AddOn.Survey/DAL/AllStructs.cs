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
namespace VietNamNet.AddOn.SurveyModule.DAL
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string SurveyOption = @"SurveyOptions";
        
		public static string SurveyPublish = @"SurveyPublishs";
        
		public static string SurveyResult = @"SurveyResults";
        
		public static string Survey = @"Surveys";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table SurveyOption{
            get { return DataService.GetSchema("SurveyOptions","VietNamNet_Surveys"); }
		}
        
		public static TableSchema.Table SurveyPublish{
            get { return DataService.GetSchema("SurveyPublishs","VietNamNet_Surveys"); }
		}
        
		public static TableSchema.Table SurveyResult{
            get { return DataService.GetSchema("SurveyResults","VietNamNet_Surveys"); }
		}
        
		public static TableSchema.Table Survey{
            get { return DataService.GetSchema("Surveys","VietNamNet_Surveys"); }
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
        public static DataProvider _provider = DataService.Providers["VietNamNet_Surveys"];
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
	
	public static string VietNamNet_Surveys = @"VietNamNet_Surveys";
    
}
#endregion