using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.AddOn.Messages.DBAccess
{
    public class MessageDeliveryDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [MessageDelivery]" +
                                  "([MessageId],[Status],[FromUserId],[ToUserId],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@MessageId, @Status, @FromUserId, @ToUserId, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@MessageId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FromUserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ToUserId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MessageDeliveryDAO::Insert::Error", ex);
            }
        }

        public static void InsertPersonal(DataRow dataRow)
        {
            InsertPersonal(null, dataRow);
        }

        public static void InsertPersonal(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [MessageDelivery]" +
                                  "([MessageId],[Status],[FromUserId],[ToUserId],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@Id, N'" + MessagesConstants.MessageStatus.UnRead + "', @Created_By, @ReceiverId, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag)";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MessageId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ReceiverId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MessageDeliveryDAO::InsertPersonal::Error", ex);
            }
        }

        public static void InsertGroup(DataRow dataRow)
        {
            InsertGroup(null, dataRow);
        }

        public static void InsertGroup(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [MessageDelivery]" +
                                  "([MessageId],[Status],[FromUserId],[ToUserId],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "(SELECT @Id, N'" + MessagesConstants.MessageStatus.UnRead + "', @Created_By, [UserId], @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag "+
                                  "FROM [GroupMember] WHERE [GroupId] = @ReceiverId AND ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MessageId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ReceiverId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MessageDeliveryDAO::InsertGroup::Error", ex);
            }
        }

        public static void InsertAllUsers(DataRow dataRow)
        {
            InsertAllUsers(null, dataRow);
        }

        public static void InsertAllUsers(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [MessageDelivery]" +
                                  "([MessageId],[Status],[FromUserId],[ToUserId],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "(SELECT @Id, N'" + MessagesConstants.MessageStatus.UnRead + "', @Created_By, [Id] AS [UserId], @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag "+
                                  " FROM [User] WHERE ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MessageId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MessageDeliveryDAO::InsertAllUsers::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [MessageDelivery] Set" +
                                  " [MessageId] = @MessageId, [Status] = @Status, [FromUserId] = @FromUserId, [ToUserId] = @ToUserId, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MessageId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FromUserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ToUserId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MessageDeliveryDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [MessageDelivery] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("MessageDeliveryDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [MessageDelivery].* " +
                                  " , [Message].[Subject] " +
                                  " , [Message].[Detail] " +
                                  " , [User].[FullName] [UserName] " +
                                  " FROM [MessageDelivery] " +
                                  " LEFT JOIN [Message] " +
                                  " ON [MessageDelivery].[MessageId] = [Message].[Id] " +
                                  " LEFT JOIN [User] " +
                                  " ON [MessageDelivery].[FromUserId] = [User].[Id] " +
                                  " WHERE [MessageDelivery].[Id] = @Id " +
                                  " AND (ISNULL([MessageDelivery].flag, '') = '')" +
                                  " AND (ISNULL([Message].flag, '') = '')";
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
                throw new Exception("MessageDeliveryDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [MessageDelivery] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("MessageDeliveryDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("MessageDelivery");
            table.Columns.Add("Id");
            table.Columns.Add("MessageId");
            table.Columns.Add("Status");
            table.Columns.Add("FromUserId");
            table.Columns.Add("ToUserId");
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