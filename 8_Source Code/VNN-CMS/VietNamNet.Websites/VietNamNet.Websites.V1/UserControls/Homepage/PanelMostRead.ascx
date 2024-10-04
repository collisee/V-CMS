<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMostRead.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelMostRead" %>

<script type="text/javascript">
	$(document).ready(function(){
		$("div.mostread-feedback-item", $('#mostread')).hide();
		$("div.mostread-head a", $('#mostread')).click(function(){
			$("div.mostread-feedback-item", $('#mostread')).slideUp("slow");
			$("div.mostread-feedback-head", $('#mostread')).removeClass('phanhoi2').addClass('phanhoi');
			$("div.mostread-item", $('#mostread')).slideDown("slow");
			$("div.mostread-head", $('#mostread')).removeClass('doc').addClass('doc2');
			return false;
		});
		$("div.mostread-feedback-head a", $('#mostread')).click(function(){
			$("div.mostread-item", $('#mostread')).slideUp("slow");
			$("div.mostread-head", $('#mostread')).removeClass('doc2').addClass('doc');
			$("div.mostread-feedback-item", $('#mostread')).slideDown("slow");
			$("div.mostread-feedback-head", $('#mostread')).removeClass('phanhoi').addClass('phanhoi2');
			return false;
		});
	});
</script>

<div id="mostread" class="thongke">
  <div class="doc2 mostread-head">
    <a href="#">
      <img alt="" src="http://res.vietnamnet.vn/images/blank.gif" width="180" height="22" /></a></div>
  <div class="thongke_list mostread-item">
    <ul>
      <asp:Repeater ID="rptMostRead" runat="server">
        <ItemTemplate>
          <li class="thongke_item"><a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a></li>
        </ItemTemplate>
      </asp:Repeater>
    </ul>
  </div>
  <div class="phanhoi mostread-feedback-head">
    <a href="#">
      <img alt="" src="http://res.vietnamnet.vn/images/blank.gif" width="180" height="22" /></a></div>
  <div class="thongke_list mostread-feedback-item">
    <ul>
      <asp:Repeater ID="rptMostFb" runat="server">
        <ItemTemplate>
          <li class="thongke_item"><a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name")) %>.html">
            <%#DataBinder.Eval(Container.DataItem, "Name")%>
          </a></li>
        </ItemTemplate>
      </asp:Repeater>
    </ul>
  </div>
  <div class="thongke_bt">
    <a href="#"></a>
  </div>
</div>
