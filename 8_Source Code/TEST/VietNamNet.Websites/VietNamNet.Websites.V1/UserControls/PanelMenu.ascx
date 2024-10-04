<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMenu.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.PanelMenu" %>
<div id="menu">
  <div id="menu-primary">
    <ul class="glossymenu">
      <li id="mn1_a" style="display: block" class="current"><a href="/vn/index.html">
        <span>Trang chủ</span></a></li>
      <li id="mn1_b" style="display: none;"><a href="/vn/index.html"><span>Trang
        chủ</span></a></li>
      <li id="mn1_1a"><a href="/vn/xa-hoi/" onmouseover="show(1,0)" onmouseout="hidden(1)"><span>
        Xã hội</span></a></li>
      <li id="mn1_1b" style="display: none;" class="current"><a href="/vn/xa-hoi/index.html" onmouseover="show(1,0)"
        onmouseout="hidden(1)"><span>Xã hội</span></a></li>
      <li id="mn1_2a"><a href="/giaoduc/" onmouseover="show(2,0)" onmouseout="hidden(2)">
        <span>Giáo dục</span></a></li>
      <li id="mn1_2b" style="display: none;" class="current"><a href="/vn/giao-duc/index.html" onmouseover="show(2,0)"
        onmouseout="hidden(2)"><span>Giáo dục</span></a></li>
      <li id="mn1_3a"><a href="/chinhtri/" onmouseover="show(3,0)" onmouseout="hidden(3)">
        <span>Chính trị</span></a></li>
      <li id="mn1_3b" style="display: none;" class="current"><a href="/vn/chinh-tri/index.html" onmouseover="show(3,0)"
        onmouseout="hidden(3)"><span>Chính trị</span></a></li>
      <li id="mn1_4a"><a href="/psks/" onmouseover="show(4,0)" onmouseout="hidden(4)"><span>
        Phóng sự điều tra</span></a></li>
      <li id="mn1_4b" style="display: none;" class="current"><a href="/vn/phong-su-dieu-tra/index.html" onmouseover="show(4,0)"
        onmouseout="hidden(4)"><span>Phóng sự điều tra</span></a></li>
      <li id="mn1_5a"><a href="/kinhte/" onmouseover="show(5,0)" onmouseout="hidden(5)">
        <span>Kinh tế</span></a></li>
      <li id="mn1_5b" style="display: none;" class="current"><a href="/vn/kinh-te/index.html" onmouseover="show(5,0)"
        onmouseout="hidden(5)"><span>Kinh tế</span></a></li>
      <li id="mn1_6a"><a href="/quocte/" onmouseover="show(6,0)" onmouseout="hidden(6)">
        <span>Quốc tế</span></a></li>
      <li id="mn1_6b" style="display: none;" class="current"><a href="/vn/quoc-te/index.html" onmouseover="show(6,0)"
        onmouseout="hidden(6)"><span>Quốc tế</span></a></li>
      <li id="mn1_7a"><a href="/vanhoa/" onmouseover="show(7,400)" onmouseout="hidden(7)">
        <span>Văn hóa</span></a></li>
      <li id="mn1_7b" style="display: none;" class="current"><a href="/vn/van-hoa/index.html" onmouseover="show(7,400)"
        onmouseout="hidden(7)"><span>Văn hóa</span></a></li>
      <li id="mn1_9a"><a href="/khoahoc/" onmouseover="show(9,290)" onmouseout="hidden(9)">
        <span>Khoa học</span></a></li>
      <li id="mn1_9b" style="display: none;" class="current"><a href="/vn/khoa-hoc/index.html" onmouseover="show(9,290)"
        onmouseout="hidden(9)"><span>Khoa học</span></a></li>
      <li id="mn1_10a"><a href="/cntt/" onmouseover="show(10,280)" onmouseout="hidden(10)">
        <span>CNTT - Viến thông</span></a></li>
      <li id="mn1_10b" style="display: none;" class="current"><a href="/vn/cong-nghe-thong-tin-vien-thong/index.html" onmouseover="show(10,280)"
        onmouseout="hidden(10)"><span>CNTT - Viến thông</span></a></li>
      <li id="mn1_11a"><a href="/bandocviet/" onmouseover="show(11,450,1)" onmouseout="hidden(11)">
        <span>Bạn đọc</span></a></li>
      <li id="mn1_11b" style="display: none;" class="current"><a href="/vn/ban-doc-phap-luat/index.html" onmouseover="show(11,450,1)"
        onmouseout="hidden(11)"><span>Bạn đọc</span></a></li>
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
      <a class="tdsk" href="#">Theo dòng sự kiện</a>
      <asp:Repeater ID="rptTheodong" runat="server">
        <ItemTemplate>
          <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div id="menu1" class="menu_c" name="xahoi" style="display: none;" onmouseover="show(1,0)"
      onmouseout="hidden(1)">
      <a href="/xahoi/doisong/">Đời sống</a> <a href="/vn/xa-hoi/phap-luat/index.html">Pháp luật</a>
      <a href="/xahoi/dothi/">Đô thị</a> <a href="/vn/xa-hoi/lao-dong/index.html">Lao động</a> <a href="/xahoi/giaothong/">
        Giao thông</a> <a href="/vn/xa-hoi/suc-khoe/index.html">Sức khoẻ</a>
    </div>
    <div id="menu2" class="menu_c" name="giaoduc" style="display: none;" onmouseover="show(2,0)"
      onmouseout="hidden(2)">
      <a href="/vn/giao-duc/van-de/index.html">Vấn đề</a> <a href="/vn/giao-duc/tuyen-sinh/index.html">Tuyển sinh</a>
      <a href="/vn/giao-duc/chuyen-giang-duong/index.html">Chuyện giảng đường </a>
    </div>
    <div id="menu3" class="menu_c" name="chinhtri" style="display: none;" onmouseover="show(3,0)"
      onmouseout="hidden(3)">
      <a href="/vn/chinh-tri/doi-noi/index.html">Đối nội</a> <a href="/vn/chinh-tri/doi-ngoai/index.html">Đối ngoại</a>
      <a href="http://daibieuquochoi.vietnamnet.vn">Đại biểu quốc hội</a> <a href="/thoisuquochoi/">
        Thời sự Quốc hội</a> <a href="/vn/chinh-tri/chong-tham-nhung/index.html">Chống tham nhũng </a>
    </div>
    <div id="menu4" class="menu_c" name="phongsu" style="display: none;" onmouseover="show(4,0)"
      onmouseout="hidden(4)">
    </div>
    <div id="menu5" class="menu_c" name="kinhte" style="display: none;" onmouseover="show(5,0)"
      onmouseout="hidden(5)">
      <a href="/vn/kinh-te/chinh-sach/index.html">Chính sách</a> <a href="/vn/kinh-te/tai-chinh/index.html">Tài chính</a>
      <a href="/vn/kinh-te/kinh-doanh/index.html">Kinh doanh</a> <a href="/vn/kinh-te/thi-truong/index.html">Thị trường</a>
      <a href="http://vnr500.vietnamnet.vn">Diễn đàn VNR500</a> <a href="/vn/dich-vu-truyen-thong/index.html">
        Thị trường - Tiêu dùng</a>
    </div>
    <div id="menu6" class="menu_c" name="quocte" style="display: none;" onmouseover="show(6,0)"
      onmouseout="hidden(6)">
      <a href="/quocte/giaitri/">Giải trí</a> <a href="/quocte/binhluan/">Bình luận quốc
        tế</a> <a href="/quocte/nhanvat/">Nhân vật và đối thoại</a> <a href="/quocte/hoso/">
          Hồ sơ</a> <a href="/quocte/cuoi/">Thế giới cười</a> <a href="/quocte/doday/">Thế giới
            đó đây</a> <a href="/quocte/vn_tg/">Việt Nam và thế giới </a>
    </div>
    <div id="menu7" class="menu_c" name="vanhoa" style="display: none;" onmouseover="show(7,430)"
      onmouseout="hidden(7)">
      <a href="/vanhoa/giaitri/">Giải trí</a> <a href="/vanhoa/tintuc/">Tin tức</a> <a
        href="/vanhoa/chuyende/">Chuyên đề </a>
    </div>
    <div id="menu9" class="menu_c" name="khoahoc" style="display: none;" onmouseover="show(9,390)"
      onmouseout="hidden(9)">
      <a href="/khoahoc/dinhduong/">Dinh dưỡng</a> <a href="/khoahoc/gioitinh/">Giới tính</a>
      <a href="/khoahoc/hosotulieu/">Hồ sơ - Tư liệu</a> <a href="/khoahoc/moituong/">Môi
        trường </a>
    </div>
    <div id="menu10" class="menu_c" name="CNTT" style="display: none;" onmouseover="show(10,400)"
      onmouseout="hidden(10)">
      <a href="/cntt/xalo/">Xa lộ thông tin</a> <a href="/cntt/thegioiso/">Thế giới số</a>
      <a href="/cntt/vienthong/">Viễn thông</a> <a href="/cntt/virus-hacker/">Virus - Hacker</a>
      <a href="/cntt/doanhnghiep/">Sản phẩm </a>
    </div>
    <div id="menu11" class="menu_c" name="bandoc" style="display: none;" onmouseover="show(11,450,1)"
      onmouseout="hidden(11)">
      <a href="/bandocviet/theodauthu/">Điều tra theo thư bạn đọc</a> <a href="/bandocviet/bandocviet/">
        Bạn đọc viết</a> <a href="/bandocviet/chiase/">Chia sẻ</a> <a href="/bandocviet/riengchung/">
          Tâm tình</a> <a href="/bandocviet/hoiam/">Hồi âm</a>
    </div>
    <div id="menu12" class="menu_c" name="tuanvn" style="display: none;">
    </div>
    <div id="menu13" class="menu_c" name="2sao" style="display: none;">
    </div>
    <div id="rss_search" style="display: block;">
      <div id="rss">
        <a class="rss_link" href="#">RSS </a>
      </div>
      <div class="submit"><a href="#"  onclick="search()" >
        <img alt="" title="" src="/images/button_search.gif" width="56" height="14" onclick="search()"   /></a></div>
      <div id="search">
        <input type="text" class="search_text" id="keywords" onkeydown="if (event.keyCode ==13) return false;" value="<%=KeyWords %>" /></div>
      <div class="clear">
        ,</div>
    </div>
    <div class="clear">
      ,</div>
  </div>
</div>
