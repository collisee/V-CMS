<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.AddOn.Union.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
    Inherits="VietNamNet.AddOn.Union.UserControls.Categories.PanelCategory" %>
<div id="container">
    <div class="bg-title1">
        <div class="bg-title2">
            <div class="bg-title3">
                <%--<a href="#" class="title">Cate</a>--%>
                <asp:HyperLink ID="hplCate" runat="server" class="title"></asp:HyperLink>
            </div>
        </div>
    </div>
    <div class="block-body">
        <asp:Repeater ID="rptTop" runat="server">
            <ItemTemplate>
                <div class="cat_list row">
                    <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "boder-img" %>">
                        <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                            <img alt="Xem chi tiết" title="Xem chi tiết" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>"
                                width="120" height="75" />
                        </a>
                    </div>
                    <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "cat_text1" : "cat_text" %>">
                        <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                            <%#DataBinder.Eval(Container.DataItem, "Name") %>
                        </a>
                        <div class="cat_intro">
                            <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                        </div>
                        <%--<div class="next none">
                          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                            Xem tiếp ››</a>
                        </div>--%>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="list">
            <div class="cm-title">
                CÁC BÀI KHÁC</div>
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
    <div class="bg-bgtitle1">
        <div class="bg-bgtitle2">
            <div class="bg-bgtitle3">
                &nbsp;
            </div>
        </div>
    </div>
</div>
