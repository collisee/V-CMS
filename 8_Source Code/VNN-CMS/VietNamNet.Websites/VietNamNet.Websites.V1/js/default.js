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
    var form =  document.forms[0];
  var keyword=form.keywords.value;
  if (keyword!='')   window.location = "/vn/tim-kiem/"+keyword+"/index.html";
}
function search2(){ 
  var form =  document.forms[0];
  var keyword=''; var date=''; var cat='';  
  if (form.skeywords!=null && form.skeywords.value !='') keyword=form.skeywords.value;
  if (form.scat!=null && form.scat[form.scat.selectedIndex].value !='') cat=form.scat[form.scat.selectedIndex].value;
  if (form.dday!=null && form.dmonth!=null && form.dyear!=null &&
      form.dday[form.dday.selectedIndex].value!='' && form.dmonth[form.dmonth.selectedIndex].value!='' && form.dyear[form.dyear.selectedIndex].value!='' ) 
            date=""+ form.dyear[form.dyear.selectedIndex].value + form.dmonth[form.dmonth.selectedIndex].value + form.dday[form.dday.selectedIndex].value ;
            
  if (keyword!='')   window.location = "/vn/tim-kiem/"+keyword+"/index.html?cat="+cat+"&d="+date; 
}


function disableEnter(evt)
 {
     var charCode = (evt.which) ? evt.which : event.keyCode 
     if ( charCode == 13) {
        return false 
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



/* make home page */
function setHomepage()
{
 if (document.all)
    {
        document.body.style.behavior='url(#default#homepage)';
        document.body.setHomePage('http://vietnamnet.vn');
 
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