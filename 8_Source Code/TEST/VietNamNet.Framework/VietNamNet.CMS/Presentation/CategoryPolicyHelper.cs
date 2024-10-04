using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.CMS.Presentation
{
    /// <summary>
    /// Summary description for CategoryPolicyHelper.
    /// </summary>
    public class CategoryPolicyHelper
    {
        private CategoryPolicy o;

        #region CategoryPolicyHelper(CategoryPolicy o)

        public CategoryPolicyHelper(CategoryPolicy o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public CategoryPolicy ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CMSConstants.Services.CategoryPolicyManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as CategoryPolicy;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as CategoryPolicy;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as CategoryPolicy;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as CategoryPolicy;
        }

        #endregion

        #region ListAll

        public DataTable ListAll()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LISTALL;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetPolicyByUserIdAndCategoryAlias

        public DataTable GetPolicyByUserIdAndCategoryAlias()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByUserIdAndCategoryAlias;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetPolicyByUserIdAndCategoryId

        public DataTable GetPolicyByUserIdAndCategoryId()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByUserIdAndCategoryId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetPolicyByGroup

        public DataTable GetPolicyByGroup()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByGroup;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region SavePolicyByGroup

        public void SavePolicyByGroup(DataTable dt)
        {
            Packet p = GetPacket();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt);
            p.Action = CMSConstants.Services.CategoryPolicyManager.Actions.SavePolicyByGroup;
            ServiceFacade.Execute(p);
        }

        #endregion

        #region GetPolicyByCategory

        public DataTable GetPolicyByCategory()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryPolicyManager.Actions.GetPolicyByCategory;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region SavePolicyByCategory

        public void SavePolicyByCategory(DataTable dt)
        {
            Packet p = GetPacket();
            p.RawData.Tables.Clear();
            p.RawData.Tables.Add(dt);
            p.Action = CMSConstants.Services.CategoryPolicyManager.Actions.SavePolicyByCategory;
            ServiceFacade.Execute(p);
        }

        #endregion
    }
}