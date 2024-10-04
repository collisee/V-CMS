using System.IO;
using System.Web;
using VietNamNet.Framework.Common;
using Telerik.Web.UI.Widgets;

namespace VietNamNet.Framework.System
{
    public class APCutomFileSystemContentProvider : FileSystemContentProvider
    {
        private readonly HttpContext _context;

        public APCutomFileSystemContentProvider(HttpContext context, string[] searchPatterns, string[] viewPaths,
                                                string[] uploadPaths, string[] deletePaths, string selectedUrl,
                                                string selectedItemTag)
            : base(context, searchPatterns, viewPaths, uploadPaths, deletePaths, selectedUrl, selectedItemTag)
        {
            _context = context;
        }

        public override DirectoryItem ResolveDirectory(string path)
        {
            DirectoryItem oldItem = base.ResolveDirectory(path);
            foreach (FileItem fileItem in oldItem.Files)
            {
                // Get the information from the physical file
                FileInfo fInfo = new FileInfo(Context.Server.MapPath(VirtualPathUtility.AppendTrailingSlash(oldItem.Path) + fileItem.Name));

                // Add the information to the attributes collection of the item. It will be automatically picked up by the FileExplorer
                // If the name attribute matches the unique name of a grid column
                fileItem.Attributes.Add("Date", fInfo.CreationTime.ToString());

                //Show thumbnails only with jpg gif or png extension

                if (Utilities.StringCompare(fileItem.Extension, ".jpg") ||
                    Utilities.StringCompare(fileItem.Extension, ".gif") ||
                    Utilities.StringCompare(fileItem.Extension, ".png") ||
                    Utilities.StringCompare(fileItem.Extension, ".jpeg"))
                {
                    fileItem.Attributes.Add("Thumb",
                                            "<img src=" +
                                            Utilities.GetThumbnailWithRND(VirtualPathUtility.AppendTrailingSlash(oldItem.Path) + fileItem.Name) +
                                            " />");
                }
            }
            return oldItem;
        }

        public override DirectoryItem ResolveRootDirectoryAsTree(string path)
        {
            DirectoryItem oldItem = base.ResolveRootDirectoryAsTree(path);
            foreach (DirectoryItem dirItem in oldItem.Directories)
            {
                // Get the information from the physical directory
                DirectoryInfo dInfo = new DirectoryInfo(Context.Server.MapPath(VirtualPathUtility.AppendTrailingSlash(dirItem.Path)));

                // Add the information to the attributes collection of the item. It will be automatically picked up by the FileExplorer
                // If the name attribute matches the unique name of a grid column

                dirItem.Attributes.Add("Date", dInfo.LastWriteTime.ToString());
            }
            return oldItem;
        }

        public override string StoreFile(Telerik.Web.UI.UploadedFile file, string path, string name, params string[] arguments)
        {
            string filePath = Utilities.FileSystem.GetFilePathNotDulicate(path, name);

            filePath = filePath.Replace('\\', '/');
            file.SaveAs(_context.Server.MapPath(filePath));

            return filePath;

            //return base.StoreFile(file, path, name, arguments);
        }

        public override string CopyFile(string sourcePath, string newPath)
        {
            if (!Nulls.IsNullOrEmpty(newPath))
            {
                string path = newPath.Substring(0, newPath.LastIndexOf("/") + 1);
                string name = newPath.Substring(newPath.LastIndexOf("/") + 1);
                newPath = Utilities.FileSystem.GetFilePathNotDulicate(path, name);
            }

            return base.CopyFile(sourcePath, newPath);
        }

        public override string DeleteFile(string path)
        {
            SystemLogging.System("Delete File", path);
            return base.DeleteFile(path);
        }

        public override string DeleteDirectory(string path)
        {
            SystemLogging.System("Delete Directory", path);
            return base.DeleteDirectory(path);
        }
    }
}