<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCateContent.ascx.cs" Inherits="VietNamNet.Websites.Clip.UserControls.Categories.PanelCateContent" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Import Namespace="VietNamNet.Websites.Core.Common" %>

<!--list tin-->
<div id="list-cate-new">

    <asp:Repeater ID="rptListContent" runat="server">
        <ItemTemplate>
            <div class="item">
                <div class="<%#Nulls.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageLink")) ? "none" : "item_img boder-img" %>">
                    <a href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
                         <img alt=  "" title="" src="http://203.162.71.133:8189/thumb/view.jpgx?file=<%#DataBinder.Eval(Container.DataItem, "ImageLink")%>&width=142&height=80" height="80" width="142" />
                    </a>                        
                </div>
                <a class="item_link" href="/vn/<%=categoryUrl %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html"><%#DataBinder.Eval(Container.DataItem, "Name")%></a>
                <div class="lead">
                    <%#DataBinder.Eval(Container.DataItem, "Lead")%>
                </div>
                <div class="clear">,</div>
            </div>        
        </ItemTemplate>
    </asp:Repeater>    
        
</div>

<div id="paging">
   <table border="0" width="100%">
    <tr>
        <td align="left">
            <asp:HyperLink ID="hplPrev" runat="server">&lt;&lt;Trang trước</asp:HyperLink>
        </td>
        <td align="right">
            <asp:HyperLink ID="hplNext" runat="server">Trang sau&gt;&gt;</asp:HyperLink>
        </td>
    </tr>
  </table>
    <div class="clear">,</div>
</div>



