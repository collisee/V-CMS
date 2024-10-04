<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateImageNews.ascx.cs"
    Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateImageNews" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<div class="panel1 photoSlide catePhoto pb10" id="photoSlide">
    <div class="pnl-top">
        <a href="#" class="title">
            <img alt="#" src="http://res.vietnamnet.vn/images/photo_r.gif" />&nbsp;Tin ảnh
        </a>
    </div>
    <div class="pnl-content">
        <div class="prev">
            <a href="javascript:void(0)">
                <img height="35" width="18" title="" alt="" src="http://res.vietnamnet.vn/images/tinanh_p.gif" /></a>
        </div>
        
        <div class="photoDeck">
            <div class="photo-container" style="left: 0px;">
            
                <asp:Repeater ID="rptImageNews" runat="server">
                    <ItemTemplate>
                        <div class="subpanel subpanel13 photoItem">
                            <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "ImageLink"), DataBinder.Eval(Container.DataItem, "Id"),
                                DataBinder.Eval(Container.DataItem, "Name"), "imgPreview", "none",
                                DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 240)%>
                            <div class="photo-text">
                              <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                                    DataBinder.Eval(Container.DataItem, "Name"), string.Empty, Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                                <div class="photo-intro">
                                    <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            
                <br class="clear">
            </div>
        </div>
        
        <div class="next">
            <a href="javascript:void(0)">
                <img height="35" width="18" title="" alt="" src="http://res.vietnamnet.vn/images/tinanh_n.gif" />
            </a>
        </div>
        <br class="clear" />
    </div>
</div>

<script type="text/javascript">
    function initPhotoSlide()
    {
        $('#photoSlide .photoDeck .photo-container .photoItem a.imgPreview').lightBox();
        VietNamNet.Framework.JS.PhotoSlide.init({id:'photoSlide', animation: true});
    }
    VietNamNet.Framework.JS.Initialization.call(initPhotoSlide);
</script>

