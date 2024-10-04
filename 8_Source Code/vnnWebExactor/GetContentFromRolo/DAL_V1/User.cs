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
	/// Strongly-typed collection for the User class.
	/// </summary>
    [Serializable]
	public partial class UserCollection : ActiveList<User, UserCollection>
	{	   
		public UserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UserCollection</returns>
		public UserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                User o = this[i];
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
	/// This is an ActiveRecord class which wraps the User table.
	/// </summary>
	[Serializable]
	public partial class User : ActiveRecord<User>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public User()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public User(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public User(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public User(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("User", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.String;
				colvarStatus.MaxLength = 255;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"(N'Hoạt động')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				TableSchema.TableColumn colvarLoginName = new TableSchema.TableColumn(schema);
				colvarLoginName.ColumnName = "LoginName";
				colvarLoginName.DataType = DbType.String;
				colvarLoginName.MaxLength = 255;
				colvarLoginName.AutoIncrement = false;
				colvarLoginName.IsNullable = false;
				colvarLoginName.IsPrimaryKey = false;
				colvarLoginName.IsForeignKey = false;
				colvarLoginName.IsReadOnly = false;
				colvarLoginName.DefaultSetting = @"";
				colvarLoginName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoginName);
				
				TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
				colvarEmail.ColumnName = "Email";
				colvarEmail.DataType = DbType.String;
				colvarEmail.MaxLength = 255;
				colvarEmail.AutoIncrement = false;
				colvarEmail.IsNullable = false;
				colvarEmail.IsPrimaryKey = false;
				colvarEmail.IsForeignKey = false;
				colvarEmail.IsReadOnly = false;
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarAvatar = new TableSchema.TableColumn(schema);
				colvarAvatar.ColumnName = "Avatar";
				colvarAvatar.DataType = DbType.String;
				colvarAvatar.MaxLength = 255;
				colvarAvatar.AutoIncrement = false;
				colvarAvatar.IsNullable = true;
				colvarAvatar.IsPrimaryKey = false;
				colvarAvatar.IsForeignKey = false;
				colvarAvatar.IsReadOnly = false;
				colvarAvatar.DefaultSetting = @"";
				colvarAvatar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAvatar);
				
				TableSchema.TableColumn colvarBirthday = new TableSchema.TableColumn(schema);
				colvarBirthday.ColumnName = "Birthday";
				colvarBirthday.DataType = DbType.DateTime;
				colvarBirthday.MaxLength = 0;
				colvarBirthday.AutoIncrement = false;
				colvarBirthday.IsNullable = true;
				colvarBirthday.IsPrimaryKey = false;
				colvarBirthday.IsForeignKey = false;
				colvarBirthday.IsReadOnly = false;
				colvarBirthday.DefaultSetting = @"";
				colvarBirthday.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBirthday);
				
				TableSchema.TableColumn colvarSex = new TableSchema.TableColumn(schema);
				colvarSex.ColumnName = "Sex";
				colvarSex.DataType = DbType.String;
				colvarSex.MaxLength = 50;
				colvarSex.AutoIncrement = false;
				colvarSex.IsNullable = false;
				colvarSex.IsPrimaryKey = false;
				colvarSex.IsForeignKey = false;
				colvarSex.IsReadOnly = false;
				
						colvarSex.DefaultSetting = @"(N'Nam')";
				colvarSex.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSex);
				
				TableSchema.TableColumn colvarFullName = new TableSchema.TableColumn(schema);
				colvarFullName.ColumnName = "FullName";
				colvarFullName.DataType = DbType.String;
				colvarFullName.MaxLength = 255;
				colvarFullName.AutoIncrement = false;
				colvarFullName.IsNullable = false;
				colvarFullName.IsPrimaryKey = false;
				colvarFullName.IsForeignKey = false;
				colvarFullName.IsReadOnly = false;
				colvarFullName.DefaultSetting = @"";
				colvarFullName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFullName);
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "Password";
				colvarPassword.DataType = DbType.String;
				colvarPassword.MaxLength = 255;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = false;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				
						colvarPassword.DefaultSetting = @"(N'AnhDT')";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "Address";
				colvarAddress.DataType = DbType.String;
				colvarAddress.MaxLength = 255;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = false;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
				colvarPhone.ColumnName = "Phone";
				colvarPhone.DataType = DbType.String;
				colvarPhone.MaxLength = 255;
				colvarPhone.AutoIncrement = false;
				colvarPhone.IsNullable = false;
				colvarPhone.IsPrimaryKey = false;
				colvarPhone.IsForeignKey = false;
				colvarPhone.IsReadOnly = false;
				colvarPhone.DefaultSetting = @"";
				colvarPhone.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhone);
				
				TableSchema.TableColumn colvarMobile = new TableSchema.TableColumn(schema);
				colvarMobile.ColumnName = "Mobile";
				colvarMobile.DataType = DbType.String;
				colvarMobile.MaxLength = 255;
				colvarMobile.AutoIncrement = false;
				colvarMobile.IsNullable = false;
				colvarMobile.IsPrimaryKey = false;
				colvarMobile.IsForeignKey = false;
				colvarMobile.IsReadOnly = false;
				colvarMobile.DefaultSetting = @"";
				colvarMobile.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMobile);
				
				TableSchema.TableColumn colvarYahoo = new TableSchema.TableColumn(schema);
				colvarYahoo.ColumnName = "Yahoo";
				colvarYahoo.DataType = DbType.String;
				colvarYahoo.MaxLength = 255;
				colvarYahoo.AutoIncrement = false;
				colvarYahoo.IsNullable = false;
				colvarYahoo.IsPrimaryKey = false;
				colvarYahoo.IsForeignKey = false;
				colvarYahoo.IsReadOnly = false;
				
						colvarYahoo.DefaultSetting = @"('')";
				colvarYahoo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarYahoo);
				
				TableSchema.TableColumn colvarSkype = new TableSchema.TableColumn(schema);
				colvarSkype.ColumnName = "Skype";
				colvarSkype.DataType = DbType.String;
				colvarSkype.MaxLength = 255;
				colvarSkype.AutoIncrement = false;
				colvarSkype.IsNullable = false;
				colvarSkype.IsPrimaryKey = false;
				colvarSkype.IsForeignKey = false;
				colvarSkype.IsReadOnly = false;
				
						colvarSkype.DefaultSetting = @"('')";
				colvarSkype.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSkype);
				
				TableSchema.TableColumn colvarFacebook = new TableSchema.TableColumn(schema);
				colvarFacebook.ColumnName = "Facebook";
				colvarFacebook.DataType = DbType.String;
				colvarFacebook.MaxLength = 255;
				colvarFacebook.AutoIncrement = false;
				colvarFacebook.IsNullable = false;
				colvarFacebook.IsPrimaryKey = false;
				colvarFacebook.IsForeignKey = false;
				colvarFacebook.IsReadOnly = false;
				
						colvarFacebook.DefaultSetting = @"('')";
				colvarFacebook.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFacebook);
				
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
				
				TableSchema.TableColumn colvarSkin = new TableSchema.TableColumn(schema);
				colvarSkin.ColumnName = "Skin";
				colvarSkin.DataType = DbType.String;
				colvarSkin.MaxLength = 255;
				colvarSkin.AutoIncrement = false;
				colvarSkin.IsNullable = false;
				colvarSkin.IsPrimaryKey = false;
				colvarSkin.IsForeignKey = false;
				colvarSkin.IsReadOnly = false;
				
						colvarSkin.DefaultSetting = @"(N'Office2007')";
				colvarSkin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSkin);
				
				TableSchema.TableColumn colvarLastLogin = new TableSchema.TableColumn(schema);
				colvarLastLogin.ColumnName = "LastLogin";
				colvarLastLogin.DataType = DbType.DateTime;
				colvarLastLogin.MaxLength = 0;
				colvarLastLogin.AutoIncrement = false;
				colvarLastLogin.IsNullable = true;
				colvarLastLogin.IsPrimaryKey = false;
				colvarLastLogin.IsForeignKey = false;
				colvarLastLogin.IsReadOnly = false;
				
						colvarLastLogin.DefaultSetting = @"(getdate())";
				colvarLastLogin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastLogin);
				
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
				DataService.Providers["VCMS"].AddSchema("User",schema);
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
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("LoginName")]
		[Bindable(true)]
		public string LoginName 
		{
			get { return GetColumnValue<string>(Columns.LoginName); }
			set { SetColumnValue(Columns.LoginName, value); }
		}
		  
		[XmlAttribute("Email")]
		[Bindable(true)]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }
			set { SetColumnValue(Columns.Email, value); }
		}
		  
		[XmlAttribute("Avatar")]
		[Bindable(true)]
		public string Avatar 
		{
			get { return GetColumnValue<string>(Columns.Avatar); }
			set { SetColumnValue(Columns.Avatar, value); }
		}
		  
		[XmlAttribute("Birthday")]
		[Bindable(true)]
		public DateTime? Birthday 
		{
			get { return GetColumnValue<DateTime?>(Columns.Birthday); }
			set { SetColumnValue(Columns.Birthday, value); }
		}
		  
		[XmlAttribute("Sex")]
		[Bindable(true)]
		public string Sex 
		{
			get { return GetColumnValue<string>(Columns.Sex); }
			set { SetColumnValue(Columns.Sex, value); }
		}
		  
		[XmlAttribute("FullName")]
		[Bindable(true)]
		public string FullName 
		{
			get { return GetColumnValue<string>(Columns.FullName); }
			set { SetColumnValue(Columns.FullName, value); }
		}
		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }
			set { SetColumnValue(Columns.Password, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		  
		[XmlAttribute("Phone")]
		[Bindable(true)]
		public string Phone 
		{
			get { return GetColumnValue<string>(Columns.Phone); }
			set { SetColumnValue(Columns.Phone, value); }
		}
		  
		[XmlAttribute("Mobile")]
		[Bindable(true)]
		public string Mobile 
		{
			get { return GetColumnValue<string>(Columns.Mobile); }
			set { SetColumnValue(Columns.Mobile, value); }
		}
		  
		[XmlAttribute("Yahoo")]
		[Bindable(true)]
		public string Yahoo 
		{
			get { return GetColumnValue<string>(Columns.Yahoo); }
			set { SetColumnValue(Columns.Yahoo, value); }
		}
		  
		[XmlAttribute("Skype")]
		[Bindable(true)]
		public string Skype 
		{
			get { return GetColumnValue<string>(Columns.Skype); }
			set { SetColumnValue(Columns.Skype, value); }
		}
		  
		[XmlAttribute("Facebook")]
		[Bindable(true)]
		public string Facebook 
		{
			get { return GetColumnValue<string>(Columns.Facebook); }
			set { SetColumnValue(Columns.Facebook, value); }
		}
		  
		[XmlAttribute("Detail")]
		[Bindable(true)]
		public string Detail 
		{
			get { return GetColumnValue<string>(Columns.Detail); }
			set { SetColumnValue(Columns.Detail, value); }
		}
		  
		[XmlAttribute("Skin")]
		[Bindable(true)]
		public string Skin 
		{
			get { return GetColumnValue<string>(Columns.Skin); }
			set { SetColumnValue(Columns.Skin, value); }
		}
		  
		[XmlAttribute("LastLogin")]
		[Bindable(true)]
		public DateTime? LastLogin 
		{
			get { return GetColumnValue<DateTime?>(Columns.LastLogin); }
			set { SetColumnValue(Columns.LastLogin, value); }
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
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public DAL.GroupMemberCollection GroupMemberRecords()
		{
			return new DAL.GroupMemberCollection().Where(GroupMember.Columns.UserId, Id).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varStatus,string varLoginName,string varEmail,string varAvatar,DateTime? varBirthday,string varSex,string varFullName,string varPassword,string varAddress,string varPhone,string varMobile,string varYahoo,string varSkype,string varFacebook,string varDetail,string varSkin,DateTime? varLastLogin,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			User item = new User();
			
			item.Status = varStatus;
			
			item.LoginName = varLoginName;
			
			item.Email = varEmail;
			
			item.Avatar = varAvatar;
			
			item.Birthday = varBirthday;
			
			item.Sex = varSex;
			
			item.FullName = varFullName;
			
			item.Password = varPassword;
			
			item.Address = varAddress;
			
			item.Phone = varPhone;
			
			item.Mobile = varMobile;
			
			item.Yahoo = varYahoo;
			
			item.Skype = varSkype;
			
			item.Facebook = varFacebook;
			
			item.Detail = varDetail;
			
			item.Skin = varSkin;
			
			item.LastLogin = varLastLogin;
			
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
		public static void Update(int varId,string varStatus,string varLoginName,string varEmail,string varAvatar,DateTime? varBirthday,string varSex,string varFullName,string varPassword,string varAddress,string varPhone,string varMobile,string varYahoo,string varSkype,string varFacebook,string varDetail,string varSkin,DateTime? varLastLogin,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			User item = new User();
			
				item.Id = varId;
			
				item.Status = varStatus;
			
				item.LoginName = varLoginName;
			
				item.Email = varEmail;
			
				item.Avatar = varAvatar;
			
				item.Birthday = varBirthday;
			
				item.Sex = varSex;
			
				item.FullName = varFullName;
			
				item.Password = varPassword;
			
				item.Address = varAddress;
			
				item.Phone = varPhone;
			
				item.Mobile = varMobile;
			
				item.Yahoo = varYahoo;
			
				item.Skype = varSkype;
			
				item.Facebook = varFacebook;
			
				item.Detail = varDetail;
			
				item.Skin = varSkin;
			
				item.LastLogin = varLastLogin;
			
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
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn LoginNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AvatarColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn BirthdayColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SexColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn FullNameColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn PhoneColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn MobileColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn YahooColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn SkypeColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn FacebookColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn SkinColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn LastLoginColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Status = @"Status";
			 public static string LoginName = @"LoginName";
			 public static string Email = @"Email";
			 public static string Avatar = @"Avatar";
			 public static string Birthday = @"Birthday";
			 public static string Sex = @"Sex";
			 public static string FullName = @"FullName";
			 public static string Password = @"Password";
			 public static string Address = @"Address";
			 public static string Phone = @"Phone";
			 public static string Mobile = @"Mobile";
			 public static string Yahoo = @"Yahoo";
			 public static string Skype = @"Skype";
			 public static string Facebook = @"Facebook";
			 public static string Detail = @"Detail";
			 public static string Skin = @"Skin";
			 public static string LastLogin = @"LastLogin";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
