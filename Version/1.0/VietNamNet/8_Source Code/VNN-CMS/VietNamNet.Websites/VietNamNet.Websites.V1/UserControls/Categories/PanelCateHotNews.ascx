<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateHotNews.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateHotNews" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="first_hot">
  <div id="news-top">
    <div class="first">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div id="gallery">          
            <a class="show" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
                <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>" />
           </a>  
          </div>
          <div class="content">            
            <a class="title" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
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
</div>