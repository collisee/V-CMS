using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.AddOn.Messages.Common.ValueObject;

namespace VietNamNet.AddOn.Messages.Presentation
{

	/// <summary>
	/// Summary description for MessageDeliveryHelper.
	/// </summary>
	public class MessageDeliveryHelper
	{

		private MessageDelivery o;

		#region MessageDeliveryHelper(MessageDelivery o)
		public MessageDeliveryHelper(MessageDelivery o)
		{
			ValueObject = o;
		}
		#endregion

		#region ValueObject
		public MessageDelivery ValueObject
		{
			get { return o; }
			set { o = value; }
		}
		#endregion

		#region GetPacket
		private Packet GetPacket()
		{
			Packet p = PacketUtils.TranslateFrom(ValueObject);
			p.ServiceName = MessagesConstants.Services.MessageDeliveryManager.Name;
			return p;
		}
		#endregion

		#region DoSave
		public void DoSave()
		{
			Packet p = GetPacket();
			p.Action = MessagesConstants.Services.CommonActions.SAVE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as MessageDelivery;
		}
		#endregion

		#region Delete
		public void Delete()
		{
			Packet p = GetPacket();
			p.Action = MessagesConstants.Services.CommonActions.DELETE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as MessageDelivery;
		}
		#endregion

		#region Load
		public void Load()
		{
			Packet p = GetPacket();
			p.Action = MessagesConstants.Services.CommonActions.LOAD;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as MessageDelivery;
		}
		#endregion

		#region LoadEncode
		public void LoadEncode()
		{
			Packet p = GetPacket();
			p.Action = MessagesConstants.Services.CommonActions.LOAD_ENCODE;
			ServiceFacade.Execute(p);
			ValueObject = PacketUtils.TranslateTo(p) as MessageDelivery;
		}
		#endregion

		#region ListAll
		public DataTable ListAll()
		{
			Packet p = GetPacket();
			p.Action = MessagesConstants.Services.CommonActions.LISTALL;
			ServiceFacade.Execute(p);
			return p.RawData.Tables[0];
		}
		#endregion

	}
}
