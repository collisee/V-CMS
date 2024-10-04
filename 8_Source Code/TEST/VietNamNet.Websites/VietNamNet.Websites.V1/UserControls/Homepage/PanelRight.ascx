<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRight.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelRight" %>
<%@ Register Src="PanelPoll.ascx" TagName="PanelPoll" TagPrefix="uc" %>
<%@ Register Src="PanelCateBoxVNR.ascx" TagName="PanelCateBoxVNR" TagPrefix="uc" %>
<%@ Register Src="PanelCateBoxTuan.ascx" TagName="PanelCateBoxTuan" TagPrefix="uc" %>
<%@ Register Src="PanelCateBox1.ascx" TagName="PanelCateBox1" TagPrefix="uc" %>
<%@ Register Src="PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>
<%@ Register Src="PanelCateBox.ascx" TagName="PanelCateBox" TagPrefix="uc" %>
<%@ Register Src="PanelInfo.ascx" TagName="PanelInfo" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_1_4.ascx" TagName="PanelAdvC_1_4" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_5.ascx" TagName="PanelAdvC_5" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_6_7.ascx" TagName="PanelAdvC_6_7" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_8_16.ascx" TagName="PanelAdvC_8_16" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_17.ascx" TagName="PanelAdvC_17" TagPrefix="uc" %>
<div class="home5right">
    <div class="home5_right">
        <uc:PanelCateBoxTuan ID="PanelCateBoxTuan1" runat="server" CategoryAlias="chuyen-trang-tuanvietnam" />
        <div class="row">
            <div class="clip">
                <uc:PanelCateBoxVNR ID="PanelCateBoxVNR1" runat="server" CategoryAlias="chuyen-trang-vnr500" />
                <!-- Quảng cáo -->
                <div class="row">
                   <div id="ad_c_nd">
                   </div>
                </div>
                <!-- KẾT THÚC Quảng cáo -->
            </div>
            <uc:PanelAdvC_5 ID="PanelAdvC_5_1" runat="server" />
            <div class="clear">
                ,</div>
            <uc:PanelCateBox ID="PanelCateBox1" runat="server" CategoryAlias="bao-ve-nguoi-tieu-dung" />
            <uc:PanelInfo ID="PanelInfo1" runat="server" />
            <div class="row">
                <uc:PanelMostRead ID="PanelMostRead1" runat="server" CategoryAlias="xa-hoi" />
                <uc:PanelAdvC_6_7 ID="PanelAdvC_6_7_1" runat="server" />
            </div>
            <div class="clear">
                ,</div>
            <uc:PanelCateBox ID="PanelCateBox2" runat="server" CategoryAlias="chuyen-trang-ttol" />
            <div class="clear">
                ,</div>
            <div class="row">
                <div class="tt_ck">
                    <uc:PanelPoll ID="PanelPoll1" runat="server" />
                    <uc:PanelCateBox1 ID="PanelCateBox1_1" runat="server" CategoryAlias="thi-truong" />
                    <uc:PanelAdvC_17 ID="PanelAdvC_17_1" runat="server" />
                </div>
                <uc:PanelAdvC_8_16 ID="PanelAdvC_8_16_1" runat="server" />
            </div>
            <div class="clear">
                ,</div>
        </div>
    </div>
</div>
