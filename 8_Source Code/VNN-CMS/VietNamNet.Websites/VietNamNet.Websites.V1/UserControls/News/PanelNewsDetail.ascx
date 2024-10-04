<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsDetail.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.News.PanelNewsDetail" %>
<%@ Register TagPrefix="vnn" TagName="PaneSurvey" Src="~/UserControls/Survey/PaneSurvey.ascx" %>
<%@ Register TagPrefix="vnn" TagName="PaneSendEmail" Src="~/UserControls/News/PanelNewDetail_SendEmail.ascx" %>
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
            <div id="Div1" class="article_content">
                <vnn:PaneSurvey ID="PaneSurvey1" runat="server" ArticleId='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
            </div>
        </div>          
        
        <vnn:PaneSendEmail ID="PaneSendEmail1" runat="server" 
                        SendEmailId='<%# DataBinder.Eval(Container.DataItem, "Id") %>' 
                        Url='<%# DataBinder.Eval(Container.DataItem, "Url") %>'
                         Subject='<%# DataBinder.Eval(Container.DataItem, "Name") %>'       />

    </ItemTemplate>
</asp:Repeater>
