using System.Data;
using VietNamNet.Framework.Biz;
using  VietNamNet.AddOn.Royalty.Core.Common;
using  VietNamNet.AddOn.Royalty.Core.Common.ValueObject;

namespace  VietNamNet.AddOn.Royalty.Core.Presentation
{

	/// <summary>
	/// Summary description for RoyaltyTypesHelper.
	/// </summary>
	public class RoyaltyTypesHelper
	{

		private RoyaltyTypes o;

		#region RoyaltyTypesHelper(RoyaltyTypes o)
		public RoyaltyTypesHelper(RoyaltyTypes o)
		{
			ValueObject = o;
		}
		#endregion

		#region ValueObject
		public RoyaltyTypes ValueObject
		{
			get { return o; }
			set { o = value; }
		}
		#endregion

		#region GetPacket
		private Packet GetPacket()
		{
			Packet p = PacketUtils.TranslateFrom(ValueObject);
			p.ServiceName = Constants.Services.RoyaltyTypesManager.Name;
			return p;
		}
		#endregion

		#region DoSave
		public void DoSave()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.SAVE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyTypes;
		}
		#endregion

		#region Delete
		public void Delete()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.DELETE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyTypes;
		}
		#endregion

		#region Load
		public void Load()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.LOAD;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyTypes;
		}
		#endregion

		#region LoadEncode
		public void LoadEncode()
		{
			Packet p = GetPacket();
			p.Action = Constants.Services.CommonActions.LOAD_ENCODE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as RoyaltyTypes;
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
        public DataTable ListByParent()
        {
            Packet p = GetPacket();
            p.Action = Constants.Services.RoyaltyTypesManager.Actions.ListByParent;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
		#endregion

	}
}
