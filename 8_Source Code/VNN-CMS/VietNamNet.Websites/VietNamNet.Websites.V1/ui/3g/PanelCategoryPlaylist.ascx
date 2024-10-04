<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategoryPlaylist.ascx.cs"
    Inherits="VietNamNet.Websites.V1.ui._3g.PanelCategoryPlaylist" %>
<div class="clip_hot">
    <div class="clip_hot_list">
        <div class="clip_list_group" id="video-list">
        </div>
        <%--<div class="clip_scroll_pa">
        <div class="clip_scroll_chi">&nbsp;</div>
      </div>--%>
    </div>
    <div class="clip_hot_center">
        <%--<div class="clip_hot_title" id="video-title">
            &nbsp;
        </div>--%>
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
            URL :
        </div>
        <input type="text" class="box_linkurl" value="http://www.vietnamnet.vn" />
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="clip_rate">
        <div class="rate_title">
            Đánh giá :</div>
        <div class="rate_star1">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="18px" height="34px" /></div>
        <div class="rate_star1">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="18px" height="34px" /></div>
        <div class="rate_star1">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="18px" height="34px" /></div>
        <div class="rate_star1">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="18px" height="34px" /></div>
        <div class="rate_star1">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="18px" height="34px" /></div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="clip_sentmail">
        <a href="#" class="sentmail_link">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="130" height="39" /></a>
    </div>
    <div class="clip_face">
        <a href="#">
            <img src="http://res.vietnamnet.vn/images/blank.gif" width="70" height="42" /></a>
    </div>
</div>

<script type="text/javascript">
    var video = {
        url: '/ajax/getTopMedia/get.html',
        data: {CateAlias: '<%=CategoryAlias %>', MediaType: 'Video'}
    }
</script>

<script type="text/javascript" src="/js/video-min.js"></script>
