﻿<%@ Import namespace="VietNamNet.CMS.Common"%>
<%@ Import namespace="VietNamNet.Framework.Common"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PanelArticleMedia.ascx.cs"
    Inherits="VietNamNet.CMS.Articles.UserControls.PanelArticleMedia" %>
<telerik:RadScriptBlock runat="server" ID="scriptBlock">

    <script type="text/javascript">
    
        function selectMedia()
        {
            OpenFileExplorerDialog('<%=txtMedia.ClientID %>');
        }

        function selectThumbnail()
        {
            OpenFileExplorerDialog('<%=txtThumbnail.ClientID %>');
        }

        function previewMedia()
        {
            var textbox = $find('<%=txtMedia.ClientID %>');
            if (textbox && textbox.get_value) window.open(textbox.get_value());
        }

        function previewThumbnail()
        {
            var textbox = $find('<%=txtThumbnail.ClientID %>');
            if (textbox && textbox.get_value) window.open(textbox.get_value());
        }

        function onRowDropping(sender,args) {
            if(sender.get_id() == "<%=radGridMedia.ClientID %>") {
                var node = args.get_destinationHtmlElement();
                if(!isChildOf('<%=radGridMedia.ClientID %>', node)) {
                    args.set_cancel(true);
                }
            }
        }

        function isChildOf(parentId, element) {
            while(element) {
                if(element.id && element.id.indexOf(parentId)> -1) {
                    return true;
                }
                element = element.parentNode;
            }
            return false;
        }
            
    </script>

    <script type="text/javascript">

        function selectAllCheckboxMedia(chk){
            $telerik.$(':input[type=checkbox]', $telerik.$('#<%=radGridMedia.ClientID %> *[class=flagDeleteCheckBox]'))
            .each(function(){
                this.checked = chk;
            });
        }

    </script>

</telerik:RadScriptBlock>
<div>
    <asp:Panel ID="pnlEdit" runat="server">
        <p>
            <asp:Label ID="lblMediaLabel" runat="server" CssClass="label w150" Text="File Media:"></asp:Label>
            <telerik:RadTextBox ID="txtMedia" runat="server" Width="450px" MaxLength="255">
            </telerik:RadTextBox>
            <img alt="Chọn media" title="Chọn media" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectMedia()" />
            <img alt="Xem meida" title="Xem meida" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewMedia()" />
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblThumbnailLabel" runat="server" CssClass="label w150" Text="File Thumbnail:"></asp:Label>
            <telerik:RadTextBox ID="txtThumbnail" runat="server" Width="450px" MaxLength="255">
            </telerik:RadTextBox>
            <img alt="Chọn media" title="Chọn media" class="cpointer" src="/Images/SmallIcon/40.png" onclick="selectThumbnail()" />
            <img alt="Xem meida" title="Xem meida" class="cpointer" src="/Images/SmallIcon/75.png" onclick="previewThumbnail()" />
            <br class="clear" />
        </p>
        <p>
            <asp:Label ID="lblMediaDetailLabel" runat="server" CssClass="label w150" Text="Mô tả:"></asp:Label>
            <telerik:RadTextBox ID="txtMediaDetail" runat="server" Width="450px" Height="50px" TextMode="MultiLine" MaxLength="4000">
            </telerik:RadTextBox>
            <br class="clear" />
        </p>
        <asp:Button ID="btnAddMedia" runat="server" Text="Thêm file" Width="150px" OnClick="btnAddMedia_Click" />
    </asp:Panel>
    <br />
    <br />
    <telerik:RadGrid ID="radGridMedia" runat="server" AllowPaging="False" AllowCustomPaging="False" AllowSorting="False"
        AutoGenerateColumns="False" GridLines="None" OnNeedDataSource="radGridMedia_NeedDataSource"
        OnItemCommand="radGridMedia_ItemCommand" AllowMultiRowSelection="True" OnRowDrop="radGridMedia_RowDrop">
        <MasterTableView ClientDataKeyNames="Id" DataKeyNames="Id" GroupLoadMode="Client"
            NoMasterRecordsText="Kh&#244;ng c&#243; phiên bản n&#224;o.">
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="<input type='checkbox' onclick='selectAllCheckboxMedia(this.checked)' />">
                    <HeaderStyle HorizontalAlign="Center" Width="40px" Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelected" runat="server" CssClass="flagDeleteCheckBox" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="STT">
                    <HeaderStyle HorizontalAlign="Right" Width="40px" Font-Bold="True" />
                    <ItemTemplate>
                        <%#Container.ItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="False">
                    <HeaderStyle Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MediaType" HeaderText="Loại media" UniqueName="MediaType">
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FileLink" HeaderText="Đường dẫn" UniqueName="FileLink"
                    Visible="False">
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Đường dẫn">
                    <ItemTemplate>
                        <a href="<%#DataBinder.Eval(Container.DataItem, "FileLink")%>" target="_blank">
                            <%#DataBinder.Eval(Container.DataItem, "FileLink")%>
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridTemplateColumn>
                <telerik:GridImageColumn DataImageUrlFields="Thumbnail" HeaderText="Thumbnail" UniqueName="Thumbnail"
                    ImageHeight="60">
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridImageColumn>
                <telerik:GridBoundColumn DataField="Detail" HeaderText="Mô tả" UniqueName="Detail" Visible="false">
                    <HeaderStyle Font-Bold="True" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Mô tả" UniqueName="DetailEdit">
                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <telerik:RadTextBox ID="txtDetail" runat="server" Width="250px" Height="50px" TextMode="MultiLine" MaxLength="4000" 
                            AutoPostBack="True" OnTextChanged="txtDetail_TextChanged" Text='<%#DataBinder.Eval(Container.DataItem, "Detail")%>'>
                        </telerik:RadTextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Mã nhúng" UniqueName="EmbedCode" Visible="false">
                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Width="240px" />
                    <ItemTemplate>
                        <asp:PlaceHolder runat="server" ID="plhEmbedVideo" Visible='<%#Utilities.StringCompare(DataBinder.Eval(Container.DataItem, "MediaType").ToString(), CMSConstants.MediaType.Video) %>'>
