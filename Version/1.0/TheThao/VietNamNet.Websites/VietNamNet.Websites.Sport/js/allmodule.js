﻿/* module Survey */
var srvSurvey_posturl='http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'+'sn=survey&dm=thethao.vietnamnet.vn&us=me&vs=1'+'&randId=[RANDOMID]&surveyId=[SURVEYID]&itemId=[ITEMID]';var srvSurvey_url="/ajax/Survey/get/g.html";
var tempOptionC='<div class=\"vote-anser\"><label><input type=\"checkbox\" id=\"itemId\" name=\"itemId\" value=\"{SurveyOptionId}\"> {OptionName}</label></div>';
var tempOptionR="<div class=\"vote-anser\"><label><input type=\"radio\" id=\"itemId\" name=\"itemId\" value=\"{SurveyOptionId}\"> {OptionName}</label></div>";
var tempButton='<a href=\"#\" id=\"LINK_ID\"  onclick=\"LINK_EVENT\" class="action"></a>';
var tempDialog='<div id=\"dias{SurveyId}\" class=\"jqmWindow diaResult\">Please wait... <img alt=\"loading\" src=\"/Images/busy.gif\"></div>';
var temp='<div class="bbc-box"><div class="bbc-top">&nbsp;</div><div class="pdlr5 ">'+
            '<div class="box-item-title"><a href="#">Trưng cầu ý kiến</a></div> <div class="pd10">' +
            '<div class="vote-ques">   {Question}   </div>' +
            '<div class=\"vote_most_item options_{SurveyId}\"></div>' +
            '<div class="vote-tool"><a href="javascript:void(0);" id=\"action_{SurveyId}\" class="action"  > </a></div>'+
            '</div></div><div class="bbc-bottom">&nbsp;<img id="cmdPostSurvey" /></div></div>'

//'<div class=\"vote_most\"> ' +
//    		'<div class=\"vote_most_title\">POLLING</div>' +
//				' <div class=\"vote_most_list\"> ' +
//					'<div class=\"vote_question\"> {Question} </div>'+
//					'<div class=\"vote_most_item options_{SurveyId}\"></div>' +
//					'<div class=\"vote_respost\"><a href="javascript:void(0);" id=\"action_{SurveyId}\" class="action"  > </a></div>' +
//				' </div>' +
//'</div><img id="cmdPostSurvey" />';
var tempResult="<div class=\"vote_most\"> " +
    		"<div class=\"vote_most_title\">Kết quả bình chọn</div>" +
				" <div class=\"vote_most_list\"> " +
					"<div class=\"vote_question\"> {Question} </div>" +
					"<div class=\"vote_most_item survey result_{SurveyId}\"></div>" +
					"<div class=\"vote_respost\"><a href=\"#\" id=\"action_{SurveyId}\"  > </a> </div>" +
				" </div>" +
 "</div><a href=\"#\" class=\"jqmClose\"></a>";
 var tempResultDetail=" <div class=\"sitem\">"+
            "<div style=\"width: 55%; \">"+
                "<label class=\"label\">{OptionName}</label>"+
            "</div>"+
            "<div style=\"width: 25%; \">"+
                  "<div class=\"result\" style=\"width:{ResultPercent}\"></div>"+
            "</div>"+
            "<div style=\"width: 10%; text-align:right; \">{ResultPercent}</div>"+
            "<div style=\"width: 10%; text-align:right; \">{Result}/SumResult</div>"+
        "</div>"; 
function showResult(a,b){if(a){var c=new VietNamNet.Framework.JS.Template({id:'tmpR',template:tempResult});VietNamNet.Framework.JS.TemplateManager.bind($('#'+b+' .diaResult'),a,c);var d=new VietNamNet.Framework.JS.Template({id:'tmpD',template:tempResultDetail.replace(/SumResult/gi,a.SumResult)});VietNamNet.Framework.JS.TemplateManager.bind($('.result_'+a.SurveyId,$('#'+b+' .diaResult')),a.SurveyOption,d)}};

function bind(obj,divId){ 
    if (obj){  
          var tmpQ = new VietNamNet.Framework.JS.Template({
                        id: 'tmpQ',
                        template: temp + tempDialog
                    });
          VietNamNet.Framework.JS.TemplateManager.bind(divId , obj, tmpQ);
          
          var tmpO = new VietNamNet.Framework.JS.Template({
                        id: 'tmpO',
                        template: obj.OptionType == "C"? tempOptionC : tempOptionR
                    });
          VietNamNet.Framework.JS.TemplateManager.bind($('#'+divId+ " .options_"+ obj.SurveyId) , obj.SurveyOption, tmpO);
          
          if (Survey_checkCookie(obj.SurveyId) || obj.HasVoted){// nếu đã vote 
                 $('#'+divId + ' input ' ) .attr("disabled","disabled");
                $('#'+divId + ' .action').text("Xem kết quả");
                $('#'+divId + ' .action').unbind('click');
                showResult(obj, divId);
                $('#'+divId +' .diaResult ').jqm({trigger: '#'+divId + ' .action'});
          } else { // chưa vote thì Bình chọn  
                $('#'+divId + ' .action').text("Bỏ phiếu");
                 $('#'+divId + ' .action').click(function (){return validateSubmit(obj.SurveyId,divId)});
          }
          
          
           
    }
};

