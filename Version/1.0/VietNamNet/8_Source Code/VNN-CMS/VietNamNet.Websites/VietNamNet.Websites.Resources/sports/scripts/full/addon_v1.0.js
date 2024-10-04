/* module Survey */
VietNamNet.Framework.JS.Survey = function(){};
VietNamNet.Framework.JS.Survey.prototype = {
    postUrl : 'http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'
                +'sn=survey&dm=thethao.vietnamnet.vn&us=me&vs=1'
                +'&randId=[RANDOMID]&surveyId=[SURVEYID]&itemId=[ITEMID]',
    getUrl : '/ajax/Survey/get/g.html',
    
    tempOptionC:'<div ><label><input type="checkbox" id="itemId" name="itemId" value="{SurveyOptionId}"> {OptionName}</label></div>',
    tempOptionR:'<div ><label><input type="radio"    id="itemId" name="itemId" value="{SurveyOptionId}"> {OptionName}</label></div>',
    tempButton: '<a href=\"#\" id=\"LINK_ID\"  onclick=\"LINK_EVENT\" class="action"></a>';
    tempDialog: '<div id=\"dias{SurveyId}\" class=\"jqmWindow diaResult\">Please wait... <img alt=\"loading\" src=\"/Images/busy.gif\"></div>';

    temp : '<div class="bbc-box"><div class="bbc-top">&nbsp;</div><div class="pdlr5 ">'+
            '<div class="box-item-title"><a href="#">Trưng cầu ý kiến</a></div> <div class="pd10">' +
            '<div class="vote-ques">   {Question}   </div>' +
            '<div class="vote_most_item options_{SurveyId}"></div>' +
            '<div class="vote-tool"><a href="javascript:void(0);" id="action_{SurveyId}" class="action"  > </a></div>'+
            '</div></div><div class="bbc-bottom">&nbsp;<img id="cmdPostSurvey" /></div></div>',
    tempResult : '<div class="vote_most"> ' +
    		            '<div class="pvt-title"><a href="#"><img src="images/blank.gif" width="30px" height="24px" /></a></div>' +
			                '<div class="pvt-ques pd10"> {Question} </div>' +
				            ' <div class="pvt-ans"> ' +
					            '<div class="pvt-ans survey result_{SurveyId}"></div>' +
					            '<div class="vote_respost"><a href="#" id="action_{SurveyId}"  > </a> </div>'+
					            '<div class="pvt-total">Tổng số bình chọn : <span class="red">{SumResult}</span> lượt</div>'+
				            ' </div>' +
             '</div><a href="#" class="jqmClose"></a>',
  tempResultDetail : '<div class="pvt-item">'+
                ' <div class="pvt-item1">{OptionName} </div>'+
				'<div class="pvt-item2">'+
					'<div class="bieudo{index}" style="width: {ResultPercent}">&nbsp;</div> {ResultPercent}'+
				'</div>'+
				'<div class="pvt-item3">{Result}/SumResult</div><br class="clear"  />'+
				'</div>',
    
    showSurvey : function(divId, catalias, aId,  surveyId) { 
        VietNamNet.Framework.JS.AjaxManager.add({
            url: srvSurvey_url,//link service
            data: {categorysalias: catalias, articleid: aId, divId: divId,  surveyid: surveyId}, //du lieu gui len
            success: function(output){
                var obj = VietNamNet.Framework.JS.JSON.decode(output); 
                bind(obj,divId);
                         
            }
        });
    },

    bind : function(obj,divId){ 
        if (obj){  
              if (obj.SurveyOption && obj.SurveyOption.length && obj.SurveyOption.length > 0){
                for(var i = 0; i < obj.SurveyOption.length; i++) obj.SurveyOption[i].index = i + 1;
              }
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
                    showResult(obj, divId);
                    $('#'+divId + ' .action').click(function (){return validateSubmit(obj.SurveyId,divId)});
              }
        };
    },

    validateSubmit: function(survey,divId) {
        var d = $('#'+divId);
        //if ($('#'+ 'poll' + ' :input[checked=true]').length >0) {
        if ($('#'+ divId + ' :input[checked=true]').length >0) {
            //alert('ye');
              submitPoll(survey,divId);
              return false;}
        
        alert('Bạn vui lòng chọn một lựa chọn trước khi gửi!');
            return false;
    },
 

    submitPoll: function(survey,div) { 
            items = [];
            var f= $('#'+ div + ' :input[checked=true]');
            for(var i = 0; i <f.length; i++) {
                    items.push(f[i].value);
            }  
            var tracker = srvSurvey_posturl.replace("[RANDOMID]", Math.random()).replace("[SURVEYID]",survey).replace("[ITEMID]",items.join(','));    
               
            $('#'+ div + ' #cmdPostSurvey').attr({src: tracker,title: "post"});
            Survey_setCookie(survey);
           // $('#'+ div + ' #cmdPostSurvey').html('<img src="'+tracker+'" title="post" />');
           
         $('#'+div + ' input ' ).attr("disabled","disabled");
                        $('#'+div + ' .action').text("Xem kết quả"); 
                        $('#'+div + ' .action').unbind('click');
          $('#'+div +' .diaResult ').jqm({trigger: '#'+div + ' .action'});
        
    },
				
    showResult: function(obj,b){
        if(obj){
            var c=new VietNamNet.Framework.JS.Template(
                {   id:'tmpR',
                    template:tempResult
                }
            );
            VietNamNet.Framework.JS.TemplateManager.bind($('#'+b+' .diaResult'),obj,c);
            var d=new VietNamNet.Framework.JS.Template(
                    {   id:'tmpD',
                        template:tempResultDetail.replace(/SumResult/gi,a.SumResult)
                     }
            );
        VietNamNet.Framework.JS.TemplateManager.bind($('.result_'+obj.SurveyId,$('#'+b+' .diaResult')),obj.SurveyOption,d)}
    },

    
    a: ''
}

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
            '</div></div><div class="bbc-bottom">&nbsp;<img id="cmdPostSurvey" /></div></div>';

