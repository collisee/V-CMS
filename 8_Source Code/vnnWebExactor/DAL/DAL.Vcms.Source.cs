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
	/// Strongly-typed collection for the Source class.
	/// </summary>
	[Serializable]
	public partial class SourceCollection : ActiveList<Source, SourceCollection> 
	{	   
		public SourceCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Sources table.
	/// </summary>
	[Serializable]
	public partial class Source : ActiveRecord<Source>
	{
		#region .ctors and Default Settings
		
		public Source()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Source(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Source(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Source(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sources", TableType.Table, DataService.GetInstance("VCMS"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarHref = new TableSchema.TableColumn(schema);
				colvarHref.ColumnName = "Href";
				colvarHref.DataType = DbType.String;
				colvarHref.MaxLength = 200;
				colvarHref.AutoIncrement = false;
				colvarHref.IsNullable = true;
				colvarHref.IsPrimaryKey = false;
				colvarHref.IsForeignKey = false;
				colvarHref.IsReadOnly = false;
				colvarHref.DefaultSetting = @"";
				colvarHref.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHref);
				
				TableSchema.TableColumn colvarStartTags = new TableSchema.TableColumn(schema);
				colvarStartTags.ColumnName = "StartTags";
				colvarStartTags.DataType = DbType.String;
				colvarStartTags.MaxLength = 1073741823;
				colvarStartTags.AutoIncrement = false;
				colvarStartTags.IsNullable = true;
				colvarStartTags.IsPrimaryKey = false;
				colvarStartTags.IsForeignKey = false;
				colvarStartTags.IsReadOnly = false;
				colvarStartTags.DefaultSetting = @"";
				colvarStartTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartTags);
				
				TableSchema.TableColumn colvarEndTags = new TableSchema.TableColumn(schema);
				colvarEndTags.ColumnName = "EndTags";
				colvarEndTags.DataType = DbType.String;
				colvarEndTags.MaxLength = 1073741823;
				colvarEndTags.AutoIncrement = false;
				colvarEndTags.IsNullable = true;
				colvarEndTags.IsPrimaryKey = false;
				colvarEndTags.IsForeignKey = false;
				colvarEndTags.IsReadOnly = false;
				colvarEndTags.DefaultSetting = @"";
				colvarEndTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndTags);
				
				TableSchema.TableColumn colvarTitleStartTags = new TableSchema.TableColumn(schema);
				colvarTitleStartTags.ColumnName = "TitleStartTags";
				colvarTitleStartTags.DataType = DbType.String;
				colvarTitleStartTags.MaxLength = 1073741823;
				colvarTitleStartTags.AutoIncrement = false;
				colvarTitleStartTags.IsNullable = true;
				colvarTitleStartTags.IsPrimaryKey = false;
				colvarTitleStartTags.IsForeignKey = false;
				colvarTitleStartTags.IsReadOnly = false;
				colvarTitleStartTags.DefaultSetting = @"";
				colvarTitleStartTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitleStartTags);
				
				TableSchema.TableColumn colvarTitleEndTags = new TableSchema.TableColumn(schema);
				colvarTitleEndTags.ColumnName = "TitleEndTags";
				colvarTitleEndTags.DataType = DbType.String;
				colvarTitleEndTags.MaxLength = 1073741823;
				colvarTitleEndTags.AutoIncrement = false;
				colvarTitleEndTags.IsNullable = true;
				colvarTitleEndTags.IsPrimaryKey = false;
				colvarTitleEndTags.IsForeignKey = false;
				colvarTitleEndTags.IsReadOnly = false;
				colvarTitleEndTags.DefaultSetting = @"";
				colvarTitleEndTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitleEndTags);
				
				TableSchema.TableColumn colvarDescStartTags = new TableSchema.TableColumn(schema);
				colvarDescStartTags.ColumnName = "DescStartTags";
				colvarDescStartTags.DataType = DbType.String;
				colvarDescStartTags.MaxLength = 1073741823;
				colvarDescStartTags.AutoIncrement = false;
				colvarDescStartTags.IsNullable = true;
				colvarDescStartTags.IsPrimaryKey = false;
				colvarDescStartTags.IsForeignKey = false;
				colvarDescStartTags.IsReadOnly = false;
				colvarDescStartTags.DefaultSetting = @"";
				colvarDescStartTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescStartTags);
				
				TableSchema.TableColumn colvarDescEndTags = new TableSchema.TableColumn(schema);
				colvarDescEndTags.ColumnName = "DescEndTags";
				colvarDescEndTags.DataType = DbType.String;
				colvarDescEndTags.MaxLength = 1073741823;
				colvarDescEndTags.AutoIncrement = false;
				colvarDescEndTags.IsNullable = true;
				colvarDescEndTags.IsPrimaryKey = false;
				colvarDescEndTags.IsForeignKey = false;
				colvarDescEndTags.IsReadOnly = false;
				colvarDescEndTags.DefaultSetting = @"";
				colvarDescEndTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescEndTags);
				
				TableSchema.TableColumn colvarContentStartTags = new TableSchema.TableColumn(schema);
				colvarContentStartTags.ColumnName = "ContentStartTags";
				colvarContentStartTags.DataType = DbType.String;
				colvarContentStartTags.MaxLength = 1073741823;
				colvarContentStartTags.AutoIncrement = false;
				colvarContentStartTags.IsNullable = true;
				colvarContentStartTags.IsPrimaryKey = false;
				colvarContentStartTags.IsForeignKey = false;
				colvarContentStartTags.IsReadOnly = false;
				colvarContentStartTags.DefaultSetting = @"";
				colvarContentStartTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContentStartTags);
				
				TableSchema.TableColumn colvarContentEndTags = new TableSchema.TableColumn(schema);
				colvarContentEndTags.ColumnName = "ContentEndTags";
				colvarContentEndTags.DataType = DbType.String;
				colvarContentEndTags.MaxLength = 1073741823;
				colvarContentEndTags.AutoIncrement = false;
				colvarContentEndTags.IsNullable = true;
				colvarContentEndTags.IsPrimaryKey = false;
				colvarContentEndTags.IsForeignKey = false;
				colvarContentEndTags.IsReadOnly = false;
				colvarContentEndTags.DefaultSetting = @"";
				colvarContentEndTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContentEndTags);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 500;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
				colvarCategoryID.ColumnName = "CategoryID";
				colvarCategoryID.DataType = DbType.Int32;
				colvarCategoryID.MaxLength = 0;
				colvarCategoryID.AutoIncrement = false;
				colvarCategoryID.IsNullable = true;
				colvarCategoryID.IsPrimaryKey = false;
				colvarCategoryID.IsForeignKey = true;
				colvarCategoryID.IsReadOnly = false;
				colvarCategoryID.DefaultSetting = @"";
				
					colvarCategoryID.ForeignKeyTableName = "Category";
				schema.Columns.Add(colvarCategoryID);
				
				TableSchema.TableColumn colvarSourceX = new TableSchema.TableColumn(schema);
				colvarSourceX.ColumnName = "Source";
				colvarSourceX.DataType = DbType.String;
				colvarSourceX.MaxLength = 200;
				colvarSourceX.AutoIncrement = false;
				colvarSourceX.IsNullable = true;
				colvarSourceX.IsPrimaryKey = false;
				colvarSourceX.IsForeignKey = false;
				colvarSourceX.IsReadOnly = false;
				colvarSourceX.DefaultSetting = @"";
				colvarSourceX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSourceX);
				
				TableSchema.TableColumn colvarNewsFlag = new TableSchema.TableColumn(schema);
				colvarNewsFlag.ColumnName = "NewsFlag";
				colvarNewsFlag.DataType = DbType.Boolean;
				colvarNewsFlag.MaxLength = 0;
				colvarNewsFlag.AutoIncrement = false;
				colvarNewsFlag.IsNullable = true;
				colvarNewsFlag.IsPrimaryKey = false;
				colvarNewsFlag.IsForeignKey = false;
				colvarNewsFlag.IsReadOnly = false;
				colvarNewsFlag.DefaultSetting = @"";
				colvarNewsFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNewsFlag);
				
				TableSchema.TableColumn colvarWholeImagePath = new TableSchema.TableColumn(schema);
				colvarWholeImagePath.ColumnName = "WholeImagePath";
				colvarWholeImagePath.DataType = DbType.String;
				colvarWholeImagePath.MaxLength = 200;
				colvarWholeImagePath.AutoIncrement = false;
				colvarWholeImagePath.IsNullable = true;
				colvarWholeImagePath.IsPrimaryKey = false;
				colvarWholeImagePath.IsForeignKey = false;
				colvarWholeImagePath.IsReadOnly = false;
				colvarWholeImagePath.DefaultSetting = @"";
				colvarWholeImagePath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWholeImagePath);
				
				TableSchema.TableColumn colvarImageDirectory = new TableSchema.TableColumn(schema);
				colvarImageDirectory.ColumnName = "ImageDirectory";
				colvarImageDirectory.DataType = DbType.String;
				colvarImageDirectory.MaxLength = 500;
				colvarImageDirectory.AutoIncrement = false;
				colvarImageDirectory.IsNullable = true;
				colvarImageDirectory.IsPrimaryKey = false;
				colvarImageDirectory.IsForeignKey = false;
				colvarImageDirectory.IsReadOnly = false;
				colvarImageDirectory.DefaultSetting = @"";
				colvarImageDirectory.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageDirectory);
				
				TableSchema.TableColumn colvarServiceName = new TableSchema.TableColumn(schema);
				colvarServiceName.ColumnName = "ServiceName";
				colvarServiceName.DataType = DbType.String;
				colvarServiceName.MaxLength = 20;
				colvarServiceName.AutoIncrement = false;
				colvarServiceName.IsNullable = true;
				colvarServiceName.IsPrimaryKey = false;
				colvarServiceName.IsForeignKey = false;
				colvarServiceName.IsReadOnly = false;
				colvarServiceName.DefaultSetting = @"";
				colvarServiceName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarServiceName);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VCMS"].AddSchema("Sources",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("Id")]
		public int Id 
		{
			get { return GetColumnValue<int>("ID"); }

			set { SetColumnValue("ID", value); }

		}

		  
		[XmlAttribute("Href")]
		public string Href 
		{
			get { return GetColumnValue<string>("Href"); }

			set { SetColumnValue("Href", value); }

		}

		  
		[XmlAttribute("StartTags")]
		public string StartTags 
		{
			get { return GetColumnValue<string>("StartTags"); }

			set { SetColumnValue("StartTags", value); }

		}

		  
		[XmlAttribute("EndTags")]
		public string EndTags 
		{
			get { return GetColumnValue<string>("EndTags"); }

			set { SetColumnValue("EndTags", value); }

		}

		  
		[XmlAttribute("TitleStartTags")]
		public string TitleStartTags 
		{
			get { return GetColumnValue<string>("TitleStartTags"); }

			set { SetColumnValue("TitleStartTags", value); }

		}

		  
		[XmlAttribute("TitleEndTags")]
		public string TitleEndTags 
		{
			get { return GetColumnValue<string>("TitleEndTags"); }

			set { SetColumnValue("TitleEndTags", value); }

		}

		  
		[XmlAttribute("DescStartTags")]
		public string DescStartTags 
		{
			get { return GetColumnValue<string>("DescStartTags"); }

			set { SetColumnValue("DescStartTags", value); }

		}

		  
		[XmlAttribute("DescEndTags")]
		public string DescEndTags 
		{
			get { return GetColumnValue<string>("DescEndTags"); }

			set { SetColumnValue("DescEndTags", value); }

		}

		  
		[XmlAttribute("ContentStartTags")]
		public string ContentStartTags 
		{
			get { return GetColumnValue<string>("ContentStartTags"); }

			set { SetColumnValue("ContentStartTags", value); }

		}

		  
		[XmlAttribute("ContentEndTags")]
		public string ContentEndTags 
		{
			get { return GetColumnValue<string>("ContentEndTags"); }

			set { SetColumnValue("ContentEndTags", value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>("Description"); }

			set { SetColumnValue("Description", value); }

		}

		  
		[XmlAttribute("CategoryID")]
		public int? CategoryID 
		{
			get { return GetColumnValue<int?>("CategoryID"); }

			set { SetColumnValue("CategoryID", value); }

		}

		  
		[XmlAttribute("SourceX")]
		public string SourceX 
		{
			get { return GetColumnValue<string>("Source"); }

			set { SetColumnValue("Source", value); }

		}

		  
		[XmlAttribute("NewsFlag")]
		public bool? NewsFlag 
		{
			get { return GetColumnValue<bool?>("NewsFlag"); }

			set { SetColumnValue("NewsFlag", value); }

		}

		  
		[XmlAttribute("WholeImagePath")]
		public string WholeImagePath 
		{
			get { return GetColumnValue<string>("WholeImagePath"); }

			set { SetColumnValue("WholeImagePath", value); }

		}

		  
		[XmlAttribute("ImageDirectory")]
		public string ImageDirectory 
		{
			get { return GetColumnValue<string>("ImageDirectory"); }

			set { SetColumnValue("ImageDirectory", value); }

		}

		  
		[XmlAttribute("ServiceName")]
		public string ServiceName 
		{
			get { return GetColumnValue<string>("ServiceName"); }

			set { SetColumnValue("ServiceName", value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Category ActiveRecord object related to this Source
		/// 
		/// </summary>
		public DAL.Category Category
		{
			get { return DAL.Category.FetchByID(this.CategoryID); }

			set { SetColumnValue("CategoryID", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varId,string varHref,string varStartTags,string varEndTags,string varTitleStartTags,string varTitleEndTags,string varDescStartTags,string varDescEndTags,string varContentStartTags,string varContentEndTags,string varDescription,int? varCategoryID,string varSourceX,bool? varNewsFlag,string varWholeImagePath,string varImageDirectory,string varServiceName)
		{
			Source item = new Source();
			
			item.Id = varId;
			
			item.Href = varHref;
			
			item.StartTags = varStartTags;
			
			item.EndTags = varEndTags;
			
			item.TitleStartTags = varTitleStartTags;
			
			item.TitleEndTags = varTitleEndTags;
			
			item.DescStartTags = varDescStartTags;
			
			item.DescEndTags = varDescEndTags;
			
			item.ContentStartTags = varContentStartTags;
			
			item.ContentEndTags = varContentEndTags;
			
			item.Description = varDescription;
			
			item.CategoryID = varCategoryID;
			
			item.SourceX = varSourceX;
			
			item.NewsFlag = varNewsFlag;
			
			item.WholeImagePath = varWholeImagePath;
			
			item.ImageDirectory = varImageDirectory;
			
			item.ServiceName = varServiceName;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varHref,string varStartTags,string varEndTags,string varTitleStartTags,string varTitleEndTags,string varDescStartTags,string varDescEndTags,string varContentStartTags,string varContentEndTags,string varDescription,int? varCategoryID,string varSourceX,bool? varNewsFlag,string varWholeImagePath,string varImageDirectory,string varServiceName)
		{
			Source item = new Source();
			
				item.Id = varId;
				
				item.Href = varHref;
				
				item.StartTags = varStartTags;
				
				item.EndTags = varEndTags;
				
				item.TitleStartTags = varTitleStartTags;
				
				item.TitleEndTags = varTitleEndTags;
				
				item.DescStartTags = varDescStartTags;
				
				item.DescEndTags = varDescEndTags;
				
				item.ContentStartTags = varContentStartTags;
				
				item.ContentEndTags = varContentEndTags;
				
				item.Description = varDescription;
				
				item.CategoryID = varCategoryID;
				
				item.SourceX = varSourceX;
				
				item.NewsFlag = varNewsFlag;
				
				item.WholeImagePath = varWholeImagePath;
				
				item.ImageDirectory = varImageDirectory;
				
				item.ServiceName = varServiceName;
				
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
			 public static string Id = @"ID";
			 public static string Href = @"Href";
			 public static string StartTags = @"StartTags";
			 public static string EndTags = @"EndTags";
			 public static string TitleStartTags = @"TitleStartTags";
			 public static string TitleEndTags = @"TitleEndTags";
			 public static string DescStartTags = @"DescStartTags";
			 public static string DescEndTags = @"DescEndTags";
			 public static string ContentStartTags = @"ContentStartTags";
			 public static string ContentEndTags = @"ContentEndTags";
			 public static string Description = @"Description";
			 public static string CategoryID = @"CategoryID";
			 public static string SourceX = @"Source";
			 public static string NewsFlag = @"NewsFlag";
			 public static string WholeImagePath = @"WholeImagePath";
			 public static string ImageDirectory = @"ImageDirectory";
			 public static string ServiceName = @"ServiceName";
						
		}

		#endregion
	}

}


