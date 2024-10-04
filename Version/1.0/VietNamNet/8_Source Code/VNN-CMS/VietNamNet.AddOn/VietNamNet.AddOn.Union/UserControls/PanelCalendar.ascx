<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelCalendar.ascx.cs"
  Inherits="VietNamNet.AddOn.Union.UserControls.PanelCalendar" %>
<div class="row">
  <div class="bg-title1">
    <div class="bg-title2">
      <div class="bg-title3">
        <a href="#" class="title">Lịch Tòa Soạn</a>
      </div>
    </div>
  </div>
  <div class="block-body">
    <div class="lichts">
        <telerik:RadCalendar runat="server" ID="radCalendarSelectedDate" AutoPostBack="true"
            EnableMultiSelect="false" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
            EnableMonthYearFastNavigation="false" OnSelectionChanged="radCalendarSelectedDate_SelectionChanged">
        </telerik:RadCalendar>
    </div>
  </div>
  <div class="bg-bgtitle1">
    <div class="bg-bgtitle2">
      <div class="bg-bgtitle3">
        &nbsp;
      </div>
    </div>
  </div>
</div>