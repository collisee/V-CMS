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
	/// Strongly-typed collection for the Category class.
	/// </summary>
	[Serializable]
	public partial class CategoryCollection : ActiveList<Category, CategoryCollection> 
	{	   
		public CategoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Category table.
	/// </summary>
	[Serializable]
	public partial class Category : ActiveRecord<Category>
	{
		#region .ctors and Default Settings
		
		public Category()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Category(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Category(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Category(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Category", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarPartitionId = new TableSchema.TableColumn(schema);
				colvarPartitionId.ColumnName = "PartitionId";
				colvarPartitionId.DataType = DbType.Int32;
				colvarPartitionId.MaxLength = 0;
				colvarPartitionId.AutoIncrement = false;
				colvarPartitionId.IsNullable = false;
				colvarPartitionId.IsPrimaryKey = false;
				colvarPartitionId.IsForeignKey = false;
				colvarPartitionId.IsReadOnly = false;
				
						colvarPartitionId.DefaultSetting = @"((1))";
				colvarPartitionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPartitionId);
				
				TableSchema.TableColumn colvarPId = new TableSchema.TableColumn(schema);
				colvarPId.ColumnName = "PId";
				colvarPId.DataType = DbType.Int32;
				colvarPId.MaxLength = 0;
				colvarPId.AutoIncrement = false;
				colvarPId.IsNullable = true;
				colvarPId.IsPrimaryKey = false;
				colvarPId.IsForeignKey = false;
				colvarPId.IsReadOnly = false;
				colvarPId.DefaultSetting = @"";
				colvarPId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPId);
				
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
				
				TableSchema.TableColumn colvarAliasX = new TableSchema.TableColumn(schema);
				colvarAliasX.ColumnName = "Alias";
				colvarAliasX.DataType = DbType.String;
				colvarAliasX.MaxLength = 255;
				colvarAliasX.AutoIncrement = false;
				colvarAliasX.IsNullable = false;
				colvarAliasX.IsPrimaryKey = false;
				colvarAliasX.IsForeignKey = false;
				colvarAliasX.IsReadOnly = false;
				
						colvarAliasX.DefaultSetting = @"(N'')";
				colvarAliasX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAliasX);
				
				TableSchema.TableColumn colvarDisplayName = new TableSchema.TableColumn(schema);
				colvarDisplayName.ColumnName = "DisplayName";
				colvarDisplayName.DataType = DbType.String;
				colvarDisplayName.MaxLength = 255;
				colvarDisplayName.AutoIncrement = false;
				colvarDisplayName.IsNullable = false;
				colvarDisplayName.IsPrimaryKey = false;
				colvarDisplayName.IsForeignKey = false;
				colvarDisplayName.IsReadOnly = false;
				colvarDisplayName.DefaultSetting = @"";
				colvarDisplayName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDisplayName);
				
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
				DataService.Providers["VCMS"].AddSchema("Category",schema);
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

		  
		[XmlAttribute("PartitionId")]
		public int PartitionId 
		{
			get { return GetColumnValue<int>("PartitionId"); }

			set { SetColumnValue("PartitionId", value); }

		}

		  
		[XmlAttribute("PId")]
		public int? PId 
		{
			get { return GetColumnValue<int?>("PId"); }

			set { SetColumnValue("PId", value); }

		}

		  
		[XmlAttribute("Ord")]
		public int Ord 
		{
			get { return GetColumnValue<int>("Ord"); }

			set { SetColumnValue("Ord", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("AliasX")]
		public string AliasX 
		{
			get { return GetColumnValue<string>("Alias"); }

			set { SetColumnValue("Alias", value); }

		}

		  
		[XmlAttribute("DisplayName")]
		public string DisplayName 
		{
			get { return GetColumnValue<string>("DisplayName"); }

			set { SetColumnValue("DisplayName", value); }

		}

		  
		[XmlAttribute("Detail")]
		public string Detail 
		{
			get { return GetColumnValue<string>("Detail"); }

			set { SetColumnValue("Detail", value); }

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
		
		
		#region PrimaryKey Methods
		
		public DAL.ArticleCategoryCollection ArticleCategoryRecords()
		{
			return new DAL.ArticleCategoryCollection().Where(ArticleCategory.Columns.CategoryId, Id).Load();
		}

		public DAL.ArticleEventCategoryCollection ArticleEventCategoryRecords()
		{
			return new DAL.ArticleEventCategoryCollection().Where(ArticleEventCategory.Columns.CategoryId, Id).Load();
		}

		public DAL.CategoryPolicyCollection CategoryPolicyRecords()
		{
			return new DAL.CategoryPolicyCollection().Where(CategoryPolicy.Columns.CategoryId, Id).Load();
		}

		public DAL.SourceCollection Sources()
		{
			return new DAL.SourceCollection().Where(Source.Columns.CategoryID, Id).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varPartitionId,int? varPId,int varOrd,string varName,string varAliasX,string varDisplayName,string varDetail,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Category item = new Category();
			
			item.PartitionId = varPartitionId;
			
			item.PId = varPId;
			
			item.Ord = varOrd;
			
			item.Name = varName;
			
			item.AliasX = varAliasX;
			
			item.DisplayName = varDisplayName;
			
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
		public static void Update(int varId,int varPartitionId,int? varPId,int varOrd,string varName,string varAliasX,string varDisplayName,string varDetail,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Category item = new Category();
			
				item.Id = varId;
				
				item.PartitionId = varPartitionId;
				
				item.PId = varPId;
				
				item.Ord = varOrd;
				
				item.Name = varName;
				
				item.AliasX = varAliasX;
				
				item.DisplayName = varDisplayName;
				
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
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string PartitionId = @"PartitionId";
			 public static string PId = @"PId";
			 public static string Ord = @"Ord";
			 public static string Name = @"Name";
			 public static string AliasX = @"Alias";
			 public static string DisplayName = @"DisplayName";
			 public static string Detail = @"Detail";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}

		#endregion
	}

}


