<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="LiveScore.aspx.cs"
    Inherits="VietNamNet.Websites.Sport.LiveScore" Title="Thể thao - VietNamNet - Kết quả - Lịch thi đấu bóng đá" %>
<%@ Register Src="UserControls/Advertisements/PanelAdvC1.ascx" TagName="PanelAdvC1" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelBBCCateBox.ascx" TagName="PanelBBCCateBox" TagPrefix="uc" %>
<%@ Register Src="UserControls/Homepage/PanelTrungthuong.ascx" TagName="PanelTrungthuong"
  TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-center">
        <div class="home-center-left pdt5">
            <div class="live-score ">
                <div class="ls-top">
                    &nbsp;</div>
                <div class="pdlr5">
                    <div class="ls-title">
                        <div class="ls-title-link">
                            <a href="javascript:void(0)" onclick="$('#ifInclude').attr({src: '/vnn/index.htm'})">
                                Lịch thi đấu </a>| <a href="javascript:void(0)" onclick="$('#ifInclude').attr({src: '/vnn/result.htm'})">
                                    Kết quả </a>
                        </div>
                    </div>
                    <div class="ls-tables">
                        <iframe id="ifInclude" frameborder="0" marginwidth="0" marginheight="0" height="550px"
                            width="670px" scrolling="yes" src="/vnn/index.htm"></iframe>
                    </div>
                </div>
                <div class="ls-bottom">
                    &nbsp;</div>
            </div>
        </div>
        <div class="home-center-right">
            <uc:paneladvc1 id="PanelAdvC1_1" runat="server" />
            <uc:PanelTrungthuong ID="PanelTrungthuong1" runat="server" CategoryAlias="trung-thuong" />
            <uc:panelbbccatebox id="PanelBBCCateBox1" runat="server" categoryalias="bbc-tieng-viet" />
        </div>
        <br class="clear" />
    </div>
</asp:Content>
