<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopVideo.ascx.cs"
    Inherits="VietNamNet.Websites.Petro.UserControls.Homepage.PanelTopVideo" %>
<div class="most-video">
    <a href="/vn/camera-dau-khi/index.html">
    <img alt="" src="/data/title_clip.jpg" width="190" height="25" /></a>
    <div style="text-align: center;">
        <div id="videoPlayer">
            Bạn cần cài đặt Flash Player để xem Video!!!
        </div>
    </div>
    <div class="video">
        <asp:HiddenField ID="hidCategoryAlias" runat="server" Value="clip-noi-bat" />
        <asp:Repeater ID="rptCate" runat="server">
            <ItemTemplate>
                <div class="video-item">
                    <a href="/vn/camera-dau-khi/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <%#DataBinder.Eval(Container.DataItem, "Name") %>
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
                playlist: 'none'
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
        swfobject.embedSWF("/Lib/player.swf", 'videoPlayer', 330, 203, "9.0.115", false, flashvars, params, attributes);
    }
    
    function loadMedia()
    {
        AP.Core.JS.AjaxManager.add({
            url: '/ajax/getTopMedia/get.html',
            data: {CateAlias: 'clip-noi-bat', MediaType: 'Video'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = AP.Core.JS.JSON.decode(html);
                if (player) {player.sendEvent('LOAD', obj)};
            }
        });
    }
    
    function playerReady(thePlayer) {
        player = window.document[thePlayer.id];
        loadMedia();
    }
    AP.Core.JS.Initialization.add(initVideoPlayer);
</script>

