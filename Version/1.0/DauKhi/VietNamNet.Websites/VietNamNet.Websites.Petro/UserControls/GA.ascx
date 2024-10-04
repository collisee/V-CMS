<%@ Control Language="C#" AutoEventWireup="true" Codebehind="GA.ascx.cs" Inherits="VietNamNet.Websites.Petro.UserControls.GA" %>

<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-6610653-1']);
  _gaq.push(['_setDomainName', '.vietnamnet.vn']);
  _gaq.push(['_trackPageview']);

  _gaq.push(['_setAccount', 'UA-6610653-21']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

function recordOutboundLink(link, category, action) {
  try {
    var pageTracker=_gat._getTracker('UA-6610653-21');
    pageTracker._trackEvent(category, action);
    setTimeout('document.location = "' + link.href + '"', 100)
  }catch(err){}
}

</script>