<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTamdiem.ascx.cs"
    Inherits="VietNamNet.Websites.Clip.UserControls.PanelTamdiem" %>

<script type="text/javascript">

jQuery(document).ready(function() {
    jQuery('#mycarousel').jcarousel({
    	wrap: 'circular'
    });
});

</script>

<div class="row mh100">
    <div class="hot-slide">
        <div class="slide_point">
            <div class="slide_point_v">
                &nbsp;</div>
            <div class="slide_point_v">
                &nbsp;</div>
            <div class="slide_point_a">
                &nbsp;</div>
            <div class="slide_point_n">
                &nbsp;</div>
            <div class="slide_point_n">
                &nbsp;</div>
        </div>
        <ul id="mycarousel" class="jcarousel-skin-tango">
            <asp:Repeater ID="rptTamdiem" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="vien1 boder-img">
                            <a href="/vn/<%=categoryUrl %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                                <img alt="" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=106&height=59" /></a></div>
                        <a href="/vn/<%=categoryUrl %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"
                            class="list_item_link link_b">
                            <%#DataBinder.Eval(Container.DataItem, "Name")%>
                        </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