var tempResult='<div class="vote_most"> ' +
    		'<div class="pvt-title"><a href="#"><img src="images/blank.gif" width="30px" height="24px" /></a></div>' +
			    '<div class="pvt-ques pd10"> {Question} </div>' +
				' <div class="pvt-ans"> ' +
					'<div class=\"pvt-ans survey result_{SurveyId}\"></div>' +
					'<div class=\"vote_respost\"><a href=\"#\" id=\"action_{SurveyId}\"  > </a> </div>'+
					'<div class="pvt-total">Tổng số bình chọn : <span class="red">{SumResult}</span> lượt</div>'+
				' </div>' +
 '</div><a href=\"#\" class=\"jqmClose \"></a>';
 
  var tempResultDetail='<div class="pvt-item">'+
                ' <div class="pvt-item1">{OptionName} </div>'+
				'<div class="pvt-item2">'+
					'<div class="bieudo{index}" style="width: {ResultPercent}">&nbsp;</div> {ResultPercent}'+
				'</div>'+
				'<div class="pvt-item3">{Result}/SumResult</div><br class="clear"  />'+
				'</div>';
 
 
 var tempResultDetail2=' <div class=\"sitem pvt-item1\">'+
            '<div style=\"width: 55%; \">'+
                '<label class=\"label\">{OptionName}</label>'+
            '</div>'+
            '<div style=\"width: 25%; \">'+
                 '<div class=\"result\" style=\"width:{ResultPercent}\"></div>'+
            '</div>'+
            '<div style=\"width: 10%; text-align:right; \">{ResultPercent}</div>'+
            '<div style=\"width: 10%; text-align:right; \">{Result}/SumResult</div>'+
        "</div>"; 
        				
function showResult(obj,b){
    if(obj){
        var c=new VietNamNet.Framework.JS.Template(
            {   id:'tmpR',
                template:tempResult
            }
        );
        VietNamNet.Framework.JS.TemplateManager.bind($('#'+b+' .diaResult'),obj,c);
        var d=new VietNamNet.Framework.JS.Template(
                {   id:'tmpD',
                    template:tempResultDetail.replace(/SumResult/gi,a.SumResult)
                 }
        );
    VietNamNet.Framework.JS.TemplateManager.bind($('.result_'+obj.SurveyId,$('#'+b+' .diaResult')),obj.SurveyOption,d)}};

 //
 




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

