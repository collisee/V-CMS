using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.DBAccess
{
    public class ArticleDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [Article]" +
                                  "([VersionId],[Status],[ArticleTypeId],[ArticleContentTypeId],[Name],[Title],[Url],[CategoryId],[PartitionId],[SubTitle1],[SubTitle2],[SubTitle3],[SubTitle4],[SubTitle5],[SubTitle6],[ImageLink],[ImageLink1],[ImageLink2],[ImageLink3],[ImageLink4],[ImageLink5],[Lead],[Detail],[PublishDate],[Author],[AuthorInfo],[IsMember],[TotalView]," +
                                  "[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@VersionId, @Status, @ArticleTypeId, @ArticleContentTypeId, @Name, @Title, @Url, @CategoryId, @PartitionId, @SubTitle1, @SubTitle2, @SubTitle3, @SubTitle4, @SubTitle5, @SubTitle6, @ImageLink, @ImageLink1, @ImageLink2, @ImageLink3, @ImageLink4, @ImageLink5, @Lead, @Detail, @PublishDate, @Author, @AuthorInfo, @IsMember, @TotalView, " +
                                  "@History, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@VersionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleContentTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Url", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle6", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        //CreateSqlPrameter("@Lead", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Lead", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Author", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@AuthorInfo", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@TotalView", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@History", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, insertString, paramArray);
                SetOutputValues(paramArray, dataRow);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [Article] Set" +
                                  " [VersionId] = @VersionId, [Status] = @Status, [ArticleTypeId] = @ArticleTypeId, [ArticleContentTypeId] = @ArticleContentTypeId, [Name] = @Name, [Title] = @Title, [Url] = @Url, [CategoryId] = @CategoryId, [PartitionId] = @PartitionId, " +
                                  " [SubTitle1] = @SubTitle1, [SubTitle2] = @SubTitle2, [SubTitle3] = @SubTitle3, [SubTitle4] = @SubTitle4, [SubTitle5] = @SubTitle5, [SubTitle6] = @SubTitle6, [ImageLink] = @ImageLink, " +
                                  " [ImageLink1] = @ImageLink1, [ImageLink2] = @ImageLink2, [ImageLink3] = @ImageLink3, [ImageLink4] = @ImageLink4, [ImageLink5] = @ImageLink5, [Lead] = @Lead, [Detail] = @Detail, [PublishDate] = @PublishDate, [Author] = @Author, [AuthorInfo] = @AuthorInfo, [IsMember] = @IsMember, " +
                                  " [TotalView] = @TotalView, [History] = @History, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@VersionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleContentTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Url", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@SubTitle6", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink1", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink2", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink3", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink4", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink5", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        //CreateSqlPrameter("@Lead", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Lead", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Author", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@AuthorInfo", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@IsMember", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@TotalView", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@History", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Created_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Flag", SqlDbType.Char, 1, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [Article] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [Article] Where  [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleDAO::SelectOne::Error", ex);
            }
        }

        #region ViewGetAllArticle

        public static DataSet ViewGetAllArticle(DataSet dataSet)
        {
            return ViewGetAllArticle(null, dataSet);
        }

        public static DataSet ViewGetAllArticle(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [Article] "
                                           + " WHERE (ISNULL(@Status, '') = '' OR [Status] = @Status) "
                                           + " AND (@UId = 0  OR [Created_By] = @UId) "
                                           + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                           + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Article.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.Article.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT *, row_number() over(order by [Id] DESC) RowNum FROM [Article] "
                                         + " WHERE (ISNULL(@Status, '') = '' OR [Status] = @Status) "
                                         + " AND (@UId = 0  OR [Created_By] = @UId) "
                                         + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                         + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Article.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.Article.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UId", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishToDate", SqlDbType.DateTime, 0, ParameterDirection.Input)
                };
            paramArray[0].Value = "%" +
                                  Convert.ToString(
                                      dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                                          Constants.Paging.Direction.KeyWords]).Replace("\"", "\"\"") + "%";

            //Get PageIndex and PageSize
            int indexOfPage =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageIndex]);
            int pagesize =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageSize]);
            int uid =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        CMSConstants.Paging.Direction.UId]);
            string status = dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.Status].ToString();
            DateTime publishFromDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishFromDate]);
            DateTime publishToDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishToDate]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = uid;
            paramArray[4].Value = status;
            paramArray[5].Value = publishFromDate;
            paramArray[6].Value = publishToDate;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllArticleByCategory

        public static DataSet ViewGetAllArticleByCategory(DataSet dataSet)
        {
            return ViewGetAllArticleByCategory(null, dataSet);
        }

        public static DataSet ViewGetAllArticleByCategory(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + "  FROM ( "
                                           + " 		SELECT *  "
                                           + " 		FROM [ArticleCategory] "
                                           + " 		WHERE [PartitionId] = (SELECT [PartitionId] FROM [Category] WHERE [Id] = @CategoryId) "
                                           + " 		AND [CategoryId] = @CategoryId "
                                           + " 		AND ISNULL(flag, '') = '' "
                                           + " 	) [ArticleCategory] "
                                           + "  LEFT JOIN [Article] "
                                           + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                           + " 	WHERE [ArticleCategory].[CategoryId] = @CategoryId "
                                           + " 	AND (ISNULL(@Status, '') = '' OR [Article].[Status] = @Status) "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Article.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.Article.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + " SELECT [Article].*, row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC) RowNum "
                                         + "        , [ArticleCategory].[Id] [ArticleCategoryId] "
                                         + "        , [ArticleCategory].[Ord] "
                                         + "        , [ArticleCategory].[Ord] [OldOrd] "
                                         + "    FROM ( "
                                         + " 		SELECT *  "
                                         + " 		FROM [ArticleCategory] "
                                         + " 		WHERE [PartitionId] = (SELECT [PartitionId] FROM [Category] WHERE [Id] = @CategoryId) "
                                         + " 		AND [CategoryId] = @CategoryId "
                                         + " 		AND ISNULL(flag, '') = '' "
                                         + " 	) [ArticleCategory] "
                                         + "    LEFT JOIN [Article] "
                                         + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                         + " 	WHERE [ArticleCategory].[CategoryId] = @CategoryId "
                                         + " 	AND (ISNULL(@Status, '') = '' OR [Article].[Status] = @Status) "
                                         + "    AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                         + "    AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(
                                             dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                             CMSConstants.Entities.Article.SearchColumns,
                                             ModuleConstants.ConnectorString.AND_STRING,
                                             CMSConstants.Entities.Article.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishToDate", SqlDbType.DateTime, 0, ParameterDirection.Input)
                };
            paramArray[0].Value = "%" +
                                  Convert.ToString(
                                      dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                                          Constants.Paging.Direction.KeyWords]).Replace("\"", "\"\"") + "%";

            //Get PageIndex and PageSize
            int indexOfPage =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageIndex]);
            int pagesize =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageSize]);
            string status = dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.Status].ToString();
            int categoryId = Utilities.ParseInt(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.CategoryId]);
            DateTime publishFromDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishFromDate]);
            DateTime publishToDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishToDate]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = status;
            paramArray[4].Value = categoryId;
            paramArray[5].Value = publishFromDate;
            paramArray[6].Value = publishToDate;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllArticleByManager

        public static DataSet ViewGetAllArticleByManager(DataSet dataSet)
        {
            return ViewGetAllArticleByManager(null, dataSet);
        }

        public static DataSet ViewGetAllArticleByManager(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + "  FROM ( "
                                           + " 		SELECT DISTINCT([ArticleId]) "
                                           + " 		FROM [ArticleCategory] "
                                           + " 		WHERE [PartitionId] IN (SELECT [PartitionId] FROM fn_GetPartitionsByUserId(@UId)) "
                                           + " 		AND [CategoryId] IN (SELECT [Id] FROM fn_GetCategoriesByUserId(@UId)) "
                                           + " 		AND ISNULL(flag, '') = '' "
                                           + " 	) [ArticleCategory] "
                                           + "  LEFT JOIN [Article] "
                                           + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                           + " 	WHERE (ISNULL(@Status, '') = '' OR [Article].[Status] = @Status) "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Article.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.Article.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + " SELECT [Article].*, row_number() over(order by [Article].[Id] DESC) RowNum "
                                         + "    FROM ( "
                                         + " 		SELECT DISTINCT([ArticleId])   "
                                         + " 		FROM [ArticleCategory] "
                                         + " 		WHERE [PartitionId] IN (SELECT [PartitionId] FROM fn_GetPartitionsByUserId(@UId)) "
                                         + " 		AND [CategoryId] IN (SELECT [Id] FROM fn_GetCategoriesByUserId(@UId)) "
                                         + " 		AND ISNULL(flag, '') = '' "
                                         + " 	) [ArticleCategory] "
                                         + "    LEFT JOIN [Article] "
                                         + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                         + "    WHERE (ISNULL(@Status, '') = '' OR [Article].[Status] = @Status) "
                                         + "    AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                         + "    AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(
                                             dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                             CMSConstants.Entities.Article.SearchColumns,
                                             ModuleConstants.ConnectorString.AND_STRING,
                                             CMSConstants.Entities.Article.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UId", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishToDate", SqlDbType.DateTime, 0, ParameterDirection.Input)
                };
            paramArray[0].Value = "%" +
                                  Convert.ToString(
                                      dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                                          Constants.Paging.Direction.KeyWords]).Replace("\"", "\"\"") + "%";

            //Get PageIndex and PageSize
            int indexOfPage =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageIndex]);
            int pagesize =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageSize]);
            int uid =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        CMSConstants.Paging.Direction.UId]);
            string status = dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.Status].ToString();
            DateTime publishFromDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishFromDate]);
            DateTime publishToDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishToDate]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = uid;
            paramArray[4].Value = status;
            paramArray[5].Value = publishFromDate;
            paramArray[6].Value = publishToDate;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllArticleForPopupInsertNews

        public static DataSet ViewGetAllArticleForPopupInsertNews(DataSet dataSet)
        {
            return ViewGetAllArticleForPopupInsertNews(null, dataSet);
        }

        public static DataSet ViewGetAllArticleForPopupInsertNews(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [Article] "
                                           + " 	LEFT JOIN ( "
                                           + " 		SELECT *  "
                                           + " 		FROM [ArticleCategory] "
                                           + " 		WHERE [PartitionId] = (SELECT [PartitionId] FROM [Category] WHERE [Id] = @CategoryId) "
                                           + " 		AND [CategoryId] = @CategoryId "
                                           + " 		AND ISNULL(flag, '') = '' "
                                           + " 	) [ArticleCategory] "
                                           + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                           + " 	WHERE [CategoryId] = @CategoryId "
                                           + "  AND [Article].[Status] = N'" + CMSConstants.ArticleStatus.Published + "' "
                                           + "  AND [Article].[Name] LIKE @KeyWords "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                           + "  AND ISNULL([Article].flag, '') = '' ";

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [Article].*, row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC) RowNum "
                                         + " , [ArticleCategory].[Id] [ArticleCategoryId] "
                                         + " , [ArticleCategory].[Ord] "
                                         + " , [ArticleCategory].[Ord] [OldOrd] "
                                         + " , [Category].[Name] [CategoryName] "
                                         + " , [Category].[Alias] [CategoryAlias] "
                                         + " FROM [Article] "
                                         + " 	LEFT JOIN ( "
                                         + " 		SELECT *  "
                                         + " 		FROM [ArticleCategory] "
                                         +
                                         " 		WHERE [PartitionId] = (SELECT [PartitionId] FROM [Category] WHERE [Id] = @CategoryId) "
                                         + " 		AND [CategoryId] = @CategoryId "
                                         + " 		AND ISNULL(flag, '') = '' "
                                         + " 	) [ArticleCategory] "
                                         + " 	ON [ArticleCategory].[ArticleId] = [Article].[Id] "
                                         + " 	LEFT JOIN [Category] "
                                         + " 	ON [Category].[Id] = [ArticleCategory].[CategoryId] "
                                         + " WHERE [CategoryId] = @CategoryId "
                                         + " AND [Article].[Status] = N'" + CMSConstants.ArticleStatus.Published + "' "
                                         + " AND [Article].[Name] LIKE @KeyWords "
                                         + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                         + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                         + " AND ISNULL([Article].flag, '') = '' "
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishToDate", SqlDbType.DateTime, 0, ParameterDirection.Input)
                };
            paramArray[0].Value = "%" +
                                  Convert.ToString(
                                      dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                                          Constants.Paging.Direction.KeyWords]).Replace("\"", "\"\"") + "%";

            //Get PageIndex and PageSize
            int indexOfPage =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageIndex]);
            int pagesize =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageSize]);
            int categoryId = Utilities.ParseInt(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.CategoryId]);
            DateTime publishFromDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishFromDate]);
            DateTime publishToDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishToDate]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = categoryId;
            paramArray[4].Value = publishFromDate;
            paramArray[5].Value = publishToDate;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllArticleForPopupInsertNewsWithoutCategory

        public static DataSet ViewGetAllArticleForPopupInsertNewsWithoutCategory(DataSet dataSet)
        {
            return ViewGetAllArticleForPopupInsertNewsWithoutCategory(null, dataSet);
        }

        public static DataSet ViewGetAllArticleForPopupInsertNewsWithoutCategory(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [Article] "
                                           + "  WHERE [Article].[Status] = N'" + CMSConstants.ArticleStatus.Published + "' "
                                           + "  AND [Article].[Name] LIKE @KeyWords "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                           + "  AND ISNULL([Article].flag, '') = '' ";

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [Article].*, row_number() over(order by [Article].[Id] DESC) RowNum "
                                         + " FROM [Article] "
                                         + " WHERE [Article].[Status] = N'" + CMSConstants.ArticleStatus.Published + "' "
                                         + " AND [Article].[Name] LIKE @KeyWords "
                                         + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishFromDate) <= 0 "
                                         + " AND DATEDIFF(DD, [Article].[PublishDate], @PublishToDate) >= 0 "
                                         + " AND ISNULL([Article].flag, '') = '' "
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@PublishToDate", SqlDbType.DateTime, 0, ParameterDirection.Input)
                };
            paramArray[0].Value = "%" +
                                  Convert.ToString(
                                      dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                                          Constants.Paging.Direction.KeyWords]).Replace("\"", "\"\"") + "%";

            //Get PageIndex and PageSize
            int indexOfPage =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageIndex]);
            int pagesize =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.PagingTableName].Rows[0][
                        Constants.Paging.Direction.PageSize]);
            DateTime publishFromDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishFromDate]);
            DateTime publishToDate = Convert.ToDateTime(dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                CMSConstants.Paging.Direction.PublishToDate]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = publishFromDate;
            paramArray[4].Value = publishToDate;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [Article] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("Article");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("VersionId", typeof(int));
            table.Columns.Add("Status");
            table.Columns.Add("ArticleTypeId", typeof(int));
            table.Columns.Add("ArticleContentTypeId", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("Title");
            table.Columns.Add("Url");
            table.Columns.Add("CategoryId", typeof(int));
            table.Columns.Add("PartitionId", typeof(int));
            table.Columns.Add("SubTitle1");
            table.Columns.Add("SubTitle2");
            table.Columns.Add("SubTitle3");
            table.Columns.Add("SubTitle4");
            table.Columns.Add("SubTitle5");
            table.Columns.Add("SubTitle6");
            table.Columns.Add("ImageLink");
            table.Columns.Add("ImageLink1");
            table.Columns.Add("ImageLink2");
            table.Columns.Add("ImageLink3");
            table.Columns.Add("ImageLink4");
            table.Columns.Add("ImageLink5");
            table.Columns.Add("Lead");
            table.Columns.Add("Detail");
            table.Columns.Add("PublishDate");
            table.Columns.Add("Author");
            table.Columns.Add("AuthorInfo");
            table.Columns.Add("IsMember");
            table.Columns.Add("TotalView", typeof(int));
            table.Columns.Add("History");
            table.Columns.Add("Created_At", typeof(DateTime));
            table.Columns.Add("Created_By", typeof(int));
            table.Columns.Add("Last_Modified_At", typeof(DateTime));
            table.Columns.Add("Last_Modified_By", typeof(int));
            table.Columns.Add("Flag");

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #region "Searching"
        public static DataSet Search(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = CMSConstants.Services.ArticleManager.Actions.SearchArticleByKeyword;
            string procedureNameCount = CMSConstants.Services.ArticleManager.Actions.SearchArticleByKeywordCount;
            try
            {
                int keyWords = Utilities.ParseInt(dataRow[Constants.Paging.Direction.KeyWords]);
                int pageSize =Utilities.ParseInt(dataRow[Constants.Paging.Direction.PageSize]);
                int pageIndex = Utilities.ParseInt(dataRow[Constants.Paging.Direction.PageIndex]);

                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FirstRow", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastRow", SqlDbType.Int, 0, ParameterDirection.Input) 
                    };
                //SetParameterValues(paramArray, dataRow);
                paramArray[0].Value = keyWords;
                paramArray[1].Value = (pageIndex - 1) * pageSize + 1;
                paramArray[2].Value = (pageIndex - 1) * pageSize + pageSize;

                return CommonDAO.ExecuteManualPagingProcedure(sqlTransaction, procedureNameCount, procedureName , paramArray);

 
                 
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleDAO::SearchArticleByKeyword::Error", ex);
            }
        }

        #endregion

        #endregion
    }
}