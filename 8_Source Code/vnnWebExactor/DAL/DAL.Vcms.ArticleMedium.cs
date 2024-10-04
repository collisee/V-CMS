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
	/// Strongly-typed collection for the ArticleMedium class.
	/// </summary>
	[Serializable]
	public partial class ArticleMediumCollection : ActiveList<ArticleMedium, ArticleMediumCollection> 
	{	   
		public ArticleMediumCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ArticleMedia table.
	/// </summary>
	[Serializable]
	public partial class ArticleMedium : ActiveRecord<ArticleMedium>
	{
		#region .ctors and Default Settings
		
		public ArticleMedium()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ArticleMedium(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ArticleMedium(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ArticleMedium(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ArticleMedia", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarArticleId = new TableSchema.TableColumn(schema);
				colvarArticleId.ColumnName = "ArticleId";
				colvarArticleId.DataType = DbType.Int32;
				colvarArticleId.MaxLength = 0;
				colvarArticleId.AutoIncrement = false;
				colvarArticleId.IsNullable = false;
				colvarArticleId.IsPrimaryKey = false;
				colvarArticleId.IsForeignKey = true;
				colvarArticleId.IsReadOnly = false;
				colvarArticleId.DefaultSetting = @"";
				
					colvarArticleId.ForeignKeyTableName = "Article";
				schema.Columns.Add(colvarArticleId);
				
				TableSchema.TableColumn colvarMediaType = new TableSchema.TableColumn(schema);
				colvarMediaType.ColumnName = "MediaType";
				colvarMediaType.DataType = DbType.String;
				colvarMediaType.MaxLength = 50;
				colvarMediaType.AutoIncrement = false;
				colvarMediaType.IsNullable = false;
				colvarMediaType.IsPrimaryKey = false;
				colvarMediaType.IsForeignKey = false;
				colvarMediaType.IsReadOnly = false;
				
						colvarMediaType.DefaultSetting = @"(N'Image')";
				colvarMediaType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMediaType);
				
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
				
				TableSchema.TableColumn colvarFileLink = new TableSchema.TableColumn(schema);
				colvarFileLink.ColumnName = "FileLink";
				colvarFileLink.DataType = DbType.String;
				colvarFileLink.MaxLength = 255;
				colvarFileLink.AutoIncrement = false;
				colvarFileLink.IsNullable = false;
				colvarFileLink.IsPrimaryKey = false;
				colvarFileLink.IsForeignKey = false;
				colvarFileLink.IsReadOnly = false;
				colvarFileLink.DefaultSetting = @"";
				colvarFileLink.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFileLink);
				
				TableSchema.TableColumn colvarThumbnail = new TableSchema.TableColumn(schema);
				colvarThumbnail.ColumnName = "Thumbnail";
				colvarThumbnail.DataType = DbType.String;
				colvarThumbnail.MaxLength = 255;
				colvarThumbnail.AutoIncrement = false;
				colvarThumbnail.IsNullable = false;
				colvarThumbnail.IsPrimaryKey = false;
				colvarThumbnail.IsForeignKey = false;
				colvarThumbnail.IsReadOnly = false;
				colvarThumbnail.DefaultSetting = @"";
				colvarThumbnail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThumbnail);
				
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
				DataService.Providers["VCMS"].AddSchema("ArticleMedia",schema);
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

		  
		[XmlAttribute("ArticleId")]
		public int ArticleId 
		{
			get { return GetColumnValue<int>("ArticleId"); }

			set { SetColumnValue("ArticleId", value); }

		}

		  
		[XmlAttribute("MediaType")]
		public string MediaType 
		{
			get { return GetColumnValue<string>("MediaType"); }

			set { SetColumnValue("MediaType", value); }

		}

		  
		[XmlAttribute("Ord")]
		public int Ord 
		{
			get { return GetColumnValue<int>("Ord"); }

			set { SetColumnValue("Ord", value); }

		}

		  
		[XmlAttribute("FileLink")]
		public string FileLink 
		{
			get { return GetColumnValue<string>("FileLink"); }

			set { SetColumnValue("FileLink", value); }

		}

		  
		[XmlAttribute("Thumbnail")]
		public string Thumbnail 
		{
			get { return GetColumnValue<string>("Thumbnail"); }

			set { SetColumnValue("Thumbnail", value); }

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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Article ActiveRecord object related to this ArticleMedium
		/// 
		/// </summary>
		public DAL.Article Article
		{
			get { return DAL.Article.FetchByID(this.ArticleId); }

			set { SetColumnValue("ArticleId", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varArticleId,string varMediaType,int varOrd,string varFileLink,string varThumbnail,string varDetail,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleMedium item = new ArticleMedium();
			
			item.ArticleId = varArticleId;
			
			item.MediaType = varMediaType;
			
			item.Ord = varOrd;
			
			item.FileLink = varFileLink;
			
			item.Thumbnail = varThumbnail;
			
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
		public static void Update(int varId,int varArticleId,string varMediaType,int varOrd,string varFileLink,string varThumbnail,string varDetail,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleMedium item = new ArticleMedium();
			
				item.Id = varId;
				
				item.ArticleId = varArticleId;
				
				item.MediaType = varMediaType;
				
				item.Ord = varOrd;
				
				item.FileLink = varFileLink;
				
				item.Thumbnail = varThumbnail;
				
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
			 public static string ArticleId = @"ArticleId";
			 public static string MediaType = @"MediaType";
			 public static string Ord = @"Ord";
			 public static string FileLink = @"FileLink";
			 public static string Thumbnail = @"Thumbnail";
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


