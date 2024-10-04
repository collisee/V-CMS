<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelArticleCategory1.ascx.cs" Inherits="VietNamNet.CMS.Articles.UserControls.PanelArticleCategory1" %>
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
        <asp:HiddenField ID="hidSubCategoryNumber" runat="server" Value="5" />
        <p>
            <asp:Label ID="lblCategory1Label" runat="server" CssClass="label w150" Text="Danh mục phụ 1:"></asp:Label>
            <telerik:RadComboBox ID="cmbSubCategory1" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px">
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <telerik:RadNumericTextBox ID="txtSubOrd1" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblCategory2Label" runat="server" CssClass="label w150" Text="Danh mục phụ 2:"></asp:Label>
            <telerik:RadComboBox ID="cmbSubCategory2" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px">
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <telerik:RadNumericTextBox ID="txtSubOrd2" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblCategory3Label" runat="server" CssClass="label w150" Text="Danh mục phụ 3:"></asp:Label>
            <telerik:RadComboBox ID="cmbSubCategory3" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px">
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <telerik:RadNumericTextBox ID="txtSubOrd3" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblCategory4Label" runat="server" CssClass="label w150" Text="Danh mục phụ 4:"></asp:Label>
            <telerik:RadComboBox ID="cmbSubCategory4" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px">
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <telerik:RadNumericTextBox ID="txtSubOrd4" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblCategory5Label" runat="server" CssClass="label w150" Text="Danh mục phụ 5:"></asp:Label>
            <telerik:RadComboBox ID="cmbSubCategory5" runat="server" Height="300px" EmptyMessage="Chọn danh mục..."
                Width="454px">
                <CollapseAnimation Type="None" />
                <ExpandAnimation Type="None" />
            </telerik:RadComboBox>
            <telerik:RadNumericTextBox ID="txtSubOrd5" runat="server" MinValue="1" Value="1" Width="50px" CssClass="right">
                <NumberFormat DecimalDigits="0" />
            </telerik:RadNumericTextBox>
            <br class="clear" />
        </p>
    </asp:Panel>
</div>