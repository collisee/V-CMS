<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsDetail.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.News.PanelNewsDetail" %>
<asp:Repeater ID="rptNewsDetail" runat="server">
  <ItemTemplate>
    <div id="article" class="row">
      <div id="title" class="content_title">
        <%#DataBinder.Eval(Container.DataItem, "Name") %>
      </div>
      <div id="date" class="content_date">
        Cập nhật lúc
        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
        (GMT+7)
      </div>
      <div id="content" class="article_content">
        <%#DataBinder.Eval(Container.DataItem, "Detail")%>
      </div>
    </div>
    <div class=" tool row" id="article-tool">
      <font size="2" style="font-family: Arial;"></font>
      <div class="tool2">
        <font size="2" style="font-family: Arial;"><a class="facebook" href="javascript:;"
          onclick="share_facebook();">
          <img height="39" width="28" src="/images/fb_icon.gif">
        </a><a class="tw" href="javascript:;" onclick="share_twitter();"  >
          <img height="39" width="28" src="/images/tw_icon.gif">
        </a></font>
      </div>
      <font size="2" style="font-family: Arial;"></font>
      <div class="tool1">
        <font size="2" style="font-family: Arial;"><span class="chiase">Chia sẻ</span> 
        <a title="In bài này" class="print" href="javascript:void(0)"  onclick="window.open(window.location.href.replace('/vn/', '/vn/print/'));">In bài này</a> 
        <a id="cmdSendEmail" title="Gửi cho bạn bè" class="mail" > Gửi bài</a> 
        <a title="Gửi phản hồi" class="feedback" href="<%#DataBinder.Eval(Container.DataItem, "Id") %>"> Gửi phản hồi</a> </font>
      </div>
    </div>
     
    <div class="jqmWindow" id="digSendEmail">
        <table cellpadding="2" cellspacing="2" >
            <tr>
                <td width="125"><label>Họ tên:</label></td>
                <td> <input class="w200" id="smName" name="smName" type="text">
                    <span class="red">*</span>
                </td>
            </tr>
            <tr>
                <td><label>Email của bạn:</label></td>
                <td> <input class="w200" id="smEmailFrom" name="smEmailFrom" type="text" >
                    <span class="red">*</span>
                </td>
            </tr>
            <tr>
                <td><label>Email gửi tới:</label></td>
                <td> <input class="w200" id="smEmailTo" name="smEmailTo" type="text">
                    <span class="red">*</span>
                </td>
            </tr>
            <tr>
                <td><label>Lời nhắn:</label></td>
                <td> <textarea class="w200" id="smMessage" name="smMessage" ></textarea></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <input id="hidCategoryAlias" name="hidCategoryAlias" value="<%#DataBinder.Eval(Container.DataItem, "Url") %>" type="hidden">
                    <input id="hidMessageId" name="hidMessageId" value="<%#DataBinder.Eval(Container.DataItem, "Id") %>" type="hidden">
                    <input id="hidMessageSubject" name="hidMessageSubject" value="<%#DataBinder.Eval(Container.DataItem, "Name") %>" type="hidden">
                    <a href="javascript:sendEmail()">Gửi</a>
                </td>
            </tr>
        </table>
    
    <a href="#" class="jqmClose"></a>
    </div> 
  </ItemTemplate>
</asp:Repeater> 

                    