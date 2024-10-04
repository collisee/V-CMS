<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="ServicesSurveyGet2.aspx.cs" Inherits="VietNamNet.Websites.V1.Survey.ServicesSurveyGet2" ValidateRequest="false"  %>
<%@ Register Src="~/Survey/UserControls/SurveyDisplay.ascx" TagName="SurveyDisplay" TagPrefix="vnnSurvey" %>
<%@ Register Src="~/Survey/UserControls/SurveyViewResult.ascx" TagName="SurveyViewResult" TagPrefix="vnnSurvey" %> 
<vnnSurvey:SurveyDisplay ID="SurveyDisplay1" runat="server" />
<vnnSurvey:SurveyViewResult id="SurveyViewResult1" runat="server" Visible="false"/> 

