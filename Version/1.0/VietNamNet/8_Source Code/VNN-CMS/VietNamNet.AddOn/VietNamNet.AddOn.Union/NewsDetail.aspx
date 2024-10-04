<%@ Page MasterPageFile="Default.Master" Language="C#" AutoEventWireup="true" Codebehind="NewsDetail.aspx.cs"
  Inherits="VietNamNet.AddOn.Union.NewsDetail" %>
<%@ Register Src="/Survey/FrontEnd/UserControls/PanelContentPoll.ascx" TagName="PanelContentPoll"    TagPrefix="uc" %>

<%@ Register Src="UserControls/News/PanelNewsDetail.ascx" TagName="PanelNewsDetail"  TagPrefix="uc" %>
<%@ Register Src="UserControls/News/PanelNewsComment.ascx" TagName="PanelNewsComment"  TagPrefix="uc" %>
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
      <uc:PanelNewsDetail ID="PanelNewsDetail1" runat="server" />
      <uc:PanelContentPoll ID="PanelContentPoll1" runat="server" />
      <uc:PanelNewsComment ID="PanelNewsComment1" runat="server" />
      <uc:PanelNewsMore ID="PanelNewsMore1" runat="server" />
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
