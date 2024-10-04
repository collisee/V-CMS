var service_post_url="/ajax/postComment/p.html";
var service_get_url="/ajax/getComment/get.html";
  
function postFeedback(){ 
//    //valid
//    if ($('#smName').val()=='') {alert('Bạn hãy nhập Họ tên!'); $('#smName').focus();  return;}
//    if (checkemail($('#smEmailFrom').val())==false || 
//        checkemail($('#smEmailTo').val())==false ) 
//            {alert('Bạn hãy nhập email đúng định dạng!'); $('#smEmailFrom').focus();return;}

    
    VietNamNet.Framework.JS.AjaxManager.add({
        url: service_post_url,
        data: {Name: $('#txtName').val(), Email: $('#txtName').val(), Add: $('#txtName').val(),
               Content: $('#txtName').val(), x: ""},
        success: function(output){
          //  alert(output);
          // if output=ok do...
              // show cam on
          // if output=false do...
          
        } 
    });
     
}



 	  
 	  
 	  
 	  
