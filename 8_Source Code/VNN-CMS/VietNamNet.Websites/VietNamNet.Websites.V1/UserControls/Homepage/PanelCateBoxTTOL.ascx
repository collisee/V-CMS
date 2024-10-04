<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateBoxTTOL.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBoxTTOL" %>

<div class="row">
  <div class="cattext3">
    <div class="cm_titlte">
      <asp:Repeater ID="rptCateTitle" runat="server">
        <ItemTemplate>
          <a href="http://tintuconline.vietnamnet.vn/" target="_blank">
            <%#DataBinder.Eval(Container.DataItem, "CategoryDisplayName")%>
          </a>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    
    <div class="cattext2_1">
      <asp:Repeater ID="rptTop" runat="server">
        <ItemTemplate>
          <div class="vien2 boder-img">
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
          </div>
          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    
    <div class="cattext2_2">
      <asp:Repeater ID="rptNext" runat="server">
        <ItemTemplate>
          <div class="cm_item">
            <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "cm_link1" : "cm_link" %>">
              <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), "cmtitle", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </div>
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                DataBinder.Eval(Container.DataItem, "Name"), "cm_img", "none",
                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
            <div class="clear">
              ,</div>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    
    <div class="clear">,</div>
  </div>
</div>
