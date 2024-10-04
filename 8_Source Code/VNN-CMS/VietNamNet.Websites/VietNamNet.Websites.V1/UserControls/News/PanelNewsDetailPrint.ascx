<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewsDetailPrint.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.News.PanelNewsDetailPrint" %>
<asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
        <div id="article" class="row">
        
            <div id="subtitle">
                <%#DataBinder.Eval(Container.DataItem, "Title") %>
            </div>
            
            <div id="title" class="content_title">
                <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </div>
            <div id="date" class="content_date">
                Cập nhật lúc
                <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                (GMT+7)
            </div>
            <div id="content" class="article_content">
                <%#DataBinder.Eval(Container.DataItem, "Detail")%>
            </div>
            
        </div>          
        
     

    </ItemTemplate>
</asp:Repeater>