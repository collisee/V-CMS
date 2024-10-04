using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;
using VietNamNet.Framework.Common.Captcha;

namespace VietNamNet.WebSites.Clip
{
  public partial class UploadClip : Page
  {
    public string filename;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            genImage();
        }
    }
    protected void btSend_Click(object sender, EventArgs e)
    {      
      HttpPostedFile myFile = FileUpload1.PostedFile;

      string strContenType = myFile.ContentType;
      long intnFileLeng = Convert.ToUInt32(myFile.ContentLength);

      if (FileUpload1.HasFile)
      {
        if ((strContenType == "video/x-flv") || (strContenType == "video/avi") || (strContenType == "video/3gpp") || (intnFileLeng < 20971520))
        {
          try
          {
              filename = DateTime.Now.ToString("yyyyMMddhhmss")+"_" + myFile.FileName;
              string strPath = Utilities.GetConfigKey("UploadVideoPath");

              try
              {
                  if (CaptchaGenerator.IsValidText(txtValidCode.Text))
                  {
                      FileUpload1.SaveAs(strPath + filename);
                      genImage();
                      lblNotify.Text = "Cám ơn thông tin bạn đã gửi.";
                      SendMail();
                      ClearForm();

                      string ipUpload = Utilities.GetConfigKey("ipUpload");
                      string userUpload = Utilities.GetConfigKey("userUpload");
                      string passwordUpload = Utilities.GetConfigKey("passwordUpload");

                      int succ=FtpUpload(strPath,filename,ipUpload, userUpload, passwordUpload);

                      if (succ==1)
                      {
                          File.Delete(strPath + filename);
                      }
                  }
                  else
                  {
                      lblNotify.Text = "Bạn nhập sai mã bảo vệ";                      
                  }
              }
              catch (Exception)
              {
                  lblNotify.Text = "Có lỗi trong quá trình gửi.";
                  throw;
              }             
              
          }
          catch (Exception ex)
          {
            lblMessage.Text = "Có lỗi: " + ex.Message.ToString();
          }
        }
        else
        {
          lblMessage.Text = "Chỉ cho phép file dạng video và file zip, dung lượng nhỏ hơn 20Mb";
        }
      }
      else
      {
        lblMessage.Text = "Chưa nhập file.";
      }
    }
    private void genImage()
      {
          int width = Utilities.ParseInt(Utilities.GetConfigKey(WebsitesConstants.ConfigKey.ValidImageWidth));
          int height = Utilities.ParseInt(Utilities.GetConfigKey(WebsitesConstants.ConfigKey.ValidImageheight));
          imgValidCode.Width = Unit.Pixel(width);
          imgValidCode.Height = Unit.Pixel(height);
          imgValidCode.ImageUrl = CaptchaGenerator.Generate(width, height);

      }
    protected void SendMail()
    {
      try
      {
          //define mail
          EmailPacket email = new EmailPacket();
          email.To = Utilities.GetConfigKey("Address_mail");
          email.Subject = Utilities.GetConfigKey("Subject_mail");
          email.EmailTemplate = HttpContext.Current.Server.MapPath(WebsitesConstants.EmailTemplates.UploadClip);

          //Build mail
          Hashtable hst = new Hashtable();
          hst.Add("name",yourname.Value);
          hst.Add("emailFrom", youremail.Value);
          hst.Add("phone",yourphone.Value);
          hst.Add("notes",yournote.Text);
          hst.Add("subject",yoursubject.Value);
          hst.Add("userfile", filename);
          
          email.SendEmail(hst);
      }
      catch (Exception ex)
      {
        lblMessage.Text = ex.Message;
      }
    }
    protected void ClearForm()
    {
      yourname.Value = "";
      youremail.Value = "";
      yoursubject.Value = "";
      yourphone.Value = "";
      yournote.Text = "";
    }

    private int FtpUpload(string vfilepath,string vfilename, string ftpServerIp, string ftpUserId, string ftpPassword)
      {
          int success = 1;

          System.IO.FileInfo _FileInfo = new System.IO.FileInfo(vfilepath+vfilename);
          System.Net.FtpWebRequest _FtpWebRequest = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(new Uri(ftpServerIp+vfilename));
        
          _FtpWebRequest.Credentials = new System.Net.NetworkCredential(ftpUserId, ftpPassword);
          _FtpWebRequest.KeepAlive = false;
          _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
          _FtpWebRequest.UseBinary = true;
          _FtpWebRequest.ContentLength = _FileInfo.Length;

          int buffLength = 4096;
          byte[] buff = new byte[buffLength];
          System.IO.FileStream _FileStream = _FileInfo.OpenRead();

          try
          {
              System.IO.Stream _Stream = _FtpWebRequest.GetRequestStream();
              int contentLen = _FileStream.Read(buff, 0, buffLength);
              while (contentLen != 0)
              {
                  _Stream.Write(buff, 0, contentLen);
                  contentLen = _FileStream.Read(buff, 0, buffLength);
              }

              _Stream.Close();
              _Stream.Dispose();
              _FileStream.Close();
              _FileStream.Dispose();
          }
          catch (Exception ex)
          {
              success = 0;
          }

          return success;
      }

  }
}