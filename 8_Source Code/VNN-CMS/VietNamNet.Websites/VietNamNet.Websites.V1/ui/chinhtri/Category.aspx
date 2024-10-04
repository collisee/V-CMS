<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Category.aspx.cs"
    Inherits="VietNamNet.Websites.V1.ui.chinhtri.Category" %>

<%@ Register Src="~/UserControls/Survey/PaneSurvey.ascx" TagName="PaneSurvey" TagPrefix="vnn" %>
<%@ Register Src="~/UserControls/Categories/PanelOtherNews.ascx" TagName="PanelOtherNews" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox1.ascx" TagName="PanelCateBox1"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox.ascx" TagName="PanelCateBox"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateTicker.ascx" TagName="PanelCateTicker"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelMostRead.ascx" TagName="PanelMostRead"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateContentViewDate.ascx" TagName="PanelCateContentViewDate"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvB_1.ascx" TagName="PanelAdvB_1"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateContent.ascx" TagName="PanelCateContent"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateHotNews.ascx" TagName="PanelCateHotNews"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateCenterPoint.ascx" TagName="PanelCateCenterPoint"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCateHotSlide.ascx" TagName="PanelCateHotSlide"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelAdvC_17.ascx" TagName="PanelAdvC_17" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />
    <div id="home4">
        <div id="home4_1">
            <uc:PanelCateHotNews ID="PanelCateHotNews1" runat="server" />
            <uc:PanelCateCenterPoint FirstIndexRecord="2" LastIndexRecord="4"
                ID="PanelCateCenterPoint1" runat="server" />
            <div class="clear">,</div>
            <uc:PanelCateHotSlide CategoryAlias="chinh-tri" FirstIndexRecord="1" LastIndexRecord="15"
                ID="PanelCateHotSlide1" runat="server" />
        </div>
        <div id="home4_2">
            <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_2" runat="server" />
        </div>
    </div>
    <div class="clear">,</div>
    <div id="home5">
        <div class="home5left">
            <div>
                <uc:PanelAdvB_1 ID="PanelAdvB_1_1" runat="server" />
            </div>
            <uc:PanelCateContent ID="PanelCateContent1" runat="server" />
            <uc:PanelOtherNews ID="PanelOtherNews1" runat="server" />            
        </div>
        <div class="home5right">
            <div class="home5_right">
                <uc:PanelCateBox CategoryAlias="bao-ve-nguoi-tieu-dung" FirstIndexRecord="1" LastIndexRecord="4" ID="PanelCateBox2" runat="server" />
                <div class="row">
                    <uc:PanelMostRead CategoryAlias="xa-hoi" ID="PanelMostRead1" runat="server" />
                    <uc:PanelAdvC_4_5 ID="PanelAdvC_4_5_1" runat="server" />
                    <div class="clear">
                    </div>
                </div>
                <div class="row">
                    <div>
                        <div class="tt_ck">
                            <uc:PanelCateBox1 FirstIndexRecord="1" LastIndexRecord="3" CategoryAlias="chinh-tri-dong-su-kien" ID="PanelCateBox1_2" runat="server" />
                            <uc:PanelCateBox1 FirstIndexRecord="1" LastIndexRecord="3" CategoryAlias="chinh-tri-tieu-diem" ID="PanelCateBox1_1" runat="server" />
                            <uc:PanelAdvC_17 ID="PanelAdvC_17_1" runat="server" />
                             <vnn:PaneSurvey ID="PaneSurvey1" runat="server" CategoryAlias="chinh-tri" />
                        </div>
                        <uc:PanelAdvC_6_14 ID="PanelAdvC_6_14_1" runat="server" />
                        <div class="clear">,</div>
                    </div>
                </div>
                <div class="row"></div>
            </div>
        </div>
        <div class="clear">,</div>
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
