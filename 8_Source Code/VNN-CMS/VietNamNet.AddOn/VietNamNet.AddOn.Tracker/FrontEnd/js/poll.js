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
function showResult(a,b){if(a){var c=new VietNamNet.Framework.JS.Template({id:'tmpR',template:tempResult});VietNamNet.Framework.JS.TemplateManager.bind($('#'+b+' .diaResult'),a,c);var d=new VietNamNet.Framework.JS.Template({id:'tmpD',template:tempResultDetail.replace(/SumResult/gi,a.SumResult)});VietNamNet.Framework.JS.TemplateManager.bind($('.result_'+a.SurveyId,$('#'+b+' .diaResult')),a.SurveyOption,d)}};

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























function showAllSurveyBySurvey(){
    $('div[survey=true]').each(function(index){
        //this.id
        //alert($(this).attr('surveyId'));
        showSurvey(this.id,'','', $(this).attr('surveyId'))
    })
};

function showAllSurveyByArticle(){
    $('div[survey=true]').each(function(index){
        //this.id
        //alert($(this).attr('surveyId'));
        showSurvey(this.id,'',$(this).attr('articleId'),'')
    })
};

function showAllSurveyByCat(){
    $('div[survey=true]').each(function(index){
        //this.id
        //alert($(this).attr('surveyId'));
        showSurvey(this.id,$(this).attr('categoryalias'),'','')
    })
};
 
function showAllSurvey(){
     $('div[survey=true]').each(function(index){
        showSurvey(this.id,$(this).attr('categoryalias'),$(this).attr('articleId'),$(this).attr('surveyId'))
    })
};

VietNamNet.Framework.JS.Initialization.add(showAllSurvey);





function validateSubmit(survey,divId) {
    var d = $('#'+divId);
    //if ($('#'+ 'poll' + ' :input[checked=true]').length >0) {
    if ($('#'+ divId + ' :input[checked=true]').length >0) {
        //alert('ye');
          submitPoll(survey,divId);
          return false;}
    
    alert('Please chose an option!');
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
                $('#'+div + ' .action').text("View result"); 
                $('#'+div + ' .action').unbind('click');
  $('#'+div +' .diaResult ').jqm({trigger: '#'+div + ' .action'});
   
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
};




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
       var cIndentity=$('.sIndentity', d); if ( cIndentity.val().length!=9 ) {msg.html('Bạn hãy điền CMND trước khi gửi!');cIndentity.focus(); return false;}
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
             var d = $('#'+div);var msg=$('#'+divId + ' .mess');
        
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

 
 