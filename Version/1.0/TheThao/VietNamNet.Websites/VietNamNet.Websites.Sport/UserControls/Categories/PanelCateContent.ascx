<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateContent.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Categories.PanelCateContent" %>
    <div class="cate-list-group">
      <asp:Repeater ID="rptListContent" runat="server">
        <ItemTemplate>
          <div class="cate-list-item">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cl-img", "none",
                  DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 128, 70)%>
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                              DataBinder.Eval(Container.DataItem, "Name"), "bc-new-title", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            <div class="bc-lead">
              <%#DataBinder.Eval(Container.DataItem, "Lead")%>
            </div>
            <br class="clear" />
          </div>
        </ItemTemplate>
      </asp:Repeater>
      <div class="cate-list-page">
        <%--<a href="#" class="cl-back">
          <img src="http://res.vietnamnet.vn/images/blank.gif" width="15" height="15" />
        </a><a href="#" class="cl-next">
          <img src="http://res.vietnamnet.vn/images/blank.gif" width="15" height="15" />
        </a>--%>
        <asp:HyperLink ID="hplPrev" runat="server" CssClass="cl-back">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:HyperLink>
        <asp:HyperLink ID="hplNext" runat="server" CssClass="cl-next">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:HyperLink>
      </div>
    </div>
