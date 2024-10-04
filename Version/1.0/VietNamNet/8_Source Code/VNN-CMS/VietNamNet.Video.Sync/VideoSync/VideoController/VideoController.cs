using System;
using SubSonic;
using VideoDAL.Objects;
namespace VideoController
{
    public class Sync
    {
        //'----------------------------------------------------------------------------------------------------
        //'Muc dich: Ket noi den CSDL cua CMS va lay danh sach cac file Media tu bang ArticleMedia can dong bo sang server Streaming
        //'Nguoi tao: Duong Hai Phong
        //'Ngay tao: 13/09/2010
        //'Tham so dau vao: 
        //'   VideoType: La chuoi cac kieu media se duoc select de dong bo, cac gia tri cach nhau boi dau ','. Ex: "'Video','Audio'"
        //'Ket qua tra ve: ArticleMediumCollection - Mot tap hop cac doi tuong ArticleMedia
        //'----------------------------------------------------------------------------------------------------

        public ArticleMediumCollection GetVideoSource(String strSendStatus, String strDeleteStatus)
        {
            ArticleMediumCollection videoCollect = null;          
            try
            {
                videoCollect = new Select().From(ArticleMedium.Schema)
                    .Where(ArticleMedium.Columns.Flag).IsNull() 
                    .AndExpression(ArticleMedium.Columns.MediaType).IsEqualTo("Video")
                    .Or(ArticleMedium.Columns.MediaType).IsEqualTo("Audio")
                    .OrderDesc(ArticleMedium.Columns.CreatedAt)
                    .ExecuteAsCollection<ArticleMediumCollection>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return videoCollect;
        }
        public ArticleMediumCollection GetVideoSource4Del(String strDeleteStatus)
        {
            ArticleMediumCollection videoCollect = null;
            try
            {
                videoCollect = new Select().From(ArticleMedium.Schema)
                    .Where(ArticleMedium.Columns.Flag).IsEqualTo(strDeleteStatus)
                    .AndExpression(ArticleMedium.Columns.MediaType).IsEqualTo("Video")
                    .Or(ArticleMedium.Columns.MediaType).IsEqualTo("Audio")
                    .OrderAsc(ArticleMedium.Columns.Flag)
                    .ExecuteAsCollection<ArticleMediumCollection>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return videoCollect;
        }
    }
    
    
}
