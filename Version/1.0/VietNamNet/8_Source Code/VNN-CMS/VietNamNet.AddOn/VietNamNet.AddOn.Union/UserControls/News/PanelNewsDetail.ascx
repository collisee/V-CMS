<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelNewsDetail.ascx.cs"
    Inherits="VietNamNet.AddOn.Union.UserControls.News.PanelNewsDetail" %>
<%@ Register Src="PanelNewsPhoto.ascx" TagName="PanelNewsPhoto" TagPrefix="uc" %>
<%@ Register Src="PanelNewsVideo.ascx" TagName="PanelNewsVideo" TagPrefix="uc" %>
<asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
        <div class="article">
            <div class="article_title">
                <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </div>
            <div class="update2">
                <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %> (GMT+7)
            </div>
            <div class="article_intro none">
                <b>
                    <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                </b>
            </div>
            <div class="article_content">
                <%#DataBinder.Eval(Container.DataItem, "Detail")%>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<uc:PanelNewsPhoto ID="PanelNewsPhoto1" runat="server" />
<uc:PanelNewsVideo ID="PanelNewsVideo1" runat="server" />
