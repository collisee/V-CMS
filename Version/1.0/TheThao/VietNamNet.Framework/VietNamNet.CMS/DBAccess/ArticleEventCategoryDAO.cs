using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.CMS.DBAccess
{
    public class ArticleEventCategoryDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [ArticleEventCategory]" +
                                  "([ArticleEventId],[CategoryId],[Ord],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@ArticleEventId, @CategoryId, @Ord, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@ArticleEventId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleEventCategoryDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [ArticleEventCategory] Set" +
                                  " [ArticleEventId] = @ArticleEventId, [CategoryId] = @CategoryId, [Ord] = @Ord, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleEventId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleEventCategoryDAO::Update::Error", ex);
            }
        }

        public static void UpdateArticleEventCategoryOrder(DataRow dataRow)
        {
            UpdateArticleEventCategoryOrder(null, dataRow);
        }

        public static void UpdateArticleEventCategoryOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"IF (@Id <= 0) " +
                                  "   UPDATE [ArticleEventCategory] " +
                                  "   SET [Ord] = [Ord] + 1 " +
                                  "   WHERE [Ord] >= @Ord " +
                                  "   AND [Ord] <= 100 " +
                                  "   AND [CategoryId] = @CategoryId " +
                                  "   AND (ISNULL(flag, '') = '') " +
                                  " ELSE IF (@Ord > @OldOrd) " +
                                  "   UPDATE [ArticleEventCategory] " +
                                  "   SET [Ord] = [Ord] - 1 " +
                                  "   WHERE [Id] <> @Id " +
                                  "   AND [CategoryId] = @CategoryId " +
                                  "   AND [Ord] <= @Ord " +
                                  "   AND [Ord] > @OldOrd " +
                                  "   AND [Ord] <= 100 " +
                                  "   AND (ISNULL(flag, '') = '') " +
                                  " ELSE IF (@Ord < @OldOrd) " +
                                  "   UPDATE [ArticleEventCategory] " +
                                  "   SET [Ord] = [Ord] + 1 " +
                                  "   WHERE [Id] <> @Id " +
                                  "   AND [CategoryId] = @CategoryId " +
                                  "   AND [Ord] >= @Ord " +
                                  "   AND [Ord] < @OldOrd " +
                                  "   AND [Ord] <= 100 " +
                                  "   AND (ISNULL(flag, '') = '') ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@OldOrd", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, updateString, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleEventCategoryDAO::UpdateArticleEventCategoryOrder::Error", ex);
            }
        }

        public static void OptimizeArticleEventCategory(DataRow dataRow)
        {
            OptimizeArticleEventCategory(null, dataRow);
        }

        public static void OptimizeArticleEventCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = CMSConstants.Services.ArticleEventCategoryManager.Actions.OptimizeArticleEventCategory;
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteProcedure(sqlTransaction, procedureName, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleEventCategoryDAO::OptimizeArticleEventCategory::Error", ex);
            }
        }

        public static void DeleteArticleEventCategoryOrder(DataRow dataRow)
        {
            DeleteArticleEventCategoryOrder(null, dataRow);
        }

        public static void DeleteArticleEventCategoryOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = @"UPDATE [ArticleEventCategory] " +
                                   " SET [Ord] = [Ord] - 1 " +
                                   " WHERE [Ord] > @OldOrd " +
                                   " AND [Ord] <= 100 " +
                                   " AND [Id] <> @Id " +
                                   " AND [CategoryId] = @CategoryId " +
                                   " AND (ISNULL(flag, '') = '') ";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@OldOrd", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                ExecuteNonQuery(sqlTransaction, procedureName, paramArray);
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleEventCategoryDAO::DeleteArticleEventCategoryOrder::Error", ex);
            }
        }

        public static DataTable SelectCategoriesByArticleEventId(DataRow dataRow)
        {
            return SelectCategoriesByArticleEventId(null, dataRow);
        }

        public static DataTable SelectCategoriesByArticleEventId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [ArticleEventCategory].* " +
                                  " , [ArticleEventCategory].[Ord] [OldOrd] " +
                                  " , [Category].[Name] [CategoryName] " +
                                  " , [Category].[Alias] [CategoryAlias] " +
                                  " , '' [SaveStatus] " +
                                  " FROM [ArticleEventCategory] " +
                                  " LEFT JOIN [Category] " +
                                  " ON [ArticleEventCategory].[CategoryId] = [Category].[Id] " +
                                  " WHERE [ArticleEventCategory].[ArticleEventId] = @Id " +
                                  " AND (ISNULL([ArticleEventCategory].flag, '') = '')" +
                                  " AND (ISNULL([Category].flag, '') = '')";
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
                throw new Exception("ArticleEventCategoryDAO::SelectCategoriesByArticleEventId::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [ArticleEventCategory] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id";
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
                throw new Exception("ArticleEventCategoryDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [ArticleEventCategory] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("ArticleEventCategoryDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [ArticleEventCategory] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleEventCategoryDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("ArticleEventCategory");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("ArticleEventId", typeof(int));
            table.Columns.Add("CategoryId", typeof(int));
            table.Columns.Add("OldOrd", typeof(int));
            table.Columns.Add("Ord", typeof(int));
            table.Columns.Add("Created_At", typeof(DateTime));
            table.Columns.Add("Created_By", typeof(int));
            table.Columns.Add("Last_Modified_At", typeof(DateTime));
            table.Columns.Add("Last_Modified_By", typeof(int));
            table.Columns.Add("Flag");
            table.Columns.Add("SaveStatus");
            table.Columns.Add("CategoryName");
            table.Columns.Add("CategoryAlias");

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #endregion
    }
}