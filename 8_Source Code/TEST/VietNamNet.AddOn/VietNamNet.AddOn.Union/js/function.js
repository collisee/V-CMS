_('<script type="text/javascript" src="/common/v4/js/ad.js"></script>');
_('<script type="text/javascript" src="/common/v4/js/poll.js"></script>');
_('<link type="text/css" rel="stylesheet" href="/common/v4_thethao/css/handheld.css" media="handheld" />');
_('<script type="text/javascript" src="/common/v4/js/weather.js"></script>');

_('<link type="text/css" rel="stylesheet" href="/common/v4/yui/css/carousel.css" />');
_('<script type="text/javascript" src="/common/v4/yui/yahoo-dom-event.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/element-min.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/carousel-min.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/animation-min.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/toolseffects-min.js"></script>');

_('<script type="text/javascript" src="/common/v4/yui/paginator-min.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/event-min.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/yahoo-min.js"></script>');
_('<script type="text/javascript" src="/common/v4/yui/connection-min.js"></script>');
/*
_('<script type="text/javascript" src="/common/v4/yui/flashdetect-min.js"></script>');
*/
_('<link href="/common/v4/yui/css/menu.css" rel="stylesheet" type="text/css" />');
_('<script src="/common/v4/yui/container_core-min.js" type="text/javascript"></script>');
_('<script src="/common/v4/yui/menu-min.js" type="text/javascript"></script>');

var lang = new Object;
lang.vietnamnet = 'VietNamNet';
lang.keyword = 'Tìm kiếm';
lang.prev = 'Trang trước';
lang.next = 'Trang sau';

var config = new Object;
config.item_per_page = 10;
config.search_per_page = 10;

var stats_url = 'http://stat.vietnamnet.vn/service/statistic/statcollector.do';



function set_cookie(cookieName,cookieValue,nDays) {
	var today = new Date();
	var expire = new Date();
	if (nDays == null || nDays == 0) nDays = 1;
	expire.setTime(today.getTime() + 3600000*24*nDays);
	document.cookie = cookieName + "=" + escape(cookieValue) + ";expires=" + expire.toGMTString() + ";path=/";
}

function get_cookie( name ) {

	var start = document.cookie.indexOf( name + "=" );
	var len = start + name.length + 1;
	if ( ( !start ) && ( name != document.cookie.substring( 0, name.length ) ) ) {
		return null;
	}
	if ( start == -1 ) return null;
	var end = document.cookie.indexOf( ";", len );
	if ( end == -1 ) end = document.cookie.length;
	return unescape( document.cookie.substring( len, end ) );
}


function search_on_focus(field) {
		if(field.value=='Từ khóa'){ field.value = ''; }
}

function search_on_blur(field) {
		if(field.value.split(' ').join('') == ''){ field.value='Từ khóa';}
}

function init_search_box() {
	$keywords = $('keywords');
	$keywords.onfocus = function() {
		search_on_focus($keywords);
	}
	$keywords.onblur = function() {
		search_on_focus($keywords);
	}
}



function keyword_checkin(obj) {
	try {
		if (obj.value == lang.keyword) {
			obj.value = '';
		}
		else {
			obj.select();
		}
	}
	catch (e) {}
}

function keyword_checkout(obj) {
	try {
		if (obj.value == '') {
			obj.value = lang.keyword;
		}
	}
	catch (e) {}
}

function keyword_checklast() {
	try {
		if ((!$('keywords').value) || ($('keywords').value == lang.keyword)) {
			return false;
		}
		else {
			return true;
		}
	}
	catch (e) {}
}

function clearById(obj_id) {
	clear($(obj_id));
}

function clear(obj) {
	while (obj.firstChild) {
		obj.removeChild(obj.firstChild);
	}
}

function set_title(tit) {
	if (tit) {
		document.title = tit + ' - ' + lang.vietnamnet;
	}
	else {
		document.title = lang.vietnamnet;
	}
	
}

function add_title(tit) {
	if (!document.title) {
		document.title = tit;
	}
	else {
		document.title = tit + ' - ' + document.title;
	}
}

function deactivate(e, cname) {
	e.className = e.className.replace(/active/gi, '').replace(/  /, '');
}

function add_class(e, cname) {
	e.className += ' ' + cname;
}

function hide(e) {
	if (e) {
		e.style.display = 'none';
	}
}

