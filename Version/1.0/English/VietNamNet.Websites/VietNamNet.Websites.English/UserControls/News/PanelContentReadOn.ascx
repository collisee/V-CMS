<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentReadOn.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.News.PanelContentReadOn" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="content-right">
    <div class="bg_title3 red52">Read on</div>
    <div class="content-readon">
        <asp:Repeater ID="rptPanelContentReadOn" runat="server">
            <ItemTemplate>
                <div class="hc-item">
                    <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <%#DataBinder.Eval(Container.DataItem, "Name")%>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
