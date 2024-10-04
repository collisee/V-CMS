using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.AddOn.VCard.Core.Common;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;
using VietNamNet.Framework.Module;

namespace VietNamNet.AddOn.VCard.Core.Presentation
{

	/// <summary>
	/// Summary description for VCardsHelper.
	/// </summary>
	public class VCardsHelper
	{

		private VCards o;

		#region VCardsHelper(VCards o)
		public VCardsHelper(VCards o)
		{
			ValueObject = o;
		}
		#endregion

		#region ValueObject
		public VCards ValueObject
		{
			get { return o; }
			set { o = value; }
		}
		#endregion

		#region GetPacket
		private Packet GetPacket()
		{
			Packet p = PacketUtils.TranslateFrom(ValueObject);
			p.ServiceName = VCardsConstants.Services.VCardsManager.Name;
			return p;
		}
		#endregion

		#region DoSave
		public void DoSave()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.SAVE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCards;
		}
		#endregion

		#region Delete
		public void Delete()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.DELETE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCards;
		}
		#endregion

		#region Load
		public void Load()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.LOAD;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCards;
		}
		#endregion

		#region LoadEncode
		public void LoadEncode()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.LOAD_ENCODE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCards;
		}
		#endregion

		#region ListAll
		public DataTable ListAll()
		{
			Packet p = GetPacket();
			p.Action = BaseServices.CommonActions.LISTALL;
			ServiceFacade.Execute(p);
			return p.RawData.Tables[0];
		}
        public DataTable ListAllByUser()
        {
            Packet p = GetPacket();
            p.Action = VCardsConstants.Services.VCardsManager.Actions.LISTALLBYUSER;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
		#endregion

	}
}
