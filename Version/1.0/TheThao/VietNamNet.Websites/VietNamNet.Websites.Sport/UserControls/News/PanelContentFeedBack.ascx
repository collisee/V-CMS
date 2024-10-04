<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelContentFeedBack.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentFeedBack" %>
<div class="home-article-comment-box">
                <h2>
                    Ý kiến của bạn</h2>
                <div class="input-area-columns clearfix">
                    <div class="l">
                        <p>
                            <input type="text" class="text" name="fullname" value="Họ và tên *" /></p>
                        <p>
                            &nbsp;</p>
                        <p>
                            <input type="text" class="text" name="tel" value="Điện thoại" /></p>
                        <p>
                            - Điện thoại không hiển thị lên trang</p>
                    </div>
                    <div class="r">
                        <p>
                            <input type="text" class="text" name="email" value="Enmail *" /></p>
                        <p>
                            - Email không hiển thị lên trang</p>
                        <p>
                            <input type="text" class="text" name="address" value="Địa chỉ" /></p>
                        <p>
                            &nbsp;</p>
                    </div>
                </div>
                <div class="input-area-full">
                    <p>
                        <textarea name="message">Nội dung</textarea></p>
                    <p>
                        - Nội dung không quá 1000 từ, viết bằng tiếng Việt có dấu.</p>
                </div>
                <div class="input-area-columns clearfix">
                    <div class="l small">
                        <input type="image" class="button-img" src="http://res.vietnamnet.vn/sports/images/button-send-comment.png" />
                    </div>
                    <div class="r big pleft clearfix">
                        <a href="#">
                            <img src="http://res.vietnamnet.vn/sports/images/button-reload.png" /></a><img src="img/img-capchar.png" height="24px" /><input
                                type="text" class="text small" name="capchar" value="Mã bảo vệ" />
                    </div>
                </div>
            </div>