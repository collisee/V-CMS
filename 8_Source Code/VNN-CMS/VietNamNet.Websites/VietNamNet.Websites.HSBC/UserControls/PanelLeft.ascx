<%@ Import Namespace="VietNamNet.Websites.HSBC.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelLeft.ascx.cs" Inherits="VietNamNet.Websites.HSBC.UserControls.PanelLeft" %>
<div class="home_left">
    <h2>
        <a href="/vn/thong-tin-ben-le-cuoc-thi/index.html">Thông tin bên lề cuộc thi</a></h2>
    <asp:Repeater ID="rptMore" runat="server">
        <ItemTemplate>
            <div style="padding-bottom:10px;">
                <div class="thumb">
                    <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#HSBCUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <img width="104" height="71" alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>"></a></div>
                <h3>
                    <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#HSBCUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <%#DataBinder.Eval(Container.DataItem, "Name") %>
                    </a>
                </h3>
                <div class="des">
                    <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                    <a class="readmore" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#HSBCUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        xem tiếp</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
