<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContent.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.ui.BBC.PanelContent" %>

<%@ Import Namespace="VietNamNet.Framework.Common" %>
    
<div class="row" id="article">
<asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
    
    <h1 class="title" id="title">
        <%#DataBinder.Eval(Container.DataItem, "Name") %>
    </h1>
    
    <div class="date" id="date">
        Cập nhật lúc <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %> (GMT+7)
    </div>
    
    <div id="content-hidden">
        <div class="clear">,</div>
    </div>
    
    <div class="content" id="content">
        <%#DataBinder.Eval(Container.DataItem, "Detail")%>      
    </div>
    <div class="clear">,</div>
    
    </ItemTemplate>
</asp:Repeater>
</div>

<div id="article-tool" class="row">
    <a href="javascript:void(0)" onclick="window.open(window.location.href.replace('/vn/', '/vn/printbbc/'));"></a>
</div>
