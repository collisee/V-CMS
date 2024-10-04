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

function search(){ 
    var keyword='';
    if ($('input.input-search').val()!='') keyword=$('input.input-search').val();
    if (keyword=='') keyword=$('#skeywords').val();
      window.location = "/en/search/index.html?&keyword="+keyword;  
}
function search2(){ 
    
 var keyword=''; var date=''; var cat=''; 
  var form =  document.forms[0];
 
  if (form.skeywords!=null && form.skeywords.value !='') keyword=form.skeywords.value;
  if (form.scat!=null && form.scat[form.scat.selectedIndex].value !='') cat=form.scat[form.scat.selectedIndex].value;
  if (form.dday!=null && form.dmonth!=null && form.dyear!=null &&
      form.dday[form.dday.selectedIndex].value!='' && form.dmonth[form.dmonth.selectedIndex].value!='' && form.dyear[form.dyear.selectedIndex].value!='' ) 
            date=""+ form.dyear[form.dyear.selectedIndex].value + form.dmonth[form.dmonth.selectedIndex].value + form.dday[form.dday.selectedIndex].value ;
            
    window.location = "/en/search/index.html?cat="+cat+"&d="+date+"&keyword="+keyword;  
}
function searchkey(evt){ 
var e=(window.event)?window.event:evt;
    var mykey=e.keyCode;
    if(mykey==13)
    {
        if ($('input.input-search').val()!='' && $('input.input-search').val()!='Search..')
        { search();  } else { search2();}
        
        if(e.preventDefault)e.preventDefault()
        else e.returnValue=false;
    }

}


function disableEnter(evt)
 {
     var charCode = (evt.which) ? evt.which : event.keyCode;
     if ( charCode == 13) {
        return false ;
     }
 } 
 /* send mail*/
function sendEmail(){  
    if ($('#smName').val()=='') {alert('Please input your name!'); $('#smName').focus();  return;}
    if (checkemail($('#smEmailFrom').val())==false || 
        checkemail($('#smEmailTo').val())==false ) 
            {alert('Invalid email! Please check your input email!'); $('#smEmailFrom').focus();return;}

    var service_send_url="/ajax/sendMail/s.html";
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_send_url,
        data: {name: $('#smName').val(), emailFrom: $('#smEmailFrom').val(), emailto:$('#smEmailTo').val(), message: $('#smMessage').val(), 
               cat: $('#hidCategoryAlias').val(), aid: $('#hidMessageId').val(), subject: $('#hidMessageSubject').val() },
        success: function(output){
          $('#smEmailTo').val('');
          $('#smMessage').val('');
        } 
    });
    
    $('#digSendEmail').jqmHide(); return;
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
//    var filter = /^\(?([0-9]{3\4})+\)?[\-\s]?([0-9]{3})+[\-\s]?([0-9]{4})+$/;
//    return filter.test(phoneinput); //return true or false 
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

/*bookmark trang chu*/
function make_home_page(obj) {
    var url = "http://english.vietnamnet.vn";
    if (ie) {
        obj.style.behavior = "url(#default#homepage)";
        obj.setHomePage(url);
    } else if (firefox) {
        window.sidebar.addPanel("VietNamNet", url, "");
    }
    return false;
}