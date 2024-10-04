using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.CMS.Presentation
{
    /// <summary>
    /// Summary description for CategoryHelper.
    /// </summary>
    public class CategoryHelper
    {
        private Category o;

        #region CategoryHelper(Category o)

        public CategoryHelper(Category o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Category ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CMSConstants.Services.CategoryManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Category;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Category;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Category;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Category;
        }

        #endregion

        #region GetCategoryByAlias

        public void GetCategoryByAlias()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryManager.Actions.GetCategoryByAlias;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Category;
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

        #region UpdateCategoryPIdAndOrder

        public void UpdateCategoryPIdAndOrder()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryManager.Actions.UpdateCategoryPIdAndOrder;
            ServiceFacade.Execute(p);
        }

        #endregion

        #region OptimizeCategory

        public void OptimizeCategory()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryManager.Actions.OptimizeCategory;
            ServiceFacade.Execute(p);
        }

        #endregion

        #region GetCategoryByUserId

        public DataTable GetCategoryByUserId()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CategoryManager.Actions.GetCategoryByUserId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}