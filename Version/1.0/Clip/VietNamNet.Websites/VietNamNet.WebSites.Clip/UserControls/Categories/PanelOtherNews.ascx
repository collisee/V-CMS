<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelOtherNews.ascx.cs"
    Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelOtherNews" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="pd05">
    <div class="othernews-title pd05">
        Các tin khác</div>
    <div class="pl10">
        <asp:Repeater ID="rptOtherNews" runat="server">
            <ItemTemplate>
                <div class="pb05">
                    <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <%#DataBinder.Eval(Container.DataItem, "Name")%>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
