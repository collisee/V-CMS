<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsFeedback.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.News.PanelNewsFeedback" %>


<div id="article-feedback" class="row"> 
<div class="content-left" id="newcomment">
  <div class="article-freedback-title">
            <span>ý kiến của bạn</span>
  </div>
  <div class="article-freedback-border1">&nbsp;</div> 
    
    <div class="article-freedback-form">
              <div>
                <div class="red mess"></div>
              </div>
    <div>
        <div class="ar-freedback-text">
          Họ và tên :
        </div>
        <div class="ar-freedback-input">
          <input type="text"  class="comment-title name" watermark="Name" />
        </div>
        
        <div class="ar-freedback-text">
          Email :
        </div>
        <div class="ar-freedback-input">
          <input type="text" class="comment-title email" watermark="Mail" /> 
        </div>
          <div class="clear">  &nbsp;</div>
     </div>   
     
      <div>
        <div class="ar-freedback-text">
          Tiêu đề :
        </div>
        <div class="ar-freedback-input">
          <input type="text" class="comment-title subject" watermark="Subject"  />
        </div>
        <div class="ar-freedback-text">
          Số ĐT :
        </div>
        <div class="ar-freedback-input">
          <input type="text" class="comment-title phone" watermark="Phone" />
        </div>
        <div class="clear">
          &nbsp;</div>
      </div>
     
     <div>
        <div class="ar-freedback-text">
          Nội dung :
        </div>
        <div class="ar-freedback-input">
          <textarea class="comment-text message"  watermark="Message"></textarea>
        </div>
        <div class="clear">
          &nbsp;</div>
      </div>

        
        
         <div class="form-item">
            <%--<img src="/images/swap.gif" width="21" height="18" class="form-swap" />
            <img src="/images/SECURITY.gif" width="72" height="18" class="form-swap" />
            <div class="form-swap2">
                <input type="text" class="comment-title2 validcode" watermark="Valid_Code" />
            </div>--%>
            <a href="javascript: void(0);"  onclick="postComment();"  class="ar-freedback-submit" >&nbsp;</a> &nbsp;
            <a href="javascript: void(0);"  onclick="resetComment();" class="ar-freedback-reset" >&nbsp;</a> 
            
              <div class="clear">
        &nbsp;</div>
        <div>
        
        <div class="ar-freedback-note">
                Vui lòng gõ tiếng Việt có dấu và không quá 1000 chữ
              </div>
        </div>

             
            <input type="text" class="comment-title aid" style="display:none" value="<%=ArticleId %>"  />
            
            <br class="clear" />

             <iframe id="cmdPostComment" src="" alt="post" style="display:none;" ></iframe>
        </div>
    </div> 
    
</div>
</div>