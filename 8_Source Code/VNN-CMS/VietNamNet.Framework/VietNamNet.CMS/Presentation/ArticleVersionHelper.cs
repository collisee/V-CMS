using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.CMS.Presentation
{
    /// <summary>
    /// Summary description for ArticleVersionHelper.
    /// </summary>
    public class ArticleVersionHelper
    {
        private ArticleVersion o;

        #region ArticleVersionHelper(ArticleVersion o)

        public ArticleVersionHelper(ArticleVersion o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public ArticleVersion ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CMSConstants.Services.ArticleVersionManager.Name;
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleVersion;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleVersion;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleVersion;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleVersion;
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

        #region GetArticleVersions

        public DataTable GetArticleVersions()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.ArticleVersionManager.Actions.GetArticleVersionsByArticleId;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}