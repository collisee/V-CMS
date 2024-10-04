<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.PanelCategory" %>
<div class="home_right">
  <h2>
    <asp:HyperLink ID="hplCate" runat="server"></asp:HyperLink></h2>
  <table class="tb_baiduthiantuong">
    <tr>
      <asp:Repeater ID="rptCate" runat="server">
        <ItemTemplate>
          <td valign="top">
            <div style="vertical-align:top">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <img width="178" height="119" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" /></a></div>
            <h3>
              <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <%#DataBinder.Eval(Container.DataItem, "Name") %>
              </a>
            </h3>
            <div class="des">
              <%#DataBinder.Eval(Container.DataItem, "Lead") %>
            </div>
            <div class="xemchitiet">
              <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <img src="/images/xemchitiet.gif" /></a></div>
          </td>
        </ItemTemplate>
      </asp:Repeater>
    </tr>       
    <tr>
      <asp:Repeater ID="rptCate1" runat="server">
        <ItemTemplate>
          <td valign="top">
            <div style="vertical-align:top">
            <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <img alt="" width="178" height="119" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>" /></a></div>
            <h3>
              <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <%#DataBinder.Eval(Container.DataItem, "Name") %>
              </a>
            </h3>
            <div class="des">
              <%#DataBinder.Eval(Container.DataItem, "Lead") %>
            </div>
            <div class="xemchitiet">
              <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <img src="/images/xemchitiet.gif" /></a></div>
          </td>
        </ItemTemplate>
      </asp:Repeater>
    </tr>    
  </table>
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
</div>
