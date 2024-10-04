using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.BizLogic
{
    /// <summary>
    /// Summary description for ArticleManager.
    /// </summary>
    public class ArticleManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case BaseServices.CommonActions.SAVE:
                    DoSave(param);
                    break;
                case BaseServices.CommonActions.DELETE:
                    DoDelete(param);
                    break;
                case BaseServices.CommonActions.LOAD:
                    DoLoad(param);
                    break;
                case BaseServices.CommonActions.LOAD_ENCODE:
                    DoLoadEncode(param);
                    break;
                case BaseServices.CommonActions.LISTALL:
                    ListAll(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.LoadSimple:
                    LoadSimple(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticle:
                    ViewGetAllArticle(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleByCategory:
                    ViewGetAllArticleByCategory(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleByManager:
                    ViewGetAllArticleByManager(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNews:
                    ViewGetAllArticleForPopupInsertNews(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.ViewGetAllArticleForPopupInsertNewsWithoutCategory:
                    ViewGetAllArticleForPopupInsertNewsWithoutCategory(param);
                    break;
                case CMSConstants.Services.ArticleManager.Actions.SearchArticleByKeyword:
                    SearchArticleByKeyword(param);
                    break;
                default:
                    break;
            }
            return param;
        }

        #endregion

        #region Execute Actions

        #region Function DoSave

        private void DoSave(Packet param)
        {
            //Start Transaction
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();


                //Add New
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id]) == 0)
                {
                    //Init VersionId
                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.VersionId] = 0;

                    //Insert Article
                    ArticleDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //ArticleCategory
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.Article.Categories))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //ArticleContentTypeId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.ArticleContentTypeId];
                                //Url
                                //param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                //    CMSConstants.Entities.ArticleCategory.FieldName.Url] =
                                //    param.RawData.Tables[0].Rows[0][
                                //        CMSConstants.Entities.Article.FieldName.Url];
                                //PublishDate
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.PublishDate];
                                //Action
                                ArticleCategoryDAO.UpdateArticleCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.Article.Categories].Rows[i]);
                                ArticleCategoryDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Categories].Rows[i]);
                            }
                        }
                    }

                    //ArticleMedia
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.Article.Media))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //Action
                                ArticleMediaDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Media].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    //ArticleVersion
                    ArticleVersionDAO.InsertNewVersion(tran, param.RawData.Tables[0].Rows[0]);

                    //Update VersionId
                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.VersionId] =
                        Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.VersionId]) + 1;
                    //Update Article
                    ArticleDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //ArticleCategory
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.Article.Categories))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //ArticleContentTypeId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.ArticleContentTypeId];
                                //Url
                                //param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                //    CMSConstants.Entities.ArticleCategory.FieldName.Url] =
                                //    param.RawData.Tables[0].Rows[0][
                                //        CMSConstants.Entities.Article.FieldName.Url];
                                //PublishDate
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.PublishDate];
                                //Action
                                ArticleCategoryDAO.UpdateArticleCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.Article.Categories].Rows[i]);
                                ArticleCategoryDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Categories].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //ArticleContentTypeId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.ArticleContentTypeId];
                                //Url
                                //param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                //    CMSConstants.Entities.ArticleCategory.FieldName.Url] =
                                //    param.RawData.Tables[0].Rows[0][
                                //        CMSConstants.Entities.Article.FieldName.Url];
                                //PublishDate
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.PublishDate];
                                //Action
                                ArticleCategoryDAO.UpdateArticleCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.Article.Categories].Rows[i]);
                                ArticleCategoryDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Categories].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //ArticleContentTypeId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.ArticleContentTypeId];
                                //Url
                                //param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                //    CMSConstants.Entities.ArticleCategory.FieldName.Url] =
                                //    param.RawData.Tables[0].Rows[0][
                                //        CMSConstants.Entities.Article.FieldName.Url];
                                //PublishDate
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.PublishDate];
                                //Action
                                ArticleCategoryDAO.DeleteArticleCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.Article.Categories].Rows[i]);
                                ArticleCategoryDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Categories].Rows[i]);
                            }
                            //SaveStatus == empty
                            if (Nulls.IsNullOrEmpty(
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus]))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //ArticleContentTypeId
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.ArticleContentTypeId] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.ArticleContentTypeId];
                                //Url
                                //param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                //    CMSConstants.Entities.ArticleCategory.FieldName.Url] =
                                //    param.RawData.Tables[0].Rows[0][
                                //        CMSConstants.Entities.Article.FieldName.Url];
                                //PublishDate
                                param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleCategory.FieldName.PublishDate] =
                                    param.RawData.Tables[0].Rows[0][
                                        CMSConstants.Entities.Article.FieldName.PublishDate];
                                //Action
                                ArticleCategoryDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Categories].Rows[i]);
                            }
                        }
                    }

                    //ArticleMedia
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.Article.Media))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //Action
                                ArticleMediaDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Media].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //Action
                                ArticleMediaDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Media].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //ArticleId
                                param.RawData.Tables[CMSConstants.Entities.Article.Media].Rows[i][
                                    CMSConstants.Entities.ArticleMedia.FieldName.ArticleId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.Article.FieldName.Id];
                                //Action
                                ArticleMediaDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.Article.Media].Rows[i]);
                            }
                        }
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleManager::DoSave::Error", ex.Message);
                }
                if (tran != null) tran.Rollback();
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            //Start Transaction
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();


                ArticleDAO.Delete(tran, param.RawData.Tables[0].Rows[0]);

                //ArticleCategory
                if (param.RawData.Tables.Contains(CMSConstants.Entities.Article.Categories))
                {
                    for (int i = 0;
                         i < param.RawData.Tables[CMSConstants.Entities.Article.Categories].Rows.Count;
                         i++)
                    {
                        //Action
                        ArticleCategoryDAO.DeleteArticleCategoryOrder(tran,
                                                                      param.RawData.Tables[
                                                                          CMSConstants.Entities.Article.Categories].Rows[i]);
                        ArticleCategoryDAO.Delete(tran,
                                                  param.RawData.Tables[
                                                      CMSConstants.Entities.Article.Categories].Rows[i]);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleManager::DoDelete::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleManager::DoDelete::Error", ex.Message);
                }
                if (tran != null) tran.Rollback();
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            //Start Transaction
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                DataTable dt = ArticleDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = ArticleCategoryDAO.SelectCategoriesByArticleId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt2 = ArticleMediaDAO.SelectMediaByArticleId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt3 = ArticleVersionDAO.SelectVersionsByArticleId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = CMSConstants.Entities.Article.Name;
                dt1.TableName = CMSConstants.Entities.Article.Categories;
                dt2.TableName = CMSConstants.Entities.Article.Media;
                dt3.TableName = CMSConstants.Entities.Article.Versions;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(dt.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));
                param.RawData.Tables.Add(dt2.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt3.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleManager::DoLoad::Error", ex.Message);
                }
                if (tran != null) tran.Rollback();

                //Clear data
                param.RawData.Tables.Clear();
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            //Start Transaction
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                DataTable dt = ArticleDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = ArticleCategoryDAO.SelectCategoriesByArticleId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt2 = ArticleMediaDAO.SelectMediaByArticleId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt3 = ArticleVersionDAO.SelectVersionsByArticleId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = CMSConstants.Entities.Article.Name;
                dt1.TableName = CMSConstants.Entities.Article.Categories;
                dt2.TableName = CMSConstants.Entities.Article.Media;
                dt3.TableName = CMSConstants.Entities.Article.Versions;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt2.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt3.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleManager::DoLoadEncode::Error", ex.Message);
                }
                if (tran != null) tran.Rollback();

                //Clear data
                param.RawData.Tables.Clear();
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = ArticleDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function LoadSimple

        private void LoadSimple(Packet param)
        {
            DataTable dt = ArticleDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllArticle

        private void ViewGetAllArticle(Packet param)
        {
            param.RawData = ArticleDAO.ViewGetAllArticle(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleByCategory

        private void ViewGetAllArticleByCategory(Packet param)
        {
            param.RawData = ArticleDAO.ViewGetAllArticleByCategory(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleByManager

        private void ViewGetAllArticleByManager(Packet param)
        {
            param.RawData = ArticleDAO.ViewGetAllArticleByManager(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleForPopupInsertNews

        private void ViewGetAllArticleForPopupInsertNews(Packet param)
        {
            param.RawData = ArticleDAO.ViewGetAllArticleForPopupInsertNews(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleForPopupInsertNewsWithoutCategory

        private void ViewGetAllArticleForPopupInsertNewsWithoutCategory(Packet param)
        {
            param.RawData = ArticleDAO.ViewGetAllArticleForPopupInsertNewsWithoutCategory(param.RawData);
        }

        #endregion

        #region Search

        private void SearchArticleByKeyword(Packet param)
        {
            param.RawData = ArticleDAO.ViewGetAllArticleForPopupInsertNewsWithoutCategory(param.RawData);
        }

        #endregion

        #endregion
    }
}