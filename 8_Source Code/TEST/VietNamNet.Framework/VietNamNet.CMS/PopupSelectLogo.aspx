<%@ Page MasterPageFile="~/Popup.Master" Language="C#" AutoEventWireup="true" CodeBehind="PopupSelectLogo.aspx.cs" Inherits="VietNamNet.CMS.PopupSelectLogo" Title="Chọn logo..." %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
        
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">

        <script type="text/javascript">

            function getRadWindow()
            {
                if (window.radWindow) return window.radWindow;
                if (window.frameElement && window.frameElement.radWindow) return window.frameElement.radWindow;
                return null;
            }
            
            function insertLogo(img){
                //bind data return
                var arg = {text: ''};
                
                //getData
                arg.text = '<img alt="" title="" src="' + img.src + '" />';
                
                //return data to parent
                var wnd = getRadWindow();
                if (wnd) wnd.close(arg); //use the close function of the getRadWindow to close the dialog 
                                         //and pass the arguments from the dialog to the callback function on the main page.
                else window.close();
            }

            function closeWin()
            {
                //bind data return
                var arg = {text: ''};
                //get a reference to the RadWindow
                var wnd = getRadWindow();

                //close the RadWindow            
                if (wnd) wnd.close(arg);
                else window.close();
            }
        
        </script>

    </telerik:RadScriptBlock>


    <div class="pd10">
        Chọn Logo
    </div>
    <div>
        <img alt="" title="" class="cpointer" src="http://image.vietnamnet.vn/logo/1.gif" onclick="insertLogo(this)" />
        <img alt="" title="" class="cpointer" src="http://image.vietnamnet.vn/logo/2.gif" onclick="insertLogo(this)" />
        <img alt="" title="" class="cpointer" src="http://image.vietnamnet.vn/logo/3.gif" onclick="insertLogo(this)" />
    </div>
</asp:Content>
