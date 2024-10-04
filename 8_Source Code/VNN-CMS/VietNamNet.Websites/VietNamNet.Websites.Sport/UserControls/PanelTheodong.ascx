<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTheodong.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.PanelTheodong" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<script type="text/javascript">
$(document).ready(function(){
	$("#sukien_thethao_box").carouFredSel({
		auto : false,
		prev : {	
			button	: "#sukien_thethao_prev",
			key		: "left"
		},
		next : { 
			button	: "#sukien_thethao_next",
			key		: "right"
		},
		pagination	: "#sukien_thethao_pagination"
	});
});
</script>

<div class="sktt">
    <div class="sktt-top">&nbsp;</div>
    <div class="pdlr5">
        <div class="bc-title">
            <div id="sukien_thethao_pagination" class="sktt-point carousel_pagination">                
            </div>
            <a href="#">Sự kiện thể thao</a>
        </div>
        
        <div class="sktt-slide">
           <div id="sukien_thethao_box" class="sktt-group">
               <asp:Repeater ID="rptOnEvent" runat="server">
                   <ItemTemplate>
                       <div class="sktt-item">
                           <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                DataBinder.Eval(Container.DataItem, "Name"), string.Empty, "none",
                                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 158, 91)%>
                           <%-- <p>
                        <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                            DataBinder.Eval(Container.DataItem, "Name"), "list_item_link link_b", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                    </p>--%>
                       </div>
                   </ItemTemplate>
               </asp:Repeater>
           </div>        
            <div class="sktt-back">
                <a id="sukien_thethao_prev" href="#">
                    <img alt="#" height="30" width="31" src="http://res.vietnamnet.vn/images/blank.gif" />
                </a>
            </div>
            <div class="sktt-next">
                <a id="sukien_thethao_next" href="#">
                    <img alt="#" height="30" width="31" src="http://res.vietnamnet.vn/images/blank.gif" />
                </a>
            </div>
        </div>
    </div>
    <div class="sktt-bottom ">&nbsp;</div>
</div>







