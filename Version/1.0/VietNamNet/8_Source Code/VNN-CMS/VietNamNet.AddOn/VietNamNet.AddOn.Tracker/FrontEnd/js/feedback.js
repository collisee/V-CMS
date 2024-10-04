var service_post_url='http://tracking.english.vietnamnet.vn/tracking/t.srv?'
+'sn=comment&dm=demo.vietnamnet.vn&us=me&vs=1'
+'&n=[NAME]&m=[MESSAGE]&s=[SUBJECT]&p=[PHONE]&em=[EMAIL]&v=[VALIDCODE]&aid=[ARTICLE]';


//http://localhost:3988/tracking/t.srv?sn=comment&dm=demo.english.vietnamnet.vn&us=me&vs=1&n=DoNamSon&m=TestComment_Messafe&s=TestCommentSub&p=0975818370&em=dnson@vietnamnet.vn&v=abdfgadg&aid=144
function postComment(){
    var cName = $('#newcomment .name').val();if( cName.length<=2||cName=='Họ và tên *'){$('#newcomment .mess').html('Bạn hãy nhập Họ tên!');$('#newcomment .name').focus();return false};
    var cEmail = $('#newcomment .email').val();if(checkemail(cEmail)!=true){$('#newcomment .mess').html('Sai định dạng Email. Bạn hãy email!');$('#newcomment .email').focus();return false};
    var cPhone = $('#newcomment .phone').val();if(checkphone(cPhone)!=true){$('#newcomment .mess').html('Sai định dạng số điện thoại. Bạn hãy nhập số điện thoại!');$('#newcomment .phone').focus();return false};
    var cSubject = $('#newcomment .subject').val();if( cSubject.length<=2||cSubject=='Tiêu đề'){$('#newcomment .mess').html('Bạn hãy nhập Tiêu đề!'); $('#newcomment .subject').focus();return false;};
    var cMessage = $('#newcomment .message').val();if( cMessage.length<=5 || cMessage.length>1000 ||cMessage=='Message'){$('#newcomment .mess').html('Bạn hãy nhập nội dung phản hồi!'); $('#newcomment .message').focus();return false;};
    var cAid = $('#newcomment .aid').val();
    var cValidCode = $('#newcomment .validcode').val();
    
    //linkPost='';
    $("#newcomment #cmdPostComment").attr({ 
          src: service_post_url.replace("[NAME]",cName).replace("[SUBJECT]",cSubject).replace("[PHONE]",cPhone)
                                .replace("[EMAIL]",cEmail).replace("[MESSAGE]",cMessage)
                                .replace("[ARTICLE]",cAid),
          title: "post" 
        });
     
    $("#newcomment #cmdPostComment").attr({src:service_post_url.replace("[NAME]",cName)
                                                                .replace("[SUBJECT]",cSubject).replace("[PHONE]",cPhone).replace("[EMAIL]",cEmail)
                                                                .replace("[MESSAGE]",cMessage) .replace("[ARTICLE]",cAid),
                                           title:"post"});

$('#newcomment .mess').html('Cám ơn bạn đã phản hồi!');
    
    //$('#newcomment .name').attr('value','');
    $('#newcomment .subject').val('').blur();
    //$('#newcomment .phone').attr('value','');
    //$('#newcomment .mail').attr('value','');
    $('#newcomment .message').val('').blur();
    $('#newcomment .validcode').val('').attr('value','');
}
    
function resetComment(){    
    $('#newcomment .name').val('').blur();
   
    $('#newcomment .phone').val('').blur();
    $('#newcomment .mail').val('').blur();
    $('#newcomment .subject').val('').blur();
    $('#newcomment .message').val('').blur();
    $('#newcomment .validcode').val('').blur();
}


 /*show form fb*/
 $(document).ready(function(){
    $("#article-feedback .article-freedback-form").hide();//.toggleClass('none');
	  
	  var blnFlag = false;
	  
	  $('#article-feedback .article-freedback-title span').click(function(){	  
	      $('#article-feedback .article-freedback-title').toggleClass('article-freedback-title2');
	      //$('#article-feedback .article-freedback-form').toggleClass('none');
	      if (blnFlag){
	        blnFlag = false;
	      $('#article-feedback .article-freedback-form').slideUp('slow');
	      }else{
	        blnFlag = true;
	      $('#article-feedback .article-freedback-form').slideDown('slow');
	      }
	    })
 	  });

var service_get_url="/ajax/getComment/get.html";
var tempComment=' '+
    '<div id="feedback-title" class="home-article-comment-box" >'+
        '<div id="feedback-sort"></div>'+
        '<div class="fb_title"><h2>Ý kiến bạn đọc</h2></div>'+
        '<div class="clear">,</div>'+
    '</div>'+
    '<div  id="feedback-list" class="list"></div>'+
    '<div id="paging" class="pagy cm-page">'+
        '&nbsp; <a href="javascript:void(0)" class="paging-prev">Trang trước</a> '+
        '&nbsp; <a href="javascript:void(0)" class="paging-next">Trang sau</a> '+
    '<br class="clear" />'+'</div>';
var tempCommentItem='<div class="feedback-item">'+
    '<div class="comment"><i>{Subject}</i><br>{Detail}</div>'+
    '<div class="profile">{Name}, gửi lúc {CreatedDate} </div>'+'</div>';

                    
var CurrentPageIndex = 1;
function bindComment(obj, b, divId) { 
   if(obj) {
      $('#' + divId).html(tempComment);
      var d = new VietNamNet.Framework.JS.Template( {
         id : 'tmpComment', template : tempCommentItem}
      );
      VietNamNet.Framework.JS.TemplateManager.bind($('#' + divId + ' .list'), obj, d);
      $('#' + divId + ' .paging-next').show();
      $('#' + divId + ' .paging-next').click(function() {
         CurrentPageIndex++; showComment(b, CurrentPageIndex, divId)}
      ); 
      
      if(!CurrentPageIndex || CurrentPageIndex <= 1) {
         $('#' + divId + ' .paging-prev').hide()}
      else {
         
         $('#' + divId + ' .paging-prev').show();
         $('#' + divId + ' .paging-prev').click(function() {
            CurrentPageIndex--; 
            showComment(b, CurrentPageIndex, divId)}
         )}
      }
   else {
      $('#' + divId + ' .paging-next').hide()}
   }
function prevComment() {
   pageIndex--;
   initComment()}
function nextComment() {
   pageIndex++;
   initComment()}
function showComment(d, e, f) {
   VietNamNet.Framework.JS.AjaxManager.add( {
      url : service_get_url, data : {
         m : d, index : e}
      , success : function(a) {
         var b = ''; 
         if(a && a != '""' && a != 'null') {
            b = a.trim()}
         else {
            if (e  > 1) $('#' + f + ' .paging-next').hide(); 
            else $('#' + f).hide();
            return}; 

         var c = VietNamNet.Framework.JS.JSON.decode(b); 
         if(c) {
            bindComment(c, d, f)}
         else {
            $('#' + f + ' .paging-next').hide()}
         }
      , error : function() {
         $('#' + f + ' .paging-prev').hide(); $('#' + f + ' .paging-next').hide()}
      }
   );
   return false};


function initComment(){$('div[comment=true]').each(function(a){showComment($(this).attr('articleId'),0,this.id)})}

VietNamNet.Framework.JS.Initialization.add(initComment);