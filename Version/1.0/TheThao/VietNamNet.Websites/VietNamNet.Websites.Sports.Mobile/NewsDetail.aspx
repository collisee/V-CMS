<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="VietNamNet.Websites.Sports.Mobile.NewsDetail" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/PanelNewsDetail.ascx" TagName="PanelNewsDetail" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelNewsMore.ascx" TagName="PanelNewsMore" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <table border="0" cellpadding="0" cellspacing="0" width="99%">
        <tr>
            <td class="cate-title" align="left">
                <asp:HyperLink ID="lnkCategory" runat="server" NavigateUrl="/vn/index.html"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <uc:PanelNewsMore ID="PanelNewsMore1" runat="server" FirstIndexRecord="1" LastIndexRecord="10" />
            </td>
        </tr>
    </table>
    <img alt="" title="" class="none" src="http://tracking.thethao.vietnamnet.vn/tracking/t.srv?sn=article&dm=m.thethao.vietnamnet.vn&us=me&vs=1&aid=<%=docId %>&catalias=<%=categoryAlias %>" />
</asp:Content>