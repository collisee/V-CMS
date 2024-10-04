<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxSmallHorizontal.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBoxSmallHorizontal" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<div class="row">
<div class="radio">
    <div class="radio_button">
        <a href="ho-chi-minh/index.html">
            <img alt="#" height="19" width="97" src="/Images/tphcm24h.gif" />
        </a>
    </div>
            
    <asp:Repeater ID="rptList" runat="server">
    <ItemTemplate>
     <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
     DataBinder.Eval(Container.DataItem, "Name"), "radio_item", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
    </ItemTemplate>
    </asp:Repeater>
       
    <div class="clear">,</div>
</div>
</div>
