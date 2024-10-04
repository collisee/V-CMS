<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Page MasterPageFile="Default.Master" Language="C#" AutoEventWireup="true" Codebehind="NewsMedia.aspx.cs"
  Inherits="VietNamNet.AddOn.Union.NewsMedia" %>

<%@ Register Src="UserControls/News/PanelNewsComment.ascx" TagName="PanelNewsComment"
  TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelNewsMore.ascx" TagName="PanelNewsMore" TagPrefix="uc" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
  <div id="container">
    <div class="bg-title1">
      <div class="bg-title2">
        <div class="bg-title3">
          <asp:HyperLink ID="hplCate" runat="server" class="title"></asp:HyperLink>
        </div>
      </div>
    </div>
    <div class="block-body">
      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>      
    </div>
    <div class="bg-bgtitle1">
      <div class="bg-bgtitle2">
        <div class="bg-bgtitle3">
          &nbsp;
        </div>
      </div>
    </div>
  </div>
</asp:Content>