function show(e) {
	if (e) {
		e.style.display = '';
	}
}

function conclude() {
	try {
		add_class($('menu-thethao'), 'active');
		get_menu_secondary('/thethao/topmenu/');
	}
	catch(e) {}

	try {
		if (parseInt($('article-feedback').innerHTML)) {
			$('feedback-form').style.display = 'block';
		}
	}
	catch (e) {}

	try {
		if ($('cate-title').innerHTML) {
			add_title($('cate-title').innerHTML);
		}

		if ($('article-title').innerHTML) {
			add_title($('article-title').innerHTML);
		}
	}
	catch (e) {}

	load_ads();
}

function init_tamdiem() {
	if (handheld) {
		return;
	}

	YAHOO.util.Event.onDOMReady(function(ev) {
		$tamdiem = new YAHOO.widget.Carousel('tamdiem', {
			animation: {speed: 1},
			numVisible: 4,
			isCircular: true,
			isVertical: true
		});

		$tamdiem.render();
		$tamdiem.show();
	});
}

function init_thegioianh() {
	if (handheld) {
		return;
	}

	YAHOO.util.Event.onDOMReady(function(ev) {
		var carousel = new YAHOO.widget.Carousel('thegioianh', {
			animation: {speed: 0.5},
			numVisible: 3,
			isCircular: true,
			isVertical: true
		});

		carousel.render();
		carousel.show();
	});
}

function init_giaitri() {
	if (handheld) {
		return;
	}

	YAHOO.util.Event.onDOMReady(function(ev) {
		var carousel = new YAHOO.widget.Carousel('giaitri', {
			animation: {speed: 0.5},
			numVisible: 1,
			isCircular: true
		});
		carousel.CONFIG.MAX_PAGER_BUTTONS = 10;
		carousel.render();
		carousel.show();
	});
}

function init_thegioianh() {
	if (handheld) {
		return;
	}

	YAHOO.util.Event.onDOMReady(function(ev) {
		var carousel = new YAHOO.widget.Carousel('thegioianh', {
			animation: {speed: 0.5},
			numVisible: 3,
			isCircular: true
		});
		carousel.render();
		carousel.show();
	});
}

function init_theodongsukien() {
	if (handheld) {
		return;
	}

	YAHOO.util.Event.onDOMReady(function(ev) {
		var carousel = new YAHOO.widget.Carousel('theodongsukien', {
			animation: {speed: 0.5},
			numVisible: 5,
			isCircular: true
		});

		carousel.render();
		carousel.show();
	});
}

function init_newsticker() {
	if (handheld) {
		return;
	}

	YAHOO.util.Event.onDOMReady(function(ev) {
		var carousel = new YAHOO.widget.Carousel('news-ticker', {
			animation: {speed: 0.5},
			numVisible: 1,
			isCircular: true,
			isVertical: true,
			autoPlayInterval: 3000
		});

		carousel.render();
		carousel.show();
		carousel.startAutoPlay();

		$('news-ticker').onmouseover = function () {
			carousel.stopAutoPlay();
		}

		$('news-ticker').onmouseout = function () {
			carousel.startAutoPlay();
		}
	});
}

function init_hover(e) {
	$items = e.getElementsByTagName('td');
	for (var i = 0; i < $items.length; i++) {
		$item = $items[i];
		$item.onmouseout = function() {
			this.className = this.className.replace(/hover/gi, '').replace(/  /, '');
			add_class(this, 'active');
		}

		$item.onmouseover = function() {
			if (this.className.indexOf('hover') > -1) {
				return;
			}

			var $links = this.parentNode.parentNode.getElementsByTagName('a')[0];
			$links.setAttribute('title', this.getElementsByTagName('a')[0].getAttribute('title'));
			$links.setAttribute('href', this.getElementsByTagName('a')[0].getAttribute('href'));
			
			var $image = this.parentNode.parentNode.getElementsByTagName('img')[0];
			$image.setAttribute('src', this.getElementsByTagName('img')[0].src);
			$image.setAttribute('alt', this.getElementsByTagName('a')[0].getAttribute('title'));

			new YAHOO.widget.Effects.Appear($image);

			var $items = this.parentNode.parentNode.getElementsByTagName('td');

			for (var i = 0; i < $items.length; i++) {
				$items[i].className = $items[i].className.replace(/active/gi, '').replace(/  /, '');
			}
			add_class(this, 'hover');
		}
	}
}

