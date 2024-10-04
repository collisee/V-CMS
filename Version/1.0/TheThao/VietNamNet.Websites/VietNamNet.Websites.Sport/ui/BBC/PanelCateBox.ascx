<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBox.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.ui.BBC.PanelCateBox" %>
<div class="khung31">
  <div class="blsc">
    <div class="title2">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <%--<a href="/vn/<%=categoryUrl %>index.html" class="title21">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>--%>
          <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
        </ItemTemplate>
      </asp:Repeater>
      <%--<a href="http://vietnamnet.vn/thethao/TT_BBC/benlesanco/index.rss" title="RSS" class="rss_bbc">
      </a><a class="title21" href="http://vietnamnet.vn/thethao/TT_BBC/hosopremiership/">
        HỒ SƠ PREMIERSHIP</a>--%>
    </div>
    <asp:Repeater ID="rptTop3" runat="server">
      <ItemTemplate>
        <div class="item_new">
          <div class="new_img">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 104, 58)%>
          </div>
          <div class="new_text">
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
              DataBinder.Eval(Container.DataItem, "Name"), "bc-new-title", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <%--<div class="item_new">
      <div class="new_img">
        <img src="http://images.vietnamnet.vn/dataimages/201008/normal/images2020516_Arsenal.jpg"
          alt="Dự đoán kỳ 2 - ứng viên Arsenal" width="104" height="58" />
      </div>
      <div class="new_text">
        <a href="/thethao/TT_BBC/hosopremiership_new/201008/Du-doan-ky-2-ung-vien-Arsenal-928541/">
          Dự đoán kỳ 2 - ứng viên Arsenal</a>
      </div>
    </div>
    <div class="item_new">
      <div class="new_img">
        <img src="http://images.vietnamnet.vn/dataimages/201008/normal/images2020514_kenneth_huang.jpg"
          alt="'Ông Hoàng Kenny' và thương vụ Liverpool" width="104" height="58" />
      </div>
      <div class="new_text">
        <a href="/thethao/TT_BBC/tinbongda_new/201008/Ong-Hoang-Kenny-va-thuong-vu-Liverpool-928394/">
          'Ông Hoàng Kenny' và thương vụ Liverpool</a>
      </div>
    </div>
    <div class="item_new">
      <div class="new_img">
        <img src="http://images.vietnamnet.vn/dataimages/201008/normal/images2015346_prediction.jpg"
          alt="Dự đoán kỳ 2 - ứng viên Arsenal" width="104" height="58" />
      </div>
      <div class="new_text">
        <a href="/thethao//TT_BBC/premierprofile/201008/Du-doan-ky-2-ung-vien-Arsenal-928459/">
          Dự đoán kỳ 2 - ứng viên Arsenal</a>
      </div>
    </div>--%>
    <asp:Repeater ID="rptTop5" runat="server">
      <ItemTemplate>
        <div class="list_new">
          <div class="item_listn">
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
    <%--<div class="list_new">
      <div class="item_listn">
        <a href="/thethao//TT_BBC/premierprofile/201008/Du-doan-nha-vo-dich-Premiership-Ky-1-928138/">
          Dự đoán nhà vô địch Premiership - Kỳ 1</a>
      </div>
    </div>
    <div class="list_new">
      <div class="item_listn">
        <a href="/thethao/TT_BBC/benlesanco_new/201007/Ashley-Cole-o-lai-Anh-25/7-924668/">
          Ashley Cole ở lại Anh (25/7)</a>
      </div>
    </div>
    <div class="list_new">
      <div class="item_listn">
        <a href="/thethao/TT_BBC/benlesanco_new/201007/Toure-tu-choi-MU-24/7-924498/">Toure
          từ chối MU (24/7)</a>
      </div>
    </div>
    <div class="list_new">
      <div class="item_listn">
        <a href="/thethao/TT_BBC/benlesanco_new/201007/Hoi-chot-vu-Milner-23/7-924334/">Hồi
          chót vụ Milner (23/7)</a>
      </div>
    </div>
    <div class="list_new">
      <div class="item_listn">
        <a href="/thethao/TT_BBC/benlesanco_new/201007/Donovan-the-cho-Milner-22/7-924112/">
          Donovan thế chỗ Milner? (22/7)</a>
      </div>
    </div>--%>
  </div>
</div>