function showSurvey(divId, catalias, aId,  surveyId) { 
    VietNamNet.Framework.JS.AjaxManager.add({
        url: srvSurvey_url,//link service
        data: {categorysalias: catalias, articleid: aId, divId: divId,  surveyid: surveyId}, //du lieu gui len
        success: function(output){
            var obj = VietNamNet.Framework.JS.JSON.decode(output); 
            bind(obj,divId);
                     
        }
    });
};
function showAllSurveyBySurvey(){$('div[survey=true]').each(function(a){showSurvey(this.id,'','',$(this).attr('surveyId'))})};function showAllSurveyByArticle(){$('div[survey=true]').each(function(a){showSurvey(this.id,'',$(this).attr('articleId'),'')})};function showAllSurveyByCat(){$('div[survey=true]').each(function(a){showSurvey(this.id,$(this).attr('categoryalias'),'','')})};function showAllSurvey(){$('div[survey=true]').each(function(a){showSurvey(this.id,$(this).attr('categoryalias'),$(this).attr('articleId'),$(this).attr('surveyId'))})};VietNamNet.Framework.JS.Initialization.add(showAllSurvey);

function validateSubmit(a,b){var d=$('#'+b);if($('#'+b+' :input[checked=true]').length>0){submitPoll(a,b);return false}alert('Bạn hãy chọn một lựa chọn trước!');return false};
function submitPoll(a,b){items=[];var f=$('#'+b+' :input[checked=true]');for(var i=0;i<f.length;i++){items.push(f[i].value)}var c=srvSurvey_posturl.replace("[RANDOMID]",Math.random()).replace("[SURVEYID]",a).replace("[ITEMID]",items.join(','));$('#'+b+' #cmdPostSurvey').attr({src:c,title:"post"});Survey_setCookie(a);$('#'+b+' input ').attr("disabled","disabled");$('#'+b+' .action').text("Xem kết quả");$('#'+b+' .action').unbind('click');$('#'+b+' .diaResult ').jqm({trigger:'#'+b+' .action'})};function Survey_setCookie(a){c_name='Survey_'+a;var b=new Date();b.setDate(b.getDate()+1);document.cookie=c_name+"=true"+";expires="+b.toUTCString()};function Survey_getCookie(a){c_name='Survey_'+a;if(document.cookie.length>0){c_start=document.cookie.indexOf(c_name+"=");if(c_start!=-1){c_start=c_start+c_name.length+1;c_end=document.cookie.indexOf(";",c_start);if(c_end==-1)c_end=document.cookie.length;return true}}return false}function Survey_checkCookie(a){return Survey_getCookie(a)}













/* module Comment (feedback) */
var service_post_url='http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'+'sn=comment&dm=thethao.vietnamnet.vn&us=me&vs=1'+'&n=[NAME]&m=[MESSAGE]&s=[SUBJECT]&p=[PHONE]&em=[EMAIL]&v=[VALIDCODE]&aid=[ARTICLE]';
function postComment(){
    var cName = $('#newcomment .name').val();if( cName.length<=2||cName=='Họ và tên *'){$('#newcomment .mess').html('Bạn hãy nhập Họ tên!');$('#newcomment .name').focus();return false};
    var cEmail = $('#newcomment .email').val();if(checkemail(cEmail)!=true){$('#newcomment .mess').html('Sai định dạng Email. Bạn hãy email!');$('#newcomment .email').focus();return false};
    var cPhone = $('#newcomment .phone').val();if(checkphone(cPhone)!=true){$('#newcomment .mess').html('Sai định dạng số điện thoại. Bạn hãy nhập số điện thoại!');$('#newcomment .phone').focus();return false};
    var cSubject = $('#newcomment .subject').val();if( cSubject.length<=2||cSubject=='Tiêu đề'){$('#newcomment .mess').html('Bạn hãy nhập Tiêu đề!'); $('#newcomment .subject').focus();return false;};
    var cMessage = $('#newcomment .message').val();if( cMessage.length<=5 || cMessage.length>1000 ||cMessage=='Nội dung'){$('#newcomment .mess').html('Bạn hãy nhập nội dung phản hồi!'); $('#newcomment .message').focus();return false;};
    var cAid = $('#newcomment .aid').val();
    var cValidCode = $('#newcomment .validcode').val();
    
    //linkPost='';
    $("#newcomment #cmdPostComment").attr({ 
          src: service_post_url.replace("[NAME]",cName).replace("[SUBJECT]",cSubject).replace("[PHONE]",cPhone)
                                .replace("[EMAIL]",cEmail).replace("[MESSAGE]",cMessage)
                                .replace("[ARTICLE]",cAid),
          title: "post" 
        }); 
        
$('#newcomment .mess').html('Cám ơn bạn đã phản hồi!');
    
    //$('#newcomment .name').attr('value','');
    $('#newcomment .subject').val('').blur();
    //$('#newcomment .phone').attr('value','');
    //$('#newcomment .mail').attr('value','');
    $('#newcomment .message').val('').blur();
    $('#newcomment .validcode').val('').attr('value','');
}


