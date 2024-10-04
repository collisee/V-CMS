using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using Telerik.Web.UI;
using VietNamNet.CMS.MediaManager.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.ImageUtility;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.MediaManager
{
    public partial class DocumentManager : BasePage
    {
        protected int imageHeight =
            Utilities.ParseInt(Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.ThumbnailHeight));

        protected int imageWidth =
            Utilities.ParseInt(Utilities.GetConfigKey(MediaManagerConstants.ConfigKey.ThumbnailWidth));

        protected bool isUpload = false;
        protected string uploadAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //hidden buttons in Upload form
                FileExplorer1.Upload.ControlObjectsVisibility = ControlObjectsVisibility.None;
                
                List<string> viewFolders = new List<string>();
                List<string> deleteFolders = new List<string>();
                List<string> uploadFolders = new List<string>();

                FileExplorer1.InitialPath = MediaManagerUtils.GetUserFolderByDay().Replace("~", "");
                if (!isViewer) FileExplorer1.Configuration.ViewPaths = viewFolders.ToArray();
                if (!isUpload) FileExplorer1.Configuration.UploadPaths = uploadFolders.ToArray();
                if (!isDeleter) FileExplorer1.Configuration.DeletePaths = deleteFolders.ToArray();

                FileExplorer1.Configuration.SearchPatterns = MediaManagerUtils.GetFileTypeSearchPatterns();

                FileExplorer1.Configuration.MaxUploadFileSize = MediaManagerUtils.GetMaxUploadFileZip();
            }

            //RadMenuItem preview = new RadMenuItem("Preview");
            //preview.PostBack = false;
            //preview.Value = "Preview";
            //FileExplorer1.GridContextMenu.Items.Insert(1, preview);
            //RadMenuItem resize = new RadMenuItem("Resize (image only)");
            //resize.PostBack = false;
            //resize.Value = "Resize";
            //FileExplorer1.GridContextMenu.Items.Add(resize);
            RadMenuItem unzip = new RadMenuItem("Unzip (zip only)");
            unzip.PostBack = false;
            unzip.Value = "Unzip";
            FileExplorer1.GridContextMenu.Items.Add(unzip);

            FileExplorer1.GridContextMenu.OnClientItemClicked = "OnGridContextItemClicked";

            //add new column
            AddDateAndThumbColumns();

            //add search
            AddSearchBar(FileExplorer1, null);
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            //aplly search
            string searchText = GetSerchText(FileExplorer1); // retrives the serach paterns from the TextBox

            // Holds the modified search paterns. Every patern contains wildcards
            string[] paterns = ApplyModificatorType(FileExplorer1, searchText);

            if (paterns == null)
            {
                // no paterns found
                // show all files
                FileExplorer1.Configuration.SearchPatterns = MediaManagerUtils.GetFileTypeSearchPatterns();
            }
            else
            {
                // Use the paterns
                FileExplorer1.Configuration.SearchPatterns = paterns;
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.DocumentManager";
            viewAlias = "VietNamNet.CMS.DocumentManager.View";
            uploadAlias = "VietNamNet.CMS.DocumentManager.Upload";
            deleteAlias = "VietNamNet.CMS.DocumentManager.Delete";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isUpload = SystemUtils.GetPolicy(UserId, moduleAlias, uploadAlias);
        }

        private void ExtractZipFile(string path, string name)
        {
            string filePath = Path.Combine(path, name);
            string realFilePath = Request.MapPath(filePath);

            ZipFile zipFile = new ZipFile(realFilePath);

            string[] patterns = MediaManagerUtils.GetFileTypeSearchPatterns();

            foreach (ZipEntry zipEntry in zipFile)
            {
                if (zipEntry.IsFile)
                {
                    string fileFolder = Path.GetDirectoryName(zipEntry.Name);
                    string fileName = Path.GetFileName(zipEntry.Name);
                    string newPath = Path.Combine(path, fileFolder);
                    string realFolder = Request.MapPath(newPath);
                    if (!Directory.Exists(realFolder))
                    {
                        Directory.CreateDirectory(realFolder);
                    }

                    if (Utilities.FileSystem.IsValidFileTypeAfterUnZip(fileName, patterns))
                    {
                        fileName = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), fileName);
                        string newFileName = Utilities.FileSystem.GetFilePathNotDulicate(newPath, fileName);
                        string realNewFileName = Request.MapPath(newFileName);

                        Stream stream = zipFile.GetInputStream(zipEntry);

                        using (FileStream FS = File.Create(realNewFileName))
                        {
                            int i = 2048;
                            byte[] b = new byte[2049];
                            while (true)
                            {
                                i = stream.Read(b, 0, b.Length);
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
            }
        }

        private ImageFormat GetImageFormat(string fileName)
        {
            switch (Path.GetExtension(fileName))
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".png":
                    return ImageFormat.Png;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        private void ResizeImageFile(string filePath, int width, int height)
        {
            string path = filePath.Substring(0, filePath.LastIndexOf("/") + 1);
            string name = filePath.Substring(filePath.LastIndexOf("/") + 1);
            string newName = name.Substring(0, name.LastIndexOf("."));
            string extension = name.Substring(name.LastIndexOf("."));

            string newFilePath = string.Format("{0}{1} [{2}x{3}]{4}", path, newName, width, height, extension);
            ImageFormat format = GetImageFormat(name);

            //Resize
            ImageUtils.ResizeFixed(Request.MapPath(filePath), width, height, format, Request.MapPath(newFilePath));
        }

        private void ResizeImageFile(string filePath)
        {
            ResizeImageFile(filePath, imageWidth, imageHeight);
        }

        private string PublicFile(string path, string name, string publicFolder)
        {
            string filePath = Path.Combine(path, name);
            string realFilePath = Request.MapPath(filePath);

            //string newFilePath = Utilities.FileSystem.GetFilePathNotDulicate(publicFolder, name);
            string newFilePath = Path.Combine(publicFolder, name);
            string realNewFilePath = Request.MapPath(newFilePath);

            //File.Copy(realFilePath, realNewFilePath);
            File.Copy(realFilePath, realNewFilePath, true);

            return newFilePath.Substring(newFilePath.LastIndexOf("/") + 1);
        }

        protected void RadAjaxPanel1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            string[] args = e.Argument.Split(new char[] {'?'}, StringSplitOptions.RemoveEmptyEntries);
            if (args == null || args.Length <= 1) return;

            string filePath = args[args.Length - 1];
            string path = filePath.Substring(0, filePath.LastIndexOf("/") + 1);
            string name = filePath.Substring(filePath.LastIndexOf("/") + 1);

            string refresh = "refreshExplorer();";

            switch (args[0])
            {
                case "unzip": //UnZip
                    ExtractZipFile(path, name);

                    RadAjaxPanel1.ResponseScripts.Add(refresh);
                    break;
                case "resize": //Resize
                    if (args.Length == 2) //Resize no params
                    {
                        ResizeImageFile(filePath);
                    }
                    else if (args.Length == 4)
                    {
                        int width = Utilities.ParseInt(args[1]);
                        int height = Utilities.ParseInt(args[2]);

                        if (width <= 0 || height <= 0) //Resize no params
                        {
                            ResizeImageFile(filePath);
                        }
                        else //Resize with params
                        {
                            ResizeImageFile(filePath, width, height);
                        }
                    }

                    RadAjaxPanel1.ResponseScripts.Add(refresh);
                    break;
                case "open": //Open
                    filePath = args[args.Length - 1];
                    string selectedFiles = string.Empty;

                    foreach (string file in filePath.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        path = file.Substring(0, file.LastIndexOf("/") + 1);
                        name = file.Substring(file.LastIndexOf("/") + 1);

                        string fileType = MediaManagerUtils.GetFileType(name);
                        string serverLink = string.Empty;
                        string publicFolder = string.Empty;

                        switch (fileType)
                        {
                            case MediaManagerConstants.FileType.Image:
                                serverLink = MediaManagerUtils.GetImageServerLinkFolder();
                                publicFolder = MediaManagerUtils.GetPublicImageFolder();
                                break;
                            case MediaManagerConstants.FileType.Audio:
                                serverLink = MediaManagerUtils.GetAudioServerLinkFolder();
                                publicFolder = MediaManagerUtils.GetPublicAudioFolder();
                                break;
                            case MediaManagerConstants.FileType.Video:
                                serverLink = MediaManagerUtils.GetVideoServerLinkFolder();
                                publicFolder = MediaManagerUtils.GetPublicVideoFolder();
                                break;
                            default:
                                serverLink = MediaManagerUtils.GetPublicServerLinkFolder();
                                publicFolder = MediaManagerUtils.GetPublicFolder();
                                break;
                        }

                        string newName = PublicFile(path, name, publicFolder);
                        string link = string.Format("{0}{1}", serverLink, newName);

                        if (!Nulls.IsNullOrEmpty(selectedFiles)) selectedFiles += ",";
                        selectedFiles += "{" + string.Format("file: '{0}', type: '{1}'", link, fileType) + "}";
                    }

                    string select = string.Format("selectFile([{0}]);", selectedFiles);
                    RadAjaxPanel1.ResponseScripts.Add(select);
                    break;
                default:
                    break;
            }
        }

        private void AddGridColumn(string name, string uniqueName, int width, bool sortable)
        {
            RemoveGridColumn(uniqueName);
            GridTemplateColumn gridTemplateColumn1 = new GridTemplateColumn();
            gridTemplateColumn1.HeaderText = name;
            if (sortable)
            {
                gridTemplateColumn1.SortExpression = uniqueName;
            }
            gridTemplateColumn1.UniqueName = uniqueName;
            gridTemplateColumn1.DataField = uniqueName;
            gridTemplateColumn1.HeaderStyle.Width = Unit.Pixel(width);
            FileExplorer1.Grid.Columns.Add(gridTemplateColumn1);
        }

        private void RemoveGridColumn(string uniqueName)
        {
            if (FileExplorer1.Grid.Columns.FindByUniqueNameSafe(uniqueName) != null)
            {
                FileExplorer1.Grid.Columns.Remove(FileExplorer1.Grid.Columns.FindByUniqueNameSafe(uniqueName));
            }
        }

        private void AddDateAndThumbColumns()
        {
            AddGridColumn("Created Date", "Date", 135, true);
            AddGridColumn("Thumb", "Thumb", 70, false);
        }

        private void AddSearchBar(RadFileExplorer explorer, string defaultSearchText)
        {
            RadToolBarButton sep = new RadToolBarButton();
            sep.IsSeparator = true;
            explorer.ToolBar.Items.Add(sep);

            RadToolBarButton button = new RadToolBarButton();
            button.EnableViewState = true;
            button.CommandName = "SearchCommand";
            button.ItemTemplate = new ToolBarButtonTemplate(defaultSearchText);
            explorer.ToolBar.Items.Add(button);
        }

        private string[] ApplyModificatorType(RadFileExplorer fileExplorer, string searchText)
        {
            if (Nulls.IsNullOrEmpty(searchText)) return null;

            //Get searchPaterns
            string[] searchPaterns = MediaManagerUtils.GetFileTypeSearchPatterns();

            // Get reference to the custom search button
            RadToolBarButton searchButton =
                fileExplorer.ToolBar.FindButtonByCommandName("SearchCommand") as RadToolBarButton;
            if (searchButton == null) return new string[] {};

            // Get reference to the RadComoBox that contains the text
            RadComboBox searchTypeSelector = searchButton.FindControl("SearchComboBox") as RadComboBox;
            if (searchTypeSelector == null) return new string[] {};

            switch (searchTypeSelector.SelectedValue)
            {
                case "StartsWith":
                    for (int i = 0; i < searchPaterns.Length; i++)
                    {
                        searchPaterns[i] = searchText + searchPaterns[i];
                    }
                    break;
                case "EndsWith":
                    for (int i = 0; i < searchPaterns.Length; i++)
                    {
                        searchPaterns[i] = "*" + searchText + searchPaterns[i].Replace("*", string.Empty);
                    }
                    break;
                case "Contains":
                    for (int i = 0; i < searchPaterns.Length; i++)
                    {
                        searchPaterns[i] = "*" + searchText + searchPaterns[i];
                    }
                    break;
                case "None":
                    searchPaterns = MediaManagerUtils.GetFileTypeSearchPatterns();
                    break;
                default:
                    // Error
                    throw new ArgumentException(searchTypeSelector.SelectedValue + " value is not expected here");
            }

            // Return the value
            return searchPaterns;
        }

        private string GetSerchText(RadFileExplorer fileExplorer)
        {
            // Get reference to the custom search button
            RadToolBarButton searchButton =
                fileExplorer.ToolBar.FindButtonByCommandName("SearchCommand") as RadToolBarButton;
            if (searchButton == null) return string.Empty;

            // Get reference to the text box that contains the text
            RadTextBox searchBox = searchButton.FindControl("SearchBox1") as RadTextBox;
            if (searchBox == null) return string.Empty;

            //check & remove some char
            if (Nulls.IsNullOrEmpty(searchBox.Text.Trim())) return string.Empty;

            string v = searchBox.Text.Trim();
            string e = string.Empty;
            v = v.Replace("*", e).Replace("?", e).Replace("%", e);

            // Return the value
            return v;
        }
    }
}