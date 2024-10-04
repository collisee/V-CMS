using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.BizLogic
{
    /// <summary>
    /// Summary description for CategoryPolicyManager.
    /// </summary>
    public class CategoryPolicyManager : Facade
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
                case CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByUserIdAndCategoryAlias:
                    GetPolicyByUserIdAndCategoryAlias(param);
                    break;
                case CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByUserIdAndCategoryId:
                    GetPolicyByUserIdAndCategoryId(param);
                    break;
                case CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByGroup:
                    GetPolicyByGroup(param);
                    break;
                case CMSConstants.Services.CategoryPolicyManager.Actions.SavePolicyByGroup:
                    SavePolicyByGroup(param);
                    break;
                case CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByCategory:
                    GetPolicyByCategory(param);
                    break;
                case CMSConstants.Services.CategoryPolicyManager.Actions.SavePolicyByCategory:
                    SavePolicyByCategory(param);
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
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CMSConstants.Entities.CategoryPolicy.FieldName.Id]) == 0)
            {
                CategoryPolicyDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                CategoryPolicyDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            CategoryPolicyDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPolicyByUserIdAndCategoryAlias

        private void GetPolicyByUserIdAndCategoryAlias(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.GetPolicyByUserIdAndCategoryAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPolicyByUserIdAndCategoryId

        private void GetPolicyByUserIdAndCategoryId(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.GetPolicyByUserIdAndCategoryId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPolicyByGroup

        private void GetPolicyByGroup(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.GetPolicyByGroup(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function SavePolicyByGroup

        private void SavePolicyByGroup(Packet param)
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
                    if (
                        Utilities.ParseInt(param.RawData.Tables[0].Rows[i][CMSConstants.Entities.CategoryPolicy.FieldName.Id]) ==
                        0)
                    {
                        CategoryPolicyDAO.Insert(tran, param.RawData.Tables[0].Rows[i]);
                    }
                    else
                    {
                        CategoryPolicyDAO.UpdatePolicyOnly(tran, param.RawData.Tables[0].Rows[i]);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("CategoryPolicyManager::SavePolicyByGroup::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("CategoryPolicyManager::SavePolicyByGroup::Error", ex.Message);
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

        #region Function GetPolicyByCategory

        private void GetPolicyByCategory(Packet param)
        {
            DataTable dt = CategoryPolicyDAO.GetPolicyByCategory(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function SavePolicyByCategory

        private void SavePolicyByCategory(Packet param)
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
                    if (
                        Utilities.ParseInt(param.RawData.Tables[0].Rows[i][CMSConstants.Entities.CategoryPolicy.FieldName.Id]) ==
                        0)
                    {
                        CategoryPolicyDAO.Insert(tran, param.RawData.Tables[0].Rows[i]);
                    }
                    else
                    {
                        CategoryPolicyDAO.UpdatePolicyOnly(tran, param.RawData.Tables[0].Rows[i]);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("CategoryPolicyManager::SavePolicyByCategory::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("CategoryPolicyManager::SavePolicyByCategory::Error", ex.Message);
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