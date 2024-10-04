using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;

namespace VietNamNet.AddOn.Union.DBAccess
{
    public class UnionDAO : BaseDAO
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
                throw new Exception("UnionDAO::GetCategoryByAlias::Error", ex);
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
                                  " WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  " AND [Article].[Status] = N'Đã xuất bản' " +
                                  " AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) " +
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
                throw new Exception("UnionDAO::GetCategoryArticleNumber::Error", ex);
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
                                  "     SELECT [Article].*, row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC) RowNum  " +
                                  "     FROM [ArticleCategory] " +
                                  "     LEFT JOIN [Article] " +
                                  "     ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  "     WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  "     AND [Article].[Status] = N'Đã xuất bản' " +
                                  "     AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) " +
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
                throw new Exception("UnionDAO::GetCategoryArticles::Error", ex);
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
                                  "     SELECT [Article].*, row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC) RowNum  " +
                                  "     FROM [ArticleCategory] " +
                                  "     LEFT JOIN [Article] " +
                                  "     ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  "     WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  "     AND [Article].[Status] = N'Đã xuất bản' " +
                                  "     AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) " +
                                  "     AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  "     AND [ArticleCategory].[ArticleId] <> @ArticleId " +
                                  "     AND [ArticleCategory].[Ord] >= ( " +
                                  "             SELECT MAX([Ord]) FROM [ArticleCategory] " +
                                  "             WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  "             AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  "             AND [ArticleCategory].[ArticleId] = @ArticleId " +
                                  "             ) " +
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
                throw new Exception("UnionDAO::GetCategoryArticlesMore::Error", ex);
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
                                  " AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) " +
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
                throw new Exception("UnionDAO::GetArticle::Error", ex);
            }
        }

        #endregion

        #region GetArticleMedia

        public static DataTable GetArticleMedia(DataRow dataRow)
        {
            return GetArticleMedia(null, dataRow);
        }

        public static DataTable GetArticleMedia(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT '' [author] " +
                                  " , '' [link] " +
                                  " , [FileLink] [file] " +
                                  " , [Thumbnail] [image] " +
                                  " , [Detail] [description] " +
                                  " , REVERSE(SUBSTRING(REVERSE(FileLink), 0, CHARINDEX('/', REVERSE(FileLink)))) [title] " +
                                  " FROM [ArticleMedia] " +
                                  " WHERE [ArticleId] = @ArticleId " +
                                  " AND (ISNULL(@MediaType, '') = '' OR [MediaType] = @MediaType) " +
                                  " AND (ISNULL(flag, '') = '')" +
                                  " ORDER BY [Ord], [Id] DESC";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MediaType", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UnionDAO::GetArticleMedia::Error", ex);
            }
        }

        #endregion

        #region GetArticleComment

        public static DataTable GetArticleComment(DataRow dataRow)
        {
            return GetArticleComment(null, dataRow);
        }

        public static DataTable GetArticleComment(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT a.*, u.avatar " +
                                  " FROM ArticleComment AS a INNER JOIN " +
                                  " [User] AS u ON a.Name = u.FullName " +
                                  " WHERE [ArticleId] = @ArticleId" +
                                  " ORDER BY a.Created_At DESC";
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
                throw new Exception("UnionDAO::GetArticle::Error", ex);
            }
        }

        #endregion

        #region GetTopMedia

        public static DataTable GetTopMedia(DataRow dataRow)
        {
            return GetTopMedia(null, dataRow);
        }

        public static DataTable GetTopMedia(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string selectString = @"SELECT * FROM ( " +
                                  "     SELECT row_number() over(order by [ArticleCategory].[Ord], [Article].[Id] DESC, [ArticleMedia].[Ord]) RowNum  " +
                                  "         , '' [author] " +
                                  "         , '' [link] " +
                                  "         , [ArticleMedia].[FileLink] [file] " +
                                  "         , [ArticleMedia].[Thumbnail] [image] " +
                                  "         , [ArticleMedia].[Detail] [description] " +
                                  "         , REVERSE(SUBSTRING(REVERSE([ArticleMedia].[FileLink]), 0, CHARINDEX('/', REVERSE([ArticleMedia].[FileLink])))) [title] " +
                                  "     FROM [ArticleCategory] " +
                                  "     LEFT JOIN [Article] " +
                                  "     ON [Article].[Id] = [ArticleCategory].[ArticleId] " +
                                  "     LEFT JOIN [ArticleMedia] " +
                                  "     ON [ArticleMedia].[ArticleId] = [ArticleCategory].[ArticleId] " +
                                  "     WHERE [ArticleCategory].[PartitionId] = @PartitionId " +
                                  "     AND [Article].[Status] = N'Đã xuất bản' " +
                                  "     AND (DATEDIFF(ss, [Article].[PublishDate], GETDATE()) >= 0) " +
                                  "     AND [ArticleCategory].[CategoryId] = @CategoryId " +
                                  "     AND (ISNULL(@MediaType, '') = '' OR [ArticleMedia].[MediaType] = @MediaType) " +
                                  "     AND (ISNULL([ArticleMedia].flag, '') = '')" +
                                  "     AND (ISNULL([ArticleCategory].flag, '') = '')" +
                                  "     AND (ISNULL([Article].flag, '') = '')" +
                                  " ) X WHERE RowNum BETWEEN @FirstIndexRecord AND @LastIndexRecord";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@MediaType", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteQuery(sqlTransaction, selectString, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("UnionDAO::GetTopMedia::Error", ex);
            }
        }

        #endregion
    }
}