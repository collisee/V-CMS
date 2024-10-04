using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.AJAX
{
    public class GetTopMedia : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            string categoryAlias = packet.Parameters[WebsitesConstants.ParameterName.CATEGORY_ALIAS];
            string mediaType = packet.Parameters[WebsitesConstants.ParameterName.MediaType];
            int items = Utilities.ParseInt(packet.Parameters[WebsitesConstants.ParameterName.Items]);

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(categoryAlias, mediaType, items);
        }

        private static object GetData(string categoryAlias, string mediaType, int items)
        {
            WebsitesHelper cateHelper = new WebsitesHelper(new WebsitesObject());
            cateHelper.ValueObject.CategoryAlias = categoryAlias;
            DataTable dtCate = cateHelper.GetCategoryByAlias();

            if (dtCate != null && dtCate.Rows.Count > 0)
            {
                int categoryId =
                    Utilities.ParseInt(dtCate.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.CategoryId]);
                int partitionId =
                    Utilities.ParseInt(dtCate.Rows[0][WebsitesConstants.Entity.WebsitesObject.FieldName.PartitionId]);

                WebsitesHelper helper = new WebsitesHelper(new WebsitesObject());
                helper.ValueObject.PartitionId = partitionId;
                helper.ValueObject.CategoryId = categoryId;
                helper.ValueObject.MediaType = mediaType;
                helper.ValueObject.FirstIndexRecord = 1;
                helper.ValueObject.LastIndexRecord = (items <= 0) ? 6 : items;
                DataTable dt = helper.GetTopMedia();

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