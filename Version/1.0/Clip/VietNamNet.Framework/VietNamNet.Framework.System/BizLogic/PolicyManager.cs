using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.DBAccess;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.BizLogic
{
    /// <summary>
    /// Summary description for PolicyManager.
    /// </summary>
    public class PolicyManager : Facade
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
                case SystemConstants.Services.PolicyManager.Actions.GetPolicy:
                    GetPolicy(param);
                    break;
                case SystemConstants.Services.PolicyManager.Actions.GetPolicyByGroup:
                    GetPolicyByGroup(param);
                    break;
                case SystemConstants.Services.PolicyManager.Actions.SavePolicyByGroup:
                    SavePolicyByGroup(param);
                    break;
                case SystemConstants.Services.PolicyManager.Actions.GetPolicyByModule:
                    GetPolicyByModule(param);
                    break;
                case SystemConstants.Services.PolicyManager.Actions.SavePolicyByModule:
                    SavePolicyByModule(param);
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
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Policy.FieldName.Id]) == 0)
            {
                PolicyDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                PolicyDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            PolicyDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = PolicyDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = PolicyDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = PolicyDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPolicy

        private void GetPolicy(Packet param)
        {
            DataTable dt = PolicyDAO.GetPolicy(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetPolicyByGroup

        private void GetPolicyByGroup(Packet param)
        {
            DataTable dt = PolicyDAO.GetPolicyByGroup(param.RawData.Tables[0].Rows[0]);
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
                        Utilities.ParseInt(param.RawData.Tables[0].Rows[i][SystemConstants.Entities.Policy.FieldName.Id]) ==
                        0)
                    {
                        PolicyDAO.Insert(tran, param.RawData.Tables[0].Rows[i]);
                    }
                    else
                    {
                        PolicyDAO.UpdatePolicyOnly(tran, param.RawData.Tables[0].Rows[i]);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("PolicyManager::SavePolicyByGroup::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("PolicyManager::SavePolicyByGroup::Error", ex.Message);
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

        #region Function GetPolicyByModule

        private void GetPolicyByModule(Packet param)
        {
            DataTable dt = PolicyDAO.GetPolicyByModule(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function SavePolicyByModule

        private void SavePolicyByModule(Packet param)
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
                        Utilities.ParseInt(param.RawData.Tables[0].Rows[i][SystemConstants.Entities.Policy.FieldName.Id]) ==
                        0)
                    {
                        PolicyDAO.Insert(tran, param.RawData.Tables[0].Rows[i]);
                    }
                    else
                    {
                        PolicyDAO.UpdatePolicyOnly(tran, param.RawData.Tables[0].Rows[i]);
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("PolicyManager::SavePolicyByModule::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("PolicyManager::SavePolicyByModule::Error", ex.Message);
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