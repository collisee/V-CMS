<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSearchContent.ascx.cs"  Inherits="VietNamNet.Websites.V1.UserControls.Search.PanelSearchContent" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<div id="search_box" class="search_new">
    
	<div class="search_rows clearfix">
		<div class="search_rows_left">Từ khóa:</div>
		<div class="search_rows_center"><input class="search_rows_text keyword"   type="text" value="<%=SearchKeyword %>" onkeydown="searchkey(event,this)"/></div>
		<div class="search_rows_right"><a id="search_new_submit" href="javacsript: void(0)" onclick="search2()" >Tìm kiếm</a><a id="search_new_reset" href="javascript: void(0)">Làm lại</a></div>
	</div>
	
	<div class="search_rows clearfix">
		<div class="search_rows_left">Danh mục tin:</div>
		<div class="search_rows_center">
			<select id="scat" name="scat" class="categories"  >
                    <option value="">Toàn bộ</option>
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
		</div>
	</div>	
	
	<div class="search_rows clearfix">
		<div class="search_rows_left">Thời gian:</div>
		<div class="search_rows_center">
			<select  class="dday" ><option value=""></option>
                <% for(int i =1; i<=31;i++) {%>
                    <option value="<%=String.Format("{0:00}", i)%>" <%= PublishDate.Length==8?PublishDate.Substring(6,2)==String.Format("{0:00}", i)?"selected":""  :""%>><%=i%></option>
                <% } %>
            </select> tháng 
            <select  class="dmonth"><option value=""></option>
                <% for(int i =1; i<=13;i++) {%>
                    <option value="<%=String.Format("{0:00}", i)%>" <%=PublishDate.Length!=8?"":PublishDate.Substring(4,2)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                <% } %>
            </select> năm 
           <select  class="dyear"><option value=""></option>
                <% for(int i = 2010; i<=2010;i++) {%>
                    <option value="<%=i %>" <%=PublishDate.Length!=8?"":PublishDate.Substring(0,4)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                <% } %>
            </select>
		</div>
	</div>
	
</div>
  
<div id="SearchContent">
<asp:Repeater ID="rptSearchArticles" runat="server">
    <HeaderTemplate>
        <h3>Kết quả tìm kiếm</h3>
    </HeaderTemplate>
  <ItemTemplate>
    <div class="item2"> 
                    <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                        DataBinder.Eval(Container.DataItem, "ImageLink"), "fl_left", 200, 112)%>
                
                  <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), "item_link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                <div class="lead">
                    <%#DataBinder.Eval(Container.DataItem, "Lead")%>
                </div>
                <div class="clear">,</div>
            </div>        
  </ItemTemplate>
</asp:Repeater>
</div>
  <div id="paging">
    <asp:HyperLink ID="hplPrev" runat="server" class="back">quay lại trang trước</asp:HyperLink>
    <asp:HyperLink ID="hplNext" runat="server" class="next">xem tiếp tin khác</asp:HyperLink>
    <div class="clear">
      ,</div>
  </div>

<asp:Label runat="server" ID="lblMessages" Visible="false"/>
<asp:Literal runat="server" ID="lScript"></asp:Literal> 