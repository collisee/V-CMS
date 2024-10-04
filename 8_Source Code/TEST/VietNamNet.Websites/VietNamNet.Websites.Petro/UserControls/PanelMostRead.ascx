<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMostRead.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.PanelMostRead" %>
<asp:Repeater ID="rptMostRead" runat="server">
  <HeaderTemplate>
    <div class="new_hot_list">
  </HeaderTemplate>
  <ItemTemplate>
    <div class="new_hot_item" showlead="true">
      <a lead="true" class="new_hot_link" href="/vn/tin-top/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
        <%#DataBinder.Eval(Container.DataItem, "Name") %>
      </a>
      <div class="leadContent none">
        <%#DataBinder.Eval(Container.DataItem, "Lead") %>
      </div>
    </div>
  </ItemTemplate>
  <FooterTemplate>
    </div>
  </FooterTemplate>
</asp:Repeater>
