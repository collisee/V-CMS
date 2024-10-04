<%@ OutputCache CacheProfile="ArticleCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="Detail.aspx.cs"
    Inherits="VietNamNet.Websites.Sport.ui.BBC.Detail" %>

<%@ Register Src="PanelBbcCateRight.ascx" TagName="PanelBbcCateRight" TagPrefix="uc" %>
<%@ Register Src="PanelContent.ascx" TagName="PanelContent" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pad">
        <div class="logobbc">
            <div class="bbc">
                <a href="http://www.bbc.co.uk/vietnamese/football/">
                    <img height="45" width="300" src="http://res.vietnamnet.vn/images/blank.gif"></a>
            </div>
            <div class="premier">
                <a href="http://vietnamnet.vn/thethao/">
                    <img height="55" width="410" src="http://res.vietnamnet.vn/images/blank.gif"></a>
            </div>
        </div>
        
        <div class="clear">
        </div>
        
        <div id="body" class="article-home">
            <div class="home2">
                <div class="home21">
                    <uc:PanelContent ID="PanelContent1" runat="server" />                    
                </div>
                <div class="home22">
                    <div class="home221">
                         <uc:PanelBbcCateRight CategoryAlias="bbc-tieng-viet-multimedia" FirstIndexRecord="1" LastIndexRecord="5" ID="PanelBbcCateRight1" runat="server" />
                         <uc:PanelBbcCateRight CategoryAlias="bbc-tieng-viet-binh-luan" FirstIndexRecord="1" LastIndexRecord="5" ID="PanelBbcCateRight2" runat="server" />
                         <uc:PanelBbcCateRight CategoryAlias="bbc-tieng-viet-ho-so-premiership" FirstIndexRecord="1" LastIndexRecord="5" ID="PanelBbcCateRight3" runat="server" />
                         <uc:PanelBbcCateRight CategoryAlias="bbc-tieng-viet-tin-bong-da" FirstIndexRecord="1" LastIndexRecord="5" ID="PanelBbcCateRight4" runat="server" />
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="smallbbc">
        </div>    

    </div>
<!-- START Nielsen//NetRatings SiteCensus V5.1 strict XHTML --> 
<!-- COPYRIGHT 2005 Nielsen//NetRatings --> 
<script type="text/javascript"> 
//<![CDATA[ 
var _rsCI="bbc"; 
var _rsCG="0"; 
var _rsDT=1; 
var _rsDU=0; 
var _rsDO=0; 
var _rsX6=0; 
var _rsSI=escape(window.location); 
var _rsLP=location.protocol.indexOf('https')>-1?'https:':'http:'; 
var _rsRP=escape(document.referrer); 
var _rsND=_rsLP+'//secure-uk.imrworldwide.com/'; 
if (parseInt(navigator.appVersion)>=4) 
{ 
 var _rsRD=(new Date()).getTime(); 
 var _rsSE=1; 
 var _rsSV=""; 
 var _rsSM=0.1; 
 _rsCL='<scr'+'ipt language="JavaScript" type="text/javascript"
src="'+_rsND+'v51.js"><\/scr'+'ipt>'; 
} 
else 
{ 
 _rsCL='<img
src="'+_rsND+'cgi-bin/m?ci='+_rsCI+'&cg='+_rsCG+'&si='+_rsSI+'&rp='+_rsRP+'" />'; 
} 
document.write(_rsCL); 
//]]> 
</script> 
<noscript> 
<div> 
 <img src="//secure-uk.imrworldwide.com/cgi-bin/m?ci=bbc&cg=0" alt="" /> 
</div> 
</noscript> 
<!-- END Nielsen//NetRatings SiteCensus V5.1 -->
</asp:Content>
