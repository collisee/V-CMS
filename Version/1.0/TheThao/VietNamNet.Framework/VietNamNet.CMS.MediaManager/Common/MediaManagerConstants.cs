using VietNamNet.Framework.Module;

namespace VietNamNet.CMS.MediaManager.Common
{
    public class MediaManagerConstants
    {
        #region ConfigKey

        public class ConfigKey : ModuleConstants.ConfigKey
        {
            public const string CommonDirectory = "CommonDirectory";
            public const string DeleteFromPhysical = "DeleteFromPhysical";
            public const string FileTypeAllow = "FileTypeAllow";
            public const string ImageFileType = "ImageFileType";
            public const string AudioFileType = "AudioFileType";
            public const string VideoFileType = "VideoFileType";
            public const string FlashFileType = "FlashFileType";
            public const string MaxUploadFileSize = "MaxUploadFileSize";
            public const string MaxUploadFileZipSize = "MaxUploadFileZipSize";
            public const string TempDirectory = "TempDirectory";
            public const string TemplateDirectory = "TemplateDirectory";
            public const string ThumbnailDirectory = "ThumbnailDirectory";
            public const string ThumbnailHeight = "ThumbnailHeight";
            public const string ThumbnailWidth = "ThumbnailWidth";
            public const string UpLoadDirectory = "UpLoadDirectory";
            public const string PublicDirectory = "PublicDirectory";
            public const string PublicImageDirectory = "PublicImageDirectory";
            public const string PublicAudioDirectory = "PublicAudioDirectory";
            public const string PublicVideoDirectory = "PublicVideoDirectory";
            public const string PublicServerLink = "PublicServerLink";
            public const string ImageServerLink = "ImageServerLink";
            public const string AudioServerLink = "AudioServerLink";
            public const string VideoServerLink = "VideoServerLink";
        }

        #endregion

        #region FileType

        public class FileType
        {
            public const string Image = "Image";
            public const string Audio = "Audio";
            public const string Video = "Video";
            public const string Flash = "Flash";
            public const string Other = "Other";
        }

        #endregion


        #region ParameterName

        public class ParameterName : ModuleConstants.ParameterName
        {
            public const string Popup = "Popup";
        }

        #endregion
    }
}