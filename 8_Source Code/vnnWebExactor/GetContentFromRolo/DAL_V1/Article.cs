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
	/// Strongly-typed collection for the Article class.
	/// </summary>
    [Serializable]
	public partial class ArticleCollection : ActiveList<Article, ArticleCollection>
	{	   
		public ArticleCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ArticleCollection</returns>
		public ArticleCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Article o = this[i];
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
	/// This is an ActiveRecord class which wraps the Article table.
	/// </summary>
	[Serializable]
	public partial class Article : ActiveRecord<Article>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Article()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Article(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Article(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Article(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Article", TableType.Table, DataService.GetInstance("VCMS"));
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
				
				TableSchema.TableColumn colvarVersionId = new TableSchema.TableColumn(schema);
				colvarVersionId.ColumnName = "VersionId";
				colvarVersionId.DataType = DbType.Int32;
				colvarVersionId.MaxLength = 0;
				colvarVersionId.AutoIncrement = false;
				colvarVersionId.IsNullable = false;
				colvarVersionId.IsPrimaryKey = false;
				colvarVersionId.IsForeignKey = false;
				colvarVersionId.IsReadOnly = false;
				
						colvarVersionId.DefaultSetting = @"((0))";
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
				
				TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
				colvarUrl.ColumnName = "Url";
				colvarUrl.DataType = DbType.String;
				colvarUrl.MaxLength = 255;
				colvarUrl.AutoIncrement = false;
				colvarUrl.IsNullable = true;
				colvarUrl.IsPrimaryKey = false;
				colvarUrl.IsForeignKey = false;
				colvarUrl.IsReadOnly = false;
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUrl);
				
				TableSchema.TableColumn colvarCategoryId = new TableSchema.TableColumn(schema);
				colvarCategoryId.ColumnName = "CategoryId";
				colvarCategoryId.DataType = DbType.Int32;
				colvarCategoryId.MaxLength = 0;
				colvarCategoryId.AutoIncrement = false;
				colvarCategoryId.IsNullable = false;
				colvarCategoryId.IsPrimaryKey = false;
				colvarCategoryId.IsForeignKey = false;
				colvarCategoryId.IsReadOnly = false;
				
						colvarCategoryId.DefaultSetting = @"((0))";
				colvarCategoryId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryId);
				
				TableSchema.TableColumn colvarPartitionId = new TableSchema.TableColumn(schema);
				colvarPartitionId.ColumnName = "PartitionId";
				colvarPartitionId.DataType = DbType.Int32;
				colvarPartitionId.MaxLength = 0;
				colvarPartitionId.AutoIncrement = false;
				colvarPartitionId.IsNullable = false;
				colvarPartitionId.IsPrimaryKey = false;
				colvarPartitionId.IsForeignKey = false;
				colvarPartitionId.IsReadOnly = false;
				
						colvarPartitionId.DefaultSetting = @"((0))";
				colvarPartitionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPartitionId);
				
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
				colvarLead.MaxLength = 4000;
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
				DataService.Providers["VCMS"].AddSchema("Article",schema);
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
		  
		[XmlAttribute("VersionId")]
		[Bindable(true)]
		public int VersionId 
		{
			get { return GetColumnValue<int>(Columns.VersionId); }
			set { SetColumnValue(Columns.VersionId, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("ArticleTypeId")]
		[Bindable(true)]
		public int ArticleTypeId 
		{
			get { return GetColumnValue<int>(Columns.ArticleTypeId); }
			set { SetColumnValue(Columns.ArticleTypeId, value); }
		}
		  
		[XmlAttribute("ArticleContentTypeId")]
		[Bindable(true)]
		public int ArticleContentTypeId 
		{
			get { return GetColumnValue<int>(Columns.ArticleContentTypeId); }
			set { SetColumnValue(Columns.ArticleContentTypeId, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Title")]
		[Bindable(true)]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }
			set { SetColumnValue(Columns.Title, value); }
		}
		  
		[XmlAttribute("Url")]
		[Bindable(true)]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }
			set { SetColumnValue(Columns.Url, value); }
		}
		  
		[XmlAttribute("CategoryId")]
		[Bindable(true)]
		public int CategoryId 
		{
			get { return GetColumnValue<int>(Columns.CategoryId); }
			set { SetColumnValue(Columns.CategoryId, value); }
		}
		  
		[XmlAttribute("PartitionId")]
		[Bindable(true)]
		public int PartitionId 
		{
			get { return GetColumnValue<int>(Columns.PartitionId); }
			set { SetColumnValue(Columns.PartitionId, value); }
		}
		  
		[XmlAttribute("SubTitle1")]
		[Bindable(true)]
		public string SubTitle1 
		{
			get { return GetColumnValue<string>(Columns.SubTitle1); }
			set { SetColumnValue(Columns.SubTitle1, value); }
		}
		  
		[XmlAttribute("SubTitle2")]
		[Bindable(true)]
		public string SubTitle2 
		{
			get { return GetColumnValue<string>(Columns.SubTitle2); }
			set { SetColumnValue(Columns.SubTitle2, value); }
		}
		  
		[XmlAttribute("SubTitle3")]
		[Bindable(true)]
		public string SubTitle3 
		{
			get { return GetColumnValue<string>(Columns.SubTitle3); }
			set { SetColumnValue(Columns.SubTitle3, value); }
		}
		  
		[XmlAttribute("SubTitle4")]
		[Bindable(true)]
		public string SubTitle4 
		{
			get { return GetColumnValue<string>(Columns.SubTitle4); }
			set { SetColumnValue(Columns.SubTitle4, value); }
		}
		  
		[XmlAttribute("SubTitle5")]
		[Bindable(true)]
		public string SubTitle5 
		{
			get { return GetColumnValue<string>(Columns.SubTitle5); }
			set { SetColumnValue(Columns.SubTitle5, value); }
		}
		  
		[XmlAttribute("SubTitle6")]
		[Bindable(true)]
		public string SubTitle6 
		{
			get { return GetColumnValue<string>(Columns.SubTitle6); }
			set { SetColumnValue(Columns.SubTitle6, value); }
		}
		  
		[XmlAttribute("ImageLink")]
		[Bindable(true)]
		public string ImageLink 
		{
			get { return GetColumnValue<string>(Columns.ImageLink); }
			set { SetColumnValue(Columns.ImageLink, value); }
		}
		  
		[XmlAttribute("ImageLink1")]
		[Bindable(true)]
		public string ImageLink1 
		{
			get { return GetColumnValue<string>(Columns.ImageLink1); }
			set { SetColumnValue(Columns.ImageLink1, value); }
		}
		  
		[XmlAttribute("ImageLink2")]
		[Bindable(true)]
		public string ImageLink2 
		{
			get { return GetColumnValue<string>(Columns.ImageLink2); }
			set { SetColumnValue(Columns.ImageLink2, value); }
		}
		  
		[XmlAttribute("ImageLink3")]
		[Bindable(true)]
		public string ImageLink3 
		{
			get { return GetColumnValue<string>(Columns.ImageLink3); }
			set { SetColumnValue(Columns.ImageLink3, value); }
		}
		  
		[XmlAttribute("ImageLink4")]
		[Bindable(true)]
		public string ImageLink4 
		{
			get { return GetColumnValue<string>(Columns.ImageLink4); }
			set { SetColumnValue(Columns.ImageLink4, value); }
		}
		  
		[XmlAttribute("ImageLink5")]
		[Bindable(true)]
		public string ImageLink5 
		{
			get { return GetColumnValue<string>(Columns.ImageLink5); }
			set { SetColumnValue(Columns.ImageLink5, value); }
		}
		  
		[XmlAttribute("Lead")]
		[Bindable(true)]
		public string Lead 
		{
			get { return GetColumnValue<string>(Columns.Lead); }
			set { SetColumnValue(Columns.Lead, value); }
		}
		  
		[XmlAttribute("Detail")]
		[Bindable(true)]
		public string Detail 
		{
			get { return GetColumnValue<string>(Columns.Detail); }
			set { SetColumnValue(Columns.Detail, value); }
		}
		  
		[XmlAttribute("PublishDate")]
		[Bindable(true)]
		public DateTime PublishDate 
		{
			get { return GetColumnValue<DateTime>(Columns.PublishDate); }
			set { SetColumnValue(Columns.PublishDate, value); }
		}
		  
		[XmlAttribute("Author")]
		[Bindable(true)]
		public string Author 
		{
			get { return GetColumnValue<string>(Columns.Author); }
			set { SetColumnValue(Columns.Author, value); }
		}
		  
		[XmlAttribute("AuthorInfo")]
		[Bindable(true)]
		public string AuthorInfo 
		{
			get { return GetColumnValue<string>(Columns.AuthorInfo); }
			set { SetColumnValue(Columns.AuthorInfo, value); }
		}
		  
		[XmlAttribute("IsMember")]
		[Bindable(true)]
		public int IsMember 
		{
			get { return GetColumnValue<int>(Columns.IsMember); }
			set { SetColumnValue(Columns.IsMember, value); }
		}
		  
		[XmlAttribute("TotalView")]
		[Bindable(true)]
		public int TotalView 
		{
			get { return GetColumnValue<int>(Columns.TotalView); }
			set { SetColumnValue(Columns.TotalView, value); }
		}
		  
		[XmlAttribute("History")]
		[Bindable(true)]
		public string History 
		{
			get { return GetColumnValue<string>(Columns.History); }
			set { SetColumnValue(Columns.History, value); }
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
        
		
		public DAL.ArticleCategoryCollection ArticleCategoryRecords()
		{
			return new DAL.ArticleCategoryCollection().Where(ArticleCategory.Columns.ArticleId, Id).Load();
		}
		public DAL.ArticleCommentCollection ArticleCommentRecords()
		{
			return new DAL.ArticleCommentCollection().Where(ArticleComment.Columns.ArticleId, Id).Load();
		}
		public DAL.ArticleEventItemCollection ArticleEventItemRecords()
		{
			return new DAL.ArticleEventItemCollection().Where(ArticleEventItem.Columns.ArticleId, Id).Load();
		}
		public DAL.ArticleMediumCollection ArticleMedia()
		{
			return new DAL.ArticleMediumCollection().Where(ArticleMedium.Columns.ArticleId, Id).Load();
		}
		public DAL.ArticleVersionCollection ArticleVersionRecords()
		{
			return new DAL.ArticleVersionCollection().Where(ArticleVersion.Columns.ArticleId, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ArticleContentType ActiveRecord object related to this Article
		/// 
		/// </summary>
		public DAL.ArticleContentType ArticleContentType
		{
			get { return DAL.ArticleContentType.FetchByID(this.ArticleContentTypeId); }
			set { SetColumnValue("ArticleContentTypeId", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a ArticleType ActiveRecord object related to this Article
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
		public static void Insert(int varVersionId,string varStatus,int varArticleTypeId,int varArticleContentTypeId,string varName,string varTitle,string varUrl,int varCategoryId,int varPartitionId,string varSubTitle1,string varSubTitle2,string varSubTitle3,string varSubTitle4,string varSubTitle5,string varSubTitle6,string varImageLink,string varImageLink1,string varImageLink2,string varImageLink3,string varImageLink4,string varImageLink5,string varLead,string varDetail,DateTime varPublishDate,string varAuthor,string varAuthorInfo,int varIsMember,int varTotalView,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Article item = new Article();
			
			item.VersionId = varVersionId;
			
			item.Status = varStatus;
			
			item.ArticleTypeId = varArticleTypeId;
			
			item.ArticleContentTypeId = varArticleContentTypeId;
			
			item.Name = varName;
			
			item.Title = varTitle;
			
			item.Url = varUrl;
			
			item.CategoryId = varCategoryId;
			
			item.PartitionId = varPartitionId;
			
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
		public static void Update(int varId,int varVersionId,string varStatus,int varArticleTypeId,int varArticleContentTypeId,string varName,string varTitle,string varUrl,int varCategoryId,int varPartitionId,string varSubTitle1,string varSubTitle2,string varSubTitle3,string varSubTitle4,string varSubTitle5,string varSubTitle6,string varImageLink,string varImageLink1,string varImageLink2,string varImageLink3,string varImageLink4,string varImageLink5,string varLead,string varDetail,DateTime varPublishDate,string varAuthor,string varAuthorInfo,int varIsMember,int varTotalView,string varHistory,DateTime varCreatedAt,int varCreatedBy,DateTime varLastModifiedAt,int varLastModifiedBy,string varFlag)
		{
			Article item = new Article();
			
				item.Id = varId;
			
				item.VersionId = varVersionId;
			
				item.Status = varStatus;
			
				item.ArticleTypeId = varArticleTypeId;
			
				item.ArticleContentTypeId = varArticleContentTypeId;
			
				item.Name = varName;
			
				item.Title = varTitle;
			
				item.Url = varUrl;
			
				item.CategoryId = varCategoryId;
			
				item.PartitionId = varPartitionId;
			
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
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn VersionIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleTypeIdColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ArticleContentTypeIdColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryIdColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn PartitionIdColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTitle1Column
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTitle2Column
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTitle3Column
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTitle4Column
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTitle5Column
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTitle6Column
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLinkColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLink1Column
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLink2Column
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLink3Column
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLink4Column
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn ImageLink5Column
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn LeadColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn PublishDateColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn AuthorColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn AuthorInfoColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn IsMemberColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalViewColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn HistoryColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedAtColumn
        {
            get { return Schema.Columns[30]; }
        }
        
        
        
        public static TableSchema.TableColumn CreatedByColumn
        {
            get { return Schema.Columns[31]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedAtColumn
        {
            get { return Schema.Columns[32]; }
        }
        
        
        
        public static TableSchema.TableColumn LastModifiedByColumn
        {
            get { return Schema.Columns[33]; }
        }
        
        
        
        public static TableSchema.TableColumn FlagColumn
        {
            get { return Schema.Columns[34]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string VersionId = @"VersionId";
			 public static string Status = @"Status";
			 public static string ArticleTypeId = @"ArticleTypeId";
			 public static string ArticleContentTypeId = @"ArticleContentTypeId";
			 public static string Name = @"Name";
			 public static string Title = @"Title";
			 public static string Url = @"Url";
			 public static string CategoryId = @"CategoryId";
			 public static string PartitionId = @"PartitionId";
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
