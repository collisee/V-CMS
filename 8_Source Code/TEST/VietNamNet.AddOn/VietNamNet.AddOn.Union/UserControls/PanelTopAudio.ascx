<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelTopAudio.ascx.cs" Inherits="VietNamNet.AddOn.Union.UserControls.PanelTopAudio" %>
<div class="row">
    <div class="bg-title1">
        <div class="bg-title2">
            <div class="bg-title3">
                <a href="/vn/bai-hit-trong-tuan/index.html" class="title">Audio hit trong tuần</a>
            </div>
        </div>
    </div>
    <div class="block-body">
        <br />
        <div style="text-align: center;">
            <div id="topAudioPlayer">
                Bạn cần cài đặt Flash Player để xem Audio!!!
            </div>
        </div>
        <div class="list" id="audioList">
        </div>
    </div>
    <div class="bg-bgtitle1">
        <div class="bg-bgtitle2">
            <div class="bg-bgtitle3">
                &nbsp;
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function initTopAudioPlayer(){
        var flashvars = {
			    skin: '/Lib/vnn.zip',
                autostart : false, 
                shuffle : false, 
                playlistsize: 130,
                playlist: 'none'
        };
        var params = {
                allowfullscreen:'true', 
                wmode:'transparent', 
                allowscriptaccess:'always'
        };
        var attributes = {
                id:'topAudioPlayer',
                name:'topAudioPlayer'
        };
        swfobject.embedSWF("/Lib/player.swf", 'topAudioPlayer', 190, 32, "9.0.115", false, flashvars, params, attributes);
    }
    
    function loadTopAudio()
    {
        AP.Core.JS.AjaxManager.add({
            url: '/ajax/getTopMedia/get.html',
            data: {CateAlias: 'bai-hit-trong-tuan', MediaType: 'Audio'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = AP.Core.JS.JSON.decode(html);
                if (obj && audioPlayer) {
                    audioPlayer.sendEvent('LOAD', obj)
                    var tmpAudioList = new AP.Core.JS.Template({
                        id: 'audioList',
                        template: '<div class="item"><a href="javascript:audioPlayer.sendEvent(\'PLAY\', {index});">{description}</a></div>'
                    });
                    if (obj.length && obj.length > 0){
                        for(var i = 0; i < obj.length; i++) obj[i].index = i;
                    }else{
                        obj.index = 0;
                        if (!obj.file) return;
                    }
                    AP.Core.JS.TemplateManager.bind('audioList', obj, tmpAudioList);
                };
            }
        });
    }
    
    AP.Core.JS.Initialization.add(initTopAudioPlayer);
</script>

