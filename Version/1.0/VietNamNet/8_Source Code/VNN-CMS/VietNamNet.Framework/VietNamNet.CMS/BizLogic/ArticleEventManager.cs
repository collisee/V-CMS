using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.BizLogic
{
    /// <summary>
    /// Summary description for ArticleEventManager.
    /// </summary>
    public class ArticleEventManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case CMSConstants.Services.CommonActions.SAVE:
                    DoSave(param);
                    break;
                case CMSConstants.Services.CommonActions.DELETE:
                    DoDelete(param);
                    break;
                case CMSConstants.Services.CommonActions.LOAD:
                    DoLoad(param);
                    break;
                case CMSConstants.Services.CommonActions.LOAD_ENCODE:
                    DoLoadEncode(param);
                    break;
                case CMSConstants.Services.CommonActions.LISTALL:
                    ListAll(param);
                    break;
                case CMSConstants.Services.ArticleEventManager.Actions.LoadSimple:
                    LoadSimple(param);
                    break;
                case CMSConstants.Services.ArticleEventManager.Actions.ViewGetAllArticleEvent:
                    ViewGetAllArticleEvent(param);
                    break;
                case CMSConstants.Services.ArticleEventManager.Actions.ViewGetAllArticleEventByCategory:
                    ViewGetAllArticleEventByCategory(param);
                    break;
                case CMSConstants.Services.ArticleEventManager.Actions.ViewGetAllArticleEventByManager:
                    ViewGetAllArticleEventByManager(param);
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
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id]) == 0)
                {
                    //Insert ArticleEvent
                    ArticleEventDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //ArticleEventCategory
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.ArticleEvent.Categories))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventCategoryDAO.UpdateArticleEventCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                                ArticleEventCategoryDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                            }
                        }
                    }

                    //ArticleEventItem
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.ArticleEvent.Items))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventItemDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Items].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    //Update ArticleEvent
                    ArticleEventDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //ArticleEventCategory
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.ArticleEvent.Categories))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventCategoryDAO.UpdateArticleEventCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                                ArticleEventCategoryDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventCategoryDAO.UpdateArticleEventCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                                ArticleEventCategoryDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventCategoryDAO.DeleteArticleEventCategoryOrder(tran,
                                                                              param.RawData.Tables[
                                                                                  CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                                ArticleEventCategoryDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                            }
                            //SaveStatus == empty
                            if (Nulls.IsNullOrEmpty(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.SaveStatus]))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories].Rows[i][
                                    CMSConstants.Entities.ArticleEventCategory.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventCategoryDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Categories].Rows[i]);
                            }
                        }
                    }

                    //ArticleEventItem
                    if (param.RawData.Tables.Contains(CMSConstants.Entities.ArticleEvent.Items))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventItemDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Items].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventItemDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Items].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //ArticleEventId
                                param.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items].Rows[i][
                                    CMSConstants.Entities.ArticleEventItem.FieldName.ArticleEventId] =
                                    param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEvent.FieldName.Id];
                                //Action
                                ArticleEventItemDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              CMSConstants.Entities.ArticleEvent.Items].Rows[i]);
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
                    SystemLogging.Error("ArticleEventManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleEventManager::DoSave::Error", ex.Message);
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
            ArticleEventDAO.Delete(param.RawData.Tables[0].Rows[0]);
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

                DataTable dt = ArticleEventDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = ArticleEventCategoryDAO.SelectCategoriesByArticleEventId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt2 = ArticleEventItemDAO.SelectItemsByArticleEventId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = CMSConstants.Entities.ArticleEvent.Name;
                dt1.TableName = CMSConstants.Entities.ArticleEvent.Categories;
                dt2.TableName = CMSConstants.Entities.ArticleEvent.Items;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(dt.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt2.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleEventManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleEventManager::DoLoad::Error", ex.Message);
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

                DataTable dt = ArticleEventDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = ArticleEventCategoryDAO.SelectCategoriesByArticleEventId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt2 = ArticleEventItemDAO.SelectItemsByArticleEventId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = CMSConstants.Entities.ArticleEvent.Name;
                dt1.TableName = CMSConstants.Entities.ArticleEvent.Categories;
                dt2.TableName = CMSConstants.Entities.ArticleEvent.Items;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt2.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleEventManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleEventManager::DoLoadEncode::Error", ex.Message);
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
            DataTable dt = ArticleEventDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function LoadSimple

        private void LoadSimple(Packet param)
        {
            DataTable dt = ArticleEventDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllArticleEvent

        private void ViewGetAllArticleEvent(Packet param)
        {
            param.RawData = ArticleEventDAO.ViewGetAllArticleEvent(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleEventByCategory

        private void ViewGetAllArticleEventByCategory(Packet param)
        {
            param.RawData = ArticleEventDAO.ViewGetAllArticleEventByCategory(param.RawData);
        }

        #endregion

        #region Function ViewGetAllArticleEventByManager

        private void ViewGetAllArticleEventByManager(Packet param)
        {
            param.RawData = ArticleEventDAO.ViewGetAllArticleEventByManager(param.RawData);
        }

        #endregion

        #endregion
    }
}