using System;
using System.Data;
using System.Data.SqlClient;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.AddOn.Messages.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.DAO.MSSQL;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Messages.BizLogic
{
    /// <summary>
    /// Summary description for MessageManager.
    /// </summary>
    public class MessageManager : Facade
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
                case MessagesConstants.Services.MessageManager.Actions.GetNewPrivateMessages:
                    GetNewPrivateMessages(param);
                    break;
                case MessagesConstants.Services.MessageManager.Actions.ViewGetAllMessages:
                    ViewGetAllMessages(param);
                    break;
                case MessagesConstants.Services.MessageManager.Actions.ViewGetAllMyMessagesByStatus:
                    ViewGetAllMyMessagesByStatus(param);
                    break;
                case MessagesConstants.Services.MessageManager.Actions.ViewGetAllPrivateMessages:
                    ViewGetAllPrivateMessages(param);
                    break;
                case MessagesConstants.Services.MessageManager.Actions.ViewGetAllPrivateMessagesByStatus:
                    ViewGetAllPrivateMessagesByStatus(param);
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

                //Message
                if (
                    Utilities.ParseInt(param.RawData.Tables[0].Rows[0][MessagesConstants.Entities.Message.FieldName.Id]) ==
                    0)
                {
                    MessageDAO.Insert(tran, param.RawData.Tables[0].Rows[0]);
                }
                else
                {
                    MessageDAO.Update(tran, param.RawData.Tables[0].Rows[0]);
                }

                //Message Delivery - when status = Sent
                if (Utilities.StringCompare(MessagesConstants.MessageStatus.Sent, 
                        param.RawData.Tables[0].Rows[0][MessagesConstants.Entities.Message.FieldName.Status]))
                {
                    switch(Utilities.ParseInt(param.RawData.Tables[0].Rows[0][MessagesConstants.Entities.Message.FieldName.MsgType]))
                    {
                        case 0:
                            MessageDeliveryDAO.InsertPersonal(tran, param.RawData.Tables[0].Rows[0]);
                            break;
                        case 1:
                            MessageDeliveryDAO.InsertGroup(tran, param.RawData.Tables[0].Rows[0]);
                            break;
                        case 2:
                            MessageDeliveryDAO.InsertAllUsers(tran, param.RawData.Tables[0].Rows[0]);
                            break;
                        default:
                            break;
                    }
                }


                tran.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    SystemLogging.Error("MessageManager::DoSave::Error - " + ex.Message,
                                        ex.InnerException.Message);
                }
                else
                {
                    SystemLogging.Error("MessageManager::DoSave::Error", ex.Message);
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
            MessageDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = MessageDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = MessageDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function GetNewPrivateMessages

        private void GetNewPrivateMessages(Packet param)
        {
            DataTable dt = MessageDAO.GetNewPrivateMessages(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = MessageDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllMessages

        private void ViewGetAllMessages(Packet param)
        {
            param.RawData = MessageDAO.ViewGetAllMessages(param.RawData);
        }

        #endregion

        #region Function ViewGetAllMyMessagesByStatus

        private void ViewGetAllMyMessagesByStatus(Packet param)
        {
            param.RawData = MessageDAO.ViewGetAllMyMessagesByStatus(param.RawData);
        }

        #endregion

        #region Function ViewGetAllPrivateMessages

        private void ViewGetAllPrivateMessages(Packet param)
        {
            param.RawData = MessageDAO.ViewGetAllPrivateMessages(param.RawData);
        }

        #endregion

        #region Function ViewGetAllPrivateMessagesByStatus

        private void ViewGetAllPrivateMessagesByStatus(Packet param)
        {
            param.RawData = MessageDAO.ViewGetAllPrivateMessagesByStatus(param.RawData);
        }

        #endregion

        #endregion
    }
}