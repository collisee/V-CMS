<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewSurvey.aspx.cs" Inherits="VietNamNet.AddOn.Survey.ViewSurvey" Title="Bình chọn" ValidateRequest="false" %>

<%@ Register Src="~/UserControls/SurveyDisplay.ascx" TagName="SurveyDisplay" TagPrefix="vnnSurvey" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <vnnSurvey:SurveyDisplay id="SurveyDisplay1" runat="server">
        
    </vnnSurvey:SurveyDisplay> 
   
     <asp:LinkButton ID="cmdSelect" runat="server" OnClick="cmdSelect_Click">Lựa chọn</asp:LinkButton>
      <asp:LinkButton ID="cmdResult" runat="server"  Visible="false" >Xem kết quả</asp:LinkButton>
      
      <telerik:RadTextBox ID="txtSurveyId" runat="server" Visible="false"    ></telerik:RadTextBox> 
</asp:Content>
