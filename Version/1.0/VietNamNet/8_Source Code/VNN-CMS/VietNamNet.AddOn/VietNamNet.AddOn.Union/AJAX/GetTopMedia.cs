using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.AddOn.Union.Common;
using VietNamNet.AddOn.Union.Common.ValueObject;
using VietNamNet.AddOn.Union.Presentation;

namespace VietNamNet.AddOn.Union.AJAX
{
    public class GetTopMedia : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            string categoryAlias = packet.Parameters[UnionConstants.ParameterName.CATEGORY_ALIAS];
            string mediaType = packet.Parameters[UnionConstants.ParameterName.MediaType];

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(categoryAlias, mediaType);
        }

        private static object GetData(string categoryAlias, string mediaType)
        {
            UnionHelper cateHelper = new UnionHelper(new UnionObject());
            cateHelper.ValueObject.CategoryAlias = categoryAlias;
            DataTable dtCate = cateHelper.GetCategoryByAlias();

            if (dtCate != null && dtCate.Rows.Count > 0)
            {
                //hplCate.Text =
                //    dt.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryDisplayName].ToString();
                //hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

                int categoryId =
                    Utilities.ParseInt(dtCate.Rows[0][UnionConstants.Entity.UnionObject.FieldName.CategoryId]);
                int partitionId =
                    Utilities.ParseInt(dtCate.Rows[0][UnionConstants.Entity.UnionObject.FieldName.PartitionId]);

                UnionHelper helper = new UnionHelper(new UnionObject());
                helper.ValueObject.PartitionId = partitionId;
                helper.ValueObject.CategoryId = categoryId;
                helper.ValueObject.MediaType = mediaType;
                helper.ValueObject.FirstIndexRecord = 1;
                helper.ValueObject.LastIndexRecord = 3;
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