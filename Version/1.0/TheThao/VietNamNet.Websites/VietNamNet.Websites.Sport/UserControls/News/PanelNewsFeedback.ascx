<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsFeedback.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelNewsFeedback" %>
 

<div class="home-article-comment-box" id="newcomment">
    <div class="fb_title cpointer">
        <h2>Ý kiến của bạn<a name="youridea" href="javascript:void(0)" class="down">Close</a></h2>
    </div>
    <div class="article-freedback-form hidden">
        <div class="input-area-full">
            <div class="red mess">
            </div>
        </div>
        <div class="input-area-columns clearfix">
            <div class="l">
                <p>
                    <input type="text" watermark="Họ và tên *" class="text name"></p>
                <p>
                    &nbsp;</p>
                <p>
                    <input type="text" watermark="Điện thoại" class="text phone"></p>
                <p>
                    - Điện thoại không hiển thị lên trang</p>
            </div>
            <div class="r">
                <p>
                    <input type="text" watermark="Email *" class="text email"></p>
                <p>
                    - Email không hiển thị lên trang</p>
                <p>
                    <input type="text" watermark="Tiêu đề" class="text subject"></p>
                <p>
                    &nbsp;</p>
            </div>
        </div>
        <div class="input-area-full">
            <p>
                <textarea class="message" watermark="Nội dung"></textarea></p>
            <p>
                - Nội dung không quá 1000 từ, viết bằng tiếng Việt có dấu.</p>
        </div>
        <div class="input-area-columns clearfix">
            <div class="l small">
                <a href="javascript: void(0)" onclick="postComment();" class="ar-freedback-submit">
                    <img src="http://res.vietnamnet.vn/sports/images/button-send-comment.png" class="button-img" /></a> &nbsp;
                <input type="text" class="comment-title aid" style="display: none" value="<%=ArticleId %>" />
                <br class="clear" />
                <iframe id="cmdPostComment" src="" alt="post" style="display: none;"></iframe>
            </div>
            <div class="r big pleft clearfix">
            </div>
        </div>
    </div>
</div>
