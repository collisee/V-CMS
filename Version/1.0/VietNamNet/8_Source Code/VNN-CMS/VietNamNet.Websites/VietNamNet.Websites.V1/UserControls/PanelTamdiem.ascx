<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTamdiem.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.PanelTamdiem" %>


<script type="text/javascript">
jQuery(document).ready(function(){
	jQuery("#foo2").carouFredSel({
		auto : false,
		prev : {	
			button	: "#foo2_prev",
			key		: "left"
		},
		next : { 
			button	: "#foo2_next",
			key		: "right"
		},
		pagination	: "#foo2_pag"
	});
});
</script>


<div class="image_carousel">
    <div id="foo2" class="image_carousel_content clearfix">
    
     <asp:Repeater ID="rptTamdiem" runat="server">
     <ItemTemplate>    
        <div class="carousel_item">       
            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 110, 63)%>
            
            <p>                
                <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), "list_item_link link_b", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
            </p>
        </div>        
       </ItemTemplate>
     </asp:Repeater>
       
    </div>
    
    <div class="clearfix"></div>
    
    <a class="prev" id="foo2_prev" href="#"><span>prev</span></a>
    <a class="next" id="foo2_next" href="#"><span>next</span></a>
    <div class="pagination" id="foo2_pag"></div>
</div>
