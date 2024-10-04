<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCategory.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCategory" %>
<div id="home5_1" class="row">
  <div class="cattitle">
    <div class="cattitle1">
      <div class="cattitle2">
        <asp:Repeater ID="rptCateTitle" runat="server">
          <ItemTemplate>
            <div class="cattitlebg">
              <%#WebsitesUtils.BuildCategoryLink(categoryUrl, DataBinder.Eval(Container.DataItem, "CategoryDisplayName"), string.Empty)%>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>
    <div class="cattitle_sub">
      <asp:HyperLink ID="cattitle_sub0" runat="server" Visible="false"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub1" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub2" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub3" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub4" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
      <asp:HyperLink ID="cattitle_sub5" runat="server" Visible="false" CssClass="sub_link"></asp:HyperLink>
    </div>
  </div>
  <div class="cattext">
    <div class="first_text">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="cat_box1">
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "left vien2 boder-img", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
          </div>
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "avata", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          <div class="cat_intro">
            <%#DataBinder.Eval(Container.DataItem, "Lead")%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="first_list">
      <asp:Repeater ID="rptTop3" runat="server">
        <ItemTemplate>
          <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "first_itema" : "first_itemb" %>">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "link_b", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
          <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "first_item_img" %>">
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 88, 50)%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <div class="clear">
        ,</div>
      <asp:Repeater ID="rptTop3_1" runat="server">
        <ItemTemplate>
          <div class="first_itema">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "link_b", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="clear">
      ,</div>
    <asp:Repeater ID="rptTop2" runat="server">
      <ItemTemplate>
        <div class="cat_item">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </a>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</div>
