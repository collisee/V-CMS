<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelNewDetailPrint.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.News.PanelNewDetailPrint" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>

<asp:Repeater ID="rptNewsDetail" runat="server">
    <ItemTemplate>
       
            <br />
            
            <div id="date" class="content_date">
                Cập nhật lúc
                <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                (GMT+7)
            </div>
            
            <div id="title" class="content_title">
                <%#DataBinder.Eval(Container.DataItem, "Name") %>
            </div>
        
            <div id="subtitle">
                <%#DataBinder.Eval(Container.DataItem, "Title") %>
            </div>
                       
            <div class="fright">
                <a href="Javascript:window.print();"><img src="http://res.vietnamnet.vn/images/print.gif" alt="#" /></a>
            </div>
            
            <br class="clear" />            
            
            <div>
                <%#DataBinder.Eval(Container.DataItem, "Detail")%>
            </div>           
          
    </ItemTemplate>
</asp:Repeater>