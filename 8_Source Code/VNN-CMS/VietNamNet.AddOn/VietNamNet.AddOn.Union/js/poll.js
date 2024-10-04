var service_getpoll_url2="/Survey/Services/ServicesSurveyGet2.aspx";
var service_postpoll_url="/Survey/Services/ServicesSurveyPost.aspx";
var service_getpollresult_url="/Survey/Services/ServicesSurveyResult.aspx?surveyid=SURVEY_ID";
var service_result_url="/Survey/Services/ViewResult.aspx?surveyid=SURVEY_ID";

function showPoll(catalias, aId, divId, surveyId) {
    var vId = document.cookie;
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_getpoll_url2,//link service
        data: {categorysalias: catalias, articleid: aId, divId: divId, v:vId, surveyid: surveyId}, //du lieu gui len
        success: function(output){
            $('#'+divId).html(output);            
        }
    });
}

function validateSubmit(survey,divId) {
//if (document.forms.length>1)   var formSurvey =  document.getElementById(formId);
//else var formSurvey =  document.forms[0];
var formSurvey =  document.forms[0];
    for(var i = 0; i < formSurvey.itemId.length; i++) {
        if(formSurvey.itemId[i].checked) {
            submitPoll(survey,divId);
            return false;
        }
    }
    alert('Bạn hãy chọn 1 lựa chọn!');
    return false;
}

function submitPoll(survey,div) {
    
    var surveyId = $('#'+survey).val();  // document.getElementById(survey).value; 
    var divId =$('#'+div).val(); // document.getElementById(div).value;
    var form =  document.forms[0];
    items = [];
    for(var i = 0; i < form.itemId.length; i++) {
        if(form.itemId[i].checked) {
            items.push(form.itemId[i].value);
        }
    } 
    
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_postpoll_url,
        data: {pollId: surveyId, randId: Math.random(), itemId:items.join(',')},
        success: function(output){
            showPoll(null, null, divId, surveyId);
            //$('#message').jqm();$('#message').jqmShow();
        }
    });
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
