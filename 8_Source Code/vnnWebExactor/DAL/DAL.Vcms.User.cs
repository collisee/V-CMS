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

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the User table.
	/// </summary>
	[Serializable]
	public partial class User : ActiveRecord<User>
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
		public int Id 
		{
			get { return GetColumnValue<int>("Id"); }

			set { SetColumnValue("Id", value); }

		}

		  
		[XmlAttribute("Status")]
		public string Status 
		{
			get { return GetColumnValue<string>("Status"); }

			set { SetColumnValue("Status", value); }

		}

		  
		[XmlAttribute("LoginName")]
		public string LoginName 
		{
			get { return GetColumnValue<string>("LoginName"); }

			set { SetColumnValue("LoginName", value); }

		}

		  
		[XmlAttribute("Email")]
		public string Email 
		{
			get { return GetColumnValue<string>("Email"); }

			set { SetColumnValue("Email", value); }

		}

		  
		[XmlAttribute("Birthday")]
		public DateTime? Birthday 
		{
			get { return GetColumnValue<DateTime?>("Birthday"); }

			set { SetColumnValue("Birthday", value); }

		}

		  
		[XmlAttribute("Sex")]
		public string Sex 
		{
			get { return GetColumnValue<string>("Sex"); }

			set { SetColumnValue("Sex", value); }

		}

		  
		[XmlAttribute("FullName")]
		public string FullName 
		{
			get { return GetColumnValue<string>("FullName"); }

			set { SetColumnValue("FullName", value); }

		}

		  
		[XmlAttribute("Password")]
		public string Password 
		{
			get { return GetColumnValue<string>("Password"); }

			set { SetColumnValue("Password", value); }

		}

		  
		[XmlAttribute("Address")]
		public string Address 
		{
			get { return GetColumnValue<string>("Address"); }

			set { SetColumnValue("Address", value); }

		}

		  
		[XmlAttribute("Phone")]
		public string Phone 
		{
			get { return GetColumnValue<string>("Phone"); }

			set { SetColumnValue("Phone", value); }

		}

		  
		[XmlAttribute("Mobile")]
		public string Mobile 
		{
			get { return GetColumnValue<string>("Mobile"); }

			set { SetColumnValue("Mobile", value); }

		}

		  
		[XmlAttribute("LastLogin")]
		public DateTime? LastLogin 
		{
			get { return GetColumnValue<DateTime?>("LastLogin"); }

			set { SetColumnValue("LastLogin", value); }

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
		public static void Insert(string varStatus,string varLoginName,string varEmail,DateTime? varBirthday,string varSex,string varFullName,string varPassword,string varAddress,string varPhone,string varMobile,DateTime? varLastLogin,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			User item = new User();
			
			item.Status = varStatus;
			
			item.LoginName = varLoginName;
			
			item.Email = varEmail;
			
			item.Birthday = varBirthday;
			
			item.Sex = varSex;
			
			item.FullName = varFullName;
			
			item.Password = varPassword;
			
			item.Address = varAddress;
			
			item.Phone = varPhone;
			
			item.Mobile = varMobile;
			
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
		public static void Update(int varId,string varStatus,string varLoginName,string varEmail,DateTime? varBirthday,string varSex,string varFullName,string varPassword,string varAddress,string varPhone,string varMobile,DateTime? varLastLogin,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			User item = new User();
			
				item.Id = varId;
				
				item.Status = varStatus;
				
				item.LoginName = varLoginName;
				
				item.Email = varEmail;
				
				item.Birthday = varBirthday;
				
				item.Sex = varSex;
				
				item.FullName = varFullName;
				
				item.Password = varPassword;
				
				item.Address = varAddress;
				
				item.Phone = varPhone;
				
				item.Mobile = varMobile;
				
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
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string Status = @"Status";
			 public static string LoginName = @"LoginName";
			 public static string Email = @"Email";
			 public static string Birthday = @"Birthday";
			 public static string Sex = @"Sex";
			 public static string FullName = @"FullName";
			 public static string Password = @"Password";
			 public static string Address = @"Address";
			 public static string Phone = @"Phone";
			 public static string Mobile = @"Mobile";
			 public static string LastLogin = @"LastLogin";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}

		#endregion
	}

}


