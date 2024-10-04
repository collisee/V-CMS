<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelArticleCategory2.ascx.cs" Inherits="VietNamNet.CMS.Articles.UserControls.PanelArticleCategory2" %>
<%@ Register Src="PanelCategory.ascx" TagName="PanelCategory" TagPrefix="uc" %>

<div>
    <asp:Panel ID="pnlEdit" runat="server">
        <p>
            <asp:Label ID="lblCategoryLabel" runat="server" CssClass="label w150" Text="Danh mục chính:"></asp:Label>
            <telerik:RadComboBox ID="cmbPrimaryCategory" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px">
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <telerik:RadNumericTextBox ID="txtPrimaryOrd" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
        <asp:HiddenField ID="hidSubCategoryNumber" runat="server" Value="2" />
        <asp:PlaceHolder ID="plhSubCategories" runat="server">
        </asp:PlaceHolder>
        <p>
            <asp:Button ID="btnAddCategory" runat="server" Text="Thêm Chuyên mục XB" Width="150px" OnClick="btnAddCategory_Click" />
        </p>
    </asp:Panel>
</div>