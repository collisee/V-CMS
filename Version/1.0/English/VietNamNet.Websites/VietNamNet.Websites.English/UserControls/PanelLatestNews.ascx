<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelLatestNews.ascx.cs" Inherits="VietNamNet.Websites.English.UserControls.PanelLatestNews" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="lastnew">
	<div class="bg_title">
		Latest News
	</div>
	
	<div class="lastnew-list pdlr8">
	    <asp:Repeater ID="rptLatestNews" runat="server">
	        <ItemTemplate>
	            <div class="lastnew-item">
			        <a href="/en/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"> <%#DataBinder.Eval(Container.DataItem, "Name")%> </a>
		        </div>
	        </ItemTemplate>							
		</asp:Repeater>						
	</div>
</div>