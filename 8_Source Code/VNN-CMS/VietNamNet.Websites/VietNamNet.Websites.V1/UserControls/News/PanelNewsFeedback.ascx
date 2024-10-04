<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsFeedback.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.News.PanelNewsFeedback" %>

 

<div id="newcomment" class="commentbox_new">
	<div id="commentbox_new_top" class="commentbox_new_head_1">
	    <a class="commentbox_new_but_open_1" id="commentbox_new_but_open" href="#">Ý kiến của bạn</a>
	    <div class="commentbox_new_button">
			<a href="#TB_inline?height=400&width=300&inlineId=digSendEmail_hidden" class="commentbox_new_button_mail thickbox" title="Gửi cho bạn bè" >E-mail</a> | 
			<a onclick="window.open(window.location.href.replace('/vn/', '/vn/print/'));" href="javascript:void(0);" class="commentbox_new_button_print" title="Bản In">Bản In</a> | 
			<span>Chia sẻ</span>
			<a onclick="share_facebook();" href="javascript:void(0);" class="commentbox_new_button_facebook">&nbsp;</a>
			<a onclick="share_twitter();" href="javascript:void(0);" class="commentbox_new_button_twitter">&nbsp;</a>
		</div>
	</div>
	<div class="commentbox_new_content">
		<div class="commentbox_new_padding_content">
			<div class="box_rows clearfix"><div class="mess"></div></div>
			<div class="box_rows clearfix">
				<div class="box_rows_left"><input type="text" watermark="Họ và tên *" class="commentbox_new_text name" style="color: #a3c1d4;"></div>
				<div class="box_rows_right"><input type="text" watermark="Email" class="commentbox_new_text email" style="color: #a3c1d4;"></div>
			</div>
			<div class="box_rows clearfix">
				<div class="box_rows_left"><input type="text" watermark="Tiêu đề" class="commentbox_new_text subject" style="color: #a3c1d4;"></div>
				<div class="box_rows_right"><input type="text" watermark="Số điện thoại" class="commentbox_new_text phone" style="color: #a3c1d4;"></div>
			</div>
			<div class="box_rows clearfix"><textarea watermark="Nội dung" class="comment-text message" style="color: #a3c1d4;"></textarea></div>
			<div class="box_rows clearfix">
				<a class="ar-freedback-submit" onclick="postComment();" href="javascript: void(0);">Gửi tòa soạn</a>
				<a class="ar-freedback-reset" onclick="resetComment();" href="javascript: void(0);">Xóa trắng</a>
				<a class="ar-freedback-close" href="#">Đóng lại</a>
			</div>
			
			<div class="commentbox_new_note">Vui lòng gõ tiếng Việt có dấu và không quá 1000 chữ</div>
			
			<input type="text" class="comment-title aid" style="display:none" value="<%=ArticleId %>"/>
            <iframe id="cmdPostComment" src="" alt="post" style="display:none;" ></iframe>
			
		</div>
	</div>
</div>