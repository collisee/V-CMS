using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Xml;
using System.Net;
using System.Configuration;


namespace GetContentFromRolo
{
    //Muc dich: Chua cac ham tien ich de lay du lieu XML tu Rolo
    //Nguoi tao: PhongDH
    //Ngay tao: 20/09/2010
    public class Utils
    {
        //Muc dich: Lay du lieu XML tu doi tac Rolo
        //Nguoi tao: PhongDH
        //Ngay tao: 20/09/2010
        //Tham so dau vao:
        //  -url: La chuoi String chua du lieu XML ma Rolo cung cap
        //Gia tri tri ve: La chuoi XML lay duoc tu url truyen vao
        public XmlDocument GetXmlFromUrl(String url, String strKey)
        {
            String strReturn = "";
            Uri xmlUri = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream receiveStream = null;
            XmlReader xmlReader = null;
            XmlDocument doc = new XmlDocument();

            try
            {
                url = url + "&apikey=" + strKey;
                XmlTextReader xmlTextReader = new XmlTextReader(url);
                xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
                doc.Load(xmlTextReader);
            }
            catch (Exception ex)
            {
                WriteLog(this.LogPath, ex.ToString(), "GetXmlFromUrl:Error", DateTime.Now.ToString());
            }
            return doc;
        }

