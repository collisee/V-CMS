<%@ Page MasterPageFile="Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Forums.aspx.cs" Inherits="VietNamNet.AddOn.Union.Forums" %>

<%@ Register Src="UserControls/Hompage/PanelCategory.ascx" TagName="PanelCategory"
    TagPrefix="uc" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div id="row-center">              
        <uc:PanelCategory ID="PanelCategory1" runat="server" CategoryAlias="buon-chuyen" />
        <uc:PanelCategory ID="PanelCategory2" runat="server" CategoryAlias="cuoi" />
        <uc:PanelCategory ID="PanelCategory3" runat="server" CategoryAlias="cuoc-thi" />
        <uc:PanelCategory ID="PanelCategory4" runat="server" CategoryAlias="goc-chia-se" />
    </div>
</asp:Content>
