using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.DBAccess
{
    public class CategoryDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [Category]" +
                                  "([PartitionId],[PId],[Ord],[Name],[Alias],[DisplayName],[Url],[Detail],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@PartitionId, @PId, @Ord, @Name, @Alias, @DisplayName, @Url, @Detail, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Alias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@DisplayName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Url", SqlDbType.NVarChar, 255, ParameterDirection.Input),
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
                throw new Exception("CategoryDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [Category] Set" +
                                  " [PartitionId] = @PartitionId, [PId] = @PId, [Ord] = @Ord, [Name] = @Name, [Alias] = @Alias, [DisplayName] = @DisplayName, [Url] = @Url, [Detail] = @Detail, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Name", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Alias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@DisplayName", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@Url", SqlDbType.NVarChar, 255, ParameterDirection.Input),
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
                throw new Exception("CategoryDAO::Update::Error", ex);
            }
        }

        public static void UpdateCategoryPIdAndOrder(DataRow dataRow)
        {
            UpdateCategoryPIdAndOrder(null, dataRow);
        }

        public static void UpdateCategoryPIdAndOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = CMSConstants.Services.CategoryManager.Actions.UpdateCategoryPIdAndOrder;
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
                throw new Exception("CategoryDAO::UpdateCategoryPIdAndOrder::Error", ex);
            }
        }

        public static void OptimizeCategory(DataRow dataRow)
        {
            OptimizeCategory(null, dataRow);
        }

        public static void OptimizeCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = CMSConstants.Services.CategoryManager.Actions.OptimizeCategory;
            try
            {
                ExecuteProcedure(sqlTransaction, procedureName);
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryDAO::OptimizeArticleCategory::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [Category] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("CategoryDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [Category].* "
                                  + " , [Parent].[Name] [ParentName] "
                                  + " , [Parent].[DisplayName] [ParentDisplayName] "
                                  + " FROM [Category]  "
                                  + " LEFT JOIN [Category] [Parent] "
                                  + " ON [Category].[PId] = [Parent].[Id] "
                                  + " WHERE [Category].[Id] = @Id "
                                  + " AND (ISNULL([Category].flag, '') = '')"
                                  + " AND (ISNULL([Parent].flag, '') = '')";
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
                throw new Exception("CategoryDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable GetCategoryByAlias(DataRow dataRow)
        {
            return GetCategoryByAlias(null, dataRow);
        }

        public static DataTable GetCategoryByAlias(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM [Category] WHERE [Id] <> @Id AND [Alias] = @Alias AND (ISNULL(flag, '') = '')";
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
                throw new Exception("CategoryDAO::GetCategoryByAlias::Error", ex);
            }
        }

        public static DataTable GetCategoryByUserId(DataRow dataRow)
        {
            return GetCategoryByUserId(null, dataRow);
        }

        public static DataTable GetCategoryByUserId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = @"GetCategoryByUserId";
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
                throw new Exception("CategoryDAO::GetCategoryByUserId::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "SELECT * FROM [Category] WHERE (ISNULL(flag, '') = '') ORDER BY [PId], [Ord], [Name]";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("CategoryDAO::SelectAll::Error", ex);
            }
        }

        #region ViewGetAllCategory

        public static DataSet ViewGetAllCategory(DataSet dataSet)
        {
            return ViewGetAllCategory(null, dataSet);
        }

        public static DataSet ViewGetAllCategory(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " FROM [Category] "
                                           +
                                           CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Category.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          CMSConstants.Entities.Category.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [Category].*, row_number() over(order by [Category].[PId], [Category].[Ord], [Category].[Name]) RowNum "
                                         + " , ISNULL([Parent].[Name], N'Root') [ParentName] "
                                         + " , ISNULL([Parent].[DisplayName], N'Root') [ParentDisplayName] "
                                         + " FROM [Category] "
                                         + " LEFT JOIN [Category] [Parent] "
                                         + " ON [Category].[PId] = [Parent].[Id] "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Category.SearchColumns,
                                                          ModuleConstants.ConnectorString.WHERE_STRING,
                                                          CMSConstants.Entities.Category.Name)
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

        #region ViewGetAllMyCategory

        public static DataSet ViewGetAllMyCategory(DataSet dataSet)
        {
            return ViewGetAllMyCategory(null, dataSet);
        }

        public static DataSet ViewGetAllMyCategory(SqlTransaction sqlTransaction, DataSet dataSet)
        {
            //generate query count record string
            string strQueryToCountRecord = "SELECT COUNT(*) "
                                           + " 		FROM ( "
                                           + "			SELECT [Category].* "
                                           + "				, [GroupMember].[GroupId] [GroupId] "
                                           + "				, Rank() over (PARTITION BY [Category].[Id] ORDER BY [Category].[PId], [Category].[Ord], [GroupMember].[GroupId]) AS [Rank] "
                                           + "			FROM [Category] "
                                           + "			LEFT JOIN [CategoryPolicy] "
                                           + "			On [CategoryPolicy].[CategoryId] = [Category].[Id] "
                                           + "			LEFT JOIN [GroupMember] "
                                           + "			On [CategoryPolicy].[GroupId] = [GroupMember].[GroupId] "
                                           + "			WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId) "
                                           + "			AND ([CategoryPolicy].[Val] = 1) "
                                           + "			AND (ISNULL([Category].flag, '') = '') "
                                           + "			AND (ISNULL([CategoryPolicy].flag, '') = '') "
                                           + "			AND (ISNULL([GroupMember].flag, '') = '') "
                                           + "		) [Category] WHERE [Rank] = 1 "
                                           + CommonDAO.SearchingQuery(
                                               dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                               CMSConstants.Entities.Category.SearchColumns,
                                               ModuleConstants.ConnectorString.AND_STRING,
                                               CMSConstants.Entities.Category.Name);

            //generate query string
            string strQueryToGetRecord = "SELECT * FROM ( "
                                         + "SELECT [Category].*, row_number() over(order by [Category].[PId], [Category].[Ord], [Category].[Name]) RowNum "
                                         + " 		FROM ( "
                                         + "			SELECT [Category].* "
                                         + "				, [GroupMember].[GroupId] [GroupId] "
                                         + "				, Rank() over (PARTITION BY [Category].[Id] ORDER BY [Category].[PId], [Category].[Ord], [GroupMember].[GroupId]) AS [Rank] "
                                         + "			FROM [Category] "
                                         + "			LEFT JOIN [CategoryPolicy] "
                                         + "			On [CategoryPolicy].[CategoryId] = [Category].[Id] "
                                         + "			LEFT JOIN [GroupMember] "
                                         + "			On [CategoryPolicy].[GroupId] = [GroupMember].[GroupId] "
                                         + "			WHERE (ISNULL([GroupMember].[UserId], -1) = @UserId) "
                                         + "			AND ([CategoryPolicy].[Val] = 1) "
                                         + "			AND (ISNULL([Category].flag, '') = '') "
                                         + "			AND (ISNULL([CategoryPolicy].flag, '') = '') "
                                         + "			AND (ISNULL([GroupMember].flag, '') = '') "
                                         + "		) [Category] WHERE [Rank] = 1 "
                                         + CommonDAO.SearchingQuery(dataSet.Tables[Constants.Paging.Direction.SearchingTableName],
                                                          CMSConstants.Entities.Category.SearchColumns,
                                                          ModuleConstants.ConnectorString.AND_STRING,
                                                          CMSConstants.Entities.Category.Name)
                                         + " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";

            //create parameter array to contain all needed parameter
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 50, ParameterDirection.Input),
                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                    CreateSqlPrameter("@UserId", SqlDbType.Int, 0, ParameterDirection.Input)
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
            int userId =
                Utilities.ParseInt(
                    dataSet.Tables[Constants.Paging.Direction.SearchingTableName].Rows[0][
                        Constants.Paging.Direction.UId]);
            paramArray[1].Value = (indexOfPage - 1) * pagesize + 1;
            paramArray[2].Value = indexOfPage * pagesize;
            paramArray[3].Value = userId;

            //Paging and Execute
            return CommonDAO.ExecuteManualPagingQuery(sqlTransaction, strQueryToCountRecord, strQueryToGetRecord, paramArray);
        }

        #endregion

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("Category");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("PartitionId", typeof(int));
            table.Columns.Add("PId", typeof(int));
            table.Columns.Add("Ord", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("Alias");
            table.Columns.Add("DisplayName");
            table.Columns.Add("Url");
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