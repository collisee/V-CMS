using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.DBAccess;

namespace VietNamNet.CMS.BizLogic
{
    /// <summary>
    /// Summary description for ArticleCategoryManager.
    /// </summary>
    public class ArticleCategoryManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

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
                case CMSConstants.Services.ArticleCategoryManager.Actions.OptimizeArticleCategory:
                    OptimizeArticleCategory(param);
                    break;
                case CMSConstants.Services.ArticleCategoryManager.Actions.GetArticlesByCategoryId:
                    GetArticlesByCategoryId(param);
                    break;
                case CMSConstants.Services.ArticleCategoryManager.Actions.SaveCategory:
                    SaveCategory(param);
                    break;
                default:
                    break;
            }

            //Log timer
            timer.Stop();
            string strAction = string.Format("{0}::{1}::Timer", param.ServiceName, param.Action);
            string strTimer = string.Format("{0} ms", Utilities.DisplayNumberFormat(timer.ElapsedMilliseconds));
            SystemLogging.Info(strAction, strTimer);

            //return
            return param;
        }

        #endregion

        #region Execute Actions

        #region Function DoSave

        private void DoSave(Packet param)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleCategory.FieldName.Id]) == 0)
                {
                    ArticleCategoryDAO.UpdateArticleCategoryOrder(tran, param.RawData.Tables[0].Rows[0]);
                    ArticleCategoryDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);
                }
                else
                {
                    ArticleCategoryDAO.UpdateArticleCategoryOrder(tran, param.RawData.Tables[0].Rows[0]);
                    ArticleCategoryDAO.Update(tran, param.RawData.Tables[0].Rows[0]);
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleCategoryManager::Save::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleCategoryManager::Save::Error", ex.Message);
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
            ArticleCategoryDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = ArticleCategoryDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = ArticleCategoryDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = ArticleCategoryDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetArticlesByCategoryId

        private void GetArticlesByCategoryId(Packet param)
        {
            DataTable dt = ArticleCategoryDAO.GetArticlesByCategoryId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function OptimizeArticleCategory

        private void OptimizeArticleCategory(Packet param)
        {
            ArticleCategoryDAO.OptimizeArticleCategory(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function SaveCategory

        private void SaveCategory(Packet param)
        {
            //Start Transaction
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                for (int i = 0; i < param.RawData.Tables[0].Rows.Count; i++)
                {
                    //SaveStatus == NEW
                    if (Utilities.StringCompare(
                        param.RawData.Tables[0].Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                        Constants.CommonStatus.NEW))
                    {
                        ArticleCategoryDAO.Insert(tran, param.RawData.Tables[0].Rows[i]);
                    }
                    //SaveStatus == UPDATE
                    if (Utilities.StringCompare(
                        param.RawData.Tables[0].Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                        Constants.CommonStatus.UPDATE))
                    {
                        ArticleCategoryDAO.Update(tran, param.RawData.Tables[0].Rows[i]);
                    }
                    //SaveStatus == DELETE
                    if (Utilities.StringCompare(
                        param.RawData.Tables[0].Rows[i][CMSConstants.Entities.ArticleCategory.FieldName.SaveStatus],
                        Constants.CommonStatus.DELETE))
                    {
                        ArticleCategoryDAO.Delete(tran, param.RawData.Tables[0].Rows[i]);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleCategoryManager::SaveArticleCategoryByGroup::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleCategoryManager::SaveArticleCategoryByGroup::Error", ex.Message);
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

        #endregion
    }
}