using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Advertisement.BizLogic
{
    /// <summary>
    /// Summary description for AdvertisementBlockManager.
    /// </summary>
    public class AdvertisementBlockManager : Facade
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
                case AdvertisementConstants.Services.AdvertisementBlockManager.Actions.ViewGetAllAdvertisementBlock:
                    ViewGetAllAdvertisementBlock(param);
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
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementBlock.FieldName.Id]) == 0)
                {
                    //Insert AdvertisementBlock
                    AdvertisementBlockDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //AdvertisementBlockItem
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementBlock.Items))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementBlockId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.BlockId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementBlock.FieldName.Id];
                                //Action
                                AdvertisementBlockItemDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    //Update AdvertisementBlock
                    AdvertisementBlockDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //AdvertisementBlockItem
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementBlock.Items))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementBlockId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.BlockId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementBlock.FieldName.Id];
                                //Action
                                AdvertisementBlockItemDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //AdvertisementBlockId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.BlockId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementBlock.FieldName.Id];
                                //Action
                                AdvertisementBlockItemDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //AdvertisementBlockId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementBlockItem.FieldName.BlockId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementBlock.FieldName.Id];
                                //Action
                                AdvertisementBlockItemDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementBlock.Items].Rows[i]);
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
                    SystemLogging.Error("AdvertisementBlockManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementBlockManager::DoSave::Error", ex.Message);
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
            AdvertisementBlockDAO.Delete(param.RawData.Tables[0].Rows[0]);
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

                DataTable dt = AdvertisementBlockDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = AdvertisementBlockItemDAO.SelectItemByBlockId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = AdvertisementConstants.Entities.AdvertisementBlock.Name;
                dt1.TableName = AdvertisementConstants.Entities.AdvertisementBlock.Items;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(dt.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("AdvertisementBlockManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementBlockManager::DoLoad::Error", ex.Message);
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

                DataTable dt = AdvertisementBlockDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = AdvertisementBlockItemDAO.SelectItemByBlockId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = AdvertisementConstants.Entities.AdvertisementBlock.Name;
                dt1.TableName = AdvertisementConstants.Entities.AdvertisementBlock.Items;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("AdvertisementBlockManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementBlockManager::DoLoadEncode::Error", ex.Message);
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
            DataTable dt = AdvertisementBlockDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllAdvertisementBlock

        private void ViewGetAllAdvertisementBlock(Packet param)
        {
            param.RawData = AdvertisementBlockDAO.ViewGetAllAdvertisementBlock(param.RawData);
        }

        #endregion

        #endregion
    }
}