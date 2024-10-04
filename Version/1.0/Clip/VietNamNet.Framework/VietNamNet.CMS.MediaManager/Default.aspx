<%@ Page MasterPageFile="~/Default.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VietNamNet.CMS.MediaManager._Default" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cplhContainer">
	<telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">

        <script type="text/javascript">
            
            var controlId = '';
            
            function OpenFileExplorerDialog(ctrlId)
            {
                controlId = ctrlId;
                var wnd = $find('<%= FileExplorerWindow.ClientID %>');
                //add the name of the function to be executed when RadWindow is closed
                wnd.add_close(OnFileSelected);
                wnd.show();
            }

            //This function is called from the FileExplorer.aspx page
            function OnFileSelected(wnd, args)
            {
                var textbox = $find(controlId);
                //if (textbox && textbox.set_value) textbox.set_value(args.get_argument().fileSelected);
                if (textbox && textbox.set_value)
                {
                    var files = args.get_argument();
                    var v = '';
                    for (i = 0; i < files.length; i++)
                    {
                        if (v) v += ',';
                        v += files[i].file;
                    }
                    textbox.set_value(v);
                }
            }

        </script>

    </telerik:RadScriptBlock>
    <telerik:RadWindow runat="server" Width="680px" Height="550px" VisibleStatusbar="false" Behaviors="Close,Move"
        NavigateUrl="/FileManager.aspx" ID="FileExplorerWindow" Modal="True">
    </telerik:RadWindow>
    <div>
        <telerik:RadTextBox ID="txtFile" runat="server"></telerik:RadTextBox><span onclick="OpenFileExplorerDialog('<%=txtFile.ClientID %>')">open File explorer</span>
    </div>
    
</asp:Content>