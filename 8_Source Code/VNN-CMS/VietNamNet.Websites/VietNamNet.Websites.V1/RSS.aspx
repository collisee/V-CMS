<%@ OutputCache CacheProfile="SystemCache" %>
<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="RSS.aspx.cs"
    Inherits="VietNamNet.Websites.English.RSS" %>

<%@ Register Src="UserControls/RSS/panelRSSdesc.ascx" TagName="panelRSSdesc" TagPrefix="rss" %>
<%@ Register Src="UserControls/Homepage/PanelTopNews.ascx" TagName="PanelTopNews"    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home-body">
        <div class="body680">
            <div class="body680-box3">
            
            <div class="body680-top3a">
                &nbsp;
            </div>
            <rss:panelRSSdesc ID="PanelRSSdesc1" runat="server" />
            <div class="body680-bottom3">
                &nbsp;
            </div>
            </div>
        </div> 
        <br class="clear" />
        &nbsp;</div> 
</asp:Content>
