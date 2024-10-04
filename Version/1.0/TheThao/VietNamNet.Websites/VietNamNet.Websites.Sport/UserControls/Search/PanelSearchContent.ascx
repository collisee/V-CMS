<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelSearchContent.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.Search.PanelSearchContent" %>

 
				<div class="cate-list">
					<div class="cate-list-top">&nbsp;</div>
					<div class="pdlr5">
						<div class="patway-search">
							Tìm Kiếm 
						</div>
						
						<div class="search-form">
							<div class="text">
								Từ khóa : 
							</div> 
							<input class="key-search" id="skeywords" name="skeywords" type="text" value="<%=SearchKeyword %>"/>
							<br class="clear" />
							<div class="text">
								Danh mục tin : 
							</div> 
				<select id="scat" name="scat"  class="select-search" >
                    <option value="">Tất cả</option>
                    <option value="xa-hoi" <%=CategoryAlias=="xa-hoi"?"selected":"" %>>Xã hội</option>
                    <option value="giao-duc" <%=CategoryAlias=="giao-duc"?"selected":"" %>>Giáo dục</option>
                    <option value="chinh-tri" <%=CategoryAlias=="chinh-tri"?"selected":"" %>>Chính trị</option>
                    <option value="phong-su-dieu-tra" <%=CategoryAlias=="phong-su-dieu-tra"?"selected":"" %>>Phóng sự điều tra</option>
                    <option value="kinh-te" <%=CategoryAlias=="kinh-te"?"selected":"" %>>Thị trường</option>
                    <option value="quoc-te" <%=CategoryAlias=="quoc-te"?"selected":"" %>>Quốc tế</option>
                    <option value="van-hoa" <%=CategoryAlias=="van-hoa"?"selected":"" %>>Văn hóa</option>
                    <option value="khoa-hoc" <%=CategoryAlias=="khoa-hoc"?"selected":"" %>>Khoa học</option>
                    <option value="cong-nghe-thong-tin-vien-thong" <%=CategoryAlias=="cong-nghe-thong-tin-vien-thong"?"selected":"" %>>CNTT - Viến thông</option>
                    <option value="ban-doc-phap-luat" <%=CategoryAlias=="ban-doc-phap-luat"?"selected":"" %>>Bạn đọc</option>
                </select>
							<br class="clear" />
							<div class="text">
								Thời gian :
							</div> Ngày
<select id="dday" name="dday" class="select-search" ><option value=""></option>
                    <% for(int i =1; i<=31;i++) {%>
                        <option value="<%=String.Format("{0:00}", i)%>" <%= PublishDate.Length==8?PublishDate.Substring(6,2)==String.Format("{0:00}", i)?"selected":""  :""%>><%=i%></option>
                    <% } %>
                </select> 
tháng           <select id="dmonth" name="dmonth" class="select-search" ><option value=""></option>
                    <% for(int i =1; i<=13;i++) {%>
                        <option value="<%=String.Format("{0:00}", i)%>" <%=PublishDate.Length!=8?"":PublishDate.Substring(4,2)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                    <% } %>
                </select>
năm                <select id="dyear" name="dyear" class="select-search" ><option value=""></option>
                    <% for(int i = 2009; i<=2010;i++) {%>
                        <option value="<%=i %>" <%=PublishDate.Length!=8?"":PublishDate.Substring(0,4)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                    <% } %>
                </select>
							<br class="clear" />	
							
							<div class="pdt10">
								<a href="#" onclick="search2()" ><img src="http://res.vietnamnet.vn/sports/images/bt-search.gif" width="89" height="24" /></a>
								  <img src="http://res.vietnamnet.vn/sports/images/bt-reset.gif" width="77" height="24" />
							</div>	
						</div>

<div id="SearchContent"  class="cate-list-group">
<asp:Repeater ID="rptSearchArticles" runat="server">
  <ItemTemplate>
    <div class="cate-list-item">
                <div class="cl-img">
                    <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                        DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 125, 70)%>
                </div>
                  <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                              DataBinder.Eval(Container.DataItem, "Name"), "bc-new-title", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                <div class="bc-lead">
                    <%#DataBinder.Eval(Container.DataItem, "Lead")%>
                </div>
                <div class="clear">,</div>
            </div>        
  </ItemTemplate>
</asp:Repeater>
</div>

					</div>
					<div class="cate-list-bottom">&nbsp;</div>
				</div>	

  <div id="paging">
    <asp:HyperLink ID="hplPrev" runat="server" class="back">quay lại trang trước</asp:HyperLink>
    <asp:HyperLink ID="hplNext" runat="server" class="next">xem tiếp tin khác</asp:HyperLink>
    <div class="clear">
      ,</div>
  </div>

<asp:Label runat="server" ID="lblMessages" Visible="false"/>
<asp:Literal runat="server" ID="lScript"></asp:Literal>
<script>//$('#SearchContent').removeHighlight().highlight('<%=SearchKeyword%>');</script>
 