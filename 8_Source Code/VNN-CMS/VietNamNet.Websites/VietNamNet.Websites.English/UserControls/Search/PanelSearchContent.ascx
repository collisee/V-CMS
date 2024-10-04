<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSearchContent.ascx.cs"  Inherits="VietNamNet.Websites.English.UserControls.Search.PanelSearchContent" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>


<div class="pdlr5">
    <div class="bg_title3">SEARCH</div>
</div>
                    
<div class="pd10">
	<div class="search-form pdb10">
     
        <input class="search-key" id="skeywords" name="skeywords" type="text" 
               onkeypress="searchkey(event)"   value="<%=SearchKeyword %>"  watermark="Search.."/>
                            
              <select id="scat" name="scat"   class="search-cate" >
                    <option value="">- all -</option>
                    <option value="special-report" <%=CategoryAlias=="special-report"?"selected":"" %>>Special Reports</option>
                    <option value="vietnamn-in-photos" <%=CategoryAlias=="vietnamn-in-photos"?"selected":"" %>>Vietnam In Photos</option>
                    <option value="what-on" <%=CategoryAlias=="what-on"?"selected":"" %>>What's On</option>
                    <option value="vietnam-reference" <%=CategoryAlias=="vietnam-reference"?"selected":"" %>>Vietnam Reference</option>
                    <option value="politics" <%=CategoryAlias=="politics"?"selected":"" %>>Politics</option>
                    <option value="bussiness" <%=CategoryAlias=="bussiness"?"selected":"" %>>Bussiness</option>
                    <option value="society" <%=CategoryAlias=="society"?"selected":"" %>>Society</option>
                    <option value="arts-entertainment" <%=CategoryAlias==" arts-entertainment"?"selected":"" %>>Arts & Entertainment</option>
                    <option value="sports" <%=CategoryAlias=="sports"?"selected":"" %>>Sports</option>
                    <option value="world-news" <%=CategoryAlias=="world-news"?"selected":"" %>>World News</option>
                    
                    <option value="top-stories" <%=CategoryAlias=="top-stories"?"selected":"" %>>Top Stories</option>
                    <option value="in-focus" <%=CategoryAlias=="in-focus"?"selected":"" %>>In Focus</option>

                    <option value="reader-tell-us" <%=CategoryAlias=="reader-tell-us"?"selected":"" %>>Reader tell us</option>
                    <option value="lastest-news" <%=CategoryAlias=="lastest-news"?"selected":"" %>>Lastest News</option>
                </select> 
                
                <span class="box-date">
                        Date :
                  <select id="dday" name="dday" class="search-date" ><option value=""></option>
                    <% for(int i =1; i<=31;i++) {%>
                        <option value="<%=String.Format("{0:00}", i)%>" <%= PublishDate.Length==8?PublishDate.Substring(6,2)==String.Format("{0:00}", i)?"selected":""  :""%>><%=i%></option>
                    <% } %>
                </select>  <select id="dmonth" name="dmonth" class="search-date"  ><option value=""></option>
                    <% for(int i =1; i<=13;i++) {%>
                        <option value="<%=String.Format("{0:00}", i)%>" <%=PublishDate.Length!=8?"":PublishDate.Substring(4,2)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                    <% } %>
                </select>  <select id="dyear" name="dyear" class="search-date"  ><option value=""></option>
                    <% for(int i = 2010; i<=2010;i++) {%>
                        <option value="<%=i %>" <%=PublishDate.Length!=8?"":PublishDate.Substring(0,4)==String.Format("{0:00}", i)?"selected":"" %>><%=i %></option>
                    <% } %>
                </select>
                </span>
                            
                        </div>
                             <a href="#" onclick="search2()" class="button" ><img src="/images/search.gif" width="71" height="16" /></a>
                        
						<br class="clear" />
                        
                       <div class="bg_title2 pdt110">Search result </div>
                       
                       <div class="pdtb10">
<div id="SearchContent">
<asp:Repeater ID="rptSearchArticles" runat="server">
  <ItemTemplate>
    <div class="pdtb5">
                <div class="hc-img">
                    <a  class="img-boder" href="/en/<%# DataBinder.Eval(Container.DataItem, "URL")%><%#DataBinder.Eval(Container.DataItem, "Id")%>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" >                        
                         <img src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=142" alt="image"  width="142" />
                    </a>                        
                </div>
                <a class="hc-title" href="/en/<%# DataBinder.Eval(Container.DataItem, "URL")%><%#DataBinder.Eval(Container.DataItem, "Id")%>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"><%#DataBinder.Eval(Container.DataItem, "Name")%></a>
                <div class="hc-intro">
                    <%#DataBinder.Eval(Container.DataItem, "Lead")%>
                </div>
                <br class="clear" />
            </div>        
  </ItemTemplate>
</asp:Repeater>
</div>

 <div id="paging" class="pdt5 bortop center">
    <asp:HyperLink ID="hplPrev" runat="server" class="prev" Visible="false">Prev</asp:HyperLink>
    <asp:HyperLink ID="hplNext" runat="server" class="next" Visible="false">Next</asp:HyperLink>
    <div class="clear"></div>
  </div>

                       </div>
                       
                       
                    </div>
		

		
	
<asp:Label runat="server" ID="lblMessages" Visible="false"/>
<asp:Literal runat="server" ID="lScript"></asp:Literal>
<script type="text/javascript">
if ('<%=SearchKeyword%>'!='')
$('#SearchContent').removeHighlight().highlight('<%=SearchKeyword%>');
</script>