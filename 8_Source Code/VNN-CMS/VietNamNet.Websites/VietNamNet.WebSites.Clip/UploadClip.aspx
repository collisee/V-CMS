<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" Codebehind="UploadClip.aspx.cs"
  Inherits="VietNamNet.WebSites.Clip.UploadClip" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script>
        var imgSrc = '';
        
        function reloadValidImage()
        {
            if (!imgSrc) imgSrc = document.getElementById('<%=imgValidCode.ClientID %>').src;
            var rnd = (new Date().getMonth() + 1) + '' + (new Date().getDate()) + '' + (new Date().getHours()) + '' 
                + (new Date().getMinutes()) + '' + (new Date().getSeconds()) + '' + (new Date().getMilliseconds());
            document.getElementById('<%=imgValidCode.ClientID %>').src = imgSrc + '&' + rnd;
        }
</script>



  <div>
    <div id="home4_1">
      <div class="form-sentvideo">
        <div class="sentvideo-title">
            Video của bạn
        </div>
        <p>
            Vui lòng ghi tên, địa chỉ email và cung cấp một số thông tin liên quan
          đến hình ảnh, âm thanh hoặc video bạn gửi.
        </p>
        <p>
            Ngoài ra bạn nên cho chúng tôi số điện thoại để chúng tôi có thể liên lạc nếu
          cần thêm thông tin.</p>
        <p>
          Nếu bạn gặp khó khăn hay thắc mắc gì xin hãy email cho <a href="mailto:clipvnn@vietnamnet.vn">
            clipvnn@vietnamnet.vn</a>.</p>
        <p>
          Bạn cũng có thể gửi cho chúng tôi video qua email: <a href="mailto:clipvnn@vietnamnet.vn">
            clipvnn@vietnamnet.vn</a></p>
        <p>
          Các mục có dấu <font color="#ff0000">*</font> là bắt buộc.</p>
        <div class="form-chuan">
          <div class="clip_title">
            VietNamNet upload:</div>
          <div>
            <font color="#ff0000">*</font> Tên của bạn:
          </div>
          <div>
            <input runat="server" id="yourname" name="author" type="text" class="fr789" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập tên của bạn!" ControlToValidate="yourname"></asp:RequiredFieldValidator>
          </div>
          <div>
            <font color="#ff0000">*</font> Địa chỉ email của bạn:</div>
          <div>
            <input runat="server" id="youremail" name="email" type="text" class="fr789" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vui lòng nhập địa chỉ email!" ControlToValidate="youremail"></asp:RequiredFieldValidator>
          </div>
          <div>
           <font color="#ff0000">*</font> Số điện thoại liên lạc:</div>
          <div>
            <input runat="server" id="yourphone" name="phone" type="text" class="fr789" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vui lòng nhập số điện thoại!" ControlToValidate="yourphone"></asp:RequiredFieldValidator>
          </div>
          <div for="subject">
            <font color="#ff0000">*</font> Chủ đề:</div>
          <div>
            <input runat="server" id="yoursubject" name="subject" type="text" class="fr789" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Vui lòng nhập chủ đề!" ControlToValidate="yoursubject"></asp:RequiredFieldValidator>
          </div>
          <div>
            <label for="file">
               <font color="#ff0000">*</font> File Video:</label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng chọn file!" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator><br />
            <strong>Các tiêu chí gửi File</strong><br />
            - Cỡ tối đa của Clip,Video,Audio : 20MB<br />
            - Dạng: avi,flv,3gp<br />
          </div>
          
          <table>
            <tr>              
              <td colspan="3">
              <asp:Label ID="lblNotify" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label>
                <asp:RegularExpressionValidator ID="Rv1" runat="server" ErrorMessage="Chỉ cho phép file dạng : flv, avi, 3gp ! " ValidationExpression="^.*\.((a|A)(v|V)(i|I)|(3|3)|(g|G)(p|P)|(f|F)(l|L)(v|V))$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>&nbsp;
                
              </td>              
            </tr>
          </table>
          <table>           
            <tr>
                <td>
                    <asp:TextBox ID="txtValidCode" runat="server" Text="Mã bảo vệ" Width="100px" onfocus="if(this.value=='Mã bảo vệ')this.value=''" onblur="if(this.value=='')this.value='Mã bảo vệ'"></asp:TextBox>
                </td>
                <td>
                    <asp:Image ID="imgValidCode" runat="server" />
                    <img alt="" src="/Images/refresh.gif" style="cursor:pointer;" onclick="reloadValidImage()" />
                </td>
                <td>
                    <asp:Button ID="btSend" runat="server" OnClick="btSend_Click" Text="   Gửi   " />
                </td>
            </tr>
          </table>
          <div>
            Ghi chú&nbsp; video: (tối đa 500 mẫu tự)</div>
          <asp:TextBox ID="yournote" runat="server" Height="200px" MaxLength="2000" TextMode="MultiLine"
            Width="580px"></asp:TextBox><p>
              VietNamNet sẽ xử lý các Thông Tin Cá Nhân bạn cung cấp theo các quy định của mình.
              Nếu ý kiến của bạn được đăng, VietNamNet chỉ ghi tên và nơi ở của bạn. Nếu như bạn
              không muốn tên và nơi ở của bạn xuất hiện, xin cho chúng tôi biết trong hộp ý kiến.
            </p>
          <p>
            Xin Chân Thành Cảm Ơn Sự Hợp Tác Của Bạn !!!</p>
        </div>
      </div>
      <div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
      </div>
    </div>
    <div class="clear">
    </div>
  </div>
</asp:Content>
