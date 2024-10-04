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
    /// Summary description for AdvertisementLayoutManager.
    /// </summary>
    public class AdvertisementLayoutManager : Facade
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
                case AdvertisementConstants.Services.AdvertisementLayoutManager.Actions.ViewGetAllAdvertisementLayout:
                    ViewGetAllAdvertisementLayout(param);
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
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id]) == 0)
                {
                    //Insert AdvertisementLayout
                    AdvertisementLayoutDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //AdvertisementLayoutCategory
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementLayout.Categories))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutCategoryDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i]);
                            }
                        }
                    }

                    //AdvertisementLayoutZone
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementLayout.Zones))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutZoneDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    //Update AdvertisementLayout
                    AdvertisementLayoutDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //AdvertisementLayoutCategory
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementLayout.Categories))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutCategoryDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutCategoryDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutCategory.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutCategoryDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Categories].Rows[i]);
                            }
                        }
                    }

                    //AdvertisementLayoutZone
                    if (param.RawData.Tables.Contains(AdvertisementConstants.Entities.AdvertisementLayout.Zones))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutZoneDAO.Insert(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutZoneDAO.Update(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                //AdvertisementLayoutId
                                param.RawData.Tables[AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i][
                                    AdvertisementConstants.Entities.AdvertisementLayoutZone.FieldName.LayoutId] =
                                    param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementLayout.FieldName.Id];
                                //Action
                                AdvertisementLayoutZoneDAO.Delete(tran,
                                                          param.RawData.Tables[
                                                              AdvertisementConstants.Entities.AdvertisementLayout.Zones].Rows[i]);
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
                    SystemLogging.Error("AdvertisementLayoutManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementLayoutManager::DoSave::Error", ex.Message);
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
            AdvertisementLayoutDAO.Delete(param.RawData.Tables[0].Rows[0]);
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

                DataTable dt = AdvertisementLayoutDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = AdvertisementLayoutCategoryDAO.SelectCategoriesByLayoutId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt2 = AdvertisementLayoutZoneDAO.SelectZoneByLayoutId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Name;
                dt1.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Categories;
                dt2.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Zones;

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
                    SystemLogging.Error("AdvertisementLayoutManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementLayoutManager::DoLoad::Error", ex.Message);
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

                DataTable dt = AdvertisementLayoutDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = AdvertisementLayoutCategoryDAO.SelectCategoriesByLayoutId(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt2 = AdvertisementLayoutZoneDAO.SelectZoneByLayoutId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Name;
                dt1.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Categories;
                dt2.TableName = AdvertisementConstants.Entities.AdvertisementLayout.Zones;

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
                    SystemLogging.Error("AdvertisementLayoutManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("AdvertisementLayoutManager::DoLoadEncode::Error", ex.Message);
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
            DataTable dt = AdvertisementLayoutDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllAdvertisementLayout

        private void ViewGetAllAdvertisementLayout(Packet param)
        {
            param.RawData = AdvertisementLayoutDAO.ViewGetAllAdvertisementLayout(param.RawData);
        }

        #endregion

        #endregion
    }
}