using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn.VCard.Core.DBAccess;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;

namespace VietNamNet.AddOn.VCard.Core.BizLogic
{
    /// <summary>
    /// Summary description for VCardsGroupsManager.
    /// </summary>
    public class VCardsGroupsManager : Facade
    {
        #region Override Execute

        public override Packet Execute(Packet param)
        {
            switch (param.Action)
            {
                case Common.VCardsConstants.Services.CommonActions.SAVE:
                    DoSave(param);
                    break;
                case Common.VCardsConstants.Services.CommonActions.DELETE:
                    DoDelete(param);
                    break;
                case Common.VCardsConstants.Services.CommonActions.LOAD:
                    DoLoad(param);
                    break;
                case Common.VCardsConstants.Services.CommonActions.LOAD_ENCODE:
                    DoLoadEncode(param);
                    break;
                case Common.VCardsConstants.Services.CommonActions.LISTALL:
                    ListAll(param);
                    break;
                case Common.VCardsConstants.Services.VCardsGroupsManager.Actions.LISTALLBYUSER:
                    ListAllByUser(param);
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
            VCardsGroups o = PacketUtils.TranslateTo(param) as VCardsGroups;
            if (o.GroupId == 0)
            {
                VCardsGroupsDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                VCardsGroupsDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
        }

        #endregion

        #region Function DoDelete

        private void DoDelete(Packet param)
        {
            VCardsGroupsDAO.Delete(param.RawData.Tables[0].Rows[0]);
        }

        #endregion

        #region Function DoLoad

        private void DoLoad(Packet param)
        {
            DataTable dt = VCardsGroupsDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #region Function DoLoadEncode

        private void DoLoadEncode(Packet param)
        {
            DataTable dt = VCardsGroupsDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
        }

        #endregion

        #region Function ListAll

        private void ListAll(Packet param)
        {
            DataTable dt = VCardsGroupsDAO.SelectAll();
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        private void ListAllByUser(Packet param)
        {
            DataTable dt = VCardsGroupsDAO.SelectAllByUser(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

        #endregion

        #endregion
    }
}