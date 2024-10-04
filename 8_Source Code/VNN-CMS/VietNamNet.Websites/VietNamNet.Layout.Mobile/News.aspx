<%--<%@ OutputCache CacheProfile="SystemCache" %>--%>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="VietNamNet.Layout.Mobile.News" %>

<%@ Register Src="~/UserControls/PanelNewsDetail.ascx" TagName="PanelNewsDetail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelNewsMore.ascx" TagName="PanelNewsMore" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div class="news-category">
        <asp:HyperLink ID="lnkCategory" runat="server" NavigateUrl="/vn/index.html"></asp:HyperLink>
    </div>
    <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
    <uc:PanelNewsMore ID="PanelNewsMore1" runat="server" />
</asp:Content>
