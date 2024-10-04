<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentFeedback.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.News.PanelContentFeedback" %>
<div class="content-left" id="newcomment">
    <div class="bg_title3">Comment</div>
    
    <div class="content-form">
        <div class="form-item">
            <input type="text"  class="comment-title name" watermark="Name" />
            <br class="clear" />
        </div>
        <div class="form-item">
            <input type="text" class="comment-title mail" watermark="Mail" />
            <br class="clear" />
        </div>
        <div class="form-item">
            <input type="text" class="comment-title phone" watermark="Phone" />
            <br class="clear" />
        </div>
        <div class="form-item">
            <input type="text" class="comment-title subject" watermark="Subject"  />
            <br class="clear" />
        </div>
        <div class="form-item">
            <textarea class="comment-text message"  watermark="Message"></textarea>
            <br class="clear" />
        </div>
          <div class="form-item">
                <div class="red mess" style="color:Red"></div>
              </div>
        <div class="form-item">
            <%--<img src="/images/swap.gif" width="21" height="18" class="form-swap" />
            <img src="/images/SECURITY.gif" width="72" height="18" class="form-swap" />
            <div class="form-swap2">
                <input type="text" class="comment-title2 validcode" watermark="Valid_Code" />
            </div>--%>
            <img src="/images/reset.gif" width="47" height="18" class="form-swap" onclick="resetComment();"/>
            <img src="/images/sent.gif" width="42" height="18" onclick="postComment();" /> 
              <input type="text" class="comment-title aid" style="display:none" value="<%=ArticleId %>"  />
            
            <br class="clear" />

             <iframe id="cmdPostComment" src="" alt="post" style="display:none;" ></iframe>
        </div>
    </div>
    
</div>
