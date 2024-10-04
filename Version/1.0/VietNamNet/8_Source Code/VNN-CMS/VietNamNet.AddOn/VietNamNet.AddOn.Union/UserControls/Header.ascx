<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Header.ascx.cs" Inherits="VietNamNet.AddOn.Union.UserControls.Header" %>
<div id="home-banner">
    <div class="logo">
        <a href="http://www.vietnamnet.vn" target="_blank">
            <img src="/data/logovnn.png" width="180" height="85" /></a>
    </div>
    <div class="slogan">
        <a href="/vn/index.html">
            <img src="/data/logo-Union4.png" height="75" width="207" /></a>
    </div>
    <div class="qc_top">
        <embed width="550" height="80" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer"
        type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player"
        wmode="transparent" quality="high" src="/data/banner550x80.swf" />
    </div>
    <div class="clear">
        ,</div>
</div>
<div id="home-menu">
    <div class="home-mn1">
        <div class="home-mn2">
            <div class="home-mn">
                <div class="mn1-item">
                    <a href="/vn/gia-dinh-vnn/index.html" class="mn-link">Gia đình vietnamnet</a>
                </div>
                <div class="mn1-item">
                    <a href="/vn/thong-tin/index.html" class="mn-link">Thông tin</a>
                </div>
                <div class="mn1-item">
                    <a href="/vn/su-kien/index.html" class="mn-link">Sự kiện </a>
                </div>
                <div class="mn1-item">
                    <a href="/Union/Forum.aspx" class="mn-link">Diễn đàn </a>
                </div>
                <div class="mn1-item">
                    <a href="#" class="mn-link">Tiện ích </a>
                </div>
                <div class="clear">
                    &nbsp;</div>
            </div>
        </div>
    </div>
</div>
<div id="sub-menu" class="sub-menu" style="display: none;">
    <div id="sub0" class="sub-menu-item">
        <div class="sub-menu-item2">
            <a href="/vn/nhung-chang-duong/index.html">VNN - những chặng đường</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/so-do-to-chuc/index.html">Giới thiệu tổ chức</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/lanh-dao/index.html">Lãnh đạo</a>
        </div>
    </div>
    <div id="sub1" class="sub-menu-item">
        <div class="sub-menu-item2">
            <a href="/vn/hot-news/index.html">Hot news</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/noi-quy-quy-dinh/index.html">Nội quy - Quy định</a>
        </div>
    </div>
    <div id="sub2" class="sub-menu-item">
        <div class="sub-menu-item2">
            <a href="/vn/chung-ta-se-lam-gi/index.html">Sắp tới... chúng ta sẽ làm gì</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/ky-niem/index.html">Kỷ niệm</a>
        </div>
    </div>
    <%--<div id="sub3" class="sub-menu-item">
        <div class="sub-menu-item2">
            <a href="/vn/buon-chuyen/index.html">Buôn chuyện</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/cuoi/index.html">Cười</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/cuoc-thi/index.html">Cuộc thi</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/vn/goc-chia-se/index.html">Góc chia sẻ</a>
        </div>
    </div>--%>
    <div id="sub3" class="sub-menu-item">
        <div class="sub-menu-item2">
            <a href="/Union/Forum.aspx?id=2">Buôn chuyện</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/Union/Forum.aspx?id=3">Cười</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/Union/Forum.aspx?id=4">Cuộc thi</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/Union/Forum.aspx?id=5">Góc chia sẻ</a>
        </div>
    </div>
    <div id="sub4" class="sub-menu-item">
        <div class="sub-menu-item2">
            <a href="/UserView.aspx?Groups=2">Danh bạ</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/DocumentManager.aspx">Tài liệu - Văn bản</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/Calendar/Default.aspx">Lịch làm việc</a>
        </div>
        <div class="sub-menu-item2">
            <a href="/Calendar/RoomBooking.aspx">Đặt phòng họp</a>
        </div>
        <div class="sub-menu-item2">
            <a href="http://hotro.vietnamnet.vn/" target="_blank">Hỗ trợ kỹ thuật</a>
        </div>
    </div>
</div>
<script type="text/javascript">
    var menuTimeout;
    var currentMenu = -1;
    var timeOutDelay = 700;
    //menu
    $telerik.$('#home-menu .mn1-item a').mouseover(function(){
        window.clearTimeout(menuTimeout);
        //show hide sub-menu items
        var index = $telerik.$('#home-menu .mn1-item a').index(this);
        $telerik.$('#sub-menu .sub-menu-item').each(function(D){
            if (D == index) $telerik.$(this).show();
            else $telerik.$(this).hide();
        });
        //show sub-menu
        if (currentMenu != index){
            currentMenu = index;
            $telerik.$('#sub-menu').hide().css({
                    //top: $telerik.$(this).offset().top + 24,
                    left: $telerik.$(this).offset().left - 20
                }).slideDown();
        }else{
            $telerik.$('#sub-menu').slideDown();
        }
    }).mouseout(function(){
        menuTimeout = window.setTimeout(function(){
            $telerik.$('#sub-menu').slideUp();
        }, timeOutDelay);
    });
    
    //sub-menu
    $telerik.$('#sub-menu').mouseover(function(){
        window.clearTimeout(menuTimeout);
    }).mouseout(function(){
        menuTimeout = window.setTimeout(function(){
            $telerik.$('#sub-menu').slideUp();
        }, timeOutDelay);
    });
</script>