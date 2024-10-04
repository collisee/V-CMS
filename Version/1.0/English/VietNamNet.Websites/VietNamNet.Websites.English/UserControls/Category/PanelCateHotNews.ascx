<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateHotNews.ascx.cs"
    Inherits="VietNamNet.Websites.English.UserControls.Category.PanelCateHotNews" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<div class="body-hotnew">    
    <asp:Repeater ID="rptTopHotNews" runat="server">
        <ItemTemplate>
            <div class="hn-item1" >
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "hn-img" %>">
                    <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=80" width="80" height="45" />
                </a>
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                    class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "hn-title3" : "hn-title" %>">
                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                </a>
                <br class="clear" />
            </div>
        </ItemTemplate>
        
        <AlternatingItemTemplate>
            <div class="hn-item2">
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "hn-img" %>">
                    <img alt="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>?w=80" width="80" height="45" />
                </a>
                
                <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html" class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "hn-title3" : "hn-title" %>">
                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                </a>
                <br class="clear" />
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
