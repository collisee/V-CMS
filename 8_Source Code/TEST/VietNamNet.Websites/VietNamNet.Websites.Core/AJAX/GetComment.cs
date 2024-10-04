using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.AJAX
{
  public class GetComment : AJAXService
  {
    public override void Execute(AJAXPacket packet)
    {
      int index = Utilities.ParseInt(packet.Parameters["index"]);
      int messageId = Utilities.ParseInt(packet.Parameters["m"]);
      
      packet.Type = AJAXType.JavaScriptObject;
      packet.Value = GetData(index, messageId);
    }

    private static object GetData(int index, int mid)
    {
      //Get PageNumber
      int pageSize = Utilities.GetCommentPageSize();
      if (index <= 0) index = 1;

      WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
      helper.ValueObject.ArticleId = mid;
      helper.ValueObject.FirstIndexRecord = (index - 1) * pageSize + 1;
      helper.ValueObject.LastIndexRecord = index * pageSize;
      DataTable dt = helper.GetArticleComment();

      if (dt != null && dt.Rows.Count > 0)
      {
        Packet p = new Packet();
        p.RawData.Tables.Add(dt.Copy());
        return PacketUtils.TranslateTo(p, typeof(Comments));
      }

      return null;
    }
  }
}