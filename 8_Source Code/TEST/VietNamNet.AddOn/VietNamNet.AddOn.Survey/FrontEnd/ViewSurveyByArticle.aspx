<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewSurveyByArticle.aspx.cs" Inherits="VietNamNet.AddOn.Survey.ViewSurveyByArticle" Title="Bình ch?n" ValidateRequest="false" %>
<%@ Register Src="UserControls/SurveysListByArticle.ascx" TagName="SurveysListByArticle"   TagPrefix="vnnSurvey" %> 
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer"> 
    <vnnSurvey:SurveysListByArticle ID="SurveysListByArticle1" runat="server" />
    
      
</asp:Content>
