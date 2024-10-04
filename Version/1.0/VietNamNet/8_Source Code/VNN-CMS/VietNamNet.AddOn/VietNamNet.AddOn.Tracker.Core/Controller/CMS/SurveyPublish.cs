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
	/// Strongly-typed collection for the SurveyPublish class.
	/// </summary>
    [Serializable]
	public partial class SurveyPublishCollection : ActiveList<SurveyPublish, SurveyPublishCollection>
	{	   
		public SurveyPublishCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SurveyPublishCollection</returns>
		public SurveyPublishCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SurveyPublish o = this[i];
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
	/// This is an ActiveRecord class which wraps the SurveyPublishs table.
	/// </summary>
	[Serializable]
	public partial class SurveyPublish : ActiveRecord<SurveyPublish>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SurveyPublish()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SurveyPublish(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SurveyPublish(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SurveyPublish(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SurveyPublishs", TableType.Table, DataService.GetInstance("VNN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSurveyPublishId = new TableSchema.TableColumn(schema);
				colvarSurveyPublishId.ColumnName = "SurveyPublishId";
				colvarSurveyPublishId.DataType = DbType.Int32;
				colvarSurveyPublishId.MaxLength = 0;
				colvarSurveyPublishId.AutoIncrement = true;
				colvarSurveyPublishId.IsNullable = false;
				colvarSurveyPublishId.IsPrimaryKey = true;
				colvarSurveyPublishId.IsForeignKey = false;
				colvarSurveyPublishId.IsReadOnly = false;
				colvarSurveyPublishId.DefaultSetting = @"";
				colvarSurveyPublishId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSurveyPublishId);
				
				TableSchema.TableColumn colvarSurveyId = new TableSchema.TableColumn(schema);
				colvarSurveyId.ColumnName = "SurveyId";
				colvarSurveyId.DataType = DbType.Int32;
				colvarSurveyId.MaxLength = 0;
				colvarSurveyId.AutoIncrement = false;
				colvarSurveyId.IsNullable = false;
				colvarSurveyId.IsPrimaryKey = false;
				colvarSurveyId.IsForeignKey = false;
				colvarSurveyId.IsReadOnly = false;
				colvarSurveyId.DefaultSetting = @"";
				colvarSurveyId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSurveyId);
				
				TableSchema.TableColumn colvarArticleId = new TableSchema.TableColumn(schema);
				colvarArticleId.ColumnName = "ArticleId";
				colvarArticleId.DataType = DbType.Int32;
				colvarArticleId.MaxLength = 0;
				colvarArticleId.AutoIncrement = false;
				colvarArticleId.IsNullable = true;
				colvarArticleId.IsPrimaryKey = false;
				colvarArticleId.IsForeignKey = false;
				colvarArticleId.IsReadOnly = false;
				colvarArticleId.DefaultSetting = @"";
				colvarArticleId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArticleId);
				
				TableSchema.TableColumn colvarCategoryId = new TableSchema.TableColumn(schema);
				colvarCategoryId.ColumnName = "CategoryId";
				colvarCategoryId.DataType = DbType.Int32;
				colvarCategoryId.MaxLength = 0;
				colvarCategoryId.AutoIncrement = false;
				colvarCategoryId.IsNullable = true;
				colvarCategoryId.IsPrimaryKey = false;
				colvarCategoryId.IsForeignKey = false;
				colvarCategoryId.IsReadOnly = false;
				colvarCategoryId.DefaultSetting = @"";
				colvarCategoryId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryId);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = false;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				
						colvarStartDate.DefaultSetting = @"(getdate())";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarExpireDate = new TableSchema.TableColumn(schema);
				colvarExpireDate.ColumnName = "ExpireDate";
				colvarExpireDate.DataType = DbType.DateTime;
				colvarExpireDate.MaxLength = 0;
				colvarExpireDate.AutoIncrement = false;
				colvarExpireDate.IsNullable = false;
				colvarExpireDate.IsPrimaryKey = false;
				colvarExpireDate.IsForeignKey = false;
				colvarExpireDate.IsReadOnly = false;
				colvarExpireDate.DefaultSetting = @"";
				colvarExpireDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpireDate);
				
				TableSchema.TableColumn colvarSecurity = new TableSchema.TableColumn(schema);
				colvarSecurity.ColumnName = "Security";
				colvarSecurity.DataType = DbType.Byte;
				colvarSecurity.MaxLength = 0;
				colvarSecurity.AutoIncrement = false;
				colvarSecurity.IsNullable = false;
				colvarSecurity.IsPrimaryKey = false;
				colvarSecurity.IsForeignKey = false;
				colvarSecurity.IsReadOnly = false;
				colvarSecurity.DefaultSetting = @"";
				colvarSecurity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSecurity);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = false;
				colvarCreatedBy.IsPrimaryKey = false;
				colvarCreatedBy.IsForeignKey = false;
				colvarCreatedBy.IsReadOnly = false;
				colvarCreatedBy.DefaultSetting = @"";
				colvarCreatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedBy);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(getdate())";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifiedBy = new TableSchema.TableColumn(schema);
				colvarModifiedBy.ColumnName = "ModifiedBy";
				colvarModifiedBy.DataType = DbType.String;
				colvarModifiedBy.MaxLength = 50;
				colvarModifiedBy.AutoIncrement = false;
				colvarModifiedBy.IsNullable = false;
				colvarModifiedBy.IsPrimaryKey = false;
				colvarModifiedBy.IsForeignKey = false;
				colvarModifiedBy.IsReadOnly = false;
				colvarModifiedBy.DefaultSetting = @"";
				colvarModifiedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedBy);
				
				TableSchema.TableColumn colvarModifiOn = new TableSchema.TableColumn(schema);
				colvarModifiOn.ColumnName = "ModifiOn";
				colvarModifiOn.DataType = DbType.DateTime;
				colvarModifiOn.MaxLength = 0;
				colvarModifiOn.AutoIncrement = false;
				colvarModifiOn.IsNullable = false;
				colvarModifiOn.IsPrimaryKey = false;
				colvarModifiOn.IsForeignKey = false;
				colvarModifiOn.IsReadOnly = false;
				
						colvarModifiOn.DefaultSetting = @"(getdate())";
				colvarModifiOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiOn);
				
				TableSchema.TableColumn colvarIsDeleted = new TableSchema.TableColumn(schema);
				colvarIsDeleted.ColumnName = "IsDeleted";
				colvarIsDeleted.DataType = DbType.Boolean;
				colvarIsDeleted.MaxLength = 0;
				colvarIsDeleted.AutoIncrement = false;
				colvarIsDeleted.IsNullable = false;
				colvarIsDeleted.IsPrimaryKey = false;
				colvarIsDeleted.IsForeignKey = false;
				colvarIsDeleted.IsReadOnly = false;
				
						colvarIsDeleted.DefaultSetting = @"((0))";
				colvarIsDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsDeleted);
				
				TableSchema.TableColumn colvarIsActive = new TableSchema.TableColumn(schema);
				colvarIsActive.ColumnName = "IsActive";
				colvarIsActive.DataType = DbType.Boolean;
				colvarIsActive.MaxLength = 0;
				colvarIsActive.AutoIncrement = false;
				colvarIsActive.IsNullable = false;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				
						colvarIsActive.DefaultSetting = @"((1))";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.Byte;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"((0))";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VNN"].AddSchema("SurveyPublishs",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SurveyPublishId")]
		[Bindable(true)]
		public int SurveyPublishId 
		{
			get { return GetColumnValue<int>(Columns.SurveyPublishId); }
			set { SetColumnValue(Columns.SurveyPublishId, value); }
		}
		  
		[XmlAttribute("SurveyId")]
		[Bindable(true)]
		public int SurveyId 
		{
			get { return GetColumnValue<int>(Columns.SurveyId); }
			set { SetColumnValue(Columns.SurveyId, value); }
		}
		  
		[XmlAttribute("ArticleId")]
		[Bindable(true)]
		public int? ArticleId 
		{
			get { return GetColumnValue<int?>(Columns.ArticleId); }
			set { SetColumnValue(Columns.ArticleId, value); }
		}
		  
		[XmlAttribute("CategoryId")]
		[Bindable(true)]
		public int? CategoryId 
		{
			get { return GetColumnValue<int?>(Columns.CategoryId); }
			set { SetColumnValue(Columns.CategoryId, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public DateTime StartDate 
		{
			get { return GetColumnValue<DateTime>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("ExpireDate")]
		[Bindable(true)]
		public DateTime ExpireDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ExpireDate); }
			set { SetColumnValue(Columns.ExpireDate, value); }
		}
		  
		[XmlAttribute("Security")]
		[Bindable(true)]
		public byte Security 
		{
			get { return GetColumnValue<byte>(Columns.Security); }
			set { SetColumnValue(Columns.Security, value); }
		}
		  
		[XmlAttribute("CreatedBy")]
		[Bindable(true)]
		public string CreatedBy 
		{
			get { return GetColumnValue<string>(Columns.CreatedBy); }
			set { SetColumnValue(Columns.CreatedBy, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifiedBy")]
		[Bindable(true)]
		public string ModifiedBy 
		{
			get { return GetColumnValue<string>(Columns.ModifiedBy); }
			set { SetColumnValue(Columns.ModifiedBy, value); }
		}
		  
		[XmlAttribute("ModifiOn")]
		[Bindable(true)]
		public DateTime ModifiOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiOn); }
			set { SetColumnValue(Columns.ModifiOn, value); }
		}
		  
		[XmlAttribute("IsDeleted")]
		[Bindable(true)]
		public bool IsDeleted 
		{
			get { return GetColumnValue<bool>(Columns.IsDeleted); }
			set { SetColumnValue(Columns.IsDeleted, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool IsActive 
		{
			get { return GetColumnValue<bool>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public byte Status 
		{
			get { return GetColumnValue<byte>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSurveyId,int? varArticleId,int? varCategoryId,DateTime varStartDate,DateTime varExpireDate,byte varSecurity,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiOn,bool varIsDeleted,bool varIsActive,byte varStatus)
		{
			SurveyPublish item = new SurveyPublish();
			
			item.SurveyId = varSurveyId;
			
			item.ArticleId = varArticleId;
			
			item.CategoryId = varCategoryId;
			
			item.StartDate = varStartDate;
			
			item.ExpireDate = varExpireDate;
			
			item.Security = varSecurity;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiOn = varModifiOn;
			
			item.IsDeleted = varIsDeleted;
			
			item.IsActive = varIsActive;
			
			item.Status = varStatus;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSurveyPublishId,int varSurveyId,int? varArticleId,int? varCategoryId,DateTime varStartDate,DateTime varExpireDate,byte varSecurity,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiOn,bool varIsDeleted,bool varIsActive,byte varStatus)
		{
			SurveyPublish item = new SurveyPublish();
			
				item.SurveyPublishId = varSurveyPublishId;
			
				item.SurveyId = varSurveyId;
			
				item.ArticleId = varArticleId;
			
				item.CategoryId = varCategoryId;
			
				item.StartDate = varStartDate;
			
				item.ExpireDate = varExpireDate;
			
				item.Security = varSecurity;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiOn = varModifiOn;
			
				item.IsDeleted = varIsDeleted;
			
				item.IsActive = varIsActive;
			
				item.Status = varStatus;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SurveyPublishIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SurveyIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ExpireDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SecurityColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiOnColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDeletedColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SurveyPublishId = @"SurveyPublishId";
			 public static string SurveyId = @"SurveyId";
			 public static string ArticleId = @"ArticleId";
			 public static string CategoryId = @"CategoryId";
			 public static string StartDate = @"StartDate";
			 public static string ExpireDate = @"ExpireDate";
			 public static string Security = @"Security";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiOn = @"ModifiOn";
			 public static string IsDeleted = @"IsDeleted";
			 public static string IsActive = @"IsActive";
			 public static string Status = @"Status";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