function init_hover_blocks(eid) {
	$blocks = $(eid).getElementsByTagName('div');
	for (var i = 0; i < $blocks.length; i++) {
		if ($blocks[i].className.indexOf('cate2') > -1) {
			init_hover($blocks[i]);
		}
	}
}

function init_hover_chuyentrang() {
	init_hover_blocks('chuyentrang');
}

function init_hover_tuanvietnam() {
	init_hover($('tuanvietnam'));
}

function init_hover_worldcup() {
	init_hover($('worldcup'));
}

function init_hover_chandungphongvan() {
	init_hover($('chandungphongvan'));
}

function init_accordion(eid) {
	if (handheld) {
		return;
	}
	$headers = $(eid).getElementsByTagName('h3');
	var h = 0;
	for (var i = 0; i < $headers.length; i++) {
		$header = $headers[i];
		$content = $header.parentNode.getElementsByTagName('span')[0];

		var str_h = $content.offsetHeight;
		if (h < str_h) {
			h = str_h;
		}

	 	if (get_cookie("vnn_accordion") != null)
	 	{
			if (i != get_cookie("vnn_accordion") ) {
				$content.style.display = 'none';
				$header.className = $headers[i].className.replace(/active/gi, '').replace(/  /, '');
				collapse($content);
			}
			else
			{
				$header.className += ' active';
				expand($content);
			}

		 }
	 	else
	 	{
			if ($header.className.indexOf('active') == -1) {
			$content.style.display = 'none';
			}
	 	}




		$content.style.height = h + 'px';

		$header.onmouseover = function () {
			if (this.className.indexOf('active') > -1) {
				return;
			}

			$headers = $(eid).getElementsByTagName('h3');
			for (var i = 0; i < $headers.length; i++) {
				$header = $headers[i];
				$content = $header.parentNode.getElementsByTagName('span')[0];

				if ($header.className.indexOf('active') > -1) {
					$header.className = $headers[i].className.replace(/active/gi, '').replace(/  /, '');
					collapse($content);
				}

				if ($headers[i] == this) {
					$header.className += ' active';
					set_cookie("vnn_accordion",i,365)
					expand($content);
				}
			}
		};
	}
}


function collapse(e) {
	e.style.display = 'none';
	// new YAHOO.widget.Effects.BlindUp(e);
}

function expand(e) {
	// new YAHOO.widget.Effects.BlindUp(e, {bind: 'bottom'});
	e.style.display = '';
}

function opentab(e, _title, _window, w, h) {
	if (!e.href) {
		return false;
	}
	_window += ',width=' + w;
	_window += ',height=' + h;
	_window += ',left=' + (screen.width-w)/2;
	_window += ',scrollbars=1,top=' + (screen.height-h)/2;
	var win = window.open(e.href, _title, _window);
	return false;
}

function slideshow(e) {
	var slide = '<embed flashvars="width=480&amp;height=270&amp;file=FILE&amp;rotatetime=3&amp;textsize=8&amp;shuffle=false&amp;transition=slowfade" wmode="opaque" src="/common/v4/player/imagerotator.swf" type="application/x-shockwave-flash" />';
	slide = slide.replace(/FILE/, e.getAttribute('href'));

	var slot = $('news-top').getElementsByTagName('div')[0].getElementsByTagName('div')[0];

	clear(slot);
	slot.innerHTML = slide + e.parentNode.parentNode.innerHTML;
	try {
		slot.removeChild(slot.getElementsByTagName('div')[1]);
	}
	catch (e) {
		return false;
	}

	new YAHOO.widget.Effects.Appear(slot);
	return false;
}

function play(e) {
	var slide = '<embed flashvars="width=480&amp;height=270&amp;streamer=http://media.vietnamnet.vn/vnn.php&amp;autostart=true&amp;file=FILE&amp;image=IMAGE" allowfullscreen="true" quality="high" wmode="opaque" width = "480" height = "270" type="application/x-shockwave-flash" src="/common/v4/player/player.swf" />'

	slide = slide
		.replace(/FILE/, e.getAttribute('href').replace(new RegExp('http://(.*)/truyenhinh/', 'gi'), ''))
		.replace(/IMAGE/, e.parentNode.parentNode.getElementsByTagName('img')[0].getAttribute('src'));
	var slot = $('news-top').getElementsByTagName('div')[0].getElementsByTagName('div')[0];

	clear(slot);
	slot.innerHTML = slide + e.parentNode.parentNode.innerHTML;
	slot.removeChild(slot.getElementsByTagName('div')[1]);
	new YAHOO.widget.Effects.Appear(slot);

	return false;
}

