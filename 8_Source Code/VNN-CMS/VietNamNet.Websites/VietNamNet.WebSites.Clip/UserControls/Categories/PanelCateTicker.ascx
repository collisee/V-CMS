<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateTicker.ascx.cs" Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelCateTicker" %>
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
    <img src="/images/icon_thethao.gif" width="21" height="21" />
    <a href="#">Thể thao</a>
    <img src="/images/icon_truyenhinh.gif" width="28" height="21" />
    <a href="/vn/video-3g-hot/index.html">3G Hot</a>
    <img src="/images/icon_mobi.gif" width="20" height="21" />
    <a href="#">Mobile </a>
  </div>
  <div class="clear">
    ,</div>
</div>
