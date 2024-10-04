<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMenu.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.PanelMenu" %>
<div id="menu">
  <div id="menu-primary">
    <ul class="glossymenu">
      <li id="mn1_a" style="display: block" class="current"><a href="/vn/index.html"><span>
        Trang chủ</span></a></li>
      <li id="mn1_b" style="display: none;"><a href="/vn/index.html"><span>Trang chủ</span></a></li>
      <li id="mn1_1a"><a href="/vn/xa-hoi/" onmouseover="show(1,0)" onmouseout="hidden(1)">
        <span>Xã hội</span></a></li>
      <li id="mn1_1b" style="display: none;" class="current"><a href="/vn/xa-hoi/index.html"
        onmouseover="show(1,0)" onmouseout="hidden(1)"><span>Xã hội</span></a></li>
      <li id="mn1_2a"><a href="/giaoduc/" onmouseover="show(2,0)" onmouseout="hidden(2)">
        <span>Giáo dục</span></a></li>
      <li id="mn1_2b" style="display: none;" class="current"><a href="/vn/giao-duc/index.html"
        onmouseover="show(2,0)" onmouseout="hidden(2)"><span>Giáo dục</span></a></li>
      <li id="mn1_3a"><a href="/chinhtri/" onmouseover="show(3,0)" onmouseout="hidden(3)">
        <span>Chính trị</span></a></li>
      <li id="mn1_3b" style="display: none;" class="current"><a href="/vn/chinh-tri/index.html"
        onmouseover="show(3,0)" onmouseout="hidden(3)"><span>Chính trị</span></a></li>
      <li id="mn1_4a"><a href="/psks/" onmouseover="show(4,240)" onmouseout="hidden(4)">
        <span>Phóng sự điều tra</span></a></li>
      <li id="mn1_4b" style="display: none;" class="current"><a href="/vn/phong-su-dieu-tra/index.html"
        onmouseover="show(4,240)" onmouseout="hidden(4)"><span>Phóng sự điều tra</span></a></li>
      <li id="mn1_5a"><a href="/kinhte/" onmouseover="show(5,0)" onmouseout="hidden(5)">
        <span>Thị trường</span></a></li>
      <li id="mn1_5b" style="display: none;" class="current"><a href="/vn/kinh-te/index.html"
        onmouseover="show(5,0)" onmouseout="hidden(5)"><span>Thị trường</span></a></li>
      <li id="mn1_6a"><a href="/quocte/" onmouseover="show(6,0)" onmouseout="hidden(6)">
        <span>Quốc tế</span></a></li>
      <li id="mn1_6b" style="display: none;" class="current"><a href="/vn/quoc-te/index.html"
        onmouseover="show(6,0)" onmouseout="hidden(6)"><span>Quốc tế</span></a></li>
      <li id="mn1_7a"><a href="/vanhoa/" onmouseover="show(7,400)" onmouseout="hidden(7)">
        <span>Văn hóa</span></a></li>
      <li id="mn1_7b" style="display: none;" class="current"><a href="/vn/van-hoa/index.html"
        onmouseover="show(7,400)" onmouseout="hidden(7)"><span>Văn hóa</span></a></li>
      <li id="mn1_9a"><a href="/khoahoc/" onmouseover="show(9,290)" onmouseout="hidden(9)">
        <span>Khoa học</span></a></li>
      <li id="mn1_9b" style="display: none;" class="current"><a href="/vn/khoa-hoc/index.html"
        onmouseover="show(9,290)" onmouseout="hidden(9)"><span>Khoa học</span></a></li>
      <li id="mn1_10a"><a href="/cntt/" onmouseover="show(10,280)" onmouseout="hidden(10)">
        <span>CNTT - Viến thông</span></a></li>
      <li id="mn1_10b" style="display: none;" class="current"><a href="/vn/cong-nghe-thong-tin-vien-thong/index.html"
        onmouseover="show(10,280)" onmouseout="hidden(10)"><span>CNTT - Viến thông</span></a></li>
      <li id="mn1_11a"><a href="/bandocviet/" onmouseover="show(11,450,1)" onmouseout="hidden(11)">
        <span>Bạn đọc</span></a></li>
      <li id="mn1_11b" style="display: none;" class="current"><a href="/vn/ban-doc-phap-luat/index.html"
        onmouseover="show(11,450,1)" onmouseout="hidden(11)"><span>Bạn đọc</span></a></li>
      <li id="mn1_12a"><a href="http://tuanvietnam.net"><span>Tuần VN</span></a></li>
      <li id="mn1_12b" style="display: none;" class="current"><a href="http://tuanvietnam.net">
        <span>Tuần VN</span></a></li>
      <li id="mn1_13a"><a href="http://2sao.net"><span>2 Sao</span></a></li>
      <li id="mn1_13b" style="display: none;" class="current"><a href="http://2sao.net">
        <span>2 Sao</span></a></li>
    </ul>
  </div>
  <div id="sub_menu">
    <div id="menu0" class="menu_c1" style="display: block;">
      <a class="tdsk" href="/theodongsukien/">Theo dòng sự kiện</a>
      <asp:Repeater ID="rptTheodong" runat="server">
        <ItemTemplate>
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div id="menu1" class="menu_c" name="xahoi" style="display: none;" onmouseover="show(1,0)"
      onmouseout="hidden(1)">
      <a href="/vn/xa-hoi/phap-luat/index.html">Hình sự</a><a href="/vn/xa-hoi/ghi-tu-phap-dinh/index.html">Pháp
        đình</a> <a href="/vn/xa-hoi/doi-song/index.html">Đời sống</a> <a href="/vn/xa-hoi/chuyen-dong-tre/index.html">
          Chuyển động trẻ</a> <a href="/vn/suc-khoe/index.html">Sức khoẻ</a>
    </div>
    <div id="menu2" class="menu_c" name="giaoduc" style="display: none;" onmouseover="show(2,0)"
      onmouseout="hidden(2)">
      <a href="/vn/giao-duc/dien-dan/index.html">Diễn đàn</a><a href="/vn/giao-duc/chuyen-giang-duong/index.html">Giảng
        đường</a> <a href="/vn/giao-duc/nep-nha/index.html">Nếp nhà</a> <a href="/vn/giao-duc/du-hoc/index.html">
          Tư vấn du học </a>
    </div>
    <div id="menu3" class="menu_c" name="chinhtri" style="display: none;" onmouseover="show(3,0)"
      onmouseout="hidden(3)">
      <a href="/vn/chinh-tri/doi-noi/index.html">Đối nội</a> <a href="/vn/chinh-tri/doi-ngoai/index.html">
        Đối ngoại</a> <a href="http://daibieuquochoi.vietnamnet.vn" target="_blank">Đại biểu
          quốc hội</a> <a href="/vn/thoi-su-quoc-hoi/index.html">Thời sự Quốc hội</a>
      <a href="/vn/chinh-tri/chong-tham-nhung/index.html">Chống tham nhũng </a>
    </div>
    <div id="menu4" class="menu_c" name="phongsu" style="display: none;" onmouseover="show(4,240)"
      onmouseout="hidden(4)">
      <a href="/vn/phong-su-dieu-tra/phong-su-anh/index.html">Phóng sự ảnh</a> <a href="/vn/phong-su-dieu-tra/quoc-te/index.html">
        Phóng sự quốc tế</a>
    </div>
    <div id="menu5" class="menu_c" name="kinhte" style="display: none;" onmouseover="show(5,0)"
      onmouseout="hidden(5)">
      <a href="/vn/kinh-te/tai-chinh/index.html">Tài chính</a> <a href="/vn/kinh-te/kinh-doanh/index.html">
        Kinh doanh</a> <a href="/vn/kinh-te/thi-truong/index.html">Thị trường</a> <a href="/vn/dich-vu-truyen-thong/index.html">
          Thị trường - Tiêu dùng</a><a href="/vn/kinh-te/rao-vat/index.html">Rao vặt</a>
    </div>
    <div id="menu6" class="menu_c" name="quocte" style="display: none;" onmouseover="show(6,0)"
      onmouseout="hidden(6)">
      <a href="/vn/quoc-te/binh-luan/index.html">Bình luận quốc tế</a> <a href="/vn/quoc-te/nhan-vat-doi-thoai/index.html">
        Nhân vật và đối thoại</a> <a href="/vn/quoc-te/ho-so/index.html">Hồ sơ</a><a href="/vn/quoc-te/cuoi/index.html">Thế
          giới cười</a> <a href="/vn/quoc-te/the-gioi-do-day/index.html">Thế giới đó đây</a>
      <a href="/vn/quoc-te/vietnam-the-gioi/index.html">Việt Nam và thế giới</a>
    </div>
    <div id="menu7" class="menu_c" name="vanhoa" style="display: none;" onmouseover="show(7,430)"
      onmouseout="hidden(7)">
      <a href="/vn/van-hoa/tin-tuc/index.html">Tin tức</a> <a href="/vn/van-hoa/chuyen-de/index.html">
        Chuyên đề </a>
    </div>
    <div id="menu9" class="menu_c" name="khoahoc" style="display: none;" onmouseover="show(9,390)"
      onmouseout="hidden(9)">
      <a href="/vn/khoa-hoc/cong-nghe/index.html">Khoa học Công nghệ</a> <a href="/vn/khoa-hoc/moi-truong/index.html">
        Môi trường </a><a href="/vn/khoa-hoc/suc-khoe-gioi-tinh/index.html">Sức khỏe Giới
          tính</a>
    </div>
    <div id="menu10" class="menu_c" name="CNTT" style="display: none;" onmouseover="show(10,400)"
      onmouseout="hidden(10)">
      <a href="/vn/cong-nghe-thong-tin-vien-thong/xa-lo/index.html">Xa lộ thông tin</a>
      <a href="/vn/cong-nghe-thong-tin-vien-thong/the-gioi-so/index.html">Thế giới số</a>
      <a href="/vn/cong-nghe-thong-tin-vien-thong/vien-thong/index.html">Viễn thông</a>
      <a href="/vn/cong-nghe-thong-tin-vien-thong/virus-hacker/index.html">Virus - Hacker</a>
      <a href="/vn/cong-nghe-thong-tin-vien-thong/san-pham/index.html">Sản phẩm </a>
    </div>
    <div id="menu11" class="menu_c" name="bandoc" style="display: none;" onmouseover="show(11,450,1)"
      onmouseout="hidden(11)">
      <a href="/vn/ban-doc-phap-luat/chuyen-chung-chuyen-rieng/index.html">Chuyện chung-chuyện
        riêng</a> <a href="/vn/ban-doc-phap-luat/ngu-phap-tinh-yeu/index.html">Ngữ pháp tình
          yêu</a> <a href="/vn/ban-doc-phap-luat/chia-se/index.html">Chia sẻ-Hồi âm</a>
      <a href="/vn/ban-doc-phap-luat/moi-tinh/index.html">Những mối tình khác thường</a>
    </div>
    <div id="menu12" class="menu_c" name="tuanvn" style="display: none;">
    </div>
    <div id="menu13" class="menu_c" name="2sao" style="display: none;">
    </div>
    <div id="rss_search" style="display: block;">
      <div id="rss">
        <a class="rss_link" href="/vn/rss/index.html">RSS </a>
      </div>
      <div class="submit">
        <a href="#" onclick="search()">
          <img alt="" title="" src="/images/button_search.gif" width="56" height="14" onclick="search()" /></a></div>
      <div id="search">
        <input type="text" class="search_text" id="keywords" onkeydown="if (event.keyCode ==13) return false;"
          value="<%=KeyWords %>" /></div>
      <div class="clear">
        ,</div>
    </div>
    <div class="clear">
      ,</div>
  </div>
</div>
