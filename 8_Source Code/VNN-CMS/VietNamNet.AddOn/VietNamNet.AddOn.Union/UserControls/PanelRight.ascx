<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelRight.ascx.cs"
    Inherits="VietNamNet.AddOn.Union.UserControls.PanelRight" %>
<%@ Register Src="PanelArticleTop.ascx" TagName="PanelArticleTop" TagPrefix="uc" %>
<%@ Register Src="PanelCalendar.ascx" TagName="PanelCalendar" TagPrefix="uc" %>
<%@ Register Src="PanelCuocthi.ascx" TagName="PanelCuocthi" TagPrefix="uc" %>
<%@ Register Src="PanelRSS.ascx" TagName="PanelRSS" TagPrefix="uc" %>
<%@ Register Src="PanelBirthday.ascx" TagName="PanelBirthday" TagPrefix="uc" %>
<uc:PanelBirthday ID="PanelBirthday1" runat="server"></uc:PanelBirthday>
<%--<div>
  <img src="/data/qc1.jpg" width="235" height="124" />
</div>--%>
<%--<uc:PanelCuocthi ID="PanelCuocthi1" runat="server" CategoryAlias="cuoi"></uc:PanelCuocthi>--%>
<%--<uc:PanelArticleTop ID="PanelArticleTop1" runat="server" CategoryAlias="cuoi"></uc:PanelArticleTop>--%>
<%--<uc:PanelCalendar ID="PanelCalendar1" runat="server"></uc:PanelCalendar>--%>
<div id="Div1" class="row">
    <div class="bg-title1">
        <div class="bg-title2">
            <div class="bg-title3">
                <a href="#" class="title">Tin Vietnamnet</a>
            </div>
        </div>
    </div>
    <div class="block-body">
        <marquee height="220" onmouseout="this.start();" onmouseover="this.stop();" direction="up"
            scrolldelay="1" scrollamount="1" style="margin-top: 5px;">
                <uc:PanelRSS id="PanelRSS1" runat="server" RSSUrl="http://vietnamnet.vn/xahoi/index.rss" />
                <uc:PanelRSS id="PanelRSS3" runat="server" RSSUrl="http://vietnamnet.vn/chinhtri/index.rss" />
                <uc:PanelRSS id="PanelRSS4" runat="server" RSSUrl="http://vietnamnet.vn/vanhoa/index.rss" />
            </marquee>
    </div>
    <div class="bg-bgtitle1">
        <div class="bg-bgtitle2">
            <div class="bg-bgtitle3">
                &nbsp;
            </div>
        </div>
    </div>
</div>
<div id="Div2" class="row">
    <div class="bg-title1">
        <div class="bg-title2">
            <div class="bg-title3">
                <a href="#" class="title">Tin Vnexpress</a>
            </div>
        </div>
    </div>
    <div class="block-body">
        <marquee height="150" onmouseout="this.start();" onmouseover="this.stop();" direction="up"
            scrolldelay="1" scrollamount="1" style="margin-top: 5px;">
                <uc:PanelRSS id="PanelRSS2" runat="server" RSSUrl="http://vnexpress.net/rss/gl/trang-chu.rss" />
            </marquee>
    </div>
    <div class="bg-bgtitle1">
        <div class="bg-bgtitle2">
            <div class="bg-bgtitle3">
                &nbsp;
            </div>
        </div>
    </div>
</div>