function bind(obj,divId){ 
    if (obj){  
          if (obj.SurveyOption && obj.SurveyOption.length && obj.SurveyOption.length > 0){
            for(var i = 0; i < obj.SurveyOption.length; i++) obj.SurveyOption[i].index = i + 1;
          }
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
                showResult(obj, divId);
                $('#'+divId + ' .action').click(function (){return validateSubmit(obj.SurveyId,divId)});
          }
    }
}

function validateSubmit(survey,divId) {
    var d = $('#'+divId);
    //if ($('#'+ 'poll' + ' :input[checked=true]').length >0) {
    if ($('#'+ divId + ' :input[checked=true]').length >0) {
        //alert('ye');
          submitPoll(survey,divId);
          return false;}
    
    alert('Bạn vui lòng chọn một lựa chọn trước khi gửi!');
        return false;
    };
 

function submitPoll(survey,div) { 
    items = [];
    var f= $('#'+ div + ' :input[checked=true]');
    for(var i = 0; i <f.length; i++) {
            items.push(f[i].value);
    }  
    var tracker = srvSurvey_posturl.replace("[RANDOMID]", Math.random()).replace("[SURVEYID]",survey).replace("[ITEMID]",items.join(','));    
       
    $('#'+ div + ' #cmdPostSurvey').attr({src: tracker,title: "post"});
    Survey_setCookie(survey);
   // $('#'+ div + ' #cmdPostSurvey').html('<img src="'+tracker+'" title="post" />');
   
 $('#'+div + ' input ' ).attr("disabled","disabled");
                $('#'+div + ' .action').text("Xem kết quả"); 
                $('#'+div + ' .action').unbind('click');
  $('#'+div +' .diaResult ').jqm({trigger: '#'+div + ' .action'});
    
};
    





/* module Survey Games */


//VietNamNet.Framework.JS.SurveyGame.showGame(); // alert 1

