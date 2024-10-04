<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="NewsDetail.aspx.cs"
  Inherits="VietNamNet.Websites.Clip.NewsDetail" %>

<%@ Register Src="~/UserControls/PanelClipNoibat.ascx" TagName="PanelClipNoibat"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelTamdiem3g.ascx" TagName="PanelTamdiem3g" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelArticlePlaylist.ascx" TagName="PanelArticlePlaylist"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvertisement.ascx" TagName="PanelAdvertisement"
  TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvB_1.ascx" TagName="PanelAdvB_1" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_1_3.ascx" TagName="PanelAdvC_1_3" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_4_5.ascx" TagName="PanelAdvC_4_5" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/PanelAdvC_6_14.ascx" TagName="PanelAdvC_6_14" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="icon">
    <div class="cate">
      <a href="/vn/index.html">clip mobile</a>
    </div>
  </div>
  <div id="home4">
    <!-- Tieu Diem -->
    <div id="home4_1">
      <uc:PanelArticlePlaylist ID="PanelArticlePlaylist1" runat="server" />
      <div class="clip_class3 row">
        <a href="/vn/clip-mobile-thoi-su/index.html" class="clip_cate_link">
          <img src="/images/thoisu.jpg" width="168" height="60" /></a> <a href="/vn/clip-mobile-mobile/index.html"
            class="clip_cate_link">
            <img src="/images/mobile.jpg" width="168" height="60" /></a> <a href="/vn/clip-mobile-radio/index.html"
              class="clip_cate_link">
              <img src="/images/radio.gif" width="168" height="60" /></a>
      </div>
    </div>
    <div id="home4_2">
      <div class="sent_clip">
        <a href="/vn/upload/index.html" target="_blank"><img src="/images/sentfile.gif" width="300" height="54" /></a></div>
      <uc:PanelAdvC_1_3 ID="PanelAdvC_1_3_1" runat="server" />
    </div>
    <!-- END Tieu Diem -->
  </div>
  <div class="clear">
    ,</div>
  <div id="home5">
    <div class="home5left">
      <!--qc center-->
      <!--other news-->
      <div id="list-clip-new" class="row">
        <asp:Repeater ID="rptMore" runat="server">
          <ItemTemplate>
            <div class="clip_item_1">
              <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "clip_thumwar" %>">
                <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                  <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>"
                    width="142" height="80" class="thumwar" />
                </a><a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                  class="play_ico">&nbsp;</a>
              </div>
              <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                class="clip_link_1">
                <%#DataBinder.Eval(Container.DataItem, "Name")%>
              </a>
              <div class="clip_lead_new">
                <%#DataBinder.Eval(Container.DataItem, "Lead")%>
              </div>
              <div class="ratting_list none">
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="clear">
                  ,</div>
              </div>
              <div class="clear">
                ,</div>
            </div>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <div class="clip_item_2">
              <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "clip_thumwar" %>">
                <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                  <img alt="" title="" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>"
                    width="142" height="80" class="thumwar" />
                </a><a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                  class="play_ico">&nbsp;</a>
              </div>
              <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                class="clip_link_1">
                <%#DataBinder.Eval(Container.DataItem, "Name")%>
              </a>
              <div class="clip_lead_new">
                <%#DataBinder.Eval(Container.DataItem, "Lead")%>
              </div>
              <div class="ratting_list none">
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="star_item">
                  <img src="/images/blank.gif" width="12" height="12" />
                </div>
                <div class="clear">
                  ,</div>
              </div>
              <div class="clear">
                ,</div>
            </div>
          </AlternatingItemTemplate>
        </asp:Repeater>
      </div>
      <!--other news end-->
    </div>
    <div class="home5right">
      <div class="home5_right">
        <div class=" row">
          <!--top statitic-->
          <uc:PanelClipNoibat ID="PanelClipNoibat1" runat="server" CategoryAlias="clip-mobile-noi-bat"
            FirstIndexRecord="1" LastIndexRecord="3" />
          <!--qc right2-->
          <uc:PanelTamdiem3g ID="PanelTamdiem3g1" runat="server" CategoryAlias="clip-mobile-tieu-diem"
            FirstIndexRecord="1" LastIndexRecord="4" />
          <div class="clear">
            ,</div>
          <!--qc right2 end-->
        </div>
        <div class=" row">
          <div>
            <div class="tt_ck">

            </div>
            <!--qc right 3 -->
            <uc:PanelAdvC_6_14 ID="PanelAdvC_6_14_1" runat="server" />
            <!--qc right 3 end-->
            <div class="clear">
              ,</div>
          </div>
        </div>
      </div>
    </div>
    <div class="clear">
      ,</div>
  </div>
  <uc:PanelAdvertisement ID="PanelAdvertisement1" runat="server" />
</asp:Content>
