<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VideoPlayer.ascx.cs"
    Inherits="VietNamNet.Websites.Petro.UserControls.News.VideoPlayer" %>
<div style="width:330px;margin:10px auto;">
    <div id="videoPlayer">
        Bạn cần cài đặt Flash Player để xem Video!!!
    </div>
    <div id="videoList" style="padding-top:10px;">
    </div>
</div>

<script type="text/javascript">
    function initVideoPlayer(){
        var flashvars = {
                autostart : false, 
                shuffle : false, 
                playlistsize: 130,
                playlist: 'none'
        };
        var params = {
                allowfullscreen:"true", 
                wmode:"transparent", 
                allowscriptaccess:"always"
        };
        var attributes = {
                id:'videoPlayer',
                name:'videoPlayer'
        };
        swfobject.embedSWF("/Lib/player.swf", 'videoPlayer', 330, 203, "9.0.115", false, flashvars, params, attributes);
    }
        
    function loadMedia()
    {
        AP.Core.JS.AjaxManager.add({
            url: '/ajax/getMedia/get.html',
            data: {DocId: <%=ArticleId %>, MediaType: 'Video'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = AP.Core.JS.JSON.decode(html);
                if (player && obj) {
                    player.sendEvent('LOAD', obj)
                    var tmpVideoList = new AP.Core.JS.Template({
                        id: 'videoList',
                        template: '<div class="video-item"><a href="javascript:player.sendEvent(\'PLAY\', {index});">{description}</a></div>'
                    });
                    if (obj.length && obj.length > 0){
                        for(var i = 0; i < obj.length; i++) obj[i].index = i;
                    }else{
                        obj.index = 0;
                    }
                    AP.Core.JS.TemplateManager.bind('videoList', obj, tmpVideoList);
                };
            }
        });
    }
    
    function playerReady(thePlayer) {
        player = window.document[thePlayer.id];
        loadMedia();
    }
    AP.Core.JS.Initialization.add(initVideoPlayer);
</script>

