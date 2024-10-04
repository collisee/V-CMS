using System;
using System.IO;
using System.Net;
using Telerik.Web.UI;
using VietNamNet.CMS.MediaManager.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles
{
    public partial class PopupInsertRolo : BasePageView
    {
        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.Save:
                    //logging
                    SystemLogging.Info("Get Rolo news", txtTitle.Text);

                    DoSave();
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(Constants.FormNames.Default);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Private Method

        private void Initialize()
        {
            dynamicLayout = false;
        }

        private void StoreFile(string source, string publicFolder, string fileName)
        {
            string filePath = Path.Combine(publicFolder, fileName);
            string physicalFilePath = Request.MapPath(filePath);

            WebClient client = new WebClient();
            //client.DownloadFile(source, filePath);
            Stream streamRemote = client.OpenRead(new Uri(source));
            Stream streamLocal = new FileStream(physicalFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

            int iByteSize = 0;
            byte[] byteBuffer = new byte[256];
            while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
            {
                streamLocal.Write(byteBuffer, 0, iByteSize);
            }

            streamLocal.Close();
            streamRemote.Close();
        }

        private void DoSave()
        {
            string fileName = string.Format("{0}_rolo.jpg", DateTime.Now.ToString("yyyyMMddHHmmss"));
            string fileType = MediaManagerUtils.GetFileType(fileName);
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

            string source = txtImage.Text;
            StoreFile(source, publicFolder, fileName);

            txtImage.Text = string.Format("{0}{1}", serverLink, fileName);
        }

        #endregion
    }
}