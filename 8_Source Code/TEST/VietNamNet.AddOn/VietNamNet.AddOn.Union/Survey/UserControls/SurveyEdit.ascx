<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyEdit.ascx.cs" Inherits="VietNamNet.AddOn.Survey.UserControls.SurveyEdit" %>

<p>
    <asp:Label ID="lblStatusLabel" runat="server" CssClass="label w150" Text="Câu h?i:"></asp:Label>
    <asp:Label ID="lblQuestion" runat="server" CssClass="label w450" Text=""></asp:Label>
    <br class="clear" />
</p>
<p>
    <asp:Label ID="Label1" runat="server" CssClass="label w150" Text="Ki?u ch?n:"></asp:Label>
    <asp:Label ID="lblOptionType" runat="server" CssClass="label w450" Text=""></asp:Label>
    <br class="clear" />
</p>
<p>
    <asp:Label ID="Label3" runat="server" CssClass="label w150" Text="Mô t?:"></asp:Label>
    <asp:Label ID="lblNotes" runat="server" CssClass="label w450" Text=""></asp:Label>
    <br class="clear" />
</p>
<p>
    <asp:Label ID="Label5" runat="server" CssClass="label w150" Text="Tags:"></asp:Label>
    <asp:Label ID="lblTags" runat="server" CssClass="label w450" Text=""></asp:Label>
    <br class="clear" />
</p>
<p>
    <asp:Label ID="Label7" runat="server" CssClass="label w150" Text="Các l?a ch?n:"></asp:Label> 
    <asp:Label ID="lblSurveyOptions" runat="server" CssClass="label w450" Text=""></asp:Label>  
    <br class="clear" />
</p>
<%--<p>
    <a href="#" onclick="selectTab('tSearchInfo');">B??c ti?p theo</a>
</p>--%>
<asp:Label ID="lblSurveyId" runat="server"   Text="" Visible=false ></asp:Label> 