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
	/// Strongly-typed collection for the ArticleCategory class.
	/// </summary>
    [Serializable]
	public partial class ArticleCategoryCollection : ActiveList<ArticleCategory, ArticleCategoryCollection>
	{	   
		public ArticleCategoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ArticleCategoryCollection</returns>
		public ArticleCategoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ArticleCategory o = this[i];
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
	/// This is an ActiveRecord class which wraps the ArticleCategory table.
	/// </summary>
	[Serializable]
	public partial class ArticleCategory : ActiveRecord<ArticleCategory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ArticleCategory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ArticleCategory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ArticleCategory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ArticleCategory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ArticleCategory", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarCategoryId = new TableSchema.TableColumn(schema);
				colvarCategoryId.ColumnName = "CategoryId";
				colvarCategoryId.DataType = DbType.Int32;
				colvarCategoryId.MaxLength = 0;
				colvarCategoryId.AutoIncrement = false;
				colvarCategoryId.IsNullable = false;
				colvarCategoryId.IsPrimaryKey = false;
				colvarCategoryId.IsForeignKey = true;
				colvarCategoryId.IsReadOnly = false;
				
						colvarCategoryId.DefaultSetting = @"((0))";
				
					colvarCategoryId.ForeignKeyTableName = "Category";
				schema.Columns.Add(colvarCategoryId);
				
				TableSchema.TableColumn colvarPartitionId = new TableSchema.TableColumn(schema);
				colvarPartitionId.ColumnName = "PartitionId";
				colvarPartitionId.DataType = DbType.Int32;
				colvarPartitionId.MaxLength = 0;
				colvarPartitionId.AutoIncrement = false;
				colvarPartitionId.IsNullable = false;
				colvarPartitionId.IsPrimaryKey = false;
				colvarPartitionId.IsForeignKey = false;
				colvarPartitionId.IsReadOnly = false;
				
						colvarPartitionId.DefaultSetting = @"((0))";
				colvarPartitionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPartitionId);
				
				TableSchema.TableColumn colvarArticleId = new TableSchema.TableColumn(schema);
				colvarArticleId.ColumnName = "ArticleId";
				colvarArticleId.DataType = DbType.Int32;
				colvarArticleId.MaxLength = 0;
				colvarArticleId.AutoIncrement = false;
				colvarArticleId.IsNullable = false;
				colvarArticleId.IsPrimaryKey = false;
				colvarArticleId.IsForeignKey = true;
				colvarArticleId.IsReadOnly = false;
				
						colvarArticleId.DefaultSetting = @"((0))";
				
					colvarArticleId.ForeignKeyTableName = "Article";
				schema.Columns.Add(colvarArticleId);
				
				TableSchema.TableColumn colvarOrd = new TableSchema.TableColumn(schema);
				colvarOrd.ColumnName = "Ord";
				colvarOrd.DataType = DbType.Int32;
				colvarOrd.MaxLength = 0;
				colvarOrd.AutoIncrement = false;
				colvarOrd.IsNullable = false;
				colvarOrd.IsPrimaryKey = false;
				colvarOrd.IsForeignKey = false;
				colvarOrd.IsReadOnly = false;
				
						colvarOrd.DefaultSetting = @"((1))";
				colvarOrd.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrd);
				
				TableSchema.TableColumn colvarArticleContentTypeId = new TableSchema.TableColumn(schema);
				colvarArticleContentTypeId.ColumnName = "ArticleContentTypeId";
				colvarArticleContentTypeId.DataType = DbType.Int32;
				colvarArticleContentTypeId.MaxLength = 0;
				colvarArticleContentTypeId.AutoIncrement = false;
				colvarArticleContentTypeId.IsNullable = false;
				colvarArticleContentTypeId.IsPrimaryKey = false;
				colvarArticleContentTypeId.IsForeignKey = false;
				colvarArticleContentTypeId.IsReadOnly = false;
				
						colvarArticleContentTypeId.DefaultSetting = @"((0))";
				colvarArticleContentTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArticleContentTypeId);
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "Url";
				colvarUrl.DataType = DbType.String;
				colvarUrl.MaxLength = 255;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = true;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
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
				
				TableSchema.TableColumn colvarPrimaryCategory = new TableSchema.TableColumn(schema);
				colvarPrimaryCategory.ColumnName = "PrimaryCategory";
				colvarPrimaryCategory.DataType = DbType.Int32;
				colvarPrimaryCategory.MaxLength = 0;
				colvarPrimaryCategory.AutoIncrement = false;
				colvarPrimaryCategory.IsNullable = false;
				colvarPrimaryCategory.IsPrimaryKey = false;
				colvarPrimaryCategory.IsForeignKey = false;
				colvarPrimaryCategory.IsReadOnly = false;
				
						colvarPrimaryCategory.DefaultSetting = @"((0))";
				colvarPrimaryCategory.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimaryCategory);
				
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
				
				TableSchema.TableColumn colvarPartitionNumber = new TableSchema.TableColumn(schema);
				colvarPartitionNumber.ColumnName = "PartitionNumber";
				colvarPartitionNumber.DataType = DbType.Int32;
				colvarPartitionNumber.MaxLength = 0;
				colvarPartitionNumber.AutoIncrement = false;
				colvarPartitionNumber.IsNullable = true;
				colvarPartitionNumber.IsPrimaryKey = false;
				colvarPartitionNumber.IsForeignKey = false;
				colvarPartitionNumber.IsReadOnly = true;
				colvarPartitionNumber.DefaultSetting = @"";
				colvarPartitionNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPartitionNumber);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VCMS"].AddSchema("ArticleCategory",schema);
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
		  
		[XmlAttribute("CategoryId")]
		[Bindable(true)]
		public int CategoryId 
		{
			get { return GetColumnValue<int>(Columns.CategoryId); }
			set { SetColumnValue(Columns.CategoryId, value); }
		}
		  
		[XmlAttribute("PartitionId")]
		[Bindable(true)]
		public int PartitionId 
		{
			get { return GetColumnValue<int>(Columns.PartitionId); }
			set { SetColumnValue(Columns.PartitionId, value); }
		}
		  
		[XmlAttribute("ArticleId")]
		[Bindable(true)]
		public int ArticleId 
		{
			get { return GetColumnValue<int>(Columns.ArticleId); }
			set { SetColumnValue(Columns.ArticleId, value); }
		}
		  
		[XmlAttribute("Ord")]
		[Bindable(true)]
		public int Ord 
		{
			get { return GetColumnValue<int>(Columns.Ord); }
			set { SetColumnValue(Columns.Ord, value); }
		}
		  
		[XmlAttribute("ArticleContentTypeId")]
		[Bindable(true)]
		public int ArticleContentTypeId 
		{
			get { return GetColumnValue<int>(Columns.ArticleContentTypeId); }
			set { SetColumnValue(Columns.ArticleContentTypeId, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("PublishDate")]
		[Bindable(true)]
		public DateTime PublishDate 
		{
			get { return GetColumnValue<DateTime>(Columns.PublishDate); }
			set { SetColumnValue(Columns.PublishDate, value); }
		}
		  
		[XmlAttribute("PrimaryCategory")]
		[Bindable(true)]
		public int PrimaryCategory 
		{
			get { return GetColumnValue<int>(Columns.PrimaryCategory); }
			set { SetColumnValue(Columns.PrimaryCategory, value); }
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
		  
		[XmlAttribute("PartitionNumber")]
		[Bindable(true)]
		public int? PartitionNumber 
		{
			get { return GetColumnValue<int?>(Columns.PartitionNumber); }
			set { SetColumnValue(Columns.PartitionNumber, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Article ActiveRecord object related to this ArticleCategory
		/// 
		/// </summary>
		public DAL.Article Article
		{
			get { return DAL.Article.FetchByID(this.ArticleId); }
			set { SetColumnValue("ArticleId", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a Category ActiveRecord object related to this ArticleCategory
		/// 
		/// </summary>
		public DAL.Category Category
		{
			get { return DAL.Category.FetchByID(this.CategoryId); }
			set { SetColumnValue("CategoryId", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCategoryId,int varPartitionId,int varArticleId,int varOrd,int varArticleContentTypeId,string varUrl,DateTime varPublishDate,int varPrimaryCategory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag,int? varPartitionNumber)
		{
			ArticleCategory item = new ArticleCategory();
			
			item.CategoryId = varCategoryId;
			
			item.PartitionId = varPartitionId;
			
			item.ArticleId = varArticleId;
			
			item.Ord = varOrd;
			
			item.ArticleContentTypeId = varArticleContentTypeId;
			
			item.Url = varUrl;
			
			item.PublishDate = varPublishDate;
			
			item.PrimaryCategory = varPrimaryCategory;
			
			item.CreatedAt = varCreatedAt;
			
			item.CreatedBy = varCreatedBy;
			
			item.LastModifiedAt = varLastModifiedAt;
			
			item.LastModifiedBy = varLastModifiedBy;
			
			item.Flag = varFlag;
			
			item.PartitionNumber = varPartitionNumber;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varCategoryId,int varPartitionId,int varArticleId,int varOrd,int varArticleContentTypeId,string varUrl,DateTime varPublishDate,int varPrimaryCategory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag,int? varPartitionNumber)
		{
			ArticleCategory item = new ArticleCategory();
			
				item.Id = varId;
			
				item.CategoryId = varCategoryId;
			
				item.PartitionId = varPartitionId;
			
				item.ArticleId = varArticleId;
			
				item.Ord = varOrd;
			
				item.ArticleContentTypeId = varArticleContentTypeId;
			
				item.Url = varUrl;
			
				item.PublishDate = varPublishDate;
			
				item.PrimaryCategory = varPrimaryCategory;
			
				item.CreatedAt = varCreatedAt;
			
				item.CreatedBy = varCreatedBy;
			
				item.LastModifiedAt = varLastModifiedAt;
			
				item.LastModifiedBy = varLastModifiedBy;
			
				item.Flag = varFlag;
			
				item.PartitionNumber = varPartitionNumber;
			
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
        
        
        
        public static TableSchema.TableColumn CategoryIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PartitionIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleContentTypeIdColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PublishDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimaryCategoryColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PartitionNumberColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string CategoryId = @"CategoryId";
			 public static string PartitionId = @"PartitionId";
			 public static string ArticleId = @"ArticleId";
			 public static string Ord = @"Ord";
			 public static string ArticleContentTypeId = @"ArticleContentTypeId";
			 public static string Url = @"Url";
			 public static string PublishDate = @"PublishDate";
			 public static string PrimaryCategory = @"PrimaryCategory";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
			 public static string PartitionNumber = @"PartitionNumber";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
