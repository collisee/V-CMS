using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using VietNamNet.Framework.AJAX;
using VietNamNet.Framework.Common;
using VietNamNet.Websites.Core.Common;

namespace VietNamNet.Websites.Core.AJAX
{
    public class SendEmail : AJAXService
    {
        public override void Execute(AJAXPacket packet)
        {
            string tempSubject = "[VietNamNet] {0}";
            //string tempContent = "Bạn: SENDER_NAME " +
            //                           " (email: SENDER_EMAIL) gửi bạn bài báo: ARTICLE_TITLE<br />SENDER_HTTP<br/>" +
            //                           " với lời nhắn: SENDER_MESSAGE" +
            //    " <hr> Email này được gửi bằng tiện ích \"Gửi cho bạn bè\" của VietNamNet.vn.<br>" +
            //    " Đây là Email tự động, vui lòng đừng trả lời Email này. Nếu có vấn đề xin liên hệ với chúng tôi. " +
            //    " Neu khong doc duoc xin vui long chon View/Unicode UTF-8 tren trinh duyet dang dung.";

            string tempContent = "";


            string name = packet.Parameters["name"];
            string emailFrom = packet.Parameters["emailFrom"];
            string emailTo = packet.Parameters["emailto"];
            string message = packet.Parameters["message"];
            string catAlias = packet.Parameters["cat"];
            string articleId = packet.Parameters["aid"];
            string subject = packet.Parameters["subject"];

            //send mail
            EmailPacket email = new EmailPacket();
            email.Subject = string.Format(tempSubject, subject);
            email.To = emailTo;
            //email.Cc = hidEmailCC.Value;
            //email.Bcc = hidEmailBCC.Value;
            //email.Body = string.Format(tempContent.Replace("SENDER_NAME",HttpUtility.HtmlEncode(name))
            //                                .Replace("SENDER_EMAIL", HttpUtility.HtmlEncode(emailFrom))
            //                                .Replace("SENDER_MESSAGE", HttpUtility.HtmlEncode(message))
            //                                .Replace("SENDER_HTTP", "http://vietnamnet.vn/vn/" + catAlias + articleId + "/" + WebsitesUtils.BuildLink(subject)+ ".html"  )
            //                                .Replace("ARTICLE_TITLE", subject));

            email.EmailTemplate = HttpContext.Current.Server.MapPath(WebsitesConstants.EmailTemplates.SendEmailArticle);

            //Build mail
            Hashtable hst = new Hashtable();
            hst.Add("name", name);
            hst.Add("emailFrom", emailFrom);
            hst.Add("message", message);
            hst.Add("catAlias", catAlias);
            hst.Add("articleId", articleId);
            hst.Add("subject", subject);
            hst.Add("article_link", "/vn/" + catAlias + articleId + "/" + WebsitesUtils.BuildLink(subject) + ".html");

            email.SendEmail(hst);

            packet.Type = AJAXType.HTML;
            packet.Value = "Email have been sent!";
        }
    }
}
