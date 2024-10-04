<%@ Import Namespace="VietNamNet.AddOn.Union.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelAlbumTop.ascx.cs"
  Inherits="VietNamNet.AddOn.Union.UserControls.PanelAlbumTop" %>
<div class="row">
  <div class="bg-title1">
    <div class="bg-title2">
      <div class="bg-title3">
        <a href="/vn/album-top-hit/index.html" class="title">Album Top Hit</a>
      </div>
    </div>
  </div>
  <div class="block-body">
    <asp:Repeater ID="rptTopNoImg" runat="server">
      <ItemTemplate>
        <div class="acc_img">
          <img src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" class="avata" width="150" height="100" />          
        </div>
        <div class="acc_text">
        <center>
          <a class="ghichu" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%--<a class="ghichu" href="NewsMedia.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Id") %>">--%>
            <em>
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </em></a></center>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rptTop" runat="server">
      <ItemTemplate>
        <div class="acc_img">
          <img src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" width="150" height="100"
            class="avata" />
        </div>
        <div class="acc_text">
        <center>
          <a class="ghichu" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%--<a class="ghichu" href="NewsMedia.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Id") %>">--%>
            <em>
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </em></a></center>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <div class="list">
      <asp:Repeater ID="rptMore" runat="server">
        <ItemTemplate>
          <div class="item">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%--<a class="ghichu" href="NewsMedia.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Id") %>">--%>
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </a>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
  <div class="bg-bgtitle1">
    <div class="bg-bgtitle2">
      <div class="bg-bgtitle3">
        &nbsp;
      </div>
    </div>
  </div>
</div>