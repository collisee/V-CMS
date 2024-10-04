<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelLiveScore.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelLiveScore" %>
<div class="live-score ">
  <div class="ls-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="ls-title">
      <div class="ls-title-link">
        <a href="javascript:void(0)" onclick="$('#ifInclude').attr({src: '/vnn/index.htm'})">Lịch thi đấu </a>| 
        <a href="javascript:void(0)" onclick="$('#ifInclude').attr({src: '/vnn/result.htm'})">Kết quả </a>
      </div>
    </div>
    <div class="ls-tables">
        <iframe id="ifInclude" frameborder="0" marginwidth="0" marginheight="0" height="218px" width="670px" scrolling="yes" src="/vnn/index.htm"></iframe>
    </div>
    <div class="ls-xemthem">
      <a href="/vn/ket-qua/index.html">Xem thêm </a>
    </div>
  </div>
  <div class="ls-bottom">
    &nbsp;</div>
</div>
