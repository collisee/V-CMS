<%@ Import namespace="VietNamNet.Websites.Petro.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubPanelTopImages.ascx.cs" Inherits="VietNamNet.Websites.Petro.UserControls.Homepage.SubPanelTopImages" %>
            <a id="top-image" href="/vn/<%=CategoryAlias %>/<%=ArticleId %>/<%=PetroUtils.BuildLink(ArticleName) %>.html"
                class="border-img hot-img">
                <img alt="<%=ArticleName %>" src="<%=ImageLink %>" width="300" height="186" />
            </a>
<script type="text/javascript">
        
    function loadImage()
    {
        AP.Core.JS.AjaxManager.add({
            url: '/ajax/getMedia/get.html',
            data: {DocId: <%=ArticleId %>, MediaType: 'Image'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = AP.Core.JS.JSON.decode(html);
                if (obj) {
                    if (obj.length && obj.length > 0) {
                        var imgIndex = 0;
                        $('#top-image img').attr('src', obj[imgIndex++].file).show();
                        window.setInterval(function(){
                            $('#top-image img').fadeOut(function(){
                                $(this).attr('src', obj[imgIndex++].file).fadeIn('slow');
                            })
                        }, 7000);
                    }else{
                        $('#top-image img').attr('src', obj.file);
                    }
                };
            }
        });
    }
    
    AP.Core.JS.Initialization.call(loadImage);

</script>