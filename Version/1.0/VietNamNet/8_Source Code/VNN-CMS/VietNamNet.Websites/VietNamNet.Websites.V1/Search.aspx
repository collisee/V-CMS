<%@ OutputCache CacheProfile="CategoryCache" %>
<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Search.aspx.cs"    Inherits="VietNamNet.Websites.V1.Search" Title="Tìm kiếm" %>
<%@ Register Src="UserControls/Search/PanelSearchContent.ascx" TagName="PanelSearchContent" TagPrefix="vnnSearch" %>
 
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
<p>
    <vnnSearch:PanelSearchContent ID="PanelSearchContent1" runat="server" />
</p>
</asp:Content>
