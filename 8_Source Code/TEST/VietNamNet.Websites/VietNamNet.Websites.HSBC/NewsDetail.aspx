<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="NewsDetail.aspx.cs"
    Inherits="VietNamNet.Websites.HSBC.NewsDetail" %>
<%@ Import namespace="VietNamNet.Websites.HSBC.Common"%>

<%@ Import Namespace="VietNamNet.Framework.Common" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div class="home_right">
        <h2>
            <asp:HyperLink ID="hplCate" runat="server"></asp:HyperLink>
        </h2>
        <asp:Repeater ID="rptNewsDetail" runat="server">
            <ItemTemplate>
                <div class="chitiet_noidung">
                    <h3>
                        <%#DataBinder.Eval(Container.DataItem, "Name") %>
                    </h3>
                    <div class="article_time">
                        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                        (GMT+7)
                    </div>
                    <div class="article_content">
                        <%#DataBinder.Eval(Container.DataItem, "Detail")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clearall">&nbsp;</div>
        <asp:Panel ID="pnlMoreArticle" runat="server">
            <!-- bai du thi khac -->
            <div class="baiduthikhac">
                <h2>
                    Các bài đã đưa</h2>
                <ul>
                    <asp:Repeater ID="rptMore" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="/vn/<%#categoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#HSBCUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"><%#DataBinder.Eval(Container.DataItem, "Name") %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
