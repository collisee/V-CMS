<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRight.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelRight" %>
<%@ Register Src="PanelCateBoxRight2.ascx" TagName="PanelCateBoxRight2" TagPrefix="uc" %>
<%@ Register Src="PanelCateBoxRight1.ascx" TagName="PanelCateBoxRight1" TagPrefix="uc" %>
<%@ Register Src="PanelBVKH.ascx" TagName="PanelBVKH" TagPrefix="uc" %>
<%@ Register Src="PanelHoagiaiyeuthuong.ascx" TagName="PanelHoagiaiyeuthuong" TagPrefix="uc" %>
<%@ Register Src="PanelThegioianh.ascx" TagName="PanelThegioianh" TagPrefix="uc" %>
<%@ Register Src="PanelCateBoxVNR.ascx" TagName="PanelCateBoxVNR" TagPrefix="uc" %>
<%@ Register Src="PanelCateBoxTuan.ascx" TagName="PanelCateBoxTuan" TagPrefix="uc" %>
<%@ Register Src="PanelCateBoxTTOL.ascx" TagName="PanelCateBoxTTOL" TagPrefix="uc" %>
<%@ Register Src="PanelCateBox1.ascx" TagName="PanelCateBox1" TagPrefix="uc" %>
<%@ Register Src="PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>
<%@ Register Src="PanelCateBox.ascx" TagName="PanelCateBox" TagPrefix="uc" %>
<%@ Register Src="PanelInfo.ascx" TagName="PanelInfo" TagPrefix="uc" %>
<%--<%@ Register Src="~/UserControls/Categories/PanelBoxViettel.ascx" TagName="PanelBoxViettel"
  TagPrefix="uc" %>--%>
<%@ Register Src="../../UserControls/Categories/PanelCateBuySell.ascx" TagName="PanelCateBuySell" TagPrefix="uc" %>  
<%@ Register Src="PanelAdvC_1_4.ascx" TagName="PanelAdvC_1_4" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_5.ascx" TagName="PanelAdvC_5" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_6_7.ascx" TagName="PanelAdvC_6_7" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_8_16.ascx" TagName="PanelAdvC_8_16" TagPrefix="uc" %>
<%@ Register Src="PanelAdvC_17.ascx" TagName="PanelAdvC_17" TagPrefix="uc" %>
<%@ Register Src="PanelVideoClip.ascx" TagName="PanelVideoClip" TagPrefix="uc" %>
<div class="home5right">
  <div class="home5_right">
    <uc:PanelCateBoxTuan ID="PanelCateBoxTuan1" runat="server" CategoryAlias="chuyen-trang-tuanvietnam" />
    <div class="row">
      <div class="clip">
        <uc:PanelCateBoxVNR ID="PanelCateBoxVNR1" runat="server" CategoryAlias="chuyen-trang-vnr500" />
        <uc:PanelHoagiaiyeuthuong ID="PanelHoagiaiyeuthuong1" runat="server" CategoryAlias="hoa-giai-yeu-thuong" />
      </div>
      <!-- Quảng cáo -->
      <uc:PanelAdvC_5 ID="PanelAdvC_5_1" runat="server" />
      
      <div class="clear">,</div>
      <!-- KẾT THÚC Quảng cáo -->
      <uc:PanelVideoClip ID="PanelVideoClip1" runat="server" />
      <div class="row">
        <uc:PanelBVKH ID="PanelBVKH1" runat="server" CategoryAlias="bao-ve-nguoi-tieu-dung" />
        <div class="giavang-new">
          <uc:PanelInfo ID="PanelInfo1" runat="server" />
        </div>
        <div class="clear">
          &nbsp;</div>
      </div>
      
      <div class="row">
        <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
        <uc:PanelAdvC_6_7 ID="PanelAdvC_6_7_1" runat="server" />
      </div>
      
      <div class="clear">,</div>
         
      
      <div class="pdt5">
          <uc:PanelCateBoxRight1 FirstIndexRecord="1" LastIndexRecord="3" CategoryAlias="chuyen-trang-ttol" id="PanelCateBoxRight1_1" runat="server" />
          <uc:PanelCateBoxRight2 FirstIndexRecord="1" LastIndexRecord="3" CategoryAlias="chuyen-trang-2sao" id="PanelCateBoxRight2_1" runat="server" />
        <div class="clear">,</div>
      </div>

      <div class="clear">,</div>
      <div class="row">
        <div class="tt_ck">
        <%--<uc:PanelBoxViettel id="PanelBoxViettel1" CategoryAlias="cong-nghe-thong-tin-vien-thong-mobile" FirstIndexRecord="1"
          LastIndexRecord="10" runat="server" />--%>
          <%--<uc:PanelCateBuySell FirstIndexRecord="1" LastIndexRecord="15" CategoryAlias="hop-tac-megavnn" id="PanelCateBuySell1" runat="server" />                           
          <br class="row" />--%>
          <uc:PanelCateBox1 ID="PanelCateBox1_1" runat="server" FirstIndexRecord="1" LastIndexRecord="5"
            CategoryAlias="dich-vu-truyen-thong" />
          <uc:PanelAdvC_17 ID="PanelAdvC_17_1" runat="server" />
          <uc:PanelThegioianh ID="PanelThegioianh1" runat="server" CategoryAlias="the-gioi-anh" />
          
        </div>
        <uc:PanelAdvC_8_16 ID="PanelAdvC_8_16_1" runat="server" />
      </div>
      
      <div class="clear">,</div>
    </div>
  </div>
</div>
