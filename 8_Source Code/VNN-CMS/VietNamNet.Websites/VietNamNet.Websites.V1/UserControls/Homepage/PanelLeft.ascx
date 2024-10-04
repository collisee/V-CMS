<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelLeft.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelLeft" %>
<%@ Register Src="PanelCategory1.ascx" TagName="PanelCategory1" TagPrefix="uc" %>
<%@ Register Src="PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<%@ Register Src="PanelAdvB_2.ascx" TagName="PanelAdvB_2" TagPrefix="uc" %>
<%@ Register Src="PanelAdvB_3.ascx" TagName="PanelAdvB_3" TagPrefix="uc" %>
<%@ Register Src="PanelSpecial2Sao.ascx" TagName="PanelSpecial2Sao" TagPrefix="uc" %>
<div class="home5left">
  <uc:PanelCategory ID="PanelCategory7" runat="server" CategoryAlias="chinh-tri" SubCategoryName="Thời sự Quốc hội;Đại biểu quốc hội" SubCategoryLink="/vn/thoi-su-quoc-hoi/index.html;http://daibieuquochoi.vietnamnet.vn/"/>
  <uc:PanelCategory ID="PanelCategory1" runat="server" CategoryAlias="xa-hoi" SubCategoryName="Pháp luật;Lao động;Đời sống;Blog Việt" SubCategoryLink="/vn/xa-hoi/phap-luat/index.html;/vn/xa-hoi/lao-dong/index.html;/vn/xa-hoi/doi-song/index.html;/vn/blog-viet/index.html" />
  <uc:PanelCategory ID="PanelCategory2" runat="server" CategoryAlias="phong-su-dieu-tra" />
  <uc:PanelCategory ID="PanelCategory8" runat="server" CategoryAlias="giao-duc" SubCategoryName="Diễn đàn;Tuyển sinh;Chuyện giảng đường" SubCategoryLink="/vn/giao-duc/dien-dan/index.html;/vn/giao-duc/tuyen-sinh/index.html;/vn/giao-duc/chuyen-giang-duong/index.html" />
  <uc:PanelAdvB_2 ID="PanelAdvB_2_1" runat="server" />
  <uc:PanelCategory ID="PanelCategory9" runat="server" CategoryAlias="kinh-te" SubCategoryName="Rao vặt;Kinh doanh;Tài chính" SubCategoryLink="/vn/kinh-te/rao-vat/index.html;/vn/kinh-te/kinh-doanh/index.html;/vn/kinh-te/tai-chinh/index.html" />
  <uc:PanelCategory ID="PanelCategory3" runat="server" CategoryAlias="quoc-te" SubCategoryName="Hồ sơ;Bình luận quốc tế" SubCategoryLink="/vn/quoc-te/ho-so/index.html;/vn/quocte/binh-luan-quoc-te/index.html" />
  <uc:PanelCategory ID="PanelCategory4" runat="server" CategoryAlias="van-hoa"  SubCategoryName="Hòa giải & Yêu thương;Giải trí Sao;Chuyên đề;Tin tức"  SubCategoryLink="/vn/van-hoa/hoa-giai-yeu-thuong/index.html;/vn/van-hoa/giai-tri-sao/index.html;/vn/van-hoa/chuyen-de/index.html;/vn/van-hoa/tin-tuc/index.html" />
  <uc:PanelCategory ID="PanelCategory5" runat="server" CategoryAlias="the-thao" SubCategoryName="BBC Giải bóng đá Premiership" SubCategoryLink="http://thethao.vietnamnet.vn/vn/bbc-tieng-viet/index.html" />
  <uc:PanelAdvB_3 ID="PanelAdvB_3_1" runat="server" />
  <uc:PanelCategory ID="PanelCategory6" runat="server" CategoryAlias="chuyen-trang-oto-xemay" />
  <uc:PanelCategory ID="PanelCategory10" runat="server" CategoryAlias="cong-nghe-thong-tin-vien-thong" SubCategoryName="Tiêu điểm;Sản phẩm;Thế giới số" SubCategoryLink="/vn/cong-nghe-thong-tin-vien-thong/tieu-diem/index.html;/vn/cong-nghe-thong-tin-vien-thong/san-pham/index.html;/vn/cong-nghe-thong-tin-vien-thong/the-gioi-so/index.html" />
  <uc:PanelCategory ID="PanelCategory11" runat="server" CategoryAlias="khoa-hoc" SubCategoryName="Khoa học - Công nghệ;Môi trường;Sức khỏe - Giới tính" SubCategoryLink="/vn/khoa-hoc/khcn/index.html;/vn/khoa-hoc/moi-truong/index.html;/vn/khoa-hoc/suc-khoe/index.html" />
  <uc:PanelCategory ID="PanelCategory12" runat="server" CategoryAlias="ban-doc-phap-luat" SubCategoryName="Tiếng nói người dân;Chia sẻ;Hồi âm" SubCategoryLink="/vn/ban-doc-phap-luat/tieng-noi-nguoi-dan/index.html;/vn/ban-doc-phap-luat/chia-se/index.html;/vn/ban-doc-phap-luat/hoi-am/index.html" />
</div>