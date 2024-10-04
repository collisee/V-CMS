using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.Framework.Biz;

namespace VietNamNet.CMS.Presentation
{
    /// <summary>
    /// Summary description for ArticleHelper.
    /// </summary>
    public class ArticleHelper
    {
        private Article o;

        #region ArticleHelper(Article o)

        public ArticleHelper(Article o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public Article ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CMSConstants.Services.ArticleManager.Name;
            if (ValueObject.Media != null)
            {
                ValueObject.Media.TableName = CMSConstants.Entities.Article.Media;
                p.RawData.Tables.Add(ValueObject.Media.Copy());
            }
            if (ValueObject.Categories != null)
            {
                ValueObject.Categories.TableName = CMSConstants.Entities.Article.Categories;
                p.RawData.Tables.Add(ValueObject.Categories.Copy());
            }
            return p;
        }

        #endregion

        #region DoSave

        public void DoSave()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.SAVE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Article;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Article;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Article;
            if (ValueObject != null)
            {
                ValueObject.Media = p.RawData.Tables[CMSConstants.Entities.Article.Media];
                ValueObject.Categories = p.RawData.Tables[CMSConstants.Entities.Article.Categories];
                ValueObject.Versions = p.RawData.Tables[CMSConstants.Entities.Article.Versions];
            }
        }

        #endregion

        #region LoadSimple

        public void LoadSimple()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.ArticleManager.Actions.LoadSimple;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Article;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as Article;
            if (ValueObject != null)
            {
                ValueObject.Media = p.RawData.Tables[CMSConstants.Entities.Article.Media];
                ValueObject.Categories = p.RawData.Tables[CMSConstants.Entities.Article.Categories];
                ValueObject.Versions = p.RawData.Tables[CMSConstants.Entities.Article.Versions];
            }
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
    }
}