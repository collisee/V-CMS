<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateCenterPoint.ascx.cs"
    Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelCateCenterPoint" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="first_new">
    <div class="boder1">
        <img alt="#" src="/images/new_boder1.gif" width="280px" height="3" /></div>
    <ul>
        <asp:Repeater ID="rptCenterPoint" runat="server">
            <ItemTemplate>        
                <div class="cate_item1">                     
                             <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                                <%#DataBinder.Eval(Container.DataItem, "Name")%>
                            </a>     
                            
                            
                            <div class="cate_intro1">
                                <%#DataBinder.Eval(Container.DataItem, "Lead") %>        
                            </div>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="boder2">
        <img alt="#" src="/images/new_boder2.gif" width="280px" height="3" /></div>
</div>

