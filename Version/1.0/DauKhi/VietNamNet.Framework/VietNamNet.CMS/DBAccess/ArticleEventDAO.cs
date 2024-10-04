using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.DBAccess
{
    public class ArticleEventDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [ArticleEvent]" +
                                  "([Status],[Name],[Title],[ImageLink],[Lead],[Detail],[PublishDate],[TotalView],[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@Status, @Name, @Title, @ImageLink, @Lead, @Detail, @PublishDate, @TotalView, @History, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Lead", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleEventDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [ArticleEvent] Set" +
                                  " [Status] = @Status, [Name] = @Name, [Title] = @Title, [ImageLink] = @ImageLink, [Lead] = @Lead, [Detail] = @Detail, [PublishDate] = @PublishDate, [TotalView] = @TotalView, [History] = @History, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Title", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ImageLink", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Lead", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleEventDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [ArticleEvent] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, deleteString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleEventDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [ArticleEvent] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("ArticleEventDAO::SelectOne::Error", ex);
            }
        }

        #region ViewGetAllArticleEvent

        public static DataSet ViewGetAllArticleEvent(DataSet dataSet)
        {
            return ViewGetAllArticleEvent(null, dataSet);
        }

        public static DataSet ViewGetAllArticleEvent(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [ArticleEvent] "
                                           + " WHERE (ISNULL(@Status, '') = '' OR [Status] = @Status) "
                                           + " AND (@UId = 0  OR [Created_By] = @UId) "
                                           + " AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishFromDate) <= 0 "
                                           + " AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleEvent.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleEvent.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT *, row_number() over(order by [Id] DESC) RowNum FROM [ArticleEvent] "
                                         + " WHERE (ISNULL(@Status, '') = '' OR [Status] = @Status) "
                                         + " AND (@UId = 0  OR [Created_By] = @UId) "
                                         + " AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishFromDate) <= 0 "
                                         + " AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleEvent.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleEvent.Name)
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

        #region ViewGetAllArticleEventByCategory

        public static DataSet ViewGetAllArticleEventByCategory(DataSet dataSet)
        {
            return ViewGetAllArticleEventByCategory(null, dataSet);
        }

        public static DataSet ViewGetAllArticleEventByCategory(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + "  FROM ( "
                                           + " 		SELECT *  "
                                           + " 		FROM [ArticleEventCategory] "
                                           + " 		WHERE [CategoryId] = @CategoryId "
                                           + " 		AND ISNULL(flag, '') = '' "
                                           + " 	) [ArticleEventCategory] "
                                           + "  LEFT JOIN [ArticleEvent] "
                                           + " 	ON [ArticleEventCategory].[ArticleEventId] = [ArticleEvent].[Id] "
                                           + " 	WHERE [ArticleEventCategory].[CategoryId] = @CategoryId "
                                           + " 	AND (ISNULL(@Status, '') = '' OR [ArticleEvent].[Status] = @Status) "
                                           + "  AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleEvent.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleEvent.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + " SELECT [ArticleEvent].*, row_number() over(order by [ArticleEventCategory].[Ord], [ArticleEvent].[Id] DESC) RowNum "
                                         + "        , [ArticleEventCategory].[Id] [ArticleEventCategoryId] "
                                         + "        , [ArticleEventCategory].[Ord] "
                                         + "        , [ArticleEventCategory].[Ord] [OldOrd] "
                                         + "    FROM ( "
                                         + " 		SELECT *  "
                                         + " 		FROM [ArticleEventCategory] "
                                         + " 		WHERE [CategoryId] = @CategoryId "
                                         + " 		AND ISNULL(flag, '') = '' "
                                         + " 	) [ArticleEventCategory] "
                                         + "    LEFT JOIN [ArticleEvent] "
                                         + " 	ON [ArticleEventCategory].[ArticleEventId] = [ArticleEvent].[Id] "
                                         + " 	WHERE [ArticleEventCategory].[CategoryId] = @CategoryId "
                                         + " 	AND (ISNULL(@Status, '') = '' OR [ArticleEvent].[Status] = @Status) "
                                         + "    AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishFromDate) <= 0 "
                                         + "    AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(
                                             dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                             CMSConstants.Entities.ArticleEvent.SearchColumns,
                                             ModuleConstants.ConnectorString.AND_STRING,
                                             CMSConstants.Entities.ArticleEvent.Name)
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

        #region ViewGetAllArticleEventByManager

        public static DataSet ViewGetAllArticleEventByManager(DataSet dataSet)
        {
            return ViewGetAllArticleEventByManager(null, dataSet);
        }

        public static DataSet ViewGetAllArticleEventByManager(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + "  FROM ( "
                                           + " 		SELECT DISTINCT([ArticleEventId]) "
                                           + " 		FROM [ArticleEventCategory] "
                                           + " 		WHERE [CategoryId] IN (SELECT [Id] FROM fn_GetCategoriesByUserId(@UId)) "
                                           + " 		AND ISNULL(flag, '') = '' "
                                           + " 	) [ArticleEventCategory] "
                                           + "  LEFT JOIN [ArticleEvent] "
                                           + " 	ON [ArticleEventCategory].[ArticleEventId] = [ArticleEvent].[Id] "
                                           + " 	WHERE (ISNULL(@Status, '') = '' OR [ArticleEvent].[Status] = @Status) "
                                           + "  AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishFromDate) <= 0 "
                                           + "  AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishToDate) >= 0 "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleEvent.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleEvent.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + " SELECT [ArticleEvent].*, row_number() over(order by [ArticleEvent].[Id] DESC) RowNum "
                                         + "    FROM ( "
                                         + " 		SELECT DISTINCT([ArticleEventId])   "
                                         + " 		FROM [ArticleEventCategory] "
                                         + " 		WHERE [CategoryId] IN (SELECT [Id] FROM fn_GetCategoriesByUserId(@UId)) "
                                         + " 		AND ISNULL(flag, '') = '' "
                                         + " 	) [ArticleEventCategory] "
                                         + "    LEFT JOIN [ArticleEvent] "
                                         + " 	ON [ArticleEventCategory].[ArticleEventId] = [ArticleEvent].[Id] "
                                         + "    WHERE (ISNULL(@Status, '') = '' OR [ArticleEvent].[Status] = @Status) "
                                         + "    AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishFromDate) <= 0 "
                                         + "    AND DATEDIFF(DD, [ArticleEvent].[PublishDate], @PublishToDate) >= 0 "
                                         + CommonDAO.SearchingQuery(
                                             dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                             CMSConstants.Entities.ArticleEvent.SearchColumns,
                                             ModuleConstants.ConnectorString.AND_STRING,
                                             CMSConstants.Entities.ArticleEvent.Name)
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

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [ArticleEvent] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleEventDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("ArticleEvent");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Status");
            table.Columns.Add("Name");
            table.Columns.Add("Title");
            table.Columns.Add("ImageLink");
            table.Columns.Add("Lead");
            table.Columns.Add("Detail");
            table.Columns.Add("PublishDate", typeof(DateTime));
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

        #endregion
    }
}