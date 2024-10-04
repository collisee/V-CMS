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
namespace VietNamNet.AddOn.SurveyModule.DAL
{
	/// <summary>
	/// Strongly-typed collection for the SurveyResult class.
	/// </summary>
    [Serializable]
	public partial class SurveyResultCollection : ActiveList<SurveyResult, SurveyResultCollection>
	{	   
		public SurveyResultCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SurveyResultCollection</returns>
		public SurveyResultCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SurveyResult o = this[i];
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
	/// This is an ActiveRecord class which wraps the SurveyResults table.
	/// </summary>
	[Serializable]
	public partial class SurveyResult : ActiveRecord<SurveyResult>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SurveyResult()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SurveyResult(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SurveyResult(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SurveyResult(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SurveyResults", TableType.Table, DataService.GetInstance("VietNamNet_Surveys"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSurveyResultId = new TableSchema.TableColumn(schema);
				colvarSurveyResultId.ColumnName = "SurveyResultId";
				colvarSurveyResultId.DataType = DbType.Int32;
				colvarSurveyResultId.MaxLength = 0;
				colvarSurveyResultId.AutoIncrement = true;
				colvarSurveyResultId.IsNullable = false;
				colvarSurveyResultId.IsPrimaryKey = true;
				colvarSurveyResultId.IsForeignKey = false;
				colvarSurveyResultId.IsReadOnly = false;
				colvarSurveyResultId.DefaultSetting = @"";
				colvarSurveyResultId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSurveyResultId);
				
				TableSchema.TableColumn colvarSurveyOptionId = new TableSchema.TableColumn(schema);
				colvarSurveyOptionId.ColumnName = "SurveyOptionId";
				colvarSurveyOptionId.DataType = DbType.Int32;
				colvarSurveyOptionId.MaxLength = 0;
				colvarSurveyOptionId.AutoIncrement = false;
				colvarSurveyOptionId.IsNullable = false;
				colvarSurveyOptionId.IsPrimaryKey = false;
				colvarSurveyOptionId.IsForeignKey = true;
				colvarSurveyOptionId.IsReadOnly = false;
				colvarSurveyOptionId.DefaultSetting = @"";
				
					colvarSurveyOptionId.ForeignKeyTableName = "SurveyOptions";
				schema.Columns.Add(colvarSurveyOptionId);
				
				TableSchema.TableColumn colvarNotes = new TableSchema.TableColumn(schema);
				colvarNotes.ColumnName = "Notes";
				colvarNotes.DataType = DbType.String;
				colvarNotes.MaxLength = 500;
				colvarNotes.AutoIncrement = false;
				colvarNotes.IsNullable = true;
				colvarNotes.IsPrimaryKey = false;
				colvarNotes.IsForeignKey = false;
				colvarNotes.IsReadOnly = false;
				
						colvarNotes.DefaultSetting = @"((0))";
				colvarNotes.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNotes);
				
				TableSchema.TableColumn colvarCreatedBy = new TableSchema.TableColumn(schema);
				colvarCreatedBy.ColumnName = "CreatedBy";
				colvarCreatedBy.DataType = DbType.String;
				colvarCreatedBy.MaxLength = 50;
				colvarCreatedBy.AutoIncrement = false;
				colvarCreatedBy.IsNullable = true;
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
				colvarCreatedOn.IsNullable = true;
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
				colvarModifiedBy.IsNullable = true;
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
				colvarModifiOn.IsNullable = true;
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
				colvarIsDeleted.IsNullable = true;
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
				colvarIsActive.IsNullable = true;
				colvarIsActive.IsPrimaryKey = false;
				colvarIsActive.IsForeignKey = false;
				colvarIsActive.IsReadOnly = false;
				
						colvarIsActive.DefaultSetting = @"((1))";
				colvarIsActive.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsActive);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VietNamNet_Surveys"].AddSchema("SurveyResults",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SurveyResultId")]
		[Bindable(true)]
		public int SurveyResultId 
		{
			get { return GetColumnValue<int>(Columns.SurveyResultId); }
			set { SetColumnValue(Columns.SurveyResultId, value); }
		}
		  
		[XmlAttribute("SurveyOptionId")]
		[Bindable(true)]
		public int SurveyOptionId 
		{
			get { return GetColumnValue<int>(Columns.SurveyOptionId); }
			set { SetColumnValue(Columns.SurveyOptionId, value); }
		}
		  
		[XmlAttribute("Notes")]
		[Bindable(true)]
		public string Notes 
		{
			get { return GetColumnValue<string>(Columns.Notes); }
			set { SetColumnValue(Columns.Notes, value); }
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
		public DateTime? CreatedOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.CreatedOn); }
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
		public DateTime? ModifiOn 
		{
			get { return GetColumnValue<DateTime?>(Columns.ModifiOn); }
			set { SetColumnValue(Columns.ModifiOn, value); }
		}
		  
		[XmlAttribute("IsDeleted")]
		[Bindable(true)]
		public bool? IsDeleted 
		{
			get { return GetColumnValue<bool?>(Columns.IsDeleted); }
			set { SetColumnValue(Columns.IsDeleted, value); }
		}
		  
		[XmlAttribute("IsActive")]
		[Bindable(true)]
		public bool? IsActive 
		{
			get { return GetColumnValue<bool?>(Columns.IsActive); }
			set { SetColumnValue(Columns.IsActive, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SurveyOption ActiveRecord object related to this SurveyResult
		/// 
		/// </summary>
		public VietNamNet.AddOn.SurveyModule.DAL.SurveyOption SurveyOption
		{
			get { return VietNamNet.AddOn.SurveyModule.DAL.SurveyOption.FetchByID(this.SurveyOptionId); }
			set { SetColumnValue("SurveyOptionId", value.SurveyOptionId); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSurveyOptionId,string varNotes,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiOn,bool? varIsDeleted,bool? varIsActive)
		{
			SurveyResult item = new SurveyResult();
			
			item.SurveyOptionId = varSurveyOptionId;
			
			item.Notes = varNotes;
			
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
		public static void Update(int varSurveyResultId,int varSurveyOptionId,string varNotes,string varCreatedBy,DateTime? varCreatedOn,string varModifiedBy,DateTime? varModifiOn,bool? varIsDeleted,bool? varIsActive)
		{
			SurveyResult item = new SurveyResult();
			
				item.SurveyResultId = varSurveyResultId;
			
				item.SurveyOptionId = varSurveyOptionId;
			
				item.Notes = varNotes;
			
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
        
        
        public static TableSchema.TableColumn SurveyResultIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SurveyOptionIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NotesColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiOnColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDeletedColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SurveyResultId = @"SurveyResultId";
			 public static string SurveyOptionId = @"SurveyOptionId";
			 public static string Notes = @"Notes";
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