VietNamNet.Framework.JS.SurveyGame1 = function(){};
VietNamNet.Framework.JS.SurveyGame1.prototype = {
    temp:'<div class="bbc-box"><div class="bbc-top">&nbsp;</div><div class="pdlr5 ">'+
            '<div class="box-item-title"><a href="#">Trò chơi</a></div> '+
            '<div class="pd10">'+ // begin UserInfo
                '<div class="vote-anser"><label class="label w70" for="stName">Họ tên <span class="red">*</span>: </label>         <input type="text" name="stName" class="w150 sName" ></div> <br class="clear"/>'+
                '<div class="vote-anser"><label class="label w70" for="stIndentity">CMND <span class="red">*</span>:</label>           <input type="text" name="stIndentity" class="w150 sIndentity" ></div> <br class="clear"/>'+
                '<div class="vote-anser"><label class="label w70" for="stPhone">Điện thoại <span class="red">*</span>:</label>     <input type="text" name="stPhone" class="w150 sPhone" ></div> <br class="clear"/>'+
                '<div class="vote-anser"><label class="label w70" for="stEmail">Email <span class="red">*</span>:</label>     <input type="text" name="stEmail" class="w150 sEmail" ></div> <br class="clear"/>'+
                '<div class="vote-anser"><label class="label w70" for="stAddress">Địa chỉ :</label>        <input type="text" name="stAddress" class="w150 sAddress" ></div> <br class="clear"/>'+// end UserInfo
                    // begin Survey
                '<div class="vote-ques">   {Question}   </div>' +
                '<div class=\"vote_most_item options_{SurveyId}\"></div>' +
                '<div class="red mess"></div>' +
                '<div class="vote-tool"><a href="javascript:void(0);" id=\"action_{SurveyId}\" class="action"  > </a></div>'+
            '</div></div><div class="bbc-bottom">&nbsp;<img id="cmdPostSurvey" />'+
            '</div>'+ // end Survey
            '</div>',
    posturl:'http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'+'sn=survey&dm=thethao.vietnamnet.vn&us=me&vs=1'
                +'&randId=[RANDOMID]&surveyId=[SURVEYID]&itemId=[ITEMID]'
                +'&name=[NAME]&identityCard=[INDENTITYCARD]&address=[ADDRESS]&email=[EMAIL]',  
    config: {domainname: 'd',tracking: ''},
    id: '',
    postUrl: '',
    init: function(cfg){
        this.config = $.extend(this.config, cfg);
        
    }, 
    bindGame: function(obj,divId){ 
        var _this = this;
        if (obj){  
              var tmpQ = new VietNamNet.Framework.JS.Template({
                            id: 'tmpQ',
                            template: _this.temp
                        });
              VietNamNet.Framework.JS.TemplateManager.bind(divId , obj, tmpQ);
              
              var tmpO = new VietNamNet.Framework.JS.Template({
                            id: 'tmpO',
                            template: obj.OptionType == "C"? tempOptionC : tempOptionR
                        });
              VietNamNet.Framework.JS.TemplateManager.bind($('#'+divId+ " .options_"+ obj.SurveyId) , obj.SurveyOption, tmpO);
              
                    $('#'+divId + ' .action').text("Gửi");
                    $('#'+divId + ' .action').click(function (){return _this.validate(obj.SurveyId,divId)});
        }
    },           
    showGame: function(divId, aId) { 
        var _this = this;
        VietNamNet.Framework.JS.AjaxManager.add({
            url: srvSurvey_url,//link service
            data: {categorysalias: 0, articleid: aId, divId: divId,  surveyid: 0}, //du lieu gui len
            success: function(output){
                var obj = VietNamNet.Framework.JS.JSON.decode(output); 
                _this.bindGame(obj,divId);
            }
        });
    },
    showAllGame: function(){
        var _this = this;
        $('div[surveygame=true]').each(function(a){
            _this.showGame(this.id,$(this).attr('articleId'));
        })
    },
    validate: function(survey,divId) {var _this = this;
        var d = $('#'+divId);var msg=$('#'+divId + ' .mess');
        msg.html('');
       
       var cName=$('.sName', d);if (! cName.val() || cName.val().length<2 ) { msg.html('Bạn hãy điền Họ tên trước khi gửi!');cName.focus();  return false;}
       var cIndentity=$('.sIndentity', d); if ( cIndentity.val().length<9 || cIndentity.val().length>10 ) {msg.html('Bạn hãy điền CMND trước khi gửi!');cIndentity.focus(); return false;}
       var cPhone=$('.sPhone', d); if (checkphone(cPhone.val())!=true) { cPhone.focus();msg.html('Bạn hãy điền Số điện thoại trước khi gửi!'); return false;}
       var cEmail=$('.sEmail', d); if (checkemail(cEmail.val())!=true) { cEmail.focus();msg.html('Bạn hãy điền đúng Email trước khi gửi!'); return false;}
       
       if ($('input[checked=true]',d).length >0) {   
             _this.submitSend(survey,divId);
        } else 
        {
             msg.html('Hãy chọn một lựa chọn trước khi gửi!'); return false; 
        }
       
        
   },
   submitSend: function(survey,div) { 
            var _this=this;
            items = [];
            var f= $('#'+ div + ' :input[checked=true]');
             var d = $('#'+div);var msg=$('#'+div + ' .mess');
        
            var cName=$('.sName', d).val();var cIndentity=$('.sIndentity', d).val();
            var cPhone=$('.sPhone', d).val();var cEmail=$('.sEmail', d).val();
            
            for(var i = 0; i <f.length; i++) {
                    items.push(f[i].value);
            }  
            var tracker = _this.posturl.replace("[RANDOMID]", Math.random())
                                    .replace("[SURVEYID]",survey).replace("[ITEMID]",items.join(','))
                                    .replace("[NAME]",cName)
                                    .replace("[INDENTITYCARD]",cIndentity)
                                    .replace("[ADDRESS]",cPhone)
                                    .replace("[EMAIL]",cEmail);
               //'&name=[NAME]&identityCard=[INDENTITYCARD]&address=[ADDRESS]&email=[EMAIL]'
            $(' #cmdPostSurvey', d).attr({src: tracker,title: "post"});
            Survey_setCookie(survey);
           // $('#'+ div + ' #cmdPostSurvey').html('<img src="'+tracker+'" title="post" />');
           
            $(' input ', d ).attr("disabled","disabled");
                            $('#'+div + ' .action').unbind('click');
           msg.html('Thông tin đã được gửi. Cám ơn bạn đã tham gia!');
           /* VietNamNet.Framework.JS.AjaxManager.add({
                url: srvSurvey_posturl,
                data: { sn: 'survey',dm='english', us='me',vs='test',
                        surveyId: surveyId, randId: Math.random(), itemId:items.join(',')},
                success: function(output){ 
                    if (output='true'){
                        $('#'+divId + ' input ' ).attr("disabled","disabled");
                        $('#'+divId + ' .action').text("Xem kết quả"); 
                        $('#'+divId + ' .action').unbind('click');
                        
                        VietNamNet.Framework.JS.AjaxManager.add({
                            url: srvSurvey_url,//link service
                            data: {categorysalias: '', articleid: '', divId: divId,  surveyid: surveyId}, //du lieu gui len
                            success: function(output){
                                var obj = VietNamNet.Framework.JS.JSON.decode(output); 
                                showResult(obj, divId);          
                            }
                        });
                         $('#'+divId +' .diaResult ').jqm({trigger: '#'+divId + ' .action'});
                    } 
                }
            });*/
        }
}; 

