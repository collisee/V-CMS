using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.Framework.System.DBAccess
{
    public class PolicyDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [Policy]" +
                                  "([GroupId],[ModuleId],[Val],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@GroupId, @ModuleId, @Val, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Val", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("PolicyDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [Policy] Set" +
                                  " [GroupId] = @GroupId, [ModuleId] = @ModuleId, [Val] = @Val, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Val", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("PolicyDAO::Update::Error", ex);
            }
        }

        public static void UpdatePolicyOnly(DataRow dataRow)
        {
            UpdatePolicyOnly(null, dataRow);
        }

        public static void UpdatePolicyOnly(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"UPDATE [Policy] SET" +
                                  " [GroupId] = @GroupId, [ModuleId] = @ModuleId, [Val] = @Val, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By " +
                                  " WHERE [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Val", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("PolicyDAO::UpdatePolicyOnly::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [Policy] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("PolicyDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [Policy] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("PolicyDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetPolicy(DataRow dataRow)
        {
            return GetPolicy(null, dataRow);
        }

        public static DataTable GetPolicy(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "GetPolicyByUserIdAndModuleAlias";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("PolicyDAO::GetPolicy::Error", ex);
            }
        }

        public static DataTable GetPolicyByGroup(DataRow dataRow)
        {
            return GetPolicyByGroup(null, dataRow);
        }

        public static DataTable GetPolicyByGroup(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            //string procedureName = "GetPolicyByGroup";
            string selectString = " SELECT * FROM ( " +
                                  " SELECT P.[Id], P.[Val], P.[GroupId], P.[ModuleId], M.[Name] [ModuleName], G.[Name] [GroupName] " +
                                  " FROM [Policy] P " +
                                  " INNER JOIN [Module] M " +
                                  " ON P.[ModuleId] = M.[Id] " +
                                  " INNER JOIN [Group] G " +
                                  " ON P.[GroupId] = G.[Id] " +
                                  " WHERE P.GroupId = @GroupId " +
                                  " AND (ISNULL(P.flag, '') = '')" +
                                  " AND (ISNULL(M.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " UNION " +
                                  " SELECT 0, 0, G.[Id] [GroupId], M.[Id] [ModuleId], M.[Name] [ModuleName], G.[Name] [GroupName] " +
                                  " FROM [Module] M " +
                                  " INNER JOIN [Group] G " +
                                  " ON G.[Id] = @GroupId " +
                                  " WHERE M.[Id] NOT IN (SELECT [ModuleId] FROM [Policy] WHERE [GroupId] = @GroupId AND (ISNULL(flag, '') = '')) " +
                                  " AND (ISNULL(M.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " ) X " +
                                  " ORDER BY [ModuleName] ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("PolicyDAO::GetPolicyByGroup::Error", ex);
            }
        }

        public static DataTable GetPolicyByModule(DataRow dataRow)
        {
            return GetPolicyByModule(null, dataRow);
        }

        public static DataTable GetPolicyByModule(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            //string procedureName = "GetPolicyByGroup";
            string selectString = " SELECT * FROM ( " +
                                  " SELECT P.[Id], P.[Val], P.[GroupId], P.[ModuleId], M.[Name] [ModuleName], G.[Name] [GroupName] " +
                                  " FROM [Policy] P " +
                                  " INNER JOIN [Module] M " +
                                  " ON P.[ModuleId] = M.[Id] " +
                                  " INNER JOIN [Group] G " +
                                  " ON P.[GroupId] = G.[Id] " +
                                  " WHERE P.[ModuleId] = @ModuleId " +
                                  " AND (ISNULL(P.flag, '') = '')" +
                                  " AND (ISNULL(M.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " UNION " +
                                  " SELECT 0, 0, G.[Id] [GroupId], M.[Id] [ModuleId], M.[Name] [ModuleName], G.[Name] [GroupName] " +
                                  " FROM [Module] M " +
                                  " INNER JOIN [Group] G " +
                                  " ON M.[Id] = @ModuleId " +
                                  " WHERE G.[Id] NOT IN (SELECT [GroupId] FROM [Policy] WHERE [ModuleId] = @ModuleId AND (ISNULL(flag, '') = '')) " +
                                  " AND (ISNULL(M.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " ) X " +
                                  " ORDER BY [GroupName] ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("PolicyDAO::GetPolicyByModule::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [Policy] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("PolicyDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("Policy");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("GroupId");
            table.Columns.Add("ModuleId", typeof(int));
            table.Columns.Add("Val", typeof(int));
            table.Columns.Add("Created_At", typeof(DateTime));
            table.Columns.Add("Created_By", typeof(int));
            table.Columns.Add("Last_Modified_At", typeof(DateTime));
            table.Columns.Add("Last_Modified_By", typeof(int));
            table.Columns.Add("Flag");
            table.Columns.Add("UserId", typeof(int));

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #endregion
    }
}