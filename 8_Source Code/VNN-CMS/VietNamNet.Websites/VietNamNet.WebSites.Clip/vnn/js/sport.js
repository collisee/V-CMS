    function initVideoPlayer(){
	    var flashvars = {
			    skin: '/lib/vnn_v1.1.swf',
			    autostart : false, 
			    shuffle : false, 
			    playlistsize: 180,
			    playlist: 'none',
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
	    swfobject.embedSWF("/lib/player.swf", 'mediaplayer', 354, 218, "9.0.115", false, flashvars, params, attributes);
    };
    
    var videoTitleTimeout = null;
    
    function setVideoTitle(title){
        $('#video-subtitle').html(title).css({opacity: 0.7}).show();
        window.clearTimeout(videoTitleTimeout);
        videoTitleTimeout = window.setTimeout(function(){
            $('#video-subtitle').fadeOut('slow');
        }, 4500);
    };
    
    function setEmbedCode(file, img){
        var width = 480;
        var height = 296;
        var code= '<embed width="' + width + '" height="' + height + '" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer" ' +
                  'type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player" allowfullscreen="true" ' +
                  'wmode="transparent" quality="high" src="http://clip.vietnamnet.vn/Lib/player.swf" '+
                  'flashvars="streamer=http://media.vietnamnet.vn/clip.php&amp;file=' + file + '&amp;image=' + img + '&amp;skin=http://clip.vietnamnet.vn/Lib/vnn_v1.0.swf'+
                  '&amp;autostart=false&amp;shuffle=false&amp;mute=false&amp;repeat=none&amp;displayclick=play&amp;playlistsize=100&amp;playlist=none" /> ';
        $('#embed-code').val(code);
    };

    function setArrow(index){
        $('#video-list .clip-item').removeClass('clip-item-a');
        $($('#video-list .clip-item').get(index)).addClass('clip-item-a');
        $('#video-list .clip-arrow').css({top: $('#video-list .clip-item-a').position().top + 15});
    }
    
    function loadMedia()
    {
        VietNamNet.Framework.JS.AjaxManager.add($.extend(video, {
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = VietNamNet.Framework.JS.JSON.decode(html);
                if (player && obj) {
                    var tmpVideoList = new VietNamNet.Framework.JS.Template({
                        id: 'videoList',
                        template: '<div class="clip-item">'+
                                  '    <a href="javascript:playVideo({index})">{title}</a>'+
                                  '</div>'
                    });
                    if (obj.length && obj.length > 0){
                        for(var i = 0; i < obj.length; i++) {
                            obj[i].index = i;
                            obj[i].streamer = player.getConfig().streamer;
                        }
                        //bind title & embed
                        setVideoTitle(obj[0].title);
                        setEmbedCode(obj[0].file, obj[0].image);
                    }else{
                        obj.index = 0;
                        obj.streamer = player.getConfig().streamer;
                        //bind title & embed
                        setVideoTitle(obj.title);
                        setEmbedCode(obj.file, obj.image);
                    };
                    
                    player.sendEvent('LOAD', obj);
                    VietNamNet.Framework.JS.TemplateManager.bind('clip-items', obj, tmpVideoList);
                    setArrow(0);
                    
                    //bind jScrollPane
                    $('#video-list').jScrollPane({
                        wheelSpeed: 26
                    });
                };
            }
        }));
    };

    function playerReady(thePlayer) {
        player = window.document[thePlayer.id];
        loadMedia();
    };
    
    function playVideo(index){
        player.sendEvent('ITEM', index);
        setVideoTitle(player.getPlaylist()[index].title);
        setEmbedCode(player.getPlaylist()[index].file, player.getPlaylist()[index].image);
        setArrow(index);
    };			

    VietNamNet.Framework.JS.Initialization.add(initVideoPlayer);