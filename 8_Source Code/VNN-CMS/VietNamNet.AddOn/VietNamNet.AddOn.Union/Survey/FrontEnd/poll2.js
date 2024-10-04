var service_getpoll_url2="http://localhost/vnnSurvey/Services/ServicesSurveyGet2.aspx?surveyid=SURVEY_ID";
var service_postpoll_url="http://localhost/vnnSurvey/Services/ServicesSurveyPost.aspx";
var service_getpollresult_url="http://localhost/vnnSurvey/Services/ServicesSurveyResult.aspx?surveyid=POLL_ID";
var xmlHttpRequestHandler = new Object();
xmlHttpRequestHandler.createXmlHttpRequest = function(){

  var XmlHttpRequestObject;
  if (typeof XMLHttpRequest != "undefined"){
   XmlHttpRequestObject = new XMLHttpRequest();
  }
  else if (window.ActiveXObject){
   // look up the highest possible MSXML version
   var tryPossibleVersions=["MSXML2.XMLHttp.5.0",
                          "MSXML2.XMLHttp.4.0",
                          "MSXML2.XMLHttp.3.0",
                          "MSXML2.XMLHttp",
                          "Microsoft.XMLHttp"];

  for (i=0; i< tryPossibleVersions.length; i++){
   try{
      XmlHttpRequestObject = new ActiveXObject(tryPossibleVersions[i]);
      break;
   }
   catch (xmlHttpRequestObjectError){
      //ignore
   }
  }
 }
 return XmlHttpRequestObject;
}
 
function showPoll(surveyId, divId) {
    var randId = Math.random(); 
    //document.write('<div id="'+randId+'">'+randId+'</div>'); 
    
      var requestObject = xmlHttpRequestHandler.createXmlHttpRequest();
    requestObject.onreadystatechange=function()
      {
      if (requestObject.readyState==4 && requestObject.status==200){
        document.getElementById(divId).innerHTML=requestObject.responseText;
        }
      }
    requestObject.open("GET",service_getpoll_url2.replace("SURVEY_ID", surveyId + "&divId=" + divId),true);
    requestObject.send(); 
}

function validateSubmit(formId) {
if (document.forms.length>1)   var formSurvey =  document.getElementById(formId);
else var formSurvey =  document.forms[0];
    for(var i = 0; i < formSurvey.itemId.length; i++) {
        if(formSurvey.itemId[i].checked) {
            submitPoll(formSurvey);
            return false;
        }
    }
    alert('Bạn hãy chọn 1 lựa chọn!');
    return false;
alert(document.forms.length);
}

function submitPoll(form) {
    var PAGE_SUCCESS = 200;
    var requestObject = xmlHttpRequestHandler.createXmlHttpRequest();
    requestObject.open('POST', service_postpoll_url, false);
    requestObject.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    var surveyId =form.surveyId.value; var divId =  form.divId.value;
    var postData  = "pollId=" +  form.surveyId.value + "&randId=" + form.randId.value;
    for(var i = 0; i < form.itemId.length; i++) {
        if(form.itemId[i].checked) {
            postData += "&itemId="+form.itemId[i].value;
        }
    }
    //alert(postData);
    
    requestObject.send(postData);
    
    if (requestObject.status===PAGE_SUCCESS){
        // generatePollView(requestObject.responseXML, form.pollId.value,  form.randId.value);
        var status = requestObject.responseXML.getElementsByTagName('Status').item(0).childNodes.item(0).data;
        if (status=='True'){
            showPoll(surveyId,divId);
            alert ("Cám ơn bạn đã Bình chọn!" );
            }
    }
    else {
        //alert ("Request failed");
    }
}


