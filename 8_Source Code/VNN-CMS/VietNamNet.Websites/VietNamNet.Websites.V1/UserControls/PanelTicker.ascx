<%@ Import namespace="VietNamNet.Framework.Common"%>
<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelTicker.ascx.cs"
  Inherits="VietNamNet.Websites.V1.UserControls.PanelTicker" %>
<div id="icon">
  <div class="date">
    <%--Cập nhật 19:31, Thứ Hai, 12/04/2010 (GMT+7)--%>
        Cập nhật <%=Utilities.FormatDisplayDateTime(DateTime.Now) %> (GMT+7)
      <%--<script language="JavaScript">
// Get today's current date.
var now = new Date();

// Array list of days.
var days = new Array('Chủ nhật','Thứ 2','Thứ 3','Thứ 4','Thứ 5','Thứ 6','Thứ 7');

// Array list of months.
var months = new Array('Tháng 1','Tháng 2','Tháng 3','Tháng 4','Tháng 5','Tháng 6','Tháng 7','Tháng 8','Tháng 9','Tháng 10','Tháng 11','Tháng 12');

// Calculate the number of the current day in the week.
var date = ((now.getDate()<10) ? "0" : "")+ now.getDate();

// Calculate current time
  var curhour = now.getHours();
  var curmin = now.getMinutes();
  var cursec = now.getSeconds();
  var time = "";
 
//  if(curhour == 0) curhour = 12;
//  time = (curhour > 12 ? curhour - 12 : curhour) + ":" +
//         (curmin < 10 ? "0" : "") + curhour + ":" +
//         (cursec < 10 ? "0" : "") + cursec + " " +
//         (curhour > 12 ? "PM" : "AM");
  time = curhour + ':' + curmin;

// Calculate four digit year.
function fourdigits(number)	{
	return (number < 1000) ? number + 1900 : number;
								}

// Join it all together
today =  time + ", " + days[now.getDay()] + ', ' + date + '/' + (now.getMonth() + 1) + '/' + (fourdigits(now.getYear()));

// Print out the data.
document.write('Cập nhật ');
document.write(today);
document.write(' (GMT+7)');
      </script>--%>
  </div>
  <div class="link_hot">
    <a href="http://thethao.vietnamnet.vn/vn/bbc-tieng-viet/index.html" target="_blank"">
      <img src="http://res.vietnamnet.vn/images/logoBBC.gif" width="148" height="22" /></a> <a href="/vn/bao-ve-nguoi-tieu-dung/index.html">
        <img src="http://res.vietnamnet.vn/images/box_BVKH.gif" width="145" height="22" /></a>
  </div>
  
  <div class="last-new"><a href="/vn/tin-moi-nhat/index.html">» Tin mới nhất «</a></div>
  
  <div class="icon-slot">
    <img src="http://res.vietnamnet.vn/images/icon_thethao.gif" width="21" height="21" />
    <a href="http://thethao.vietnamnet.vn/vn/index.html" target="_blank"">Thể thao</a>
    <img src="http://res.vietnamnet.vn/images/icon_truyenhinh.gif" width="28" height="21" />
    <a href="http://clip.vietnamnet.vn/" target="_blank"">3G Hot</a>
    <img src="http://res.vietnamnet.vn/images/icon_mobi.gif" width="20" height="21" />
    <a href="#">Mobile</a>
  </div>
  
  <div class="clear">,</div>
</div>
