using System.Data;
using VietNamNet.AddOn.Calendar.Common;
using VietNamNet.AddOn.Calendar.Common.ValueObject;
using VietNamNet.AddOn.Calendar.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Calendar.BizLogic
{
    /// <summary>
    /// Summary description for RoomManager.
    /// </summary>
    public class RoomManager : Facade
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
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][CalendarConstants.Entities.Room.FieldName.Id]) == 0)
            {
                RoomDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                RoomDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            RoomDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = RoomDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = RoomDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = RoomDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}