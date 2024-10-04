<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewResult.aspx.cs" Inherits="VietNamNet.Websites.V1.Survey.ViewResult" Title="Kết quả Bình chọn" ValidateRequest="false" %>
<%@ Register Src="UserControls/SurveyViewResult.ascx" TagName="SurveyViewResult" TagPrefix="vnnSurvey" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <vnnSurvey:SurveyViewResult id="SurveyViewResult1" runat="server"/> 
       
</asp:Content>
