using System;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using SubSonic;

namespace VideoDAL.Objects
{
	/// <summary>
	/// Strongly-typed collection for the AdvertisementBlock class.
	/// </summary>
    [Serializable]
	public partial class AdvertisementBlockCollection : ActiveList<AdvertisementBlock, AdvertisementBlockCollection>
	{	   
		public AdvertisementBlockCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AdvertisementBlockCollection</returns>
		public AdvertisementBlockCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AdvertisementBlock o = this[i];
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
	/// This is an ActiveRecord class which wraps the AdvertisementBlock table.
	/// </summary>
	[Serializable]
	public partial class AdvertisementBlock : ActiveRecord<AdvertisementBlock>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AdvertisementBlock()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AdvertisementBlock(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AdvertisementBlock(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AdvertisementBlock(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("AdvertisementBlock", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 255;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
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
				
				TableSchema.TableColumn colvarMode = new TableSchema.TableColumn(schema);
				colvarMode.ColumnName = "Mode";
				colvarMode.DataType = DbType.Int32;
				colvarMode.MaxLength = 0;
				colvarMode.AutoIncrement = false;
				colvarMode.IsNullable = false;
				colvarMode.IsPrimaryKey = false;
				colvarMode.IsForeignKey = false;
				colvarMode.IsReadOnly = false;
				
						colvarMode.DefaultSetting = @"((0))";
				colvarMode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMode);
				
				TableSchema.TableColumn colvarTimeDelay = new TableSchema.TableColumn(schema);
				colvarTimeDelay.ColumnName = "TimeDelay";
				colvarTimeDelay.DataType = DbType.Int32;
				colvarTimeDelay.MaxLength = 0;
				colvarTimeDelay.AutoIncrement = false;
				colvarTimeDelay.IsNullable = false;
				colvarTimeDelay.IsPrimaryKey = false;
				colvarTimeDelay.IsForeignKey = false;
				colvarTimeDelay.IsReadOnly = false;
				
						colvarTimeDelay.DefaultSetting = @"((5000))";
				colvarTimeDelay.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTimeDelay);
				
				TableSchema.TableColumn colvarWidth = new TableSchema.TableColumn(schema);
				colvarWidth.ColumnName = "Width";
				colvarWidth.DataType = DbType.Int32;
				colvarWidth.MaxLength = 0;
				colvarWidth.AutoIncrement = false;
				colvarWidth.IsNullable = false;
				colvarWidth.IsPrimaryKey = false;
				colvarWidth.IsForeignKey = false;
				colvarWidth.IsReadOnly = false;
				
						colvarWidth.DefaultSetting = @"((0))";
				colvarWidth.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWidth);
				
				TableSchema.TableColumn colvarHeight = new TableSchema.TableColumn(schema);
				colvarHeight.ColumnName = "Height";
				colvarHeight.DataType = DbType.Int32;
				colvarHeight.MaxLength = 0;
				colvarHeight.AutoIncrement = false;
				colvarHeight.IsNullable = false;
				colvarHeight.IsPrimaryKey = false;
				colvarHeight.IsForeignKey = false;
				colvarHeight.IsReadOnly = false;
				
						colvarHeight.DefaultSetting = @"((0))";
				colvarHeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHeight);
				
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
				DataService.Providers["VCMS"].AddSchema("AdvertisementBlock",schema);
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
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Detail")]
		[Bindable(true)]
		public string Detail 
		{
			get { return GetColumnValue<string>(Columns.Detail); }
			set { SetColumnValue(Columns.Detail, value); }
		}
		  
		[XmlAttribute("Mode")]
		[Bindable(true)]
		public int Mode 
		{
			get { return GetColumnValue<int>(Columns.Mode); }
			set { SetColumnValue(Columns.Mode, value); }
		}
		  
		[XmlAttribute("TimeDelay")]
		[Bindable(true)]
		public int TimeDelay 
		{
			get { return GetColumnValue<int>(Columns.TimeDelay); }
			set { SetColumnValue(Columns.TimeDelay, value); }
		}
		  
		[XmlAttribute("Width")]
		[Bindable(true)]
		public int Width 
		{
			get { return GetColumnValue<int>(Columns.Width); }
			set { SetColumnValue(Columns.Width, value); }
		}
		  
		[XmlAttribute("Height")]
		[Bindable(true)]
		public int Height 
		{
			get { return GetColumnValue<int>(Columns.Height); }
			set { SetColumnValue(Columns.Height, value); }
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
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public VideoDAL.AdvertisementBlockItemCollection AdvertisementBlockItemRecords()
		{
			return new VideoDAL.AdvertisementBlockItemCollection().Where(AdvertisementBlockItem.Columns.BlockId, Id).Load();
		}
		public VideoDAL.AdvertisementZoneBlockCollection AdvertisementZoneBlockRecords()
		{
			return new VideoDAL.AdvertisementZoneBlockCollection().Where(AdvertisementZoneBlock.Columns.BlockId, Id).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varDetail,int varMode,int varTimeDelay,int varWidth,int varHeight,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			AdvertisementBlock item = new AdvertisementBlock();
			
			item.Name = varName;
			
			item.Detail = varDetail;
			
			item.Mode = varMode;
			
			item.TimeDelay = varTimeDelay;
			
			item.Width = varWidth;
			
			item.Height = varHeight;
			
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
		public static void Update(int varId,string varName,string varDetail,int varMode,int varTimeDelay,int varWidth,int varHeight,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			AdvertisementBlock item = new AdvertisementBlock();
			
				item.Id = varId;
			
				item.Name = varName;
			
				item.Detail = varDetail;
			
				item.Mode = varMode;
			
				item.TimeDelay = varTimeDelay;
			
				item.Width = varWidth;
			
				item.Height = varHeight;
			
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
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ModeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TimeDelayColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn WidthColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn HeightColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Name = @"Name";
			 public static string Detail = @"Detail";
			 public static string Mode = @"Mode";
			 public static string TimeDelay = @"TimeDelay";
			 public static string Width = @"Width";
			 public static string Height = @"Height";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
