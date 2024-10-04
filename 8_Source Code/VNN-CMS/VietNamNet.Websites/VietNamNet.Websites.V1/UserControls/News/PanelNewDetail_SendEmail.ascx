<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewDetail_SendEmail.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.News.PanelNewDetail_SendEmail" %>

	<div id="digSendEmail_hidden">
		<div id="digSendEmail">
		
			<div class="digSendEmail_rows clearfix"><div class="mess"></div></div>
			
			<div class="digSendEmail_rows clearfix">
				<div class="digSendEmail_rows_left">Tới:</div>
				<div class="digSendEmail_rows_right"><input class="digSendEmail_text" id="smEmailTo" name="smEmailTo" type="text"/></div>
			</div>
			
			<div class="digSendEmail_rows clearfix">
				<div class="digSendEmail_rows_left">Họ tên:</div>
				<div class="digSendEmail_rows_right"><input class="digSendEmail_text" id="smName" name="smName" type="text"/></div>
			</div>
			
			<div class="digSendEmail_rows clearfix">
				<div class="digSendEmail_rows_left">E-mail của bạn:</div>
				<div class="digSendEmail_rows_right"><input class="digSendEmail_text" id="smEmailFrom" name="smEmailFrom" type="text"/></div>
			</div>
			
			<div class="digSendEmail_rows clearfix">
				<div class="digSendEmail_rows_left">Nội dung:</div>
				<div class="digSendEmail_rows_right"><textarea class="digSendEmail_textarea" id="smMessage" name="smMessage"></textarea></div>
			</div>
			
			<div class="digSendEmail_rows clearfix">
				<div class="digSendEmail_rows_left">&nbsp;</div>
				<div class="digSendEmail_rows_right"><a id="digSendEmail_but_send" href="javascript:sendEmail();">Gửi E-mail</a></div>
			</div>
			
			<input id="hidCategoryAlias" name="hidCategoryAlias" value="<%=Url %>" type="hidden"/>
			<input id="hidMessageId" name="hidMessageId" value="<%= SendEmailId%>" type="hidden"/>
			<input id="hidMessageSubject" name="hidMessageSubject" value="<%=Subject %>" type="hidden"/>
			
		</div>
	</div>
        