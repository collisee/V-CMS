using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.Layout.Mobile.DBAccess
{
    public class VNN4MobileDAO : BaseDAO
    {
        #region GetCategoryByAlias

        public static DataTable GetCategoryByAlias(DataRow dataRow)
        {
            return GetCategoryByAlias(null, dataRow);
        }

        public static DataTable GetCategoryByAlias(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT [Id] [CategoryId] " +
                                  " , [Name] [CategoryName] " +
                                  " , [DisplayName] [CategoryDisplayName] " +
                                  " , [PartitionId] [PartitionId] " +
                                  " FROM [Category] " +
                                  " WHERE [Alias] = @CategoryAlias AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VNN4MobileDAO::GetCategoryByAlias::Error", ex);
            }
        }

        #endregion

        #region GetCategoryArticleNumber

        public static DataTable GetCategoryArticleNumber(DataRow dataRow)
        {
            return GetCategoryArticleNumber(null, dataRow);
        }

        public static DataTable GetCategoryArticleNumber(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT COUNT(*) " +
                                  " FROM [ArticleCategory] " +
                                  " LEFT JOIN [Article] " +
                                  " ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  " WHERE [ArticleCategory].[PartitionId] = @PartitionId "+
                                  " AND [Article].[Status] = N'Đã xuất bản' " +
                                  " AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  " AND (ISNULL([ArticleCategory].flag, '') = '')" +
                                  " AND (ISNULL([Article].flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VNN4MobileDAO::GetCategoryArticleNumber::Error", ex);
            }
        }

        #endregion

        #region GetCategoryArticles

        public static DataTable GetCategoryArticles(DataRow dataRow)
        {
            return GetCategoryArticles(null, dataRow);
        }

        public static DataTable GetCategoryArticles(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM ( " +
                                  "     SELECT [Article].*, row_number() over(order by [Article].[Id] DESC) RowNum  " +
                                  "     FROM [ArticleCategory] " +
                                  "     LEFT JOIN [Article] " +
                                  "     ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  "     WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  "     AND [Article].[Status] = N'Đã xuất bản' " +
                                  "     AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  "     AND (ISNULL([ArticleCategory].flag, '') = '')" +
                                  "     AND (ISNULL([Article].flag, '') = '')" +
                                  " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VNN4MobileDAO::GetCategoryArticles::Error", ex);
            }
        }

        #endregion

        #region GetCategoryArticlesMore

        public static DataTable GetCategoryArticlesMore(DataRow dataRow)
        {
            return GetCategoryArticlesMore(null, dataRow);
        }

        public static DataTable GetCategoryArticlesMore(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM ( " +
                                  "     SELECT [Article].*, row_number() over(order by [Article].[Id] DESC) RowNum  " +
                                  "     FROM [ArticleCategory] " +
                                  "     LEFT JOIN [Article] " +
                                  "     ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  "     WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  "     AND [Article].[Status] = N'Đã xuất bản' " +
                                  "     AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  "     AND [ArticleCategory].[ArticleId] < @ArticleId " +
                                  //"     AND [ArticleCategory].[ArticleId] <> @ArticleId " +
                                  //"     AND [ArticleCategory].[Ord] >= ( "+
                                  //"             SELECT MAX([Ord]) FROM [ArticleCategory] " +
                                  //"             WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  //"             AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  //"             AND [ArticleCategory].[ArticleId] = @ArticleId " +
                                  //"             ) " +
                                  "     AND (ISNULL([ArticleCategory].flag, '') = '')" +
                                  "     AND (ISNULL([Article].flag, '') = '')" +
                                  " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VNN4MobileDAO::GetCategoryArticlesMore::Error", ex);
            }
        }

        #endregion

        #region GetArticle

        public static DataTable GetArticle(DataRow dataRow)
        {
            return GetArticle(null, dataRow);
        }

        public static DataTable GetArticle(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * " +
                                  " FROM [Article] " +
                                  " WHERE [Id] = @ArticleId " +
                                  " AND [Article].[Status] = N'Đã xuất bản' " +
                                  " AND (ISNULL(flag, '') = '')";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VNN4MobileDAO::GetArticle::Error", ex);
            }
        }

        #endregion

        #region GetTopArticle

        public static DataTable GetTopArticle(DataRow dataRow)
        {
            return GetTopArticle(null, dataRow);
        }

        public static DataTable GetTopArticle(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT TOP 5 [Article].* " +
                                  " , [Category].[Alias] [CategoryAlias] " +
                                  " FROM [Article] " +
                                  " LEFT JOIN [ArticleCategory] " +
                                  " ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  " LEFT JOIN [Category] " +
                                  " ON [Category].[Id] = [ArticleCategory].[CategoryId] " +
                                  " WHERE [Article].[Status] = N'Đã xuất bản' " +
                                  " AND (ISNULL([Article].flag, '') = '')" +
                                  " AND (ISNULL([ArticleCategory].flag, '') = '')" +
                                  " AND (ISNULL([Category].flag, '') = '')" +
                                  " ORDER BY [Article].[Id] DESC";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("VNN4MobileDAO::GetArticle::Error", ex);
            }
        }

        #endregion
    }
}