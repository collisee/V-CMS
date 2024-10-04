using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for GroupHelper.
    /// </summary>
    public class GroupHelper
    {
        private Group o;

        #region GroupHelper(Group o)

        public GroupHelper(Group o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Group ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.GroupManager.Name;
            if (ValueObject.Members != null)
            {
                ValueObject.Members.TableName = SystemConstants.Entities.Group.Members;
                p.RawData.Tables.Add(ValueObject.Members.Copy());
            }
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Group;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Group;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Group;
            if (ValueObject == null) return;
            ValueObject.Members = p.RawData.Tables[SystemConstants.Entities.Group.Members];
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Group;
            if (ValueObject == null) return;
            ValueObject.Members = p.RawData.Tables[SystemConstants.Entities.Group.Members];
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
    }
}