function playtt(e) {

	var slide = '<embed flashvars="width=480&amp;height=270&amp;streamer=http://media.vietnamnet.vn/vnn.php&amp;autostart=true&amp;file=FILE&amp; allowfullscreen="true" quality="high" wmode="opaque" width = "480" height = "270" type="application/x-shockwave-flash" src="/common/v4/player/player.swf" />'
	
	slide = slide
		.replace(/FILE/, e.getAttribute('href').replace(new RegExp('http://(.*)/mediavideo/', 'gi'), ''))		
	var slot = $('news-top-thethao').getElementsByTagName('div')[0].getElementsByTagName('div')[0];


	clear(slot);
	slot.innerHTML = slide + e.parentNode.parentNode.innerHTML;
	slot.removeChild(slot.getElementsByTagName('div')[1]);
	new YAHOO.widget.Effects.Appear(slot);

	return false;
}

function get_date_full() {
	$('date-full').innerHTML = $('date-full-hidden').innerHTML;
}

function get_list_cate(ipp) {
	var item_per_page = (ipp == undefined) ? config.item_per_page : ipp;

	var url = "index.txt";
	var obj = document.createElement('div');
	var handleSuccess = function(o) {
		if (o.responseText !== undefined) {
			obj.innerHTML = o.responseText;
			
			var items= obj.getElementsByTagName('span');
			var data = new Array();
			for (var i = 0; i < items.length; i++) {
				data[i] = items[i].innerHTML;
			}
			if (handheld){
				num_feedback = data.length;
			}

			YAHOO.util.Event.onDOMReady(function() {

				var list = YAHOO.namespace('vsolutions');
				list.content = YAHOO.util.Dom.get('list-cate-next');

				list.handlePagination = function (state) {
					var startIndex = state.recordOffset;

					recs = data.slice(startIndex, startIndex + state.rowsPerPage);
					list.content.start = startIndex + 1;
					list.content.innerHTML = recs.join('');
					list.paginator.setState(state);
				};

				list.paginator = new YAHOO.widget.Paginator({
					rowsPerPage: item_per_page,
					totalRecords: data.length,
					containers: ['paging'],
					template: '{NextPageLink}',
					nextPageLinkLabel: 'xem thêm tin khác',
					nextPageLinkClass : 'yui-pg-next more'
				});

				list.paginator.subscribe('changeRequest', list.handlePagination);
				list.paginator.render();

				list.handlePagination(list.paginator.getState());

				// Chuyển trang kiểu VietNamNet
				$('paging').getElementsByTagName('a')[0].onclick = function () {
					window.location = '#';

					if ($('body').className.indexOf('tv-home') > -1 || $('body').className.indexOf('image-home') > -1) {
					}
					else if ($('news-top')) {
						hide($('news-top'));

						if ($('ad_center_1')) {
							hide($('ad_center_1').parentNode);
						}
					}
					else {
						try {
							$divs = $('paging').parentNode.getElementsByTagName('div');
							for (var i = 0; i < $divs.length; i++) {
								if (($divs[i].className.indexOf('first') > -1) || ($divs[i].className.indexOf('second') > -1)) {
									hide($divs[i]);
								}
							}
						}
						catch (e) {}
					}
				}

			});

		}
	};

	var handleFailure = function(o) {
		if (o.responseText !== undefined) {return null;}
	};

	var callback = {
		success: handleSuccess,
		failure: handleFailure
	};
	var request = YAHOO.util.Connect.asyncRequest('GET', url, callback);
}

function get_menu_secondary(url) {
	var $menu = document.createElement('div');

	var handleSuccess = function(o) {
		if (o.responseText !== undefined) {
			$menu.innerHTML = o.responseText;
			$('menu').appendChild($menu);

			init_menu_secondary();

			var topmenu = new YAHOO.widget.MenuBar('menu-secondary', {
				position: 'static',
				autosubmenudisplay: true,
				hidedelay: 750,
				lazyload: true,
				effect: {
					effect: YAHOO.widget.ContainerEffect.FADE,
					duration: 0.10
				}
			});

			topmenu.render();
			new YAHOO.widget.Effects.BlindDown($menu, {
				duration: 0.6
			});

		}
	}

	var handleFailure = function(o) {
		if (o.responseText !== undefined) {return null;}
	};

	var callback = {
		success: handleSuccess,
		failure: handleFailure
	};
	var request = YAHOO.util.Connect.asyncRequest('GET', url, callback);
}

