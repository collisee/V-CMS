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
	/// Strongly-typed collection for the SurveyOption class.
	/// </summary>
    [Serializable]
	public partial class SurveyOptionCollection : ActiveList<SurveyOption, SurveyOptionCollection>
	{	   
		public SurveyOptionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SurveyOptionCollection</returns>
		public SurveyOptionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SurveyOption o = this[i];
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
	/// This is an ActiveRecord class which wraps the SurveyOptions table.
	/// </summary>
	[Serializable]
	public partial class SurveyOption : ActiveRecord<SurveyOption>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SurveyOption()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SurveyOption(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SurveyOption(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SurveyOption(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SurveyOptions", TableType.Table, DataService.GetInstance("VNN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSurveyOptionId = new TableSchema.TableColumn(schema);
				colvarSurveyOptionId.ColumnName = "SurveyOptionId";
				colvarSurveyOptionId.DataType = DbType.Int32;
				colvarSurveyOptionId.MaxLength = 0;
				colvarSurveyOptionId.AutoIncrement = false;
				colvarSurveyOptionId.IsNullable = false;
				colvarSurveyOptionId.IsPrimaryKey = true;
				colvarSurveyOptionId.IsForeignKey = false;
				colvarSurveyOptionId.IsReadOnly = false;
				colvarSurveyOptionId.DefaultSetting = @"";
				colvarSurveyOptionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSurveyOptionId);
				
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
				
				TableSchema.TableColumn colvarOptionName = new TableSchema.TableColumn(schema);
				colvarOptionName.ColumnName = "OptionName";
				colvarOptionName.DataType = DbType.String;
				colvarOptionName.MaxLength = 500;
				colvarOptionName.AutoIncrement = false;
				colvarOptionName.IsNullable = false;
				colvarOptionName.IsPrimaryKey = false;
				colvarOptionName.IsForeignKey = false;
				colvarOptionName.IsReadOnly = false;
				colvarOptionName.DefaultSetting = @"";
				colvarOptionName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOptionName);
				
				TableSchema.TableColumn colvarViewOrder = new TableSchema.TableColumn(schema);
				colvarViewOrder.ColumnName = "ViewOrder";
				colvarViewOrder.DataType = DbType.Int32;
				colvarViewOrder.MaxLength = 0;
				colvarViewOrder.AutoIncrement = false;
				colvarViewOrder.IsNullable = false;
				colvarViewOrder.IsPrimaryKey = false;
				colvarViewOrder.IsForeignKey = false;
				colvarViewOrder.IsReadOnly = false;
				colvarViewOrder.DefaultSetting = @"";
				colvarViewOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarViewOrder);
				
				TableSchema.TableColumn colvarNotes = new TableSchema.TableColumn(schema);
				colvarNotes.ColumnName = "Notes";
				colvarNotes.DataType = DbType.String;
				colvarNotes.MaxLength = 500;
				colvarNotes.AutoIncrement = false;
				colvarNotes.IsNullable = true;
				colvarNotes.IsPrimaryKey = false;
				colvarNotes.IsForeignKey = false;
				colvarNotes.IsReadOnly = false;
				colvarNotes.DefaultSetting = @"";
				colvarNotes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotes);
				
				TableSchema.TableColumn colvarIsOther = new TableSchema.TableColumn(schema);
				colvarIsOther.ColumnName = "IsOther";
				colvarIsOther.DataType = DbType.Boolean;
				colvarIsOther.MaxLength = 0;
				colvarIsOther.AutoIncrement = false;
				colvarIsOther.IsNullable = true;
				colvarIsOther.IsPrimaryKey = false;
				colvarIsOther.IsForeignKey = false;
				colvarIsOther.IsReadOnly = false;
				colvarIsOther.DefaultSetting = @"";
				colvarIsOther.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsOther);
				
				TableSchema.TableColumn colvarIsCorrect = new TableSchema.TableColumn(schema);
				colvarIsCorrect.ColumnName = "IsCorrect";
				colvarIsCorrect.DataType = DbType.Boolean;
				colvarIsCorrect.MaxLength = 0;
				colvarIsCorrect.AutoIncrement = false;
				colvarIsCorrect.IsNullable = true;
				colvarIsCorrect.IsPrimaryKey = false;
				colvarIsCorrect.IsForeignKey = false;
				colvarIsCorrect.IsReadOnly = false;
				colvarIsCorrect.DefaultSetting = @"";
				colvarIsCorrect.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsCorrect);
				
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
				colvarCreatedOn.DefaultSetting = @"";
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
				colvarModifiOn.DefaultSetting = @"";
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
				colvarIsDeleted.DefaultSetting = @"";
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
				colvarIsActive.DefaultSetting = @"";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VNN"].AddSchema("SurveyOptions",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SurveyOptionId")]
		[Bindable(true)]
		public int SurveyOptionId 
		{
			get { return GetColumnValue<int>(Columns.SurveyOptionId); }
			set { SetColumnValue(Columns.SurveyOptionId, value); }
		}
		  
		[XmlAttribute("SurveyId")]
		[Bindable(true)]
		public int SurveyId 
		{
			get { return GetColumnValue<int>(Columns.SurveyId); }
			set { SetColumnValue(Columns.SurveyId, value); }
		}
		  
		[XmlAttribute("OptionName")]
		[Bindable(true)]
		public string OptionName 
		{
			get { return GetColumnValue<string>(Columns.OptionName); }
			set { SetColumnValue(Columns.OptionName, value); }
		}
		  
		[XmlAttribute("ViewOrder")]
		[Bindable(true)]
		public int ViewOrder 
		{
			get { return GetColumnValue<int>(Columns.ViewOrder); }
			set { SetColumnValue(Columns.ViewOrder, value); }
		}
		  
		[XmlAttribute("Notes")]
		[Bindable(true)]
		public string Notes 
		{
			get { return GetColumnValue<string>(Columns.Notes); }
			set { SetColumnValue(Columns.Notes, value); }
		}
		  
		[XmlAttribute("IsOther")]
		[Bindable(true)]
		public bool? IsOther 
		{
			get { return GetColumnValue<bool?>(Columns.IsOther); }
			set { SetColumnValue(Columns.IsOther, value); }
		}
		  
		[XmlAttribute("IsCorrect")]
		[Bindable(true)]
		public bool? IsCorrect 
		{
			get { return GetColumnValue<bool?>(Columns.IsCorrect); }
			set { SetColumnValue(Columns.IsCorrect, value); }
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
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSurveyOptionId,int varSurveyId,string varOptionName,int varViewOrder,string varNotes,bool? varIsOther,bool? varIsCorrect,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiOn,bool varIsDeleted,bool varIsActive)
		{
			SurveyOption item = new SurveyOption();
			
			item.SurveyOptionId = varSurveyOptionId;
			
			item.SurveyId = varSurveyId;
			
			item.OptionName = varOptionName;
			
			item.ViewOrder = varViewOrder;
			
			item.Notes = varNotes;
			
			item.IsOther = varIsOther;
			
			item.IsCorrect = varIsCorrect;
			
			item.CreatedBy = varCreatedBy;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedBy = varModifiedBy;
			
			item.ModifiOn = varModifiOn;
			
			item.IsDeleted = varIsDeleted;
			
			item.IsActive = varIsActive;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSurveyOptionId,int varSurveyId,string varOptionName,int varViewOrder,string varNotes,bool? varIsOther,bool? varIsCorrect,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiOn,bool varIsDeleted,bool varIsActive)
		{
			SurveyOption item = new SurveyOption();
			
				item.SurveyOptionId = varSurveyOptionId;
			
				item.SurveyId = varSurveyId;
			
				item.OptionName = varOptionName;
			
				item.ViewOrder = varViewOrder;
			
				item.Notes = varNotes;
			
				item.IsOther = varIsOther;
			
				item.IsCorrect = varIsCorrect;
			
				item.CreatedBy = varCreatedBy;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedBy = varModifiedBy;
			
				item.ModifiOn = varModifiOn;
			
				item.IsDeleted = varIsDeleted;
			
				item.IsActive = varIsActive;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SurveyOptionIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SurveyIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OptionNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ViewOrderColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NotesColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IsOtherColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IsCorrectColumn
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
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SurveyOptionId = @"SurveyOptionId";
			 public static string SurveyId = @"SurveyId";
			 public static string OptionName = @"OptionName";
			 public static string ViewOrder = @"ViewOrder";
			 public static string Notes = @"Notes";
			 public static string IsOther = @"IsOther";
			 public static string IsCorrect = @"IsCorrect";
			 public static string CreatedBy = @"CreatedBy";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedBy = @"ModifiedBy";
			 public static string ModifiOn = @"ModifiOn";
			 public static string IsDeleted = @"IsDeleted";
			 public static string IsActive = @"IsActive";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
