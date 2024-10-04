<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCategory.ascx.cs" Inherits="VietNamNet.CMS.Articles.UserControls.PanelCategory" %>
<p>
    <asp:Label ID="lblSubCategoryLabel" runat="server" CssClass="label w150" Text="Danh mục phụ:"></asp:Label>
    <telerik:RadComboBox ID="cmbSubCategory" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
        Width="454px" DataTextField="Name" DataValueField="Id">
        <CollapseAnimation Type="None" />
        <ExpandAnimation Type="None" />
    </telerik:RadComboBox>
    <telerik:RadNumericTextBox ID="txtSubOrd" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
        <NumberFormat DecimalDigits="0" />
    </telerik:RadNumericTextBox>
    <br class="clear" />
</p>
