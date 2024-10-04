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
    /// Summary description for AdvertisementZoneManager.
    /// </summary>
    public class AdvertisementZoneManager : Facade
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
                case AdvertisementConstants.Services.AdvertisementZoneManager.Actions.ViewGetAllAdvertisementZone:
                    ViewGetAllAdvertisementZone(param);
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
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementZone.FieldName.Id]) == 0)
                {
                    //Insert AdvertisementZone
                    AdvertisementZoneDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //AdvertisementZoneBlock
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementZone.Blocks))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementZoneId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.ZoneId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementZone.FieldName.Id];
                                //Action
                                AdvertisementZoneBlockDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    //Update AdvertisementZone
                    AdvertisementZoneDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //AdvertisementZoneBlock
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementZone.Blocks))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementZoneId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.ZoneId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementZone.FieldName.Id];
                                //Action
                                AdvertisementZoneBlockDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //AdvertisementZoneId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.ZoneId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementZone.FieldName.Id];
                                //Action
                                AdvertisementZoneBlockDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //AdvertisementZoneId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementZoneBlock.FieldName.ZoneId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementZone.FieldName.Id];
                                //Action
                                AdvertisementZoneBlockDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementZone.Blocks].Rows[i]);
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
                    SystemLogging.Error("AdvertisementZoneManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementZoneManager::DoSave::Error", ex.Message);
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
            AdvertisementZoneDAO.Delete(param.RawData.Tables[0].Rows[0]);
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

                DataTable dt = AdvertisementZoneDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = AdvertisementZoneBlockDAO.SelectBlockByZoneId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = AdvertisementConstants.Entities.AdvertisementZone.Name;
                dt1.TableName = AdvertisementConstants.Entities.AdvertisementZone.Blocks;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(dt.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("AdvertisementZoneManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementZoneManager::DoLoad::Error", ex.Message);
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

                DataTable dt = AdvertisementZoneDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = AdvertisementZoneBlockDAO.SelectBlockByZoneId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = AdvertisementConstants.Entities.AdvertisementZone.Name;
                dt1.TableName = AdvertisementConstants.Entities.AdvertisementZone.Blocks;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("AdvertisementZoneManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementZoneManager::DoLoadEncode::Error", ex.Message);
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
            DataTable dt = AdvertisementZoneDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllAdvertisementZone

        private void ViewGetAllAdvertisementZone(Packet param)
        {
            param.RawData = AdvertisementZoneDAO.ViewGetAllAdvertisementZone(param.RawData);
        }

        #endregion

        #endregion
    }
}