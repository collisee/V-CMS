<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTamdiem3g.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelTamdiem3g" %>
<div class="clip_most">
  <div class="clip_most_title">
    &nbsp;
  </div>
  <div class="clip_most_list">
    <asp:Repeater ID="rptNext" runat="server">
      <ItemTemplate>
        <div class="clip_most_item">
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="clip_link">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
          <div class="clip_most_group">
            <div class="clip_boder">
              <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=85&height=50" width="85" height="50" />
              </a><a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                class="play_ico_small">&nbsp;</a>
            </div>
            <div class="clip_lead ">
              <%#DataBinder.Eval(Container.DataItem, "Lead")%>
            </div>
            <div class="clear">
              &nbsp;</div>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
