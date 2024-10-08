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
	/// Strongly-typed collection for the Logging class.
	/// </summary>
    [Serializable]
	public partial class LoggingCollection : ActiveList<Logging, LoggingCollection>
	{	   
		public LoggingCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LoggingCollection</returns>
		public LoggingCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Logging o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the Logging table.
	/// </summary>
	[Serializable]
	public partial class Logging : ActiveRecord<Logging>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Logging()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Logging(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Logging(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Logging(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Logging", TableType.Table, DataService.GetInstance("VCMS"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarLogTime = new TableSchema.TableColumn(schema);
				colvarLogTime.ColumnName = "LogTime";
				colvarLogTime.DataType = DbType.DateTime;
				colvarLogTime.MaxLength = 0;
				colvarLogTime.AutoIncrement = false;
				colvarLogTime.IsNullable = false;
				colvarLogTime.IsPrimaryKey = false;
				colvarLogTime.IsForeignKey = false;
				colvarLogTime.IsReadOnly = false;
				
						colvarLogTime.DefaultSetting = @"(getdate())";
				colvarLogTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogTime);
				
				TableSchema.TableColumn colvarLogLevel = new TableSchema.TableColumn(schema);
				colvarLogLevel.ColumnName = "LogLevel";
				colvarLogLevel.DataType = DbType.Int32;
				colvarLogLevel.MaxLength = 0;
				colvarLogLevel.AutoIncrement = false;
				colvarLogLevel.IsNullable = false;
				colvarLogLevel.IsPrimaryKey = false;
				colvarLogLevel.IsForeignKey = false;
				colvarLogLevel.IsReadOnly = false;
				
						colvarLogLevel.DefaultSetting = @"((0))";
				colvarLogLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogLevel);
				
				TableSchema.TableColumn colvarIp = new TableSchema.TableColumn(schema);
				colvarIp.ColumnName = "IP";
				colvarIp.DataType = DbType.String;
				colvarIp.MaxLength = 50;
				colvarIp.AutoIncrement = false;
				colvarIp.IsNullable = false;
				colvarIp.IsPrimaryKey = false;
				colvarIp.IsForeignKey = false;
				colvarIp.IsReadOnly = false;
				
						colvarIp.DefaultSetting = @"(N'0.0.0.0')";
				colvarIp.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIp);
				
				TableSchema.TableColumn colvarUId = new TableSchema.TableColumn(schema);
				colvarUId.ColumnName = "UId";
				colvarUId.DataType = DbType.Int32;
				colvarUId.MaxLength = 0;
				colvarUId.AutoIncrement = false;
				colvarUId.IsNullable = false;
				colvarUId.IsPrimaryKey = false;
				colvarUId.IsForeignKey = false;
				colvarUId.IsReadOnly = false;
				
						colvarUId.DefaultSetting = @"((0))";
				colvarUId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUId);
				
				TableSchema.TableColumn colvarUserFullName = new TableSchema.TableColumn(schema);
				colvarUserFullName.ColumnName = "UserFullName";
				colvarUserFullName.DataType = DbType.String;
				colvarUserFullName.MaxLength = 255;
				colvarUserFullName.AutoIncrement = false;
				colvarUserFullName.IsNullable = false;
				colvarUserFullName.IsPrimaryKey = false;
				colvarUserFullName.IsForeignKey = false;
				colvarUserFullName.IsReadOnly = false;
				
						colvarUserFullName.DefaultSetting = @"('')";
				colvarUserFullName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserFullName);
				
				TableSchema.TableColumn colvarAction = new TableSchema.TableColumn(schema);
				colvarAction.ColumnName = "Action";
				colvarAction.DataType = DbType.String;
				colvarAction.MaxLength = 255;
				colvarAction.AutoIncrement = false;
				colvarAction.IsNullable = false;
				colvarAction.IsPrimaryKey = false;
				colvarAction.IsForeignKey = false;
				colvarAction.IsReadOnly = false;
				
						colvarAction.DefaultSetting = @"(N'none')";
				colvarAction.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAction);
				
				TableSchema.TableColumn colvarDetail = new TableSchema.TableColumn(schema);
				colvarDetail.ColumnName = "Detail";
				colvarDetail.DataType = DbType.String;
				colvarDetail.MaxLength = 4000;
				colvarDetail.AutoIncrement = false;
				colvarDetail.IsNullable = true;
				colvarDetail.IsPrimaryKey = false;
				colvarDetail.IsForeignKey = false;
				colvarDetail.IsReadOnly = false;
				colvarDetail.DefaultSetting = @"";
				colvarDetail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetail);
				
				TableSchema.TableColumn colvarCreatedAt = new TableSchema.TableColumn(schema);
				colvarCreatedAt.ColumnName = "Created_At";
				colvarCreatedAt.DataType = DbType.DateTime;
				colvarCreatedAt.MaxLength = 0;
				colvarCreatedAt.AutoIncrement = false;
				colvarCreatedAt.IsNullable = false;
				colvarCreatedAt.IsPrimaryKey = false;
				colvarCreatedAt.IsForeignKey = false;
				colvarCreatedAt.IsReadOnly = false;
				
						colvarCreatedAt.DefaultSetting = @"(getdate())";
				colvarCreatedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedAt);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "Created_By";
				colvarCreatedBy.DataType = DbType.Int32;
				colvarCreatedBy.MaxLength = 0;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				
						colvarCreatedBy.DefaultSetting = @"((0))";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarLastModifiedAt = new TableSchema.TableColumn(schema);
				colvarLastModifiedAt.ColumnName = "Last_Modified_At";
				colvarLastModifiedAt.DataType = DbType.DateTime;
				colvarLastModifiedAt.MaxLength = 0;
				colvarLastModifiedAt.AutoIncrement = false;
				colvarLastModifiedAt.IsNullable = false;
				colvarLastModifiedAt.IsPrimaryKey = false;
				colvarLastModifiedAt.IsForeignKey = false;
				colvarLastModifiedAt.IsReadOnly = false;
				
						colvarLastModifiedAt.DefaultSetting = @"(getdate())";
				colvarLastModifiedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastModifiedAt);
				
				TableSchema.TableColumn colvarLastModifiedBy = new TableSchema.TableColumn(schema);
				colvarLastModifiedBy.ColumnName = "Last_Modified_By";
				colvarLastModifiedBy.DataType = DbType.Int32;
				colvarLastModifiedBy.MaxLength = 0;
				colvarLastModifiedBy.AutoIncrement = false;
				colvarLastModifiedBy.IsNullable = false;
				colvarLastModifiedBy.IsPrimaryKey = false;
				colvarLastModifiedBy.IsForeignKey = false;
				colvarLastModifiedBy.IsReadOnly = false;
				
						colvarLastModifiedBy.DefaultSetting = @"((0))";
				colvarLastModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastModifiedBy);
				
				TableSchema.TableColumn colvarFlag = new TableSchema.TableColumn(schema);
				colvarFlag.ColumnName = "flag";
				colvarFlag.DataType = DbType.AnsiStringFixedLength;
				colvarFlag.MaxLength = 1;
				colvarFlag.AutoIncrement = false;
				colvarFlag.IsNullable = true;
				colvarFlag.IsPrimaryKey = false;
				colvarFlag.IsForeignKey = false;
				colvarFlag.IsReadOnly = false;
				colvarFlag.DefaultSetting = @"";
				colvarFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFlag);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VCMS"].AddSchema("Logging",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("LogTime")]
		[Bindable(true)]
		public DateTime LogTime 
		{
			get { return GetColumnValue<DateTime>(Columns.LogTime); }
			set { SetColumnValue(Columns.LogTime, value); }
		}
		  
		[XmlAttribute("LogLevel")]
		[Bindable(true)]
		public int LogLevel 
		{
			get { return GetColumnValue<int>(Columns.LogLevel); }
			set { SetColumnValue(Columns.LogLevel, value); }
		}
		  
		[XmlAttribute("Ip")]
		[Bindable(true)]
		public string Ip 
		{
			get { return GetColumnValue<string>(Columns.Ip); }
			set { SetColumnValue(Columns.Ip, value); }
		}
		  
		[XmlAttribute("UId")]
		[Bindable(true)]
		public int UId 
		{
			get { return GetColumnValue<int>(Columns.UId); }
			set { SetColumnValue(Columns.UId, value); }
		}
		  
		[XmlAttribute("UserFullName")]
		[Bindable(true)]
		public string UserFullName 
		{
			get { return GetColumnValue<string>(Columns.UserFullName); }
			set { SetColumnValue(Columns.UserFullName, value); }
		}
		  
		[XmlAttribute("Action")]
		[Bindable(true)]
		public string Action 
		{
			get { return GetColumnValue<string>(Columns.Action); }
			set { SetColumnValue(Columns.Action, value); }
		}
		  
		[XmlAttribute("Detail")]
		[Bindable(true)]
		public string Detail 
		{
			get { return GetColumnValue<string>(Columns.Detail); }
			set { SetColumnValue(Columns.Detail, value); }
		}
		  
		[XmlAttribute("CreatedAt")]
		[Bindable(true)]
		public DateTime CreatedAt 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedAt); }
			set { SetColumnValue(Columns.CreatedAt, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public int CreatedBy 
		{
			get { return GetColumnValue<int>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("LastModifiedAt")]
		[Bindable(true)]
		public DateTime LastModifiedAt 
		{
			get { return GetColumnValue<DateTime>(Columns.LastModifiedAt); }
			set { SetColumnValue(Columns.LastModifiedAt, value); }
		}
		  
		[XmlAttribute("LastModifiedBy")]
		[Bindable(true)]
		public int LastModifiedBy 
		{
			get { return GetColumnValue<int>(Columns.LastModifiedBy); }
			set { SetColumnValue(Columns.LastModifiedBy, value); }
		}
		  
		[XmlAttribute("Flag")]
		[Bindable(true)]
		public string Flag 
		{
			get { return GetColumnValue<string>(Columns.Flag); }
			set { SetColumnValue(Columns.Flag, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varLogTime,int varLogLevel,string varIp,int varUId,string varUserFullName,string varAction,string varDetail,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Logging item = new Logging();
			
			item.LogTime = varLogTime;
			
			item.LogLevel = varLogLevel;
			
			item.Ip = varIp;
			
			item.UId = varUId;
			
			item.UserFullName = varUserFullName;
			
			item.Action = varAction;
			
			item.Detail = varDetail;
			
			item.CreatedAt = varCreatedAt;
			
			item.CreatedBy = varCreatedBy;
			
			item.LastModifiedAt = varLastModifiedAt;
			
			item.LastModifiedBy = varLastModifiedBy;
			
			item.Flag = varFlag;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,DateTime varLogTime,int varLogLevel,string varIp,int varUId,string varUserFullName,string varAction,string varDetail,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Logging item = new Logging();
			
				item.Id = varId;
			
				item.LogTime = varLogTime;
			
				item.LogLevel = varLogLevel;
			
				item.Ip = varIp;
			
				item.UId = varUId;
			
				item.UserFullName = varUserFullName;
			
				item.Action = varAction;
			
				item.Detail = varDetail;
			
				item.CreatedAt = varCreatedAt;
			
				item.CreatedBy = varCreatedBy;
			
				item.LastModifiedAt = varLastModifiedAt;
			
				item.LastModifiedBy = varLastModifiedBy;
			
				item.Flag = varFlag;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn LogTimeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn LogLevelColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IpColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn UIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn UserFullNameColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ActionColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string LogTime = @"LogTime";
			 public static string LogLevel = @"LogLevel";
			 public static string Ip = @"IP";
			 public static string UId = @"UId";
			 public static string UserFullName = @"UserFullName";
			 public static string Action = @"Action";
			 public static string Detail = @"Detail";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
