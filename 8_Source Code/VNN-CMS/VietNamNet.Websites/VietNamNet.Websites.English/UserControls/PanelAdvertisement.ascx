<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelAdvertisement.ascx.cs" Inherits="VietNamNet.Websites.English.UserControls.PanelAdvertisement" %>
<script type="text/javascript">

    function initAdvertisement(){
        VietNamNet.Framework.JS.AjaxManager.add({
            url: '/ajax/getAdvertisement/get.html',
            data: {CateAlias: '<%=CategoryAlias %>'},
            success : function(h){
                var html = '';
                if (h && h != '""' && h != 'null') {html = h.trim();}else{return;};
                var obj = VietNamNet.Framework.JS.JSON.decode(html);
                VietNamNet.Framework.JS.Advertisement.init(obj);
            }
        });
    }
    
    VietNamNet.Framework.JS.Initialization.add(initAdvertisement);
</script>