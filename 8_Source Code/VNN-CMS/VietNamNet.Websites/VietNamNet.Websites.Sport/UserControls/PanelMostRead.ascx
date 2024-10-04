<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMostRead.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.PanelMostRead" %>

<script type="text/javascript">
	$(document).ready(function(){
		$("div.mostread-feedback-item", $('#mostread')).hide();
		$("div.mostread-head a", $('#mostread')).click(function(){
			$("div.mostread-feedback-item", $('#mostread')).slideUp("slow");
			//$("div.mostread-feedback-head", $('#mostread')).removeClass('phanhoi2').addClass('phanhoi');
			$("div.mostread-item", $('#mostread')).slideDown("slow");
			//$("div.mostread-head", $('#mostread')).removeClass('doc').addClass('doc2');
			return false;
		});
		$("div.mostread-feedback-head a", $('#mostread')).click(function(){
			$("div.mostread-item", $('#mostread')).slideUp("slow");
			//$("div.mostread-head", $('#mostread')).removeClass('doc2').addClass('doc');
			$("div.mostread-feedback-item", $('#mostread')).slideDown("slow");
			//$("div.mostread-feedback-head", $('#mostread')).removeClass('phanhoi').addClass('phanhoi2');
			return false;
		});
	});
</script>

<div id="mostread" class="docs">
  <div class="docs-top">
    &nbsp;</div>
  <div class="pdlr5">
    <div class="doc2 mostread-head">
      <div class="arow-top">
        <a href="#">
          <img src="http://res.vietnamnet.vn/images/blank.gif" width="14" height="14" /></a>
      </div>
      <a href="#">Đọc nhiều nhất</a>
    </div>
    <div class="mostread-item docs-list">
      <asp:Repeater ID="rptMostRead" runat="server">
        <ItemTemplate>
          <div class="docs<%#Container.ItemIndex + 1%>">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
    <div class="phanhoi mostread-feedback-head">
      <div class="arow-bottom">
        <a href="#">
          <img src="http://res.vietnamnet.vn/images/blank.gif" width="14" height="14" /></a>
      </div>
      <a href="#">Phản hồi nhiều nhất</a>
    </div>
    <div class="mostread-feedback-item  docs-list">
      <asp:Repeater ID="rptMostFb" runat="server">
        <ItemTemplate>
          <div class="docs<%#Container.ItemIndex + 1%>">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
  </div>
  <div class="docs-bottom">
    &nbsp;</div>
</div>
