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
	/// Strongly-typed collection for the ArticleVersion class.
	/// </summary>
	[Serializable]
	public partial class ArticleVersionCollection : ActiveList<ArticleVersion, ArticleVersionCollection> 
	{	   
		public ArticleVersionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ArticleVersion table.
	/// </summary>
	[Serializable]
	public partial class ArticleVersion : ActiveRecord<ArticleVersion>
	{
		#region .ctors and Default Settings
		
		public ArticleVersion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ArticleVersion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ArticleVersion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ArticleVersion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ArticleVersion", TableType.Table, DataService.GetInstance("VCMS"));
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
				
						colvarArticleId.DefaultSetting = @"((0))";
				
					colvarArticleId.ForeignKeyTableName = "Article";
				schema.Columns.Add(colvarArticleId);
				
				TableSchema.TableColumn colvarVersionId = new TableSchema.TableColumn(schema);
				colvarVersionId.ColumnName = "VersionId";
				colvarVersionId.DataType = DbType.Int32;
				colvarVersionId.MaxLength = 0;
				colvarVersionId.AutoIncrement = false;
				colvarVersionId.IsNullable = false;
				colvarVersionId.IsPrimaryKey = false;
				colvarVersionId.IsForeignKey = false;
				colvarVersionId.IsReadOnly = false;
				
						colvarVersionId.DefaultSetting = @"((1))";
				colvarVersionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVersionId);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.String;
				colvarStatus.MaxLength = 255;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"(N'Bản nháp')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				TableSchema.TableColumn colvarArticleTypeId = new TableSchema.TableColumn(schema);
				colvarArticleTypeId.ColumnName = "ArticleTypeId";
				colvarArticleTypeId.DataType = DbType.Int32;
				colvarArticleTypeId.MaxLength = 0;
				colvarArticleTypeId.AutoIncrement = false;
				colvarArticleTypeId.IsNullable = false;
				colvarArticleTypeId.IsPrimaryKey = false;
				colvarArticleTypeId.IsForeignKey = true;
				colvarArticleTypeId.IsReadOnly = false;
				
						colvarArticleTypeId.DefaultSetting = @"((0))";
				
					colvarArticleTypeId.ForeignKeyTableName = "ArticleType";
				schema.Columns.Add(colvarArticleTypeId);
				
				TableSchema.TableColumn colvarArticleContentTypeId = new TableSchema.TableColumn(schema);
				colvarArticleContentTypeId.ColumnName = "ArticleContentTypeId";
				colvarArticleContentTypeId.DataType = DbType.Int32;
				colvarArticleContentTypeId.MaxLength = 0;
				colvarArticleContentTypeId.AutoIncrement = false;
				colvarArticleContentTypeId.IsNullable = false;
				colvarArticleContentTypeId.IsPrimaryKey = false;
				colvarArticleContentTypeId.IsForeignKey = true;
				colvarArticleContentTypeId.IsReadOnly = false;
				
						colvarArticleContentTypeId.DefaultSetting = @"((0))";
				
					colvarArticleContentTypeId.ForeignKeyTableName = "ArticleContentType";
				schema.Columns.Add(colvarArticleContentTypeId);
				
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
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 255;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = true;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarSubTitle1 = new TableSchema.TableColumn(schema);
				colvarSubTitle1.ColumnName = "SubTitle1";
				colvarSubTitle1.DataType = DbType.String;
				colvarSubTitle1.MaxLength = 255;
				colvarSubTitle1.AutoIncrement = false;
				colvarSubTitle1.IsNullable = true;
				colvarSubTitle1.IsPrimaryKey = false;
				colvarSubTitle1.IsForeignKey = false;
				colvarSubTitle1.IsReadOnly = false;
				colvarSubTitle1.DefaultSetting = @"";
				colvarSubTitle1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTitle1);
				
				TableSchema.TableColumn colvarSubTitle2 = new TableSchema.TableColumn(schema);
				colvarSubTitle2.ColumnName = "SubTitle2";
				colvarSubTitle2.DataType = DbType.String;
				colvarSubTitle2.MaxLength = 255;
				colvarSubTitle2.AutoIncrement = false;
				colvarSubTitle2.IsNullable = true;
				colvarSubTitle2.IsPrimaryKey = false;
				colvarSubTitle2.IsForeignKey = false;
				colvarSubTitle2.IsReadOnly = false;
				colvarSubTitle2.DefaultSetting = @"";
				colvarSubTitle2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTitle2);
				
				TableSchema.TableColumn colvarSubTitle3 = new TableSchema.TableColumn(schema);
				colvarSubTitle3.ColumnName = "SubTitle3";
				colvarSubTitle3.DataType = DbType.String;
				colvarSubTitle3.MaxLength = 255;
				colvarSubTitle3.AutoIncrement = false;
				colvarSubTitle3.IsNullable = true;
				colvarSubTitle3.IsPrimaryKey = false;
				colvarSubTitle3.IsForeignKey = false;
				colvarSubTitle3.IsReadOnly = false;
				colvarSubTitle3.DefaultSetting = @"";
				colvarSubTitle3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTitle3);
				
				TableSchema.TableColumn colvarSubTitle4 = new TableSchema.TableColumn(schema);
				colvarSubTitle4.ColumnName = "SubTitle4";
				colvarSubTitle4.DataType = DbType.String;
				colvarSubTitle4.MaxLength = 255;
				colvarSubTitle4.AutoIncrement = false;
				colvarSubTitle4.IsNullable = true;
				colvarSubTitle4.IsPrimaryKey = false;
				colvarSubTitle4.IsForeignKey = false;
				colvarSubTitle4.IsReadOnly = false;
				colvarSubTitle4.DefaultSetting = @"";
				colvarSubTitle4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTitle4);
				
				TableSchema.TableColumn colvarSubTitle5 = new TableSchema.TableColumn(schema);
				colvarSubTitle5.ColumnName = "SubTitle5";
				colvarSubTitle5.DataType = DbType.String;
				colvarSubTitle5.MaxLength = 255;
				colvarSubTitle5.AutoIncrement = false;
				colvarSubTitle5.IsNullable = true;
				colvarSubTitle5.IsPrimaryKey = false;
				colvarSubTitle5.IsForeignKey = false;
				colvarSubTitle5.IsReadOnly = false;
				colvarSubTitle5.DefaultSetting = @"";
				colvarSubTitle5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTitle5);
				
				TableSchema.TableColumn colvarSubTitle6 = new TableSchema.TableColumn(schema);
				colvarSubTitle6.ColumnName = "SubTitle6";
				colvarSubTitle6.DataType = DbType.String;
				colvarSubTitle6.MaxLength = 255;
				colvarSubTitle6.AutoIncrement = false;
				colvarSubTitle6.IsNullable = true;
				colvarSubTitle6.IsPrimaryKey = false;
				colvarSubTitle6.IsForeignKey = false;
				colvarSubTitle6.IsReadOnly = false;
				colvarSubTitle6.DefaultSetting = @"";
				colvarSubTitle6.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTitle6);
				
				TableSchema.TableColumn colvarImageLink = new TableSchema.TableColumn(schema);
				colvarImageLink.ColumnName = "ImageLink";
				colvarImageLink.DataType = DbType.String;
				colvarImageLink.MaxLength = 255;
				colvarImageLink.AutoIncrement = false;
				colvarImageLink.IsNullable = false;
				colvarImageLink.IsPrimaryKey = false;
				colvarImageLink.IsForeignKey = false;
				colvarImageLink.IsReadOnly = false;
				
						colvarImageLink.DefaultSetting = @"('')";
				colvarImageLink.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink);
				
				TableSchema.TableColumn colvarImageLink1 = new TableSchema.TableColumn(schema);
				colvarImageLink1.ColumnName = "ImageLink1";
				colvarImageLink1.DataType = DbType.String;
				colvarImageLink1.MaxLength = 255;
				colvarImageLink1.AutoIncrement = false;
				colvarImageLink1.IsNullable = false;
				colvarImageLink1.IsPrimaryKey = false;
				colvarImageLink1.IsForeignKey = false;
				colvarImageLink1.IsReadOnly = false;
				
						colvarImageLink1.DefaultSetting = @"('')";
				colvarImageLink1.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink1);
				
				TableSchema.TableColumn colvarImageLink2 = new TableSchema.TableColumn(schema);
				colvarImageLink2.ColumnName = "ImageLink2";
				colvarImageLink2.DataType = DbType.String;
				colvarImageLink2.MaxLength = 255;
				colvarImageLink2.AutoIncrement = false;
				colvarImageLink2.IsNullable = false;
				colvarImageLink2.IsPrimaryKey = false;
				colvarImageLink2.IsForeignKey = false;
				colvarImageLink2.IsReadOnly = false;
				
						colvarImageLink2.DefaultSetting = @"('')";
				colvarImageLink2.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink2);
				
				TableSchema.TableColumn colvarImageLink3 = new TableSchema.TableColumn(schema);
				colvarImageLink3.ColumnName = "ImageLink3";
				colvarImageLink3.DataType = DbType.String;
				colvarImageLink3.MaxLength = 255;
				colvarImageLink3.AutoIncrement = false;
				colvarImageLink3.IsNullable = false;
				colvarImageLink3.IsPrimaryKey = false;
				colvarImageLink3.IsForeignKey = false;
				colvarImageLink3.IsReadOnly = false;
				
						colvarImageLink3.DefaultSetting = @"('')";
				colvarImageLink3.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink3);
				
				TableSchema.TableColumn colvarImageLink4 = new TableSchema.TableColumn(schema);
				colvarImageLink4.ColumnName = "ImageLink4";
				colvarImageLink4.DataType = DbType.String;
				colvarImageLink4.MaxLength = 255;
				colvarImageLink4.AutoIncrement = false;
				colvarImageLink4.IsNullable = false;
				colvarImageLink4.IsPrimaryKey = false;
				colvarImageLink4.IsForeignKey = false;
				colvarImageLink4.IsReadOnly = false;
				
						colvarImageLink4.DefaultSetting = @"('')";
				colvarImageLink4.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink4);
				
				TableSchema.TableColumn colvarImageLink5 = new TableSchema.TableColumn(schema);
				colvarImageLink5.ColumnName = "ImageLink5";
				colvarImageLink5.DataType = DbType.String;
				colvarImageLink5.MaxLength = 255;
				colvarImageLink5.AutoIncrement = false;
				colvarImageLink5.IsNullable = false;
				colvarImageLink5.IsPrimaryKey = false;
				colvarImageLink5.IsForeignKey = false;
				colvarImageLink5.IsReadOnly = false;
				
						colvarImageLink5.DefaultSetting = @"('')";
				colvarImageLink5.ForeignKeyTableName = "";
				schema.Columns.Add(colvarImageLink5);
				
				TableSchema.TableColumn colvarLead = new TableSchema.TableColumn(schema);
				colvarLead.ColumnName = "Lead";
				colvarLead.DataType = DbType.String;
				colvarLead.MaxLength = 1073741823;
				colvarLead.AutoIncrement = false;
				colvarLead.IsNullable = false;
				colvarLead.IsPrimaryKey = false;
				colvarLead.IsForeignKey = false;
				colvarLead.IsReadOnly = false;
				colvarLead.DefaultSetting = @"";
				colvarLead.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLead);
				
				TableSchema.TableColumn colvarDetail = new TableSchema.TableColumn(schema);
				colvarDetail.ColumnName = "Detail";
				colvarDetail.DataType = DbType.String;
				colvarDetail.MaxLength = 1073741823;
				colvarDetail.AutoIncrement = false;
				colvarDetail.IsNullable = false;
				colvarDetail.IsPrimaryKey = false;
				colvarDetail.IsForeignKey = false;
				colvarDetail.IsReadOnly = false;
				colvarDetail.DefaultSetting = @"";
				colvarDetail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetail);
				
				TableSchema.TableColumn colvarPublishDate = new TableSchema.TableColumn(schema);
				colvarPublishDate.ColumnName = "PublishDate";
				colvarPublishDate.DataType = DbType.DateTime;
				colvarPublishDate.MaxLength = 0;
				colvarPublishDate.AutoIncrement = false;
				colvarPublishDate.IsNullable = false;
				colvarPublishDate.IsPrimaryKey = false;
				colvarPublishDate.IsForeignKey = false;
				colvarPublishDate.IsReadOnly = false;
				
						colvarPublishDate.DefaultSetting = @"(getdate())";
				colvarPublishDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPublishDate);
				
				TableSchema.TableColumn colvarAuthor = new TableSchema.TableColumn(schema);
				colvarAuthor.ColumnName = "Author";
				colvarAuthor.DataType = DbType.String;
				colvarAuthor.MaxLength = 255;
				colvarAuthor.AutoIncrement = false;
				colvarAuthor.IsNullable = true;
				colvarAuthor.IsPrimaryKey = false;
				colvarAuthor.IsForeignKey = false;
				colvarAuthor.IsReadOnly = false;
				colvarAuthor.DefaultSetting = @"";
				colvarAuthor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuthor);
				
				TableSchema.TableColumn colvarAuthorInfo = new TableSchema.TableColumn(schema);
				colvarAuthorInfo.ColumnName = "AuthorInfo";
				colvarAuthorInfo.DataType = DbType.String;
				colvarAuthorInfo.MaxLength = 4000;
				colvarAuthorInfo.AutoIncrement = false;
				colvarAuthorInfo.IsNullable = true;
				colvarAuthorInfo.IsPrimaryKey = false;
				colvarAuthorInfo.IsForeignKey = false;
				colvarAuthorInfo.IsReadOnly = false;
				colvarAuthorInfo.DefaultSetting = @"";
				colvarAuthorInfo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAuthorInfo);
				
				TableSchema.TableColumn colvarIsMember = new TableSchema.TableColumn(schema);
				colvarIsMember.ColumnName = "IsMember";
				colvarIsMember.DataType = DbType.Int32;
				colvarIsMember.MaxLength = 0;
				colvarIsMember.AutoIncrement = false;
				colvarIsMember.IsNullable = false;
				colvarIsMember.IsPrimaryKey = false;
				colvarIsMember.IsForeignKey = false;
				colvarIsMember.IsReadOnly = false;
				
						colvarIsMember.DefaultSetting = @"((0))";
				colvarIsMember.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsMember);
				
				TableSchema.TableColumn colvarTotalView = new TableSchema.TableColumn(schema);
				colvarTotalView.ColumnName = "TotalView";
				colvarTotalView.DataType = DbType.Int32;
				colvarTotalView.MaxLength = 0;
				colvarTotalView.AutoIncrement = false;
				colvarTotalView.IsNullable = false;
				colvarTotalView.IsPrimaryKey = false;
				colvarTotalView.IsForeignKey = false;
				colvarTotalView.IsReadOnly = false;
				
						colvarTotalView.DefaultSetting = @"((0))";
				colvarTotalView.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalView);
				
				TableSchema.TableColumn colvarHistory = new TableSchema.TableColumn(schema);
				colvarHistory.ColumnName = "History";
				colvarHistory.DataType = DbType.String;
				colvarHistory.MaxLength = 1073741823;
				colvarHistory.AutoIncrement = false;
				colvarHistory.IsNullable = false;
				colvarHistory.IsPrimaryKey = false;
				colvarHistory.IsForeignKey = false;
				colvarHistory.IsReadOnly = false;
				colvarHistory.DefaultSetting = @"";
				colvarHistory.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHistory);
				
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
				DataService.Providers["VCMS"].AddSchema("ArticleVersion",schema);
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

		  
		[XmlAttribute("VersionId")]
		public int VersionId 
		{
			get { return GetColumnValue<int>("VersionId"); }

			set { SetColumnValue("VersionId", value); }

		}

		  
		[XmlAttribute("Status")]
		public string Status 
		{
			get { return GetColumnValue<string>("Status"); }

			set { SetColumnValue("Status", value); }

		}

		  
		[XmlAttribute("ArticleTypeId")]
		public int ArticleTypeId 
		{
			get { return GetColumnValue<int>("ArticleTypeId"); }

			set { SetColumnValue("ArticleTypeId", value); }

		}

		  
		[XmlAttribute("ArticleContentTypeId")]
		public int ArticleContentTypeId 
		{
			get { return GetColumnValue<int>("ArticleContentTypeId"); }

			set { SetColumnValue("ArticleContentTypeId", value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>("Name"); }

			set { SetColumnValue("Name", value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>("Title"); }

			set { SetColumnValue("Title", value); }

		}

		  
		[XmlAttribute("SubTitle1")]
		public string SubTitle1 
		{
			get { return GetColumnValue<string>("SubTitle1"); }

			set { SetColumnValue("SubTitle1", value); }

		}

		  
		[XmlAttribute("SubTitle2")]
		public string SubTitle2 
		{
			get { return GetColumnValue<string>("SubTitle2"); }

			set { SetColumnValue("SubTitle2", value); }

		}

		  
		[XmlAttribute("SubTitle3")]
		public string SubTitle3 
		{
			get { return GetColumnValue<string>("SubTitle3"); }

			set { SetColumnValue("SubTitle3", value); }

		}

		  
		[XmlAttribute("SubTitle4")]
		public string SubTitle4 
		{
			get { return GetColumnValue<string>("SubTitle4"); }

			set { SetColumnValue("SubTitle4", value); }

		}

		  
		[XmlAttribute("SubTitle5")]
		public string SubTitle5 
		{
			get { return GetColumnValue<string>("SubTitle5"); }

			set { SetColumnValue("SubTitle5", value); }

		}

		  
		[XmlAttribute("SubTitle6")]
		public string SubTitle6 
		{
			get { return GetColumnValue<string>("SubTitle6"); }

			set { SetColumnValue("SubTitle6", value); }

		}

		  
		[XmlAttribute("ImageLink")]
		public string ImageLink 
		{
			get { return GetColumnValue<string>("ImageLink"); }

			set { SetColumnValue("ImageLink", value); }

		}

		  
		[XmlAttribute("ImageLink1")]
		public string ImageLink1 
		{
			get { return GetColumnValue<string>("ImageLink1"); }

			set { SetColumnValue("ImageLink1", value); }

		}

		  
		[XmlAttribute("ImageLink2")]
		public string ImageLink2 
		{
			get { return GetColumnValue<string>("ImageLink2"); }

			set { SetColumnValue("ImageLink2", value); }

		}

		  
		[XmlAttribute("ImageLink3")]
		public string ImageLink3 
		{
			get { return GetColumnValue<string>("ImageLink3"); }

			set { SetColumnValue("ImageLink3", value); }

		}

		  
		[XmlAttribute("ImageLink4")]
		public string ImageLink4 
		{
			get { return GetColumnValue<string>("ImageLink4"); }

			set { SetColumnValue("ImageLink4", value); }

		}

		  
		[XmlAttribute("ImageLink5")]
		public string ImageLink5 
		{
			get { return GetColumnValue<string>("ImageLink5"); }

			set { SetColumnValue("ImageLink5", value); }

		}

		  
		[XmlAttribute("Lead")]
		public string Lead 
		{
			get { return GetColumnValue<string>("Lead"); }

			set { SetColumnValue("Lead", value); }

		}

		  
		[XmlAttribute("Detail")]
		public string Detail 
		{
			get { return GetColumnValue<string>("Detail"); }

			set { SetColumnValue("Detail", value); }

		}

		  
		[XmlAttribute("PublishDate")]
		public DateTime PublishDate 
		{
			get { return GetColumnValue<DateTime>("PublishDate"); }

			set { SetColumnValue("PublishDate", value); }

		}

		  
		[XmlAttribute("Author")]
		public string Author 
		{
			get { return GetColumnValue<string>("Author"); }

			set { SetColumnValue("Author", value); }

		}

		  
		[XmlAttribute("AuthorInfo")]
		public string AuthorInfo 
		{
			get { return GetColumnValue<string>("AuthorInfo"); }

			set { SetColumnValue("AuthorInfo", value); }

		}

		  
		[XmlAttribute("IsMember")]
		public int IsMember 
		{
			get { return GetColumnValue<int>("IsMember"); }

			set { SetColumnValue("IsMember", value); }

		}

		  
		[XmlAttribute("TotalView")]
		public int TotalView 
		{
			get { return GetColumnValue<int>("TotalView"); }

			set { SetColumnValue("TotalView", value); }

		}

		  
		[XmlAttribute("History")]
		public string History 
		{
			get { return GetColumnValue<string>("History"); }

			set { SetColumnValue("History", value); }

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
		/// Returns a Article ActiveRecord object related to this ArticleVersion
		/// 
		/// </summary>
		public DAL.Article Article
		{
			get { return DAL.Article.FetchByID(this.ArticleId); }

			set { SetColumnValue("ArticleId", value.Id); }

		}

		
		
		/// <summary>
		/// Returns a ArticleContentType ActiveRecord object related to this ArticleVersion
		/// 
		/// </summary>
		public DAL.ArticleContentType ArticleContentType
		{
			get { return DAL.ArticleContentType.FetchByID(this.ArticleContentTypeId); }

			set { SetColumnValue("ArticleContentTypeId", value.Id); }

		}

		
		
		/// <summary>
		/// Returns a ArticleType ActiveRecord object related to this ArticleVersion
		/// 
		/// </summary>
		public DAL.ArticleType ArticleType
		{
			get { return DAL.ArticleType.FetchByID(this.ArticleTypeId); }

			set { SetColumnValue("ArticleTypeId", value.Id); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varArticleId,int varVersionId,string varStatus,int varArticleTypeId,int varArticleContentTypeId,string varName,string varTitle,string varSubTitle1,string varSubTitle2,string varSubTitle3,string varSubTitle4,string varSubTitle5,string varSubTitle6,string varImageLink,string varImageLink1,string varImageLink2,string varImageLink3,string varImageLink4,string varImageLink5,string varLead,string varDetail,DateTime varPublishDate,string varAuthor,string varAuthorInfo,int varIsMember,int varTotalView,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleVersion item = new ArticleVersion();
			
			item.ArticleId = varArticleId;
			
			item.VersionId = varVersionId;
			
			item.Status = varStatus;
			
			item.ArticleTypeId = varArticleTypeId;
			
			item.ArticleContentTypeId = varArticleContentTypeId;
			
			item.Name = varName;
			
			item.Title = varTitle;
			
			item.SubTitle1 = varSubTitle1;
			
			item.SubTitle2 = varSubTitle2;
			
			item.SubTitle3 = varSubTitle3;
			
			item.SubTitle4 = varSubTitle4;
			
			item.SubTitle5 = varSubTitle5;
			
			item.SubTitle6 = varSubTitle6;
			
			item.ImageLink = varImageLink;
			
			item.ImageLink1 = varImageLink1;
			
			item.ImageLink2 = varImageLink2;
			
			item.ImageLink3 = varImageLink3;
			
			item.ImageLink4 = varImageLink4;
			
			item.ImageLink5 = varImageLink5;
			
			item.Lead = varLead;
			
			item.Detail = varDetail;
			
			item.PublishDate = varPublishDate;
			
			item.Author = varAuthor;
			
			item.AuthorInfo = varAuthorInfo;
			
			item.IsMember = varIsMember;
			
			item.TotalView = varTotalView;
			
			item.History = varHistory;
			
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
		public static void Update(int varId,int varArticleId,int varVersionId,string varStatus,int varArticleTypeId,int varArticleContentTypeId,string varName,string varTitle,string varSubTitle1,string varSubTitle2,string varSubTitle3,string varSubTitle4,string varSubTitle5,string varSubTitle6,string varImageLink,string varImageLink1,string varImageLink2,string varImageLink3,string varImageLink4,string varImageLink5,string varLead,string varDetail,DateTime varPublishDate,string varAuthor,string varAuthorInfo,int varIsMember,int varTotalView,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			ArticleVersion item = new ArticleVersion();
			
				item.Id = varId;
				
				item.ArticleId = varArticleId;
				
				item.VersionId = varVersionId;
				
				item.Status = varStatus;
				
				item.ArticleTypeId = varArticleTypeId;
				
				item.ArticleContentTypeId = varArticleContentTypeId;
				
				item.Name = varName;
				
				item.Title = varTitle;
				
				item.SubTitle1 = varSubTitle1;
				
				item.SubTitle2 = varSubTitle2;
				
				item.SubTitle3 = varSubTitle3;
				
				item.SubTitle4 = varSubTitle4;
				
				item.SubTitle5 = varSubTitle5;
				
				item.SubTitle6 = varSubTitle6;
				
				item.ImageLink = varImageLink;
				
				item.ImageLink1 = varImageLink1;
				
				item.ImageLink2 = varImageLink2;
				
				item.ImageLink3 = varImageLink3;
				
				item.ImageLink4 = varImageLink4;
				
				item.ImageLink5 = varImageLink5;
				
				item.Lead = varLead;
				
				item.Detail = varDetail;
				
				item.PublishDate = varPublishDate;
				
				item.Author = varAuthor;
				
				item.AuthorInfo = varAuthorInfo;
				
				item.IsMember = varIsMember;
				
				item.TotalView = varTotalView;
				
				item.History = varHistory;
				
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
			 public static string VersionId = @"VersionId";
			 public static string Status = @"Status";
			 public static string ArticleTypeId = @"ArticleTypeId";
			 public static string ArticleContentTypeId = @"ArticleContentTypeId";
			 public static string Name = @"Name";
			 public static string Title = @"Title";
			 public static string SubTitle1 = @"SubTitle1";
			 public static string SubTitle2 = @"SubTitle2";
			 public static string SubTitle3 = @"SubTitle3";
			 public static string SubTitle4 = @"SubTitle4";
			 public static string SubTitle5 = @"SubTitle5";
			 public static string SubTitle6 = @"SubTitle6";
			 public static string ImageLink = @"ImageLink";
			 public static string ImageLink1 = @"ImageLink1";
			 public static string ImageLink2 = @"ImageLink2";
			 public static string ImageLink3 = @"ImageLink3";
			 public static string ImageLink4 = @"ImageLink4";
			 public static string ImageLink5 = @"ImageLink5";
			 public static string Lead = @"Lead";
			 public static string Detail = @"Detail";
			 public static string PublishDate = @"PublishDate";
			 public static string Author = @"Author";
			 public static string AuthorInfo = @"AuthorInfo";
			 public static string IsMember = @"IsMember";
			 public static string TotalView = @"TotalView";
			 public static string History = @"History";
			 public static string CreatedAt = @"Created_At";
			 public static string CreatedBy = @"Created_By";
			 public static string LastModifiedAt = @"Last_Modified_At";
			 public static string LastModifiedBy = @"Last_Modified_By";
			 public static string Flag = @"flag";
						
		}

		#endregion
	}

}


