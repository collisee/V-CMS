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
	/// Strongly-typed collection for the ArticleEvent class.
	/// </summary>
    [Serializable]
	public partial class ArticleEventCollection : ActiveList<ArticleEvent, ArticleEventCollection>
	{	   
		public ArticleEventCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ArticleEventCollection</returns>
		public ArticleEventCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ArticleEvent o = this[i];
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
	/// This is an ActiveRecord class which wraps the ArticleEvent table.
	/// </summary>
	[Serializable]
	public partial class ArticleEvent : ActiveRecord<ArticleEvent>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ArticleEvent()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ArticleEvent(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ArticleEvent(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ArticleEvent(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ArticleEvent", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.String;
				colvarStatus.MaxLength = 255;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"(N'Chưa xử lý')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
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
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 255;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = true;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarImageLink = new TableSchema.TableColumn(schema);
				colvarImageLink.ColumnName = "ImageLink";
				colvarImageLink.DataType = DbType.String;
				colvarImageLink.MaxLength = 255;
				colvarImageLink.AutoIncrement = false;
				colvarImageLink.IsNullable = false;
				colvarImageLink.IsPrimaryKey = false;
				colvarImageLink.IsForeignKey = false;
				colvarImageLink.IsReadOnly = false;
				
						colvarImageLink.DefaultSetting = @"('')";
				colvarImageLink.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink);
				
				TableSchema.TableColumn colvarLead = new TableSchema.TableColumn(schema);
				colvarLead.ColumnName = "Lead";
				colvarLead.DataType = DbType.String;
				colvarLead.MaxLength = 4000;
				colvarLead.AutoIncrement = false;
				colvarLead.IsNullable = false;
				colvarLead.IsPrimaryKey = false;
				colvarLead.IsForeignKey = false;
				colvarLead.IsReadOnly = false;
				colvarLead.DefaultSetting = @"";
				colvarLead.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLead);
				
				TableSchema.TableColumn colvarDetail = new TableSchema.TableColumn(schema);
				colvarDetail.ColumnName = "Detail";
				colvarDetail.DataType = DbType.String;
				colvarDetail.MaxLength = 1073741823;
				colvarDetail.AutoIncrement = false;
				colvarDetail.IsNullable = false;
				colvarDetail.IsPrimaryKey = false;
				colvarDetail.IsForeignKey = false;
				colvarDetail.IsReadOnly = false;
				colvarDetail.DefaultSetting = @"";
				colvarDetail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetail);
				
				TableSchema.TableColumn colvarPublishDate = new TableSchema.TableColumn(schema);
				colvarPublishDate.ColumnName = "PublishDate";
				colvarPublishDate.DataType = DbType.DateTime;
				colvarPublishDate.MaxLength = 0;
				colvarPublishDate.AutoIncrement = false;
				colvarPublishDate.IsNullable = false;
				colvarPublishDate.IsPrimaryKey = false;
				colvarPublishDate.IsForeignKey = false;
				colvarPublishDate.IsReadOnly = false;
				
						colvarPublishDate.DefaultSetting = @"(getdate())";
				colvarPublishDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPublishDate);
				
				TableSchema.TableColumn colvarTotalView = new TableSchema.TableColumn(schema);
				colvarTotalView.ColumnName = "TotalView";
				colvarTotalView.DataType = DbType.Int32;
				colvarTotalView.MaxLength = 0;
				colvarTotalView.AutoIncrement = false;
				colvarTotalView.IsNullable = false;
				colvarTotalView.IsPrimaryKey = false;
				colvarTotalView.IsForeignKey = false;
				colvarTotalView.IsReadOnly = false;
				
						colvarTotalView.DefaultSetting = @"((0))";
				colvarTotalView.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalView);
				
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
				DataService.Providers["VCMS"].AddSchema("ArticleEvent",schema);
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
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Title")]
		[Bindable(true)]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }
			set { SetColumnValue(Columns.Title, value); }
		}
		  
		[XmlAttribute("ImageLink")]
		[Bindable(true)]
		public string ImageLink 
		{
			get { return GetColumnValue<string>(Columns.ImageLink); }
			set { SetColumnValue(Columns.ImageLink, value); }
		}
		  
		[XmlAttribute("Lead")]
		[Bindable(true)]
		public string Lead 
		{
			get { return GetColumnValue<string>(Columns.Lead); }
			set { SetColumnValue(Columns.Lead, value); }
		}
		  
		[XmlAttribute("Detail")]
		[Bindable(true)]
		public string Detail 
		{
			get { return GetColumnValue<string>(Columns.Detail); }
			set { SetColumnValue(Columns.Detail, value); }
		}
		  
		[XmlAttribute("PublishDate")]
		[Bindable(true)]
		public DateTime PublishDate 
		{
			get { return GetColumnValue<DateTime>(Columns.PublishDate); }
			set { SetColumnValue(Columns.PublishDate, value); }
		}
		  
		[XmlAttribute("TotalView")]
		[Bindable(true)]
		public int TotalView 
		{
			get { return GetColumnValue<int>(Columns.TotalView); }
			set { SetColumnValue(Columns.TotalView, value); }
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
        
		
		public DAL.ArticleEventCategoryCollection ArticleEventCategoryRecords()
		{
			return new DAL.ArticleEventCategoryCollection().Where(ArticleEventCategory.Columns.ArticleEventId, Id).Load();
		}
		public DAL.ArticleEventItemCollection ArticleEventItemRecords()
		{
			return new DAL.ArticleEventItemCollection().Where(ArticleEventItem.Columns.ArticleEventId, Id).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varStatus,string varName,string varTitle,string varImageLink,string varLead,string varDetail,DateTime varPublishDate,int varTotalView,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleEvent item = new ArticleEvent();
			
			item.Status = varStatus;
			
			item.Name = varName;
			
			item.Title = varTitle;
			
			item.ImageLink = varImageLink;
			
			item.Lead = varLead;
			
			item.Detail = varDetail;
			
			item.PublishDate = varPublishDate;
			
			item.TotalView = varTotalView;
			
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
		public static void Update(int varId,string varStatus,string varName,string varTitle,string varImageLink,string varLead,string varDetail,DateTime varPublishDate,int varTotalView,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleEvent item = new ArticleEvent();
			
				item.Id = varId;
			
				item.Status = varStatus;
			
				item.Name = varName;
			
				item.Title = varTitle;
			
				item.ImageLink = varImageLink;
			
				item.Lead = varLead;
			
				item.Detail = varDetail;
			
				item.PublishDate = varPublishDate;
			
				item.TotalView = varTotalView;
			
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
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLinkColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn LeadColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PublishDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalViewColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn HistoryColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Status = @"Status";
			 public static string Name = @"Name";
			 public static string Title = @"Title";
			 public static string ImageLink = @"ImageLink";
			 public static string Lead = @"Lead";
			 public static string Detail = @"Detail";
			 public static string PublishDate = @"PublishDate";
			 public static string TotalView = @"TotalView";
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
