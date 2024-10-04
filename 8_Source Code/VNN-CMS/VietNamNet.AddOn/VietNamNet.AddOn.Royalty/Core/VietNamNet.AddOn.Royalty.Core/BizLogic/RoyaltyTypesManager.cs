using System.Data;
using VietNamNet.Framework.Biz;
using  VietNamNet.Framework.Common;
using  VietNamNet.AddOn.Royalty.Core.DBAccess;
using  VietNamNet.AddOn.Royalty.Core.Common;
using  VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using Constants = VietNamNet.AddOn.Royalty.Core.Common.Constants;

namespace  VietNamNet.AddOn.Royalty.Core.BizLogic
{
	/// <summary>
	/// Summary description for RoyaltyTypesManager.
	/// </summary>
	public class RoyaltyTypesManager : Facade
	{
		#region Override Execute
		public override Packet Execute(Packet param)
		{
			switch (param.Action)
			{
				case Constants.Services.CommonActions.SAVE:
					DoSave(param);
					break;
				case Constants.Services.CommonActions.DELETE:
					DoDelete(param);
					break;
				case Constants.Services.CommonActions.LOAD:
					DoLoad(param);
					break;
				case Constants.Services.CommonActions.LOAD_ENCODE:
					DoLoadEncode(param);
					break;
				case Constants.Services.CommonActions.LISTALL:
					ListAll(param);
					break;
                case Constants.Services.RoyaltyTypesManager.Actions.ListByParent:
                    ListByParent(param);
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
			RoyaltyTypes o = PacketUtils.TranslateTo(param) as RoyaltyTypes;
			if (o.Type_Id== 0)
			{
				RoyaltyTypesDAO.Insert(param.RawData.Tables[0].Rows[0]);
			}
			else
			{
				RoyaltyTypesDAO.Update(param.RawData.Tables[0].Rows[0]);
			}
		}
		#endregion
		#region Function DoDelete
		private void DoDelete(Packet param)
		{
			RoyaltyTypesDAO.Delete(param.RawData.Tables[0].Rows[0]);
		}
		#endregion
		#region Function DoLoad
		private void DoLoad(Packet param)
		{
			DataTable dt = RoyaltyTypesDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(dt.Copy());
		}
		#endregion
		#region Function DoLoadEncode
		private void DoLoadEncode(Packet param)
		{
			DataTable dt = RoyaltyTypesDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
		}
		#endregion
		#region Function List
		private void ListAll(Packet param)
		{
			DataTable dt = RoyaltyTypesDAO.SelectAll();
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(dt.Copy());
		}
        private void ListByParent(Packet param)
        {
            DataTable dt = RoyaltyTypesDAO.SelectByParent(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
		#endregion

		#endregion
	}
}
