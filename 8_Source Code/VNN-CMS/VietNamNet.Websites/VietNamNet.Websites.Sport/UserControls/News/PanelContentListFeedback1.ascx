<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelContentListFeedback1.ascx.cs"
    Inherits="VietNamNet.Websites.Sport.UserControls.News.PanelContentListFeedback1" %>
<div>
    <div class="home-article-comment-box" id="feedback-title">
        <a name="feedBackList">&nbsp;</a>
        <%--<div id="feedback-sort">&nbsp;</div>--%>
        <div class="fb_title">
            <h2>
                Ý kiến bạn đọc</h2>
        </div>
        <div class="clear">
            ,</div>
    </div>
    <div class="list" id="feedback-list">
        <asp:Repeater ID="rptComment" runat="server">
            <ItemTemplate>
                <div class="feedback-item">
                    <div class="comment">
                        <i><%#DataBinder.Eval(Container.DataItem, "Subject")%></i><br />
                        <%#DataBinder.Eval(Container.DataItem, "Detail")%></div>
                    <div class="profile">
                        <b><%#DataBinder.Eval(Container.DataItem, "Name")%></b>, gửi lúc <%#DataBinder.Eval(Container.DataItem, "CreatedDate")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pagy cm-page" id="paging">
        &nbsp; 
        <asp:HyperLink ID="hlnkPrev" runat="server" CssClass="paging-prev">Trang trước</asp:HyperLink>
        &nbsp;
        <asp:HyperLink ID="hlnkNext" runat="server">Trang sau</asp:HyperLink>
        <br class="clear" />
    </div>
</div>
