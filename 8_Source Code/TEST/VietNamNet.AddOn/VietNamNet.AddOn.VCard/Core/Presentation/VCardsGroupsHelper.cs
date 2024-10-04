using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.AddOn.VCard.Core.Common;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;

namespace VietNamNet.AddOn.VCard.Core.Presentation
{

	/// <summary>
	/// Summary description for VCardsGroupsHelper.
	/// </summary>
	public class VCardsGroupsHelper
	{

		private VCardsGroups o;

		#region VCardsGroupsHelper(VCardsGroups o)
		public VCardsGroupsHelper(VCardsGroups o)
		{
			ValueObject = o;
		}
		#endregion

		#region ValueObject
		public VCardsGroups ValueObject
		{
			get { return o; }
			set { o = value; }
		}
		#endregion

		#region GetPacket
		private Packet GetPacket()
		{
			Packet p = PacketUtils.TranslateFrom(ValueObject);
			p.ServiceName = VCardsConstants.Services.VCardsGroupsManager.Name;
			return p;
		}
		#endregion

		#region DoSave
		public void DoSave()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.SAVE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCardsGroups;
		}
		#endregion

		#region Delete
		public void Delete()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.DELETE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCardsGroups;
		}
		#endregion

		#region Load
		public void Load()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.LOAD;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCardsGroups;
		}
		#endregion

		#region LoadEncode
		public void LoadEncode()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.LOAD_ENCODE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as VCardsGroups;
		}
		#endregion

		#region ListAll
		public DataTable ListAll()
		{
			Packet p = GetPacket();
			p.Action = VCardsConstants.Services.CommonActions.LISTALL;
			ServiceFacade.Execute(p);
			return p.RawData.Tables[0];
		}
        public DataTable ListAllByUser()
        {
            Packet p = GetPacket();
            p.Action = VCardsConstants.Services.VCardsGroupsManager.Actions.LISTALLBYUSER;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }
		#endregion

	}
}
