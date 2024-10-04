<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateBoxRight1.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Homepage.PanelCateBoxRight1" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

    <div class="box-ttol">
        <div class="ttol-title">
            <a href="http://tintuconline.vietnamnet.vn" target="_blank">
                <img height="25" width="135" src="http://res.vietnamnet.vn/images/blank.gif" alt="#" />
            </a>
        </div>              
        
        <div class="ttol-text">
            
                <asp:Repeater ID="rptTop" runat="server">
                  <ItemTemplate>
                    <%--<a href="#" class="left vien2 boder-img" target="_blank">
                           <img height="64" width="116" src="/dataimages/201010//original/images2055875_cha.jpg" />
                    </a>--%>
                    <div class="cat_box1">                
                    <%#WebsitesUtils.BuildImageLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"),"left vien2 boder-img", "none",
                    DataBinder.Eval(Container.DataItem, "ImageLink"), string.Empty, 116, 64)%>
                    </div>
                      
                    <%--<a href="#" class="avata" target="_blank"></a>--%>
                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"), "avata", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>
                </ItemTemplate>
                </asp:Repeater>
             
             
            <div class="clear">,</div>
            
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                  <div class="bvkh-item">                
                    <%#WebsitesUtils.BuildTextLink(DataBinder.Eval(Container.DataItem, "Url"), DataBinder.Eval(Container.DataItem, "Id"),
                    DataBinder.Eval(Container.DataItem, "Name"),"link_b", Utilities.ParseInt(DataBinder.Eval(Container.DataItem, "ArticleContentTypeId")))%>                
                  </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
