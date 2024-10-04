using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Layout.Mobile.Common;
using VietNamNet.Layout.Mobile.Common.ValueObject;

namespace VietNamNet.Layout.Mobile.Presentation
{
    public class VNN4MobileHelper
    {
        private VNN4MobileObject o;

        #region VNN4MobileHelper(VNN4MobileObject o)

        public VNN4MobileHelper(VNN4MobileObject o)
        {
            ValueObject = o;
        }

        #endregion

        #region ValueObject

        public VNN4MobileObject ValueObject
        {
            get { return o; }
            set { o = value; }
        }

        #endregion

        #region GetPacket

        private Packet GetPacket()
        {
            Packet p = PacketUtils.TranslateFrom(ValueObject);
            p.ServiceName = VNN4MobileConstants.Services.VNN4MobileManager.Name;
            return p;
        }

        #endregion

        #region GetCategoryByAlias

        public DataTable GetCategoryByAlias()
        {
            Packet p = GetPacket();
            p.Action = VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryByAlias;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetCategoryArticleNumber

        public DataTable GetCategoryArticleNumber()
        {
            Packet p = GetPacket();
            p.Action = VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryArticleNumber;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetCategoryArticles

        public DataTable GetCategoryArticles()
        {
            Packet p = GetPacket();
            p.Action = VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryArticles;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetCategoryArticlesMore

        public DataTable GetCategoryArticlesMore()
        {
            Packet p = GetPacket();
            p.Action = VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetCategoryArticlesMore;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetArticle

        public DataTable GetArticle()
        {
            Packet p = GetPacket();
            p.Action = VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetArticle;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion

        #region GetTopArticle

        public DataTable GetTopArticle()
        {
            Packet p = GetPacket();
            p.Action = VNN4MobileConstants.Services.VNN4MobileManager.Actions.GetTopArticle;
            ServiceFacade.Execute(p);
            return p.RawData.Tables[0];
        }

        #endregion
    }
}