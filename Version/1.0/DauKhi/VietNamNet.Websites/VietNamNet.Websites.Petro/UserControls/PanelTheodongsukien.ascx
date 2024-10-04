<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTheodongsukien.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.PanelTheodongsukien" %>
<div id="home6" class="row">
  <div class="home61_1">
    <div class="home61_3">
      <div class="home61_2">
        <asp:HyperLink ID="hplCate" runat="server"></asp:HyperLink>
      </div>
    </div>
  </div>
  <div class="home62">
    <asp:Repeater ID="rptCate" runat="server">
      <ItemTemplate>
        <div class="hoptac_item">
          <div class="hoptac_img boder-img">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
              <img width="120" height="78" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" /></a></div>
          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name") %>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>    
    <div class="clear">
      ,</div>
  </div>
  <div class="home63_1">
    <div class="home63_3">
      <div class="home63_2">
        &nbsp;
      </div>
    </div>
  </div>
</div>