        //Muc dich: Ghi log cua he thong
        //Nguoi tao: PhongDH
        //Ngay tao: 20/09/2010
        //Tham so dau vao:
        //  -logFile: Ten file log voi day du duong dan
        //  -logContent: Noi dung log duoc ghi vao file
        //  -logLevel: Muc do log
        //  -logTime: thoi gian ghi log
        //Gia tri tri ve: Khong co
        public void WriteLog(String logFile, String logContent, String logLevel, String logTime)
        {
            StreamWriter mStreamWriter = null;
            try
            {
                logFile = logFile + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate, FileAccess.Write);
                mStreamWriter = new StreamWriter(fs);
                mStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                mStreamWriter.WriteLine(logTime + ":" + logLevel + "-->" + logContent);
                mStreamWriter.Flush();
                mStreamWriter.Close();

            }
            catch (Exception ex)
            {
                
                throw;
                
            } finally
            {
                //if (mStreamWriter != null)
                //{
                //    mStreamWriter.Flush();
                //    mStreamWriter.Close();
                //}
            }
        }
        //Muc dich: Lay gia tri cua 1 key trong file app.config
        //Nguoi tao: PhongDH
        //Ngay tao: 20/09/2010
        //Tham so dau vao:
        //  -key: Ten key trong file config
        //Gia tri tri ve: La gia tri cua key do trong file config; Neu ko tim thay thi tra ve gia tri trong
        public String GetAppSetting(String key)
        {
            String strReturn = "";
            try
            {
                strReturn = ConfigurationManager.AppSettings[key] ?? "";
            }
            catch (Exception)
            {
                
                throw;
            }
            return strReturn;
        }
	    /// Muc dich: Lay anh tu url va save xuong dia
	    /// <param name="url">URL address to download image</param>
	    /// <returns>Image</returns>
	    public System.Drawing.Image DownloadImage(string url)
	    {
            System.Drawing.Image tmpImage = null;
    	 
	        try
	        {
	            // Open a connection
	            System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
    	 
	            httpWebRequest.AllowWriteStreamBuffering = true;
    	 
	            // You can also specify additional header values like the user agent or the referer: (Optional)
	            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
	            httpWebRequest.Referer = "http://www.google.com/";
    	 
	            // set timeout for 20 seconds (Optional)
	            httpWebRequest.Timeout = 20000;
    	 
	            // Request response:
	            System.Net.WebResponse webResponse = httpWebRequest.GetResponse();
    	 
	            // Open data stream:
	            System.IO.Stream webStream = webResponse.GetResponseStream();
    	 
	            // convert webstream to image
	            if (webStream != null) 
                    tmpImage = System.Drawing.Image.FromStream(webStream);

	            // Cleanup
	            webResponse.Close();
	            webResponse.Close();
	        }
	        catch (Exception exception)
	        {
                WriteLog(this.LogPath, exception.ToString(), "Error", DateTime.Now.ToString());
	            return null;
	        }
	        return tmpImage;

	    }
        public Boolean SaveImageToDisk(string url,String imgName, Utils utils)
        {
            System.Drawing.Image image = null;
            String imageDir = "";
            //String imgNameInConfig = "";
            Boolean saveResult = false;
            try
            {
                image = this.DownloadImage(url);
                // check for valid image
                if (image != null)
                {
                    //imgNameInConfig = this.GetAppSetting("imageName");
                    imageDir = this.GetAppSetting("imageDir");
                    if (imageDir != null && !imageDir.Equals("") && imgName != null && !imgName.Equals(""))
                    {
                        // lets save image to disk
                        image.Save(imageDir +  imgName);
                        saveResult = true;
                    }
                    
                }else
                {
                    WriteLog(utils.LogPath, "Can not save image -->" + url + " to disk", "SaveImageToDisk::Warning", DateTime.Now.ToString());
                }
                
            }
            catch (Exception exception)
            {
                WriteLog(this.LogPath, exception.ToString(), "SaveImageToDisk::Error", DateTime.Now.ToString());
                saveResult = false;
            }
            return saveResult;
        }
        ///Muc dich: Tạo đường link ảnh đại diện khi 1 tin được insert vào bảng Article
        ///Nguoi tao: PhongDH
        ///Ngay tao: 21/09/2010
        ///Tham so dau vao:
        ///  -imgName: Tên file ảnh
        ///Gia tri tri ve: Đường link của file ảnh trên hệ thống V-CMS
        public String BuildImageLink(String datetimeDir, String imgName)
        {
            try
            {
                //String strDateTime = DateTime.Now.ToString("yyyy/MM/dd/hh");
                String imgLink = this.GetAppSetting("imageLink");
                String imgNameConfig = this.GetAppSetting("imageName").Replace("{DATE}", imgName);
                return imgLink.Replace("{DATE}", datetimeDir).Replace("{IMAGE}", imgNameConfig);
            }
            catch (Exception)
            {
                return null;
            } 
        }
        ///Muc dich: Lay duong link de lay noi dung tin chi tiet cua Rolo
        ///Nguoi tao: PhongDH
        ///Ngay tao: 21/09/2010
        ///Tham so dau vao:
        ///  -newsId: Id cua tin
        ///Gia tri tri ve: Đường link của tin can lay noi dung chi tiet
        public String BuildNewsDetailLink(String newsId)
        {
            DateTime dateTime = new DateTime();
            try
            {
                String newsContentLink = this.GetAppSetting("newsContentLink");
                return newsContentLink.Replace("{ID}", newsId);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        ///Muc dich: Tao thu muc moi
        ///Nguoi tao: PhongDH
        ///Ngay tao: 21/09/2010
        ///Tham so dau vao:
        ///  -strDir: Ten cua thu muc can tao
        ///Gia tri tri ve: Đường link của tin can lay noi dung chi tiet
        public void CreateDir(String strDir)
        {
            String strDirCheck = "";
            try
            {
                strDirCheck = this.GetAppSetting("imageDir") + strDir;
                if (!Directory.Exists(strDirCheck))
                {
                    Directory.CreateDirectory(strDirCheck);
                    
                }
            }
            catch (Exception exception)
            {
                WriteLog(this.LogPath, exception.ToString(), "CreateDir::Error", DateTime.Now.ToString());
            }
        }
        ///Muc dich: Tao thu muc moi
        ///Nguoi tao: PhongDH
        ///Ngay tao: 21/09/2010
        ///Tham so dau vao:
        ///  -strDir: Ten cua thu muc can tao
        ///Gia tri tri ve: Đường link của tin can lay noi dung chi tiet
        public Boolean IsExistedDir(String strDir)
        {
            String strDirCheck;
            try
            {
                if (Directory.Exists(strDir))
                {
                    return true;
                }else {
                    return false;
                }
            }
            catch (Exception)
            {
                //WriteLog(this.LogPath, exception.ToString(), "CreateDir::Error", DateTime.Now.ToString());
                return false;
            }
        }
        public object[] StringToArray(string input, string separator, Type type)
        {
            string[] stringList = input.Split(separator.ToCharArray(),
                                              StringSplitOptions.RemoveEmptyEntries);
            object[] list = new object[stringList.Length];

            for (int i = 0; i < stringList.Length; i++)
            {
                list[i] = Convert.ChangeType(stringList[i], type);
            }

            return list;
        }
        public String LogPath = "";
    }
    
}
