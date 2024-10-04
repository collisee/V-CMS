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
    /// Summary description for FunctionManager.
    /// </summary>
    public class FunctionManager : Facade
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
                case SystemConstants.Services.FunctionManager.Actions.ViewGetAllFunction:
                    ViewGetAllFunction(param);
                    break;
                case SystemConstants.Services.FunctionManager.Actions.GetFunctionByAlias:
                    GetFunctionByAlias(param);
                    break;
                case SystemConstants.Services.FunctionManager.Actions.GetFunctionByModuleId:
                    GetFunctionByModuleId(param);
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

                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Function.FieldName.Id]) == 0)
                {
                    FunctionDAO.UpdateFunctionOrder(tran, param.RawData.Tables[0].Rows[0]);
                    FunctionDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);
                }
                else
                {
                    FunctionDAO.UpdateFunctionOrder(tran, param.RawData.Tables[0].Rows[0]);
                    FunctionDAO.Update(tran, param.RawData.Tables[0].Rows[0]);
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("FunctionManager::Save::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("FunctionManager::Save::Error", ex.Message);
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
            FunctionDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = FunctionDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = FunctionDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = FunctionDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetFunctionByAlias

        private void GetFunctionByAlias(Packet param)
        {
            DataTable dt = FunctionDAO.GetFunctionByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetFunctionByModuleId

        private void GetFunctionByModuleId(Packet param)
        {
            DataTable dt = FunctionDAO.GetFunctionByModuleId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllFunction

        private void ViewGetAllFunction(Packet param)
        {
            param.RawData = FunctionDAO.ViewGetAllFunction(param.RawData);
        }

        #endregion

        #endregion
    }
}