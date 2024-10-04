<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateFocus.ascx.cs" Inherits="VietNamNet.Websites.English.UserControls.Category.PanelCateFocus" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>


<script type="text/javascript">

jQuery(document).ready(function() {
    jQuery('#mycarousel').jcarousel({
    	wrap: 'circular'
    });
});

</script>


<div class="focus-box">
            <div class="focus-top">&nbsp;</div>
            
            <div class="focus-list">
                <div class="bg_title2">
                    <a href="#">IN FOCUS </a>
                </div>
              
                <ul id="mycarousel" class="jcarousel-skin-tango">
                    <asp:Repeater ID="rptFocus" runat="server">
                        <ItemTemplate>
                            <li>
                            <div class="focus-item">
                                <div class="focus-img">
                                    <a href="#">
                                        <img alt="#" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>" />
                                    </a>
                                </div>
                                <div class="focus-title">
                                    <a href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                                        <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                    </a>
                                </div>
                            </div>
                            </li>
                        </ItemTemplate>                    
                    </asp:Repeater>                    
               </ul>
                             
                <br class="clear" />
            </div>
            
            <div class="focus-bottom">&nbsp;</div>
</div>