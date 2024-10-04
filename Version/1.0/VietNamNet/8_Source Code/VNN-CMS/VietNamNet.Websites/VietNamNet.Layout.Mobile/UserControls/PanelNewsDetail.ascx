<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewsDetail.ascx.cs" Inherits="VietNamNet.Layout.Mobile.UserControls.PanelNewsDetail" %>
<%@ Register Src="~/UserControls/PanelSendFeedBack.ascx" TagName="PanelSendFeedBack" TagPrefix="uc" %>
<asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
        <div class="article">
            <br />
            <div class="article_title">
                <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </div>
            <div class="article_time">
                <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %> (GMT+7)
            </div>
            <br />
            <%--<div class="article_intro">
                <b>
                    <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                </b>
            </div>--%>
            <div class="article_content">
                <%#DataBinder.Eval(Container.DataItem, "Detail")%>
                <br class="clear" />
            </div>
        </div>
        <br class="clear" />
        <p style="text-align:center">
            <img alt="Quảng cáo" title="Quảng cáo" src="/data/banner-kqsx-mb.gif" width="300" />
        </p>
        <uc:PanelSendFeedBack ID="PanelSendFeedBack1" runat="server" ArticleName='<%#DataBinder.Eval(Container.DataItem, "Name") %>'
            ArticleId='<%#DataBinder.Eval(Container.DataItem, "Id") %>' />
    </ItemTemplate>
</asp:Repeater>

