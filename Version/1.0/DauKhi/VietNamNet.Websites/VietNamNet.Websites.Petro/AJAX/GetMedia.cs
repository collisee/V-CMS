using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.AJAX
{
    public class GetMedia : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            int id = Utilities.ParseInt(packet.Parameters[PetroConstants.ParameterName.DOC_ID]);
            string mediaType = packet.Parameters[PetroConstants.ParameterName.MediaType];

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(id, mediaType);
        }

        private static object GetData(int id, string mediaType)
        {
            if (id > 0)
            {
                PetroHelper helper = new PetroHelper(new PetroObject());
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