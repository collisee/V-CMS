using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.CMS.DBAccess
{
    public class ArticleCategoryDAO : BaseDAO
    {
        #region Standard Function

        public static void Insert(DataRow dataRow)
        {
            Insert(null, dataRow);
        }

        public static void Insert(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string insertString = "Insert Into [ArticleCategory]" +
                                  "([CategoryId],[PartitionId],[ArticleId],[Ord],[ArticleContentTypeId],[Url],[PublishDate],[PrimaryCategory],[Created_At],[Created_By],[Last_Modified_At],[Last_Modified_By],[flag]) " +
                                  "Values(@CategoryId, @PartitionId, @ArticleId, @Ord, @ArticleContentTypeId, @Url, @PublishDate, @PrimaryCategory, @Created_At, @Created_By, @Last_Modified_At, @Last_Modified_By, @Flag) " +
                                  "SELECT @Id = SCOPE_IDENTITY()";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Output),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleContentTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Url", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PrimaryCategory", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleCategoryDAO::Insert::Error", ex);
            }
        }

        public static void Update(DataRow dataRow)
        {
            Update(null, dataRow);
        }

        public static void Update(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"Update [ArticleCategory] Set" +
                                  " [CategoryId] = @CategoryId, [PartitionId] = @PartitionId, [ArticleId] = @ArticleId, [Ord] = @Ord, [ArticleContentTypeId] = @ArticleContentTypeId, [Url] = @Url, [PublishDate] = @PublishDate, [PrimaryCategory] = @PrimaryCategory, [Created_At] = @Created_At, [Created_By] = @Created_By, [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = @flag " +
                                  " Where [Id] = @Id AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Ord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleContentTypeId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@Url", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.DateTime, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PrimaryCategory", SqlDbType.Int, 0, ParameterDirection.Input),
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
                throw new Exception("ArticleCategoryDAO::Update::Error", ex);
            }
        }

        public static void UpdateArticleCategoryOrder(DataRow dataRow)
        {
            UpdateArticleCategoryOrder(null, dataRow);
        }

        public static void UpdateArticleCategoryOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string updateString = @"IF (@Id <= 0 OR @Ord = @OldOrd) " +
                                  "   UPDATE [ArticleCategory] " +
                                  "   SET [Ord] = [Ord] + 1 " +
                                  "   WHERE [Id] <> @Id" +
                                  "   AND [CategoryId] = @CategoryId " +
                                  "   AND [Ord] >= @Ord " +
                                  "   AND [Ord] <= 100 " +
                                  "   AND (ISNULL(flag, '') = '') " +
                                  " ELSE IF (@Ord > @OldOrd) " +
                                  "   UPDATE [ArticleCategory] " +
                                  "   SET [Ord] = [Ord] - 1 " +
                                  "   WHERE [Id] <> @Id " +
                                  "   AND [CategoryId] = @CategoryId " +
                                  "   AND [Ord] <= @Ord " +
                                  "   AND [Ord] > @OldOrd " +
                                  "   AND [Ord] <= 100 " +
                                  "   AND (ISNULL(flag, '') = '') " +
                                  " ELSE IF (@Ord < @OldOrd) " +
                                  "   UPDATE [ArticleCategory] " +
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
                throw new Exception("ArticleCategoryDAO::UpdateArticleCategoryOrder::Error", ex);
            }
        }

        public static void OptimizeArticleCategory(DataRow dataRow)
        {
            OptimizeArticleCategory(null, dataRow);
        }

        public static void OptimizeArticleCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = CMSConstants.Services.ArticleCategoryManager.Actions.OptimizeArticleCategory;
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
                throw new Exception("ArticleCategoryDAO::OptimizeArticleCategory::Error", ex);
            }
        }

        public static void DeleteArticleCategoryOrder(DataRow dataRow)
        {
            DeleteArticleCategoryOrder(null, dataRow);
        }

        public static void DeleteArticleCategoryOrder(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = @"UPDATE [ArticleCategory] " +
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
                throw new Exception("ArticleCategoryDAO::DeleteArticleCategoryOrder::Error", ex);
            }
        }

        public static void Delete(DataRow dataRow)
        {
            Delete(null, dataRow);
        }

        public static void Delete(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string deleteString =
                @"UPDATE [ArticleCategory] SET [Last_Modified_At] = @Last_Modified_At, [Last_Modified_By] = @Last_Modified_By, [flag] = 'D' WHERE [Id] = @Id ";
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
                throw new Exception("ArticleCategoryDAO::Delete::Error", ex);
            }
        }

        public static DataTable SelectOne(DataRow dataRow)
        {
            return SelectOne(null, dataRow);
        }

        public static DataTable SelectOne(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"Select * From [ArticleCategory] Where [Id] = @Id AND (ISNULL(flag, '') = '')";
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
                throw new Exception("ArticleCategoryDAO::SelectOne::Error", ex);
            }
        }

        public static DataTable SelectCategoriesByArticleId(DataRow dataRow)
        {
            return SelectCategoriesByArticleId(null, dataRow);
        }

        public static DataTable SelectCategoriesByArticleId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [ArticleCategory].* " +
                                  " , [ArticleCategory].[Ord] [OldOrd] " +
                                  " , [Category].[Name] [CategoryName] " +
                                  " , [Category].[Alias] [CategoryAlias] " +
                                  " , '' [SaveStatus] " +
                                  " FROM [ArticleCategory] " +
                                  " LEFT JOIN [Category] " +
                                  " ON [ArticleCategory].[CategoryId] = [Category].[Id] " +
                                  " WHERE [ArticleCategory].[ArticleId] = @Id " +
                                  " AND (ISNULL([ArticleCategory].flag, '') = '')" +
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
                throw new Exception("ArticleCategoryDAO::SelectCategoriesByArticleId::Error", ex);
            }
        }

        public static DataTable GetArticlesByCategoryId(DataRow dataRow)
        {
            return GetArticlesByCategoryId(null, dataRow);
        }

        public static DataTable GetArticlesByCategoryId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT TOP 100 [ArticleCategory].* " +
                                  " , [ArticleCategory].[Ord] [OldOrd] " +
                                  " , [Article].[Name] [ArticleName] " +
                                  " , '' [SaveStatus] " +
                                  " FROM [ArticleCategory] " +
                                  " LEFT JOIN [Article] " +
                                  " ON [ArticleCategory].[ArticleId] = [Article].[Id] " +
                                  " WHERE [ArticleCategory].[CategoryId] = @CategoryId " +
                                  " AND [Article].[Status] = N'"+ CMSConstants.ArticleStatus.Published + "' " +
                                  " AND (ISNULL([ArticleCategory].flag, '') = '')" +
                                  " AND (ISNULL([Article].flag, '') = '')" +
                                  " ORDER BY [ArticleCategory].[Ord], [ArticleCategory].[PublishDate]";
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
                throw new Exception("ArticleCategoryDAO::GetArticlesByCategoryId::Error", ex);
            }
        }

        public static DataTable SelectAll()
        {
            return SelectAll(null);
        }

        public static DataTable SelectAll(SqlTransaction sqlTransaction)
        {
            string selectAllString = "Select * From [ArticleCategory] Where (ISNULL(flag, '') = '')";
            try
            {
                return ExecuteQuery(sqlTransaction, selectAllString).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("ArticleCategoryDAO::SelectAll::Error", ex);
            }
        }

        public static DataTable GetTemplateTable()
        {
            DataTable table = new DataTable("ArticleCategory");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("CategoryId", typeof(int));
            table.Columns.Add("PartitionId", typeof(int));
            table.Columns.Add("ArticleId", typeof(int));
            table.Columns.Add("OldOrd", typeof(int));
            table.Columns.Add("Ord", typeof(int));
            table.Columns.Add("ArticleContentTypeId", typeof(int));
            table.Columns.Add("Url");
            table.Columns.Add("PublishDate", typeof(DateTime));
            table.Columns.Add("PrimaryCategory", typeof(int));
            table.Columns.Add("Created_At", typeof(DateTime));
            table.Columns.Add("Created_By", typeof(int));
            table.Columns.Add("Last_Modified_At", typeof(DateTime));
            table.Columns.Add("Last_Modified_By", typeof(int));
            table.Columns.Add("Flag");
            table.Columns.Add("SaveStatus");
            table.Columns.Add("CategoryName");
            table.Columns.Add("CategoryAlias");
            table.Columns.Add("ArticleName");

            return table;
        }

        public static DataRow GetTemplateRow()
        {
            return GetTemplateTable().NewRow();
        }

        #endregion
    }
}