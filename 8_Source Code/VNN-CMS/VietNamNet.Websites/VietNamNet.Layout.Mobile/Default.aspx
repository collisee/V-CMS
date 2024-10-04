<%--<%@ OutputCache CacheProfile="SystemCache" %>--%>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VietNamNet.Layout.Mobile._Default" %>
<%@ Register Src="~/UserControls/PanelTopNews.ascx" TagName="PanelTopNews" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <%--<uc:PanelTopNews ID="PanelTopNews1" runat="server" />--%>
    <uc:PanelCategory ID="PanelCategory0" runat="server" CategoryAlias="tam-diem" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory11" runat="server" CategoryAlias="tuan-vn" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory1" runat="server" CategoryAlias="xa-hoi" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory2" runat="server" CategoryAlias="chinh-tri" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory9" runat="server" CategoryAlias="the-thao" FirstIndexRecord="1" LastIndexRecord="5" />
    <%--<uc:PanelCategory ID="PanelCategory3" runat="server" CategoryAlias="phong-su-dieu-tra" FirstIndexRecord="1" LastIndexRecord="5" />--%>
    <uc:PanelCategory ID="PanelCategory4" runat="server" CategoryAlias="kinh-te" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory5" runat="server" CategoryAlias="the-gioi" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory6" runat="server" CategoryAlias="van-hoa" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory7" runat="server" CategoryAlias="khoa-hoc" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory10" runat="server" CategoryAlias="cong-nghe" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory8" runat="server" CategoryAlias="giao-duc" FirstIndexRecord="1" LastIndexRecord="5" />
    <uc:PanelCategory ID="PanelCategory13" runat="server" CategoryAlias="ban-doc" FirstIndexRecord="1" LastIndexRecord="5" />
</asp:Content>
