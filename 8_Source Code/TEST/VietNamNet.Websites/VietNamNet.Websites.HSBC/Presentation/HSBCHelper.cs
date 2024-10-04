using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Websites.HSBC.Common;
using VietNamNet.Websites.HSBC.Common.ValueObject;
using HSBCObject = VietNamNet.Websites.HSBC.Common.ValueObject.HSBCObject;

namespace VietNamNet.Websites.HSBC.Presentation
{
  public class HSBCHelper
  {
    private HSBCObject o;

    #region HSBCHelper(HSBCObject o)

    public HSBCHelper(Common.ValueObject.HSBCObject o)
    {
      ValueObject = o;
    }

    #endregion

    #region ValueObject

    public HSBCObject ValueObject
    {
      get { return o; }
      set { o = value; }
    }

    #endregion

    #region GetPacket

    private Packet GetPacket()
    {
      Packet p = PacketUtils.TranslateFrom(ValueObject);
      p.ServiceName = HSBCConstants.Services.HSBCManager.Name;
      return p;
    }

    #endregion

    #region GetCategoryByAlias

    public DataTable GetCategoryByAlias()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetCategoryByAlias;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetCategoryArticleNumber

    public DataTable GetCategoryArticleNumber()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetCategoryArticleNumber;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetCategoryArticles

    public DataTable GetCategoryArticles()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetCategoryArticles;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetCategoryArticlesMore

    public DataTable GetCategoryArticlesMore()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetCategoryArticlesMore;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetArticle

    public DataTable GetArticle()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetArticle;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetArticleMedia

    public DataTable GetArticleMedia()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetArticleMedia;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetArticleComment

    public DataTable GetArticleComment()
    {
      Packet p = GetPacket();
      p.Action = HSBCConstants.Services.HSBCManager.Actions.GetArticleComment;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion
  }
}