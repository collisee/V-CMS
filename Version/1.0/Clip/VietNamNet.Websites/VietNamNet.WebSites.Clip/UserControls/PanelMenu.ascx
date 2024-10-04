<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMenu.ascx.cs" Inherits="VietNamNet.Websites.Clip.UserControls.PanelMenu" %>
<div id="menu">
  <div id="menu-primary">
    <ul class="glossymenu">
      <li id="mn1_a" style="display: block" class="current"><a href="http://vietnamnet.vn/">
        <span>Trang chủ</span></a></li>
      <li id="mn1_b" style="display: none;"><a href="http://vietnamnet.vn/"><span>Trang
        chủ</span></a></li>
      <li id="mn1_1a"><a href="http://vietnamnet.vn/xa-hoi/" onmouseover="show(1,0)" onmouseout="hidden(1)">
        <span>Xã hội</span></a></li>
      <li id="mn1_1b" style="display: none;" class="current"><a href="http://vietnamnet.vn/xahoi/"
        onmouseover="show(1,0)" onmouseout="hidden(1)"><span>Xã hội</span></a></li>
      <li id="mn1_2a"><a href="http://vietnamnet.vn/giaoduc/" onmouseover="show(2,0)" onmouseout="hidden(2)">
        <span>Giáo dục</span></a></li>
      <li id="mn1_2b" style="display: none;" class="current"><a href="http://vietnamnet.vn/giaoduc/"
        onmouseover="show(2,0)" onmouseout="hidden(2)"><span>Giáo dục</span></a></li>
      <li id="mn1_3a"><a href="http://vietnamnet.vn/chinhtri/" onmouseover="show(3,0)"
        onmouseout="hidden(3)"><span>Chính trị</span></a></li>
      <li id="mn1_3b" style="display: none;" class="current"><a href="http://vietnamnet.vn/chinhtri/"
        onmouseover="show(3,0)" onmouseout="hidden(3)"><span>Chính trị</span></a></li>
      <li id="mn1_4a"><a href="http://vietnamnet.vn/psks/" onmouseover="show(4,0)" onmouseout="hidden(4)">
        <span>Phóng sự điều tra</span></a></li>
      <li id="mn1_4b" style="display: none;" class="current"><a href="http://vietnamnet.vn/psks/"
        onmouseover="show(4,0)" onmouseout="hidden(4)"><span>Phóng sự điều tra</span></a></li>
      <li id="mn1_5a"><a href="http://vietnamnet.vn/kinhte/" onmouseover="show(5,0)" onmouseout="hidden(5)">
        <span>Kinh tế</span></a></li>
      <li id="mn1_5b" style="display: none;" class="current"><a href="http://vietnamnet.vn/kinhte/"
        onmouseover="show(5,0)" onmouseout="hidden(5)"><span>Kinh tế</span></a></li>
      <li id="mn1_6a"><a href="http://vietnamnet.vn/quocte/" onmouseover="show(6,0)" onmouseout="hidden(6)">
        <span>Quốc tế</span></a></li>
      <li id="mn1_6b" style="display: none;" class="current"><a href="http://vietnamnet.vn/thegioi/"
        onmouseover="show(6,0)" onmouseout="hidden(6)"><span>Quốc tế</span></a></li>
      <li id="mn1_7a"><a href="http://vietnamnet.vn/vanhoa/" onmouseover="show(7,400)"
        onmouseout="hidden(7)"><span>Văn hóa</span></a></li>
      <li id="mn1_7b" style="display: none;" class="current"><a href="http://vietnamnet.vn/vanhoa/"
        onmouseover="show(7,400)" onmouseout="hidden(7)"><span>Văn hóa</span></a></li>
      <li id="mn1_9a"><a href="http://vietnamnet.vn/khoahoc/" onmouseover="show(9,290)"
        onmouseout="hidden(9)"><span>Khoa học</span></a></li>
      <li id="mn1_9b" style="display: none;" class="current"><a href="http://vietnamnet.vn/khoahoc/"
        onmouseover="show(9,290)" onmouseout="hidden(9)"><span>Khoa học</span></a></li>
      <li id="mn1_10a"><a href="http://vietnamnet.vn/cntt/" onmouseover="show(10,280)"
        onmouseout="hidden(10)"><span>CNTT - Viến thông</span></a></li>
      <li id="mn1_10b" style="display: none;" class="current"><a href="http://vietnamnet.vn/cntt/"
        onmouseover="show(10,280)" onmouseout="hidden(10)"><span>CNTT - Viến thông</span></a></li>
      <li id="mn1_11a"><a href="http://vietnamnet.vn/bandocviet/" onmouseover="show(11,450,1)"
        onmouseout="hidden(11)"><span>Bạn đọc</span></a></li>
      <li id="mn1_11b" style="display: none;" class="current"><a href="http://vietnamnet.vn/bandocviet/"
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
      <a class="tdsk" href="http://vietnamnet.vn/theodongsukien">Theo dòng sự kiện</a>
      <asp:Repeater ID="rptTheodong" runat="server">
        <ItemTemplate>
          <a href="http://vietnamnet.vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div id="menu1" class="menu_c" name="xahoi" style="display: none;" onmouseover="show(1,0)"
      onmouseout="hidden(1)">
      <a href="http://vietnamnet.vn/xahoi/phapluat/">Hình sự </a><a href="http://vietnamnet.vn/xahoi/phapdinh/">
        Pháp đình</a> <a href="http://vietnamnet.vn/xahoi/doisong/">Đời sống</a> <a href="http://vietnamnet.vn/xahoi/chuyendongtre/">
          Chuyển động trẻ </a><a href="http://vietnamnet.vn/suckhoe/">Sức khỏe</a>
    </div>
    <div id="menu2" class="menu_c" name="giaoduc" style="display: none;" onmouseover="show(2,0)"
      onmouseout="hidden(2)">
      <a href="http://vietnamnet.vn/giaoduc/diendan/">Diễn đàn</a> <a href="http://vietnamnet.vn/giaoduc/chuyengiangduong/">
        Giảng đường </a><a href="http://vietnamnet.vn/giaoduc/nepnha/">Nếp nhà </a><a href="http://vietnamnet.vn/giaoduc/tuvan/">
          Tư vấn</a>
    </div>
    <div id="menu3" class="menu_c" name="chinhtri" style="display: none;" onmouseover="show(3,0)"
      onmouseout="hidden(3)">
      <a href="http://vietnamnet.vn/chinhtri/doinoi/">Đối nội</a> <a href="http://vietnamnet.vn/chinhtri/doingoai/">
        Đối ngoại </a><a href="http://daibieuquochoi.vietnamnet.vn" target="_blank">Đại
          biểu quốc hội </a><a href="http://vietnamnet.vn/thoisuquochoi/">Thời sự Quốc
            hội </a><a href="http://vietnamnet.vn/chinhtri/chongthamnhung/">Chống tham nhũng
            </a>
    </div>
    <div id="menu4" class="menu_c" name="phongsu" style="display: none;" onmouseover="show(4,210)"
      onmouseout="hidden(4)">
      <a href="http://vietnamnet.vn/psks/anh/">Phóng sự ảnh </a><a href="http://vietnamnet.vn/psks/quocte/">
        Phóng sự quốc tế </a>
    </div>
    <div id="menu5" class="menu_c" name="kinhte" style="display: none;" onmouseover="show(5,0)"
      onmouseout="hidden(5)">
      <a href="http://vietnamnet.vn/kinhte/kinhdoanh/">Kinh doanh</a> <a href="http://vietnamnet.vn/kinhte/thitruong/">
        Thị trường </a><a href="http://vietnamnet.vn/dichvutruyenthong//">Thị trường -
          Tiêu dùng </a><a href="http://vietnamnet.vn/kinhte/raovat/">Rao vặt </a>
    </div>
    <div id="menu6" class="menu_c" name="quocte" style="display: none;" onmouseover="show(6,0)"
      onmouseout="hidden(6)">
      <a href="http://vietnamnet.vn/thegioi/tinanh/">Tin ảnh </a><a href="http://vietnamnet.vn/thegioi/binhluan/">
        Bình luận</a> <a href="http://vietnamnet.vn/thegioi/hoso/">Hồ sơ </a><a href="http://vietnamnet.vn/thegioi/doday/">
          Thế giới đó đây</a> <a href="http://vietnamnet.vn/thegioi/vn_tg/">Việt Nam và
            thế giới </a>
    </div>
    <div id="menu7" class="menu_c" name="vanhoa" style="display: none;" onmouseover="show(7,430)"
      onmouseout="hidden(7)">
      <a href="http://vietnamnet.vn/vanhoa/giaitri/">Giải trí</a> <a href="http://vietnamnet.vn/vanhoa/tintuc/">
        Tin tức </a><a href="http://vietnamnet.vn/vanhoa/chuyende/">Chuyên đề </a>
    </div>
    <div id="menu9" class="menu_c" name="khoahoc" style="display: none;" onmouseover="show(9,390)"
      onmouseout="hidden(9)">
      <a href="http://vietnamnet.vn/khoahoc/event/12040/">Khoa học Công nghệ 2010</a>
      <a href="http://vietnamnet.vn/khoahoc/moitruong/">Môi trường</a> <a href="http://vietnamnet.vn/khoahoc/gioitinh/">
        Sức khỏe Giới tính</a>
    </div>
    <div id="menu10" class="menu_c" name="CNTT" style="display: none;" onmouseover="show(10,310)"
      onmouseout="hidden(10)">
      <a href="http://vietnamnet.vn/cntt/xalo/">Xa lộ thông tin</a> <a href="http://vietnamnet.vn/cntt/thegioiso/">
        Thế giới số </a><a href="http://vietnamnet.vn/cntt/vienthong/">Viễn thông </a>
      <a href="http://vietnamnet.vn/cntt/virus-hacker/">Virus - Hacker</a> <a href="http://vietnamnet.vn/cntt/doanhnghiep/">
        Sản phẩm </a>
    </div>
    <div id="menu11" class="menu_c" name="bandoc" style="display: none;" onmouseover="show(11,450,1)"
      onmouseout="hidden(11)">
      <a href="http://vietnamnet.vn/bandocviet/riengchung/">Chuyện chung-chuyện riêng </a>
      <a href="http://vietnamnet.vn/bandocviet/tinhyeu/">Ngữ pháp tình yêu</a> <a href="http://vietnamnet.vn/bandocviet/chiase/">
        Chia sẻ-Hồi âm</a> <a href="http://vietnamnet.vn/bandocviet/moitinh/">Những mối tình
          khác thường</a>
    </div>
    <div id="menu12" class="menu_c" name="tuanvn" style="display: none;">
    </div>
    <div id="menu13" class="menu_c" name="2sao" style="display: none;">
    </div>
    <div id="rss_search" style="display: block;">
      <div id="rss">
        <a class="rss_link" href="#">RSS </a>
      </div>
      <div class="submit">
       <a href="#" onclick="search()">
          <img alt="" title="" src="/images/button_search.gif" width="56" height="14" onclick="search()" /></a></div>
      <div id="search">
       <input type="text" class="search_text input-search" watermark="Search.." onkeydown="searchkey(event,this)"
      id="keywords2" /></div>
      <div class="clear">
        ,</div>
    </div>
    <div class="clear">
      ,</div>
  </div>
</div>
<div class="search-top">
    
    <a href="#" onclick="search()">
      <img alt="" title="" src="http://res.vietnamnet.vn/images/blank.gif" width="16" height="13"
        onclick="search()" /></a>
  </div>