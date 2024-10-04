<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="HotNewsDetail.aspx.cs"
    Inherits="VietNamNet.Websites.Petro.HotNewsDetail" %>

<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Register Src="UserControls/PanelRight.ascx" TagName="PanelRight" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelComment.ascx" TagName="PanelComment" TagPrefix="uc" %>
<%@ Register Src="UserControls/News/VideoPlayer.ascx" TagName="VideoPlayer" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div class="homeleft">
        <div id="article" class="row">
            <asp:HyperLink ID="hplCate" runat="server" Font-Bold="true"></asp:HyperLink>
            <br />
            <br />
            <asp:Repeater ID="rptNewsDetail" runat="server">
                <ItemTemplate>
                    <div class="content_title">
                        <%#DataBinder.Eval(Container.DataItem, "Name") %>
                    </div>
                    <div id="date" class="content_date">
                        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                        (GMT+7)
                    </div>
                    <div id="content" class="content">
                        <%#DataBinder.Eval(Container.DataItem, "Detail")%>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clearall">
                &nbsp;</div>
            <uc:VideoPlayer id="VideoPlayer1" runat="server"></uc:VideoPlayer>
            <uc:PanelComment ID="PanelComment1" runat="server"></uc:PanelComment>
            <asp:Panel ID="pnlMoreArticle" runat="server">
                <div class="td_list">
                    <div class="box-title">
                        Các tin khác
                    </div>
                    <asp:Repeater ID="rptMore" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <a href="/vn/<%#categoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </asp:Panel>
        </div>
    </div>
    <uc:PanelRight ID="PanelRight1" runat="server" />
</asp:Content>
