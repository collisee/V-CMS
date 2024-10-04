using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Presentation
{
    /// <summary>
    /// Summary description for ArticleEventCategoryHelper.
    /// </summary>
    public class ArticleEventCategoryHelper
    {
        private ArticleEventCategory o;

        #region ArticleEventCategoryHelper(ArticleEventCategory o)

        public ArticleEventCategoryHelper(ArticleEventCategory o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public ArticleEventCategory ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CMSConstants.Services.ArticleEventCategoryManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEventCategory;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEventCategory;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEventCategory;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEventCategory;
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

        #region OptimizeArticleEventCategory

        public void OptimizeArticleEventCategory()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.ArticleEventCategoryManager.Actions.OptimizeArticleEventCategory;
            ServiceFacade.Execute(p);
        }

        #endregion
    }
}