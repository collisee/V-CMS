/************************************************************************/
/* File Name  : WebsitesDAO                                             */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.Websites.Core                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : Khai báo const của các Tracker                         */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 27/09/2010 Sondn: coding convention & add new RSS function           */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Core.DBAccess
{
    public class WebsitesDAO : BaseDAO
    {

        #region Categories

        #region GetCategoryByAlias

        public static DataTable GetCategoryByAlias(DataRow dataRow)
        {
            return GetCategoryByAlias(null, dataRow);
        }

        public static DataTable GetCategoryByAlias(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetCategoryByAlias";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetCategoryByAlias::Error", ex);
            }
        }

        #endregion

        #region GetSubCategory

        public static DataTable GetSubCategory(DataRow dataRow)
        {
            return GetSubCategory(null, dataRow);
        }

        public static DataTable GetSubCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetSubCategory";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetSubCategory::Error", ex);
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
            string procedureName = "Layout_GetCategoryArticleNumber";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@PartitionId", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetCategoryArticleNumber::Error", ex);
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
            string procedureName = "Layout_GetCategoryArticles";
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

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetCategoryArticles::Error", ex);
            }
        }

        #endregion

        #region GetPrimaryCategory

        public static DataTable GetPrimaryCategory(DataRow dataRow)
        {
            return GetPrimaryCategory(null, dataRow);
        }

        public static DataTable GetPrimaryCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetPrimaryCategory";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetPrimaryCategory::Error", ex);
            }
        }

        #endregion

        #endregion
               
        #region Articles

        #region GetTopArticles

        public static DataTable GetTopArticles(DataRow dataRow)
        {
            return GetTopArticles(null, dataRow);
        }

        public static DataTable GetTopArticles(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetTopArticles";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetTopArticles::Error", ex);
            }
        }

        #endregion

        #region GetMostReadArticles

        public static DataTable GetMostReadArticles(DataRow dataRow)
        {
            return GetMostReadArticles(null, dataRow);
        }

        public static DataTable GetMostReadArticles(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetMostReadArticles";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetMostReadArticles::Error", ex);
            }
        }

        #endregion

        #region GetArticlesTopRead

        public static DataTable GetArticlesTopRead(DataRow dataRow)
        {
            return GetArticlesTopRead(null, dataRow);
        }

        public static DataTable GetArticlesTopRead(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetArticlesTopRead";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticlesTopRead::Error", ex);
            }
        }

        #endregion

        #region GetArticlesTopComment

        public static DataTable GetArticlesTopComment(DataRow dataRow)
        {
            return GetArticlesTopComment(null, dataRow);
        }

        public static DataTable GetArticlesTopComment(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetArticlesTopComment";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticlesTopComment::Error", ex);
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
            string procedureName = "Layout_GetCategoryArticlesMore";
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

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetCategoryArticlesMore::Error", ex);
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
            string procedureName = "Layout_GetArticle";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticle::Error", ex);
            }
        }

        #endregion

        #region GetArticleByStatus

        public static DataTable GetArticleByStatus(DataRow dataRow)
        {
            return GetArticleByStatus(null, dataRow);
        }

        public static DataTable GetArticleByStatus(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetArticleByStatus";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                                                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticleByStatus::Error", ex);
            }
        }

        #endregion

        #region GetArticleByStatusAndId

        public static DataTable GetArticleByStatusAndId(DataRow dataRow)
        {
            return GetArticleByStatusAndId(null, dataRow);
        }

        public static DataTable GetArticleByStatusAndId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetArticleByStatusAndId";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                                                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticleByStatusAndId::Error", ex);
            }
        }

        #endregion

        #region GetArticleByStatusAndCategoryId

        public static DataTable GetArticleByStatusAndCategoryId(DataRow dataRow)
        {
            return GetArticleByStatusAndCategoryId(null, dataRow);
        }

        public static DataTable GetArticleByStatusAndCategoryId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetArticleByStatusAndCategoryId";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@Status", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                                                    CreateSqlPrameter("@CategoryId", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticleByStatusAndCategoryId::Error", ex);
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
            string procedureName = "Layout_GetArticleMedia";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@MediaType", SqlDbType.NVarChar, 255, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticleMedia::Error", ex);
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
            string procedureName = "Layout_GetTopMedia";
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

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetTopMedia::Error", ex);
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
            string procedureName = "Layout_GetArticleComment";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticleComment::Error", ex);
            }
        }

        #endregion

        #region GetArticleVNNId

        public static DataTable GetArticleVNNId(DataRow dataRow)
        {
            return GetArticleVNNId(null, dataRow);
        }

        public static DataTable GetArticleVNNId(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetArticleVNNId";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@ArticleId", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetArticleVNNId::Error", ex);
            }
        }

        #endregion

        #region GetSearchArticles

        public static DataTable GetSearchArticles(DataRow dataRow)
        {
            return GetSearchArticles(null, dataRow);
        }

        public static DataTable GetSearchArticles(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_GetSearchArticles";
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                                                {
                                                    CreateSqlPrameter("@Searchkeyword", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                                                    CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                                                    CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                                                };
                SetParameterValues(paramArray, dataRow);

                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetSearchArticles::Error", ex);
            }
        }

        #endregion

        #endregion

        #region Searching

        public static DataTable Search(DataRow dataRow)
        {
            return Search(null, dataRow);
        }

        public static DataTable Search(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = WebsitesConstants.Services.WebsitesManager.Actions.SearchArticleByKeyword;
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@KeyWords", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                        CreateSqlPrameter("@PublishDate", SqlDbType.NVarChar, 8, ParameterDirection.Input),
                        CreateSqlPrameter("@FirstIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input),
                        CreateSqlPrameter("@LastIndexRecord", SqlDbType.Int, 0, ParameterDirection.Input)
                    };
                SetParameterValues(paramArray, dataRow);
                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::Search::Error", ex);
            }
        }

        #endregion

        #region RSS

        public static DataTable GetRSSHome(DataRow dataRow)
        {
            return GetRSSHome(null, dataRow);
        }

        public static DataTable GetRSSHome(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_" + WebsitesConstants.Services.WebsitesManager.Actions.GetRSSHome;
            try
            {
                
                return ExecuteProcedure(sqlTransaction, procedureName).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetRSSHome::Error" + ex, ex);
            }
        }

        public static DataTable GetRSSByCategory(DataRow dataRow)
        {
            return GetRSSByCategory(null, dataRow);
        }

        public static DataTable GetRSSByCategory(SqlTransaction sqlTransaction, DataRow dataRow)
        {
            string procedureName = "Layout_" + WebsitesConstants.Services.WebsitesManager.Actions.GetRSSByCategory;
            try
            {
                SqlParameter[] paramArray = new SqlParameter[]
                    {
                        CreateSqlPrameter("@CategoryAlias", SqlDbType.NVarChar, 255, ParameterDirection.Input),
                    };
                SetParameterValues(paramArray, dataRow);
                return ExecuteProcedure(sqlTransaction, procedureName, paramArray).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("WebsitesDAO::GetRSSByCategory::Error", ex);
            }
        }

        #endregion
    }
}