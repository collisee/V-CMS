<%@ Import Namespace="VietNamNet.Websites.Petro.Common" %>
<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelHotNews.ascx.cs"
  Inherits="VietNamNet.Websites.Petro.UserControls.PanelHotNews" %>
<div class="hotdiv">
  <div class="hot-link" id="hot-link">
    TIN NÓNG :
    <asp:Repeater ID="rptHotNews" runat="server">
      <ItemTemplate>
        <span class="hot-news-item" style="display: none;"><a class="link" href="/vn/<%#CategoryAlias %>/<%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#PetroUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name") %>
        </a><font class="update">(
          <%#Utilities.FormatDisplayDateTime((DateTime)DataBinder.Eval(Container.DataItem, "PublishDate")) %>
          (GMT+7) )</font> </span>
      </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
      &nbsp;</div>
  </div>
  <div class="box-search">
    <asp:TextBox ID="txtSearchkeyword" runat="server" class="form-search" Text="search..."></asp:TextBox><asp:ImageButton
      ID="btnSearch" runat="server" ImageUrl="~/data/search.png" OnClick="btnSearch_Click" />
  </div>
  <div class="clear">
    &nbsp;</div>
</div>

<script type="text/javascript">
    $(document).ready(function(){
        var hotNewsIndex = 0;
        function showHotNews(){
            $('#hot-link .hot-news-item').hide().each(function(D){
                if (D == hotNewsIndex) $(this).fadeIn('slow');
            });
            hotNewsIndex++;
            if (hotNewsIndex >= 3) hotNewsIndex = 0;
        }
        showHotNews();
        window.setInterval(showHotNews, 5000);
    })
</script>