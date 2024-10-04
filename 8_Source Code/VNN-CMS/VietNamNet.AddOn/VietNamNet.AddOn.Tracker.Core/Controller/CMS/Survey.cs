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
	/// Strongly-typed collection for the Survey class.
	/// </summary>
    [Serializable]
	public partial class SurveyCollection : ActiveList<Survey, SurveyCollection>
	{	   
		public SurveyCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SurveyCollection</returns>
		public SurveyCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Survey o = this[i];
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
	/// This is an ActiveRecord class which wraps the Surveys table.
	/// </summary>
	[Serializable]
	public partial class Survey : ActiveRecord<Survey>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Survey()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Survey(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Survey(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Survey(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Surveys", TableType.Table, DataService.GetInstance("VNN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSurveyId = new TableSchema.TableColumn(schema);
				colvarSurveyId.ColumnName = "SurveyId";
				colvarSurveyId.DataType = DbType.Int32;
				colvarSurveyId.MaxLength = 0;
				colvarSurveyId.AutoIncrement = false;
				colvarSurveyId.IsNullable = false;
				colvarSurveyId.IsPrimaryKey = true;
				colvarSurveyId.IsForeignKey = false;
				colvarSurveyId.IsReadOnly = false;
				colvarSurveyId.DefaultSetting = @"";
				colvarSurveyId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSurveyId);
				
				TableSchema.TableColumn colvarQuestion = new TableSchema.TableColumn(schema);
				colvarQuestion.ColumnName = "Question";
				colvarQuestion.DataType = DbType.String;
				colvarQuestion.MaxLength = 500;
				colvarQuestion.AutoIncrement = false;
				colvarQuestion.IsNullable = false;
				colvarQuestion.IsPrimaryKey = false;
				colvarQuestion.IsForeignKey = false;
				colvarQuestion.IsReadOnly = false;
				colvarQuestion.DefaultSetting = @"";
				colvarQuestion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuestion);
				
				TableSchema.TableColumn colvarTags = new TableSchema.TableColumn(schema);
				colvarTags.ColumnName = "Tags";
				colvarTags.DataType = DbType.String;
				colvarTags.MaxLength = 500;
				colvarTags.AutoIncrement = false;
				colvarTags.IsNullable = true;
				colvarTags.IsPrimaryKey = false;
				colvarTags.IsForeignKey = false;
				colvarTags.IsReadOnly = false;
				colvarTags.DefaultSetting = @"";
				colvarTags.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTags);
				
				TableSchema.TableColumn colvarOptionType = new TableSchema.TableColumn(schema);
				colvarOptionType.ColumnName = "OptionType";
				colvarOptionType.DataType = DbType.AnsiStringFixedLength;
				colvarOptionType.MaxLength = 1;
				colvarOptionType.AutoIncrement = false;
				colvarOptionType.IsNullable = false;
				colvarOptionType.IsPrimaryKey = false;
				colvarOptionType.IsForeignKey = false;
				colvarOptionType.IsReadOnly = false;
				colvarOptionType.DefaultSetting = @"";
				colvarOptionType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOptionType);
				
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
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.Byte;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = true;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				colvarStatus.DefaultSetting = @"";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["VNN"].AddSchema("Surveys",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SurveyId")]
		[Bindable(true)]
		public int SurveyId 
		{
			get { return GetColumnValue<int>(Columns.SurveyId); }
			set { SetColumnValue(Columns.SurveyId, value); }
		}
		  
		[XmlAttribute("Question")]
		[Bindable(true)]
		public string Question 
		{
			get { return GetColumnValue<string>(Columns.Question); }
			set { SetColumnValue(Columns.Question, value); }
		}
		  
		[XmlAttribute("Tags")]
		[Bindable(true)]
		public string Tags 
		{
			get { return GetColumnValue<string>(Columns.Tags); }
			set { SetColumnValue(Columns.Tags, value); }
		}
		  
		[XmlAttribute("OptionType")]
		[Bindable(true)]
		public string OptionType 
		{
			get { return GetColumnValue<string>(Columns.OptionType); }
			set { SetColumnValue(Columns.OptionType, value); }
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
		public byte? Status 
		{
			get { return GetColumnValue<byte?>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSurveyId,string varQuestion,string varTags,string varOptionType,string varNotes,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiOn,bool varIsDeleted,bool varIsActive,byte? varStatus)
		{
			Survey item = new Survey();
			
			item.SurveyId = varSurveyId;
			
			item.Question = varQuestion;
			
			item.Tags = varTags;
			
			item.OptionType = varOptionType;
			
			item.Notes = varNotes;
			
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
		public static void Update(int varSurveyId,string varQuestion,string varTags,string varOptionType,string varNotes,string varCreatedBy,DateTime varCreatedOn,string varModifiedBy,DateTime varModifiOn,bool varIsDeleted,bool varIsActive,byte? varStatus)
		{
			Survey item = new Survey();
			
				item.SurveyId = varSurveyId;
			
				item.Question = varQuestion;
			
				item.Tags = varTags;
			
				item.OptionType = varOptionType;
			
				item.Notes = varNotes;
			
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
        
        
        public static TableSchema.TableColumn SurveyIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn QuestionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TagsColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn OptionTypeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NotesColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiOnColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn IsDeletedColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn IsActiveColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SurveyId = @"SurveyId";
			 public static string Question = @"Question";
			 public static string Tags = @"Tags";
			 public static string OptionType = @"OptionType";
			 public static string Notes = @"Notes";
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
