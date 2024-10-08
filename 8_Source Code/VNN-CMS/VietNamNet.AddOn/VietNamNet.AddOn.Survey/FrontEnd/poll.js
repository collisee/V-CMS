var service_getpoll_url="http://localhost/vnnSurvey/Services/ServicesSurveyGet.aspx?surveyid=POLL_ID";
var service_getpoll_url2="http://localhost/vnnSurvey/Services/ServicesSurveyGet2.aspx?surveyid=SURVEY_ID";
var service_postpoll_url="http://localhost/vnnSurvey/Services/ServicesSurveyPost.aspx";
var service_getpollresult_url="http://localhost/vnnSurvey/Services/ServicesSurveyResult.aspx?surveyid=POLL_ID";
var sampleItem = "<div>INPUT_TYPE ITEM_DESCRIPTION</div>";
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
 
function showPoll(pollId) {
    // Generate random div
    var randId = Math.random();
    document.write('<div id="'+randId+'"></div>'); 
    //document.getElementById(randId).innerHTML = '<div id="poll"> <div id="poll_show" style="display: block;"> <form id="poll_form" action="http://localhost/Services/ServicesSurveyPost.aspx" onsubmit="return validateSubmit(this)"> <input name="pollId" value="POLL_ID"  type="hidden"> <input name="randId" value="RAND_ID" type="hidden">  POLL_TITLE     <ul id="poll_show_items">             <li>INPUT_TYPE ITEM_DESCRIPTION</li>     </ul> VOTE_BUTTON  </form>   </div>  </div>';
     

    var PAGE_SUCCESS = 200;
    var requestObject = xmlHttpRequestHandler.createXmlHttpRequest();
            
    var divPoll = document.getElementById(randId).previousSibling;
    while(divPoll.id != "poll") {
            divPoll = divPoll.previousSibling;
    }
    
    var showPollUrl = service_getpoll_url;//findChildElementById(divPoll, "poll_data_url").value;
    showPollUrl = showPollUrl.replace("POLL_ID", pollId + '&cp=' + Math.random());
    requestObject.open("Get",showPollUrl,false);
    requestObject.send(null);
    
    if (requestObject.status===PAGE_SUCCESS){
            generatePollView(requestObject.responseXML, pollId, randId);
    }
    else {
            alert ("Request failed");
    }
}

function validateSubmit() {
var formpoll =  document.getElementById('poll_form');
    for(var i = 0; i < formpoll.itemId.length; i++) {
        if(formpoll.itemId[i].checked) {
            submitPoll(formpoll);
            return false;
        }
    }
    alert('Bạn hãy chọn 1 lựa chọn!');
    return false;
}

