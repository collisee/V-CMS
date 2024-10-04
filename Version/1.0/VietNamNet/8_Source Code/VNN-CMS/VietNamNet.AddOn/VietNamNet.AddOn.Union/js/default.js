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
function sendEmail(){ 
    //valid
    if ($('#smName').val()=='') {alert('Bạn hãy nhập Họ tên!'); $('#smName').focus();  return;}
    if (checkemail($('#smEmailFrom').val())==false || 
        checkemail($('#smEmailTo').val())==false ) 
            {alert('Bạn hãy nhập email đúng định dạng!'); $('#smEmailFrom').focus();return;}

    var service_send_url="/ajax/sendMail/s.html";
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_send_url,
        data: {name: $('#smName').val(), emailFrom: $('#smEmailFrom').val(), emailto:$('#smEmailTo').val(), message: $('#smMessage').val(), 
               cat: $('#hidCategoryAlias').val(), aid: $('#hidMessageId').val(), subject: $('#hidMessageSubject').val() },
        success: function(output){
          //  alert(output);
        } 
    });
    
    $('#digSendEmail').jqmHide(); return;
}

function checkemail(emailinput){
    var testresults 
    var filter=/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i
    if (filter.test(emailinput))
        testresults=true
    else{
        testresults=false
    }
    return (testresults)
}