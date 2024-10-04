<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMenu.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.PanelMenu" %>
<div class="hnavBox">
  <ul class="hnavVNN">
    <li alias="trang-chu" class="current"><a class="item" href="/vn/index.html"><b>Trang
      chủ</b></a></li>
    <li alias="xa-hoi"><a class="item" href="/vn/xa-hoi/index.html"><b>Xã hội</b></a></li>
    <li alias="giao-duc"><a class="item" href="/vn/giao-duc/index.html"><b>Giáo dục</b></a></li>
    <li alias="chinh-tri"><a class="item" href="/vn/chinh-tri/index.html"><b>Chính trị</b></a></li>
    <li alias="phong-su-dieu-tra"><a class="item" href="/vn/phong-su-dieu-tra/index.html">
      <b>Phóng sự điều tra</b></a></li>
    <li alias="kinh-te"><a class="item" href="/vn/kinh-te/index.html"><b>Thị trường</b></a></li>
    <li alias="quoc-te"><a class="item" href="/vn/quoc-te/index.html"><b>Quốc tế</b></a></li>
    <li alias="van-hoa"><a class="item" href="/vn/van-hoa/index.html"><b>Văn hóa</b></a></li>
    <li alias="khoa-hoc"><a class="item" href="/vn/khoa-hoc/index.html"><b>Khoa học</b></a></li>
    <li alias="cong-nghe-thong-tin-vien-thong"><a class="item" href="/vn/cong-nghe-thong-tin-vien-thong/index.html">
      <b>CNTT-Viễn thông</b></a></li>
    <li alias="ban-doc-phap-luat"><a class="item" href="/vn/ban-doc-phap-luat/index.html">
      <b>Bạn đọc</b></a></li>
    <li alias="external-1"><a class="item" href="http://tuanvietnam.net" target="_blank">
      <b>Tuần VN</b></a></li>
    <li alias="external-2"><a class="item" href="http://2sao.net" target="_blank"><b>2
      Sao</b></a></li>
    <li alias="external-3" id="hnavVNN_lastItem"><a class="item" href="http://english.vietnamnet.vn/"
      target="_blank"><b>English</b></a></li>
  </ul>
  <div class="hnavSUB" alias="trang-chu">
    <a href="/vn/theo-dong-su-kien/index.html" class="tdsk_new">Theo dòng sự kiện</a>
    <asp:Repeater ID="rptTheodong" runat="server">
      <ItemTemplate>
        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
    DataBinder.Eval(Container.DataItem, "Name"), "focus", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
      </ItemTemplate>
    </asp:Repeater>
  </div>
  <div class="hnavSUB" alias="xa-hoi">
    <a href="/vn/xa-hoi/phap-luat/index.html">Hình sự</a> <a href="/vn/xa-hoi/ghi-tu-phap-dinh/index.html">
      Pháp đình</a> <a href="/vn/xa-hoi/doi-song/index.html">Đời sống</a> <a href="/vn/xa-hoi/chuyen-dong-tre/index.html">
        Chuyển động trẻ</a><a href="/vn/hop-tac-suc-khoe/index.html">Sức khoẻ</a> <a href="/vn/xa-hoi/tieu-diem/index.html"
          style="display: none; width: 0px;">Tiêu điểm</a> <a href="/vn/xa-hoi/dong-su-kien/index.html"
            style="display: none; width: 0px;">Dòng sự kiện</a>
  </div>
  <div class="hnavSUB" alias="giao-duc">
    <a href="/vn/giao-duc/dien-dan/index.html">Diễn đàn</a><a href="/vn/giao-duc/chuyen-giang-duong/index.html">Giảng
      đường</a> <a href="/vn/giao-duc/nep-nha/index.html">Nếp nhà</a> <a href="/vn/giao-duc/du-hoc/index.html">
        Tư vấn du học </a><a href="/vn/giao-duc/tieu-diem/index.html" style="display: none;
          width: 0px;">Tiêu điểm</a> <a href="/vn/giao-duc/dong-su-kien/index.html" style="display: none;
            width: 0px;">Dòng sự kiện</a>
  </div>
  <div class="hnavSUB" alias="chinh-tri">
    <a href="/vn/chinh-tri/doi-noi/index.html">Đối nội</a> <a href="/vn/chinh-tri/doi-ngoai/index.html">
      Đối ngoại</a> <a href="http://daibieuquochoi.vietnamnet.vn" target="_blank">Đại biểu
        quốc hội</a> <a href="/vn/thoi-su-quoc-hoi/index.html">Thời sự Quốc hội</a>
    <a href="/vn/chinh-tri/chong-tham-nhung/index.html">Chống tham nhũng </a><a href="/vn/chinh-tri/tieu-diem/index.html"
      style="display: none; width: 0px;">Tiêu điểm</a> <a href="/vn/chinh-tri/dong-su-kien/index.html"
        style="display: none; width: 0px;">Dòng sự kiện</a>
  </div>
  <div class="hnavSUB" alias="phong-su-dieu-tra">
    <a href="/vn/phong-su-dieu-tra/phong-su-anh/index.html">Phóng sự ảnh</a> <a href="/vn/phong-su-dieu-tra/quoc-te/index.html">
      Phóng sự quốc tế</a>
  </div>
  <div class="hnavSUB" alias="kinh-te">
    <a href="/vn/kinh-te/tai-chinh/index.html">Tài chính</a> <a href="/vn/kinh-te/kinh-doanh/index.html">
      Kinh doanh</a> <a href="/vn/kinh-te/thi-truong/index.html">Thị trường</a> <a href="/vn/dich-vu-truyen-thong/index.html">
        Thị trường - Tiêu dùng</a><a href="/vn/kinh-te/rao-vat/index.html">Rao vặt</a>
  </div>
  <div class="hnavSUB" alias="quoc-te">
    <a href="/vn/quoc-te/binh-luan/index.html">Bình luận quốc tế</a> <a href="/vn/quoc-te/nhan-vat-doi-thoai/index.html">
      Nhân vật và đối thoại</a> <a href="/vn/quoc-te/ho-so/index.html">Hồ sơ</a><a href="/vn/quoc-te/cuoi/index.html">Thế
        giới cười</a> <a href="/vn/quoc-te/the-gioi-do-day/index.html">Thế giới đó đây</a>
    <a href="/vn/quoc-te/vietnam-the-gioi/index.html">Việt Nam và thế giới</a> <a href="/vn/quoc-te/tieu-diem/index.html"
      style="display: none; width: 0px;">Tiêu điểm</a>
  </div>
  <div class="hnavSUB" alias="van-hoa">
    <a href="/vn/van-hoa/tin-tuc/index.html">Tin tức</a> <a href="/vn/van-hoa/chuyen-de/index.html">
      Chuyên đề </a><a href="/vn/van-hoa/tieu-diem/index.html" style="display: none; width: 0px;">
        Tiêu điểm</a> <a href="/vn/van-hoa/giai-tri-sao/index.html" style="display: none;
          width: 0px;">Giải trí sao</a>
  </div>
  <div class="hnavSUB" alias="khoa-hoc">
    <a href="/vn/khoa-hoc/cong-nghe/index.html">Khoa học Công nghệ</a> <a href="/vn/khoa-hoc/moi-truong/index.html">
      Môi trường </a><a href="/vn/khoa-hoc/suc-khoe-gioi-tinh/index.html">Sức khỏe Giới
        tính</a> <a href="/vn/khoa-hoc/trong-nuoc/index.html" style="display: none; width: 0px;">
          Trong nước</a> <a href="/vn/khoa-hoc/tieu-diem/index.html" style="display: none;
            width: 0px;">Quốc tế</a> <a href="/vn/khoa-hoc/tieu-diem/index.html" style="display: none;
              width: 0px;">Tiêu điểm</a>
  </div>
  <div class="hnavSUB" alias="cong-nghe-thong-tin-vien-thong">
    <a href="/vn/cong-nghe-thong-tin-vien-thong/xa-lo/index.html">Xa lộ thông tin</a>
    <a href="/vn/cong-nghe-thong-tin-vien-thong/the-gioi-so/index.html">Thế giới số</a>
    <a href="/vn/cong-nghe-thong-tin-vien-thong/vien-thong/index.html">Viễn thông</a>
    <a href="/vn/cong-nghe-thong-tin-vien-thong/virus-hacker/index.html">Virus - Hacker</a>
    <a href="/vn/cong-nghe-thong-tin-vien-thong/san-pham/index.html">Sản phẩm </a><a
      href="/vn/cong-nghe-thong-tin-vien-thong/tieu-diem/index.html" style="display: none;
      width: 0px;">Tiêu điểm</a>
  </div>
  <div class="hnavSUB" alias="ban-doc-phap-luat">
    <a href="/vn/ban-doc-phap-luat/chuyen-chung-chuyen-rieng/index.html">Chuyện chung-chuyện
      riêng</a> <a href="/vn/ban-doc-phap-luat/ngu-phap-tinh-yeu/index.html">Ngữ pháp tình
        yêu</a> <a href="/vn/ban-doc-phap-luat/chia-se/index.html">Chia sẻ-Hồi âm</a>
    <a href="/vn/ban-doc-phap-luat/moi-tinh/index.html">Những mối tình khác thường</a>
  </div>
  <div class="hnavSUB" alias="external-1">
  </div>
  <div class="hnavSUB" alias="external-2">
  </div>
  <div class="hnavSUB" alias="external-3">
  </div>
  <div class="rss_search_new_box hnavSUBRight clearfix">
    <div class="search_new_box">
      <input type="text" class="search-top-button search_text input-search" watermark="Search.."
        onkeydown="searchkey(event,this)" id="keywords2" />
      <a href="javascript: search();">&nbsp;</a>
    </div>
    <a href="/vn/rss/index.html" class="rss_link_new">RSS</a>
  </div>
  <!-- [rss_search_new_box] -->
</div>

<script type="text/javascript" language="javascript">
  menuCurrentAlias = '<%=categoryAlias %>';
</script>

