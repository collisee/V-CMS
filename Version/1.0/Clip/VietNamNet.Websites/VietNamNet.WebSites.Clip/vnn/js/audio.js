    function initAudioPlayer(){
	    var flashvars = {
			    skin: '/lib/vnn_v1.1.swf',
			    autostart : false, 
			    shuffle : false, 
			    playlistsize: 180,
			    playlist: 'none'
	    };
	    var params = {
			    //type: 'sound',
			    allowfullscreen:'true', 
			    wmode:'transparent', 
			    allowscriptaccess:'always'
	    };
	    var attributes = {
			    id:'audioPlayer',
			    name:'audioPlayer'
	    };
	    swfobject.embedSWF("/lib/player.swf", 'mediaplayer', 354, 158, "9.0.115", false, flashvars, params, attributes);
    };
    
    var audioTitleTimeout = null;
    
    function setAudioTitle(title){
        $('#audio-subtitle').html(title).css({opacity: 0.7}).show();
        window.clearTimeout(audioTitleTimeout);
        audioTitleTimeout = window.setTimeout(function(){
            $('#audio-subtitle').fadeOut('slow');
        }, 4500);
    };
    
    function setEmbedCode(file, img){
        var width = 450;
        var height = 32;
        var code= '<embed width="' + width + '" height="' + height + '" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer" ' +
                  'type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player" allowfullscreen="true" ' +
                  'wmode="transparent" quality="high" src="http://clip.vietnamnet.vn/Lib/player.swf" '+
                  'flashvars="file=http://media.vietnamnet.vn/vnnclip' + file + '&amp;image=' + img + '&amp;skin=http://clip.vietnamnet.vn/Lib/vnn_v1.0.swf'+
                  '&amp;autostart=false&amp;shuffle=false&amp;mute=false&amp;repeat=none&amp;displayclick=play&amp;playlistsize=100&amp;playlist=none" /> ';
        $('#embed-code').val(code);
    };

    function setArrow(index){
        $('#audio-list .clip-item').removeClass('clip-item-a');
        $($('#audio-list .clip-item').get(index)).addClass('clip-item-a');
        $('#audio-list .clip-arrow').css({top: $('#audio-list .clip-item-a').position().top + 15});
    }
    
    function loadMedia()
    {
        VietNamNet.Framework.JS.AjaxManager.add($.extend(audio, {
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = VietNamNet.Framework.JS.JSON.decode(html);
                if (player && obj) {
                    var tmpAudioList = new VietNamNet.Framework.JS.Template({
                        id: 'audioList',
                        template: '<div class="clip-item">'+
                                  '    <a href="javascript:playAudio({index})">{title}</a>'+
                                  '</div>'
                    });
                    if (obj.length && obj.length > 0){
                        for(var i = 0; i < obj.length; i++) {
                            obj[i].index = i;
                            //obj[i].streamer = player.getConfig().streamer;
                            obj[i].file = 'http://media.vietnamnet.vn/vnnclip' + obj[i].file;
                        }
                        //bind title & embed
                        setAudioTitle(obj[0].title);
                        setEmbedCode(obj[0].file, obj[0].image);
                    }else{
                        obj.index = 0;
                        //obj.streamer = player.getConfig().streamer;
                        obj.file = 'http://media.vietnamnet.vn/vnnclip' + obj.file;
                        //bind title & embed
                        setAudioTitle(obj.title);
                        setEmbedCode(obj.file, obj.image);
                    };
                    
                    player.sendEvent('LOAD', obj);
                    VietNamNet.Framework.JS.TemplateManager.bind('clip-items', obj, tmpAudioList);
                    setArrow(0);
                    
                    //bind jScrollPane
                    $('#audio-list').jScrollPane({
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
    
    function playAudio(index){
        player.sendEvent('ITEM', index);
        setAudioTitle(player.getPlaylist()[index].title);
        setEmbedCode(player.getPlaylist()[index].file, player.getPlaylist()[index].image);
        setArrow(index);
    };			

    VietNamNet.Framework.JS.Initialization.add(initAudioPlayer);