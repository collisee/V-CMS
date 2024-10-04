using System;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using SubSonic;

namespace VideoDAL.Objects
{
	/// <summary>
	/// Strongly-typed collection for the AdvertisementItem class.
	/// </summary>
    [Serializable]
	public partial class AdvertisementItemCollection : ActiveList<AdvertisementItem, AdvertisementItemCollection>
	{	   
		public AdvertisementItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AdvertisementItemCollection</returns>
		public AdvertisementItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                AdvertisementItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the AdvertisementItem table.
	/// </summary>
	[Serializable]
	public partial class AdvertisementItem : ActiveRecord<AdvertisementItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public AdvertisementItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public AdvertisementItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public AdvertisementItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public AdvertisementItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("AdvertisementItem", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarTypeId = new TableSchema.TableColumn(schema);
				colvarTypeId.ColumnName = "TypeId";
				colvarTypeId.DataType = DbType.Int32;
				colvarTypeId.MaxLength = 0;
				colvarTypeId.AutoIncrement = false;
				colvarTypeId.IsNullable = false;
				colvarTypeId.IsPrimaryKey = false;
				colvarTypeId.IsForeignKey = true;
				colvarTypeId.IsReadOnly = false;
				colvarTypeId.DefaultSetting = @"";
				
					colvarTypeId.ForeignKeyTableName = "AdvertisementType";
				schema.Columns.Add(colvarTypeId);
				
				TableSchema.TableColumn colvarLink = new TableSchema.TableColumn(schema);
				colvarLink.ColumnName = "Link";
				colvarLink.DataType = DbType.String;
				colvarLink.MaxLength = 255;
				colvarLink.AutoIncrement = false;
				colvarLink.IsNullable = false;
				colvarLink.IsPrimaryKey = false;
				colvarLink.IsForeignKey = false;
				colvarLink.IsReadOnly = false;
				colvarLink.DefaultSetting = @"";
				colvarLink.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLink);
				
				TableSchema.TableColumn colvarFileLink1 = new TableSchema.TableColumn(schema);
				colvarFileLink1.ColumnName = "FileLink1";
				colvarFileLink1.DataType = DbType.String;
				colvarFileLink1.MaxLength = 255;
				colvarFileLink1.AutoIncrement = false;
				colvarFileLink1.IsNullable = false;
				colvarFileLink1.IsPrimaryKey = false;
				colvarFileLink1.IsForeignKey = false;
				colvarFileLink1.IsReadOnly = false;
				colvarFileLink1.DefaultSetting = @"";
				colvarFileLink1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFileLink1);
				
