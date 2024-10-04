VietNamNet.Framework.JS.Initialization.add(VietNamNet.Framework.JS.PopupLead.init); 

function share_facebook()
{
	var	u=location.href;
	var t=document.title;
	var t1=	$('article-title').innerHTML;
	window.open("http://www.facebook.com/share.php?u="+encodeURIComponent(u)+"&t="+encodeURIComponent(t1));

}

function share_twitter()
{
	var	uvnn=location.href;
	var tvnn=document.title;
	window.open("http://twitter.com/home?status=" + encodeURIComponent(uvnn));
}
/* search*/
function search(){ 
    var keyword='';
    
    if ($('input.input-search').val()!='' && $('input.input-search').val()!='Search..') keyword=$('input.input-search').val();
    if (keyword=='' && $('input.input-search2').val()!='' && $('input.input-search2').val()!='Search..') keyword=$('input.input-search2').val();
    
    if (keyword=='' && keyword=='Search..' && $('#skeywords').val()!='') keyword=$('#skeywords').val();
   if (keyword=='' && keyword=='Search..' && $('#search_box .keyword').val()!='') keyword=$('#search_box .keyword').val();
   
   if (keyword!=null && keyword!=''){ 
       window.location = "/vn/tim-kiem/index.html?&keyword="+keyword; 
      }
}

function search2(){ 
    
 var keyword=''; var date=''; var cat=''; 
 var searchbox=$('#search_box');
 
  var form =  document.forms[0];
 
  if ($(' .keyword',searchbox)!=null && $(' .keyword',searchbox) !='') keyword=$(' .keyword',searchbox).val();
  if ($(' .categories',searchbox)!=null && $(' .categories',searchbox).val() !='') cat=$(' .categories',searchbox).val();
  if ($(' .dday',searchbox)!=null && $(' .dmonth',searchbox)!=null && $(' .dyear',searchbox)!=null &&
      $(' .dday',searchbox).val()!='' && $(' .dmonth',searchbox).val()!='' && $(' .dyear',searchbox).val()!='' ) 
            date=""+ $(' .dyear',searchbox).val() + $(' .dyear',searchbox).val() + $(' .dyear',searchbox).val() ;
            
    window.location = "/vn/tim-kiem/index.html?cat="+cat+"&d="+date+"&keyword="+keyword;  
}

function searchkey(evt,obj){ 
var e=(window.event)?window.event:evt;
    var mykey=e.keyCode;
    if(mykey==13)
    {
        if ((obj.value!=''  && obj.value!='Search..'  ))
        { search();  } else { search2();}
        
        if(e.preventDefault)e.preventDefault()
        else e.returnValue=false;
    }   
}

function disableEnter(evt)
 {
     var charCode = (evt.which) ? evt.which : event.keyCode 
     if ( charCode == 13) {
        return false 
     }
 } 
 
 /* send mail*/
 $(document).ready(function(){$('#digSendEmail').jqm({trigger: '#cmdSendEmail'}); });
 
function sendEmail(){  
var mess=$('#digSendEmail ' +' .mess');mess.removeClass("warning");
    if ($('#smName').val()=='') {mess.html('Bạn hãy vui lòng nhập tên!'); $('#smName').focus(); mess.toggleClass("warning"); return;}
    if (checkemail($('#smEmailFrom').val())==false || 
        checkemail($('#smEmailTo').val())==false ) 
            {mess.html('Email sai định dạng! Bạn hãy vui lòng nhập đúng Email!'); $('#smEmailFrom').focus();mess.toggleClass("warning"); return;}

    var service_send_url="/ajax/sendMail/s.html";
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_send_url,
        data: {name: $('#smName').val(), emailFrom: $('#smEmailFrom').val(), emailto:$('#smEmailTo').val(), message: $('#smMessage').val(), 
               cat: $('#hidCategoryAlias').val(), aid: $('#hidMessageId').val(), subject: $('#hidMessageSubject').val() },
        success: function(output){
          $('#smEmailTo').val('');
          $('#smMessage').val('');  
          mess.html('Email đã được gửi. Cám ơn bạn đã chia sẻ bài viết này!');
        } 
    });
    
    //$('#digSendEmail').jqmHide(); 
    return;
}

function checkemail(emailinput){
    var testresults ;
    var filter=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    if (filter.test(emailinput))
        testresults=true;
    else{
        testresults=false;
    }
    return (testresults);
}
function checkphone(phoneinput){
    var filter = /^[0-9]{7,15}$/;
    return filter.test(phoneinput); //return true or false 
return true;
}

/* rss */
function rss_MyYahoo(rssUrl){
     window.location = 'http://pa.yahoo.com/*http://us.rd.yahoo.com/evt=32777/*http://add.my.yahoo.com/rss?url='+rssUrl;return false;
}
function rss_GoogleReader(rssUrl){
     window.location = 'http://fusion.google.com/add?source=atgs&feedurl='+rssUrl;return false;
}
