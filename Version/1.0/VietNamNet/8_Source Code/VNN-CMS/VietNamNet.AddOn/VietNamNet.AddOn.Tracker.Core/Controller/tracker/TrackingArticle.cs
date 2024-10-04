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
namespace VietNamNet.AddOn.Tracker.Core.tracker
{
	/// <summary>
	/// Strongly-typed collection for the TrackingArticle class.
	/// </summary>
    [Serializable]
	public partial class TrackingArticleCollection : ActiveList<TrackingArticle, TrackingArticleCollection>
	{	   
		public TrackingArticleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TrackingArticleCollection</returns>
		public TrackingArticleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TrackingArticle o = this[i];
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
	/// This is an ActiveRecord class which wraps the Tracking_Articles table.
	/// </summary>
	[Serializable]
	public partial class TrackingArticle : ActiveRecord<TrackingArticle>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TrackingArticle()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TrackingArticle(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TrackingArticle(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TrackingArticle(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Tracking_Articles", TableType.Table, DataService.GetInstance("VNN_Tracker"));
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
				
				TableSchema.TableColumn colvarIPAddress = new TableSchema.TableColumn(schema);
				colvarIPAddress.ColumnName = "IPAddress";
				colvarIPAddress.DataType = DbType.String;
				colvarIPAddress.MaxLength = 20;
				colvarIPAddress.AutoIncrement = false;
				colvarIPAddress.IsNullable = true;
				colvarIPAddress.IsPrimaryKey = false;
				colvarIPAddress.IsForeignKey = false;
				colvarIPAddress.IsReadOnly = false;
				colvarIPAddress.DefaultSetting = @"";
				colvarIPAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIPAddress);
				
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
				
				TableSchema.TableColumn colvarCategoryAlias = new TableSchema.TableColumn(schema);
				colvarCategoryAlias.ColumnName = "CategoryAlias";
				colvarCategoryAlias.DataType = DbType.String;
				colvarCategoryAlias.MaxLength = 255;
				colvarCategoryAlias.AutoIncrement = false;
				colvarCategoryAlias.IsNullable = true;
				colvarCategoryAlias.IsPrimaryKey = false;
				colvarCategoryAlias.IsForeignKey = false;
				colvarCategoryAlias.IsReadOnly = false;
				colvarCategoryAlias.DefaultSetting = @"";
				colvarCategoryAlias.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryAlias);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = true;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(getdate())";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarModifyOn = new TableSchema.TableColumn(schema);
				colvarModifyOn.ColumnName = "ModifyOn";
				colvarModifyOn.DataType = DbType.DateTime;
				colvarModifyOn.MaxLength = 0;
				colvarModifyOn.AutoIncrement = false;
				colvarModifyOn.IsNullable = true;
				colvarModifyOn.IsPrimaryKey = false;
				colvarModifyOn.IsForeignKey = false;
				colvarModifyOn.IsReadOnly = false;
				
						colvarModifyOn.DefaultSetting = @"(getdate())";
				colvarModifyOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifyOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VNN_Tracker"].AddSchema("Tracking_Articles",schema);
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
		  
		[XmlAttribute("IPAddress")]
		[Bindable(true)]
		public string IPAddress 
		{
			get { return GetColumnValue<string>(Columns.IPAddress); }
			set { SetColumnValue(Columns.IPAddress, value); }
		}
		  
		[XmlAttribute("ArticleId")]
		[Bindable(true)]
		public int? ArticleId 
		{
			get { return GetColumnValue<int?>(Columns.ArticleId); }
			set { SetColumnValue(Columns.ArticleId, value); }
		}
		  
		[XmlAttribute("CategoryAlias")]
		[Bindable(true)]
		public string CategoryAlias 
		{
			get { return GetColumnValue<string>(Columns.CategoryAlias); }
			set { SetColumnValue(Columns.CategoryAlias, value); }
		}
		  
		[XmlAttribute("CreatedOn")]
		[Bindable(true)]
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
			set { SetColumnValue(Columns.CreatedOn, value); }
		}
		  
		[XmlAttribute("ModifyOn")]
		[Bindable(true)]
		public DateTime? ModifyOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifyOn); }
			set { SetColumnValue(Columns.ModifyOn, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varIPAddress,int? varArticleId,string varCategoryAlias,DateTime? varCreatedOn,DateTime? varModifyOn)
		{
			TrackingArticle item = new TrackingArticle();
			
			item.IPAddress = varIPAddress;
			
			item.ArticleId = varArticleId;
			
			item.CategoryAlias = varCategoryAlias;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifyOn = varModifyOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varIPAddress,int? varArticleId,string varCategoryAlias,DateTime? varCreatedOn,DateTime? varModifyOn)
		{
			TrackingArticle item = new TrackingArticle();
			
				item.Id = varId;
			
				item.IPAddress = varIPAddress;
			
				item.ArticleId = varArticleId;
			
				item.CategoryAlias = varCategoryAlias;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifyOn = varModifyOn;
			
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
        
        
        
        public static TableSchema.TableColumn IPAddressColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleIdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryAliasColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifyOnColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string IPAddress = @"IPAddress";
			 public static string ArticleId = @"ArticleId";
			 public static string CategoryAlias = @"CategoryAlias";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifyOn = @"ModifyOn";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
