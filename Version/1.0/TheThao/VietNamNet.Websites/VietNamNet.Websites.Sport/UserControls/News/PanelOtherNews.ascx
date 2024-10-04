<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelOtherNews.ascx.cs" Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelOtherNews" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="home-article-related pdb5">
    <h2>
        Các tin đã đăng</h2>
    <ul>
        <asp:Repeater ID="rptPanelOtherNews" runat="server">
            <ItemTemplate>
                <li>                
                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), "", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                    <span class="gray">(<%#Utilities.FormatDisplayDateOnly((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %> GMT+7)</span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
            
            
       