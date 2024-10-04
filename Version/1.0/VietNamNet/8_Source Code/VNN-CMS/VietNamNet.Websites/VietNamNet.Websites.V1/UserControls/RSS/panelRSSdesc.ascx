<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="panelRSSdesc.ascx.cs" Inherits="VietNamNet.Websites.English.UserControls.RSS.panelRSSdesc" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="pdlr5">
<div style=" margin: 15px;text-align: justify; padding:15px; float: right; border: 1px solid #AAAAAA; background: #F9F9F9;">
    <ul>
        <li><a href="#WhatRssIs">RSS là gì?</a></li>
        <li><a href="#VietNamNetChannel">Danh mục Kênh RSS của báo VietNamNet</a></li>
        <li><a href="#AddPersonal">Thêm RSS vào trang Cá nhân</a></li>
        <li><a href="#WhatRssReaderIs">Chương trình đọc RSS là gì?</a> </li>
        <li><a href="#TermAndConditionOfUse">Điều kiện sử dụng</a></li>
    </ul>
 </div>
 
    <div class="bg_title3">RSS - Really Simple Syndication</div>
     
</div>
<div style="text-align: justify; padding:15px; line-height:1.5em;"  class="content-article">
 
 
 <h3 id="WhatRssIs">RSS là gì?</h3>
<p>
    RSS  là định dạng dữ liệu dựa theo chuẩn XML được sử dụng để chia sẻ và phát tán nội dung Web. Việc sử dụng các chương trình đọc tin (News Reader, RSS Reader hay RSS Feeds) sẽ giúp bạn luôn xem được nhanh chóng tin tức mới nhất từ Báo VietNamNet
</p>
<p>
    Mỗi tin dưới dạng RSS sẽ gồm : Tiêu đề, tóm tắt nội dung và đường dẫn nối đến trang Web chứa nội dung đầy đủ của tin.
</p>
<a class="totop" href="#">Về đầu trang</a>


<h3  id="VietNamNetChannel">Các kênh RSS của báo VietNamNet</h3>
<p>
    <table width="100%">
        <tr>
            <td>
                <a href="/rss/home.rss"><img src="/Images/rss.png" alt="Trang chủ" /></a>
            </td>
            <td>                
               <a href="/vn/index.html">Trang chủ</a>
            </td>
            <td><a href="/rss/home.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/trang-chu.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/home.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/home.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
         <tr>
            <td>
                <a href="/rss/xa-hoi.rss"><img src="/Images/rss.png" alt="Xã hội" /></a>
            </td>
            <td>                
               <a href="/vn/xa-hoi/index.html">Xã hội</a></td>
            <td><a href="/rss/xa-hoi.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/xa-hoi.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/xa-hoi.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/xa-hoi.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
        <tr>
            <td>
                <a href="/rss/giao-duc.rss"><img src="/Images/rss.png" alt="Giáo dục" /></a>
            </td>
            <td><a href="/vn/giao-duc/index.html">Giáo dục</a></td>
            <td><a href="/rss/giao-duc.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/giao-duc.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/giao-duc.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/giao-duc.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
        <tr>
            <td>
                <a href="/rss/chinh-tri.rss"><img src="/Images/rss.png" alt="Chính trị" /></a>
            </td>
            <td><a href="/vn/chinh-tri/index.html">Chính trị</a></td>
            <td> <a href="/rss/chinh-tri.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/chinh-tri.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/chinh-tri.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/chinh-tri.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
        <tr>
            <td>
                <a href="/rss/phong-su-dieu-tra.rss"><img alt="Phóng sự điều tra" src="/Images/rss.png" /></a>
            </td>
            <td><a href="/vn/phong-su-dieu-tra/index.html">Phóng sự điều tra</a></td>
            <td>
                <a href="/rss/phong-su-dieu-tra.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/phong-su-dieu-tra.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/phong-su-dieu-tra.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/phong-su-dieu-tra.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
         <tr>
            <td>
                <a href="/rss/kinh-te.rss"><img alt="Kinh tế" src="/Images/rss.png" /></a>
            </td>
            <td><a href="/vn/kinh-te/index.html">Kinh tế</a></td>
            <td>
                <a href="/rss/kinh-te.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/kinh-te.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/kinh-te.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/kinh-te.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
         <tr>
            <td>
                <a href="/rss/quoc-te.rss"><img alt="Quốc tế" src="/Images/rss.png" /></a>
            </td>
            <td>
                <a href="/vn/quoc-te/index.html">Quốc tế</a></td>
            <td>
                <a href="/rss/quoc-te.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/quoc-te.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/quoc-te.rss');"><img alt="Add to Google"  src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/quoc-te.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
     <tr>
            <td>
                <a href="/rss/van-hoa.rss"><img alt="Văn hóa" src="/Images/rss.png" /></a>
            </td>
            <td>
                <a href="/vn/van-hoa/index.html">Văn hóa</a></td>
            <td>
                <a href="/rss/van-hoa.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/van-hoa.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/van-hoa.rss');"><img alt="Add to Google"  src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/van-hoa.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
     <tr>
            <td>
                <a href="/rss/khoa-hoc.rss"><img alt="Khoa học" src="/Images/rss.png" /></a>
            </td>
            <td>
                <a href="/vn/khoa-hoc/index.html">Khoa học</a></td>
            <td>
                <a href="/rss/khoa-hoc.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/khoa-hoc.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/khoa-hoc.rss');"><img alt="Add to Google"  src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/khoa-hoc.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
        
        <tr>
            <td>
                <a href="/rss/cong-nghe-thong-tin-vien-thong.rss"><img alt="CNTT - Viễn thông" src="/Images/rss.png" /></a>
            </td>
            <td>
                <a href="/vn/cong-nghe-thong-tin-vien-thong/index.html">CNTT - Viễn thông</a></td>
            <td>
                <a href="/rss/cong-nghe-thong-tin-vien-thong.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/cong-nghe-thong-tin-vien-thong.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/cong-nghe-thong-tin-vien-thong.rss');"><img alt="Add to Google"  src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/cong-nghe-thong-tin-vien-thong.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
        <tr>
            <td>
                <a href="/rss/ban-doc-phap-luat.rss"><img alt="Bạn đọc" src="/Images/rss.png" /></a>
            </td>
            <td>
                <a href="/vn/ban-doc-phap-luat/index.html">Bạn đọc</a></td>
            <td>
                <a href="/rss/ban-doc-phap-luat.rss"><%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/ban-doc-phap-luat.rss</a></td>
            <td><a href="#" onclick="return rss_GoogleReader('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/ban-doc-phap-luat.rss');"><img alt="Add to Google" src="/Images/plus_google.gif" /></a>
                <a href="#" onclick="return rss_MyYahoo('<%=Utilities.GetConfigKey(WebsitesConstants.ConfigKey.WebsiteLink) %>rss/ban-doc-phap-luat.rss');"><img alt="Add to MyYahoo" src="/Images/addtomyyahoo.gif" /></a></td>
        </tr>
    </table>
