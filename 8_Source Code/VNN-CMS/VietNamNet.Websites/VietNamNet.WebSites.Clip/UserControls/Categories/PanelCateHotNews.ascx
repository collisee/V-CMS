<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateHotNews.ascx.cs" Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelCateHotNews" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="first_hot">
  <div id="news-top">
    <div class="first">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div id="gallery">          
            <a class="show" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <img src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>" />
           </a>  
          </div>
          <div class="content">            
            <a class="title" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                <%#DataBinder.Eval(Container.DataItem, "Name")%>
           </a>  
           
            <div class="lead">
              <p>
                <%#DataBinder.Eval(Container.DataItem, "Lead")%>
              </p>
            </div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
  <div class="first_hot_list">
    <asp:Repeater ID="rptTopOther" runat="server">
      <ItemTemplate>
        <div class="first_hot_item">         
           <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                         <%#HttpUtility.HtmlEncode((string)(DataBinder.Eval(Container.DataItem, "Name")))%>
           </a>     
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>