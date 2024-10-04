using System.Data;
using VietNamNet.AddOn.Advertisement.Common;
using VietNamNet.AddOn.Advertisement.Common.ValueObject;
using VietNamNet.AddOn.Advertisement.DBAccess;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.Advertisement.BizLogic
{
    /// <summary>
    /// Summary description for AdvertisementTypeManager.
    /// </summary>
    public class AdvertisementTypeManager : Facade
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
                case AdvertisementConstants.Services.AdvertisementTypeManager.Actions.ViewGetAllAdvertisementType:
                    ViewGetAllAdvertisementType(param);
                    break;
                case AdvertisementConstants.Services.AdvertisementTypeManager.Actions.GetAdvertisementTypeByAlias:
                    GetAdvertisementTypeByAlias(param);
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
            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][AdvertisementConstants.Entities.AdvertisementType.FieldName.Id]) == 0)
            {
                AdvertisementTypeDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                AdvertisementTypeDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            AdvertisementTypeDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = AdvertisementTypeDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = AdvertisementTypeDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = AdvertisementTypeDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function GetAdvertisementTypeByAlias

        private void GetAdvertisementTypeByAlias(Packet param)
        {
            DataTable dt = AdvertisementTypeDAO.GetAdvertisementTypeByAlias(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function ViewGetAllAdvertisementType

        private void ViewGetAllAdvertisementType(Packet param)
        {
            param.RawData = AdvertisementTypeDAO.ViewGetAllAdvertisementType(param.RawData);
        }

        #endregion

        #endregion
    }
}