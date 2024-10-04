<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelLeft.ascx.cs" Inherits="VietNamNet.AddOn.Union.UserControls.PanelLeft" %>
<%@ Register Src="PanelPersonInfo.ascx" TagName="PanelPersonInfo" TagPrefix="uc" %>
<%@ Register Src="PanelBirthday.ascx" TagName="PanelBirthday" TagPrefix="uc" %>
<%@ Register Src="PanelAlbumTop.ascx" TagName="PanelAlbumTop" TagPrefix="uc" %>
<%@ Register Src="PanelArticleTop.ascx" TagName="PanelArticleTop" TagPrefix="uc" %>
<%@ Register Src="PanelTopVideo.ascx" TagName="PanelTopVideo" TagPrefix="uc" %>
<%@ Register Src="PanelTopAudio.ascx" TagName="PanelTopAudio" TagPrefix="uc" %>

<uc:PanelPersonInfo ID="PanelPersonInfo1" runat="server" />
<uc:PanelTopVideo ID="PanelTopVideo1" runat="server" />
<uc:PanelTopAudio ID="PanelTopAudio1" runat="server" />
<br />
<br />
<embed width="210" height="400" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
wmode="transparent" quality="high" src="/data/29UNION.swf" />

<%--<uc:PanelAlbumTop ID="PanelAlbumTop1" runat="server" CategoryAlias="cuoi" />--%>
<%--<uc:PanelBirthday ID="PanelBirthday1" runat="server"></uc:PanelBirthday>--%>
<%--<uc:PanelArticleTop ID="PanelArticleTop1" runat="server" CategoryAlias="cuoi"></uc:PanelArticleTop>--%>

<script type="text/javascript">
    
    function playerReady(thePlayer) {
        if (thePlayer.id == 'topVideoPlayer'){
            topPlayer = window.document[thePlayer.id];
            if (loadTopMedia) loadTopMedia();
        }else if (thePlayer.id == 'topAudioPlayer'){
            audioPlayer = window.document[thePlayer.id];
            if (loadTopAudio) loadTopAudio();
        }else if (thePlayer.id == 'videoPlayer'){
            player = window.document[thePlayer.id];
            if (loadMedia) loadMedia();
        }
    }

</script>
