<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCate3gContent.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCate3gContent" %>
<div id="list-clip-new" class="row">
  <asp:Repeater ID="rptListContent" runat="server">
    <ItemTemplate>
      <div class="clip_item_1">
        <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "clip_thumwar" %>">
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), "thumwar", 142, 80)%>
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                "&nbsp;", "play_ico", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
        <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "clip_link_1", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        <div class="clip_lead_new">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
        <div class="ratting_list">
          <div class="star_item">
            <img alt="" title="" src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img alt="" title="" src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img alt="" title="" src="/images/blank.gif" width="12" height="12" />
          </div>
          <div class="star_item">
            <img alt="" title="" src="/images/blank.gif" width="12" height="12" />
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
            <%#WebsitesUtils.BuildImageLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), "thumwar", 142, 80)%>
            <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                "&nbsp;", "play_ico", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </div>
        <%#WebsitesUtils.BuildTextLink(categoryUrl, DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "clip_link_1", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        <div class="clip_lead_new">
          <%#DataBinder.Eval(Container.DataItem, "Lead")%>
        </div>
        <div class="ratting_list">
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
<div id="paging">
  <table border="0" width="100%">
    <tr>
      <td align="left">
        <asp:HyperLink ID="hplPrev" runat="server">&lt;&lt;Trang trước</asp:HyperLink>
      </td>
      <td align="right">
        <asp:HyperLink ID="hplNext" runat="server">Trang sau&gt;&gt;</asp:HyperLink>
      </td>
    </tr>
  </table>
  <div class="clear">
    ,</div>
</div>
