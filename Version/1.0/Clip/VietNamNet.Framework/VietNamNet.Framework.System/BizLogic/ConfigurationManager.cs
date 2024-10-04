using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.DBAccess;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.BizLogic
{
    /// <summary>
    /// Summary description for ConfigurationManager.
    /// </summary>
    public class ConfigurationManager : Facade
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
                case SystemConstants.Services.ConfigurationManager.Actions.GetConfiguration:
                    GetConfiguration(param);
                    break;
                case SystemConstants.Services.ConfigurationManager.Actions.ViewGetAllConfiguration:
                    ViewGetAllConfiguration(param);
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
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][SystemConstants.Entities.Configuration.FieldName.Id]) == 0)
            {
                ConfigurationDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                ConfigurationDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            ConfigurationDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = ConfigurationDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetConfiguration

        private void GetConfiguration(Packet param)
        {
            DataTable dt = ConfigurationDAO.GetConfiguration(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = ConfigurationDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = ConfigurationDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllConfiguration

        private void ViewGetAllConfiguration(Packet param)
        {
            param.RawData = ConfigurationDAO.ViewGetAllConfiguration(param.RawData);
        }

        #endregion

        #endregion
    }
}