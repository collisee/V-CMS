<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTopNews.ascx.cs"
    Inherits="VietNamNet.Websites.Petro.UserControls.Homepage.PanelTopNews" %>
<div class="most-new">
    <img alt="" src="/data/title_tinmoi.jpg" width="140" height="25" />
    <asp:Repeater ID="rptTopNews" runat="server">
        <HeaderTemplate>
            <table cellpadding="0" cellspacing="0" class="most-list" width="310px">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td valign="middle" align="center" class="most-img">
                    <div class="border-img">
                        <a href="/vn/tin-moi/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                            <img alt="<%#DataBinder.Eval(Container.DataItem, "Name") %>" src="<%#DataBinder.Eval(Container.DataItem, "ImageLink") %>"
                                width="115px" height="70px" /></a>
                    </div>
                </td>
                <td valign="top" align="left" class="most-title">
                    <div showlead="true">
                        <a lead="true" class="bold" href="/vn/tin-moi/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                            <%#DataBinder.Eval(Container.DataItem, "Name") %>
                        </a>
                        <div class="leadContent none">
                            <%#DataBinder.Eval(Container.DataItem, "Lead") %>
                        </div>
                    </div>
                    <div class="update">
                        <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
                        (GMT+7)</div>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
