using System.Data;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.Presentation
{
    /// <summary>
    /// Summary description for ArticleEventHelper.
    /// </summary>
    public class ArticleEventHelper
    {
        private ArticleEvent o;

        #region ArticleEventHelper(ArticleEvent o)

        public ArticleEventHelper(ArticleEvent o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public ArticleEvent ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = CMSConstants.Services.ArticleEventManager.Name;
            if (ValueObject.Items != null)
            {
                ValueObject.Items.TableName = CMSConstants.Entities.ArticleEvent.Items;
                p.RawData.Tables.Add(ValueObject.Items.Copy());
            }
            if (ValueObject.Categories != null)
            {
                ValueObject.Categories.TableName = CMSConstants.Entities.ArticleEvent.Categories;
                p.RawData.Tables.Add(ValueObject.Categories.Copy());
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
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEvent;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.DELETE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEvent;
        }

        #endregion

        #region Load

        public void Load()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEvent;
            if (ValueObject != null)
            {
                ValueObject.Items = p.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items];
                ValueObject.Categories = p.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories];
            }
        }

        #endregion

        #region LoadSimple

        public void LoadSimple()
        {
            Packet p = GetPacket();
            p.Action = CMSConstants.Services.ArticleEventManager.Actions.LoadSimple;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEvent;
        }

        #endregion

        #region LoadEncode

        public void LoadEncode()
        {
            Packet p = GetPacket();
            p.Action = BaseServices.CommonActions.LOAD_ENCODE;
            ServiceFacade.Execute(p);
            ValueObject = PacketUtils.TranslateTo(p) as ArticleEvent;
            if (ValueObject != null)
            {
                ValueObject.Items = p.RawData.Tables[CMSConstants.Entities.ArticleEvent.Items];
                ValueObject.Categories = p.RawData.Tables[CMSConstants.Entities.ArticleEvent.Categories];
            }
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