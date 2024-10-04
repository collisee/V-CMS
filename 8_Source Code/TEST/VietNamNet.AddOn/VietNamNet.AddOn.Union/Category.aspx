<%@ Page MasterPageFile="Default.Master" Language="C#" AutoEventWireup="true" Codebehind="Category.aspx.cs"
    Inherits="VietNamNet.AddOn.Union.Category" %>

<%@ Register Src="UserControls/Categories/PanelCategory.ascx" TagName="PanelCategory"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <div id="row-center">
        <uc1:PanelCategory ID="PanelCategory1" runat="server" />
    </div>
</asp:Content>
