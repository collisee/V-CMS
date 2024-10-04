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
    /// Summary description for UserManager.
    /// </summary>
    public class UserManager : Facade
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
                case SystemConstants.Services.UserManager.Actions.ViewGetAllUser:
                    ViewGetAllUser(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.ViewGetAllUserByGroup:
                    ViewGetAllUserByGroup(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.UpdateUserLastLogin:
                    UpdateUserLastLogin(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.GetUser:
                    GetUser(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.GetUserByGroup:
                    GetUserByGroup(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.GetUserByEmail:
                    GetUserByEmail(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.GetUserByLoginName:
                    GetUserByLoginName(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.ViewGetAllUserFilterByGroup:
                    ViewGetAllUserFilterByGroup(param);
                    break;
                case SystemConstants.Services.UserManager.Actions.GetBirthday:
                    GetBirthday(param);
                    break;
                  case SystemConstants.Services.UserManager.Actions.GetBirthdayNext:
                    GetBirthdayNext(param);
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
                if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.User.FieldName.Id]) == 0)
                {
                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.User.FieldName.LastLogin] = DateTime.Now;
                    UserDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);

                    //GroupMember
                    if (param.RawData.Tables.Contains(SystemConstants.Entities.User.MemberOf))
                    {
                        for (int i = 0; i < param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows.Count; i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.UserId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.User.FieldName.Id];
                                GroupMemberDAO.Insert(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.User.MemberOf].Rows[i]);
                            }
                        }
                    }
                }
                else //Update
                {
                    UserDAO.Update(tran, param.RawData.Tables[0].Rows[0]);

                    //GroupMember
                    if (param.RawData.Tables.Contains(SystemConstants.Entities.User.MemberOf))
                    {
                        for (int i = 0;
                             i < param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows.Count;
                             i++)
                        {
                            //SaveStatus == NEW
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.NEW))
                            {
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.UserId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.User.FieldName.Id];
                                GroupMemberDAO.Insert(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.User.MemberOf].Rows[i]);
                            }
                            //SaveStatus == UPDATE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.UPDATE))
                            {
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.UserId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.User.FieldName.Id];
                                GroupMemberDAO.Update(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.User.MemberOf].Rows[i]);
                            }
                            //SaveStatus == DELETE
                            if (Utilities.StringCompare(
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.SaveStatus],
                                Constants.CommonStatus.DELETE))
                            {
                                param.RawData.Tables[SystemConstants.Entities.User.MemberOf].Rows[i][
                                    SystemConstants.Entities.GroupMember.FieldName.UserId] =
                                    param.RawData.Tables[0].Rows[0][SystemConstants.Entities.User.FieldName.Id];
                                GroupMemberDAO.Delete(tran,
                                                      param.RawData.Tables[
                                                          SystemConstants.Entities.User.MemberOf].Rows[i]);
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
                    SystemLogging.Error("UserManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("UserManager::DoSave::Error", ex.Message);
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
            UserDAO.Delete(param.RawData.Tables[0].Rows[0]);
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

                DataTable dt = UserDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = GroupMemberDAO.GetGroupsByUserId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = SystemConstants.Entities.User.Name;
                dt1.TableName = SystemConstants.Entities.User.MemberOf;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(dt.Copy());
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("UserManager::DoLoad::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("UserManager::DoLoad::Error", ex.Message);
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

                DataTable dt = UserDAO.SelectOne(tran, param.RawData.Tables[0].Rows[0]);
                DataTable dt1 = GroupMemberDAO.GetGroupsByUserId(tran, param.RawData.Tables[0].Rows[0]);

                dt.TableName = SystemConstants.Entities.User.Name;
                dt1.TableName = SystemConstants.Entities.User.MemberOf;

                param.RawData.Tables.Clear();
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
                param.RawData.Tables.Add(Utilities.EncodeDatatable(dt1.Copy()));

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("UserManager::DoLoadEncode::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("UserManager::DoLoadEncode::Error", ex.Message);
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
            DataTable dt = UserDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllUser

        private void ViewGetAllUser(Packet param)
        {
            param.RawData = UserDAO.ViewGetAllUser(param.RawData);
        }

        #endregion

        #region Function ViewGetAllUserFilterByGroup

        private void ViewGetAllUserFilterByGroup(Packet param)
        {
            param.RawData = UserDAO.ViewGetAllUserFilterByGroup(param.RawData);
        }

        #endregion

        #region Function ViewGetAllUserByGroup

        private void ViewGetAllUserByGroup(Packet param)
        {
            param.RawData = UserDAO.ViewGetAllUserByGroup(param.RawData);
        }

        #endregion

        #region Function UpdateUserLastLogin

        private void UpdateUserLastLogin(Packet param)
        {
            UserDAO.UpdateUserLastLogin(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function GetUser

        private void GetUser(Packet param)
        {
            DataTable dt = UserDAO.GetUser(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetUserByGroup

        private void GetUserByGroup(Packet param)
        {
            DataTable dt = UserDAO.GetUserByGroup(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetUserByEmail

        private void GetUserByEmail(Packet param)
        {
            DataTable dt = UserDAO.GetUserByEmail(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetUserByLoginName

        private void GetUserByLoginName(Packet param)
        {
            DataTable dt = UserDAO.GetUserByLoginName(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetBirthday

        private void GetBirthday(Packet param)
        {
            DataTable dt = UserDAO.GetBirthday();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

      #region Function GetBirthdayNext

      private void GetBirthdayNext(Packet param)
      {
        DataTable dt = UserDAO.GetBirthdayNext();
        param.RawData.Tables.Clear();
        param.RawData.Tables.Add(dt.Copy());
      }

      #endregion

        #endregion
    }
}