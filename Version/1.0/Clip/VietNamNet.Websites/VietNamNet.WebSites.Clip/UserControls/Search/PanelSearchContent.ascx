<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSearchContent.ascx.cs"  Inherits="VietNamNet.Websites.Clip.UserControls.Search.PanelSearchContent" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>

 <div class="form-chuan">
    <table cellpadding="3" cellspacing="3">
        <tr>
            <td class="w100">Từ khóa</td>
            <td> <input class="fr789 w100" id="skeywords" name="skeywords" type="text"  value="<%=SearchKeyword %>"/></td>
        </tr>
        <tr>
            <td>Danh mục clip</td>
            <td><select id="scat" name="scat"  class="fr789 w100 " >
                    <option value="">- Toàn bộ -</option>
                    <option value="clip-mobile-thoi-su" <%=CategoryAlias=="clip-mobile-thoi-su"?"selected":"" %>>Thời sự</option>
                    <option value="clip-mobile-mobile" <%=CategoryAlias=="clip-mobile-mobile"?"selected":"" %>>Mobile</option>
                    <option value="clip-mobile-radio" <%=CategoryAlias=="clip-mobile-radio"?"selected":"" %>>Radio</option>
                    <option value="clip-mobile-su-kien" <%=CategoryAlias=="clip-mobile-su-kien"?"selected":"" %>>Sự kiện</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>Ngày</td>
            <td>
                <select id="dday" name="dday"  class="fr789 w50 center" ><option value=""></option>
                    <% for(int i =1; i<=31;i++) {%>
                        <option value="<%=String.Format("{0:00}", i)%>" <%= PublishDate.Length==8?PublishDate.Substring(6,2)==String.Format("{0:00}", i)?"selected":""  :""%>><%=i%></option>
                    <% } %>
                </select> 
tháng           <select id="dmonth" name="dmonth"  class="fr789 w50 center" ><option value=""></option>
                    <% for(int i =1; i<=13;i++) {%>
                        <option value="<%=String.Format("{0:00}", i)%>" <%=PublishDate.Length!=8?"":PublishDate.Substring(4,2)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                    <% } %>
                </select>
năm                <select id="dyear" name="dyear"  class="fr789 w50 center"><option value=""></option>
                    <% for(int i = 2010; i<=2010;i++) {%>
                        <option value="<%=i %>" <%=PublishDate.Length!=8?"":PublishDate.Substring(0,4)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                    <% } %>
                </select>
                <a href="#" onclick="search2()" >Tìm kiếm</a>
            </td>
        </tr> 
    </table> 
    
</div>
    
<div id="SearchContent">
<asp:Repeater ID="rptSearchArticles" runat="server">
    <HeaderTemplate>
        <h3>Kết quả tìm kiếm</h3>
    </HeaderTemplate>
  <ItemTemplate>
    <div class="clip_item_1">
                <div class="clip_thumwar">
                        <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                        DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 154, 94)%> 
                </div>
                  <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                                                    DataBinder.Eval(Container.DataItem, "Name"), "clip_link_1", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                
                <div class="clip_lead_new">
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
<script>
if ('<%=SearchKeyword%>'!='')
$('#SearchContent').removeHighlight().highlight('<%=SearchKeyword%>');
</script>