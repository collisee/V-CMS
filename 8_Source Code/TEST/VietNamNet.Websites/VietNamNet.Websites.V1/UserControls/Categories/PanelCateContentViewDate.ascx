<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelCateContentViewDate.ascx.cs" Inherits="VietNamNet.Websites.V1.UserControls.Categories.PanelCateContentViewDate" %>
<div class="viewbydate">
    <table cellspacing="0" cellpadding="0" width="470px">
        <tbody>
            <tr>
                <td align="left">
                    Các tin đã đưa theo ngày:
                </td>
                <td align="right">
                    <select id="view-date" class="">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                        <option value="13">13</option>
                        <option value="14">14</option>
                        <option value="15">15</option>
                        <option value="16">16</option>
                        <option value="17">17</option>
                        <option value="18">18</option>
                        <option value="19">19</option>
                        <option value="20">20</option>
                        <option value="21">21</option>
                        <option value="22">22</option>
                        <option value="23">23</option>
                        <option value="24">24</option>
                        <option value="25">25</option>
                        <option value="26">26</option>
                        <option selected="true" value="27">27</option>
                        <option value="28">28</option>
                        <option value="29">29</option>
                        <option value="30">30</option>
                        <option value="31">31</option>
                    </select>
                    <select id="view-month">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option selected="true" value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                    </select>
                    <select id="view-year">
                        <option value="2005">2005</option>
                        <option value="2006">2006</option>
                        <option value="2007">2007</option>
                        <option value="2008">2008</option>
                        <option value="2009">2009</option>
                        <option selected="true" value="2010">2010</option>
                    </select>
                    <input type="button" class="xem" value="Xem" onclick="vnn_get_by_date()">
                </td>
            </tr>
        </tbody>
    </table>
</div>