<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelLiveTV.ascx.cs"
    Inherits="VietNamNet.WebSites.Clip.UserControls.PanelLiveTV" %>
<div class="clip_hot" style="height:490px;">
    <div id='mediaplayer'>
        <object width="670" height="420" align="middle" id="Object1" classid="clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6">
            <param value="mms://tv.vietnamnet.vn/live" name="URL" />
            <param value="0" name="currentPosition" />
            <param value="999" name="playCount" />
            <param value="0" name="autoStart" />
            <param value="0" name="currentMarker" />
            <param value="-1" name="invokeURLs" />
            <param value="" name="baseURL" />
            <param value="0" name="mute" />
            <param value="full" name="uiMode" />
            <param value="-1" name="enabled" />
            <param value="0" name="enableContextMenu" />
            <param value="1" name="fullScreen" />
            <param value="" name="captioningID" />
            <param value="100" name="Volume" />
            <param value="1" name="AutoSize" />
            <embed pluginspage="" src="mms://tv.vietnamnet.vn/live" type="application/x-mplayer2"
                showstatusbar="1" autostart="0" showcontrols="1" width="670px" align="middle" height="420px"> </embed>
        </object>
    </div>
    <div style="color:#FFFFFF;">
        <br /><br />
        &nbsp; <a href="mms://tv.vietnamnet.vn/live" style="color:#FFFFFF;font-weight:bold;">Nếu bạn không xem được, mời bạn click vào đây để xem trực tiếp</a>
    </div>
    <div class="clear">
        &nbsp;</div>
</div>
