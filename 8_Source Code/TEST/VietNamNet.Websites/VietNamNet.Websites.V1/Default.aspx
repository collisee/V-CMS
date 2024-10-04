<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs"
    Inherits="VietNamNet.Websites.V1._Default" %>

<%@ Register Src="UserControls/PanelTicker.ascx" TagName="PanelTicker" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelTopNews.ascx" TagName="PanelTopNews"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelMoinong.ascx" TagName="PanelMoinong"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelAdvC_1_4.ascx" TagName="PanelAdvC_1_4"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelAdCenter.ascx" TagName="PanelAdCenter"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelTamdiem.ascx" TagName="PanelTamdiem" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelRadio.ascx" TagName="PanelRadio" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelLeft.ascx" TagName="PanelLeft" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelRight.ascx" TagName="PanelRight" TagPrefix="uc" %>
<%@ Register Src="UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <uc:PanelTicker ID="PanelTicker1" runat="server" />
    <div id="home4">
        <div id="home4_1">
            <uc:PanelTopNews ID="PanelTopNews1" runat="server" CategoryAlias="tin-noi-bat" FirstIndexRecord="2"
                LastIndexRecord="4" />
            <uc:PanelMoinong ID="PanelMoinong1" runat="server" CategoryAlias="moi-nong" FirstIndexRecord="1"
                LastIndexRecord="15" />
            <div class="clear">,</div>
            <uc:PanelTamdiem ID="PanelTamdiem1" runat="server" CategoryAlias="tam-diem" FirstIndexRecord="1"
                LastIndexRecord="10" />
            <%--<uc:PanelRadio ID="PanelRadio1" runat="server" CategoryAlias="radio-vietnamnet" />--%>
            <uc:PanelAdCenter ID="PanelAdCenter1" runat="server" />
        </div>
        <uc:PanelAdvC_1_4 ID="PanelAdvC_1_4_1" runat="server" />
    </div>
    <div class="clear">
        ,</div>
    <div id="home5">
        <uc:PanelLeft ID="PanelLeft1" runat="server" />
        <uc:PanelRight ID="PanelRight1" runat="server" />
        <div class="clear">
            ,</div>
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" CategoryAlias="trang-chu" />
</asp:Content>
