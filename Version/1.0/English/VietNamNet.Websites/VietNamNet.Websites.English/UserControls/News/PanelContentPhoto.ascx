<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelContentPhoto.ascx.cs" Inherits="VietNamNet.Websites.English.UserControls.News.PanelContentPhoto" %>
<br />
<div id="photo-slide" class="slide-show">
    <div class="slide-show-title">
        <div class="slide-show-next">
            <a class="title" href="javascript:slideNext()">
                <img alt="" width="23" height="20" class="image" src="/data/next.png" />
            </a>
        </div>
        <div class="page-photo">
            9/10
        </div>
        <div class="slide-show-back">
            <a class="title" href="javascript:slidePrev()">
                <img alt="" width="23" height="20" src="/data/back.png" />
            </a>
        </div>
        <div class="clear">&nbsp;</div>
    </div>
    <div class="photo_img">
        <img alt="" width="450" src="" />
    </div>
    <div class="photo_text">
        
    </div>
</div>

<script type="text/javascript">
    var objImages = null;
    var currentPhotoIndex = -1;
    var totalPhoto = 0;
    var photoTimeout;
    var photoTimeoutDelay = 7000;
    
    function initSlide(obj){
        if (obj.length && obj.length > 0){
            totalPhoto = obj.length;
            objImages = obj;
        }else{
            totalPhoto = 1;
            objImages = [obj];
        }
        slideNext();
    }
    
    function slideNext(){
        window.clearTimeout(photoTimeout);
        
        currentPhotoIndex++;
        if (currentPhotoIndex >= totalPhoto) currentPhotoIndex = 0;
        $('#photo-slide .page-photo').html( (currentPhotoIndex + 1) + '/' + totalPhoto);
        $('#photo-slide .photo_img img').attr('src', objImages[currentPhotoIndex].file)
            .attr('alt', objImages[currentPhotoIndex].description);
        $('#photo-slide .photo_text').html( objImages[currentPhotoIndex].description);
        
        photoTimeout = window.setTimeout(slideNext, photoTimeoutDelay);
    }
    
    function slidePrev(){
        window.clearTimeout(photoTimeout);
        
        currentPhotoIndex--;
        if (currentPhotoIndex <= 0) currentPhotoIndex = totalPhoto - 1;
        $('#photo-slide .page-photo').html( (currentPhotoIndex + 1) + '/' + totalPhoto);
        $('#photo-slide .photo_img img').attr('src', objImages[currentPhotoIndex].file)
            .attr('alt', objImages[currentPhotoIndex].description);
        $('#photo-slide .photo_text').html( objImages[currentPhotoIndex].description);
        
        photoTimeout = window.setTimeout(slideNext, photoTimeoutDelay);
    }
    
    function initPhoto(){
        AP.Core.JS.AjaxManager.add({
            url: '/ajax/getMedia/get.html',
            data: {DocId: <%=ArticleId %>, MediaType: 'Image'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = AP.Core.JS.JSON.decode(html);
                if (obj) {
                    initSlide(obj);
                }else{
                    $('#photo-slide').hide();
                };
            }
        });
    }
    
    AP.Core.JS.Initialization.add(initPhoto);
</script>