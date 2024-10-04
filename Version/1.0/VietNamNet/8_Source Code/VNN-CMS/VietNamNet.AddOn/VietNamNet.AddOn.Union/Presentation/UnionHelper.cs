using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using UnionObject=VietNamNet.AddOn.Union.Common.ValueObject.UnionObject;

namespace VietNamNet.AddOn.Union.Presentation
{
  public class UnionHelper
  {
    private UnionObject o;

    #region UnionHelper(UnionObject o)

    public UnionHelper(Common.ValueObject.UnionObject o)
    {
      ValueObject = o;
    }

    #endregion

    #region ValueObject

    public UnionObject ValueObject
    {
      get { return o; }
      set { o = value; }
    }

    #endregion

    #region GetPacket

    private Packet GetPacket()
    {
      Packet p = PacketUtils.TranslateFrom(ValueObject);
      p.ServiceName = UnionConstants.Services.UnionManager.Name;
      return p;
    }

    #endregion

    #region GetCategoryByAlias

    public DataTable GetCategoryByAlias()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetCategoryByAlias;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetCategoryArticleNumber

    public DataTable GetCategoryArticleNumber()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetCategoryArticleNumber;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetCategoryArticles

    public DataTable GetCategoryArticles()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetCategoryArticles;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetCategoryArticlesMore

    public DataTable GetCategoryArticlesMore()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetCategoryArticlesMore;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetArticle

    public DataTable GetArticle()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetArticle;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetArticleMedia

    public DataTable GetArticleMedia()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetArticleMedia;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetArticleComment

    public DataTable GetArticleComment()
    {
      Packet p = GetPacket();
      p.Action = UnionConstants.Services.UnionManager.Actions.GetArticleComment;
      ServiceFacade.Execute(p);
      return p.RawData.Tables[0];
    }

    #endregion

    #region GetTopMedia

    public DataTable GetTopMedia()
    {
        Packet p = GetPacket();
        p.Action = UnionConstants.Services.UnionManager.Actions.GetTopMedia;
        ServiceFacade.Execute(p);
        return p.RawData.Tables[0];
    }

    #endregion
}
}