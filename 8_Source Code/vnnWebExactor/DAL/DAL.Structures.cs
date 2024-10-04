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
	#region Tables Struct
	public partial struct Tables
	{
		
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
        
		public static string ModuleX = @"Module";
        
		public static string Policy = @"Policy";
        
		public static string Source = @"Sources";
        
		public static string User = @"User";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	
	public static string VCMS = @"VCMS";
    
}

#endregion

