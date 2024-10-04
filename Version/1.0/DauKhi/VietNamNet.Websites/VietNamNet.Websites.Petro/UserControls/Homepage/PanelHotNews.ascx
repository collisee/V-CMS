<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHotNews.ascx.cs"
    Inherits="VietNamNet.Websites.Petro.UserControls.Homepage.PanelHotNews" %>
<%@ Register Src="SubPanelTopImages.ascx" TagName="SubPanelTopImages" TagPrefix="uc" %>
<div class="new-hot">
    <asp:Repeater ID="rptHotNews" runat="server">
        <ItemTemplate>
            <uc:SubPanelTopImages id="SubPanelTopImages1" runat="server" ImageLink='<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>' CategoryAlias='<%#CategoryAlias %>' ArticleId='<%#DataBinder.Eval(Container.DataItem, "Id") %>' ArticleName='<%#DataBinder.Eval(Container.DataItem, "Name") %>' />
            <div class="hot-text">
                <a class="link" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                </a>
                <div class="update2">
                    <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                    (GMT+7)
                </div>
                <p>
                    <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                </p>
                <%--<div class="hot-comment">
                    <%=commentCounter%> bình luận
                </div>--%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="hot-list" style="float: right;width:330px;">
        <asp:Repeater ID="rptCate1" runat="server">
            <ItemTemplate>
                <div class="hot-item">
                    <a href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                        <%#DataBinder.Eval(Container.DataItem, "Name") %>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear">
        ,</div>
</div>
