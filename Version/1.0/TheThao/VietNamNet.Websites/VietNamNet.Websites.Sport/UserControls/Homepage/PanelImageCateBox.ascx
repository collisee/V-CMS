<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelImageCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Homepage.PanelImageCateBox" %>

<%--<script type="text/javascript">
$(document).ready(function(){
	$("#photoSlide").carouFredSel({
		auto : false,
		prev : {	
			button	: "#sukien_thethao_prev",
			key		: "left"
		},
		next : { 
			button	: "#sukien_thethao_next",
			key		: "right"
		},
		pagination	: "#sukien_thethao_pagination"
	});
});
</script>--%>

<div class="bbc-box">
  <div class="bbc-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="box-item-title">
      <a href="/vn/anh-the-thao/index.html">Ảnh Thể Thao</a></div>
    <div class="box-tga">
      <div class="tga-back">
        <a href="javascript:void(0)">
          <img src="http://res.vietnamnet.vn/sports/images/anh-back.gif" width="24" height="35" /></a>
      </div>
      <div class="tga-group">
        <div class="tga-item" id="photoSlide">
          <asp:Repeater ID="rptImageNews" runat="server">
            <ItemTemplate>
              <div class="box-anh">
                <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "ImageLink"), DataBinder.Eval(Container.DataItem, "Id"),
                      DataBinder.Eval(Container.DataItem, "Name"), "imgPreview", "none",
                        DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 213, 119)%>
                <div class="tga-link">
                  <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                      DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                </div>
              </div>
            </ItemTemplate>
          </asp:Repeater>
          <div class="tga-point">
            <a href="#">
              <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-red.gif"></a> <a href="#">
                <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-red.gif"></a> <a href="#">
                  <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-red.gif"></a> <a href="#">
                    <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-red.gif"></a> <a href="#">
                      <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-black.gif"></a> <a href="#">
                        <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-black.gif"></a> <a href="#">
                          <img height="10" width="11px" src="http://res.vietnamnet.vn/sports/images/point-black.gif"></a>
          </div>
          <br class="clear">
        </div>
      </div>
      <div class="tga-next">
        <a href="javascript:void(0)">
          <img src="http://res.vietnamnet.vn/sports/images/anh-next.gif" width="24" height="35" /></a>
      </div>
      <br class="clear" />
    </div>
  </div>
  <div class="bbc-bottom">
    &nbsp;</div>
</div>
