using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Websites.Core.Common.ValueObject;
using VietNamNet.Websites.Core.Presentation;

namespace VietNamNet.Websites.Core.AJAX
{
    public class GetPhoto : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            int id = Utilities.ParseInt(packet.Parameters[WebsitesConstants.ParameterName.DOC_ID]);
            string mediaType = packet.Parameters[WebsitesConstants.ParameterName.MediaType];

            packet.Type = AJAXType.XML;
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
                    Photos photos = new Photos();

                    foreach (DataRow row in dt.Rows)
                    {
                        Photo photo = new Photo();
                        photo.FileName = row["file"].ToString() + "?w=108";
                        photo.Link = row["file"].ToString();
                        photo.Description = row["description"].ToString();

                        photos.PhotoColection.Add(photo);
                    }

                    return photos;
                }
            }

            return new object();
        }
    }
}
