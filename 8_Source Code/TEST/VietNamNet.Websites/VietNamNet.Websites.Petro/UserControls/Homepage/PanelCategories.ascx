<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategories.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.Homepage.PanelCategories" %>
<div class="cate">
  <div class="cattitle">
    <div class="bgtittle1">
      <div class="bgtittle2">
        <div class="bgtittle3">
          <asp:HyperLink ID="hplCate" runat="server"></asp:HyperLink>
        </div>
      </div>
    </div>
    <div class="clear">
      ,</div>
  </div>
  <div class="3-content">
    <asp:Repeater ID="rptCate" runat="server">
      <ItemTemplate>
        <div class="cate-content1">
          <div class="cate-img border-img">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <img width="178" height="119" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" /></a></div>
          <div class="cate-text">
            <a class="cate-<%#DataBinder.Eval(Container.DataItem, "ArticleContentTypeId") %>-link" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </a>
            <p>
              <%#DataBinder.Eval(Container.DataItem, "Lead") %>
            </p>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
  <div class="clear">
    ,</div>
  <div class="hot-list">
    <asp:Repeater ID="rptCate1" runat="server">
      <ItemTemplate>
        <div class="hot-item">
          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name") %>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
