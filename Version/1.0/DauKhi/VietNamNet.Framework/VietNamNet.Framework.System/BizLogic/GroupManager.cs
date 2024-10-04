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
    /// Summary description for GroupManager.
    /// </summary>
    public class GroupManager : Facade
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
                case SystemConstants.Services.GroupManager.Actions.ViewGetAllGroup:
                    ViewGetAllGroup(param);
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
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Group.FieldName.Id]) == 0)
                {
                    GroupDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //GroupMember
                    if (param.RawData.Tables.Contains(SystemConstants.Entities.Group.Members))
                    {
                        for (int i = 0; i < param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows.Count; i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.GroupId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Group.FieldName.Id];
                                GroupMemberDAO.Insert(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.Group.Members].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    GroupDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //GroupMember
                    if (param.RawData.Tables.Contains(SystemConstants.Entities.Group.Members))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.GroupId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Group.FieldName.Id];
                                GroupMemberDAO.Insert(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.Group.Members].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.GroupId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Group.FieldName.Id];
                                GroupMemberDAO.Update(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.Group.Members].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                param.RawData.Tables[SystemConstants.Entities.Group.Members].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.GroupId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Group.FieldName.Id];
                                GroupMemberDAO.Delete(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.Group.Members].Rows[i]);
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
                    SystemLogging.Error("GroupManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("GroupManager::DoSave::Error", ex.Message);
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
            GroupDAO.Delete(param.RawData.Tables[0].Rows[0]);
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

                DataTable dt = GroupDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = GroupMemberDAO.GetMembersByGroupId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = SystemConstants.Entities.Group.Name;
                dt1.TableName = SystemConstants.Entities.Group.Members;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(dt.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("GroupManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("GroupManager::DoLoad::Error", ex.Message);
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

                DataTable dt = GroupDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = GroupMemberDAO.GetMembersByGroupId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = SystemConstants.Entities.Group.Name;
                dt1.TableName = SystemConstants.Entities.Group.Members;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("GroupManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("GroupManager::DoLoadEncode::Error", ex.Message);
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

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = GroupDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllGroup

        private void ViewGetAllGroup(Packet param)
        {
            param.RawData = GroupDAO.ViewGetAllGroup(param.RawData);
        }

        #endregion

        #endregion
    }
}