function init_menu_secondary() {
	try {
		$menu_child = $('menu-secondary-child');

		$childs = $menu_child.getElementsByTagName('li');
		$childs_length = $childs.length;

		for (var i = 0; i < $childs_length; i++) {
			$child = $childs[0];

			$parent = $('ms' + $child.className);
			if ($parent.getElementsByTagName('ul').length <= 0) {
				var div1 = document.createElement('div');
				div1.className = 'lv2';

				var div2 = document.createElement('div');
				div2.className = 'bd';

				var ul = document.createElement('ul');

				div2.appendChild(ul);
				div1.appendChild(div2);
				$parent.appendChild(div1);
			}

			$parent.getElementsByTagName('ul')[0].appendChild($child);
		}

		$menu_child.parentNode.removeChild($menu_child);
	}
	catch (e) {}
}

function make_home_page(obj) {
	var url = 'http://vietnamnet.vn';
	if (ie) {
		obj.style.behavior = 'url(#default#homepage)';
		obj.setHomePage(url);
	}
	else if (firefox) { // Mozilla Firefox Bookmark
		window.sidebar.addPanel('VietNamNet', url, '');
	}
	return false;
}

function init_tab(eid) {
	if (handheld) {
		return;
	}
	$headers = $(eid).getElementsByTagName('h3');
	$contents = $(eid).getElementsByTagName('span');
	var h = 0;
	var  is_cookie = false;
	if (get_cookie('vnn_tab') != null && get_cookie('vnn_tab') != '')
		is_cookie = true;

	for (var i = 0; i < $headers.length; i++) {
		$header = $headers[i];
		$content = $contents[i];
		var str_h = 0;
		$con = $content.getElementsByTagName('div');
		for(var j = 0; j < $con.length; j++) {
			str_h += $con[j].offsetHeight;
		}
		str_h += 20;
		if (h < str_h) {
			h = str_h;
		}
		
		if (is_cookie) {
			if ($headers.length > 1)
				$header.className = '';
			if (get_cookie('vnn_tab') == i) {
				$header.className = 'active';
			}
		}

		$content.style.height = h + 'px';
		if ($header.className.indexOf('active') == -1) {
			$content.style.display = 'none';
		}
		$header.onmouseover = function () {
			if (this.className.indexOf('active') > -1) {
				return;
			}

			$headers = $(eid).getElementsByTagName('h3');
			for (var i = 0; i < $headers.length; i++) {
				$header = $headers[i];
				$content = $header.parentNode.parentNode.getElementsByTagName('span')[i];

				if ($header.className.indexOf('active') > -1) {
					$header.className = $headers[i].className.replace(/active/gi, '').replace(/  /, '');
					collapse($content);
				}

				if ($headers[i] == this) {
					$header.className = 'active';
					set_cookie('vnn_tab', i, 365)
					expand($content);
				}
			}
		};
	}
}



var $j = jQuery.noConflict();
function slideShow() {
	if ($j('#gallery a').length < 2) {
		return;
	};

	//Set the opacity of all images to 0
	$j('#gallery a').css({opacity: 0.0});
	
	//Get the first image and display it (set it to full opacity)
	$j('#gallery a:first').css({opacity: 1.0});
	
	//Call the gallery function to run the slideshow, 6000 = change to next image after 6 seconds
	setInterval('gallery()', 6000);
}

function gallery() {
	//if no IMGs have the show class, grab the first image
	var current = ($j('#gallery a.show')?  $j('#gallery a.show') : $j('#gallery a:first'));

	//Get next image, if it reached the end of the slideshow, rotate it back to the first image
	var next = ((current.next().length) ? current.next() : $j('#gallery a:first'));	

	//Set the fade in effect for the next image, show class has higher z-index
	next.css({opacity: 0.0})
	.addClass('show')
	.animate({opacity: 1.0}, 1000);

	//Hide the current image
	current.animate({opacity: 0.0}, 1000)
	.removeClass('show');
}