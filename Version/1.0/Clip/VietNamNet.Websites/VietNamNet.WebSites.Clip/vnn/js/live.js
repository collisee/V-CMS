var player = null;
function initVideoPlayer(){
    var flashvars = {
        file: '/vnn/live.asx',
	    skin: '/lib/vnn_v1.1.swf',
	    autostart : false, 
	    shuffle : false, 
	    playlistsize: 180,
	    playlist: 'none'//,
	    //streamer: 'mms:\\tv.vietnamnet.vn\live'
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
    swfobject.embedSWF("/lib/player.swf", 'mediaplayer', 354, 158, "9.0.115", false, flashvars, params, attributes);
};

function playerReady(thePlayer) {
    player = window.document[thePlayer.id];
};

function playVideo(){
    if (player) player.sendEvent('PLAY');
};			

VietNamNet.Framework.JS.Initialization.add(initVideoPlayer);