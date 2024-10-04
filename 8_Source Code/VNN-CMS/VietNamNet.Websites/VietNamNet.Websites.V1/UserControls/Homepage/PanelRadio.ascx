<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRadio.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelRadio" %>
<div class="row">
  <div class="radio">
    <div class="radio_button">
      <img src="http://res.vietnamnet.vn/images/radio_buttom.jpg" width="86" height="19" />
    </div>
    <asp:Repeater ID="rptRadio" runat="server">
      <ItemTemplate>
        <div class="radio_item">
          <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
      ,</div>
  </div>
</div>
