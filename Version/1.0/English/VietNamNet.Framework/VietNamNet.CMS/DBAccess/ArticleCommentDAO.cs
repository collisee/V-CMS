using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.DBAccess
{
    public class ArticleCommentDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [ArticleComment]" +
                                  "([ArticleId],[PId],[Status],[Name],[Email],[Phone],[Subject],[Detail],[History],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@ArticleId, @PId, @Status, @Name, @Email, @Phone, @Subject, @Detail, @History, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Phone", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Subject", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
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
                throw new Exception("ArticleCommentDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [ArticleComment] Set" +
                                  " [ArticleId] = @ArticleId, [PId] = @PId, [Status] = @Status, [Name] = @Name, [Email] = @Email, [Phone] = @Phone, [Subject] = @Subject, [Detail] = @Detail, [History] = @History, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Email", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Phone", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Subject", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
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
                throw new Exception("ArticleCommentDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [ArticleComment] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id ";
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
                throw new Exception("ArticleCommentDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [ArticleComment] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("ArticleCommentDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [ArticleComment] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleCommentDAO::SelectAll::Error", ex);
            }
        }

        #region ViewGetAllArticleComment

        public static DataSet ViewGetAllArticleComment(DataSet dataSet)
        {
            return ViewGetAllArticleComment(null, dataSet);
        }

        public static DataSet ViewGetAllArticleComment(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [ArticleComment] "
                                           + " LEFT JOIN [Article] "
                                           + " ON [ArticleComment].[ArticleId] = [Article].[Id] "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleComment.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          CMSConstants.Entities.ArticleComment.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [ArticleComment].*, row_number() over(order by [ArticleComment].[Id] DESC) RowNum "
                                         + " , [Article].[Name] [ArticleName] "
                                         + " FROM [ArticleComment] "
                                         + " LEFT JOIN [Article] "
                                         + " ON [ArticleComment].[ArticleId] = [Article].[Id] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleComment.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          CMSConstants.Entities.ArticleComment.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
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
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllArticleCommentByStatus

        public static DataSet ViewGetAllArticleCommentByStatus(DataSet dataSet)
        {
            return ViewGetAllArticleCommentByStatus(null, dataSet);
        }

        public static DataSet ViewGetAllArticleCommentByStatus(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [ArticleComment] "
                                           + " LEFT JOIN [Article] "
                                           + " ON [ArticleComment].[ArticleId] = [Article].[Id] "
                                           + " WHERE [ArticleComment].[Status] = @Status "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleComment.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleComment.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [ArticleComment].*, row_number() over(order by [ArticleComment].[Id] DESC) RowNum "
                                         + " , [Article].[Name] [ArticleName] "
                                         + " FROM [ArticleComment] "
                                         + " LEFT JOIN [Article] "
                                         + " ON [ArticleComment].[ArticleId] = [Article].[Id] "
                                         + " WHERE [ArticleComment].[Status] = @Status "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleComment.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleComment.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input)
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
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = status;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllArticleCommentByArticleId

        public static DataSet ViewGetAllArticleCommentByArticleId(DataSet dataSet)
        {
            return ViewGetAllArticleCommentByArticleId(null, dataSet);
        }

        public static DataSet ViewGetAllArticleCommentByArticleId(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [ArticleComment] "
                                           + " LEFT JOIN [Article] "
                                           + " ON [ArticleComment].[ArticleId] = [Article].[Id] "
                                           + " WHERE [ArticleComment].[ArticleId] = @ArticleId "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleComment.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleComment.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [ArticleComment].*, row_number() over(order by [ArticleComment].[Id] DESC) RowNum "
                                         + " , [Article].[Name] [ArticleName] "
                                         + " FROM [ArticleComment] "
                                         + " LEFT JOIN [Article] "
                                         + " ON [ArticleComment].[ArticleId] = [Article].[Id] "
                                         + " WHERE [ArticleComment].[ArticleId] = @ArticleId "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.ArticleComment.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.ArticleComment.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
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
            int articleId =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        CMSConstants.Paging.Direction.ArticleId]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = articleId;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("ArticleComment");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("ArticleId", typeof(int));
            table.Columns.Add("PId", typeof(int));
            table.Columns.Add("Status");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Columns.Add("Phone");
            table.Columns.Add("Subject");
            table.Columns.Add("Detail");
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