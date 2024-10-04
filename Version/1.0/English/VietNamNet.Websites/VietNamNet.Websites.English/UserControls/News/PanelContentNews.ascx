<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentNews.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.News.PanelContentNews" %>
<%@ Register Src="PanelContentPhoto.ascx" TagName="PanelContentPhoto" TagPrefix="uc" %>
<%@ Register Src="PanelContentVideo.ascx" TagName="PanelContentVideo" TagPrefix="uc" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<asp:Repeater ID="rptContent" runat="server">
    <ItemTemplate>
        <div class="pdtb10">
            <div class="content-update">
                Last update <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                (GMT+7)
            </div>
            <div class="content-share">
                <a href="javascript:void(0)" onclick="share_facebook();" class="fl_l">
                    <img alt="" src="/images/blank.gif" width="16" height="16" />
                </a>
                
                <a href="javascript:void(0)" onclick="share_twitter();" class="fl_l">
                    <img alt="" src="/images/blank.gif" width="16" height="16" />
                </a>
                
                <div class="fl_l">
                    <a href="http://www.addthis.com/bookmark.php?v=250&amp;username=xa-4cae93db4d7923db" class="addthis_button_compact">
                        <span  class="addthis_toolbox addthis_default_style">
                        <img alt="" src="/images/blank.gif" width="16" height="16" />
                        </span>     
                    </a>
                    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=xa-4cae93db4d7923db"></script>
                </div>
                <a id="cmdSendEmail" title="Send to friend" class="mail" href="javascript:void(0);">
                    <img alt="" src="/images/blank.gif" width="16" height="16" />
                </a><a class="print" href="javascript:void(0)" onclick="window.open(window.location.href.replace('/en/', '/en/print/'));">
                    <img alt="" src="/images/blank.gif" width="16" height="16" />
                </a>
                <br class="clear" />
            </div>
            <br class="clear" />
        </div>
        <div class="content-title pdb10">
            <%#DataBinder.Eval(Container.DataItem, "Name") %>
        </div>
        <div id="content" class="article_content">
            <%#DataBinder.Eval(Container.DataItem, "Detail")%>
        </div>
        <div class="jqmWindow" id="digSendEmail">
            <table cellpadding="2" cellspacing="2">
                <tr>
                    <td width="125">
                        <label>
                            Name:</label></td>
                    <td>
                        <input class="w200" id="smName" name="smName" type="text">
                        <span class="red">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Email from:</label></td>
                    <td>
                        <input class="w200" id="smEmailFrom" name="smEmailFrom" type="text">
                        <span class="red">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Email to:</label></td>
                    <td>
                        <input class="w200" id="smEmailTo" name="smEmailTo" type="text">
                        <span class="red">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Messages:</label></td>
                    <td>
                        <textarea class="w200" id="smMessage" name="smMessage"></textarea></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <input id="hidCategoryAlias" name="hidCategoryAlias" value="<%#DataBinder.Eval(Container.DataItem, "Url") %>"
                            type="hidden">
                        <input id="hidMessageId" name="hidMessageId" value="<%#DataBinder.Eval(Container.DataItem, "Id") %>"
                            type="hidden">
                        <input id="hidMessageSubject" name="hidMessageSubject" value="<%#DataBinder.Eval(Container.DataItem, "Name") %>"
                            type="hidden">
                        <a href="javascript:sendEmail()">Send</a>
                    </td>
                </tr>
            </table>
            <a href="#" class="jqmClose"></a>
        </div>
    </ItemTemplate>
</asp:Repeater>
<uc:PanelContentPhoto ID="PanelContentPhoto1" runat="server" />
<uc:PanelContentVideo ID="PanelContentVideo1" runat="server" />
