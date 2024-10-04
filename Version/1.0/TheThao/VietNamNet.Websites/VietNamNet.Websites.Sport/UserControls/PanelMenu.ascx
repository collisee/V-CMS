<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMenu.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.PanelMenu" %>
<div class="hnavBox">
  <ul class="hnavVNN">
    <li alias="trang-chu" class="current"><a class="item" href="/"><b>Trang chủ</b></a></li>
    <li alias="bong-da-viet-nam"><a class="item" href="/vn/tin-tuc-bong-da/index.html"><b>Bóng đá Việt Nam</b></a></li>
    <li alias="bong-da-quoc-te"><a class="item" href="/vn/bong-da-quoc-te/index.html"><b>Bóng đá quốc tế</b></a></li>
    <li alias="the-thao"><a class="item" href="/vn/tennis/index.html"><b>Thể thao</b></a></li>
    <li alias="tin-360"><a class="item" href="/vn/hau-truong/index.html"><b>360°</b></a></li>
    <%--<li alias="binh-luan"><a class="item" href="/vn/binh-luan-cung-nha-bao/index.html"><b>Bình luận cùng nhà báo</b></a></li>
    <li alias="world-cup"><a class="item" href="#"><b>World Cup</b></a></li>--%>
  </ul>
  <div class="hnavSUB" alias="trang-chu">
    <a href="http://vietnamnet.vn/" class="icon-link" target="_blank">
      <img src="http://res.vietnamnet.vn/sports/images/icon_vietnamnet.png" title="Vietnamnet"
        alt="Vietnamnet" /></a> <a href="http://tuanvietnam.vietnamnet.vn/" class="icon-link"
          target="_blank">
          <img src="http://res.vietnamnet.vn/sports/images/icon_tuanvietnam.png" title="Tuanvietnam"
            alt="Tuanvietnam" /></a> <a href="http://2sao.vietnamnet.vn/" class="icon-link" target="_blank">
              <img src="http://res.vietnamnet.vn/sports/images/icon_2sao.png" title="2Sao" alt="2Sao" /></a>
    <a href="http://clip.vietnamnet.vn/" class="icon-link icon-link-last" target="_blank">
      <img src="http://res.vietnamnet.vn/sports/images/icon_clip.png" title="3G Hot" alt="3G Hot" />3G
      Hot</a>
  </div>
  <div class="hnavSUB" alias="bong-da-viet-nam">
    <a href="/vn/tuyen-nu-viet-nam/index.html">Tuyển nữ Việt Nam</a> <a href="/vn/tin-tuc-bong-da/index.html">
      Tin tức bóng đá</a> <a href="/vn/cup-quoc-gia/index.html">Cúp Quốc gia</a> <a href="/vn/doi-tuyen-viet-nam/index.html">
        Đội tuyển Việt Nam</a> <a href="/vn/hang-nhat/index.html">Hạng nhất</a> <a href="/vn/v-league/index.html">
          V-League</a>
  </div>
  <div class="hnavSUB" alias="bong-da-quoc-te">
    <%--<a href="/vn/bong-da-quoc-te/index.html">Bóng đá quốc tế</a>--%> <a href="/vn/uefa-cup/index.html">
      UEFA Cup</a> <a href="/vn/champions-league/index.html">Champions League</a> <a href="/vn/serie-a/index.html">
        Serie A</a> <a href="/vn/bundesliga/index.html">Bundesliga</a> <a href="/vn/la-liga/index.html">
          La liga</a> <a href="/vn/premier-league/index.html">Premier League</a>
  </div>
  <div class="hnavSUB" alias="the-thao">
    <a href="/vn/dua-xe/index.html">Đua xe</a> <a href="/vn/tennis/index.html">Quần
      vợt</a> <a href="/vn/cac-mon-khac/index.html">Các môn khác</a>
  </div>
  <div class="hnavSUB" alias="tin-360">
    <a href="/vn/chan-dung-phong-van/index.html">Chân dung - Phỏng vấn</a> <a href="/vn/giao-luu-truc-tuyen/index.html">
      Giao Lưu Trực Tuyến</a> <a href="/vn/dien-dan/index.html">Diễn đàn bạn đọc</a>
    <a href="/vn/hau-truong/index.html">Hậu trường</a><a href="/vn/binh-luan-cung-nha-bao/index.html">Bình luận cùng nhà báo</a>
  </div>
  <%--<div class="hnavSUB" alias="binh-luan">
    <a href="/vn/binh-luan-cung-nha-bao/index.html">Bình luận cùng nhà báo</a>
  </div>--%>
  <div class="hnavSUB" alias="world-cup">
    <a href="/vn/world-cup/tin-nong-24h/index.html">Tin nóng 24h</a> <a href="/vn/world-cup/dien-bien/index.html">
      Diễn biến</a> <a href="/vn/world-cup/cau-chuyen-trong-ngay/index.html">Câu chuyện
        trong ngày</a> <a href="/vn/world-cup/ben-le/index.html">Bên lề</a> <a href="/vn/world-cup/toi-va-world-cup/index.html">
          Tôi và World Cup</a>
  </div>
  <div class="search-top">
    <input type="text" class="search-top-button input-search" watermark="Search.." onkeydown="searchkey(event,this)"
      id="keywords2" />
    <a href="#" onclick="search()">
      <img alt="" title="" src="http://res.vietnamnet.vn/images/blank.gif" width="16" height="13"
        onclick="search()" /></a>
  </div>
</div>

<script type="text/javascript" language="javascript">
  menuCurrentAlias = '<%=categoryAlias %>';
</script>

