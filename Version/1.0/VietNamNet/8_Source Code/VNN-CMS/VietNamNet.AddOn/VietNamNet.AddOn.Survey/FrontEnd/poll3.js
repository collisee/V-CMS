var srvSurvey_url="/ajax/Survey/get/g.html";
//var srvSurvey_posturl="/ajax/Survey/post/p.html";
var srvSurvey_posturl="/tracking/p.html";

var tempOptionC = '<div class=\"vote_item\"><label><input type=\"checkbox\" id=\"itemId\" name=\"itemId\" value=\"{SurveyOptionId}\"> {OptionName}</label></div>';
var tempOptionR = "<div class=\"vote_item\"><label><input type=\"radio\" id=\"itemId\" name=\"itemId\" value=\"{SurveyOptionId}\"> {OptionName}</label></div>";
var tempButton = '<a href=\"#\" id=\"LINK_ID\"  onclick=\"LINK_EVENT\" class="action"></a>';
var tempDialog = '<div id=\"dias{SurveyId}\" class=\"jqmWindow diaResult\">Bạn hãy chờ giây lát... <img alt=\"loading\" src=\"/Images/busy.gif\"></div>';

var temp='<div class=\"vote_most\"> ' +
    		'<div class=\"vote_most_title\">Thăm dò ý kiến</div>' +
				' <div class=\"vote_most_list\"> ' +
					'<div class=\"vote_question\"> {Question} </div>'+
					'<div class=\"vote_most_item options_{SurveyId}\"></div>' +
					'<div class=\"vote_respost\"><a href=\"#\" id=\"action_{SurveyId}\" class="action"  > </a></div>' +
				' </div>' +
'</div>';
var tempResult="<div class=\"vote_most\"> " +
    		"<div class=\"vote_most_title\">Kết quả Bình chọn</div>" +
				" <div class=\"vote_most_list\"> " +
					"<div class=\"vote_question\"> {Question} </div>" +
					"<div class=\"vote_most_item survey result_{SurveyId}\"></div>" +
					"<div class=\"vote_respost\"><a href=\"#\" id=\"action_{SurveyId}\"  > </a> </div>" +
				" </div>" +
 "</div><a href=\"#\" class=\"jqmClose\"></a>";
 var tempResultDetail=" <div class=\"vote_item1 sitem\">"+
            "<div style=\"width: 55%; \">"+
                "<label class=\"label\">{OptionName}</label>"+
            "</div>"+
            "<div style=\"width: 25%; \">"+
                  "<div class=\"result\" style=\"width:{ResultPercent}\"></div>"+
            "</div>"+
            "<div style=\"width: 10%; text-align:right; \">{ResultPercent}</div>"+
            "<div style=\"width: 10%; text-align:right; \">{Result}/SumResult</div>"+
        "</div>";
 
function showResult(obj, divId)
{
    if (obj){    
        var tmpR = new VietNamNet.Framework.JS.Template({
                        id: 'tmpR',
                        template: tempResult
                    });
        VietNamNet.Framework.JS.TemplateManager.bind($('#'+divId +' .diaResult'), obj, tmpR);
        
        var tmpD = new VietNamNet.Framework.JS.Template({
                        id: 'tmpD',
                        template: tempResultDetail.replace(/SumResult/gi,obj.SumResult)
                    });
        VietNamNet.Framework.JS.TemplateManager.bind($('.result_'+obj.SurveyId,$('#'+divId +' .diaResult')), obj.SurveyOption, tmpD);
        
    }
}

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
          
          if (obj.HasVoted==false){ // chưa vote thì Bình chọn            
             $('#'+divId + ' .action').text("Bình chọn");
             $('#'+divId + ' .action').click(function (){return validateSubmit(obj.SurveyId,divId)});
          }
          else{ // nếu đã vote 
            $('#'+divId + ' input ' ) .attr("disabled","disabled");
            $('#'+divId + ' .action').text("Xem kết quả");
            $('#'+divId + ' .action').unbind('click');
            showResult(obj, divId);
            $('#'+divId +' .diaResult ').jqm({trigger: '#'+divId + ' .action'});
          }
    }
}
 

function validateSubmit(survey,divId) {
    var d = $('#'+divId)
    //if ($('#'+ 'poll' + ' :input[checked=true]').length >0) {
    if ($('#'+ divId + ' :input[checked=true]').length >0) {
        //alert('ye');
          submitPoll(survey,divId);
          return false;}
    
    alert('Bạn hãy chọn 1 lựa chọn!');
        return false;
    }

function submitPoll(survey,div) {
    var surveyId = survey;  // document.getElementById(survey).value; 
    var divId =div; // document.getElementById(div).value;
    items = [];
    var f= $('#'+ divId + ' :input[checked=true]');
    for(var i = 0; i <f.length; i++) {
            items.push(f[i].value);
    }      
            
    VietNamNet.Framework.JS.AjaxManager.add({
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
    });
}

function showSurvey(divId, catalias, aId,  surveyId) { 
    VietNamNet.Framework.JS.AjaxManager.add({
        url: srvSurvey_url,//link service
        data: {categorysalias: catalias, articleid: aId, divId: divId,  surveyid: surveyId}, //du lieu gui len
        success: function(output){
            var obj = VietNamNet.Framework.JS.JSON.decode(output); 
            bind(obj,divId);            
        }
    });
}

























function showAllSurveyBySurvey(){
    $('div[survey=true]').each(function(index){
        //this.id
        //alert($(this).attr('surveyId'));
        showSurvey(this.id,'','', $(this).attr('surveyId'))
    })
}

function showAllSurveyByArticle(){
    $('div[survey=true]').each(function(index){
        //this.id
        //alert($(this).attr('surveyId'));
        showSurvey(this.id,'',$(this).attr('articleId'),'')
    })
}

function showAllSurveyByCat(){
    $('div[survey=true]').each(function(index){
        //this.id
        //alert($(this).attr('surveyId'));
        showSurvey(this.id,$(this).attr('categoryalias'),'','')
    })
}
 
function showAllSurvey(){
     $('div[survey=true]').each(function(index){
        showSurvey(this.id,$(this).attr('categoryalias'),$(this).attr('articleId'),$(this).attr('surveyId'))
    })
}

VietNamNet.Framework.JS.Initialization.add(showAllSurvey);
