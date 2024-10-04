<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PanelSendFeedBack.ascx.cs" Inherits="VietNamNet.Layout.Mobile.UserControls.PanelSendFeedBack" %>
<form runat="server" id="frmFeedback">
    <script type="text/javascript">
        function checkFeedback(){
            if (document.getElementById('<%=txtName.ClientID %>').value == '' || document.getElementById('<%=txtName.ClientID %>').value == 'Họ tên'){
                alert('Bạn phải điền Họ tên!');
                return false;
            }
            
            if (document.getElementById('<%=txtSubject.ClientID %>').value == '' || document.getElementById('<%=txtSubject.ClientID %>').value == 'Tiêu đề'){
                alert('Bạn phải điền Tiêu đề!');
                return false;
            }
            
            if (document.getElementById('<%=txtEmail.ClientID %>').value == '' || document.getElementById('<%=txtEmail.ClientID %>').value == 'Email'){
                alert('Bạn phải điền Email!');
                return false;
            }
            
            if (document.getElementById('<%=txtValidCode.ClientID %>').value == '' || document.getElementById('<%=txtValidCode.ClientID %>').value == 'Mã bảo vệ'){
                alert('Bạn phải điền Mã bảo vệ!');
                return false;
            }
            
            if (document.getElementById('<%=txtContent.ClientID %>').value == ''){
                alert('Bạn phải điền Nội dung!');
                return false;
            }
            
            return true;
        }
        
        var imgSrc = '';
        
        function reloadValidImage()
        {
            if (!imgSrc) imgSrc = document.getElementById('<%=imgValidCode.ClientID %>').src;
            var rnd = (new Date().getMonth() + 1) + '' + (new Date().getDate()) + '' + (new Date().getHours()) + '' 
                + (new Date().getMinutes()) + '' + (new Date().getSeconds()) + '' + (new Date().getMilliseconds());
            document.getElementById('<%=imgValidCode.ClientID %>').src = imgSrc + '&' + rnd;
        }
        
    </script>
    <div style="border-bottom:solid 1px #ccc;">
        <p style="padding:6px;">
            Gửi ý kiến của bạn:
        </p>
        <p style="padding:6px;">
            <asp:Label ID="lblInfo" runat="server" Text="Thông tin của bạn đã được gửi tới Tòa soạn. Trân trọng cảm ơn!" Visible="false" ForeColor="Blue"></asp:Label>
        </p>
        <p style="padding:6px;">
            <asp:TextBox ID="txtName" runat="server" Text="Họ tên" Width="100%" onfocus="if(this.value=='Họ tên')this.value=''" onblur="if(this.value=='')this.value='Họ tên'"></asp:TextBox>
        </p>
        <p style="padding:6px;">
            <asp:TextBox ID="txtSubject" runat="server" Text="Tiêu đề" Width="100%" onfocus="if(this.value=='Tiêu đề')this.value=''" onblur="if(this.value=='')this.value='Tiêu đề'"></asp:TextBox>
        </p>
        <p style="padding:6px;">
            <asp:TextBox ID="txtEmail" runat="server" Text="Email" Width="100%" onfocus="if(this.value=='Email')this.value=''" onblur="if(this.value=='')this.value='Email'"></asp:TextBox>
        </p>
        <p style="padding:6px;">
            <asp:TextBox ID="txtValidCode" runat="server" Text="Mã bảo vệ" Width="100px" onfocus="if(this.value=='Mã bảo vệ')this.value=''" onblur="if(this.value=='')this.value='Mã bảo vệ'"></asp:TextBox>
            <asp:Image ID="imgValidCode" runat="server" />
            <img src="/data/refresh.gif" style="cursor:pointer;" onclick="reloadValidImage()" />
            <asp:Label ID="lblError" runat="server" Text="Sai mã bảo vệ" ForeColor="red" Visible="false"></asp:Label>
        </p>
        <p style="padding:6px;">
            <asp:TextBox ID="txtContent" runat="server" Text="Nội dung" Width="100%" TextMode="MultiLine" Height="100px" onfocus="if(this.value=='Nội dung')this.value=''" onblur="if(this.value=='')this.value='Nội dung'"></asp:TextBox>
        </p>
        <p style="padding:6px;">
            <asp:HiddenField ID="hidArticleId" runat="server" />
            <asp:HiddenField ID="hidArticleName" runat="server" />
            <asp:HiddenField ID="hidEmailTo" runat="server" Value="hotnews@vietnamnet.vn" />
            <asp:HiddenField ID="hidEmailCC" runat="server" Value="fmedia@vietnamnet.vn" />
            <asp:HiddenField ID="hidEmailBCC" runat="server" Value="tuananh@vietnamnet.vn" />
            <asp:HiddenField ID="hidEmailSubject" runat="server" Value="Ý kiến từ mobile: " />
            <asp:Button ID="btnSubmit" runat="server" Text="Gửi tòa soạn" OnClientClick="return checkFeedback();" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Xóa trắng" OnClientClick="this.form.reset(); return false;" />
        </p>
    </div>
</form>