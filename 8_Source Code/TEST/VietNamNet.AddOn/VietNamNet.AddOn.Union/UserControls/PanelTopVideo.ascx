<%@ Import Namespace="VietNamNet.AddOn.Union.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopVideo.ascx.cs"
    Inherits="VietNamNet.AddOn.Union.UserControls.PanelTopVideo" %>
<div class="row">
    <div class="bg-title1">
        <div class="bg-title2">
            <div class="bg-title3">
                <a href="/vn/album-top-hit/index.html" class="title">Album Top Hit</a>
            </div>
        </div>
    </div>
    <div class="block-body">
        <br />
        <div style="text-align: center;">
            <div id="topVideoPlayer">
                Bạn cần cài đặt Flash Player để xem Video!!!
            </div>
        </div>
        <div class="list">
            <asp:HiddenField ID="hidCategoryAlias" runat="server" Value="cuoc-thi" />
            <asp:Repeater ID="rptMore" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <a href="/vn/cuoc-thi/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#UnionUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                            <%#DataBinder.Eval(Container.DataItem, "Name") %>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
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
    function initTopVideoPlayer(){
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
                id:'topVideoPlayer',
                name:'topVideoPlayer'
        };
        swfobject.embedSWF("/Lib/player.swf", 'topVideoPlayer', 190, 145, "9.0.115", false, flashvars, params, attributes);
    }
    
    function loadTopMedia()
    {
        AP.Core.JS.AjaxManager.add({
            url: '/ajax/getTopMedia/get.html',
            data: {CateAlias: 'album-top-hit', MediaType: 'Video'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = AP.Core.JS.JSON.decode(html);
                if (topPlayer && obj) {topPlayer.sendEvent('LOAD', obj)};
            }
        });
    }
    
    AP.Core.JS.Initialization.add(initTopVideoPlayer);
</script>

