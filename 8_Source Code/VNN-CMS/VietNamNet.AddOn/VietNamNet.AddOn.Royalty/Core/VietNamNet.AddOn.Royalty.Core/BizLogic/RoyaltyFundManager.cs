using System;
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
	/// Summary description for RoyaltyFundManager.
	/// </summary>
	public class RoyaltyFundManager : Facade
	{
		#region Override Execute
		public override Packet Execute(Packet param)
        {
            VietNamNet.Framework.System.SystemLogging.Info(string.Format("{0}::{1}",
                                param.ServiceName,param.Action));
		    try
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
                    case Constants.Services.RoyaltyFundManager.Actions.ListByArticle:
                        ListByArticle(param);
                        break;
                    case Constants.Services.RoyaltyFundManager.Actions.Reports21B:
                        Report21B(param);
                        break;
                    case Constants.Services.RoyaltyFundManager.Actions.ViewGetAllArticleList:
                        ViewGetAllArticleList(param);
                        break;
                    case VietNamNet.AddOn.Royalty.Core.Common.Constants.Services.RoyaltyFundManager.Actions.Reports21A:
                        Report21A(param);
                        break;
                    default:
                        break;
                }
		    }
		    catch (Exception ex)
		    {
                VietNamNet.Framework.System.SystemLogging.Error(string.Format("{0}::{1}",param.ServiceName, param.Action)); 
		    }

            return param;
        }

		#endregion

		#region Execute Actions
		#region Function DoSave
		private void DoSave(Packet param)
		{
            RoyaltyFund o = PacketUtils.TranslateTo(param) as RoyaltyFund;
            if (o.Fund_Id == 0)
            {
                RoyaltyFundDAO.Insert(param.RawData.Tables[0].Rows[0]);
            }
            else
            {
                RoyaltyFundDAO.Update(param.RawData.Tables[0].Rows[0]);
            }
		}
		#endregion
		#region Function DoDelete
		private void DoDelete(Packet param)
		{
			RoyaltyFundDAO.Delete(param.RawData.Tables[0].Rows[0]);
		}
		#endregion
		#region Function DoLoad
		private void DoLoad(Packet param)
		{
			DataTable dt = RoyaltyFundDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(dt.Copy());
		}
		#endregion
		#region Function DoLoadEncode
		private void DoLoadEncode(Packet param)
		{
			DataTable dt = RoyaltyFundDAO.SelectOne(param.RawData.Tables[0].Rows[0]);
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(Utilities.EncodeDatatable(dt.Copy()));
		}
		#endregion
		#region Function List
		private void ListAll(Packet param)
		{
			DataTable dt = RoyaltyFundDAO.SelectAll();
			param.RawData.Tables.Clear();
			param.RawData.Tables.Add(dt.Copy());
		}
        private void ListByArticle(Packet param)
        {
            DataTable dt = RoyaltyFundDAO.SelectByArticle(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
		#endregion

        #region Searching
        private void Report21B(Packet param)
        {
            DataTable dt = RoyaltyFundDAO.Reports21B(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
        private void Report21A(Packet param)
        {
            DataTable dt = RoyaltyFundDAO.Reports21A(param.RawData.Tables[0].Rows[0]);
            param.RawData.Tables.Clear();
            param.RawData.Tables.Add(dt.Copy());
        }
        #endregion

        #region Function ViewGetAllArticleList

        private void ViewGetAllArticleList(Packet param)
        {
            param.RawData = RoyaltyFundDAO.ViewGetAllArticleList(param.RawData);
        }

        #endregion

        #endregion
    }
}
