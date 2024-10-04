<%--<%@ OutputCache CacheProfile="SystemCache" %>--%>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="VietNamNet.Layout.Mobile.Category" %>
<%@ Register Src="~/UserControls/PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <uc:PanelCategory ID="PanelCategory1" runat="server" />
    <div style="text-align:right;"><a href="/vn/<%=categoryAlias %>/page/<%=pageNumber + 1 %>/index.html">Xem tiếp...</a></div>
</asp:Content>
