<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelClipNoibat.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.ui._3g.PanelClipNoibat" %>
<!--top statitic-->
<div class="clip-hot">
  <div class="clip-hot-title">
    Clip Nổi Bật</div>
  <asp:Repeater ID="rptClipNoibat" runat="server">
    <ItemTemplate>
      <div class="clip-hot-block">
        <div class="clip_hot_thumwar">
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="hot_thumwar">
            <img src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=170&height=95" width="170" height="95" />
          </a><a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="play_ico">&nbsp;</a>
        </div>
        <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
      </div>
    </ItemTemplate>
  </asp:Repeater>
</div>
<!--top statitic end-->
