using System.Data;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Union.AJAX
{
    public class GetMedia : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            int id = Utilities.ParseInt(packet.Parameters[UnionConstants.ParameterName.DOC_ID]);
            string mediaType = packet.Parameters[UnionConstants.ParameterName.MediaType];

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(id, mediaType);
        }

        private static object GetData(int id, string mediaType)
        {
            if (id > 0)
            {
                UnionHelper helper = new UnionHelper(new UnionObject());
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