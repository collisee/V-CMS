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

/* searcn*/
function search(){ 
    var keyword='';
    
    if ($('input.input-search').val()!='' && $('input.input-search').val()!='Search..') keyword=$('input.input-search').val();
    if (keyword=='' && $('input.input-search2').val()!='' && $('input.input-search2').val()!='Search..') keyword=$('input.input-search2').val();
    if (keyword=='') keyword=$('#skeywords').val();
      window.location = "/vn/tim-kiem/index.html?&keyword="+keyword;  
}

function search2(){ 
    
 var keyword=''; var date=''; var cat=''; 
  var form =  document.forms[0];
 
  if (form.skeywords!=null && form.skeywords.value !='') keyword=form.skeywords.value;
  if (form.scat!=null && form.scat[form.scat.selectedIndex].value !='') cat=form.scat[form.scat.selectedIndex].value;
  if (form.dday!=null && form.dmonth!=null && form.dyear!=null &&
      form.dday[form.dday.selectedIndex].value!='' && form.dmonth[form.dmonth.selectedIndex].value!='' && form.dyear[form.dyear.selectedIndex].value!='' ) 
            date=""+ form.dyear[form.dyear.selectedIndex].value + form.dmonth[form.dmonth.selectedIndex].value + form.dday[form.dday.selectedIndex].value ;
            
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
 
/* send email */ 
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

function sendmail_getVideoInfo(articleId, catUrl,subject){
    
}

/*bookmark trang chu*/
function make_home_page(obj) {
    var url = "http://vietnamnet.vn";
    if (ie) {
        obj.style.behavior = "url(#default#homepage)";
        obj.setHomePage(url);
    } else if (firefox) {
        window.sidebar.addPanel("VietNamNet", url, "");
    }
    return false;
}