<%@ Import Namespace="VietNamNet.AddOn.Union.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelArticleTop.ascx.cs"
  Inherits="VietNamNet.AddOn.Union.UserControls.PanelArticleTop" %>
<div class="row">
  <div class="bg-title1">
    <div class="bg-title2">
      <div class="bg-title3">
        <a href="/vn/bai-hit-trong-tuan/index.html" class="title">Audio hit trong tuần</a>
      </div>
    </div>
  </div>
  <div class="block-body">
    <div class="list">
      <asp:Repeater ID="rptMore" runat="server">
        <ItemTemplate>
          <div class="item">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
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