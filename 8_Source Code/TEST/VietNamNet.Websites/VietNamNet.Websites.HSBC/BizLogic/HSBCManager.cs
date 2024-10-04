using System;
using System.Data;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.HSBC.Common;
using VietNamNet.Websites.HSBC.DBAccess;

namespace VietNamNet.Websites.HSBC.BizLogic
{
  /// <summary>
  /// Summary description for HSBCManager.
  /// </summary>
  public class HSBCManager : Facade
  {
    #region Override Execute

    public override Packet Execute(Packet param)
    {
      switch (param.Action)
      {
        case HSBCConstants.Services.HSBCManager.Actions.GetCategoryByAlias:
          GetCategoryByAlias(param);
          break;
        case HSBCConstants.Services.HSBCManager.Actions.GetCategoryArticleNumber:
          GetCategoryArticleNumber(param);
          break;
        case HSBCConstants.Services.HSBCManager.Actions.GetCategoryArticles:
          GetCategoryArticles(param);
          break;
        case HSBCConstants.Services.HSBCManager.Actions.GetCategoryArticlesMore:
          GetCategoryArticlesMore(param);
          break;
        case HSBCConstants.Services.HSBCManager.Actions.GetArticle:
          GetArticle(param);
          break;
        case HSBCConstants.Services.HSBCManager.Actions.GetArticleMedia:
          GetArticleMedia(param);
          break;
        case HSBCConstants.Services.HSBCManager.Actions.GetArticleComment:
          GetArticleComment(param);
          break;
        default:
          break;
      }
      return param;
    }

    #endregion

    #region Execute Actions

    #region Function GetCategoryByAlias

    private void GetCategoryByAlias(Packet param)
    {
      DataTable dt = HSBCDAO.GetCategoryByAlias(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #region Function GetCategoryArticleNumber

    private void GetCategoryArticleNumber(Packet param)
    {
      DataTable dt = HSBCDAO.GetCategoryArticleNumber(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #region Function GetCategoryArticles

    private void GetCategoryArticles(Packet param)
    {
      DataTable dt = HSBCDAO.GetCategoryArticles(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #region Function GetCategoryArticlesMore

    private void GetCategoryArticlesMore(Packet param)
    {
      DataTable dt = HSBCDAO.GetCategoryArticlesMore(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #region Function GetArticle

    private void GetArticle(Packet param)
    {
      DataTable dt = HSBCDAO.GetArticle(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #region Function GetArticleMedia

    private void GetArticleMedia(Packet param)
    {
      DataTable dt = HSBCDAO.GetArticleMedia(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #region Function GetArticleComment

    private void GetArticleComment(Packet param)
    {
      DataTable dt = HSBCDAO.GetArticleComment(param.RawData.Tables[0].Rows[0]);
      param.RawData.Tables.Clear();
      param.RawData.Tables.Add(dt.Copy());
    }

    #endregion

    #endregion
  }
}