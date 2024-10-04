<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="ArticlePreview.aspx.cs" Inherits="VietNamNet.CMS.Articles.ArticlePreview" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
    <style type="text/css">
        .article{ text-align:left; padding:10px 10px 0px 10px; width:500px; overflow:hidden; }
        .article_title{color:#a83465;
		        font-weight:bold;
		        font-size:18px;
		        font-family:Arial, Helvetica, sans-serif;
		        text-decoration:none;}
        .update2{color:#a9a9a9;
	        font-size:11px; 
	        font-family:Tahoma;
	        padding:8px 0px 8px 0px;}
        .article_intro{ font-size:10pt; padding:0px 0px 10px 0px; text-align:justify}
        .article_content{ text-align:justify;}
        .chuthich{ padding:4px 0px 4px 0px ; height:26px; color:#004276; font:Tahoma; font-size:11px; background-color:#eeeeee;}
    </style>
    
    <div class="article">
        <div class="article_title">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </div>
        <div class="update2">
            <asp:Label ID="lblPublishDate" runat="server" Text=""></asp:Label>
        </div>
        <div class="article_content">
            <asp:Label ID="lblDetail" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
