<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentImageSport.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentImageSport" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<script type="text/javascript">
$(document).ready(function(){
$("#photo_thethao_box").carouFredSel({
		items: {
			visible: 1,
			width: 218,
			height: 124			
		},		
		scroll: {
			items: 1,			
	        onAfter: function(oldItems, newItems, newSizes) {
	            $("#photo_thethao_description").html($('.tga_link', newItems).html());
	        }
		},
		auto: false,
		prev : {	
			button	: "#photo_thethao_prev",
			key		: "left"
		},
		next : { 
			button	: "#photo_thethao_next",
			key		: "right"
		},
		pagination	: "#photo_thethao_pagination"
	});
	
	initialTextGallery();
});

function initialTextGallery(){
	var itemFirst = $("#photo_thethao_box div:first");
	$("#photo_thethao_description").html($('.tga_link', itemFirst).html());
}
</script>
<div class="bbc-box">
    <div class="bbc-top">&nbsp;</div>
    
    <div class="pdlr5 ">
        <div class="box-item-title">
            <a href="/vn/anh-the-thao/index.html">Ảnh Thể Thao</a></div>
        <div class="box-tga">
            <div class="tga-back">
                <a href="#" id="photo_thethao_prev">
                    <img alt="#" src="http://res.vietnamnet.vn/sports/images/anh-back.gif" width="24" height="35" /></a>
            </div>
            <div class="tga-group">
                <div class="tga-item">
                    <div class="box-anh">
                        <div id="photo_thethao_box">
                            <asp:Repeater ID="rptImageSport" runat="server">
                                <ItemTemplate>
                                    <div class="fl_l">
                                      <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                        DataBinder.Eval(Container.DataItem, "Name"), "", "none",
                                        DataBinder.Eval(Container.DataItem, "ImageLink"), "tga_vien", 213, 119)%>
                                        <div class="tga_link none">
                                          <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                            DataBinder.Eval(Container.DataItem, "Name"), "", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                                        </div>
                                    </div>                                                               
                                </ItemTemplate>
                            </asp:Repeater>                   
                        </div>
                    </div>
                </div>
            </div>
            <div class="tga-next">
                <a href="#" id="photo_thethao_next">
                    <img alt="#" src="http://res.vietnamnet.vn/sports/images/anh-next.gif" width="24" height="35" /></a>
            </div>
            <br class="clear" />
            
            <div class="tga-link" id="photo_thethao_description"></div>            
            <div class="tga-point carousel_pagination" id="photo_thethao_pagination">
            </div>
        </div>
    </div>
    <div class="bbc-bottom">&nbsp;</div>
</div>
