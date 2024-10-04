<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentCateName.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.News.PanelContentCateName" %>
<div class="bg_title3">
    <asp:Repeater ID="rptCateName" runat="server">
        <ItemTemplate>
            <a class="cate-name" href="/en/<%=categoryUrl %>index.html">
                <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>
