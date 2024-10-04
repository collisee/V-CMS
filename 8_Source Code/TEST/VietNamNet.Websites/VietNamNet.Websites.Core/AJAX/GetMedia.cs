using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.AJAX
{
    public class GetMedia : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            int id = Utilities.ParseInt(packet.Parameters[WebsitesConstants.ParameterName.DOC_ID]);
            string mediaType = packet.Parameters[WebsitesConstants.ParameterName.MediaType];

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(id, mediaType);
        }

        private static object GetData(int id, string mediaType)
        {
            if (id > 0)
            {
                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.ArticleId = id;
                helper.ValueObject.MediaType = mediaType;
                DataTable dt = helper.GetArticleMedia();

                if (dt.Rows.Count > 0 && dt.Columns.Contains("file"))
                {
                    Packet p = new Packet();
                    p.RawData.Tables.Add(dt.Copy());
                    return PacketUtils.TranslateTo(p, typeof(MediaFile));
                }
            }

            return new object();
        }
    }
}