<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentSportComment.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentSportComment" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<div class="bbc-box">    
    <div class="bbc-top">&nbsp;</div>
    
    <div class="pdlr5 ">
        <div class="box-item-title">
            <a href="/vn/binh-luan-the-thao/index.html">Bình luận thể thao</a></div>
        <div class="pd10 ">        
            <asp:Repeater ID="rptSportComment" runat="server">
                <ItemTemplate>
                    <div class="box-item">
                        <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), "box-item-img", "none",
                        DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 41, 30)%>
                                                               
                        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                        DataBinder.Eval(Container.DataItem, "Name"), "box-item-link", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                               
                        <div class="clear">&nbsp;</div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>              
            
            <div class="box-xemthem">
                <a href="/vn/binh-luan-the-thao/index.html"><img alt="" src="http://res.vietnamnet.vn/sports/images/xemthem.gif" width="76" height="20" /></a>
            </div>
        </div>
    </div>
    
    <div class="bbc-bottom">&nbsp;</div>
</div>
