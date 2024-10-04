<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateReadOn.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.Category.PanelCateReadOn" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<br class="clear" />
<div class="pd5">
    <div class="bg_title3">
        Read on
    </div>
    <asp:Repeater ID="rptReadOn" runat="server">
        <ItemTemplate>
            <div class="hc-item">
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
