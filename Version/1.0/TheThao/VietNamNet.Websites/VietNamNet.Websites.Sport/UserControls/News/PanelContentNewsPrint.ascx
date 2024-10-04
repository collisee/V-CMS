<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentNewsPrint.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentNewsPrint" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<div class="fright button-16 button-print no-text">
    <ul class="button-function clearfix b0" style="margin-bottom: 0;">
        <li><a href="javascript:window.print()" class="button-16 button-print no-text"></a></li>
    </ul>
</div>
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
            <div class="home-article-body pdr10">
                <%#DataBinder.Eval(Container.DataItem, "Detail")%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<br class="clear" />