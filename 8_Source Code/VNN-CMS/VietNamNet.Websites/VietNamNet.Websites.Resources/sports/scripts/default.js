VietNamNet.Framework.JS.Initialization.add(VietNamNet.Framework.JS.PopupLead.init); 

 function createBookmark() {

 title = "Báo điện tử Vietnamnet";  
 url = "thethao.vietnamnet.vn"; 

	if (window.sidebar) { // Mozilla Firefox Bookmark
		window.sidebar.addPanel(title, url,"");
	} else if( window.external ) { // IE Favorite
		window.external.AddFavorite(url,title)}		
	else if(window.opera && window.print) { // Opera Hotlist
		return true; 
	} 
 } 
 
/* sharing */
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
/* searcn*/
function search(){ 
    var keyword='';
    
    if ($('input.input-search').val()!='' && $('input.input-search').val()!='Search..') keyword=$('input.input-search').val();
    if (keyword=='' && $('input.input-search2').val()!='' && $('input.input-search2').val()!='Search..') keyword=$('input.input-search2').val();
    if (keyword=='') keyword=$('#skeywords').val();
   
      window.location = "/vn/tim-kiem/index.html?&keyword="+keyword; 
};

function search2(){ 
    
 var keyword=''; var date=''; var cat=''; 
  var form =  document.forms[0];
 
  if (form.skeywords!=null && form.skeywords.value !='') keyword=form.skeywords.value;
  if (form.scat!=null && form.scat[form.scat.selectedIndex].value !='') cat=form.scat[form.scat.selectedIndex].value;
  if (form.dday!=null && form.dmonth!=null && form.dyear!=null &&
      form.dday[form.dday.selectedIndex].value!='' && form.dmonth[form.dmonth.selectedIndex].value!='' && form.dyear[form.dyear.selectedIndex].value!='' ) 
            date=""+ form.dyear[form.dyear.selectedIndex].value + form.dmonth[form.dmonth.selectedIndex].value + form.dday[form.dday.selectedIndex].value ;
            
    window.location = "/vn/tim-kiem/index.html?cat="+cat+"&d="+date+"&keyword="+keyword;  
};

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
};

function disableEnter(evt)
 {
     var charCode = (evt.which) ? evt.which : event.keyCode 
     if ( charCode == 13) {
        return false 
     }
 } ;
 /* send mail*/
 

 
function sendEmail(){  
    if ($('#smName').val()=='') {alert('Bạn hãy vui lòng nhập tên!'); $('#smName').focus();  return;}
    if (checkemail($('#smEmailFrom').val())==false || 
        checkemail($('#smEmailTo').val())==false ) 
            {alert('Email sai định dạng! Bạn hãy vui lòng nhập Email!'); $('#smEmailFrom').focus();return;}

    var service_send_url="/ajax/sendMail/s.html";
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_send_url,
        data: {name: $('#smName').val(), emailFrom: $('#smEmailFrom').val(), emailto:$('#smEmailTo').val(), message: $('#smMessage').val(), 
               cat: $('#hidCategoryAlias').val(), aid: $('#hidMessageId').val(), subject: $('#hidMessageSubject').val() },
        success: function(output){
          $('#smEmailTo').val('');
          $('#smMessage').val('');
          $('#digSendEmail ' +' .mess').html('Email đã được gửi. Cám ơn bạn đã chia sẻ bài viết này!');
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

function sendEmail_init(){ 
    if ( $('#digSendEmail').length>0 && $('a.mail').length>0   )
         $('#digSendEmail').jqm({trigger: 'a.mail'});
}
VietNamNet.Framework.JS.Initialization.add(sendEmail_init); 


/* rss */
function rss_MyYahoo(rssUrl){
     window.location = 'http://pa.yahoo.com/*http://us.rd.yahoo.com/evt=32777/*http://add.my.yahoo.com/rss?url='+rssUrl;return false;
}
function rss_GoogleReader(rssUrl){
     window.location = 'http://fusion.google.com/add?source=atgs&feedurl='+rssUrl;return false;
}

/* make home page */
function setHomepage()
{
 if (document.all)
    {
        document.body.style.behavior='url(#default#homepage)';
        document.body.setHomePage('http://thethao.vietnamnet.vn');
 
    }
    else if (window.sidebar)
    {
    if(window.netscape)
    {
         try
         {  
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");  
         }  
         catch(e)  
         {  
            alert("this action was aviod by your browser，if you want to enable，please enter about:config in your address line,and change the value of signed.applets.codebase_principal_support to true");  
         }
    } 
    var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components. interfaces.nsIPrefBranch);
    prefs.setCharPref('browser.startup.homepage','thethao.vietnamnet.vn');
 }
}

