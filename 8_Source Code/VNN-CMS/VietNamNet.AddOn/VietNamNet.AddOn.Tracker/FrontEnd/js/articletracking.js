var serviceArticle_post_url='http://track.srv.vietnamnet.vn/tracking/t.srv?'
    +'sn=article&dm=demo.vietnamnet.vn&us=me&vs=1'
    +'&aid=[ARITCLEID]&catalias=[CATEGORYALIAS]';

tempArticle=  '<div class="container"></div><iframe src="" class="post" style="display:none;"></iframe>';

function bindArticleTracking(divHolder,articleId,categoryalias){
    divHolder.html(tempArticle);
    
    var s = serviceArticle_post_url.replace("[ARITCLEID]",articleId).replace("[CATEGORYALIAS]",categoryalias);
    $('.post', divHolder).attr('src', s);
};
//<div articleTracking=true articleId=... categoryalias=...></div>
function showArticleTracking(){
   $('div[articleTracking=true]').each(function(){
        bindArticleTracking($(this),$(this).attr('articleId'),$(this).attr('categoryalias'));
   });
};

VietNamNet.Framework.JS.Initialization.add(showArticleTracking);
