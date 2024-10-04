using System.Data;
using VietNamNet.Framework.Biz;
using  VietNamNet.AddOn.Royalty.Core.Common;
using  VietNamNet.AddOn.Royalty.Core.Common.ValueObject;

namespace  VietNamNet.AddOn.Royalty.Core.Presentation
{

	/// <summary>
	/// Summary description for RoyaltyFundHelper.
	/// </summary>
	public class RoyaltyFundHelper
    {
        #region Members

        private RoyaltyFund o;
        private RoyaltySearch s;

        #endregion

        #region Helper(RoyaltyFund o)
        public RoyaltyFundHelper(RoyaltyFund o)
		{
			ValueObject = o;
		}
        public RoyaltyFundHelper(RoyaltySearch search)
        {
            SearchObject = search;
        }
		#endregion

		#region ValueObject
		public RoyaltyFund ValueObject
		{
			get { return o; }
			set { o = value; }
		}

        public RoyaltySearch SearchObject
        {
            get { return s; }
            set { s = value; }
        }
		#endregion

		#region GetPacket
		private Packet GetPacket()
		{
			Packet p = PacketUtils.TranslateFrom(ValueObject);
			p.ServiceName = Constants.Services.RoyaltyFundManager.Name;
			return p;
		}
        private Packet GetSearchPacket()
        {
            Packet p = PacketUtils.TranslateFrom(SearchObject);
            p.ServiceName = Constants.Services.RoyaltyFundManager.Name;
            return p;
        }
		#endregion

		#region DoSave
		public void DoSave()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.SAVE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyFund;
		}
		#endregion

		#region Delete
		public void Delete()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.DELETE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyFund;
		}
		#endregion

		#region Load
		public void Load()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.LOAD;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyFund;
		}
		#endregion

		#region LoadEncode
		public void LoadEncode()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.LOAD_ENCODE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyFund;
		}
		#endregion

		#region List
		public DataTable ListAll()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
			return p.RawData.Tables[0];
        }
        public DataTable ListByArticle()
        {
            Packet p = GetPacket();
            p.Action = Constants.Services.RoyaltyFundManager.Actions.ListByArticle;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
		#endregion

        #region Search
        public DataTable Reports21A()
        {
            Packet p = GetSearchPacket();
            p.Action = Constants.Services.RoyaltyFundManager.Actions.Reports21A;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
        public DataTable Reports21B()
        {
            Packet p = GetSearchPacket();
            p.Action = Constants.Services.RoyaltyFundManager.Actions.Reports21B;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
        #endregion

    }
}
