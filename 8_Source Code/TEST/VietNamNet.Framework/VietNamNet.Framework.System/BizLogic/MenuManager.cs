using System;
using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.DBAccess;

namespace VietNamNet.Framework.System.BizLogic
{
    /// <summary>
    /// Summary description for MenuManager.
    /// </summary>
    public class MenuManager : Facade
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
                case SystemConstants.Services.MenuManager.Actions.GetMenuByUserId:
                    GetMenuByUserId(param);
                    break;
                case SystemConstants.Services.MenuManager.Actions.UpdateMenuPIdAndOrder:
                    UpdateMenuPIdAndOrder(param);
                    break;
                case SystemConstants.Services.MenuManager.Actions.OptimizeMenu:
                    OptimizeMenu(param);
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
            //Check PId
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Menu.FieldName.PId]) == 0)
            {
                param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Menu.FieldName.PId] = DBNull.Value;
            }
            //Save
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Menu.FieldName.Id]) == 0)
            {
                MenuDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                MenuDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            MenuDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = MenuDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetMenuByUserId

        private void GetMenuByUserId(Packet param)
        {
            DataTable dt = MenuDAO.GetMenuByUserId(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function UpdateMenuPIdAndOrder

        private void UpdateMenuPIdAndOrder(Packet param)
        {
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Menu.FieldName.PId]) == 0)
            {
                param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Menu.FieldName.PId] = DBNull.Value;
            }
            MenuDAO.UpdateMenuPIdAndOrder(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function OptimizeMenu

        private void OptimizeMenu(Packet param)
        {
            MenuDAO.OptimizeMenu(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = MenuDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = MenuDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}