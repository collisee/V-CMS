<%@ Import Namespace="VietNamNet.Framework.Common" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelBirthday.ascx.cs"
  Inherits="VietNamNet.AddOn.Union.UserControls.PanelBirthday" %>
<div>
  <div class="bg-title1">
    <div class="bg-title2">
      <div class="bg-title3">
        <a href="#" class="title">Happy Brithday</a>
      </div>
    </div>
  </div>
  <div class="block-body">
    <div class="happy_body">
      <img src="/data/happy.jpg" width="191" height="182" />
      <div class="block_title">
        <asp:Label ID="Label1" runat="server" Text="Hôm nay là sinh nhật" Visible="false"></asp:Label>
        <br />
        <asp:Repeater ID="rptBirthday" runat="server">
          <ItemTemplate>
            <%--<a href="/UserInfo.aspx?DocId=<%#DataBinder.Eval(Container.DataItem, "id") %>" class="happy-name">--%>
            <a href="/Messages/MessageEdit.aspx?ReceiverId=<%#DataBinder.Eval(Container.DataItem, "id") %>"
              class="happy-name">
              <%#DataBinder.Eval(Container.DataItem, "fullname") %>
            </a>
            <br />
            <%--<img src="<%#DataBinder.Eval(Container.DataItem, "Avatar") %>" />--%>
          </ItemTemplate>
        </asp:Repeater>
        <%--<a href="/Messages/MessageEdit.aspx" class="blue">Gửi Lời Chúc Đi Nào </a>--%>
        <span class="blue">
          <asp:Label ID="Label2" runat="server" Text="Gửi Lời Chúc Đi Nào" Visible="false"></asp:Label></span>
        <br />
      </div>
    </div>
    <!--ds cac SN sap toi-->
    <div>
      <div class="acc_title">
        <span id="ctl00_PanelRight1_PanelBirthday1_Label3">Sắp tới sinh nhật</span></div>
      <div class="bg-bd">
        <marquee class="list-brithday" onmouseout="this.start();" onmouseover="this.stop();"
          direction="left" scrolldelay="1" scrollamount="1">
          <asp:Repeater ID="rptBirthdayNext" runat="server">
            <ItemTemplate>
              <a href="/Messages/MessageEdit.aspx?ReceiverId=<%#DataBinder.Eval(Container.DataItem, "id") %>"
                class="happy-name">
                <%#DataBinder.Eval(Container.DataItem, "fullname") %>
              </a><span class="date-bd">(<%#Utilities.FormatDisplayDateOnly((DateTime)DataBinder.Eval(Container.DataItem, "Birthday")) %>)
              </span>
            </ItemTemplate>
          </asp:Repeater>
        </marquee>
      </div>
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