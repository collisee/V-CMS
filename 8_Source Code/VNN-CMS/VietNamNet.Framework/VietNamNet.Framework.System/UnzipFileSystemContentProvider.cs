using System;
using System.IO;
using System.Web;
using ICSharpCode.SharpZipLib.Zip;
using Telerik.Web.UI;
using Telerik.Web.UI.Widgets;
using VietNamNet.Framework.Common;

namespace VietNamNet.Framework.System
{
    public class UnzipFileSystemContentProvider : FileSystemContentProvider
    {
        public UnzipFileSystemContentProvider(HttpContext context, string[] searchPatterns, string[] viewPaths,
                                              string[] uploadPaths, string[] deletePaths, string selectedUrl,
                                              string selectedItemTag)
            : base(context, searchPatterns, viewPaths, uploadPaths, deletePaths, selectedUrl, selectedItemTag)
        {
            ProcessPaths(base.ViewPaths);
            ProcessPaths(base.UploadPaths);
            ProcessPaths(base.DeletePaths);
            base.SelectedUrl = RemoveProtocolNameAndServerName(GetAbsolutePath(base.SelectedUrl));
        }

        public override string StoreFile(UploadedFile file, string path, string name, params string[] arguments)
        {
            if (file.GetExtension() == ".zip")
            {
                string relFolder = path;
                string mapFolder = base.Context.Server.MapPath(relFolder);

                string lastValidFile = string.Empty;
                using (ZipInputStream ZIS = new ZipInputStream(file.InputStream))
                {
                    ZipEntry ZE = ZIS.GetNextEntry();
                    while ((ZE != null))
                    {
                        if (ZE.IsFile)
                        {
                            string fileFolder = Path.GetDirectoryName(ZE.Name);
                            string fileName = Path.GetFileName(ZE.Name);
                            string newPath = Path.Combine(path, fileFolder);
                            string realFolder = Path.Combine(mapFolder, fileFolder);

                            if (!Directory.Exists(realFolder))
                            {
                                Directory.CreateDirectory(realFolder);
                            }

                            if (Utilities.FileSystem.IsValidFileTypeAfterUnZip(fileName, base.SearchPatterns))
                            {
                                fileName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), fileName);
                                string newFileName = Utilities.FileSystem.GetFilePathNotDulicate(newPath, fileName);
                                string realNewFileName = base.Context.Server.MapPath(newFileName);
                                
                                lastValidFile = relFolder + ZE.Name;
                                using (FileStream FS = File.Create(realNewFileName))
                                {
                                    int i = 2048;
                                    byte[] b = new byte[2049];
                                    while (true)
                                    {
                                        i = ZIS.Read(b, 0, b.Length);
                                        if (i > 0)
                                        {
                                            FS.Write(b, 0, i);
                                        }
                                        else
                                        {
                                            break; // TODO: might not be correct. Was : Exit While 
                                        }
                                    }
                                }
                            }
                        }
                        ZE = ZIS.GetNextEntry();
                    }
                }
                Utilities.FileSystem.DeleteEmptyDirectoriesAfterZip(mapFolder);
                return lastValidFile;
            }
            else
            {
                name = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), name);
                string filePath = Utilities.FileSystem.GetFilePathNotDulicate(path, name);

                filePath = filePath.Replace('\\', '/');
                file.SaveAs(base.Context.Server.MapPath(filePath));

                return filePath;
            }
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