<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelSmallBar.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelSmallBar" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>


<script type="text/javascript">
jQuery(document).ready(function(){
	jQuery("#bar_hp").carouFredSel({
		auto : false,
		prev : {	
			button	: "#bar_prev",
			key		: "left"
		},
		next : { 
			button	: "#bar_next",
			key		: "right"
		}		
	});
});
</script>


<div class="box-hcm24h">
    <div class="hcm-title">
        <div class="hcm-logo">
            <a href="#">
                <img alt="#" height="23" width="102" src="http://res.vietnamnet.vn/images/blank.gif" />
            </a>     
        </div>
    </div>
    
    <div class="hcm-text">
        <div class="hcm-button">
            <a class="prev" id="bar_prev" href="#">
                <img alt="#" height="21" width="18" src="http://res.vietnamnet.vn/images/24h-back.gif" />
                
            </a>   
        </div>
        
        <div class="hcm-slider">
            <div id="bar_hp" class="hcm-group">
                    <asp:Repeater ID="rptBarHp" runat="server">
                        <ItemTemplate>                        
                            <div class="hcm-item">                         
                                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                            </div>                        
                        </ItemTemplate>
                </asp:Repeater>
               
                <div class="clear">&nbsp;</div>
            </div>
        </div>
        
        <div class="hcm-button">
            <a class="next" id="bar_next" href="#">
                <img alt="#" height="21" width="18" src="http://res.vietnamnet.vn/images/24h-next.gif" />
            </a>
        </div>
        <div class="clear">&nbsp;</div>
    </div>
    <div class="clear">&nbsp;</div>
</div>

