<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateTicker.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateTicker" %>
<div id="icon">
  <div>
    <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
            <a class="cate-name" href="/vn/<%=categoryUrl %>index.html"><%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%></a>
        </ItemTemplate>
    </asp:Repeater>
  </div>
  <div class="link_hot">
    <a href="#">
      <img src="/images/logoBBC.gif" width="148" height="22" /></a> <a href="#">
        <img src="/images/box_BVKH.gif" width="145" height="22" /></a>
  </div>
  
  
  
  <div class="icon-slot">
    <a href="/vn/tin-moi-nhat/index.html"><img alt="#" src="/images/icon_new.png" width="80" height="21" /></a> 
    <a href="/vn/moi-nong/index.html"><img alt="#" src="/images/icon_hot.png" width="80" height="21" /></a>
    <a href="/vn/tin-noi-bat/index.html"><img alt="#" src="/images/icon_focus.png" width="80" height="21" /></a>
  </div>
  <div class="clear">
    ,</div>
</div>
