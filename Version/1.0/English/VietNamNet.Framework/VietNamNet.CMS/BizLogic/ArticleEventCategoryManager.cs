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
    /// Summary description for ArticleEventCategoryManager.
    /// </summary>
    public class ArticleEventCategoryManager : Facade
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
                case CMSConstants.Services.ArticleEventCategoryManager.Actions.OptimizeArticleEventCategory:
                    OptimizeArticleEventCategory(param);
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
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = BaseDAO.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.ArticleEventCategory.FieldName.Id]) == 0)
                {
                    ArticleEventCategoryDAO.UpdateArticleEventCategoryOrder(tran, param.RawData.Tables[0].Rows[0]);
                    ArticleEventCategoryDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);
                }
                else
                {
                    ArticleEventCategoryDAO.UpdateArticleEventCategoryOrder(tran, param.RawData.Tables[0].Rows[0]);
                    ArticleEventCategoryDAO.Update(tran, param.RawData.Tables[0].Rows[0]);
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("ArticleEventCategoryManager::Save::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("ArticleEventCategoryManager::Save::Error", ex.Message);
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
            ArticleEventCategoryDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = ArticleEventCategoryDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = ArticleEventCategoryDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = ArticleEventCategoryDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function OptimizeArticleEventCategory

        private void OptimizeArticleEventCategory(Packet param)
        {
            ArticleEventCategoryDAO.OptimizeArticleEventCategory(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #endregion
    }
}