<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyDisplay.ascx.cs" Inherits="VietNamNet.Websites.V1.Survey.UserControls.SurveyDisplay" %>

<div class="vote_most">
    
    		<div class="vote_most_title">
					Thăm dò ý kiến 
				</div>
				
				<div class="vote_most_list">
					<div class="vote_question">
					        <asp:literal ID="lblQuestion" runat="server" ></asp:literal>
					</div>
					<div class="vote_most_item">
						
                        <asp:literal ID="lblOptions" runat="server" ></asp:literal> 
                      
					</div>
					
					<div class="vote_respost">
						 <asp:literal ID="lblButton" runat="server" ></asp:literal> 
						 <asp:literal ID="lblHidden" runat="server" ></asp:literal> 
					</div>
				</div>

   
   
				

 </div>