<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelVideoClip.ascx.cs"
  Inherits="VietNamNet.Websites.English.UserControls.PanelVideoClip" %>
<div class="el-clip">
  <div class="bg_title">
    Video clip
  </div>
  <div class="clip-block pdt5">
    <div>
        <div id="video-player">
        </div>
    </div>
  </div>
  <div class="clip-list">
    <asp:Repeater ID="rptLatestNews" runat="server">
      <ItemTemplate>
        <div class="clip-item">
          <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>

<script type="text/javascript">
    function initVideoPlayer(){
        var flashvars = {
                autostart : false, 
                shuffle : false, 
                playlistsize: 130,
                playlist: 'none',
                skin: '/Lib/vnn_v1.1.swf',
			    streamer: 'http://media.vietnamnet.vn/clip.php'
        };
        var params = {
                allowfullscreen:'true', 
                wmode:'transparent', 
                allowscriptaccess:'always'
        };
        var attributes = {
                id:'videoPlayer',
                name:'videoPlayer'
        };
        swfobject.embedSWF("/Lib/player.swf", 'video-player', 300, 188, "9.0.115", false, flashvars, params, attributes);
    }
    
    function loadMedia()
    {
        VietNamNet.Framework.JS.AjaxManager.add({
            url: '/ajax/getTopMedia/get.html',
            data: {CateAlias: 'video-clip', MediaType: 'Video'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = VietNamNet.Framework.JS.JSON.decode(html);
                if (player) {
                    if (obj.length && obj.length > 0){
                        for(var i = 0; i < obj.length; i++) {
                            obj[i].index = i;
                            obj[i].streamer = player.getConfig().streamer;
                        }
                    }else{
                        obj.index = 0;
                        obj.streamer = player.getConfig().streamer;
                    };
                    player.sendEvent('LOAD', obj);
                };
            }
        });
    }
    
    function playerReady(thePlayer) {
        player = window.document[thePlayer.id];
        loadMedia();
    }
    VietNamNet.Framework.JS.Initialization.add(initVideoPlayer);
</script>

