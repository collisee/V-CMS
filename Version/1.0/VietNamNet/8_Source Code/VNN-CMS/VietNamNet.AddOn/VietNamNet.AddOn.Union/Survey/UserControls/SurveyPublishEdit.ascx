<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyPublishEdit.ascx.cs" Inherits="VietNamNet.AddOn.Survey.UserControls.SurveyPublishEdit" %>
<table cellspacing="2" cellpadding="2">                        
                        <tr>
                            <td  width="100"><label>Ngày bắt đầu</label></td>
                            <td  width="200">
                                <telerik:RadDatePicker  ID="txtStartDate" runat="server"   Culture="Vietnamese (Vietnam)"      >
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td ><label>Ngày Kết thúc</label></td>
                            <td  >
                                <telerik:RadDatePicker  ID="txtExpireDate" runat="server"   Culture="Vietnamese (Vietnam)"      >
                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td ><label>Kết quả</label></td>
                            <td >
                               <asp:RadioButtonList runat="server" ID="radSecurity" RepeatDirection="Horizontal" RepeatLayout="Flow"  >
                                    <asp:ListItem Value="0" Text="Private" Selected="True"  ></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Public" ></asp:ListItem>
                               </asp:RadioButtonList>
                            </td>
                        </tr>
                   </table>
<asp:TextBox ID="txtSurveyId" runat="server" Visible="false" ></asp:TextBox>
<asp:TextBox ID="txtSurveyPublishId" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtCatId" runat="server" Visible="false"></asp:TextBox>

<asp:TextBox ID="txtArticleId" runat="server" Visible="false"></asp:TextBox>


<asp:TextBox ID="txtStatus" runat="server" Visible="false"></asp:TextBox>
