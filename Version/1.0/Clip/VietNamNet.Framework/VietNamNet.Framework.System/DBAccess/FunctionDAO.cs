using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.Framework.System.DBAccess
{
    public class FunctionDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [Function]" +
                                  "([ModuleId],[Ord],[Name],[Alias],[Detail],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@ModuleId, @Ord, @Name, @Alias, @Detail, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Alias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
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
                throw new Exception("FunctionDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [Function] Set" +
                                  " [ModuleId] = @ModuleId, [Ord] = @Ord, [Name] = @Name, [Alias] = @Alias, [Detail] = @Detail, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Alias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Detail", SqlDbType.NVarChar, 4000, ParameterDirection.Input),
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
                throw new Exception("FunctionDAO::Update::Error", ex);
            }
        }

        public static void UpdateFunctionOrder(DataRow dataRow)
        {
            UpdateFunctionOrder(null, dataRow);
        }

        public static void UpdateFunctionOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = @"IF (@Id = 0) " +
                    "   UPDATE [Function] " +
                    "   SET [Ord] = [Ord] + 1 " +
                    "   WHERE [Ord] > @Ord " +
                    "   AND [ModuleId] = @ModuleId " +
                    "   AND (ISNULL(flag, '') = '') " +
                    " ELSE IF (@Ord > @OldOrd) " +
                    "   UPDATE [Function] " +
                    "   SET [Ord] = [Ord] - 1 " +
                    "   WHERE [Id] <> @Id " +
                    "   AND [ModuleId] = @ModuleId " +
                    "   AND [Ord] <= @Ord " +
                    "   AND [Ord] > @OldOrd " +
                    "   AND (ISNULL(flag, '') = '') " +
                    " ELSE IF (@Ord < @OldOrd) " +
                    "   UPDATE [Function] " +
                    "   SET [Ord] = [Ord] + 1 " +
                    "   WHERE [Id] <> @Id " +
                    "   AND [ModuleId] = @ModuleId " +
                    "   AND [Ord] >= @Ord " +
                    "   AND [Ord] < @OldOrd " +
                    "   AND (ISNULL(flag, '') = '') ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@OldOrd", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, procedureName, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("FunctionDAO::UpdateFunctionOrder::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [Function] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("FunctionDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [Function] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("FunctionDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetFunctionByAlias(DataRow dataRow)
        {
            return GetFunctionByAlias(null, dataRow);
        }

        public static DataTable GetFunctionByAlias(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM [Function] WHERE [Id] <> @Id AND [Alias] = @Alias AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Alias", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("FunctionDAO::GetFunctionByAlias::Error", ex);
            }
        }

        public static DataTable GetFunctionByModuleId(DataRow dataRow)
        {
            return GetFunctionByModuleId(null, dataRow);
        }

        public static DataTable GetFunctionByModuleId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM [Function] WHERE [ModuleId] = @ModuleId AND (ISNULL(flag, '') = '') ORDER BY [Ord]";
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
                throw new Exception("FunctionDAO::GetFunctionByModuleId::Error", ex);
            }
        }

        #region ViewGetAllFunction

        public static DataSet ViewGetAllFunction(DataSet dataSet)
        {
            return ViewGetAllFunction(null, dataSet);
        }

        public static DataSet ViewGetAllFunction(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) FROM ( "
                                           + "SELECT [Function].[flag] FF, [Module].[flag] MF "
                                           + " FROM [Function] "
                                           + " LEFT JOIN [Module] "
                                           + " ON [Function].[ModuleId] = [Module].[Id] "
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.Function.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          SystemConstants.Entities.Function.Name)
                                           + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.Function.SearchColumnsInModule,
                                                          ModuleConstants.ConnectorString.OR_STRING,
                                                          SystemConstants.Entities.Module.Name)
                                           + " ) X WHERE ISNULL(FF, '')='' AND ISNULL(MF, '')='' ";

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT *, row_number() over(order by [ModuleName], [Ord]) RowNum FROM ( "
                                         + " SELECT [Function].*, [Module].[Name] ModuleName, [Function].[flag] FF, [Module].[flag] MF "
                                         + " FROM [Function] "
                                         + " LEFT JOIN [Module] "
                                         + " ON [Function].[ModuleId] = [Module].[Id] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.Function.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          SystemConstants.Entities.Function.Name)
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          SystemConstants.Entities.Function.SearchColumnsInModule,
                                                          ModuleConstants.ConnectorString.OR_STRING,
                                                          SystemConstants.Entities.Module.Name)
                                         + " ) X WHERE ISNULL(FF, '')='' AND ISNULL(MF, '')='' "
                                         + " ) Y WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";


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

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [Function] Where (ISNULL(flag, '') = '') ORDER BY [ModuleId], [Ord], [Name]";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("FunctionDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("Function");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("ModuleId", typeof(int));
            table.Columns.Add("Ord", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("Alias");
            table.Columns.Add("Detail");
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