<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategoryPlaylist.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.ui._3g.PanelCategoryPlaylist" %>
<div class="clip_hot">
  <div class="clip_hot_list">
    <div class="clip_list_group" id="video-list">
    </div>
  </div>
  <div class="clip_hot_center">
    <div class="clip_hot_player">
      <div id='mediaplayer'>
        Bạn cần cài đặt Flash Player để xem Video!!!
      </div>
    </div>
    <div id="video-subtitle" class="clip_hot_subtitle">
    </div>
  </div>
  <div class="clear">
    &nbsp;</div>
</div>
<div class="clip_static ">
  <div class="clip_linkurl">
    <div class="linkurl_title">
      Code:
    </div>
    <input id="embed-code" readonly="readonly" onclick="this.focus(); this.select();" type="text" class="box_linkurl" value="http://www.vietnamnet.vn" />
    <div class="clear">
      &nbsp;</div>
  </div>
  <div class="clip_rate none">
    <div class="rate_title">
      Đánh giá :</div>
    <div class="rate_star1">
      <img alt="" title="" src="/images/blank.gif" width="18px" height="34px" /></div>
    <div class="rate_star1">
      <img alt="" title="" src="/images/blank.gif" width="18px" height="34px" /></div>
    <div class="rate_star1">
      <img alt="" title="" src="/images/blank.gif" width="18px" height="34px" /></div>
    <div class="rate_star1">
      <img alt="" title="" src="/images/blank.gif" width="18px" height="34px" /></div>
    <div class="rate_star1">
      <img alt="" title="" src="/images/blank.gif" width="18px" height="34px" /></div>
    <div class="clear">
      &nbsp;</div>
  </div>
  <div class="clip_sentmail cpointer">
    <a id="cmdSendEmail" title="Gửi cho bạn bè" class="sentmail_link">
      <img alt="" title="" src="/images/blank.gif" width="130" height="39" /></a>
  </div>
  <div class="jqmWindow" id="digSendEmail">
    <table cellpadding="2" cellspacing="2">
      <tr>
        <td width="125">
          <label>
            Họ tên:</label></td>
        <td>
          <input class="w200" id="smName" name="smName" type="text">
          <span class="red">*</span>
        </td>
      </tr>
      <tr>
        <td>
          <label>
            Email của bạn:</label></td>
        <td>
          <input class="w200" id="smEmailFrom" name="smEmailFrom" type="text">
          <span class="red">*</span>
        </td>
      </tr>
      <tr>
        <td>
          <label>
            Email gửi tới:</label></td>
        <td>
          <input class="w200" id="smEmailTo" name="smEmailTo" type="text">
          <span class="red">*</span>
        </td>
      </tr>
      <tr>
        <td>
          <label>
            Lời nhắn:</label></td>
        <td>
          <textarea class="w200" id="smMessage" name="smMessage"></textarea></td>
      </tr>
      <tr>
        <td>
          &nbsp;</td>
        <td>
              <input id="hidCategoryAlias" name="hidCategoryAlias" value=""
                type="hidden">
              <input id="hidMessageId" name="hidMessageId" value="0"
                type="hidden">
              <input id="hidMessageSubject" name="hidMessageSubject" value="Trang chủ clip"
                type="hidden">
              <a href="javascript:sendEmail()">Gửi</a>
        </td>
      </tr>
    </table>
    <a href="#" class="jqmClose"></a>
  </div>
  <%--<div class="clip_face">
        <a href="#">
            <img alt="" title="" src="/images/blank.gif" width="70" height="42" /></a>
    </div>--%>
  <div class="tool2">
    <font size="2" style="font-family: Arial;"><a class="facebook" href="javascript:;"
      onclick="share_facebook();">
      <img height="39" width="28" src="/images/fb_icon.gif">
    </a><a class="tw" href="javascript:;" onclick="share_twitter();">
      <img height="39" width="28" src="/images/tw_icon.gif">
    </a></font>
  </div>
</div>

<script type="text/javascript">
    var video = {
        url: '/ajax/getTopMedia/get.html',
        data: {CateAlias: '<%=CategoryAlias %>', MediaType: 'Video'}
    }
</script>

<script type="text/javascript" src="/js/video-min.js"></script>

