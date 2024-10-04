<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentNews.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentNews" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<div>
  <asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
      <p class="pdt8 sub-title">
        <%#DataBinder.Eval(Container.DataItem, "Title") %>        
      </p>
      <h1 class="article-title">
        <%#DataBinder.Eval(Container.DataItem, "Name") %>
      </h1>
      <%--<p class="article-des">
        <%#DataBinder.Eval(Container.DataItem, "Lead") %>
      </p>--%>
      <p class="article-date">
        Cập nhật lúc
        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
        (GMT+7)
      </p>
      <ul class="button-function clearfix">
        <li><a href="http://www.addthis.com/bookmark.php?v=250&amp;username=xa-4cae93db4d7923db"
          class="button-16 button-shared addthis_button_compact"><span class="addthis_toolbox addthis_default_style">
            <img alt="" src="http://res.vietnamnet.vn/images/blank.gif" width="16" height="16" />
          </span></a>

          <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=xa-4cae93db4d7923db"></script>

          <%--<a href="http://www.addthis.com/bookmark.php?v=250&amp;username=xa-4cae93db4d7923db" class="addthis_button_compact">
               <span class="addthis_toolbox addthis_default_style">
                Chia sẻ
               </span>
            </a>  --%>
        </li>
        <li><a href="javascript:void(0)" onclick="share_twitter();" class="button-16 button-twitter no-text" title="Chia sẻ bài viết với bạn bè trên Twitter">
        </a></li>
        <li><a href="javascript:void(0)" onclick="share_facebook();" class="button-16 button-facebook no-text" title="Chia sẻ bài viết với bạn bè trên Facebook">
        </a></li>
        <li><a class="button-16 button-discussion no-text" href="#youridea" title="Gửi ý kiến thảo luận"></a></li>
        <li><a class="button-16 button-email no-text mail" href="javascript:void(0)" title="Gửi bài viết cho bạn bè"></a></li>
        <li><a class="button-16 button-print no-text" href="javascript:void(0)" onclick="window.open(window.location.href.replace('/vn/', '/vn/print/'));" title="In bài viết">
        </a></li>
      </ul>
      <div class="jqmWindow" id="digSendEmail">
        <table cellpadding="2" cellspacing="2">
          <tr>
            <td width="125">
              <label>
                Họ tên:</label></td>
            <td>
              <input class="w200" id="smName" name="smName" type="text">
              <span class="red">*</span>
            </td>
          </tr>
          <tr>
            <td>
              <label>
                Email của bạn:</label></td>
            <td>
              <input class="w200" id="smEmailFrom" name="smEmailFrom" type="text">
              <span class="red">*</span>
            </td>
          </tr>
          <tr>
            <td>
              <label>
                Email gửi tới:</label></td>
            <td>
              <input class="w200" id="smEmailTo" name="smEmailTo" type="text">
              <span class="red">*</span>
            </td>
          </tr>
          <tr>
            <td>
              <label>Lời nhắn:</label></td>
            <td>
              <textarea class="w200" id="smMessage" name="smMessage"></textarea></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>
                <div class="mess"></div>
              <input id="hidCategoryAlias" name="hidCategoryAlias" value="<%#DataBinder.Eval(Container.DataItem, "Url") %>"
                type="hidden">
              <input id="hidMessageId" name="hidMessageId" value="<%#DataBinder.Eval(Container.DataItem, "Id") %>"
                type="hidden">
              <input id="hidMessageSubject" name="hidMessageSubject" value="<%#DataBinder.Eval(Container.DataItem, "Name") %>"
                type="hidden">
              <a href="javascript:sendEmail()">Gửi</a>
            </td>
          </tr>
        </table>
        <a href="#" class="jqmClose"></a>
      </div>
      <div class="home-article-body pdr10">
        <%#DataBinder.Eval(Container.DataItem, "Detail")%>
      </div>
    </ItemTemplate>
  </asp:Repeater>
</div>
