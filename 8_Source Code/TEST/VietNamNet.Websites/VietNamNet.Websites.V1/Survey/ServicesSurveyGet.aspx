<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="ServicesSurveyGet.aspx.cs"  Inherits="VietNamNet.Websites.V1.Survey.ServicesSurveyGet" Title="Bình chọn" ValidateRequest="false" %>

<%@ Register Src="~/Survey/UserControls/SurveyDisplay.ascx" TagName="SurveyDisplay" TagPrefix="vnnSurvey" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <vnnSurvey:SurveyDisplay id="SurveyDisplay1" runat="server">
        
    </vnnSurvey:SurveyDisplay> 
   
     <asp:LinkButton ID="cmdSelect" runat="server" OnClick="cmdSelect_Click">Lựa chọn</asp:LinkButton>
      <asp:LinkButton ID="cmdResult" runat="server"  Visible="false" >Xem kết quả</asp:LinkButton>
      
      <asp:TextBox  ID="txtSurveyId" runat="server" Visible="false"    ></asp:TextBox> 
      <asp:Label ID="lblMessages" runat="server"  >messages</asp:Label>
</asp:Content>