function submitPoll(form) {
    var PAGE_SUCCESS = 200;
    var requestObject = xmlHttpRequestHandler.createXmlHttpRequest();
    requestObject.open('POST', service_postpoll_url, false);
    requestObject.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
     
    var postData  = "pollId=" +  form.pollId.value + "&randId=" + form.randId.value;
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
            alert ("Cám ơn bạn đã Bình chọn!" );
            
                var showPollUrl = service_getpoll_url;//findChildElementById(divPoll, "poll_data_url").value;
                showPollUrl = showPollUrl.replace("POLL_ID", form.pollId.value + '&cp=' + form.randId.value);
                requestObject.open("Get",showPollUrl,false);
                requestObject.send(null);
                
                if (requestObject.status===PAGE_SUCCESS){
                        generatePollView(requestObject.responseXML, form.pollId.value , form.randId.value);
                }
            
            }
    }
    else {
        //alert ("Request failed");
    }
}
function generatePollView(pollData, pollId, randId) {
        var hasVoted = pollData.getElementsByTagName('HasVoted').item(0).childNodes.item(0).data;
        
     
        var title = pollData.getElementsByTagName('Title').item(0).childNodes.item(0).data;
        //var description = pollData.getElementsByTagName('description').item(0).childNodes.item(0).data;
        var rowType = pollData.getElementsByTagName('Type').item(0).childNodes.item(0).data;
        var rowSet = pollData.getElementsByTagName('Options').item(0);
        var rowNum = rowSet.getElementsByTagName('Option').length;
     
        // Raw data here
        var rowID = new Array(rowNum);
        var rowDesc = new Array(rowNum);
        // Raw data end
        
        for(var i = 0; i < rowNum; i++) {
            var row = rowSet.getElementsByTagName('Option').item(i);
            rowID[i] = row.getElementsByTagName('OptionId').item(0).childNodes.item(0).data;
            rowDesc[i] = row.getElementsByTagName('OptionName').item(0).childNodes.item(0).data;
        }
     
        // Write html to window
        var divPoll = document.getElementById(randId).previousSibling;
        while(divPoll.id != "poll") {
            divPoll = divPoll.previousSibling;
        }
         var pollShow = findChildElementById(divPoll, "poll_show");
            var html = pollShow.innerHTML;
            // Fill in data
            html= html.replace("POLL_TITLE", title);
            //html= html.replace("POLL_DESCRIPTION", description);
            html= html.replace(/POLL_ID/g, pollId);    
            html= html.replace(/RAND_ID/g, randId);
            pollShow.innerHTML = html;
            
            var pollVote = findChildElementById(divPoll, "poll_vote");html ="";
            if (hasVoted=="False" || hasVoted=="false" )  html="<input id='poll_set' value='Gửi ý kiến' class='button' type='button' onclick='return validateSubmit();'>"
            else  { html= "<a href='#' id='viewresult' >Xem kết quả</a>";//Check có pub kết quả không?  
                    if (window.XMLHttpRequest){// code for IE7+, Firefox, Chrome, Opera, Safari
                      xmlhttp=new XMLHttpRequest();
                    }else {// code for IE6, IE5
                        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
                    }
                    
                    xmlhttp.onreadystatechange=function()
                      {
                      if (xmlhttp.readyState==4 && xmlhttp.status==200){
                        document.getElementById("dialogResult").innerHTML=xmlhttp.responseText;
                        }
                      }
                    xmlhttp.open("GET",service_getpollresult_url.replace("POLL_ID", pollId),true);
                    xmlhttp.send(); 
            } 
            pollVote.innerHTML = html;         
     
            // Render poll items
            var pollShowItems = findChildElementById(pollShow, "poll_show_items");            
            pollShowItems.innerHTML = "";
            
            // Insert new rows    
            for(var i = 0; i < rowNum; i++) {
              var newItem = sampleItem;
              var inputHTML = "";
           
                   if(rowType === "C")  {
                            inputHTML = "<label><input type=\"checkbox\" id=\"input_"+rowID[i]+"\" name=\"itemId\" value=\""+rowID[i]+"\">";
                   } else {
                            inputHTML = "<label><input type=\"radio\" id=\"input_"+rowID[i]+"\" name=\"itemId\" value=\""+rowID[i]+"\">";  
                   }
                   if (i== rowNum - 1){
                     newItem = newItem + "";
                     newItem = newItem.replace("ITEM_DESCRIPTION", ""+rowDesc[i]+"</label>");
                   } else {
                          newItem = newItem.replace("ITEM_DESCRIPTION", ""+rowDesc[i]+"</label>");
		           }
                   
                   newItem = newItem.replace("INPUT_TYPE", inputHTML);
                   pollShowItems.innerHTML += newItem;   
             } // end for Insert new rows 
             
             
             
        }     
 

function findChildElementById(parentNode, id) {
    for(var i = 0; i < parentNode.childNodes.length; i++) {
        if(parentNode.childNodes[i].id == id)
            return parentNode.childNodes[i];
        else {
            var n = findChildElementById(parentNode.childNodes[i], id);
            if(n)
                return n;
        }
    }
    return;
}
 
 
function showPoll(surveyId) {
    // Generate random div
    var randId = Math.random();
    document.write('<div id="'+randId+'"></div>'); 
    
    if (window.XMLHttpRequest){// code for IE7+, Firefox, Chrome, Opera, Safari
      xmlhttp=new XMLHttpRequest();
    }else {// code for IE6, IE5
        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    
    xmlhttp.onreadystatechange=function()
      {
      if (xmlhttp.readyState==4 && xmlhttp.status==200){
        document.getElementById(randId).innerHTML=xmlhttp.responseText;
        }
      }
    xmlhttp.open("GET",service_getpoll_url2.replace("SURVEY_ID", surveyId),true);
    xmlhttp.send(); 
}