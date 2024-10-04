<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateSmallBox.ascx.cs" Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelCateSmallBox" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<div class="cate_cm">
    <div class="cm_titlte">
        <asp:Repeater ID="rptCateTitle" runat="server">
            <ItemTemplate>
                <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "CategoryUrl") %>index.html">
                    <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Repeater ID="rptSmallBox" runat="server">
        <ItemTemplate>
            <div class="thitruong_item">
                <a class="thitruong_img" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <img alt="" height="34" width="62" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=62&height=34">
                </a>
                <div class="thitruong_link">
                    <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <%#DataBinder.Eval(Container.DataItem, "Name")%>
                    </a>
                </div>
                <div class="clear">
                    ,</div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
