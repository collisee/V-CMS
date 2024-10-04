<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewSurveyByCat.aspx.cs" Inherits="VietNamNet.AddOn.Survey.ViewSurveyByCat" Title="Bình ch?n" ValidateRequest="false" %>
<%@ Register Src="UserControls/SurveysListByCat.ascx" TagName="SurveysListByCat"   TagPrefix="vnnSurvey" %> 
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer"> 
    <vnnSurvey:SurveysListByCat ID="SurveysListByCat1" runat="server" />
    
      
</asp:Content>
