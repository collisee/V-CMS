<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMostRead.ascx.cs"
  Inherits="VietNamNet.Websites.Sport.UserControls.Categories.PanelMostRead" %>

<script type="text/javascript">
jQuery(document).ready(function(){
	jQuery(".box-docs-title-button").click(function(){
		jQuery(".cate-docs-list").css('display','none');
		jQuery(".box-docs-title-button").attr('class','box-docs-title-button');

		jQuery("#cate-docs-list-" + jQuery(this).index()).css('display','block');
		jQuery(this).attr('class','box-docs-title-button focus');
		return false;
	});			
});
</script>

<div class="bbc-box">
  <div class="bbc-top">
    &nbsp;</div>
  <div class="pdlr5 ">
    <div class="box-docs-title">
      <a class="box-docs-title-button focus" href="#">
        <img src="http://res.vietnamnet.vn/sports/images/box-docs-title-1.png" title="" align=""
          border="0" /></a><a class="box-docs-title-button" href="#"><img src="http://res.vietnamnet.vn/sports/images/box-docs-title-2.png"
            title="" align="" border="0" /></a>
    </div>
    <div class="cate-docs-list" id="cate-docs-list-0">
      <asp:Repeater ID="rptMostRead" runat="server">
        <ItemTemplate>
          <div class="cate-docs<%#Container.ItemIndex + 1%>">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>      
    </div>
    <div class="cate-docs-list" id="cate-docs-list-1" style="display: none;">
      <asp:Repeater ID="rptMostFb" runat="server">
        <ItemTemplate>
          <div class="cate-docs<%#Container.ItemIndex + 1%>">
            <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
          </div>
        </ItemTemplate>
      </asp:Repeater>      
    </div>
  </div>
  <div class="bbc-bottom">
    &nbsp;</div>
</div>
