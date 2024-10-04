<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelOtherNews.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.News.PanelOtherNews" %>
<div id="article-others" class="row">
  <div class="tab-nav">
    <div class="content-more">
      Tin khác</div>
    <div class="clear">
      ,</div>
  </div>
  <div class="tab-content">
    <asp:Repeater ID="rptMore" runat="server">
      <ItemTemplate>
        <div class="item">
          <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
            class="title">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <%--<div class="item">
      <a class="title" title="Thú nhận tội lỗi của một người đàn bà ngoại tình" href="/xahoi/201004/Thu-nhan-toi-loi-cua-mot-nguoi-dan-ba-ngoai-tinh-906778/">
        Thú nhận tội lỗi của một người đàn bà ngoại tình</a>
    </div>
    <div class="item">
      <a class="title" title="Clip Thứ 4: Nổi máu giết người chỉ vì... bị nhìn đểu!" href="/truyenhinh/201004/Clip-Thu-4-Noi-mau-giet-nguoi-chi-vi-bi-nhin-deu-906798/">
        Clip Thứ 4: Nổi máu giết người chỉ vì... bị nhìn đểu!</a>
    </div>
    <div class="item">
      <a class="title" title="Clip Thứ 4:Khốn nạn, mẹ gặp con gái khỏa thân tại bar" href="/truyenhinh/201004/Clip-Thu-4Khon-nan-me-gap-con-gai-khoa-than-tai-bar-906795/">
        Clip Thứ 4:Khốn nạn, mẹ gặp con gái khỏa thân tại bar</a>
    </div>
    <div class="item">
      <a class="title" title="Người thổi hồn sống vào những đứa trẻ sinh ngày 30/4" href="/xahoi/201004/Nguoi-thoi-hon-song-vao-nhung-dua-tre-sinh-ngay-30/4-906770/">
        Người thổi hồn sống vào những đứa trẻ sinh ngày 30/4</a>
    </div>
    <div class="item">
      <a class="title" title="Chìm tàu Biển Đông, hàng trăm lít dầu tràn ra biển" href="/xahoi/201004/Chim-tau-Bien-Dong-hang-tram-lit-dau-tran-ra-bien-906721/">
        Chìm tàu Biển Đông, hàng trăm lít dầu tràn ra biển</a>
    </div>
    <div class="more">
      <a class="title" href="#" title="xem thêm tin khác">xem tiếp</a>
    </div>--%>
  </div>
</div>