function showGame(){
var game3 = new VietNamNet.Framework.JS.SurveyGame1(); 
game3.showAllGame();
}
VietNamNet.Framework.JS.Initialization.add(showGame);

 

function Survey_checkCookie(a){return Survey_getCookie(a)};
function Survey_setCookie(surveyId)
{c_name='Survey_'+surveyId;
var exdate=new Date();
exdate.setTime(exdate.getTime()+15); 
document.cookie= c_name + "=true" + ";expires="+exdate.toUTCString();
};

function Survey_getCookie(surveyId)
{
c_name='Survey_'+surveyId;
if (document.cookie.length>0)
  {
  c_start=document.cookie.indexOf(c_name + "=");
  if (c_start!=-1)
    {
    c_start=c_start + c_name.length+1;
    c_end=document.cookie.indexOf(";",c_start);
    if (c_end==-1) c_end=document.cookie.length;
    //return unescape(document.cookie.substring(c_start,c_end));
    return true;
    }
  }
return false;
} 
            
            




/* module Comment (feedback) */
var service_post_url='http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'+'sn=comment&dm=thethao.vietnamnet.vn&us=me&vs=1'+'&n=[NAME]&m=[MESSAGE]&s=[SUBJECT]&p=[PHONE]&em=[EMAIL]&v=[VALIDCODE]&aid=[ARTICLE]';
function postComment(){
    var cName = $('#newcomment .name').val();if( cName.length<=2||cName=='Họ và tên *'){$('#newcomment .mess').html('Bạn vui lòng nhập Họ tên!');$('#newcomment .name').focus();return false};
    var cEmail = $('#newcomment .email').val();if(checkemail(cEmail)!=true){$('#newcomment .mess').html('Sai định dạng Email. Bạn vui lòng email!');$('#newcomment .email').focus();return false};
    var cPhone = $('#newcomment .phone').val();if(checkphone(cPhone)!=true){$('#newcomment .mess').html('Sai định dạng số điện thoại. Bạn vui lòng nhập số điện thoại!');$('#newcomment .phone').focus();return false};
    var cSubject = $('#newcomment .subject').val();if( cSubject.length<=2||cSubject=='Tiêu đề'){$('#newcomment .mess').html('Bạn vui lòng nhập Tiêu đề!'); $('#newcomment .subject').focus();return false;};
    var cMessage = $('#newcomment .message').val();if( cMessage.length<=5 || cMessage.length>1000 ||cMessage=='Nội dung'){$('#newcomment .mess').html('Bạn vui lòng nhập nội dung phản hồi!'); $('#newcomment .message').focus();return false;};
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


function resetComment(){$('#newcomment .name').attr('value','');$('#newcomment .phone').attr('value','');$('#newcomment .email').attr('value','');$('#newcomment .subject').attr('value','');$('#newcomment .message').attr('value','');$('#newcomment .validcode').attr('value','')}
//$(document).ready(function(){$("#article-feedback .article-freedback-form").hide();var a=false;$('#article-feedback .article-freedback-title span').click(function(){$('#article-feedback .article-freedback-title').toggleClass('article-freedback-title2');if(a){a=false;$('#article-feedback .article-freedback-form').slideUp('slow')}else{a=true;$('#article-feedback .article-freedback-form').slideDown('slow')}})});



var service_get_url="/ajax/getComment/get.html";
var tempComment=' '+
    '<div id="feedback-title" class="home-article-comment-box" >'+
        '<div id="feedback-sort"></div>'+
        '<div class="fb_title"><h2>Ý kiến bạn đọc</h2></div>'+
        '<div class="clear">,</div>'+
    '</div>'+
    '<div  id="feedback-list" class="list"></div>'+
    '<div id="paging" class="pagy cm-page">'+
        '&nbsp; <a href="javascript:void(0)" class="paging-prev">Trang trước</a> '+
        '&nbsp; <a href="javascript:void(0)" class="paging-next">Trang sau</a> '+
    '<br class="clear" />'+'</div>';
var tempCommentItem='<div class="feedback-item">'+
    '<div class="comment"><i>{Subject}</i><br>{Detail}</div>'+
    '<div class="profile"><b>{Name}</b>, gửi lúc {CreatedDate} </div>'+'</div>';


                    
var CurrentPageIndex = 1;
function bindComment(obj, b, divId) { 
   if(obj) {
      $('#' + divId).html(tempComment);
      var d = new VietNamNet.Framework.JS.Template( {
         id : 'tmpComment', template : tempCommentItem}
      );
      VietNamNet.Framework.JS.TemplateManager.bind($('#' + divId + ' .list'), obj, d);
      $('#' + divId + ' .paging-next').show();
      $('#' + divId + ' .paging-next').click(function() {
         CurrentPageIndex++; showComment(b, CurrentPageIndex, divId)}
      ); 
      
      if(!CurrentPageIndex || CurrentPageIndex <= 1) {
         $('#' + divId + ' .paging-prev').hide()}
      else {
         
         $('#' + divId + ' .paging-prev').show();
         $('#' + divId + ' .paging-prev').click(function() {
            CurrentPageIndex--; 
            showComment(b, CurrentPageIndex, divId)}
         )}
      }
   else {
      $('#' + divId + ' .paging-next').hide()}
   }
function prevComment() {
   pageIndex--;
   initComment()}
function nextComment() {
   pageIndex++;
   initComment()}
function showComment(d, e, f) {
   VietNamNet.Framework.JS.AjaxManager.add( {
      url : service_get_url, data : {
         m : d, index : e}
      , success : function(a) {
         var b = ''; 
         if(a && a != '""' && a != 'null') {
            b = a.trim()}
         else {
            if (e  > 1) $('#' + f + ' .paging-next').hide(); 
            else $('#' + f).hide();
            return}; 

         var c = VietNamNet.Framework.JS.JSON.decode(b); 
         if(c) {
            bindComment(c, d, f)}
         else {
            $('#' + f + ' .paging-next').hide()}
         }
      , error : function() {
         $('#' + f + ' .paging-prev').hide(); $('#' + f + ' .paging-next').hide()}
      }
   );
   return false};


function initComment(){$('div[comment=true]').each(function(a){showComment($(this).attr('articleId'),0,this.id)})}VietNamNet.Framework.JS.Initialization.add(initComment);








/* Comment - show/hide box  */
$(function(){
		$("div.article-freedback-form", $('#newcomment')).hide();
		$("div.fb_title", $('#newcomment')).click(function(){
			if ($("div.article-freedback-form", $('#newcomment')).toggleClass('hidden').hasClass('hidden')){
			    $("h2 a",$(this)).attr("class","down");
			    $("div.article-freedback-form", $('#newcomment')).slideUp('slow');
			}else{
			    $("h2 a",$(this)).attr("class","up");
			    $("div.article-freedback-form", $('#newcomment')).slideDown('slow');
			}
			return false;
		});
	});

/* module Article */
var serviceArticle_post_url='http://Tracking.thethao.vietnamnet.vn/tracking/t.srv?'+'sn=article&dm=thethao.vietnamnet.vn&us=me&vs=1'+'&aid=[ARITCLEID]&catalias=[CATEGORYALIAS]';tempArticle='<div class="container"></div><iframe src="" class="post" style="display:none;"></iframe>';function bindArticleTracking(a,b,c){a.html(tempArticle);var s=serviceArticle_post_url.replace("[ARITCLEID]",b).replace("[CATEGORYALIAS]",c);$('.post',a).attr('src',s)};function showArticleTracking(){$('div[articleTracking=true]').each(function(){bindArticleTracking($(this),$(this).attr('articleId'),$(this).attr('categoryalias'))})};VietNamNet.Framework.JS.Initialization.add(showArticleTracking);



