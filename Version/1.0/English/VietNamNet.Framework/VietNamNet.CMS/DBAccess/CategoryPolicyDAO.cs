using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.CMS.DBAccess
{
    public class CategoryPolicyDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [CategoryPolicy]" +
                                  "([GroupId],[CategoryId],[Val],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@GroupId, @CategoryId, @Val, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("CategoryPolicyDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [CategoryPolicy] Set" +
                                  " [GroupId] = @GroupId, [CategoryId] = @CategoryId, [Val] = @Val, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("CategoryPolicyDAO::Update::Error", ex);
            }
        }

        public static void UpdatePolicyOnly(DataRow dataRow)
        {
            UpdatePolicyOnly(null, dataRow);
        }

        public static void UpdatePolicyOnly(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"UPDATE [CategoryPolicy] SET" +
                                  " [GroupId] = @GroupId, [CategoryId] = @CategoryId, [Val] = @Val, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By " +
                                  " WHERE [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@GroupId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Val", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryPolicyDAO::UpdatePolicyOnly::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [CategoryPolicy] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("CategoryPolicyDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [CategoryPolicy] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("CategoryPolicyDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetPolicyByUserIdAndCategoryAlias(DataRow dataRow)
        {
            return GetPolicyByUserIdAndCategoryAlias(null, dataRow);
        }

        public static DataTable GetPolicyByUserIdAndCategoryAlias(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "GetPolicyByUserIdAndCategoryAlias";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryPolicyDAO::GetPolicyByUserIdAndCategoryAlias::Error", ex);
            }
        }

        public static DataTable GetPolicyByUserIdAndCategoryId(DataRow dataRow)
        {
            return GetPolicyByUserIdAndCategoryId(null, dataRow);
        }

        public static DataTable GetPolicyByUserIdAndCategoryId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "GetPolicyByUserIdAndCategoryId";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryPolicyDAO::GetPolicyByUserIdAndCategoryId::Error", ex);
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
                                  " SELECT P.[Id], P.[Val], P.[GroupId], P.[CategoryId], C.[Name] [CategoryName], C.[DisplayName] [CategoryDisplayName] " +
                                  "     , G.[Name] [GroupName], C.[PId] [CategoryPId], C.[Ord] [CategoryOrd], C.[Detail] [CategoryDetail] " +
                                  " FROM [CategoryPolicy] P " +
                                  " INNER JOIN [Category] C " +
                                  " ON P.[CategoryId] = C.[Id] " +
                                  " INNER JOIN [Group] G " +
                                  " ON P.[GroupId] = G.[Id] " +
                                  " WHERE P.[GroupId] = @GroupId " +
                                  " AND (ISNULL(P.flag, '') = '')" +
                                  " AND (ISNULL(C.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " UNION " +
                                  " SELECT 0, 0, G.[Id] [GroupId], C.[Id] [CategoryId], C.[Name] [CategoryName], C.[DisplayName] [CategoryDisplayName] " +
                                  "     , G.[Name] [GroupName], C.[PId] [CategoryPId], C.[Ord] [CategoryOrd], C.[Detail] [CategoryDetail] " +
                                  " FROM [Category] C " +
                                  " INNER JOIN [Group] G " +
                                  " ON G.[Id] = @GroupId " +
                                  " WHERE C.[Id] NOT IN (SELECT [CategoryId] FROM [CategoryPolicy] WHERE [GroupId] = @GroupId AND (ISNULL(flag, '') = '')) " +
                                  " AND (ISNULL(C.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " ) X " +
                                  " ORDER BY [CategoryPId], [CategoryOrd], [CategoryId], [CategoryName] ";
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
                throw new Exception("CategoryPolicyDAO::GetPolicyByGroup::Error", ex);
            }
        }

        public static DataTable GetPolicyByCategory(DataRow dataRow)
        {
            return GetPolicyByCategory(null, dataRow);
        }

        public static DataTable GetPolicyByCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            //string procedureName = "GetPolicyByGroup";
            string selectString = " SELECT * FROM ( " +
                                  " SELECT P.[Id], P.[Val], P.[GroupId], P.[CategoryId], C.[Name] [CategoryName], G.[Name] [GroupName] " +
                                  " FROM [CategoryPolicy] P " +
                                  " INNER JOIN [Category] C " +
                                  " ON P.[CategoryId] = C.[Id] " +
                                  " INNER JOIN [Group] G " +
                                  " ON P.[GroupId] = G.[Id] " +
                                  " WHERE P.[CategoryId] = @CategoryId " +
                                  " AND (ISNULL(P.flag, '') = '')" +
                                  " AND (ISNULL(C.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " UNION " +
                                  " SELECT 0, 0, G.[Id] [GroupId], C.[Id] [CategoryId], C.[Name] [CategoryName], G.[Name] [GroupName] " +
                                  " FROM [Category] C " +
                                  " INNER JOIN [Group] G " +
                                  " ON C.[Id] = @CategoryId " +
                                  " WHERE G.[Id] NOT IN (SELECT GroupId FROM [CategoryPolicy] WHERE [CategoryId] = @CategoryId AND (ISNULL(flag, '') = '')) " +
                                  " AND (ISNULL(C.flag, '') = '')" +
                                  " AND (ISNULL(G.flag, '') = '')" +
                                  " ) X " +
                                  " ORDER BY [GroupName] ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryPolicyDAO::GetPolicyByCategory::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [CategoryPolicy] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryPolicyDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("CategoryPolicy");
            table.Columns.Add("Id");
            table.Columns.Add("GroupId");
            table.Columns.Add("CategoryId");
            table.Columns.Add("Val");
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