				TableSchema.TableColumn colvarFileLink2 = new TableSchema.TableColumn(schema);
				colvarFileLink2.ColumnName = "FileLink2";
				colvarFileLink2.DataType = DbType.String;
				colvarFileLink2.MaxLength = 255;
				colvarFileLink2.AutoIncrement = false;
				colvarFileLink2.IsNullable = true;
				colvarFileLink2.IsPrimaryKey = false;
				colvarFileLink2.IsForeignKey = false;
				colvarFileLink2.IsReadOnly = false;
				colvarFileLink2.DefaultSetting = @"";
				colvarFileLink2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFileLink2);
				
				TableSchema.TableColumn colvarFileJS = new TableSchema.TableColumn(schema);
				colvarFileJS.ColumnName = "FileJS";
				colvarFileJS.DataType = DbType.String;
				colvarFileJS.MaxLength = 4000;
				colvarFileJS.AutoIncrement = false;
				colvarFileJS.IsNullable = true;
				colvarFileJS.IsPrimaryKey = false;
				colvarFileJS.IsForeignKey = false;
				colvarFileJS.IsReadOnly = false;
				colvarFileJS.DefaultSetting = @"";
				colvarFileJS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFileJS);
				
				TableSchema.TableColumn colvarCodeJS = new TableSchema.TableColumn(schema);
				colvarCodeJS.ColumnName = "CodeJS";
				colvarCodeJS.DataType = DbType.String;
				colvarCodeJS.MaxLength = 4000;
				colvarCodeJS.AutoIncrement = false;
				colvarCodeJS.IsNullable = true;
				colvarCodeJS.IsPrimaryKey = false;
				colvarCodeJS.IsForeignKey = false;
				colvarCodeJS.IsReadOnly = false;
				colvarCodeJS.DefaultSetting = @"";
				colvarCodeJS.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCodeJS);
				
				TableSchema.TableColumn colvarStartTime = new TableSchema.TableColumn(schema);
				colvarStartTime.ColumnName = "StartTime";
				colvarStartTime.DataType = DbType.DateTime;
				colvarStartTime.MaxLength = 0;
				colvarStartTime.AutoIncrement = false;
				colvarStartTime.IsNullable = false;
				colvarStartTime.IsPrimaryKey = false;
				colvarStartTime.IsForeignKey = false;
				colvarStartTime.IsReadOnly = false;
				
						colvarStartTime.DefaultSetting = @"(getdate())";
				colvarStartTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartTime);
				
				TableSchema.TableColumn colvarEndTime = new TableSchema.TableColumn(schema);
				colvarEndTime.ColumnName = "EndTime";
				colvarEndTime.DataType = DbType.DateTime;
				colvarEndTime.MaxLength = 0;
				colvarEndTime.AutoIncrement = false;
				colvarEndTime.IsNullable = false;
				colvarEndTime.IsPrimaryKey = false;
				colvarEndTime.IsForeignKey = false;
				colvarEndTime.IsReadOnly = false;
				
						colvarEndTime.DefaultSetting = @"(getdate())";
				colvarEndTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndTime);
				
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
				
				TableSchema.TableColumn colvarExWidth = new TableSchema.TableColumn(schema);
				colvarExWidth.ColumnName = "ExWidth";
				colvarExWidth.DataType = DbType.Int32;
				colvarExWidth.MaxLength = 0;
				colvarExWidth.AutoIncrement = false;
				colvarExWidth.IsNullable = true;
				colvarExWidth.IsPrimaryKey = false;
				colvarExWidth.IsForeignKey = false;
				colvarExWidth.IsReadOnly = false;
				
						colvarExWidth.DefaultSetting = @"((0))";
				colvarExWidth.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExWidth);
				
				TableSchema.TableColumn colvarExHeight = new TableSchema.TableColumn(schema);
				colvarExHeight.ColumnName = "ExHeight";
				colvarExHeight.DataType = DbType.Int32;
				colvarExHeight.MaxLength = 0;
				colvarExHeight.AutoIncrement = false;
				colvarExHeight.IsNullable = true;
				colvarExHeight.IsPrimaryKey = false;
				colvarExHeight.IsForeignKey = false;
				colvarExHeight.IsReadOnly = false;
				
						colvarExHeight.DefaultSetting = @"((0))";
				colvarExHeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExHeight);
				
				TableSchema.TableColumn colvarExMode = new TableSchema.TableColumn(schema);
				colvarExMode.ColumnName = "ExMode";
				colvarExMode.DataType = DbType.Int32;
				colvarExMode.MaxLength = 0;
				colvarExMode.AutoIncrement = false;
				colvarExMode.IsNullable = true;
				colvarExMode.IsPrimaryKey = false;
				colvarExMode.IsForeignKey = false;
				colvarExMode.IsReadOnly = false;
				
						colvarExMode.DefaultSetting = @"((0))";
				colvarExMode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExMode);
				
				TableSchema.TableColumn colvarHistory = new TableSchema.TableColumn(schema);
				colvarHistory.ColumnName = "History";
				colvarHistory.DataType = DbType.String;
				colvarHistory.MaxLength = 1073741823;
				colvarHistory.AutoIncrement = false;
				colvarHistory.IsNullable = true;
				colvarHistory.IsPrimaryKey = false;
				colvarHistory.IsForeignKey = false;
				colvarHistory.IsReadOnly = false;
				colvarHistory.DefaultSetting = @"";
				colvarHistory.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHistory);
				
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
				DataService.Providers["VCMS"].AddSchema("AdvertisementItem",schema);
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
		  
		[XmlAttribute("TypeId")]
		[Bindable(true)]
		public int TypeId 
		{
			get { return GetColumnValue<int>(Columns.TypeId); }
			set { SetColumnValue(Columns.TypeId, value); }
		}
		  
		[XmlAttribute("Link")]
		[Bindable(true)]
		public string Link 
		{
			get { return GetColumnValue<string>(Columns.Link); }
			set { SetColumnValue(Columns.Link, value); }
		}
		  
		[XmlAttribute("FileLink1")]
		[Bindable(true)]
		public string FileLink1 
		{
			get { return GetColumnValue<string>(Columns.FileLink1); }
			set { SetColumnValue(Columns.FileLink1, value); }
		}
		  
		[XmlAttribute("FileLink2")]
		[Bindable(true)]
		public string FileLink2 
		{
			get { return GetColumnValue<string>(Columns.FileLink2); }
			set { SetColumnValue(Columns.FileLink2, value); }
		}
		  
		[XmlAttribute("FileJS")]
		[Bindable(true)]
		public string FileJS 
		{
			get { return GetColumnValue<string>(Columns.FileJS); }
			set { SetColumnValue(Columns.FileJS, value); }
		}
		  
		[XmlAttribute("CodeJS")]
		[Bindable(true)]
		public string CodeJS 
		{
			get { return GetColumnValue<string>(Columns.CodeJS); }
			set { SetColumnValue(Columns.CodeJS, value); }
		}
		  
		[XmlAttribute("StartTime")]
		[Bindable(true)]
		public DateTime StartTime 
		{
			get { return GetColumnValue<DateTime>(Columns.StartTime); }
			set { SetColumnValue(Columns.StartTime, value); }
		}
		  
		[XmlAttribute("EndTime")]
		[Bindable(true)]
		public DateTime EndTime 
		{
			get { return GetColumnValue<DateTime>(Columns.EndTime); }
			set { SetColumnValue(Columns.EndTime, value); }
		}
		  
		[XmlAttribute("Detail")]
		[Bindable(true)]
		public string Detail 
		{
			get { return GetColumnValue<string>(Columns.Detail); }
			set { SetColumnValue(Columns.Detail, value); }
		}
		  
		[XmlAttribute("ExWidth")]
		[Bindable(true)]
		public int? ExWidth 
		{
			get { return GetColumnValue<int?>(Columns.ExWidth); }
			set { SetColumnValue(Columns.ExWidth, value); }
		}
		  
		[XmlAttribute("ExHeight")]
		[Bindable(true)]
		public int? ExHeight 
		{
			get { return GetColumnValue<int?>(Columns.ExHeight); }
			set { SetColumnValue(Columns.ExHeight, value); }
		}
		  
		[XmlAttribute("ExMode")]
		[Bindable(true)]
		public int? ExMode 
		{
			get { return GetColumnValue<int?>(Columns.ExMode); }
			set { SetColumnValue(Columns.ExMode, value); }
		}
		  
		[XmlAttribute("History")]
		[Bindable(true)]
		public string History 
		{
			get { return GetColumnValue<string>(Columns.History); }
			set { SetColumnValue(Columns.History, value); }
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
			return new VideoDAL.AdvertisementBlockItemCollection().Where(AdvertisementBlockItem.Columns.ItemId, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AdvertisementType ActiveRecord object related to this AdvertisementItem
		/// 
		/// </summary>
		public VideoDAL.AdvertisementType AdvertisementType
		{
			get { return VideoDAL.AdvertisementType.FetchByID(this.TypeId); }
			set { SetColumnValue("TypeId", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,int varTypeId,string varLink,string varFileLink1,string varFileLink2,string varFileJS,string varCodeJS,DateTime varStartTime,DateTime varEndTime,string varDetail,int? varExWidth,int? varExHeight,int? varExMode,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			AdvertisementItem item = new AdvertisementItem();
			
			item.Name = varName;
			
			item.TypeId = varTypeId;
			
			item.Link = varLink;
			
			item.FileLink1 = varFileLink1;
			
			item.FileLink2 = varFileLink2;
			
			item.FileJS = varFileJS;
			
			item.CodeJS = varCodeJS;
			
			item.StartTime = varStartTime;
			
			item.EndTime = varEndTime;
			
			item.Detail = varDetail;
			
			item.ExWidth = varExWidth;
			
			item.ExHeight = varExHeight;
			
			item.ExMode = varExMode;
			
			item.History = varHistory;
			
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
		public static void Update(int varId,string varName,int varTypeId,string varLink,string varFileLink1,string varFileLink2,string varFileJS,string varCodeJS,DateTime varStartTime,DateTime varEndTime,string varDetail,int? varExWidth,int? varExHeight,int? varExMode,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			AdvertisementItem item = new AdvertisementItem();
			
				item.Id = varId;
			
				item.Name = varName;
			
				item.TypeId = varTypeId;
			
				item.Link = varLink;
			
				item.FileLink1 = varFileLink1;
			
				item.FileLink2 = varFileLink2;
			
				item.FileJS = varFileJS;
			
				item.CodeJS = varCodeJS;
			
				item.StartTime = varStartTime;
			
				item.EndTime = varEndTime;
			
				item.Detail = varDetail;
			
				item.ExWidth = varExWidth;
			
				item.ExHeight = varExHeight;
			
				item.ExMode = varExMode;
			
				item.History = varHistory;
			
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
        
        
        
        public static TableSchema.TableColumn TypeIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LinkColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FileLink1Column
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn FileLink2Column
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn FileJSColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CodeJSColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn StartTimeColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn EndTimeColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ExWidthColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ExHeightColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn ExModeColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn HistoryColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Name = @"Name";
			 public static string TypeId = @"TypeId";
			 public static string Link = @"Link";
			 public static string FileLink1 = @"FileLink1";
			 public static string FileLink2 = @"FileLink2";
			 public static string FileJS = @"FileJS";
			 public static string CodeJS = @"CodeJS";
			 public static string StartTime = @"StartTime";
			 public static string EndTime = @"EndTime";
			 public static string Detail = @"Detail";
			 public static string ExWidth = @"ExWidth";
			 public static string ExHeight = @"ExHeight";
			 public static string ExMode = @"ExMode";
			 public static string History = @"History";
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
