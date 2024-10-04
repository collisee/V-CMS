<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelSearchGoogle.ascx.cs"  Inherits="VietNamNet.Websites.English.UserControls.Search.PanelSearchGoogle" %>
<script src="http://www.google.com/jsapi?key=ABQIAAAAm7qKx0DY58ynB_pA9Fgn3xSWTC6tfniVn0gKvVitmGXZ8ygW3xQruWbgARCEA2Cj9BTQPBUI0Li4Kw" type="text/javascript"></script>
    <link href="/Styles/googlestyle.css" rel="stylesheet" type="text/css" />
    
<div class="pdlr5">
    <div class="bg_title3">SEARCH</div>
</div>
                    
<div class="pd10">
               
<div id="SearchContent">
    <div id="searchcontrol">Loading...</div>

</div>


</div>
                       
                       

		
	
<asp:Label runat="server" ID="lblMessages" Visible="false"/>
<asp:Literal runat="server" ID="lScript"></asp:Literal>
    <script language="Javascript" type="text/javascript">
     //<![CDATA[

    google.load("search", "1");

    function OnLoad() {
      // Create a search control
      var searchControl = new google.search.CustomSearchControl('english.vietnamnet.vn');

    options = new google.search.SearcherOptions();
    //searchControl.addSearcher(new google.search.WebSearch(), options);
        var siteSearch = new google.search.WebSearch();
          siteSearch.setUserDefinedLabel("english.vietnamnet.vn");
          siteSearch.setUserDefinedClassSuffix("siteSearch");
          siteSearch.setSiteRestriction("english.vietnamnet.vn");
      searchControl.addSearcher(siteSearch, options);



      //searchControl.addSearcher(new google.search.WebSearch());
      // Tell the searcher to draw itself and tell it where to attach
      searchControl.draw(document.getElementById("searchcontrol"));

      // Execute an inital search
      //searchControl.execute("site:english.vietnamnet.vn/* <%=SearchKeyword %>");
      searchControl.execute("<%=SearchKeyword %>");
      
    }
    google.setOnLoadCallback(OnLoad);

    //]]>
    
     if ('<%=SearchKeyword%>'!='')
            $('#SearchContent').removeHighlight().highlight('<%=SearchKeyword%>');

    </script> 
    