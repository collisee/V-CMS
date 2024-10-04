<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTellUs.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.PanelTellUs" %>
<div class="read-box pdt8">
  <div class="bg_title2">
    readers tell us
  </div>
  <div class="read-bg">
    <asp:Repeater ID="rptLatestNews" runat="server">
      <ItemTemplate>
        <div class="read-text">
          <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <div class="read-arow">
      &nbsp;
    </div>
  </div>
</div>
