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
	/// Strongly-typed collection for the ArticleEventCategory class.
	/// </summary>
	[Serializable]
	public partial class ArticleEventCategoryCollection : ActiveList<ArticleEventCategory, ArticleEventCategoryCollection> 
	{	   
		public ArticleEventCategoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ArticleEventCategory table.
	/// </summary>
	[Serializable]
	public partial class ArticleEventCategory : ActiveRecord<ArticleEventCategory>
	{
		#region .ctors and Default Settings
		
		public ArticleEventCategory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ArticleEventCategory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ArticleEventCategory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ArticleEventCategory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ArticleEventCategory", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarArticleEventId = new TableSchema.TableColumn(schema);
				colvarArticleEventId.ColumnName = "ArticleEventId";
				colvarArticleEventId.DataType = DbType.Int32;
				colvarArticleEventId.MaxLength = 0;
				colvarArticleEventId.AutoIncrement = false;
				colvarArticleEventId.IsNullable = false;
				colvarArticleEventId.IsPrimaryKey = false;
				colvarArticleEventId.IsForeignKey = true;
				colvarArticleEventId.IsReadOnly = false;
				
						colvarArticleEventId.DefaultSetting = @"((0))";
				
					colvarArticleEventId.ForeignKeyTableName = "ArticleEvent";
				schema.Columns.Add(colvarArticleEventId);
				
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
				
				TableSchema.TableColumn colvarOrd = new TableSchema.TableColumn(schema);
				colvarOrd.ColumnName = "Ord";
				colvarOrd.DataType = DbType.Int32;
				colvarOrd.MaxLength = 0;
				colvarOrd.AutoIncrement = false;
				colvarOrd.IsNullable = false;
				colvarOrd.IsPrimaryKey = false;
				colvarOrd.IsForeignKey = false;
				colvarOrd.IsReadOnly = false;
				
						colvarOrd.DefaultSetting = @"((0))";
				colvarOrd.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrd);
				
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
				DataService.Providers["VCMS"].AddSchema("ArticleEventCategory",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("Id")]
		public int Id 
		{
			get { return GetColumnValue<int>("Id"); }

			set { SetColumnValue("Id", value); }

		}

		  
		[XmlAttribute("ArticleEventId")]
		public int ArticleEventId 
		{
			get { return GetColumnValue<int>("ArticleEventId"); }

			set { SetColumnValue("ArticleEventId", value); }

		}

		  
		[XmlAttribute("CategoryId")]
		public int CategoryId 
		{
			get { return GetColumnValue<int>("CategoryId"); }

			set { SetColumnValue("CategoryId", value); }

		}

		  
		[XmlAttribute("Ord")]
		public int Ord 
		{
			get { return GetColumnValue<int>("Ord"); }

			set { SetColumnValue("Ord", value); }

		}

		  
		[XmlAttribute("CreatedAt")]
		public DateTime CreatedAt 
		{
			get { return GetColumnValue<DateTime>("Created_At"); }

			set { SetColumnValue("Created_At", value); }

		}

		  
		[XmlAttribute("CreatedBy")]
		public int CreatedBy 
		{
			get { return GetColumnValue<int>("Created_By"); }

			set { SetColumnValue("Created_By", value); }

		}

		  
		[XmlAttribute("LastModifiedAt")]
		public DateTime LastModifiedAt 
		{
			get { return GetColumnValue<DateTime>("Last_Modified_At"); }

			set { SetColumnValue("Last_Modified_At", value); }

		}

		  
		[XmlAttribute("LastModifiedBy")]
		public int LastModifiedBy 
		{
			get { return GetColumnValue<int>("Last_Modified_By"); }

			set { SetColumnValue("Last_Modified_By", value); }

		}

		  
		[XmlAttribute("Flag")]
		public string Flag 
		{
			get { return GetColumnValue<string>("flag"); }

			set { SetColumnValue("flag", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ArticleEvent ActiveRecord object related to this ArticleEventCategory
		/// 
		/// </summary>
		public DAL.ArticleEvent ArticleEvent
		{
			get { return DAL.ArticleEvent.FetchByID(this.ArticleEventId); }

			set { SetColumnValue("ArticleEventId", value.Id); }

		}

		
		
		/// <summary>
		/// Returns a Category ActiveRecord object related to this ArticleEventCategory
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
		public static void Insert(int varArticleEventId,int varCategoryId,int varOrd,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleEventCategory item = new ArticleEventCategory();
			
			item.ArticleEventId = varArticleEventId;
			
			item.CategoryId = varCategoryId;
			
			item.Ord = varOrd;
			
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
		public static void Update(int varId,int varArticleEventId,int varCategoryId,int varOrd,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleEventCategory item = new ArticleEventCategory();
			
				item.Id = varId;
				
				item.ArticleEventId = varArticleEventId;
				
				item.CategoryId = varCategoryId;
				
				item.Ord = varOrd;
				
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
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string ArticleEventId = @"ArticleEventId";
			 public static string CategoryId = @"CategoryId";
			 public static string Ord = @"Ord";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}

		#endregion
	}

}


