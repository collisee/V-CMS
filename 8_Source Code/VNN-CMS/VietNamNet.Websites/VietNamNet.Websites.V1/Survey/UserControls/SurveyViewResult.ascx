<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyViewResult.ascx.cs" Inherits="VietNamNet.Websites.V1.Survey.UserControls.SurveyViewResult" %>
<div class="vote_most" id="<%=DialogName() %>" title="Kết quả bình chọn" >
    <div class="vote_most_title">
		Kết quả Bình chọn
	</div>
    	<div class="vote_most_list">
					<div class="vote_question">
					     <asp:Literal ID="lblQuestion" runat="server" /> 
					</div> 
						
    <asp:Repeater ID="rptView" runat="server">
        <HeaderTemplate><div class="vote_most_item survey"></HeaderTemplate>
        <FooterTemplate></div></FooterTemplate>
        <ItemTemplate>
        <div class="vote_item1 sitem">
            <div style="width: 55%; ">
                <label class="label"><%#DataBinder.Eval(Container.DataItem, "OptionName")%></label>  
            </div>
            <div style="width: 25%; ">
                  <div class="result" style="width:<%# int.Parse(DataBinder.Eval(Container.DataItem, "Result").ToString())*100/sumResult%>%">
                    
                  </div>
            </div>
            <div style="width: 10%; text-align:right; "><%# int.Parse(DataBinder.Eval(Container.DataItem, "Result").ToString())*100/sumResult%>%</div>
            <div style="width: 10%; text-align:right; "><%#DataBinder.Eval(Container.DataItem, "Result").ToString() %>/<%=sumResult.ToString() %></div>
        </div>
        </ItemTemplate>
    </asp:Repeater> 
    
					<div class="vote_respost">
						 <asp:literal ID="lblButton" runat="server" ></asp:literal> 
						 <asp:literal ID="lblHidden" runat="server" ></asp:literal> 
					</div>
				</div>
    

</div>  
<a href="#" class="jqmClose"></a>


<asp:Label runat="server" ID="lblMessages" Visible="false" ></asp:Label>

