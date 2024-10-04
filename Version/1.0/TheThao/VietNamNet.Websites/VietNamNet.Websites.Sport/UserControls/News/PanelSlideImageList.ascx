<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSlideImageList.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelSlideImageList" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="contentSlideList">
    <ul class="clearfix">
        <asp:Repeater ID="rptImageList" runat="server">
            <ItemTemplate>
                <li>
                     <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                     DataBinder.Eval(Container.DataItem, "Name"), "", "none",
                     DataBinder.Eval(Container.DataItem, "ImageLink"), "", 152, 91)%>
                    <p>
                        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), "", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                    </p>           
                </li>     
            </ItemTemplate>
        </asp:Repeater>              
    </ul>
    
    <p align="right">
        <a href="#">
            <img src="http://res.vietnamnet.vn/sports/images/thethaoslider/thethao_link_box.png" alt="" title="" />
        </a>
    </p>
</div>
