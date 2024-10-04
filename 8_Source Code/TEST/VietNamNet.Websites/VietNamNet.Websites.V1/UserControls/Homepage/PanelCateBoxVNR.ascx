<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxVNR.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBoxVNR" %>
<div class="box-vnr500">
  <div class="vnr500">
    <div class="vnr500-title">
      <a href="http://vnr500.vietnamnet.vn" target="_blank">
        <img height="25" src="/images/blank.gif" width="145" />
      </a>
    </div>
    <div class="vnr500-text">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="cat_box1">
            <a class="left vienvnr500 boder-img" href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
              target="_blank" title="<%#DataBinder.Eval(Container.DataItem, "Name")%>">
              <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=170&height=100" />
            </a>
          </div>
          <a class="linkvnr500" href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            target="_blank">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
          <div class="vnr500_intro">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <div class="clear">
        ,</div>
      <asp:Repeater ID="rptNext" runat="server">
        <ItemTemplate>
          <div class="cat_item">
            <a href="/vn/<%#categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
              target="_blank" title="<%#DataBinder.Eval(Container.DataItem, "Name")%>" class="<%#WebsitesUtils.GetArticleIcon(Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId"))) %>">
              <%#DataBinder.Eval(Container.DataItem, "Name")%>
            </a>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
</div>
