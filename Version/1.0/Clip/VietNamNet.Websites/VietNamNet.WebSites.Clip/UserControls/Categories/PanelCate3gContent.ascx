<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCate3gContent.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelCate3gContent" %>
<div id="list-clip-new" class="row">
  <asp:Repeater ID="rptListContent" runat="server">
    <ItemTemplate>
      <div class="clip_item_1">
        <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "clip_thumwar" %>">
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=142&height=80" width="142" height="80"
              class="thumwar" />
          </a><a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            class="play_ico">&nbsp;</a>
        </div>
        <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
          class="clip_link_1">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
        <div class="clip_lead_new">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
        <div class="ratting_list">
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="clear">
            ,</div>
        </div>
        <div class="clear">
          ,</div>
      </div>
    </ItemTemplate>
    <AlternatingItemTemplate>
      <div class="clip_item_2">
        <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "clip_thumwar" %>">
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=142&height=80" width="142" height="80"
              class="thumwar" />
          </a><a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            class="play_ico">&nbsp;</a>
        </div>
        <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
          class="clip_link_1">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
        <div class="clip_lead_new">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
        <div class="ratting_list">
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="clear">
            ,</div>
        </div>
        <div class="clear">
          ,</div>
      </div>
    </AlternatingItemTemplate>    
  </asp:Repeater>
</div>
<div id="paging">
  <table border="0" width="100%">
    <tr>
      <td align="left">
        <asp:HyperLink ID="hplPrev" runat="server">&lt;&lt;Trang trước</asp:HyperLink>
      </td>
      <td align="right">
        <asp:HyperLink ID="hplNext" runat="server">Trang sau&gt;&gt;</asp:HyperLink>
      </td>
    </tr>
  </table>
  <div class="clear">
    ,</div>
</div>
