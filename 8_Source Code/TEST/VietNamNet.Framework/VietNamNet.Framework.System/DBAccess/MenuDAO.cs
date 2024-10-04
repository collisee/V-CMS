using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.Framework.System.DBAccess
{
    public class MenuDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [Menu]" +
                                  "([PId],[Ord],[Name],[DisplayName],[Link],[ModuleId],[Access],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@PId, @Ord, @Name, @DisplayName, @Link, @ModuleId, @Access, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                        CreateSqlPrameter("@DisplayName", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                        CreateSqlPrameter("@Link", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Access", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MenuDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [Menu] Set" +
                                  " [PId] = @PId, [Ord] = @Ord, [Name] = @Name, [DisplayName] = @DisplayName, [Link] = @Link, [ModuleId] = @ModuleId, [Access] = @Access, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                        CreateSqlPrameter("@DisplayName", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                        CreateSqlPrameter("@Link", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@ModuleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Access", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("MenuDAO::Update::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [Menu] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("MenuDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            //string selectString = @"Select * From [Menu] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            string selectString = @"SELECT [Menu].* "
                                  + " , [Parent].[Name] [ParentName] "
                                  + " , [Parent].[DisplayName] [ParentDisplayName] "
                                  + " , [Module].[Name] [ModuleName] "
                                  + " FROM [Menu]  "
                                  + " LEFT JOIN [Menu] [Parent] "
                                  + " ON [Menu].[PId] = [Parent].[Id] "
                                  + " LEFT JOIN [Module] "
                                  + " ON [Menu].[ModuleId] = [Module].[Id] "
                                  + " WHERE [Menu].[Id] = @Id "
                                  + " AND (ISNULL([Menu].flag, '') = '')"
                                  + " AND (ISNULL([Parent].flag, '') = '')"
                                  + " AND (ISNULL([Module].flag, '') = '')";
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
                throw new Exception("MenuDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetMenuByUserId(DataRow dataRow)
        {
            return GetMenuByUserId(null, dataRow);
        }

        public static DataTable GetMenuByUserId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = SystemConstants.Services.MenuManager.Actions.GetMenuByUserId;
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("MenuDAO::GetMenuByUserId::Error", ex);
            }
        }

        public static void UpdateMenuPIdAndOrder(DataRow dataRow)
        {
            UpdateMenuPIdAndOrder(null, dataRow);
        }

        public static void UpdateMenuPIdAndOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = SystemConstants.Services.MenuManager.Actions.UpdateMenuPIdAndOrder;
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_At", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Last_Modified_By", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteProcedure(sqlTransaction, procedureName, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("MenuDAO::UpdateMenuPIdAndOrder::Error", ex);
            }
        }

        public static void OptimizeMenu(DataRow dataRow)
        {
            OptimizeMenu(null, dataRow);
        }

        public static void OptimizeMenu(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = SystemConstants.Services.MenuManager.Actions.OptimizeMenu;
            try
            {
                ExecuteProcedure(sqlTransaction, procedureName);
            }
            catch (Exception ex)
            {
                throw new Exception("MenuDAO::UpdateMenuPIdAndOrder::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "SELECT * FROM [Menu] WHERE (ISNULL(flag, '') = '') " +
                                     " UNION ALL " +
                                     " SELECT -1 [Id], NULL [PId], 0 [Ord] " +
                                     " , N'Cá nhân' [Name], N'Cá nhân' [DisplayName] " +
                                     " , '' [Link], 0 [ModuleId], 0 [Access]" +
                                     " , getdate() [Created_At], 0 [Created_By], getdate() [Last_Modified_At], 0 [Last_Modified_By], NULL [flag] " +
                                     " ORDER BY [PId], [Ord], [Id]";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("MenuDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("Menu");
            table.Columns.Add("Id", typeof (int));
            table.Columns.Add("PId", typeof (int));
            table.Columns.Add("Ord", typeof (int));
            table.Columns.Add("Name");
            table.Columns.Add("DisplayName");
            table.Columns.Add("Link");
            table.Columns.Add("ModuleId", typeof (int));
            table.Columns.Add("Access", typeof (int));
            table.Columns.Add("Created_At", typeof (DateTime));
            table.Columns.Add("Created_By", typeof (int));
            table.Columns.Add("Last_Modified_At", typeof (DateTime));
            table.Columns.Add("Last_Modified_By", typeof (int));
            table.Columns.Add("Flag");
            table.Columns.Add("UserId", typeof (int));

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #endregion
    }
}