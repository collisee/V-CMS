<%@ Import Namespace="VietNamNet.AddOn.Union.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelInfomation.ascx.cs"
  Inherits="VietNamNet.AddOn.Union.UserControls.Hompage.PanelInfomation" %>
<div id="container">
  <div class="bg-title1">
    <div class="bg-title2">
      <div class="bg-title3">
        <asp:HyperLink ID="lnkCategory" runat="server" NavigateUrl="/vn/thong-tin/index.html" class="title">Cafe VietNamNet</asp:HyperLink>        
      </div>
    </div>
  </div>
  <div class="block-body">
    <div class="cafe">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="cafe_left">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <img alt="Xem chi tiết" title="Xem chi tiết" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>"
                width="196" height="146" class="avata" />
            </a>
          </div>
          <div class="cafe_right">
            <a class="title-do" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </a>
            <div class="ct_cafe_text">
              <%#DataBinder.Eval(Container.DataItem, "Lead") %>
            </div>
            <div class="next">
              <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                Xem tiếp ››</a>
            </div>
          </div>
          <div class="clear">
            &nbsp;</div>
        </ItemTemplate>
      </asp:Repeater>
      <asp:Repeater ID="rptTopNoImage" runat="server">
        <ItemTemplate>
          <div class="cafe_right">
            <a class="title-do" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </a>
            <div class="ct_cafe_text">
              <%#DataBinder.Eval(Container.DataItem, "Lead") %>
            </div>
            <div class="next">
              <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                Xem tiếp ››</a>
            </div>
          </div>
          <div class="clear">
            &nbsp;</div>
        </ItemTemplate>
      </asp:Repeater>
      <div class="clear">
        ,</div>
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
  </div>
  <div class="bg-bgtitle1">
    <div class="bg-bgtitle2">
      <div class="bg-bgtitle3">
        &nbsp;
      </div>
    </div>
  </div>
</div>
<div class="clear">
  ,</div>
<br />