<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelFooter.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.PanelFooter" %>
<div class="menu-bottom ">
  <div class="menu-bt-icon">
    <a href="/vn/rss/index.html"><img src="http://res.vietnamnet.vn/images/blank.gif" width="21" height="20" alt="RSS" title="RSS" /></a> 
    <a href="javascript:void(0);" onclick="createBookmark();"><img src="http://res.vietnamnet.vn/images/blank.gif" width="21" height="20" alt="Thêm vào danh sách trang yêu thich" title="Thêm vào danh sách trang yêu thich" /></a>    
    <a href="javascript:void(0);" onclick="return setHomepage();"><img src="http://res.vietnamnet.vn/images/blank.gif" width="21" height="20" alt="Đặt làm trang chủ" title="Đặt làm trang chủ" /></a> 
    <%--<a href="#"><img src="http://res.vietnamnet.vn/images/blank.gif" width="21" height="20" /></a>--%>
  </div>
  <div class="search-bottom">
    <input type="text" class="search-top-button input-search2" watermark="Search.." onkeydown="searchkey(event,this)" id="keywords2" /> 
    <a href="#" onclick="search()"><img alt="" title="" src="http://res.vietnamnet.vn/images/blank.gif" width="25" height="13" onclick="search()" /></a></div>
  <div class="text">
    
  </div>
</div>
<div class="body-footer">
  <div class="logobottom">
    <a href="http://vietnamnet.vn" target="_blank">
      <img alt="VietNamNet" title="VietNamNet" src="http://res.vietnamnet.vn/images/blank.gif" width="110" height="30" /></a> <a href="/">
       <img alt="Trang chủ" title="Trang chủ" src="http://res.vietnamnet.vn/images/blank.gif" width="110" height="30" class="pdt5" /></a>
  </div>
  <div class="footer-submenu pdt5">
    <div class="bold">
       <a href="/vn/index.html">Trang chủ</a> | 
      <a href="/vn/doi-tuyen-viet-nam/index.html">Bóng đá Việt Nam</a> | 
      <a href="/vn/bong-da-quoc-te/index.html">Bóng đá quốc tế</a> | 
      <a href="/vn/cac-mon-khac/index.html">Thể thao</a> | 
      <a href="/vn/chan-dung-phong-van/index.html">360°</a> | 
      <a href="/vn/binh-luan-cung-nha-bao/index.html">Bình luận cùng nhà báo</a>     
    </div>
  </div>
  <div class="pdt5">
    © <b>Báo VietNamNet, số 141 Bà Triệu, Hai Bà Trưng, Hà Nội. </b>
    <br />
    Cơ quan chủ quản: Bộ Thông tin và Truyền thông.
    <br />
    Số giấy phép: 1285/GP - BTTTT cấp ngày 27/8/2008.
    <br />
    Tổng biên tập: Nguyễn Anh Tuấn.
    <br />
    ® Ghi rõ nguồn "VietNamNet" khi phát hành lại thông tin từ website này.
  </div>
  <br class="clear" />
</div>
