<%@ Page MasterPageFile="Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs"
    Inherits="VietNamNet.AddOn.Union._Default" %>

<%@ Register Src="UserControls/Hompage/PanelInfomation.ascx" TagName="PanelInfomation"
    TagPrefix="uc" %>
<%@ Register Src="UserControls/Hompage/PanelCategory.ascx" TagName="PanelCategory"
    TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div id="row-center">
        <%--<uc:PanelInfomation id="PanelInfomation1" runat="server" CategoryAlias="thong-tin" />--%>
        <uc:PanelCategory ID="PanelCategory0" runat="server" CategoryAlias="thong-tin" />
        <uc:PanelCategory ID="PanelCategory1" runat="server" CategoryAlias="buon-chuyen" />
        <uc:PanelCategory ID="PanelCategory2" runat="server" CategoryAlias="cuoi" />
        <uc:PanelCategory ID="PanelCategory3" runat="server" CategoryAlias="cuoc-thi" />
        <uc:PanelCategory ID="PanelCategory4" runat="server" CategoryAlias="goc-chia-se" />
    </div>
</asp:Content>