<textarea cols="" rows="" style="border:0px;width:200px;height:50px;overflow:hidden;" readonly="readonly" onclick="this.focus(); this.select();">
<embed width="450" height="285" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer" 
type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player" allowfullscreen="true"
wmode="transparent" quality="high" src="http://clip.vietnamnet.vn/Lib/player.swf"
flashvars="streamer=http://media.vietnamnet.vn/clip.php&amp;amp;file=<%#DataBinder.Eval(Container.DataItem, "FileLink")%>&amp;amp;image=<%#DataBinder.Eval(Container.DataItem, "Thumbnail")%>&amp;amp;skin=http://clip.vietnamnet.vn/Lib/vnn_v1.0.swf&amp;amp;autostart=false&amp;amp;shuffle=false&amp;amp;mute=false&amp;amp;repeat=none&amp;amp;displayclick=play&amp;amp;playlistsize=100&amp;amp;playlist=none" />
</textarea>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="plhEmbedAudio" Visible='<%#Utilities.StringCompare(DataBinder.Eval(Container.DataItem, "MediaType").ToString(), CMSConstants.MediaType.Audio) %>'>
<textarea cols="" rows="" style="border:0px;width:200px;height:50px;overflow:hidden;" readonly="readonly" onclick="this.focus(); this.select();">
<embed width="450" height="30" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer" 
type="application/x-shockwave-flash" allowscriptaccess="sameDomain" name="player" allowfullscreen="true"
wmode="transparent" quality="high" src="http://clip.vietnamnet.vn/Lib/player.swf"
flashvars="file=http://media.vietnamnet.vn/vnnclip<%#DataBinder.Eval(Container.DataItem, "FileLink")%>&amp;amp;skin=http://clip.vietnamnet.vn/Lib/vnn_v1.0.swf&amp;amp;autostart=false&amp;amp;shuffle=false&amp;amp;mute=false&amp;amp;repeat=none&amp;amp;displayclick=play&amp;amp;playlistsize=100&amp;amp;playlist=none" />
</textarea>
                        </asp:PlaceHolder>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                    ConfirmText="Bạn c&#243; chắc chắn muốn X&#243;a file n&#224;y?" ConfirmTitle="X&#243;a"
                    HeaderText="X&#243;a" Text="X&#243;a" UniqueName="Delete">
                    <ItemStyle CssClass="center" Width="32px" />
                    <HeaderStyle HorizontalAlign="Center" Width="32px" Font-Bold="True" />
                </telerik:GridButtonColumn>
            </Columns>
            <SortExpressions>
                <telerik:GridSortExpression FieldName="Ord"></telerik:GridSortExpression>
            </SortExpressions>
        </MasterTableView>
        <ClientSettings AllowRowsDragDrop="True" EnableRowHoverStyle="true">
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
            <Resizing AllowColumnResize="True" />
            <ClientEvents OnRowDropping="onRowDropping" />
        </ClientSettings>
        <FilterMenu EnableTheming="True">
            <CollapseAnimation Duration="200" Type="OutQuint" />
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <asp:Button ID="btnDelMedia" runat="server" Text="Xóa file Media đã chọn" Width="150px" OnClick="btnDelMedia_Click" />
    <br />
</div>
