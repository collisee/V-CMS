using System;
using System.Web.Mail;
using System.Web.UI;

namespace VietNamNet.Websites.V1
{
  public partial class NewsDetailEmail : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string str;

      lblMessage.Text = String.Empty;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
      try
      {
        MailMessage mail = new MailMessage();
        mail.To = txtTo.Text;
        mail.From = txtFrom.Text;
        mail.Subject = "Link bài viết: ";
        mail.Body = txtMessage.Text;
        SmtpMail.SmtpServer = "localhost";
        SmtpMail.Send(mail);
      }
      catch (Exception ex)
      {
        lblMessage.Text = ex.Message;
      }
    }
  }
}