<%@ Import namespace="VietNamNet.Websites.Core.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelMoinong.ascx.cs"
  Inherits="VietNamNet.Websites.Clip.UserControls.Homepage.PanelMoinong" %>
<div class="first_new">
  <div class="boder1">
    <img src="/images/new_boder1.gif" width="280px" height="3" /></div>
  <%--<ul class="u1_tooltip">--%>
  <div id="firstNew">
    <asp:Repeater ID="rptMoinong" runat="server">
      <ItemTemplate>
        <div class="p1_tooltip" showlead="true"><a lead="true" href="/vn/<%#DataBinder.Eval(Container.DataItem, "Url") %><%#DataBinder.Eval(Container.DataItem, "Id") %>/<%#WebsitesUtils.BuildLink(DataBinder.Eval(Container.DataItem, "Name").ToString()) %>.html">
          <%#DataBinder.Eval(Container.DataItem, "Name")%>
        </a>
          <div class="leadContent none">
            <%#DataBinder.Eval(Container.DataItem, "Lead") %>
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  <%--</ul>--%>
  </div>
  <div class="boder2">
    <img src="/images/new_boder2.gif" width="280px" height="3" /></div>
</div>

<script type="text/javascript">
    function initFirstNew(){
        var hp = $('#firstNew').parent().height();
        var tp = $('#firstNew').parent().offset().top;
        
        $('#firstNew div.p1_tooltip').each(function(){
            if ( ($(this).offset().top <= tp + hp && $(this).offset().top + $(this).height() > tp + hp)
                || $(this).offset().top > tp + hp ){
                $(this).hide();
            }
        })
    }
    
    VietNamNet.Framework.JS.Initialization.add(initFirstNew);
</script>