<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Category.aspx.cs"
    Inherits="VietNamNet.Websites.V1.ui.xahoi.Category" %>

<%@ Register Src="~/UserControls/Categories/PanelOtherNews.ascx" TagName="PanelOtherNews"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Homepage/PanelCateBox1.ascx" TagName="PanelCateBox1"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Categories/PanelCatePoll.ascx" TagName="PanelCatePoll"
    TagPrefix="vnnSurvey" %>
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
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <uc:PanelCateTicker ID="PanelCateTicker1" runat="server" />
    <div id="home4">
        <div id="home4_1">
            <uc:PanelCateHotNews CategoryAlias="xa-hoi" FirstIndexRecord="2" LastIndexRecord="4"
                ID="PanelCateHotNews1" runat="server" />
            <uc:PanelCateCenterPoint CategoryAlias="xa-hoi" FirstIndexRecord="1" LastIndexRecord="3"
                ID="PanelCateCenterPoint1" runat="server" />
            <div class="clear">
                ,</div>
            <uc:PanelCateHotSlide CategoryAlias="xa-hoi" FirstIndexRecord="5" LastIndexRecord="9"
                ID="PanelCateHotSlide1" runat="server" />
        </div>
        <div id="home4_2">
            <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_2" runat="server" />
        </div>
    </div>
    <div class="clear">
        ,</div>
    <div id="home5">
        <div class="home5left">
            <div>
                <uc:PanelAdvB_1 ID="PanelAdvB_1_1" runat="server" />
            </div>
            <uc:PanelCateContent FirstIndexRecord="1" LastIndexRecord="10" ID="PanelCateContent1"
                runat="server" />
            <uc:PanelOtherNews ID="PanelOtherNews1" runat="server" />            
        </div>
        <div class="home5right">
            <div class="home5_right">
                <uc:PanelCateBox CategoryAlias="xa-hoi-chuyen-dong-tre" FirstIndexRecord="1" LastIndexRecord="3"
                    ID="PanelCateBox1" runat="server" />
                <uc:PanelCateBox CategoryAlias="xa-hoi-ghi-tu-phap-dinh" FirstIndexRecord="1" LastIndexRecord="3"
                    ID="PanelCateBox2" runat="server" />
                <div class="row">
                    <uc:PanelMostRead CategoryAlias="xa-hoi" ID="PanelMostRead1" runat="server" />
                    <uc:PanelAdvC_4_5 ID="PanelAdvC_4_5_1" runat="server" />
                    <div class="clear">
                    </div>
                </div>
                <div class="row">
                    <div>
                        <div class="tt_ck">
                            <uc:PanelCateBox1 CategoryAlias="xa-hoi-tieu-diem" ID="PanelCateBox1_1" runat="server" />
                            <uc:PanelCateBox1 CategoryAlias="xa-hoi-dong-su-kien" ID="PanelCateBox1_2" runat="server" />
                            <vnnSurvey:PanelCatePoll ID="PanelCatePoll1" runat="server" />
                        </div>
                        <uc:PanelAdvC_6_14 ID="PanelAdvC_6_14_1" runat="server" />
                        <div class="clear">
                            ,</div>
                    </div>
                </div>
                <div class="row">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
