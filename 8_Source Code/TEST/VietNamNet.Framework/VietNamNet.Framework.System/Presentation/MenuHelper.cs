using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for MenuHelper.
    /// </summary>
    public class MenuHelper
    {
        private Menu o;

        #region MenuHelper(Menu o)

        public MenuHelper(Menu o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Menu ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.MenuManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Menu;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Menu;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Menu;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Menu;
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

        #endregion

        #region GetMenuByUserId

        public DataTable GetMenuByUserId()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.MenuManager.Actions.GetMenuByUserId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region UpdateMenuPIdAndOrder

        public void UpdateMenuPIdAndOrder()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.MenuManager.Actions.UpdateMenuPIdAndOrder;
            ServiceFacade.Execute(p);
        }

        #endregion

        #region OptimizeMenu

        public void OptimizeMenu()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.MenuManager.Actions.OptimizeMenu;
            ServiceFacade.Execute(p);
        }

        #endregion
    }
}