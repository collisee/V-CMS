<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateBoxHoptac1.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.PanelCateBoxHoptac1" %>
<div class="hoptac_item">
  <asp:Repeater ID="rptCateTitle" runat="server">
    <ItemTemplate>
      <a class="hoptac_link" href="<%=CategoryLink %>" target="_blank">
        <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
      </a>
    </ItemTemplate>
  </asp:Repeater>
  <asp:Repeater ID="rptTop" runat="server">
    <ItemTemplate>
      <div class="hoptac_img boder-img">
        <a href='<%#ItemLink.Replace("{Id}", DataBinder.Eval(Container.DataItem, "Id").ToString()) %>' target="_blank">
          <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=100&h=57" width="100" height="57" /></a></div>
      <a href='<%#ItemLink.Replace("{Id}", DataBinder.Eval(Container.DataItem, "Id").ToString()) %>' target="_blank">
        <%#DataBinder.Eval(Container.DataItem, "Name")%>
      </a>
    </ItemTemplate>
  </asp:Repeater>
</div>
