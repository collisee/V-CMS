<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTinBongda.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.ui.BBC.PanelTinBongda" %>
<div class="khung22">
  <div class="new_fb">
    <div class="title2">
      <%--<a href="http://vietnamnet.vn/thethao/TT_BBC/tinbongda/index.rss" title="RSS" class="rss_bbc">
      </a><a class="title21" href="http://vietnamnet.vn/thethao/TT_BBC/tinbongda/">TIN BÓNG
        ĐÁ</a>--%>
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <%--<a href="/vn/<%=categoryUrl %>index.html" class="title21">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>--%>
          <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <asp:Repeater ID="rptTop3" runat="server">
      <ItemTemplate>
        <div class="item_new">
          <div class="new_img">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 104, 60)%>
          </div>
          <div class="new_text">
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), "link_content", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
          <div class="text_content">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <%--<div class="item_new">
      <div class="new_img">
        <img src="/img/bbc/images2058858_101027052415_javier_hernandez_466x262_nocredit.jpg"
          alt="Hernandez tỏa sáng giúp MU ở Carling Cup" width="104" height="60" />
      </div>
      <div class="new_text">
        <a class="link_content" href="/thethao/TT_BBC/tinbongda_new/201010/Hernandez-toa-sang-giup-Mu-o-Carling-Cup-944716/">
          Hernandez tỏa sáng giúp MU ở Carling Cup</a>
        <div class="text_content">
          Tiếp tục đà thi đấu ấn tượng với phong độ cao và duyên làm bàn rất tốt, tiền đạo
          Hernadez vừa giúp MU chiến thắng Wolveshampton tại Carling Cup.
        </div>
      </div>
    </div>--%>
    <div class="list_new">
      <asp:Repeater ID="rptTop5" runat="server">
        <ItemTemplate>
          <div class="item_listn">
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <%--<div class="item_listn">
        <a href="/thethao/TT_BBC/tinbongda_new/201010/Cong-ty-an-do-muon-mua-Blackburn-944540/">
          Công ty Ấn Độ muốn mua Blackburn</a>
      </div>--%>
    </div>
  </div>
</div>
