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
	/// Strongly-typed collection for the RoyaltyFund class.
	/// </summary>
    [Serializable]
	public partial class RoyaltyFundCollection : ActiveList<RoyaltyFund, RoyaltyFundCollection>
	{	   
		public RoyaltyFundCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>RoyaltyFundCollection</returns>
		public RoyaltyFundCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                RoyaltyFund o = this[i];
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
	/// This is an ActiveRecord class which wraps the RoyaltyFund table.
	/// </summary>
	[Serializable]
	public partial class RoyaltyFund : ActiveRecord<RoyaltyFund>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public RoyaltyFund()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public RoyaltyFund(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public RoyaltyFund(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public RoyaltyFund(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("RoyaltyFund", TableType.Table, DataService.GetInstance("VNN"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarFundId = new TableSchema.TableColumn(schema);
				colvarFundId.ColumnName = "Fund_Id";
				colvarFundId.DataType = DbType.Int32;
				colvarFundId.MaxLength = 0;
				colvarFundId.AutoIncrement = true;
				colvarFundId.IsNullable = false;
				colvarFundId.IsPrimaryKey = true;
				colvarFundId.IsForeignKey = false;
				colvarFundId.IsReadOnly = false;
				colvarFundId.DefaultSetting = @"";
				colvarFundId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFundId);
				
				TableSchema.TableColumn colvarArticleId = new TableSchema.TableColumn(schema);
				colvarArticleId.ColumnName = "Article_Id";
				colvarArticleId.DataType = DbType.Int32;
				colvarArticleId.MaxLength = 0;
				colvarArticleId.AutoIncrement = false;
				colvarArticleId.IsNullable = false;
				colvarArticleId.IsPrimaryKey = false;
				colvarArticleId.IsForeignKey = false;
				colvarArticleId.IsReadOnly = false;
				colvarArticleId.DefaultSetting = @"";
				colvarArticleId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArticleId);
				
				TableSchema.TableColumn colvarTextFund = new TableSchema.TableColumn(schema);
				colvarTextFund.ColumnName = "Text_Fund";
				colvarTextFund.DataType = DbType.Int32;
				colvarTextFund.MaxLength = 0;
				colvarTextFund.AutoIncrement = false;
				colvarTextFund.IsNullable = true;
				colvarTextFund.IsPrimaryKey = false;
				colvarTextFund.IsForeignKey = false;
				colvarTextFund.IsReadOnly = false;
				colvarTextFund.DefaultSetting = @"";
				colvarTextFund.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTextFund);
				
				TableSchema.TableColumn colvarImageFund = new TableSchema.TableColumn(schema);
				colvarImageFund.ColumnName = "Image_Fund";
				colvarImageFund.DataType = DbType.Int32;
				colvarImageFund.MaxLength = 0;
				colvarImageFund.AutoIncrement = false;
				colvarImageFund.IsNullable = true;
				colvarImageFund.IsPrimaryKey = false;
				colvarImageFund.IsForeignKey = false;
				colvarImageFund.IsReadOnly = false;
				colvarImageFund.DefaultSetting = @"";
				colvarImageFund.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageFund);
				
				TableSchema.TableColumn colvarAudioFund = new TableSchema.TableColumn(schema);
				colvarAudioFund.ColumnName = "Audio_Fund";
				colvarAudioFund.DataType = DbType.Int32;
				colvarAudioFund.MaxLength = 0;
				colvarAudioFund.AutoIncrement = false;
				colvarAudioFund.IsNullable = true;
				colvarAudioFund.IsPrimaryKey = false;
				colvarAudioFund.IsForeignKey = false;
				colvarAudioFund.IsReadOnly = false;
				colvarAudioFund.DefaultSetting = @"";
				colvarAudioFund.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAudioFund);
				
				TableSchema.TableColumn colvarVideoFund = new TableSchema.TableColumn(schema);
				colvarVideoFund.ColumnName = "Video_Fund";
				colvarVideoFund.DataType = DbType.Int32;
				colvarVideoFund.MaxLength = 0;
				colvarVideoFund.AutoIncrement = false;
				colvarVideoFund.IsNullable = true;
				colvarVideoFund.IsPrimaryKey = false;
				colvarVideoFund.IsForeignKey = false;
				colvarVideoFund.IsReadOnly = false;
				colvarVideoFund.DefaultSetting = @"";
				colvarVideoFund.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVideoFund);
				
				TableSchema.TableColumn colvarOtherFund = new TableSchema.TableColumn(schema);
				colvarOtherFund.ColumnName = "Other_Fund";
				colvarOtherFund.DataType = DbType.Int32;
				colvarOtherFund.MaxLength = 0;
				colvarOtherFund.AutoIncrement = false;
				colvarOtherFund.IsNullable = true;
				colvarOtherFund.IsPrimaryKey = false;
				colvarOtherFund.IsForeignKey = false;
				colvarOtherFund.IsReadOnly = false;
				colvarOtherFund.DefaultSetting = @"";
				colvarOtherFund.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOtherFund);
				
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
				
				TableSchema.TableColumn colvarAuthorId = new TableSchema.TableColumn(schema);
				colvarAuthorId.ColumnName = "Author_Id";
				colvarAuthorId.DataType = DbType.Int32;
				colvarAuthorId.MaxLength = 0;
				colvarAuthorId.AutoIncrement = false;
				colvarAuthorId.IsNullable = true;
				colvarAuthorId.IsPrimaryKey = false;
				colvarAuthorId.IsForeignKey = false;
				colvarAuthorId.IsReadOnly = false;
				colvarAuthorId.DefaultSetting = @"";
				colvarAuthorId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuthorId);
				
				TableSchema.TableColumn colvarAuthorIsMember = new TableSchema.TableColumn(schema);
				colvarAuthorIsMember.ColumnName = "Author_IsMember";
				colvarAuthorIsMember.DataType = DbType.Int32;
				colvarAuthorIsMember.MaxLength = 0;
				colvarAuthorIsMember.AutoIncrement = false;
				colvarAuthorIsMember.IsNullable = true;
				colvarAuthorIsMember.IsPrimaryKey = false;
				colvarAuthorIsMember.IsForeignKey = false;
				colvarAuthorIsMember.IsReadOnly = false;
				colvarAuthorIsMember.DefaultSetting = @"";
				colvarAuthorIsMember.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuthorIsMember);
				
				TableSchema.TableColumn colvarSetterId = new TableSchema.TableColumn(schema);
				colvarSetterId.ColumnName = "Setter_Id";
				colvarSetterId.DataType = DbType.Int32;
				colvarSetterId.MaxLength = 0;
				colvarSetterId.AutoIncrement = false;
				colvarSetterId.IsNullable = true;
				colvarSetterId.IsPrimaryKey = false;
				colvarSetterId.IsForeignKey = false;
				colvarSetterId.IsReadOnly = false;
				colvarSetterId.DefaultSetting = @"";
				colvarSetterId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSetterId);
				
				TableSchema.TableColumn colvarTypeId = new TableSchema.TableColumn(schema);
				colvarTypeId.ColumnName = "Type_Id";
				colvarTypeId.DataType = DbType.Int32;
				colvarTypeId.MaxLength = 0;
				colvarTypeId.AutoIncrement = false;
				colvarTypeId.IsNullable = true;
				colvarTypeId.IsPrimaryKey = false;
				colvarTypeId.IsForeignKey = false;
				colvarTypeId.IsReadOnly = false;
				colvarTypeId.DefaultSetting = @"";
				colvarTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTypeId);
				
				TableSchema.TableColumn colvarSetType = new TableSchema.TableColumn(schema);
				colvarSetType.ColumnName = "Set_Type";
				colvarSetType.DataType = DbType.String;
				colvarSetType.MaxLength = 500;
				colvarSetType.AutoIncrement = false;
				colvarSetType.IsNullable = true;
				colvarSetType.IsPrimaryKey = false;
				colvarSetType.IsForeignKey = false;
				colvarSetType.IsReadOnly = false;
				colvarSetType.DefaultSetting = @"";
				colvarSetType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSetType);
				
				TableSchema.TableColumn colvarPayDate = new TableSchema.TableColumn(schema);
				colvarPayDate.ColumnName = "Pay_Date";
				colvarPayDate.DataType = DbType.DateTime;
				colvarPayDate.MaxLength = 0;
				colvarPayDate.AutoIncrement = false;
				colvarPayDate.IsNullable = true;
				colvarPayDate.IsPrimaryKey = false;
				colvarPayDate.IsForeignKey = false;
				colvarPayDate.IsReadOnly = false;
				colvarPayDate.DefaultSetting = @"";
				colvarPayDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPayDate);
				
				TableSchema.TableColumn colvarPayStatus = new TableSchema.TableColumn(schema);
				colvarPayStatus.ColumnName = "Pay_Status";
				colvarPayStatus.DataType = DbType.Int32;
				colvarPayStatus.MaxLength = 0;
				colvarPayStatus.AutoIncrement = false;
				colvarPayStatus.IsNullable = false;
				colvarPayStatus.IsPrimaryKey = false;
				colvarPayStatus.IsForeignKey = false;
				colvarPayStatus.IsReadOnly = false;
				
						colvarPayStatus.DefaultSetting = @"((0))";
				colvarPayStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPayStatus);
				
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
				DataService.Providers["VNN"].AddSchema("RoyaltyFund",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("FundId")]
		[Bindable(true)]
		public int FundId 
		{
			get { return GetColumnValue<int>(Columns.FundId); }
			set { SetColumnValue(Columns.FundId, value); }
		}
		  
		[XmlAttribute("ArticleId")]
		[Bindable(true)]
		public int ArticleId 
		{
			get { return GetColumnValue<int>(Columns.ArticleId); }
			set { SetColumnValue(Columns.ArticleId, value); }
		}
		  
		[XmlAttribute("TextFund")]
		[Bindable(true)]
		public int? TextFund 
		{
			get { return GetColumnValue<int?>(Columns.TextFund); }
			set { SetColumnValue(Columns.TextFund, value); }
		}
		  
		[XmlAttribute("ImageFund")]
		[Bindable(true)]
		public int? ImageFund 
		{
			get { return GetColumnValue<int?>(Columns.ImageFund); }
			set { SetColumnValue(Columns.ImageFund, value); }
		}
		  
		[XmlAttribute("AudioFund")]
		[Bindable(true)]
		public int? AudioFund 
		{
			get { return GetColumnValue<int?>(Columns.AudioFund); }
			set { SetColumnValue(Columns.AudioFund, value); }
		}
		  
		[XmlAttribute("VideoFund")]
		[Bindable(true)]
		public int? VideoFund 
		{
			get { return GetColumnValue<int?>(Columns.VideoFund); }
			set { SetColumnValue(Columns.VideoFund, value); }
		}
		  
		[XmlAttribute("OtherFund")]
		[Bindable(true)]
		public int? OtherFund 
		{
			get { return GetColumnValue<int?>(Columns.OtherFund); }
			set { SetColumnValue(Columns.OtherFund, value); }
		}
		  
		[XmlAttribute("Notes")]
		[Bindable(true)]
		public string Notes 
		{
			get { return GetColumnValue<string>(Columns.Notes); }
			set { SetColumnValue(Columns.Notes, value); }
		}
		  
		[XmlAttribute("AuthorId")]
		[Bindable(true)]
		public int? AuthorId 
		{
			get { return GetColumnValue<int?>(Columns.AuthorId); }
			set { SetColumnValue(Columns.AuthorId, value); }
		}
		  
		[XmlAttribute("AuthorIsMember")]
		[Bindable(true)]
		public int? AuthorIsMember 
		{
			get { return GetColumnValue<int?>(Columns.AuthorIsMember); }
			set { SetColumnValue(Columns.AuthorIsMember, value); }
		}
		  
		[XmlAttribute("SetterId")]
		[Bindable(true)]
		public int? SetterId 
		{
			get { return GetColumnValue<int?>(Columns.SetterId); }
			set { SetColumnValue(Columns.SetterId, value); }
		}
		  
		[XmlAttribute("TypeId")]
		[Bindable(true)]
		public int? TypeId 
		{
			get { return GetColumnValue<int?>(Columns.TypeId); }
			set { SetColumnValue(Columns.TypeId, value); }
		}
		  
		[XmlAttribute("SetType")]
		[Bindable(true)]
		public string SetType 
		{
			get { return GetColumnValue<string>(Columns.SetType); }
			set { SetColumnValue(Columns.SetType, value); }
		}
		  
		[XmlAttribute("PayDate")]
		[Bindable(true)]
		public DateTime? PayDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.PayDate); }
			set { SetColumnValue(Columns.PayDate, value); }
		}
		  
		[XmlAttribute("PayStatus")]
		[Bindable(true)]
		public int PayStatus 
		{
			get { return GetColumnValue<int>(Columns.PayStatus); }
			set { SetColumnValue(Columns.PayStatus, value); }
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
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varArticleId,int? varTextFund,int? varImageFund,int? varAudioFund,int? varVideoFund,int? varOtherFund,string varNotes,int? varAuthorId,int? varAuthorIsMember,int? varSetterId,int? varTypeId,string varSetType,DateTime? varPayDate,int varPayStatus,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			RoyaltyFund item = new RoyaltyFund();
			
			item.ArticleId = varArticleId;
			
			item.TextFund = varTextFund;
			
			item.ImageFund = varImageFund;
			
			item.AudioFund = varAudioFund;
			
			item.VideoFund = varVideoFund;
			
			item.OtherFund = varOtherFund;
			
			item.Notes = varNotes;
			
			item.AuthorId = varAuthorId;
			
			item.AuthorIsMember = varAuthorIsMember;
			
			item.SetterId = varSetterId;
			
			item.TypeId = varTypeId;
			
			item.SetType = varSetType;
			
			item.PayDate = varPayDate;
			
			item.PayStatus = varPayStatus;
			
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
		public static void Update(int varFundId,int varArticleId,int? varTextFund,int? varImageFund,int? varAudioFund,int? varVideoFund,int? varOtherFund,string varNotes,int? varAuthorId,int? varAuthorIsMember,int? varSetterId,int? varTypeId,string varSetType,DateTime? varPayDate,int varPayStatus,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			RoyaltyFund item = new RoyaltyFund();
			
				item.FundId = varFundId;
			
				item.ArticleId = varArticleId;
			
				item.TextFund = varTextFund;
			
				item.ImageFund = varImageFund;
			
				item.AudioFund = varAudioFund;
			
				item.VideoFund = varVideoFund;
			
				item.OtherFund = varOtherFund;
			
				item.Notes = varNotes;
			
				item.AuthorId = varAuthorId;
			
				item.AuthorIsMember = varAuthorIsMember;
			
				item.SetterId = varSetterId;
			
				item.TypeId = varTypeId;
			
				item.SetType = varSetType;
			
				item.PayDate = varPayDate;
			
				item.PayStatus = varPayStatus;
			
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
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn FundIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TextFundColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageFundColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AudioFundColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn VideoFundColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn OtherFundColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn NotesColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn AuthorIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AuthorIsMemberColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SetterIdColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeIdColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn SetTypeColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn PayDateColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn PayStatusColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string FundId = @"Fund_Id";
			 public static string ArticleId = @"Article_Id";
			 public static string TextFund = @"Text_Fund";
			 public static string ImageFund = @"Image_Fund";
			 public static string AudioFund = @"Audio_Fund";
			 public static string VideoFund = @"Video_Fund";
			 public static string OtherFund = @"Other_Fund";
			 public static string Notes = @"Notes";
			 public static string AuthorId = @"Author_Id";
			 public static string AuthorIsMember = @"Author_IsMember";
			 public static string SetterId = @"Setter_Id";
			 public static string TypeId = @"Type_Id";
			 public static string SetType = @"Set_Type";
			 public static string PayDate = @"Pay_Date";
			 public static string PayStatus = @"Pay_Status";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
