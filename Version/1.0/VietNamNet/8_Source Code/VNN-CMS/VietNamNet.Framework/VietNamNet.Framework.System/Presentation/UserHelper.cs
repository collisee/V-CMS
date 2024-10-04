using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System.Presentation
{
    /// <summary>
    /// Summary description for UserHelper.
    /// </summary>
    public class UserHelper
    {
        private User o;

        #region UserHelper(User o)

        public UserHelper(User o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public User ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = SystemConstants.Services.UserManager.Name;
            if (ValueObject.MemberOf != null)
            {
                ValueObject.MemberOf.TableName = SystemConstants.Entities.User.MemberOf;
                p.RawData.Tables.Add(ValueObject.MemberOf.Copy());
            }
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
        }

        #endregion

        #region UpdateUserLastLogin

        public void UpdateUserLastLogin()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.UserManager.Actions.UpdateUserLastLogin;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
            if (ValueObject == null) return;
            ValueObject.MemberOf = p.RawData.Tables[SystemConstants.Entities.User.MemberOf];
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
            if (ValueObject == null) return;
            ValueObject.MemberOf = p.RawData.Tables[SystemConstants.Entities.User.MemberOf];
        }

        #endregion

        #region ListAll

        public DataTable ListAll()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetUser

        public void GetUser()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.UserManager.Actions.GetUser;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
        }

        #endregion

        #region GetUserByGroup

        public DataTable GetUserByGroup()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.UserManager.Actions.GetUserByGroup;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetUserByEmail

        public void GetUserByEmail()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.UserManager.Actions.GetUserByEmail;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
        }

        #endregion

        #region GetUserByLoginName

        public void GetUserByLoginName()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.UserManager.Actions.GetUserByLoginName;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
        }

        #endregion

        #region CheckEmail

        public bool CheckEmail()
        {
            Packet p = GetPacket();
            p.Action = SystemConstants.Services.UserManager.Actions.GetUserByEmail;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as User;
            return ValueObject == null;
        }

        #endregion

        #region GetBirthday

        public DataTable GetBirthday()
        {
          Packet p = GetPacket();
          p.Action = SystemConstants.Services.UserManager.Actions.GetBirthday;
          ServiceFacade.Execute(p);
          return p.RawData.Tables[0];
        }

        #endregion

      #region GetBirthdayNext

      public DataTable GetBirthdayNext()
      {
        Packet p = GetPacket();
        p.Action = SystemConstants.Services.UserManager.Actions.GetBirthdayNext;
        ServiceFacade.Execute(p);
        return p.RawData.Tables[0];
      }

      #endregion
      }
}