</p>
<a class="totop" href="#">Về đầu trang</a>

    <h3 id="AddPersonal">
        Thêm một kênh <a href="#WhatRssIs">RSS</a> của báo VietNamNet
        vào các trang Cá nhân: Google, MyYahoo!</h3>

    <ol><li>Nhấn vào nút "+Google" hoặc "+My Yahoo!" cùng dòng với mục bạn muốn trong bảng danh mục <a href="#VietNamNetChannel">kênh RSS</a> của báo VietNamNet.</li><li>Làm theo các chỉ dẫn để thêm mục RSS tương ứng của báo VietNamNet vào trang
     Cá nhân của bạn.</li></ol>
 <a class="totop" href="#">Về đầu trang</a>
 
 
    <h3 id="WhatRssReaderIs">
        Chương trình đọc RSS là gì?</h3>
    <p>
        Rss Reader là phần mềm có chức năng tự động lấy tin tức đã được cấu trúc theo định
        dạng RSS. Một số phần mềm đọc RSS cho phép bạn lập lịch cập nhật tin tức. Với chương
        trình đọc RSS, bạn có thể nhấn chuột vào tiêu đề của 1 tin để đọc phần tóm tắt của
        hoặc mở ra nội dung của toàn bộ tin trong một cửa sổ trình duyệt mặc định.</p>
    <p>
        Có rất nhiều phần mềm phục vụ khai thác tin qua định dạng RSS, bạn có thể tham khảo
        bảng các chương trình đọc RSS bên cạnh và lựa chọn cái bạn thích nhất.</p>
    <p>
        Nếu đang sử dụng FireFox, bạn có thể tải chương trình Wizz RSS từ<a href="https://addons.mozilla.org/firefox/424/">địa
            chỉ này</a></p>
    <a class="totop" href="http://vietnamnet.vn/rss/#">Về đầu trang</a><h3 id="Add2RssReader">
        Sử dụng chương trình đọc RSS (RSS Reader)</h3>
    <ol>
        <li>Chép (copy) đường dẫn (URL) tương ứng với kênh RSS mà bạn ưa thích.</li>
        <li>
            <p class="pInterTitle">
                Dán (paste) URL vào chương trình đọc RSS.</p>
        </li>
    </ol>
    <a class="totop" href="#">Về đầu trang</a>
    
    <h3 id="TermAndConditionOfUse">
        Điều kiện sử dụng</h3>
    <p>
        Báo VietNamNet không chịu trách nhiệm về các nội dung của các trang khác ngoài Báo
        VietNamNet được dẫn trong trang này.</p>
    <p>
        Khi sử dụng lại các tin lấy từ Báo VietNamNet, bạn phải ghi rõ nguồn tin là "Theo
        Báo VietNamNet" hoặc "Báo VietNamNet".</p>
    <a class="totop" href="#">Về đầu trang</a>
     
</div> 