function resetComment(){$('#newcomment .name').attr('value','');$('#newcomment .phone').attr('value','');$('#newcomment .email').attr('value','');$('#newcomment .subject').attr('value','');$('#newcomment .message').attr('value','');$('#newcomment .validcode').attr('value','')}$(document).ready(function(){$("#article-feedback .article-freedback-form").hide();var a=false;$('#article-feedback .article-freedback-title span').click(function(){$('#article-feedback .article-freedback-title').toggleClass('article-freedback-title2');if(a){a=false;$('#article-feedback .article-freedback-form').slideUp('slow')}else{a=true;$('#article-feedback .article-freedback-form').slideDown('slow')}})});var service_get_url="/ajax/getComment/get.html";var tempComment=' '+'<div id="feedback-title" style="display:block;">'+'<div id="feedback-sort"></div>'+'<div class="box-title">Ý kiến bạn đọc</div>'+'<div class="clear">,</div>'+'</div>'+'<div  id="feedback-list" class="list"></div>'+'<div id="paging" class="pagy cm-page">'+'&nbsp; <a href="javascript:void(0)" class="paging-prev">Trang trước</a> '+'&nbsp; <a href="javascript:void(0)" class="paging-next">Trang sau</a> '+'<br class="clear" />'+'</div>';var tempComment1=' '+'<div class="pd5 list"></div>'+'<div class="pdt5 bortop cm-page">'+'&nbsp; <a href="javascript:void(0)" class="paging-prev">Trang trước</a> '+'&nbsp; <a href="javascript:void(0)" class="paging-next">Trang sau</a> '+'<br class="clear" />'+'</div>';var tempCommentItem='<div class="feedback-item">'+'<div class="comment"><i>{Subject}</i><br>{Detail}</div>'+'<div class="profile">{Name}, gửi lúc {CreatedDate} </div>'+'</div>';var tempCommentItem1='<div class="coment-item">'+'<div class="feerback-top">&nbsp;</div>'+'<div class="feerback-body">'+'<div class="pdtb5 bold">{Subject}</div>'+'<div class="pdtb5 bortop">{Detail}</div>'+'</div>'+'<div class="feerback-bottom">&nbsp;</div>'+'<div class="feerback-user">'+'<font class="bold red52">{Name}</font> - {Email}'+'</div>'+'</div>';var CurrentPageIndex=1;function bindComment(a,b,c){if(a){$('#'+c).html(tempComment);var d=new VietNamNet.Framework.JS.Template({id:'tmpComment',template:tempCommentItem});VietNamNet.Framework.JS.TemplateManager.bind($('#'+c+' .list'),a,d);$('#'+c+' .paging-next').show();$('#'+c+' .paging-next').click(function(){CurrentPageIndex++;showComment(b,CurrentPageIndex,c)});if(!CurrentPageIndex||CurrentPageIndex<=1){$('#'+c+' .paging-prev').hide()}else{$('#'+c+' .paging-prev').show();$('#'+c+' .paging-prev').click(function(){CurrentPageIndex--;showComment(b,CurrentPageIndex,c)})}}else{$('#'+c+' .paging-next').hide()}}function prevComment(){pageIndex--;initComment()}function nextComment(){pageIndex++;initComment()}function showComment(d,e,f){VietNamNet.Framework.JS.AjaxManager.add({url:service_get_url,data:{m:d,index:e},success:function(a){var b='';if(a&&a!='""'&&a!='null'){b=a.trim()}else{$('#'+f).hide();return};var c=VietNamNet.Framework.JS.JSON.decode(b);if(c){bindComment(c,d,f)}else{$('#'+f+' .paging-next').hide()}},error:function(){$('#'+f+' .paging-prev').hide();$('#'+f+' .paging-next').hide()}});return false}function initComment(){$('div[comment=true]').each(function(a){showComment($(this).attr('articleId'),0,this.id)})}VietNamNet.Framework.JS.Initialization.add(initComment);
/* module Article */
var serviceArticle_post_url='http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'+'sn=article&dm=thethao.vietnamnet.vn&us=me&vs=1'+'&aid=[ARITCLEID]&catalias=[CATEGORYALIAS]';tempArticle='<div class="container"></div><iframe src="" class="post" style="display:none;"></iframe>';function bindArticleTracking(a,b,c){a.html(tempArticle);var s=serviceArticle_post_url.replace("[ARITCLEID]",b).replace("[CATEGORYALIAS]",c);$('.post',a).attr('src',s)};function showArticleTracking(){$('div[articleTracking=true]').each(function(){bindArticleTracking($(this),$(this).attr('articleId'),$(this).attr('categoryalias'))})};VietNamNet.Framework.JS.Initialization.add(showArticleTracking);