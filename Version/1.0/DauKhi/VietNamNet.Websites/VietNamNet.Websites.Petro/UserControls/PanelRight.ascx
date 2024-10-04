<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRight.ascx.cs"
    Inherits="VietNamNet.Websites.Petro.UserControls.PanelRight" %>
<%@ Register Src="PanelOilPrice.ascx" TagName="PanelOilPrice" TagPrefix="uc" %>
<%@ Register Src="PanelMostRead.ascx" TagName="PanelMostRead" TagPrefix="uc" %>
<div class="homeright">
    <div class="new_hot row">
        <div class="new_hot_title1">
            <img alt="" width="285" height="25" src="/data/docnhieunhat.gif">
        </div>
        <uc:PanelMostRead ID="PanelMostRead1" runat="server" />
    </div>
    <div class="list-qc">
        <div class="border-img qc row ">
            <embed width="278" height="120" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
            wmode="transparent" quality="high" src="/data/company/Petro 300x120.swf" />
        </div>
        <%--<div class="border-img qc row ">
            <a href="http://daukhi.vietnamnet.vn/vn/tin-hot/36/pvn-chuan-bi-ky-truoc-dai-hoi-dang-bo-tap-doan-lan-i.html">
            <img alt="" src="/data/banner300.gif" width="278" height="112" />
            </a>
        </div>--%>
    </div>
    <div>
		<iframe style="padding:0px; margin:0px; border:0px;overflow:hidden;" scrolling="no" frameborder="0" src="http://doc1.srv.vietnamnet.vn/polldk/Default.aspx" width="300px" height="180px" id="binhchon">
		</iframe>
	</div>
    <div class="right-item row">
        <div class="bc-title">
            <%--Top Hot Camera--%>
            ỐNG KÍNH DẦU KHÍ
        </div>
        <a href="/vn/camera-dau-khi/index.html">
            <img alt="" src="/data/Videocmr.jpg" width="258" /></a>
    </div>
    <uc:PanelOilPrice ID="PanelOilPrice1" runat="server" />
    <div class="list-qc">
        <div class="border-img qc row ">
            <embed width="278" height="120" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
            wmode="transparent" quality="high" src="/data/company/DMC.swf" />
        </div>
        <div class="border-img qc row ">
            <embed width="278" height="120" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
            wmode="transparent" quality="high" src="/data/company/bannerdaukhi.swf" />
        </div>
        <div class="border-img qc row ">
            <embed width="278" height="120" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
            wmode="transparent" quality="high" src="/data/company/pvi.swf" />
        </div>
        <div class="border-img qc row ">
            <embed width="278" height="120" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
            wmode="transparent" quality="high" src="/data/company/pvc.swf" />
        </div>
        <div class="border-img qc row ">
            <embed width="278" height="120" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
            wmode="transparent" quality="high" src="/data/company/pvfc.swf" />
        </div>
        <%--<div class="border-img qc row ">
            <img alt="" src="/data/quangcao2.jpg" width="278" height="120" />
        </div>
        <div class="border-img qc row ">
            <img alt="" src="/data/quangcaoto.jpg" width="278" height="250" />
        </div>--%>
        <br />
    </div>
</div>
