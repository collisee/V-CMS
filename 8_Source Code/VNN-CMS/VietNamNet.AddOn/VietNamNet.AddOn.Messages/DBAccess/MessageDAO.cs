using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Messages.DBAccess
{
    public class MessageDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [Message]" +
                                  "([MsgType],[Status],[Name],[Subject],[Detail],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@MsgType, @Status, @Name, @Subject, @Detail, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@MsgType", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Subject", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
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
                throw new Exception("MessageDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [Message] Set" +
                                  " [MsgType] = @MsgType, [Status] = @Status, [Name] = @Name, [Subject] = @Subject, [Detail] = @Detail, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MsgType", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Subject", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NText, 1073741823, ParameterDirection.Input),
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
                throw new Exception("MessageDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [Message] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("MessageDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [Message] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("MessageDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetNewPrivateMessages(DataRow dataRow)
        {
            return GetNewPrivateMessages(null, dataRow);
        }

        public static DataTable GetNewPrivateMessages(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = "SELECT COUNT(*) "
                                           + " FROM [MessageDelivery] "
                                           + " LEFT JOIN [Message] "
                                           + " ON [MessageDelivery].[MessageId] = [Message].[Id] "
                                           + " LEFT JOIN [User] "
                                           + " ON [MessageDelivery].[FromUserId] = [User].[Id] "
                                           + " WHERE [MessageDelivery].[ToUserId] = @ReceiverId "
                                           //+ " AND [MessageDelivery].[Status] = @Status "
                                           + " AND [MessageDelivery].[Status] = N'" + MessagesConstants.MessageStatus.UnRead + "' "
                                           + " AND ISNULL([MessageDelivery].flag, '') = '' "
                                           + " AND ISNULL([User].flag, '') = '' ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ReceiverId", SqlDbType.Int, 0, ParameterDirection.Input)//,
                        //CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("MessageDAO::GetNewPrivateMessages::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [Message] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("MessageDAO::SelectAll::Error", ex);
            }
        }

        #region ViewGetAllMessages

        public static DataSet ViewGetAllMessages(DataSet dataSet)
        {
            return ViewGetAllMessages(null, dataSet);
        }

        public static DataSet ViewGetAllMessages(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [Message] "
                                           +
                                           CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          MessagesConstants.Entities.Message.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [Message].*, row_number() over(order by [Message].[Created_At] DESC, [Message].[Id] DESC) RowNum "
                                         + " , CASE WHEN LEN(CONVERT(nvarchar(255), [Message].[Detail])) <= 50 THEN [Message].[Detail] "
                                         + " ELSE SUBSTRING([Message].[Detail], 1, 50) + '...' "
                                         + " END AS [ShortDetail] "
                                         + " , CONVERT(nvarchar(12), [Message].[Created_At], 103) [Created_At1] "
                                         + " , CONVERT(nvarchar(12), [Message].[Created_At], 112) [Created_At2] "
                                         + " , [User].[FullName] [UserName] "
                                         + " FROM [Message] "
                                         + " LEFT JOIN [User] "
                                         + " ON [Message].[Created_By] = [User].[Id] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          MessagesConstants.Entities.Message.Name)
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

        #region ViewGetAllMyMessagesByStatus

        public static DataSet ViewGetAllMyMessagesByStatus(DataSet dataSet)
        {
            return ViewGetAllMyMessagesByStatus(null, dataSet);
        }

        public static DataSet ViewGetAllMyMessagesByStatus(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [Message] "
                                           + " WHERE [Created_By] = @UId "
                                           + " AND [Status] = @Status "
                                           +
                                           CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          MessagesConstants.Entities.Message.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT *, row_number() over(order by [Created_At] DESC, [Id] DESC) RowNum "
                                         + " , CASE WHEN LEN(CONVERT(nvarchar(255), [Detail])) <= 50 THEN [Detail] "
                                         + " ELSE SUBSTRING([Detail], 1, 50) + '...' "
                                         + " END AS [ShortDetail] "
                                         + " , CONVERT(nvarchar(12), [Created_At], 103) [Created_At1] "
                                         + " , CONVERT(nvarchar(12), [Created_At], 112) [Created_At2] "
                                         + " FROM [Message] "
                                         + " WHERE [Created_By] = @UId "
                                         + " AND [Status] = @Status "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          MessagesConstants.Entities.Message.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UId", SqlDbType.Int, 0, ParameterDirection.Input),
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
            int uid =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        Constants.Paging.Direction.UId]);
            string status = dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                Constants.Paging.Direction.Status].ToString();
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = uid;
            paramArray[4].Value = status;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllPrivateMessages

        public static DataSet ViewGetAllPrivateMessages(DataSet dataSet)
        {
            return ViewGetAllPrivateMessages(null, dataSet);
        }

        public static DataSet ViewGetAllPrivateMessages(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [MessageDelivery] "
                                           + " LEFT JOIN [Message] "
                                           + " ON [MessageDelivery].[MessageId] = [Message].[Id] "
                                           + " LEFT JOIN [User] "
                                           + " ON [MessageDelivery].[FromUserId] = [User].[Id] "
                                           + " WHERE [MessageDelivery].[ToUserId] = @UId "
                                           + " AND ISNULL([MessageDelivery].flag, '') = '' "
                                           + " AND ISNULL([User].flag, '') = '' "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          MessagesConstants.Entities.Message.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT row_number() over(order by [MessageDelivery].[Created_At] DESC, [MessageDelivery].[Id] DESC) RowNum "
                                         + " , [MessageDelivery].[Id] "
                                         + " , [MessageDelivery].[Status] "
                                         + " , [Message].[Subject] "
                                         + " , [Message].[Detail] "
                                         + " , CASE [MessageDelivery].[Status] "
                                         + "    WHEN N'" + MessagesConstants.MessageStatus.UnRead + "' THEN N'bold' "
                                         + "    ELSE N'' "
                                         + " END AS [CssClass] "
                                         + " , CASE WHEN LEN(CONVERT(nvarchar(255), [Message].[Detail])) <= 50 THEN [Message].[Detail] "
                                         + " ELSE SUBSTRING([Message].[Detail], 1, 50) + '...' "
                                         + " END AS [ShortDetail] "
                                         + " , CONVERT(nvarchar(12), [MessageDelivery].[Created_At], 103) [Created_At1] "
                                         + " , CONVERT(nvarchar(12), [MessageDelivery].[Created_At], 112) [Created_At2] "
                                         + " , [User].[FullName] [UserName] "
                                         + " FROM [MessageDelivery] "
                                         + " LEFT JOIN [Message] "
                                         + " ON [MessageDelivery].[MessageId] = [Message].[Id] "
                                         + " LEFT JOIN [User] "
                                         + " ON [MessageDelivery].[FromUserId] = [User].[Id] "
                                         + " WHERE [MessageDelivery].[ToUserId] = @UId "
                                         + " AND ISNULL([MessageDelivery].flag, '') = '' "
                                         + " AND ISNULL([User].flag, '') = '' "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          MessagesConstants.Entities.Message.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UId", SqlDbType.Int, 0, ParameterDirection.Input)
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
                        Constants.Paging.Direction.UId]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = uid;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        #region ViewGetAllPrivateMessagesByStatus

        public static DataSet ViewGetAllPrivateMessagesByStatus(DataSet dataSet)
        {
            return ViewGetAllPrivateMessagesByStatus(null, dataSet);
        }

        public static DataSet ViewGetAllPrivateMessagesByStatus(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [MessageDelivery] "
                                           + " LEFT JOIN [Message] "
                                           + " ON [MessageDelivery].[MessageId] = [Message].[Id] "
                                           + " LEFT JOIN [User] "
                                           + " ON [MessageDelivery].[FromUserId] = [User].[Id] "
                                           + " WHERE [MessageDelivery].[ToUserId] = @UId "
                                           + " AND [MessageDelivery].[Status] = @Status "
                                           + " AND ISNULL([MessageDelivery].flag, '') = '' "
                                           + " AND ISNULL([User].flag, '') = '' "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          MessagesConstants.Entities.Message.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT row_number() over(order by [MessageDelivery].[Created_At] DESC, [MessageDelivery].[Id] DESC) RowNum "
                                         + " , [MessageDelivery].[Id] "
                                         + " , [MessageDelivery].[Status] "
                                         + " , [Message].[Subject] "
                                         + " , [Message].[Detail] "
                                         + " , CASE [MessageDelivery].[Status] "
                                         + "    WHEN N'" + MessagesConstants.MessageStatus.UnRead + "' THEN N'bold' "
                                         + "    ELSE N'' "
                                         + " END AS [CssClass] "
                                         + " , CASE WHEN LEN(CONVERT(nvarchar(255), [Message].[Detail])) <= 50 THEN [Message].[Detail] "
                                         + " ELSE SUBSTRING([Message].[Detail], 1, 50) + '...' "
                                         + " END AS [ShortDetail] "
                                         + " , CONVERT(nvarchar(12), [MessageDelivery].[Created_At], 103) [Created_At1] "
                                         + " , CONVERT(nvarchar(12), [MessageDelivery].[Created_At], 112) [Created_At2] "
                                         + " , [User].[FullName] [UserName] "
                                         + " FROM [MessageDelivery] "
                                         + " LEFT JOIN [Message] "
                                         + " ON [MessageDelivery].[MessageId] = [Message].[Id] "
                                         + " LEFT JOIN [User] "
                                         + " ON [MessageDelivery].[FromUserId] = [User].[Id] "
                                         + " WHERE [MessageDelivery].[ToUserId] = @UId "
                                         + " AND [MessageDelivery].[Status] = @Status "
                                         + " AND ISNULL([MessageDelivery].flag, '') = '' "
                                         + " AND ISNULL([User].flag, '') = '' "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          MessagesConstants.Entities.Message.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          MessagesConstants.Entities.Message.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UId", SqlDbType.Int, 0, ParameterDirection.Input),
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
            int uid =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        Constants.Paging.Direction.UId]);
            string status = dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                Constants.Paging.Direction.Status].ToString();
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = uid;
            paramArray[4].Value = status;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("Message");
            table.Columns.Add("Id");
            table.Columns.Add("MsgType");
            table.Columns.Add("Status");
            table.Columns.Add("Name");
            table.Columns.Add("Subject");
            table.Columns.Add("Detail");
            table.Columns.Add("Created_At");
            table.Columns.Add("Created_By");
            table.Columns.Add("Last_Modified_At");
            table.Columns.Add("Last_Modified_By");
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