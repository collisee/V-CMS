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
	/// Strongly-typed collection for the Policy class.
	/// </summary>
    [Serializable]
	public partial class PolicyCollection : ActiveList<Policy, PolicyCollection>
	{	   
		public PolicyCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PolicyCollection</returns>
		public PolicyCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Policy o = this[i];
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
	/// This is an ActiveRecord class which wraps the Policy table.
	/// </summary>
	[Serializable]
	public partial class Policy : ActiveRecord<Policy>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Policy()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Policy(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Policy(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Policy(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Policy", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarGroupId = new TableSchema.TableColumn(schema);
				colvarGroupId.ColumnName = "GroupId";
				colvarGroupId.DataType = DbType.Int32;
				colvarGroupId.MaxLength = 0;
				colvarGroupId.AutoIncrement = false;
				colvarGroupId.IsNullable = false;
				colvarGroupId.IsPrimaryKey = false;
				colvarGroupId.IsForeignKey = true;
				colvarGroupId.IsReadOnly = false;
				
						colvarGroupId.DefaultSetting = @"((0))";
				
					colvarGroupId.ForeignKeyTableName = "Group";
				schema.Columns.Add(colvarGroupId);
				
				TableSchema.TableColumn colvarModuleId = new TableSchema.TableColumn(schema);
				colvarModuleId.ColumnName = "ModuleId";
				colvarModuleId.DataType = DbType.Int32;
				colvarModuleId.MaxLength = 0;
				colvarModuleId.AutoIncrement = false;
				colvarModuleId.IsNullable = false;
				colvarModuleId.IsPrimaryKey = false;
				colvarModuleId.IsForeignKey = true;
				colvarModuleId.IsReadOnly = false;
				
						colvarModuleId.DefaultSetting = @"((0))";
				
					colvarModuleId.ForeignKeyTableName = "Module";
				schema.Columns.Add(colvarModuleId);
				
				TableSchema.TableColumn colvarVal = new TableSchema.TableColumn(schema);
				colvarVal.ColumnName = "Val";
				colvarVal.DataType = DbType.Int32;
				colvarVal.MaxLength = 0;
				colvarVal.AutoIncrement = false;
				colvarVal.IsNullable = false;
				colvarVal.IsPrimaryKey = false;
				colvarVal.IsForeignKey = false;
				colvarVal.IsReadOnly = false;
				
						colvarVal.DefaultSetting = @"((0))";
				colvarVal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVal);
				
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
				DataService.Providers["VCMS"].AddSchema("Policy",schema);
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
		  
		[XmlAttribute("GroupId")]
		[Bindable(true)]
		public int GroupId 
		{
			get { return GetColumnValue<int>(Columns.GroupId); }
			set { SetColumnValue(Columns.GroupId, value); }
		}
		  
		[XmlAttribute("ModuleId")]
		[Bindable(true)]
		public int ModuleId 
		{
			get { return GetColumnValue<int>(Columns.ModuleId); }
			set { SetColumnValue(Columns.ModuleId, value); }
		}
		  
		[XmlAttribute("Val")]
		[Bindable(true)]
		public int Val 
		{
			get { return GetColumnValue<int>(Columns.Val); }
			set { SetColumnValue(Columns.Val, value); }
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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Group ActiveRecord object related to this Policy
		/// 
		/// </summary>
		public DAL.Group Group
		{
			get { return DAL.Group.FetchByID(this.GroupId); }
			set { SetColumnValue("GroupId", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a ModuleX ActiveRecord object related to this Policy
		/// 
		/// </summary>
		public DAL.ModuleX ModuleX
		{
			get { return DAL.ModuleX.FetchByID(this.ModuleId); }
			set { SetColumnValue("ModuleId", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varGroupId,int varModuleId,int varVal,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Policy item = new Policy();
			
			item.GroupId = varGroupId;
			
			item.ModuleId = varModuleId;
			
			item.Val = varVal;
			
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
		public static void Update(int varId,int varGroupId,int varModuleId,int varVal,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Policy item = new Policy();
			
				item.Id = varId;
			
				item.GroupId = varGroupId;
			
				item.ModuleId = varModuleId;
			
				item.Val = varVal;
			
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
        
        
        
        public static TableSchema.TableColumn GroupIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ModuleIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ValColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string GroupId = @"GroupId";
			 public static string ModuleId = @"ModuleId";
			 public static string Val = @"Val";
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
