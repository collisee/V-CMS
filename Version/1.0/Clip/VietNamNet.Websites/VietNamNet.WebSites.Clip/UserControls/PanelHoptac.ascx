<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHoptac.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.PanelHoptac" %>
<%@ Register Src="PanelCateBoxHoptac.ascx" TagName="PanelCateBoxHoptac" TagPrefix="uc" %>
<div id="home6" class="row">
  <div class="home61_1">
    <div class="home61_3">
      <div class="home61_2">
        Hợp Tác
      </div>
    </div>
  </div>
  <div class="home62">
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac1" runat="server" CategoryAlias="hop-tac-megafun" />
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac2" runat="server" CategoryAlias="hop-tac-dau-khi" />
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac3" runat="server" CategoryAlias="chuyen-trang-oto-xemay" />
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac4" runat="server" CategoryAlias="the-gioi-anh" />
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac5" runat="server" CategoryAlias="hop-tac-vnn-jobs" />
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac6" runat="server" CategoryAlias="hop-tac-land-today" />
    <uc:PanelCateBoxHoptac ID="PanelCateBoxHoptac7" runat="server" CategoryAlias="hop-tac-luatvietnam" />
    <div class="clear">
      ,</div>
  </div>
  <div class="home63_1">
    <div class="home63_3">
      <div class="home63_2">
        &nbsp;
      </div>
    </div>
  </div>
</div>
