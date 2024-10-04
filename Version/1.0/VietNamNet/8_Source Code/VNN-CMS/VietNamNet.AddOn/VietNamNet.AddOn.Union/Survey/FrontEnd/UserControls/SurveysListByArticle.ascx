<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveysListByArticle.ascx.cs" Inherits="VietNamNet.AddOn.Survey.UserControls.SurveysListByArticle" %>
<%@ Register Src="../../UserControls/SurveyDisplay.ascx" TagName="SurveyDisplay"
    TagPrefix="vnnSurvey" %>
<%@ Register TagPrefix="uc1" Namespace="VietNamNet.AddOn.Survey.UserControls" %>
<asp:Repeater ID="rptView" runat="server" OnItemDataBound="RptViewItemDataBound">
<ItemTemplate>
<vnnSurvey:SurveyDisplay ID="SurveyDisplay1" runat="server" />
</ItemTemplate>
</asp:Repeater>
<asp:LinkButton ID="cmdSelect" runat="server" OnClick="cmdSelect_Click" Visible="false" >Lựa chọn</asp:LinkButton>
<asp:LinkButton ID="cmdResult" runat="server"  Visible="false" >Xem kết quả</asp:LinkButton>