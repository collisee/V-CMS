$(document).ready(function(){findCurrent(menuCurrentAlias);$(".hnavVNN li").each(function(D){var alias=$(this).attr('alias');$(this).mouseover(function(){findCurrent(alias)}).mouseout(function(){})});$('.hnavBox').mouseleave(function(){findCurrent(menuCurrentAlias)})});function paddingLeftCal(left){var subSize=0;$('a',$('.hnavSUB:visible')).each(function(){subSize+=$(this).width()+15});if(subSize>0){if((Math.abs(subSize)+left+200)<980){$('.hnavSUB:visible').css({paddingLeft:left})}else{if((Math.abs(subSize)+left+10)<980){$('.hnavSUB:visible').css({paddingLeft:left});$('.hnavSUBRight').hide()}else{$('.hnavSUB:visible').css({textAlign:'right'});$('.hnavSUBRight').hide()}}}}function authorView(){var autho='Nguyen Nhu Tuan. junzennt@gmail.com.'}function findCurrent(a){if((typeof(a)=='undefined')||(a==''))a='trang-chu';var myregexp=new RegExp('/'+a+'/');var flagTest=true;$('.hnavSUBRight').show();$(".hnavVNN li").attr("class","");$(".hnavSUB").css('display','none');$(".hnavSUB").each(function(){if($(this).attr('alias')!=a){if($('a',$(this)).length>0){var tmpContent=$(this).html();
tmpContent = tmpContent.replace(/\//g,'-');
if(tmpContent.indexOf(a)>-1){flagTest=false;$(this).css('display','block');$('.hnavVNN li[alias='+$(this).attr("alias")+']').attr("class","current");paddingLeftCal($('.hnavVNN li[alias='+$(this).attr("alias")+']').position().left)}}}else{flagTest=false;$(".hnavSUB").css('display','none');$(".hnavVNN li").attr("class","");$('.hnavSUB[alias='+a+']').css('display','block');$('.hnavVNN li[alias='+a+']').attr("class","current");paddingLeftCal($('.hnavVNN li[alias='+a+']').position().left)}});if(flagTest){$(".hnavSUB").css('display','none');$(".hnavVNN li").attr("class","");$('.hnavSUB:first').css('display','block');$('.hnavVNN li:first').attr("class","current");paddingLeftCal($('.hnavVNN li:first').position().left)}}var menuCurrentAlias='trang-chu';