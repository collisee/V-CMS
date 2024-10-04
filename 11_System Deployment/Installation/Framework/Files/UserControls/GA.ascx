<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GA.ascx.cs" Inherits="VietNamNet.Framework.UserControls.GA" %>
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-6610653-26']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>

<script type="text/javascript">
//jquery cookie
jQuery = $telerik.$;
$telerik.$.cookie=function(a,b,c){if(typeof b!='undefined'){c=c||{};if(b===null){b='';c=$.extend({},c);c.expires=-1}var d='';if(c.expires&&(typeof c.expires=='number'||c.expires.toUTCString)){var e;if(typeof c.expires=='number'){e=new Date();e.setTime(e.getTime()+(c.expires*24*60*60*1000))}else{e=c.expires}d='; expires='+e.toUTCString()}var f=c.path?'; path='+(c.path):'';var g=c.domain?'; domain='+(c.domain):'';var h=c.secure?'; secure':'';document.cookie=[a,'=',encodeURIComponent(b),d,f,g,h].join('')}else{var j=null;if(document.cookie&&document.cookie!=''){var k=document.cookie.split(';');for(var i=0;i<k.length;i++){var l=jQuery.trim(k[i]);if(l.substring(0,a.length+1)==(a+'=')){j=decodeURIComponent(l.substring(a.length+1));break}}}return j}};
$telerik.$(function(){
    var help = $telerik.$.cookie('help-desk');
    if (help == 'true') $telerik.$('#help-desk .module-content').addClass('none');
});
function helpdesk(){
    $telerik.$('#help-desk .module-content').toggleClass('none');
    $telerik.$.cookie('help-desk', $telerik.$('#help-desk .module-content').hasClass('none'), { expires: 7 });
}
</script>

<div id="help-desk" style="position:fixed;right:10px;bottom:10px;width:220px;">
    <div class="module">
        <div class="module-border module-top">
            <div class="b1 m-border bgcolor">
            </div>
            <div class="b2 m-border bgcolor">
            </div>
            <div class="b3 m-border bgcolor">
            </div>
            <div class="b4 m-border bgcolor">
            </div>
        </div>
        <div class="module-header m-border bgcolor">
            <a href="javascript:void(0)" onclick="helpdesk()">Hỗ trợ trực tuyến</a>
        </div>
        <div class="module-content m-border bgcolor">
    &nbsp; &nbsp; Đào Tuấn Anh:<br />
    &nbsp; &nbsp; &nbsp; &nbsp; Y!M: <a href="ymsgr:sendim?shevaismylove">
	        <img border="0" src="http://opi.yahoo.com/online?u=shevaismylove&amp;m=g&amp;t=2" alt="">
	    </a><br />
    &nbsp; &nbsp; &nbsp; &nbsp; Mobile: 091 260 7890<br />
    &nbsp; &nbsp; Hoàng Thị Huyền:<br />
    &nbsp; &nbsp; &nbsp; &nbsp; Y!M: <a href="ymsgr:sendim?hoanghuyen81">
	        <img border="0" src="http://opi.yahoo.com/online?u=hoanghuyen81&amp;m=g&amp;t=2" alt="">
	    </a><br />
    &nbsp; &nbsp; &nbsp; &nbsp; Mobile: 090 344 7161<br />
    &nbsp; &nbsp; Cản Mạnh Tuấn:<br />
    &nbsp; &nbsp; &nbsp; &nbsp; Y!M: <a href="ymsgr:sendim?canmanhtuan">
	        <img border="0" src="http://opi.yahoo.com/online?u=canmanhtuan&amp;m=g&amp;t=2" alt="">
	    </a><br />
    &nbsp; &nbsp; &nbsp; &nbsp; Mobile: 098 347 9799<br />
    &nbsp; &nbsp; Lục Văn Tiến:<br />
    &nbsp; &nbsp; &nbsp; &nbsp; Y!M: <a href="ymsgr:sendim?dev.lucvantien">
	        <img border="0" src="http://opi.yahoo.com/online?u=dev.lucvantien&amp;m=g&amp;t=2" alt="">
	    </a><br />
    &nbsp; &nbsp; &nbsp; &nbsp; Mobile: 090 495 4495<br />
    <br />
    &nbsp; &nbsp; <a href="/Documents/huongdansudungcms.doc">Hướng dẫn sử dụng CMS</a>
        </div>
        <div class="module-border module-bottom">
            <div class="b4 m-border bgcolor">
            </div>
            <div class="b3 m-border bgcolor">
            </div>
            <div class="b2 m-border bgcolor">
            </div>
            <div class="b1 m-border bgcolor">
            </div>
        </div>
    </div>
</div>