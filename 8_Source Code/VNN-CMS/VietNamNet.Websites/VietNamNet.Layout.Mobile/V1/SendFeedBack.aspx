<%@ Page MasterPageFile="~/V1/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="SendFeedBack.aspx.cs" Inherits="VietNamNet.Layout.Mobile.V1.SendFeedBack" %>
<%@ Register Src="~/UserControls/PanelSendFeedBack.ascx" TagName="PanelSendFeedBack" TagPrefix="uc" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <uc:PanelSendFeedBack ID="PanelSendFeedBack1" runat="server" />
</asp:Content>
