using System;
using System.Data;
using VietNamNet.AddOn.VCard.Core.Common;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn;
using VietNamNet.AddOn.VCard.Core.DBAccess;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;

namespace VietNamNet.AddOn.VCard.Core.BizLogic
{
	/// <summary>
	/// Summary description for VCardsManager.
	/// </summary>
	public class VCardsManager : Facade
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
            if (param.RawData.Tables[0].Rows[0][VCardsConstants.Entities.VCards.FieldName.Bday] == DBNull.Value)
            {
                param.RawData.Tables[0].Rows[0][VCardsConstants.Entities.VCards.FieldName.Bday] = Utilities.GetMinDate();
            }
            else if (((DateTime) param.RawData.Tables[0].Rows[0][VCardsConstants.Entities.VCards.FieldName.Bday]) < Utilities.GetMinDate())
		    {
                param.RawData.Tables[0].Rows[0][VCardsConstants.Entities.VCards.FieldName.Bday] = Utilities.GetMinDate();
		    }

            if (Utilities.ParseInt(param.RawData.Tables[0].Rows[0][VCardsConstants.Entities.VCards.FieldName.ContactId]) == 0)
			{
				VCardsDAO.Insert(param.RawData.Tables[0].Rows[0]);
			}
			else
			{
                VCardsDAO.Update(param.RawData.Tables[0].Rows[0]);
			}
		}
		#endregion
		#region Function DoDelete
		private void DoDelete(Packet param)
		{
			VCardsDAO.Delete(param.RawData.Tables[0].Rows[0]);
		}
		#endregion
		#region Function DoLoad
		private void DoLoad(Packet param)
		{
			DataTable dt = VCardsDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(dt.Copy());

		    param.RawData.Tables[0].Rows[0][VCardsConstants.Entities.VCards.FieldName.Bday] = Utilities.GetMinDate();

		}
		#endregion
		#region Function DoLoadEncode
		private void DoLoadEncode(Packet param)
		{
			DataTable dt = VCardsDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
		}
		#endregion
		#region Function ListAll
		private void ListAll(Packet param)
		{
			DataTable dt = VCardsDAO.SelectAll();
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(dt.Copy());
		}
        private void ListAllByUser(Packet param)
        {
            DataTable dt = VCardsDAO.SelectAllByUser(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }

		#endregion
		#endregion
	}
}
