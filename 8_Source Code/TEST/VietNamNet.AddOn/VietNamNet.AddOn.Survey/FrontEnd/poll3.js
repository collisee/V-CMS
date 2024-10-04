var service_getpoll_url2="/Survey/Services/ServicesSurveyGet2.aspx";
var service_postpoll_url="/Survey/Services/ServicesSurveyPost.aspx";
var service_getpollresult_url="/Survey/Services/ServicesSurveyResult.aspx?surveyid=SURVEY_ID";
var service_result_url="/Survey/Services/ViewResult.aspx?surveyid=SURVEY_ID";

var srvSurvey_url="/ajax/Survey/g.html";
var temp="<div class=\"vote_most\"> " +
    		"<div class=\"vote_most_title\">Thăm dò ý kiến</div>" +
				" <div class=\"vote_most_list\"> " +
					"<div class=\"vote_question\"> {Question} </div>" +
					"<div class=\"vote_most_item\" id=\"options_{SurveyId}\"></div>" +
					"<div class=\"vote_respost\"><a href=\"#\" id=\"action_{SurveyId}\"  > </a> [lblHidden]</div>" +
				" </div>" +
 "</div>";
 var tempOptionC = "<div class=\"vote_item\"><label><input type=\"checkbox\" id=\"input_{SurveyOptionId}\" name=\"itemId\" value=\"{SurveyOptionId}\">{OptionName}</label></div>";
 var tempOptionR = "<div class=\"vote_item\"><label><input type=\"radio\" id=\"input_{SurveyOptionId}\" name=\"itemId\" value=\"{SurveyOptionId}\">{OptionName}</label></div>";
var tempButton = "<a href=\"#\" id=\"LINK_ID\"  onclick=\"LINK_EVENT\"></a>"
 
function showPoll(catalias, aId, divId, surveyId) {
    var vId = document.cookie;
    VietNamNet.Framework.JS.AjaxManager.add({
        url: srvSurvey_url,//link service
        data: {categorysalias: catalias, articleid: aId, divId: divId, v:vId, surveyid: surveyId}, //du lieu gui len
        success: function(output){
            var obj = VietNamNet.Framework.JS.JSON.decode(output); 
            bind(obj,divId);            
        }
    });
}

function bind(obj,divId){
   // var t = "aaaaaalength=" + obj.SurveyOption.length + temp ;
    if (obj){ //bind obj
          var tmpQ = new VietNamNet.Framework.JS.Template({
                        id: 'tmpQ',
                        template: temp
                    });
          VietNamNet.Framework.JS.TemplateManager.bind(divId , obj, tmpQ);
          
          var tmpO = new VietNamNet.Framework.JS.Template({
                        id: 'tmpO',
                        template: obj.OptionType == "C"? tempOptionC : tempOptionR
                    });
          VietNamNet.Framework.JS.TemplateManager.bind("options_"+ obj.SurveyId , obj.SurveyOption, tmpO);
          
          // nếu đã vote 
            //$('#'+divId + ' input ' ) .attr("disabled","disabled");
            //$('#'+divId + ' a#action_'+ obj.SurveyId).text("Xem kết quả");
           // chưa vote thì Bình chọn
          $('#'+divId + ' a#action_'+ obj.SurveyId).text("Bình chọn");
          $('#'+divId + ' a#action_'+ obj.SurveyId).click(function (){return validateSubmit(obj.SurveyId,divId)});

          }
}

//$('*[survey=true]').each(function(){
//    bind(obj, $(this) );
//})

function validateSubmit(survey,divId) {
    var d = $('#'+divId)
    if ($('#'+ 'poll' + ' :input[checked=true]').length >0) {
        alert('ye');
          submitPoll(survey,divId);
          return false;}
    
    alert('Bạn hãy chọn 1 lựa chọn!');
        return false;
        
//    var formSurvey =  document.forms[0];
//        for(var i = 0; i < formSurvey.itemId.length; i++) {
//            if(formSurvey.itemId[i].checked) {
//                submitPoll(survey,divId);
//                return false;
//            }
//        }
//        alert('Bạn hãy chọn 1 lựa chọn!');
//        return false;
    }

function submitPoll(survey,div) {
    var surveyId = survey;  // document.getElementById(survey).value; 
    var divId =div; // document.getElementById(div).value;
//    var form =  document.forms[0];
//    items = [];
//    for(var i = 0; i < form.itemId.length; i++) {
//        if(form.itemId[i].checked) {
//            items.push(form.itemId[i].value);
//        }
//    } 
     // nếu đã vote 
            $('#'+divId + ' input ' ) .attr("disabled","disabled");
            $('#'+divId + ' a#action_'+ surveyId).text("Xem kết quả"); 
            
//    VietNamNet.Framework.JS.AjaxManager.add({
//        url: service_postpoll_url,
//        data: {pollId: surveyId, randId: Math.random(), itemId:items.join(',')},
//        success: function(output){
//          
//            //showPoll(null, null, divId, surveyId);
//            //$('#message').jqm();$('#message').jqmShow();
//        }
//    });
}
 
 
function showresult(survey)
{
if (document.forms.length>1)   var formSurvey =  document.getElementById(formId);
else var formSurvey =  document.forms[0];
	window.open(service_result_url.replace("SURVEY_ID", document.getElementById(survey).value), 'Kết quả bình chọn', 'scrollbars=yes,resizeable=no,locationbar=no,width=500,height=350,left='.concat((screen.width - 500)/2).concat(',top=').concat((screen.height - 250)/2));
}

function viewresult(survey,dialogId)
{
if (document.forms.length>1)   var formSurvey =  document.getElementById(formId);
else var formSurvey =  document.forms[0];
    $(dialogId).jqm({ajax: service_getpollresult_url.replace("SURVEY_ID",  $('#'+survey).val())});$(dialogId).jqmShow();
return false;
}
