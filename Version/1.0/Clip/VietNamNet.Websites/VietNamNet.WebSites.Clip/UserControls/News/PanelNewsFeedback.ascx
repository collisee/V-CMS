<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsFeedback.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.News.PanelNewsFeedback" %>

<script type="text/javascript" src="/js/feedback.js"></script>

<script type="text/javascript">
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
</script>

<div class="clear">
  ,</div>
<div id="article-feedback" class="row">
  <div class="article-freedback-title">
    <asp:Label ID="lblError" runat="server" CssClass="red" Text="ý kiến của bạn" />
  </div>
  <div class="article-freedback-border1">
    &nbsp;</div>
  <asp:Panel ID="pnlForm" runat="server">
    <div class="article-freedback-form">
      <div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn phải nhập <b>Họ tên</b><br />"
          Display="Dynamic" ControlToValidate="txtName" ValidationGroup="PostComment"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ErrorMessage="Bạn nhập <b>Email</b> chưa chính xác<br />"
          Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="PostComment" ID="RegularExpressionValidator2"
          runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn phải nhập <b>Nội dung</b><br />"
          Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="PostComment"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="&nbsp; Bạn nhập nội dung quá dài<br />"
          Display="Dynamic" ControlToValidate="txtComment" ValidationGroup="PostComment"
          ValidationExpression="^[\W\w\D\d\t\n\S\s]{1,1000}$" Font-Bold="True"></asp:RegularExpressionValidator>
        <br />
      </div>
      <div>
        <div class="ar-freedback-text">
          Họ và tên :
        </div>
        <div class="ar-freedback-input">
          <asp:TextBox ID="txtName" runat="server" class="ar-freedback-box" MaxLength="255"></asp:TextBox>
          <input id="txtName" name="txtName" class="ar-freedback-box" />
        </div>
        <div class="ar-freedback-text">
          Email :
        </div>
        <div class="ar-freedback-input">
          <asp:TextBox ID="txtEmail" runat="server" class="ar-freedback-box" MaxLength="255"></asp:TextBox>
        </div>
        <div class="clear">
          &nbsp;</div>
      </div>
      <div>
        <div class="ar-freedback-text">
          Địa chỉ :
        </div>
        <div class="ar-freedback-input">
          <asp:TextBox ID="txtAddress" runat="server" class="ar-freedback-box2" MaxLength="255"></asp:TextBox>
        </div>
        <div class="clear">
          &nbsp;</div>
      </div>
      <div>
        <div class="ar-freedback-text">
          Nội dung :
        </div>
        <div class="ar-freedback-input">
          <asp:TextBox ID="txtComment" runat="server" class="ar-freedback-box3" TextMode="MultiLine"
            MaxLength="1000"></asp:TextBox>
        </div>
        <div class="clear">
          &nbsp;</div>
      </div>
      <asp:Button ID="btnSubmit" class="ar-freedback-submit" runat="server" Text=" &nbsp;"
        OnClick="btnSubmit_Click" ValidationGroup="PostComment" />
      <div class="ar-freedback-note">
        Vui lòng gõ tiếng Việt có dấu và không quá 1000 chữ
      </div>
      <div class="clear">
        &nbsp;</div>
      <div class="article-freedback-border2">
        &nbsp;</div>
    </div>
    <!--an so dt-->
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic"
      ControlToValidate="txtPhone" runat="server" ErrorMessage="Bạn nhập <b>số điện thoại</b> chưa chính xác<br />"
      ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
    <asp:TextBox ID="txtPhone" runat="server" class="ykien-title" MaxLength="255" Visible="false" />
    <!--an so dt-->
  </asp:Panel>
</div>
<div>
  <div id="<%=this.ID %>" class="item-list">
    <div id="feedback-items">
    </div>
    <div class="pagy">
      <a href="javascript:prevComment()" class="pagy-prev">Trang trước</a> <a href="javascript:nextComment()"
        class="pagy-next">Trang sau</a>
    </div>
  </div>
</div>

<script type="text/javascript">
/* Load Comment */

var commentIndex = 0;
  function initComment(){
    VietNamNet.Framework.JS.AjaxManager.add({
      url: service_get_url,
      data: {m: <%=ArticleId %>, index: commentIndex},
      success: function(output){
        var html = '';
        if (output && output != '""' && output != 'null') {html = output.trim();}
        else{
          $('#<%=this.ID %>').hide();
          return;
          };
        var obj = VietNamNet.Framework.JS.JSON.decode(html);
        if (obj){ //bind obj
          var tmpComment = new VietNamNet.Framework.JS.Template({
                        id: 'tmpComment',
                        template: '<div id="feedback-item">' +
                         '<div class="comment">{Detail}</div>' +
                         '<div class="profile"><b>{Name}</b> - lúc <i>{Created_At}</i></div>' +
                         '</div>'
                    });
          VietNamNet.Framework.JS.TemplateManager.bind('feedback-items', obj, tmpComment);
          
          //show Next button
          $('#<%=this.ID %> .pagy .pagy-next').show();
          //hidden Prev button
          if (!commentIndex || commentIndex <= 0) $('#<%=this.ID %> .pagy .pagy-prev').hide();
          else $('#<%=this.ID %> .pagy .pagy-prev').show();
        }else{
          //hidden Next button
          $('#<%=this.ID %> .pagy .pagy-next').hide();
        }
      },
      error: function(){
        $('#<%=this.ID %> .pagy .pagy-prev').hide();
        $('#<%=this.ID %> .pagy .pagy-next').hide();
      }
    });
  }
  
  function prevComment(){
    commentIndex--;
    initComment();
  }
  
  function nextComment(){
    commentIndex++;
    initComment();
  }
  
  VietNamNet.Framework.JS.Initialization.add(initComment);  
</script>

