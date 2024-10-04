using System.Data;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Petro.Common;
using VietNamNet.Websites.Petro.Common.ValueObject;
using VietNamNet.Websites.Petro.Presentation;

namespace VietNamNet.Websites.Petro.AJAX
{
    public class GetTopMedia : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            string categoryAlias = packet.Parameters[PetroConstants.ParameterName.CATEGORY_ALIAS];
            string mediaType = packet.Parameters[PetroConstants.ParameterName.MediaType];

            packet.Type = AJAXType.JavaScriptObject;
            packet.Value = GetData(categoryAlias, mediaType);
        }

        private static object GetData(string categoryAlias, string mediaType)
        {
            PetroHelper cateHelper = new PetroHelper(new PetroObject());
            cateHelper.ValueObject.CategoryAlias = categoryAlias;
            DataTable dtCate = cateHelper.GetCategoryByAlias();

            if (dtCate != null && dtCate.Rows.Count > 0)
            {
                //hplCate.Text =
                //    dt.Rows[0][PetroConstants.Entity.PetroObject.FieldName.CategoryDisplayName].ToString();
                //hplCate.NavigateUrl = string.Format("/vn/{0}/index.html", CategoryAlias);

                int categoryId =
                    Utilities.ParseInt(dtCate.Rows[0][PetroConstants.Entity.PetroObject.FieldName.CategoryId]);
                int partitionId =
                    Utilities.ParseInt(dtCate.Rows[0][PetroConstants.Entity.PetroObject.FieldName.PartitionId]);

                PetroHelper helper = new PetroHelper(new PetroObject());
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